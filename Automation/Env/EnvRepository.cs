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

namespace Env
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the EnvRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("1486a1a1-03e0-4ac7-b844-f147e94c990c")]
    public partial class EnvRepository : RepoGenBaseFolder
    {
        static EnvRepository instance = new EnvRepository();

        /// <summary>
        /// Gets the singleton class instance representing the EnvRepository element repository.
        /// </summary>
        [RepositoryFolder("1486a1a1-03e0-4ac7-b844-f147e94c990c")]
        public static EnvRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public EnvRepository() 
            : base("EnvRepository", "/", null, 0, false, "1486a1a1-03e0-4ac7-b844-f147e94c990c", ".\\RepositoryImages\\EnvRepository1486a1a1.rximgres")
        {
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("1486a1a1-03e0-4ac7-b844-f147e94c990c")]
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
    public partial class EnvRepositoryFolders
    {
    }
#pragma warning restore 0436
}
