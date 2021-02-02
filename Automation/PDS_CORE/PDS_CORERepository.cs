﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace PDS_CORE
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the PDS_CORERepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("5a3e11ed-7012-4569-a9b8-11892349cf95")]
    public partial class PDS_CORERepository : RepoGenBaseFolder
    {
        static PDS_CORERepository instance = new PDS_CORERepository();
        PDS_CORERepositoryFolders.TrackLineWindowAppFolder _tracklinewindow;
        PDS_CORERepositoryFolders.Form_WarningBoxAppFolder _form_warningbox;
        PDS_CORERepositoryFolders.NetworkLogonAppFolder _networklogon;

        /// <summary>
        /// Gets the singleton class instance representing the PDS_CORERepository element repository.
        /// </summary>
        [RepositoryFolder("5a3e11ed-7012-4569-a9b8-11892349cf95")]
        public static PDS_CORERepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public PDS_CORERepository() 
            : base("PDS_CORERepository", "/", null, 0, false, "5a3e11ed-7012-4569-a9b8-11892349cf95", ".\\RepositoryImages\\PDS_CORERepository5a3e11ed.rximgres")
        {
            _tracklinewindow = new PDS_CORERepositoryFolders.TrackLineWindowAppFolder(this);
            _form_warningbox = new PDS_CORERepositoryFolders.Form_WarningBoxAppFolder(this);
            _networklogon = new PDS_CORERepositoryFolders.NetworkLogonAppFolder(this);
        }

#region Variables

        string _window = "Desk 05: McComb 1-CrstlSprngs";

        /// <summary>
        /// Gets or sets the value of variable window.
        /// </summary>
        [TestVariable("ff2511ac-6a46-412b-a410-b9a8b458d66d")]
        public string window
        {
            get { return _window; }
            set { _window = value; }
        }

        string _tdmsID = "1219019";

        /// <summary>
        /// Gets or sets the value of variable tdmsID.
        /// </summary>
        [TestVariable("e3289fb1-2aec-44f2-a7c1-fbc9a8513dbd")]
        public string tdmsID
        {
            get { return _tdmsID; }
            set { _tdmsID = value; }
        }

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("5a3e11ed-7012-4569-a9b8-11892349cf95")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The TrackLineWindow folder.
        /// </summary>
        [RepositoryFolder("d436e7e2-745b-4eed-b86b-22d6e6cf6873")]
        public virtual PDS_CORERepositoryFolders.TrackLineWindowAppFolder TrackLineWindow
        {
            get { return _tracklinewindow; }
        }

        /// <summary>
        /// The Form_WarningBox folder.
        /// </summary>
        [RepositoryFolder("b4281c28-a28e-4728-9183-c404b70cb760")]
        public virtual PDS_CORERepositoryFolders.Form_WarningBoxAppFolder Form_WarningBox
        {
            get { return _form_warningbox; }
        }

        /// <summary>
        /// The NetworkLogon folder.
        /// </summary>
        [RepositoryFolder("cf1ec31f-307e-4aaa-b689-24d9c42d4614")]
        public virtual PDS_CORERepositoryFolders.NetworkLogonAppFolder NetworkLogon
        {
            get { return _networklogon; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class PDS_CORERepositoryFolders
    {
        /// <summary>
        /// The TrackLineWindowAppFolder folder.
        /// </summary>
        [RepositoryFolder("d436e7e2-745b-4eed-b86b-22d6e6cf6873")]
        public partial class TrackLineWindowAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _tracksectionInfo;

            /// <summary>
            /// Creates a new TrackLineWindow  folder.
            /// </summary>
            public TrackLineWindowAppFolder(RepoGenBaseFolder parentFolder) :
                    base("TrackLineWindow", "/form[@title~$window or @class='SunAwtWindow']", parentFolder, 30000, null, false, "d436e7e2-745b-4eed-b86b-22d6e6cf6873", "")
            {
                _tracksectionInfo = new RepoItemInfo(this, "TrackSection", ".//element[@symbolid=$tdmsID]", 30000, null, "40d36ae7-31a3-4bce-b8be-1df9972b2d64");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("d436e7e2-745b-4eed-b86b-22d6e6cf6873")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("d436e7e2-745b-4eed-b86b-22d6e6cf6873")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The TrackSection item.
            /// </summary>
            [RepositoryItem("40d36ae7-31a3-4bce-b8be-1df9972b2d64")]
            public virtual Ranorex.Unknown TrackSection
            {
                get
                {
                    return _tracksectionInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The TrackSection item info.
            /// </summary>
            [RepositoryItemInfo("40d36ae7-31a3-4bce-b8be-1df9972b2d64")]
            public virtual RepoItemInfo TrackSectionInfo
            {
                get
                {
                    return _tracksectionInfo;
                }
            }
        }

        /// <summary>
        /// The Form_WarningBoxAppFolder folder.
        /// </summary>
        [RepositoryFolder("b4281c28-a28e-4728-9183-c404b70cb760")]
        public partial class Form_WarningBoxAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _titlebarInfo;
            RepoItemInfo _textlabelInfo;
            RepoItemInfo _buttonyesInfo;
            RepoItemInfo _buttonnoInfo;
            RepoItemInfo _closeInfo;

            /// <summary>
            /// Creates a new Form_WarningBox  folder.
            /// </summary>
            public Form_WarningBoxAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Form_WarningBox", "/form[@title='Warning']", parentFolder, 3000, null, false, "b4281c28-a28e-4728-9183-c404b70cb760", "")
            {
                _titlebarInfo = new RepoItemInfo(this, "titlebar", ".//titlebar[@accessiblerole='TitleBar']", 3000, null, "5a6c1c54-f6d1-4391-8e66-fed0cf296353");
                _textlabelInfo = new RepoItemInfo(this, "textLabel", ".//text[@name='OptionPane.label']", 3000, null, "11067891-3394-4f36-9a12-4a9ac13806fe");
                _buttonyesInfo = new RepoItemInfo(this, "buttonYes", ".//button[@text='Yes']", 3000, null, "b79db27e-0f61-4033-88af-78215f8b09e5");
                _buttonnoInfo = new RepoItemInfo(this, "buttonNo", ".//button[@text='No']", 3000, null, "4649f730-0df8-45ab-8a7f-c3ca8a247a63");
                _closeInfo = new RepoItemInfo(this, "Close", ".//button[@accessiblename='Close']", 3000, null, "eba1427a-edf5-432c-ade2-676f04adb8d9");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("b4281c28-a28e-4728-9183-c404b70cb760")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("b4281c28-a28e-4728-9183-c404b70cb760")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The titlebar item.
            /// </summary>
            [RepositoryItem("5a6c1c54-f6d1-4391-8e66-fed0cf296353")]
            public virtual Ranorex.TitleBar titlebar
            {
                get
                {
                    return _titlebarInfo.CreateAdapter<Ranorex.TitleBar>(true);
                }
            }

            /// <summary>
            /// The titlebar item info.
            /// </summary>
            [RepositoryItemInfo("5a6c1c54-f6d1-4391-8e66-fed0cf296353")]
            public virtual RepoItemInfo titlebarInfo
            {
                get
                {
                    return _titlebarInfo;
                }
            }

            /// <summary>
            /// The textLabel item.
            /// </summary>
            [RepositoryItem("11067891-3394-4f36-9a12-4a9ac13806fe")]
            public virtual Ranorex.Text textLabel
            {
                get
                {
                    return _textlabelInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The textLabel item info.
            /// </summary>
            [RepositoryItemInfo("11067891-3394-4f36-9a12-4a9ac13806fe")]
            public virtual RepoItemInfo textLabelInfo
            {
                get
                {
                    return _textlabelInfo;
                }
            }

            /// <summary>
            /// The buttonYes item.
            /// </summary>
            [RepositoryItem("b79db27e-0f61-4033-88af-78215f8b09e5")]
            public virtual Ranorex.Button buttonYes
            {
                get
                {
                    return _buttonyesInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonYes item info.
            /// </summary>
            [RepositoryItemInfo("b79db27e-0f61-4033-88af-78215f8b09e5")]
            public virtual RepoItemInfo buttonYesInfo
            {
                get
                {
                    return _buttonyesInfo;
                }
            }

            /// <summary>
            /// The buttonNo item.
            /// </summary>
            [RepositoryItem("4649f730-0df8-45ab-8a7f-c3ca8a247a63")]
            public virtual Ranorex.Button buttonNo
            {
                get
                {
                    return _buttonnoInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonNo item info.
            /// </summary>
            [RepositoryItemInfo("4649f730-0df8-45ab-8a7f-c3ca8a247a63")]
            public virtual RepoItemInfo buttonNoInfo
            {
                get
                {
                    return _buttonnoInfo;
                }
            }

            /// <summary>
            /// The Close item.
            /// </summary>
            [RepositoryItem("eba1427a-edf5-432c-ade2-676f04adb8d9")]
            public virtual Ranorex.Button Close
            {
                get
                {
                    return _closeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Close item info.
            /// </summary>
            [RepositoryItemInfo("eba1427a-edf5-432c-ade2-676f04adb8d9")]
            public virtual RepoItemInfo CloseInfo
            {
                get
                {
                    return _closeInfo;
                }
            }
        }

        /// <summary>
        /// The NetworkLogonAppFolder folder.
        /// </summary>
        [RepositoryFolder("cf1ec31f-307e-4aaa-b689-24d9c42d4614")]
        public partial class NetworkLogonAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _iconInfo;
            RepoItemInfo _useridInfo;
            RepoItemInfo _roleInfo;
            RepoItemInfo _passwordInfo;
            RepoItemInfo _logonInfo;
            RepoItemInfo _cancelInfo;
            RepoItemInfo _messagefieldInfo;
            RepoItemInfo _systemInfo;
            RepoItemInfo _system1Info;
            RepoItemInfo _minimizeInfo;
            RepoItemInfo _maximizeInfo;
            RepoItemInfo _closeInfo;
            RepoItemInfo _titlebarInfo;

            /// <summary>
            /// Creates a new NetworkLogon  folder.
            /// </summary>
            public NetworkLogonAppFolder(RepoGenBaseFolder parentFolder) :
                    base("NetworkLogon", "/form[@title='Network Logon']", parentFolder, 30000, null, false, "cf1ec31f-307e-4aaa-b689-24d9c42d4614", "")
            {
                _iconInfo = new RepoItemInfo(this, "Icon", "text[1]", 30000, null, "703bf3a1-5bf6-4bcd-afab-f6a6bc988b16");
                _useridInfo = new RepoItemInfo(this, "UserID", "text[@name='USER_ID']", 30000, null, "cb9c2bf4-f94e-496a-b167-5e0079d6286b");
                _roleInfo = new RepoItemInfo(this, "Role", "text[@name='USER_ROLE_ID']", 30000, null, "d9427b68-9e57-417c-9ed9-2a296406e2a4");
                _passwordInfo = new RepoItemInfo(this, "Password", "text[@name='PWD_ID']", 30000, null, "8d2bc506-fd76-440f-82b8-710715779af0");
                _logonInfo = new RepoItemInfo(this, "Logon", ".//button[@name='defaultButton']", 30000, null, "fd90a44f-322a-46b7-a24d-a5cea2917bfe");
                _cancelInfo = new RepoItemInfo(this, "Cancel", ".//button[@name='_cancel']", 30000, null, "a7dd2964-a825-4c08-8b6c-7e4159edbdec");
                _messagefieldInfo = new RepoItemInfo(this, "MessageField", ".//text[@name='messageField']", 30000, null, "04b00ce0-f4cf-402a-9c4e-b96d878badec");
                _systemInfo = new RepoItemInfo(this, "System", ".//menuitem[@accessiblename='System']", 30000, null, "6bfc00e3-06a0-4ce1-9c38-2717a89abc58");
                _system1Info = new RepoItemInfo(this, "System1", "menubar[@accessiblename='System']", 30000, null, "cec03c0b-521e-4b0b-a05e-391f9ce8a222");
                _minimizeInfo = new RepoItemInfo(this, "Minimize", "?/?/button[@accessiblename='Minimize']", 30000, null, "1709ce33-1367-46a1-8460-f0b962604be6");
                _maximizeInfo = new RepoItemInfo(this, "Maximize", "?/?/button[@accessiblename='Maximize']", 30000, null, "4267ae44-4305-40a3-b317-59d56cd2e922");
                _closeInfo = new RepoItemInfo(this, "Close", "?/?/button[@accessiblename='Close']", 30000, null, "20ef3e76-6d97-4e9c-91f2-f5d8ca2b6e39");
                _titlebarInfo = new RepoItemInfo(this, "Titlebar", "titlebar[@accessiblerole='TitleBar']", 30000, null, "651dfbab-8cf9-43cf-a65e-264462c9895e");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("cf1ec31f-307e-4aaa-b689-24d9c42d4614")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("cf1ec31f-307e-4aaa-b689-24d9c42d4614")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Icon item.
            /// </summary>
            [RepositoryItem("703bf3a1-5bf6-4bcd-afab-f6a6bc988b16")]
            public virtual Ranorex.Text Icon
            {
                get
                {
                    return _iconInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Icon item info.
            /// </summary>
            [RepositoryItemInfo("703bf3a1-5bf6-4bcd-afab-f6a6bc988b16")]
            public virtual RepoItemInfo IconInfo
            {
                get
                {
                    return _iconInfo;
                }
            }

            /// <summary>
            /// The UserID item.
            /// </summary>
            [RepositoryItem("cb9c2bf4-f94e-496a-b167-5e0079d6286b")]
            public virtual Ranorex.Text UserID
            {
                get
                {
                    return _useridInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The UserID item info.
            /// </summary>
            [RepositoryItemInfo("cb9c2bf4-f94e-496a-b167-5e0079d6286b")]
            public virtual RepoItemInfo UserIDInfo
            {
                get
                {
                    return _useridInfo;
                }
            }

            /// <summary>
            /// The Role item.
            /// </summary>
            [RepositoryItem("d9427b68-9e57-417c-9ed9-2a296406e2a4")]
            public virtual Ranorex.Text Role
            {
                get
                {
                    return _roleInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Role item info.
            /// </summary>
            [RepositoryItemInfo("d9427b68-9e57-417c-9ed9-2a296406e2a4")]
            public virtual RepoItemInfo RoleInfo
            {
                get
                {
                    return _roleInfo;
                }
            }

            /// <summary>
            /// The Password item.
            /// </summary>
            [RepositoryItem("8d2bc506-fd76-440f-82b8-710715779af0")]
            public virtual Ranorex.Text Password
            {
                get
                {
                    return _passwordInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Password item info.
            /// </summary>
            [RepositoryItemInfo("8d2bc506-fd76-440f-82b8-710715779af0")]
            public virtual RepoItemInfo PasswordInfo
            {
                get
                {
                    return _passwordInfo;
                }
            }

            /// <summary>
            /// The Logon item.
            /// </summary>
            [RepositoryItem("fd90a44f-322a-46b7-a24d-a5cea2917bfe")]
            public virtual Ranorex.Button Logon
            {
                get
                {
                    return _logonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Logon item info.
            /// </summary>
            [RepositoryItemInfo("fd90a44f-322a-46b7-a24d-a5cea2917bfe")]
            public virtual RepoItemInfo LogonInfo
            {
                get
                {
                    return _logonInfo;
                }
            }

            /// <summary>
            /// The Cancel item.
            /// </summary>
            [RepositoryItem("a7dd2964-a825-4c08-8b6c-7e4159edbdec")]
            public virtual Ranorex.Button Cancel
            {
                get
                {
                    return _cancelInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Cancel item info.
            /// </summary>
            [RepositoryItemInfo("a7dd2964-a825-4c08-8b6c-7e4159edbdec")]
            public virtual RepoItemInfo CancelInfo
            {
                get
                {
                    return _cancelInfo;
                }
            }

            /// <summary>
            /// The MessageField item.
            /// </summary>
            [RepositoryItem("04b00ce0-f4cf-402a-9c4e-b96d878badec")]
            public virtual Ranorex.Text MessageField
            {
                get
                {
                    return _messagefieldInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The MessageField item info.
            /// </summary>
            [RepositoryItemInfo("04b00ce0-f4cf-402a-9c4e-b96d878badec")]
            public virtual RepoItemInfo MessageFieldInfo
            {
                get
                {
                    return _messagefieldInfo;
                }
            }

            /// <summary>
            /// The System item.
            /// </summary>
            [RepositoryItem("6bfc00e3-06a0-4ce1-9c38-2717a89abc58")]
            public virtual Ranorex.MenuItem System
            {
                get
                {
                    return _systemInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The System item info.
            /// </summary>
            [RepositoryItemInfo("6bfc00e3-06a0-4ce1-9c38-2717a89abc58")]
            public virtual RepoItemInfo SystemInfo
            {
                get
                {
                    return _systemInfo;
                }
            }

            /// <summary>
            /// The System1 item.
            /// </summary>
            [RepositoryItem("cec03c0b-521e-4b0b-a05e-391f9ce8a222")]
            public virtual Ranorex.MenuBar System1
            {
                get
                {
                    return _system1Info.CreateAdapter<Ranorex.MenuBar>(true);
                }
            }

            /// <summary>
            /// The System1 item info.
            /// </summary>
            [RepositoryItemInfo("cec03c0b-521e-4b0b-a05e-391f9ce8a222")]
            public virtual RepoItemInfo System1Info
            {
                get
                {
                    return _system1Info;
                }
            }

            /// <summary>
            /// The Minimize item.
            /// </summary>
            [RepositoryItem("1709ce33-1367-46a1-8460-f0b962604be6")]
            public virtual Ranorex.Button Minimize
            {
                get
                {
                    return _minimizeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Minimize item info.
            /// </summary>
            [RepositoryItemInfo("1709ce33-1367-46a1-8460-f0b962604be6")]
            public virtual RepoItemInfo MinimizeInfo
            {
                get
                {
                    return _minimizeInfo;
                }
            }

            /// <summary>
            /// The Maximize item.
            /// </summary>
            [RepositoryItem("4267ae44-4305-40a3-b317-59d56cd2e922")]
            public virtual Ranorex.Button Maximize
            {
                get
                {
                    return _maximizeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Maximize item info.
            /// </summary>
            [RepositoryItemInfo("4267ae44-4305-40a3-b317-59d56cd2e922")]
            public virtual RepoItemInfo MaximizeInfo
            {
                get
                {
                    return _maximizeInfo;
                }
            }

            /// <summary>
            /// The Close item.
            /// </summary>
            [RepositoryItem("20ef3e76-6d97-4e9c-91f2-f5d8ca2b6e39")]
            public virtual Ranorex.Button Close
            {
                get
                {
                    return _closeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Close item info.
            /// </summary>
            [RepositoryItemInfo("20ef3e76-6d97-4e9c-91f2-f5d8ca2b6e39")]
            public virtual RepoItemInfo CloseInfo
            {
                get
                {
                    return _closeInfo;
                }
            }

            /// <summary>
            /// The Titlebar item.
            /// </summary>
            [RepositoryItem("651dfbab-8cf9-43cf-a65e-264462c9895e")]
            public virtual Ranorex.TitleBar Titlebar
            {
                get
                {
                    return _titlebarInfo.CreateAdapter<Ranorex.TitleBar>(true);
                }
            }

            /// <summary>
            /// The Titlebar item info.
            /// </summary>
            [RepositoryItemInfo("651dfbab-8cf9-43cf-a65e-264462c9895e")]
            public virtual RepoItemInfo TitlebarInfo
            {
                get
                {
                    return _titlebarInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}