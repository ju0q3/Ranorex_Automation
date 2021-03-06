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

namespace PDS_NS.Recording_Modules.MIS
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CreateTrainDelayMISFull_NS recording.
    /// </summary>
    [TestModule("ea4d9b0b-794c-4373-a0ed-9f74d2e6da16", ModuleType.Recording, 1)]
    public partial class CreateTrainDelayMISFull_NS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static CreateTrainDelayMISFull_NS instance = new CreateTrainDelayMISFull_NS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateTrainDelayMISFull_NS()
        {
            headerProtocolId = "";
            headerMsgId = "";
            headerTraceId = "";
            headerMessageVersion = "";
            scacTrainSeed = "";
            sectionTrainSeed = "";
            trainSymbolTrainSeed = "";
            originDateTrainSeed = "";
            fromDivisionNumber = "";
            fromDivision = "";
            fromDistrict = "";
            fromLocationType = "";
            fromLocation = "";
            endDivisionNumber = "";
            endDivision = "";
            endDistrict = "";
            endLocationType = "";
            endLocation = "";
            delayRecordId = "";
            delayCode = "";
            transmissionType = "";
            userId = "";
            sourceSystem = "";
            beginDelayDateOffsetDays = "";
            beginDelayTimeOffsetMinutes = "";
            beginDelayTimeZone = "";
            endDelayDateOffsetDays = "";
            endDelayTimeOffsetMinutes = "";
            endDelayTimeZone = "";
            delayDurationOffsetMinutes = "";
            crewIdCrewSeed = "";
            crewLineSegmentCrewSeed = "";
            freeFormText = "";
            field1 = "";
            field2 = "";
            field3 = "";
            field4 = "";
            field5 = "";
            field6 = "";
            field7 = "";
            field8 = "";
            hostname = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateTrainDelayMISFull_NS Instance
        {
            get { return instance; }
        }

#region Variables

        string _headerProtocolId;

        /// <summary>
        /// Gets or sets the value of variable headerProtocolId.
        /// </summary>
        [TestVariable("946e31db-9183-49f4-ab9f-9615fef75d15")]
        public string headerProtocolId
        {
            get { return _headerProtocolId; }
            set { _headerProtocolId = value; }
        }

        string _headerMsgId;

        /// <summary>
        /// Gets or sets the value of variable headerMsgId.
        /// </summary>
        [TestVariable("ae3952e8-a1b3-42b5-bf67-68ab128c981a")]
        public string headerMsgId
        {
            get { return _headerMsgId; }
            set { _headerMsgId = value; }
        }

        string _headerTraceId;

        /// <summary>
        /// Gets or sets the value of variable headerTraceId.
        /// </summary>
        [TestVariable("9627fd90-43c7-49ff-ad16-99426e3600ca")]
        public string headerTraceId
        {
            get { return _headerTraceId; }
            set { _headerTraceId = value; }
        }

        string _headerMessageVersion;

        /// <summary>
        /// Gets or sets the value of variable headerMessageVersion.
        /// </summary>
        [TestVariable("91f2623e-3d38-4fe0-b5bd-9901b72a6106")]
        public string headerMessageVersion
        {
            get { return _headerMessageVersion; }
            set { _headerMessageVersion = value; }
        }

        string _scacTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable scacTrainSeed.
        /// </summary>
        [TestVariable("42546d37-104c-4886-ad32-b70a19e6bd37")]
        public string scacTrainSeed
        {
            get { return _scacTrainSeed; }
            set { _scacTrainSeed = value; }
        }

        string _sectionTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable sectionTrainSeed.
        /// </summary>
        [TestVariable("d2cd34ea-9017-4ee5-851c-e6b753725552")]
        public string sectionTrainSeed
        {
            get { return _sectionTrainSeed; }
            set { _sectionTrainSeed = value; }
        }

        string _trainSymbolTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable trainSymbolTrainSeed.
        /// </summary>
        [TestVariable("7efe2f72-5d30-458b-8b43-847f51db531d")]
        public string trainSymbolTrainSeed
        {
            get { return _trainSymbolTrainSeed; }
            set { _trainSymbolTrainSeed = value; }
        }

        string _originDateTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable originDateTrainSeed.
        /// </summary>
        [TestVariable("93748e57-2fef-4844-942f-7f096438877c")]
        public string originDateTrainSeed
        {
            get { return _originDateTrainSeed; }
            set { _originDateTrainSeed = value; }
        }

        string _fromDivisionNumber;

        /// <summary>
        /// Gets or sets the value of variable fromDivisionNumber.
        /// </summary>
        [TestVariable("d9f77fc9-5d80-46ba-9647-af8a144f6a24")]
        public string fromDivisionNumber
        {
            get { return _fromDivisionNumber; }
            set { _fromDivisionNumber = value; }
        }

        string _fromDivision;

        /// <summary>
        /// Gets or sets the value of variable fromDivision.
        /// </summary>
        [TestVariable("5af0e382-4809-4957-9bfd-c858eabecfb4")]
        public string fromDivision
        {
            get { return _fromDivision; }
            set { _fromDivision = value; }
        }

        string _fromDistrict;

        /// <summary>
        /// Gets or sets the value of variable fromDistrict.
        /// </summary>
        [TestVariable("57d91d16-cfdc-430a-8747-92e3b16b85fa")]
        public string fromDistrict
        {
            get { return _fromDistrict; }
            set { _fromDistrict = value; }
        }

        string _fromLocationType;

        /// <summary>
        /// Gets or sets the value of variable fromLocationType.
        /// </summary>
        [TestVariable("255ddef7-9b0d-42b6-8bc8-a20899809068")]
        public string fromLocationType
        {
            get { return _fromLocationType; }
            set { _fromLocationType = value; }
        }

        string _fromLocation;

        /// <summary>
        /// Gets or sets the value of variable fromLocation.
        /// </summary>
        [TestVariable("583d7b13-eca4-40d7-9011-e5cd115cf627")]
        public string fromLocation
        {
            get { return _fromLocation; }
            set { _fromLocation = value; }
        }

        string _endDivisionNumber;

        /// <summary>
        /// Gets or sets the value of variable endDivisionNumber.
        /// </summary>
        [TestVariable("ae2ba5a1-7035-4877-95f5-063a79f4eea9")]
        public string endDivisionNumber
        {
            get { return _endDivisionNumber; }
            set { _endDivisionNumber = value; }
        }

        string _endDivision;

        /// <summary>
        /// Gets or sets the value of variable endDivision.
        /// </summary>
        [TestVariable("cf13b3b2-77f3-4d56-a82f-08ff95cd5a70")]
        public string endDivision
        {
            get { return _endDivision; }
            set { _endDivision = value; }
        }

        string _endDistrict;

        /// <summary>
        /// Gets or sets the value of variable endDistrict.
        /// </summary>
        [TestVariable("e2686982-095e-4bba-89d4-c9193653422b")]
        public string endDistrict
        {
            get { return _endDistrict; }
            set { _endDistrict = value; }
        }

        string _endLocationType;

        /// <summary>
        /// Gets or sets the value of variable endLocationType.
        /// </summary>
        [TestVariable("36aa74bb-37fc-4b6a-a503-4c651d98a81e")]
        public string endLocationType
        {
            get { return _endLocationType; }
            set { _endLocationType = value; }
        }

        string _endLocation;

        /// <summary>
        /// Gets or sets the value of variable endLocation.
        /// </summary>
        [TestVariable("2b820423-35d6-41a9-9a98-85d49f3a3cd8")]
        public string endLocation
        {
            get { return _endLocation; }
            set { _endLocation = value; }
        }

        string _delayRecordId;

        /// <summary>
        /// Gets or sets the value of variable delayRecordId.
        /// </summary>
        [TestVariable("aec9e982-1beb-4d58-8452-0f6cf4a1814b")]
        public string delayRecordId
        {
            get { return _delayRecordId; }
            set { _delayRecordId = value; }
        }

        string _delayCode;

        /// <summary>
        /// Gets or sets the value of variable delayCode.
        /// </summary>
        [TestVariable("80423477-800f-487a-bc9e-a4d60286c4a7")]
        public string delayCode
        {
            get { return _delayCode; }
            set { _delayCode = value; }
        }

        string _transmissionType;

        /// <summary>
        /// Gets or sets the value of variable transmissionType.
        /// </summary>
        [TestVariable("d4321615-9849-4279-a384-bc286dedc7c1")]
        public string transmissionType
        {
            get { return _transmissionType; }
            set { _transmissionType = value; }
        }

        string _userId;

        /// <summary>
        /// Gets or sets the value of variable userId.
        /// </summary>
        [TestVariable("555789e3-ef07-40ee-acc0-f887561781e5")]
        public string userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        string _sourceSystem;

        /// <summary>
        /// Gets or sets the value of variable sourceSystem.
        /// </summary>
        [TestVariable("3e3eb7de-afd3-4f5a-97b8-66dc3071b64f")]
        public string sourceSystem
        {
            get { return _sourceSystem; }
            set { _sourceSystem = value; }
        }

        string _beginDelayDateOffsetDays;

        /// <summary>
        /// Gets or sets the value of variable beginDelayDateOffsetDays.
        /// </summary>
        [TestVariable("c7fa6c4d-a123-42e2-aeec-17feec4de22e")]
        public string beginDelayDateOffsetDays
        {
            get { return _beginDelayDateOffsetDays; }
            set { _beginDelayDateOffsetDays = value; }
        }

        string _beginDelayTimeOffsetMinutes;

        /// <summary>
        /// Gets or sets the value of variable beginDelayTimeOffsetMinutes.
        /// </summary>
        [TestVariable("1f02123a-2237-4945-a4b1-f472ddb41b8b")]
        public string beginDelayTimeOffsetMinutes
        {
            get { return _beginDelayTimeOffsetMinutes; }
            set { _beginDelayTimeOffsetMinutes = value; }
        }

        string _beginDelayTimeZone;

        /// <summary>
        /// Gets or sets the value of variable beginDelayTimeZone.
        /// </summary>
        [TestVariable("7c0cac3e-2a9b-49b5-aa17-bebc5dbbe6a0")]
        public string beginDelayTimeZone
        {
            get { return _beginDelayTimeZone; }
            set { _beginDelayTimeZone = value; }
        }

        string _endDelayDateOffsetDays;

        /// <summary>
        /// Gets or sets the value of variable endDelayDateOffsetDays.
        /// </summary>
        [TestVariable("bc120129-018d-4e22-ba64-cb8afa559601")]
        public string endDelayDateOffsetDays
        {
            get { return _endDelayDateOffsetDays; }
            set { _endDelayDateOffsetDays = value; }
        }

        string _endDelayTimeOffsetMinutes;

        /// <summary>
        /// Gets or sets the value of variable endDelayTimeOffsetMinutes.
        /// </summary>
        [TestVariable("fd73c6dc-9514-43cb-9486-cf7c55bd5a6a")]
        public string endDelayTimeOffsetMinutes
        {
            get { return _endDelayTimeOffsetMinutes; }
            set { _endDelayTimeOffsetMinutes = value; }
        }

        string _endDelayTimeZone;

        /// <summary>
        /// Gets or sets the value of variable endDelayTimeZone.
        /// </summary>
        [TestVariable("f4f9c1b8-2e30-4b2c-b9d2-30f51802de48")]
        public string endDelayTimeZone
        {
            get { return _endDelayTimeZone; }
            set { _endDelayTimeZone = value; }
        }

        string _delayDurationOffsetMinutes;

        /// <summary>
        /// Gets or sets the value of variable delayDurationOffsetMinutes.
        /// </summary>
        [TestVariable("a37cefdb-c091-420f-9621-fbaa7cf28df9")]
        public string delayDurationOffsetMinutes
        {
            get { return _delayDurationOffsetMinutes; }
            set { _delayDurationOffsetMinutes = value; }
        }

        string _crewIdCrewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewIdCrewSeed.
        /// </summary>
        [TestVariable("7dbf8134-9303-4028-84db-7405ba35260a")]
        public string crewIdCrewSeed
        {
            get { return _crewIdCrewSeed; }
            set { _crewIdCrewSeed = value; }
        }

        string _crewLineSegmentCrewSeed;

        /// <summary>
        /// Gets or sets the value of variable crewLineSegmentCrewSeed.
        /// </summary>
        [TestVariable("9e41a58f-ba4b-42dc-a2b9-4a452775aeab")]
        public string crewLineSegmentCrewSeed
        {
            get { return _crewLineSegmentCrewSeed; }
            set { _crewLineSegmentCrewSeed = value; }
        }

        string _freeFormText;

        /// <summary>
        /// Gets or sets the value of variable freeFormText.
        /// </summary>
        [TestVariable("560880e5-72ac-44ad-aa68-3237ee4648f0")]
        public string freeFormText
        {
            get { return _freeFormText; }
            set { _freeFormText = value; }
        }

        string _field1;

        /// <summary>
        /// Gets or sets the value of variable field1.
        /// </summary>
        [TestVariable("28842ae8-5692-414e-8dd1-0fb8b8947ef5")]
        public string field1
        {
            get { return _field1; }
            set { _field1 = value; }
        }

        string _field2;

        /// <summary>
        /// Gets or sets the value of variable field2.
        /// </summary>
        [TestVariable("e7bde2c5-1106-49cf-984a-b20c90e6cc74")]
        public string field2
        {
            get { return _field2; }
            set { _field2 = value; }
        }

        string _field3;

        /// <summary>
        /// Gets or sets the value of variable field3.
        /// </summary>
        [TestVariable("caf82e7b-d00c-42a2-b8c4-53565ccb84a0")]
        public string field3
        {
            get { return _field3; }
            set { _field3 = value; }
        }

        string _field4;

        /// <summary>
        /// Gets or sets the value of variable field4.
        /// </summary>
        [TestVariable("7c9cfa7f-c79a-411e-a90a-f1eedeefbdaa")]
        public string field4
        {
            get { return _field4; }
            set { _field4 = value; }
        }

        string _field5;

        /// <summary>
        /// Gets or sets the value of variable field5.
        /// </summary>
        [TestVariable("cc82c6d5-8db7-42bb-917a-8771312e621b")]
        public string field5
        {
            get { return _field5; }
            set { _field5 = value; }
        }

        string _field6;

        /// <summary>
        /// Gets or sets the value of variable field6.
        /// </summary>
        [TestVariable("073ee448-0456-4a4e-9d60-7b8455065c33")]
        public string field6
        {
            get { return _field6; }
            set { _field6 = value; }
        }

        string _field7;

        /// <summary>
        /// Gets or sets the value of variable field7.
        /// </summary>
        [TestVariable("ff7f36ab-e39d-4a9d-8101-a6f32a94c582")]
        public string field7
        {
            get { return _field7; }
            set { _field7 = value; }
        }

        string _field8;

        /// <summary>
        /// Gets or sets the value of variable field8.
        /// </summary>
        [TestVariable("88fa1136-bc3b-4115-954f-d27f34e94e19")]
        public string field8
        {
            get { return _field8; }
            set { _field8 = value; }
        }

        string _hostname;

        /// <summary>
        /// Gets or sets the value of variable hostname.
        /// </summary>
        [TestVariable("581f2871-df6c-4e71-8037-b0a2845cf16a")]
        public string hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
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

            UserCodeCollections.NS_MIS_Messages.NS_SendTrainDelay_48(headerProtocolId, headerMsgId, headerTraceId, headerMessageVersion, scacTrainSeed, sectionTrainSeed, trainSymbolTrainSeed, originDateTrainSeed, fromDivisionNumber, fromDivision, fromDistrict, fromLocationType, fromLocation, endDivisionNumber, endDivision, endDistrict, endLocationType, endLocation, delayRecordId, delayCode, transmissionType, userId, sourceSystem, beginDelayDateOffsetDays, beginDelayTimeOffsetMinutes, beginDelayTimeZone, endDelayDateOffsetDays, endDelayTimeOffsetMinutes, endDelayTimeZone, delayDurationOffsetMinutes, crewIdCrewSeed, crewLineSegmentCrewSeed, freeFormText, field1, field2, field3, field4, field5, field6, field7, field8, hostname);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
