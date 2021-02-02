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

namespace PDS_NS.Recording_Modules.Track_Authorities
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The NS_ValidateAuthorityDetails recording.
    /// </summary>
    [TestModule("ba37cbe1-33f4-4c7b-9ac0-eaf115a36941", ModuleType.Recording, 1)]
    public partial class NS_ValidateAuthorityDetails : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static NS_ValidateAuthorityDetails instance = new NS_ValidateAuthorityDetails();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public NS_ValidateAuthorityDetails()
        {
            AuthoritySeed = "RW1_2";
            authorityType = "R/W";
            To = "RW1_2";
            At = "Edgewood";
            CopiedBy = "RW1_2";
            RelayingEmployee = "Automater";
            RelayingAt = "Edgewood";
            ExtendUntil = "";
            ExtendBy = "";
            ExtendOSLocation = "";
            ExtendFSW = "False";
            ExtendRecordedTime = "";
            AuthorityToVoid = "";
            Proceed1Between = "";
            Proceed1To1 = "";
            Proceed1Track1 = "";
            Proceed1To2 = "";
            Proceed1Track2 = "";
            Proceed1To3 = "";
            Proceed1Track3 = "";
            WorkBetweenBetween = "Edgewood";
            WorkBetweenAnd = "Smarr";
            WorkBetweenTrack1 = "MAIN";
            WorkBetweenTrack2 = "";
            WorkBetweenTrack3 = "";
            WorkBetweenTrack4 = "";
            WorkBetweenTrack5 = "";
            EffectiveUntil = "09:00 AM";
            StopShortPoint = "";
            StopShortTrack = "";
            box12RWIC1 = "RW1_1";
            box12Between1 = "Edgewood";
            box12And1 = "Smarr";
            box12Track1 = "MAIN";
            box12RWIC2 = "";
            box12Between2 = "";
            box12And2 = "";
            box12Track2 = "";
            box12RWIC3 = "";
            box12Between3 = "";
            box12And3 = "";
            box12Track3 = "";
            OtherInstructionsSystem = "";
            OtherInstructionsUser = "";
            Box1 = "False";
            Box2 = "False";
            Box3 = "False";
            Box4 = "False";
            Box5 = "False";
            Box6 = "False";
            Box7 = "False";
            Box8 = "False";
            Box9 = "False";
            Box10 = "False";
            Box11 = "False";
            Box12 = "False";
            Box13 = "False";
            Box4Proceed2Between = "";
            Box4Proceed2To1 = "";
            Box4Proceed2Track1 = "";
            Box4Proceed2To2 = "";
            Box4Proceed2Track2 = "";
            Box4Proceed2To3 = "";
            Box4Proceed2Track3 = "";
            TrainsToFollowTrainText = "";
            TrainsToFollowTrain1Text = "";
            TrainsToFollowTrain2Text = "";
            TrainsSpeedRestrictionBetweenText = "";
            TrainsSpeedRestrictionAndText = "";
            OpposingTrainField1Text = "";
            OpposingTrainField2Text = "";
            OpposingTrainField3Text = "";
            OpposingTrainsLocationText = "";
            closeForm = "False";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static NS_ValidateAuthorityDetails Instance
        {
            get { return instance; }
        }

#region Variables

        string _AuthoritySeed;

        /// <summary>
        /// Gets or sets the value of variable AuthoritySeed.
        /// </summary>
        [TestVariable("353450c0-2e97-4332-a7ac-bb59d1c8d2f1")]
        public string AuthoritySeed
        {
            get { return _AuthoritySeed; }
            set { _AuthoritySeed = value; }
        }

        string _authorityType;

        /// <summary>
        /// Gets or sets the value of variable authorityType.
        /// </summary>
        [TestVariable("130bfcf4-5d1f-4a91-a8b1-86bf9643bfa8")]
        public string authorityType
        {
            get { return _authorityType; }
            set { _authorityType = value; }
        }

        string _To;

        /// <summary>
        /// Gets or sets the value of variable To.
        /// </summary>
        [TestVariable("e6746a65-d92c-41ae-a46a-04a077eff36f")]
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }

        string _At;

        /// <summary>
        /// Gets or sets the value of variable At.
        /// </summary>
        [TestVariable("83504e0a-7c1a-4f41-8b78-9d45a0d19abf")]
        public string At
        {
            get { return _At; }
            set { _At = value; }
        }

        string _CopiedBy;

        /// <summary>
        /// Gets or sets the value of variable CopiedBy.
        /// </summary>
        [TestVariable("386a87ee-cbaf-4bcc-83b4-aa16a1ddb18a")]
        public string CopiedBy
        {
            get { return _CopiedBy; }
            set { _CopiedBy = value; }
        }

        string _RelayingEmployee;

        /// <summary>
        /// Gets or sets the value of variable RelayingEmployee.
        /// </summary>
        [TestVariable("37df2d06-e892-45ef-833d-472d0430d910")]
        public string RelayingEmployee
        {
            get { return _RelayingEmployee; }
            set { _RelayingEmployee = value; }
        }

        string _RelayingAt;

        /// <summary>
        /// Gets or sets the value of variable RelayingAt.
        /// </summary>
        [TestVariable("62054e8e-bd92-44de-a0c8-22a7560a65bc")]
        public string RelayingAt
        {
            get { return _RelayingAt; }
            set { _RelayingAt = value; }
        }

        string _ExtendUntil;

        /// <summary>
        /// Gets or sets the value of variable ExtendUntil.
        /// </summary>
        [TestVariable("8e4bf09d-b4fc-4439-8e84-8b6c25c818ea")]
        public string ExtendUntil
        {
            get { return _ExtendUntil; }
            set { _ExtendUntil = value; }
        }

        string _ExtendBy;

        /// <summary>
        /// Gets or sets the value of variable ExtendBy.
        /// </summary>
        [TestVariable("23f0d7c7-67a1-4c6b-bb8d-7d10495c6b4b")]
        public string ExtendBy
        {
            get { return _ExtendBy; }
            set { _ExtendBy = value; }
        }

        string _ExtendOSLocation;

        /// <summary>
        /// Gets or sets the value of variable ExtendOSLocation.
        /// </summary>
        [TestVariable("9b9cafec-2da5-4e93-a656-a55ceadd840d")]
        public string ExtendOSLocation
        {
            get { return _ExtendOSLocation; }
            set { _ExtendOSLocation = value; }
        }

        string _ExtendFSW;

        /// <summary>
        /// Gets or sets the value of variable ExtendFSW.
        /// </summary>
        [TestVariable("9110a6d2-41fd-43d5-99d3-f79b203ea4ca")]
        public string ExtendFSW
        {
            get { return _ExtendFSW; }
            set { _ExtendFSW = value; }
        }

        string _ExtendRecordedTime;

        /// <summary>
        /// Gets or sets the value of variable ExtendRecordedTime.
        /// </summary>
        [TestVariable("5c05c905-2553-4ba4-a8c5-71f54cb3cbfd")]
        public string ExtendRecordedTime
        {
            get { return _ExtendRecordedTime; }
            set { _ExtendRecordedTime = value; }
        }

        string _AuthorityToVoid;

        /// <summary>
        /// Gets or sets the value of variable AuthorityToVoid.
        /// </summary>
        [TestVariable("07d9c009-9a92-4675-b292-f3dca7d51cd7")]
        public string AuthorityToVoid
        {
            get { return _AuthorityToVoid; }
            set { _AuthorityToVoid = value; }
        }

        string _Proceed1Between;

        /// <summary>
        /// Gets or sets the value of variable Proceed1Between.
        /// </summary>
        [TestVariable("12ad97e3-24cf-4242-991f-55a5769fecf9")]
        public string Proceed1Between
        {
            get { return _Proceed1Between; }
            set { _Proceed1Between = value; }
        }

        string _Proceed1To1;

        /// <summary>
        /// Gets or sets the value of variable Proceed1To1.
        /// </summary>
        [TestVariable("e6579054-18e8-46ef-908f-faad366e3f2e")]
        public string Proceed1To1
        {
            get { return _Proceed1To1; }
            set { _Proceed1To1 = value; }
        }

        string _Proceed1Track1;

        /// <summary>
        /// Gets or sets the value of variable Proceed1Track1.
        /// </summary>
        [TestVariable("a7d58593-9f1a-4462-8723-a5cab84c03be")]
        public string Proceed1Track1
        {
            get { return _Proceed1Track1; }
            set { _Proceed1Track1 = value; }
        }

        string _Proceed1To2;

        /// <summary>
        /// Gets or sets the value of variable Proceed1To2.
        /// </summary>
        [TestVariable("c78f3550-19de-4000-b4b2-35604d90c6db")]
        public string Proceed1To2
        {
            get { return _Proceed1To2; }
            set { _Proceed1To2 = value; }
        }

        string _Proceed1Track2;

        /// <summary>
        /// Gets or sets the value of variable Proceed1Track2.
        /// </summary>
        [TestVariable("646a9899-9d29-42d0-ace6-3d05d21b1b21")]
        public string Proceed1Track2
        {
            get { return _Proceed1Track2; }
            set { _Proceed1Track2 = value; }
        }

        string _Proceed1To3;

        /// <summary>
        /// Gets or sets the value of variable Proceed1To3.
        /// </summary>
        [TestVariable("9a82416d-4077-46d1-be07-b549fad7bc13")]
        public string Proceed1To3
        {
            get { return _Proceed1To3; }
            set { _Proceed1To3 = value; }
        }

        string _Proceed1Track3;

        /// <summary>
        /// Gets or sets the value of variable Proceed1Track3.
        /// </summary>
        [TestVariable("5c4259ee-fb9b-44c1-aa9a-f22b00a5527f")]
        public string Proceed1Track3
        {
            get { return _Proceed1Track3; }
            set { _Proceed1Track3 = value; }
        }

        string _WorkBetweenBetween;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenBetween.
        /// </summary>
        [TestVariable("b3d13c5c-db7b-4b93-8b37-a34a74c3421e")]
        public string WorkBetweenBetween
        {
            get { return _WorkBetweenBetween; }
            set { _WorkBetweenBetween = value; }
        }

        string _WorkBetweenAnd;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenAnd.
        /// </summary>
        [TestVariable("88b4afd1-710b-4bbe-ae4a-b958c93229fe")]
        public string WorkBetweenAnd
        {
            get { return _WorkBetweenAnd; }
            set { _WorkBetweenAnd = value; }
        }

        string _WorkBetweenTrack1;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenTrack1.
        /// </summary>
        [TestVariable("24847336-2268-497f-8e24-03997a03b1dd")]
        public string WorkBetweenTrack1
        {
            get { return _WorkBetweenTrack1; }
            set { _WorkBetweenTrack1 = value; }
        }

        string _WorkBetweenTrack2;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenTrack2.
        /// </summary>
        [TestVariable("677c28c1-98a3-4ef4-8372-216a8e79f05a")]
        public string WorkBetweenTrack2
        {
            get { return _WorkBetweenTrack2; }
            set { _WorkBetweenTrack2 = value; }
        }

        string _WorkBetweenTrack3;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenTrack3.
        /// </summary>
        [TestVariable("75710c5a-682c-403a-9c22-cd69ccd15fc3")]
        public string WorkBetweenTrack3
        {
            get { return _WorkBetweenTrack3; }
            set { _WorkBetweenTrack3 = value; }
        }

        string _WorkBetweenTrack4;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenTrack4.
        /// </summary>
        [TestVariable("010a147b-728a-4dbc-b116-b6a0798282a7")]
        public string WorkBetweenTrack4
        {
            get { return _WorkBetweenTrack4; }
            set { _WorkBetweenTrack4 = value; }
        }

        string _WorkBetweenTrack5;

        /// <summary>
        /// Gets or sets the value of variable WorkBetweenTrack5.
        /// </summary>
        [TestVariable("380b1af2-2551-4b9b-9be2-0f0117f9ab2a")]
        public string WorkBetweenTrack5
        {
            get { return _WorkBetweenTrack5; }
            set { _WorkBetweenTrack5 = value; }
        }

        string _EffectiveUntil;

        /// <summary>
        /// Gets or sets the value of variable EffectiveUntil.
        /// </summary>
        [TestVariable("9c5d1b96-e48c-40db-bfb7-fd0d27a29ef2")]
        public string EffectiveUntil
        {
            get { return _EffectiveUntil; }
            set { _EffectiveUntil = value; }
        }

        string _StopShortPoint;

        /// <summary>
        /// Gets or sets the value of variable StopShortPoint.
        /// </summary>
        [TestVariable("b8f16333-b5ab-4306-bc72-7b701c96b034")]
        public string StopShortPoint
        {
            get { return _StopShortPoint; }
            set { _StopShortPoint = value; }
        }

        string _StopShortTrack;

        /// <summary>
        /// Gets or sets the value of variable StopShortTrack.
        /// </summary>
        [TestVariable("5c84d30b-d544-404b-b87c-e2170ac866d9")]
        public string StopShortTrack
        {
            get { return _StopShortTrack; }
            set { _StopShortTrack = value; }
        }

        string _box12RWIC1;

        /// <summary>
        /// Gets or sets the value of variable box12RWIC1.
        /// </summary>
        [TestVariable("5ebb7b4d-d658-4ce4-ae8d-88efc51ee141")]
        public string box12RWIC1
        {
            get { return _box12RWIC1; }
            set { _box12RWIC1 = value; }
        }

        string _box12Between1;

        /// <summary>
        /// Gets or sets the value of variable box12Between1.
        /// </summary>
        [TestVariable("ba6d5dbd-7097-45b7-979f-55af59a1caaf")]
        public string box12Between1
        {
            get { return _box12Between1; }
            set { _box12Between1 = value; }
        }

        string _box12And1;

        /// <summary>
        /// Gets or sets the value of variable box12And1.
        /// </summary>
        [TestVariable("7f8188d3-a98b-40e7-92f6-c4390268e83b")]
        public string box12And1
        {
            get { return _box12And1; }
            set { _box12And1 = value; }
        }

        string _box12Track1;

        /// <summary>
        /// Gets or sets the value of variable box12Track1.
        /// </summary>
        [TestVariable("d73ec041-b612-4005-8b62-f4deaaa5baf1")]
        public string box12Track1
        {
            get { return _box12Track1; }
            set { _box12Track1 = value; }
        }

        string _box12RWIC2;

        /// <summary>
        /// Gets or sets the value of variable box12RWIC2.
        /// </summary>
        [TestVariable("3b56cd4d-6bc1-4687-8220-3e57e4ba8b8a")]
        public string box12RWIC2
        {
            get { return _box12RWIC2; }
            set { _box12RWIC2 = value; }
        }

        string _box12Between2;

        /// <summary>
        /// Gets or sets the value of variable box12Between2.
        /// </summary>
        [TestVariable("6be7d1e8-d4bf-4bc9-91b3-e4f947233551")]
        public string box12Between2
        {
            get { return _box12Between2; }
            set { _box12Between2 = value; }
        }

        string _box12And2;

        /// <summary>
        /// Gets or sets the value of variable box12And2.
        /// </summary>
        [TestVariable("eae45259-6cf9-4044-bd6f-58b4cd5c59ad")]
        public string box12And2
        {
            get { return _box12And2; }
            set { _box12And2 = value; }
        }

        string _box12Track2;

        /// <summary>
        /// Gets or sets the value of variable box12Track2.
        /// </summary>
        [TestVariable("d0132263-97e5-4ed8-abac-ac6e66758889")]
        public string box12Track2
        {
            get { return _box12Track2; }
            set { _box12Track2 = value; }
        }

        string _box12RWIC3;

        /// <summary>
        /// Gets or sets the value of variable box12RWIC3.
        /// </summary>
        [TestVariable("128207ef-b46c-4462-80af-146895d4b1de")]
        public string box12RWIC3
        {
            get { return _box12RWIC3; }
            set { _box12RWIC3 = value; }
        }

        string _box12Between3;

        /// <summary>
        /// Gets or sets the value of variable box12Between3.
        /// </summary>
        [TestVariable("8f6a6128-8a71-4e7b-a6cc-dd9c955ae454")]
        public string box12Between3
        {
            get { return _box12Between3; }
            set { _box12Between3 = value; }
        }

        string _box12And3;

        /// <summary>
        /// Gets or sets the value of variable box12And3.
        /// </summary>
        [TestVariable("76e7b91e-5a99-4354-bf00-035def2e788f")]
        public string box12And3
        {
            get { return _box12And3; }
            set { _box12And3 = value; }
        }

        string _box12Track3;

        /// <summary>
        /// Gets or sets the value of variable box12Track3.
        /// </summary>
        [TestVariable("34952640-8205-4081-9183-66065257b93b")]
        public string box12Track3
        {
            get { return _box12Track3; }
            set { _box12Track3 = value; }
        }

        string _OtherInstructionsSystem;

        /// <summary>
        /// Gets or sets the value of variable OtherInstructionsSystem.
        /// </summary>
        [TestVariable("e0abea04-6443-492b-9553-226abce1ae6e")]
        public string OtherInstructionsSystem
        {
            get { return _OtherInstructionsSystem; }
            set { _OtherInstructionsSystem = value; }
        }

        string _OtherInstructionsUser;

        /// <summary>
        /// Gets or sets the value of variable OtherInstructionsUser.
        /// </summary>
        [TestVariable("6687f595-aeb2-4e4b-a10b-85088cd8817a")]
        public string OtherInstructionsUser
        {
            get { return _OtherInstructionsUser; }
            set { _OtherInstructionsUser = value; }
        }

        string _Box1;

        /// <summary>
        /// Gets or sets the value of variable Box1.
        /// </summary>
        [TestVariable("e6149b1f-6f1c-464e-aa96-6ac3589d16d0")]
        public string Box1
        {
            get { return _Box1; }
            set { _Box1 = value; }
        }

        string _Box2;

        /// <summary>
        /// Gets or sets the value of variable Box2.
        /// </summary>
        [TestVariable("dd0c3ca3-0b72-44e3-8b91-96edf9a30ae7")]
        public string Box2
        {
            get { return _Box2; }
            set { _Box2 = value; }
        }

        string _Box3;

        /// <summary>
        /// Gets or sets the value of variable Box3.
        /// </summary>
        [TestVariable("c1376acb-6cbd-482e-b422-b7f2a73982a6")]
        public string Box3
        {
            get { return _Box3; }
            set { _Box3 = value; }
        }

        string _Box4;

        /// <summary>
        /// Gets or sets the value of variable Box4.
        /// </summary>
        [TestVariable("6fddc9f7-e72d-4197-b81c-7b5ac5733d55")]
        public string Box4
        {
            get { return _Box4; }
            set { _Box4 = value; }
        }

        string _Box5;

        /// <summary>
        /// Gets or sets the value of variable Box5.
        /// </summary>
        [TestVariable("7453b8ef-deb3-4250-8151-d7ba534ffb03")]
        public string Box5
        {
            get { return _Box5; }
            set { _Box5 = value; }
        }

        string _Box6;

        /// <summary>
        /// Gets or sets the value of variable Box6.
        /// </summary>
        [TestVariable("a55b9667-ba74-4a10-8325-939ba90ab6b3")]
        public string Box6
        {
            get { return _Box6; }
            set { _Box6 = value; }
        }

        string _Box7;

        /// <summary>
        /// Gets or sets the value of variable Box7.
        /// </summary>
        [TestVariable("b88b8984-c3c6-478f-af17-4a12d8f820d7")]
        public string Box7
        {
            get { return _Box7; }
            set { _Box7 = value; }
        }

        string _Box8;

        /// <summary>
        /// Gets or sets the value of variable Box8.
        /// </summary>
        [TestVariable("e8355e1e-fe85-4a2f-96d9-f7a4a31ddde3")]
        public string Box8
        {
            get { return _Box8; }
            set { _Box8 = value; }
        }

        string _Box9;

        /// <summary>
        /// Gets or sets the value of variable Box9.
        /// </summary>
        [TestVariable("1b007a6a-05e5-4180-be30-f4422e0eb079")]
        public string Box9
        {
            get { return _Box9; }
            set { _Box9 = value; }
        }

        string _Box10;

        /// <summary>
        /// Gets or sets the value of variable Box10.
        /// </summary>
        [TestVariable("8d688590-a72f-410a-afe2-063ba6d8ff14")]
        public string Box10
        {
            get { return _Box10; }
            set { _Box10 = value; }
        }

        string _Box11;

        /// <summary>
        /// Gets or sets the value of variable Box11.
        /// </summary>
        [TestVariable("9c14b055-f58c-4380-89e9-0202c92ee889")]
        public string Box11
        {
            get { return _Box11; }
            set { _Box11 = value; }
        }

        string _Box12;

        /// <summary>
        /// Gets or sets the value of variable Box12.
        /// </summary>
        [TestVariable("7e4b62b1-3619-4623-b4df-921fd3ad265a")]
        public string Box12
        {
            get { return _Box12; }
            set { _Box12 = value; }
        }

        string _Box13;

        /// <summary>
        /// Gets or sets the value of variable Box13.
        /// </summary>
        [TestVariable("6df5da4f-455d-4b87-a401-295097f08377")]
        public string Box13
        {
            get { return _Box13; }
            set { _Box13 = value; }
        }

        string _Box4Proceed2Between;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2Between.
        /// </summary>
        [TestVariable("732b943b-ddd8-4fd4-b3d6-114b5349fe91")]
        public string Box4Proceed2Between
        {
            get { return _Box4Proceed2Between; }
            set { _Box4Proceed2Between = value; }
        }

        string _Box4Proceed2To1;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2To1.
        /// </summary>
        [TestVariable("d76a608e-63da-4121-977a-7be25c80d5c1")]
        public string Box4Proceed2To1
        {
            get { return _Box4Proceed2To1; }
            set { _Box4Proceed2To1 = value; }
        }

        string _Box4Proceed2Track1;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2Track1.
        /// </summary>
        [TestVariable("6d65386b-a31c-41f8-a6d5-9f84e5609b84")]
        public string Box4Proceed2Track1
        {
            get { return _Box4Proceed2Track1; }
            set { _Box4Proceed2Track1 = value; }
        }

        string _Box4Proceed2To2;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2To2.
        /// </summary>
        [TestVariable("4d4e3005-3102-44c0-8093-aed2366e329e")]
        public string Box4Proceed2To2
        {
            get { return _Box4Proceed2To2; }
            set { _Box4Proceed2To2 = value; }
        }

        string _Box4Proceed2Track2;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2Track2.
        /// </summary>
        [TestVariable("730c26ce-a371-4308-b6e7-c777910cc4b4")]
        public string Box4Proceed2Track2
        {
            get { return _Box4Proceed2Track2; }
            set { _Box4Proceed2Track2 = value; }
        }

        string _Box4Proceed2To3;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2To3.
        /// </summary>
        [TestVariable("2d92973a-9225-402c-bf69-55735617a5c1")]
        public string Box4Proceed2To3
        {
            get { return _Box4Proceed2To3; }
            set { _Box4Proceed2To3 = value; }
        }

        string _Box4Proceed2Track3;

        /// <summary>
        /// Gets or sets the value of variable Box4Proceed2Track3.
        /// </summary>
        [TestVariable("1fac83b3-672c-4ab2-b33f-07fe7fe27944")]
        public string Box4Proceed2Track3
        {
            get { return _Box4Proceed2Track3; }
            set { _Box4Proceed2Track3 = value; }
        }

        string _TrainsToFollowTrainText;

        /// <summary>
        /// Gets or sets the value of variable TrainsToFollowTrainText.
        /// </summary>
        [TestVariable("353d9e45-e0b1-4342-b32f-6b3219a37f6e")]
        public string TrainsToFollowTrainText
        {
            get { return _TrainsToFollowTrainText; }
            set { _TrainsToFollowTrainText = value; }
        }

        string _TrainsToFollowTrain1Text;

        /// <summary>
        /// Gets or sets the value of variable TrainsToFollowTrain1Text.
        /// </summary>
        [TestVariable("975aa5a1-a165-4225-8d12-c7edfc96bbd7")]
        public string TrainsToFollowTrain1Text
        {
            get { return _TrainsToFollowTrain1Text; }
            set { _TrainsToFollowTrain1Text = value; }
        }

        string _TrainsToFollowTrain2Text;

        /// <summary>
        /// Gets or sets the value of variable TrainsToFollowTrain2Text.
        /// </summary>
        [TestVariable("cd0abcb5-5a90-47f9-ab00-7e62bb705045")]
        public string TrainsToFollowTrain2Text
        {
            get { return _TrainsToFollowTrain2Text; }
            set { _TrainsToFollowTrain2Text = value; }
        }

        string _TrainsSpeedRestrictionBetweenText;

        /// <summary>
        /// Gets or sets the value of variable TrainsSpeedRestrictionBetweenText.
        /// </summary>
        [TestVariable("d5d2492c-d8a7-4793-8218-edd2a94e3133")]
        public string TrainsSpeedRestrictionBetweenText
        {
            get { return _TrainsSpeedRestrictionBetweenText; }
            set { _TrainsSpeedRestrictionBetweenText = value; }
        }

        string _TrainsSpeedRestrictionAndText;

        /// <summary>
        /// Gets or sets the value of variable TrainsSpeedRestrictionAndText.
        /// </summary>
        [TestVariable("a16429dc-e5f8-4afe-8c0f-60e375d868d1")]
        public string TrainsSpeedRestrictionAndText
        {
            get { return _TrainsSpeedRestrictionAndText; }
            set { _TrainsSpeedRestrictionAndText = value; }
        }

        string _OpposingTrainField1Text;

        /// <summary>
        /// Gets or sets the value of variable OpposingTrainField1Text.
        /// </summary>
        [TestVariable("2457a23b-2f47-4524-9f67-5bccfdcad913")]
        public string OpposingTrainField1Text
        {
            get { return _OpposingTrainField1Text; }
            set { _OpposingTrainField1Text = value; }
        }

        string _OpposingTrainField2Text;

        /// <summary>
        /// Gets or sets the value of variable OpposingTrainField2Text.
        /// </summary>
        [TestVariable("849c4dd3-de2c-4f91-877c-443866c088f5")]
        public string OpposingTrainField2Text
        {
            get { return _OpposingTrainField2Text; }
            set { _OpposingTrainField2Text = value; }
        }

        string _OpposingTrainField3Text;

        /// <summary>
        /// Gets or sets the value of variable OpposingTrainField3Text.
        /// </summary>
        [TestVariable("62de7395-69a9-4a94-80b1-dc601ca4a1c6")]
        public string OpposingTrainField3Text
        {
            get { return _OpposingTrainField3Text; }
            set { _OpposingTrainField3Text = value; }
        }

        string _OpposingTrainsLocationText;

        /// <summary>
        /// Gets or sets the value of variable OpposingTrainsLocationText.
        /// </summary>
        [TestVariable("9dd326ae-c409-43ed-b715-6f7c0b3a7125")]
        public string OpposingTrainsLocationText
        {
            get { return _OpposingTrainsLocationText; }
            set { _OpposingTrainsLocationText = value; }
        }

        string _closeForm;

        /// <summary>
        /// Gets or sets the value of variable closeForm.
        /// </summary>
        [TestVariable("c5f3f77d-893f-452f-8eff-e50bb2711428")]
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

            UserCodeCollections.NS_Authorities.validateAuthorityDetails(AuthoritySeed, authorityType, To, At, CopiedBy, RelayingEmployee, RelayingAt, ExtendUntil, ExtendBy, ExtendOSLocation, ValueConverter.ArgumentFromString<bool>("Box1", Box1), ValueConverter.ArgumentFromString<bool>("Box2", Box2), ValueConverter.ArgumentFromString<bool>("Box3", Box3), ValueConverter.ArgumentFromString<bool>("Box4", Box4), ValueConverter.ArgumentFromString<bool>("Box5", Box5), ValueConverter.ArgumentFromString<bool>("Box6", Box6), ValueConverter.ArgumentFromString<bool>("Box7", Box7), ValueConverter.ArgumentFromString<bool>("Box8", Box8), ValueConverter.ArgumentFromString<bool>("Box9", Box9), ValueConverter.ArgumentFromString<bool>("Box10", Box10), ValueConverter.ArgumentFromString<bool>("Box11", Box11), ValueConverter.ArgumentFromString<bool>("Box12", Box12), ValueConverter.ArgumentFromString<bool>("Box13", Box13), ValueConverter.ArgumentFromString<bool>("ExtendFSW", ExtendFSW), ExtendRecordedTime, AuthorityToVoid, Box4Proceed2Between, Box4Proceed2To1, Box4Proceed2Track1, Box4Proceed2To2, Box4Proceed2Track2, Box4Proceed2To3, Box4Proceed2Track3, Proceed1Between, Proceed1To1, Proceed1Track1, Proceed1To2, Proceed1Track2, Proceed1To3, Proceed1Track3, WorkBetweenBetween, WorkBetweenAnd, WorkBetweenTrack1, WorkBetweenTrack2, WorkBetweenTrack3, WorkBetweenTrack4, WorkBetweenTrack5, EffectiveUntil, StopShortPoint, StopShortTrack, OpposingTrainField1Text, TrainsToFollowTrain2Text, OpposingTrainField3Text, OpposingTrainsLocationText, TrainsToFollowTrainText, TrainsToFollowTrain1Text, TrainsToFollowTrain2Text, TrainsSpeedRestrictionBetweenText, TrainsSpeedRestrictionAndText, box12RWIC1, box12Between1, box12And1, box12Track1, box12RWIC2, box12Between2, box12And2, box12Track2, box12RWIC3, box12Between3, box12And3, box12Track3, OtherInstructionsSystem, OtherInstructionsUser, ValueConverter.ArgumentFromString<bool>("closeForm", closeForm));
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}