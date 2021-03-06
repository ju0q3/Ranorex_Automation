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
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace PDS_NS.Recording_Modules.Trainsheet_Validations
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ValidateMovesInInteractiveHistory_Trainsheet recording.
    /// </summary>
    [TestModule("0e387b3c-b782-43ed-8b2d-8127338ad8b5", ModuleType.Recording, 1)]
    public partial class ValidateMovesInInteractiveHistory_Trainsheet : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static ValidateMovesInInteractiveHistory_Trainsheet instance = new ValidateMovesInInteractiveHistory_Trainsheet();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateMovesInInteractiveHistory_Trainsheet()
        {
            trainSeed = "";
            movedOpsta = "";
            station = "";
            milePost = "";
            reportType = "";
            direction = "";
            distance = "";
            speed = "";
            source = "";
            pseudoTrain = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ValidateMovesInInteractiveHistory_Trainsheet Instance
        {
            get { return instance; }
        }

#region Variables

        string _trainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSeed.
        /// </summary>
        [TestVariable("b170a793-ea56-4660-bde1-2f7cb1fcbdbf")]
        public string trainSeed
        {
            get { return _trainSeed; }
            set { _trainSeed = value; }
        }

        string _movedOpsta;

        /// <summary>
        /// Gets or sets the value of variable movedOpsta.
        /// </summary>
        [TestVariable("1fffcad4-c1a3-40a3-9867-ccf1d2aa260e")]
        public string movedOpsta
        {
            get { return _movedOpsta; }
            set { _movedOpsta = value; }
        }

        string _station;

        /// <summary>
        /// Gets or sets the value of variable station.
        /// </summary>
        [TestVariable("47299015-8a06-40be-936c-d832103de93a")]
        public string station
        {
            get { return _station; }
            set { _station = value; }
        }

        string _milePost;

        /// <summary>
        /// Gets or sets the value of variable milePost.
        /// </summary>
        [TestVariable("354312f7-8d4b-4ab1-bebf-49693ab5b94a")]
        public string milePost
        {
            get { return _milePost; }
            set { _milePost = value; }
        }

        string _reportType;

        /// <summary>
        /// Gets or sets the value of variable reportType.
        /// </summary>
        [TestVariable("c4fd5dc2-4b70-4878-b622-5d6b2d7525e7")]
        public string reportType
        {
            get { return _reportType; }
            set { _reportType = value; }
        }

        string _direction;

        /// <summary>
        /// Gets or sets the value of variable direction.
        /// </summary>
        [TestVariable("1935fe13-a882-4441-8ac8-d6e1a4e5ef12")]
        public string direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        string _distance;

        /// <summary>
        /// Gets or sets the value of variable distance.
        /// </summary>
        [TestVariable("0bbdc89e-78dd-4c4b-bfec-a2f735d5d925")]
        public string distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        string _speed;

        /// <summary>
        /// Gets or sets the value of variable speed.
        /// </summary>
        [TestVariable("2ac6e0b5-d033-47e6-b78e-e74b28350f30")]
        public string speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        string _source;

        /// <summary>
        /// Gets or sets the value of variable source.
        /// </summary>
        [TestVariable("09f88652-4225-42cc-8621-47490052e246")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        string _pseudoTrain;

        /// <summary>
        /// Gets or sets the value of variable pseudoTrain.
        /// </summary>
        [TestVariable("33dfc5f7-d051-44d4-b6e7-1dd5cd6600ad")]
        public string pseudoTrain
        {
            get { return _pseudoTrain; }
            set { _pseudoTrain = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("66d73f59-5c04-4b39-be5d-d115126aa432")]
        public string closeForm
        {
            get { return _closeForm; }
            set { _closeForm = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            UserCodeCollections.NS_Trainsheet.NS_ValidateMovesInInteractiveHistory_Trainsheet(trainSeed, movedOpsta, station, milePost, reportType, direction, distance, speed, source, pseudoTrain, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
