#!/usr/bin/python

import subprocess
import re
import sys
import xml.etree.ElementTree as ET
import argparse

parser = argparse.ArgumentParser(description = "Add emt tags for latest version of striplet XMLs that do not have them.")
parser.add_argument("--location", '-l', default = None, help = "Location/station near which data needs to be changed\nexample: addEmtTagsToStripletsInTdms.py -l SPRINGS")
parser.add_argument("--user", "-u", default = None, help = "USER/TNS name to access and update TDMS.")
args = parser.parse_args()

def retrieve_tdms_label_id():
    input_cmd = 'identDbs | grep TDMS -i'
    session = subprocess.Popen(input_cmd, stdout=subprocess.PIPE, shell = True)
    output = session.communicate()[0]
    label_id = output[output.find('(')+1:output.find(')')]
    return str(label_id)

def execute_sql_query(sql_settings, sql_query, input_username):
    """Executes a SQL command against TDMS, using SQL*Plus.

    Arguments:
        sql_settings (str) -- Preferred SQL*Plus settings, if any.
        sql_query (str) -- The final SQL code snippet to be passed on to SQL*Plus.
        input_username (str) -- The ClearCase user name, which equals the TNS name for the user's DB.
    """
    session = subprocess.Popen(
        ['sqlplus', '-S', 'tdms/hello@' + input_username],
        stdin=subprocess.PIPE, stdout=subprocess.PIPE, stderr=subprocess.PIPE
    )
    session.stdin.write(str.encode(str(sql_settings) + '\n' + str(sql_query)))
    output, error = session.communicate()
    return output.decode(), error.decode()

def retrieve_striplet_ids(location, input_username):
    """Queries TDMS for striplet IDs corresponding to an input location. A user name is required for SQL*Plus.

    Notes:
        The striplet IDs come from the table, TDMS.TE_STRIPLET. The column name is given by STRIPLET_ID.

    Arguments:
        location (str) -- The input location corresponding to the mileposts to be added into TDMS.
        input_username (str) -- The ClearCase user name, which equals the TNS name for the user's DB.

    Returns:
        A list of str-formatted striplet IDs, if any striplet IDs exist for the location. Otherwise, returns None.
    """
    _sql_settings = 'set pagesize 0\nset long 1000000000\nset feedback off\n'
    _sql_query = "SELECT distinct STRIPLET_ID  from TE_STRIPLET where STRIPLET_NAME like '%" + location + "%' ORDER BY STRIPLET_ID;"
    output, error = execute_sql_query(_sql_settings, _sql_query, input_username)
    if len(output) == 0:
        return None
    output=output[output.find(re.search('[0-9]',output).group(0)):]
    ids = output.strip().split('\n')
    if len(ids) < 1:
        return None
    else:
        strip_list = []
        for i in ids:
            strip_id = i[i.find(re.search('[0-9]',i).group(0)):].strip()
            strip_list.append(strip_id)
        return strip_list

def retrieve_project_version(label_id, striplet_id, input_username):
    """Queries the project version, given a striplet ID and TDMS label ID. A user name is required for SQL*Plus.

    Arguments:
        label_id (str) -- The label id associated with the TDMS topology bundle.
        striplet_id (str) -- One of the striplet identifiers given by the input location.
        input_username (str) -- The ClearCase user name, which equals the TNS name for the user's DB.

    Notes:
        The project version comes from the table, TDMS.CM_LABEL_PROJECT. The column name is given by PROJECT_VERSION.

    Returns:
        The project version number, formatted as a string. Otherwise, returns None.
    """
    _sql_settings = 'set pagesize 0\nset long 1000000000\nset wrap off\nset trimspool on\nset linesize 32767\nset longchunksize 32767'
    _sql_query = "select CM_LABEL_PROJECT.PROJECT_VERSION from CM_LABEL_PROJECT where CM_LABEL_PROJECT.LABEL_ID =" + label_id + " and CM_LABEL_PROJECT.PROJECT_ID = (SELECT distinct TE_STRIPLET_CLOB.PROJECT_ID from TE_STRIPLET_CLOB where TE_STRIPLET_CLOB.STRIPLET_ID =" + striplet_id + ");"
    proj_output = execute_sql_query(_sql_settings, _sql_query, input_username)[0]
    try:
        proj_version = proj_output[proj_output.find(re.search('[0-9]',proj_output).group(0)):]
    except:
        return None
    proj_version = re.sub('\n','',proj_version).strip()
    return str(proj_version)

def retrieve_original_xml_striplet(project_version, striplet_id, input_username):
    """Queries the XML Clob associated with the project version and striplet ID. A user name is required for SQL*Plus.

    Arguments:
        project_version (str) -- The project version.
        striplet_id (str) -- One of the striplet identifiers given by the input location.
        input_username (str) -- The ClearCase user name, which equals the TNS name for the user's DB.

    Returns:
        The XML clob associated with the striplet ID, formatted as a string. Otherwise, returns None.
    """
    _sql_settings = "set pagesize 0\nset long 2000000000\nset trimspool on\nset linesize 32767\nset longchunksize 32767"
    _sql_query = "select TE_STRIPLET_CLOB.STRIPLET_DATA from TE_STRIPLET_CLOB where TE_STRIPLET_CLOB.PROJECT_VERSION = " + project_version + "and TE_STRIPLET_CLOB.STRIPLET_ID =" + striplet_id + ";"
    xml_strip = execute_sql_query(_sql_settings, _sql_query, input_username)[0]
    xml_strip = xml_strip.replace('\n','').replace('\r','')
    if len(xml_strip) > 40:
        return xml_strip

def modify_xml_striplet(xml_striplet):
    """Parses through the XML, adding EMT tags for mileposts if none exist.

    Arguments:
        xml_striplet (str) -- An XML clob, formatted as a string.

    Returns:
        Returns a modified, string representation of an XML clob. If no modifications to the XML are necessary, the function returns None.
    """
    tree = ET.fromstring(xml_striplet)
    try:
        track_nodes = tree.find('stpl').findall('dev_trk_sctn')
    except:
        track_nodes = -1
    if track_nodes != -1 and track_nodes is not None:
        for t in track_nodes:
            if t.find('emt') is not None:
                return None
            else:
                start_mp = round(float(t.attrib['start_mp']),6)
                end_mp = round(float(t.attrib['end_mp']), 6)
                resolution = round(abs(float(start_mp) - float(end_mp))*.01, 6)
                mp = min(start_mp, end_mp)
                mp_list = [mp]
                for i in range(3):
                    mp_list = mp_list + [round(mp + (1+i)*resolution,4)]
                mp_list = mp_list +[round(mp_list[-1] - .0001,4)]
                for m in mp_list:
                    emt_tag = ET.SubElement(t, 'emt')
                    emt_tag.set('mp','%.4f' % m)
        modified_xml_string = ET.tostring(tree).decode()
        if modified_xml_string != xml_striplet:
            return modified_xml_string

def construct_query_to_tdms(xml_string, project_version, striplet_id):
    """Iterates through the string-formatted XML clob, breaking the xml into sections that are small enough in character length for execution with SQL*Plus.

    Arguments:
        xml_string (str) -- The modified, string representation of the XML clob.
        project_version (str) -- The project version.
        striplet_id (str) -- One of the striplet identifiers given by the input location.

    Returns:
        All required SQL commands to be executed via SQL*Plus for the corresponding location.
    """
    sql_query = "update TE_STRIPLET_CLOB set STRIPLET_DATA = TO_CLOB('"+'<?xml version="1.0" standalone="no"?><!DOCTYPE tdms_msg>'+"') where TE_STRIPLET_CLOB.PROJECT_VERSION =" + project_version + " and TE_STRIPLET_CLOB.STRIPLET_ID =" + striplet_id + ";"
    iteration_count = len(xml_string)//1400
    for iteration_count in range(1, iteration_count+1):
        xml_substring = xml_string[(1400*(iteration_count-1)):(1400*iteration_count)]
        sub_query = "\n\nupdate TE_STRIPLET_CLOB set STRIPLET_DATA = STRIPLET_DATA || TO_CLOB('" + xml_substring + "') where TE_STRIPLET_CLOB.PROJECT_VERSION =" + project_version + " and TE_STRIPLET_CLOB.STRIPLET_ID =" + striplet_id + ";"
        sql_query = sql_query + sub_query
    xml_end_string = xml_string[(1400*iteration_count):]
    full_sql_query = sql_query + "\n\nupdate TE_STRIPLET_CLOB set STRIPLET_DATA = STRIPLET_DATA || TO_CLOB('" + xml_end_string + "') where TE_STRIPLET_CLOB.PROJECT_VERSION =" + project_version + " and TE_STRIPLET_CLOB.STRIPLET_ID =" + striplet_id + ";\ncommit;"
    return str(full_sql_query)

def main(location, input_username):
    tdms_label_id = retrieve_tdms_label_id()
    tdms_striplet_ids = retrieve_striplet_ids(location, input_username)
    if tdms_striplet_ids is not None:
        for strip in tdms_striplet_ids:
            proj_version = retrieve_project_version(tdms_label_id, strip, input_username)
            if proj_version is not None:
                original_xml = retrieve_original_xml_striplet(proj_version, strip, input_username)
                if original_xml is not None:
                    modified_xml = modify_xml_striplet(original_xml)
                    if modified_xml is not None:
                        sql = construct_query_to_tdms(modified_xml, proj_version, strip)
                        execute_sql_query(sql_settings = '', sql_query = sql, input_username = input_username)


if (args.location is not None and args.user is not None):
        main(args.location, args.user)