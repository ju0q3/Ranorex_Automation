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

namespace PTC_Lab_Automation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Test_ExecutionRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("dab857d6-db00-487f-8fdd-61a5ad3edc4e")]
    public partial class Test_ExecutionRepository : RepoGenBaseFolder
    {
        static Test_ExecutionRepository instance = new Test_ExecutionRepository();

        /// <summary>
        /// Gets the singleton class instance representing the Test_ExecutionRepository element repository.
        /// </summary>
        [RepositoryFolder("dab857d6-db00-487f-8fdd-61a5ad3edc4e")]
        public static Test_ExecutionRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Test_ExecutionRepository() 
            : base("Test_ExecutionRepository", "/", null, 0, false, "dab857d6-db00-487f-8fdd-61a5ad3edc4e", ".\\RepositoryImages\\Test_ExecutionRepositorydab857d6.rximgres")
        {
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("dab857d6-db00-487f-8fdd-61a5ad3edc4e")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class Test_ExecutionRepositoryFolders
    {
    }
#pragma warning restore 0436
}