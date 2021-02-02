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

namespace PDS_NS.Recording_Modules.RUM
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SendRD_RTIR_FBAStyle recording.
    /// </summary>
    [TestModule("c57f316e-aa8b-4684-96e8-cb95e05a7e15", ModuleType.Recording, 1)]
    public partial class SendRD_RTIR_FBAStyle : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::PDS_NS.PDS_NSRepository repository.
        /// </summary>
        public static global::PDS_NS.PDS_NSRepository repo = global::PDS_NS.PDS_NSRepository.Instance;

        static SendRD_RTIR_FBAStyle instance = new SendRD_RTIR_FBAStyle();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendRD_RTIR_FBAStyle()
        {
            district_name = "";
            type = "";
            to = "";
            at = "";
            box1_yn = "";
            box1_void = "";
            box2_yn = "";
            box2_fsw = "";
            box2_to = "";
            box2_from = "";
            box2_track1 = "";
            box2_to2 = "";
            box2_track2 = "";
            box2_to3 = "";
            box2_track3 = "";
            box2_zones = "";
            box3_yn = "";
            box3_loc1 = "";
            box3_loc1_os = "";
            box3_loc2 = "";
            box3_loc2_cp = "";
            box3_track1 = "";
            box3_track2 = "";
            box3_track3 = "";
            box3_track4 = "";
            box3_track5 = "";
            zone_list = "";
            box4_yn = "";
            box4_from = "";
            box4_fsw = "";
            box4_to = "";
            box4_track1 = "";
            box4_to2 = "";
            box4_track2 = "";
            box4_to3 = "";
            box4_track3 = "";
            box5_time = "";
            box7_yn = "";
            box9_yn = "";
            box13_subdiv = "";
            box13_subdiv_limit = "";
            box13_subdiv_side = "";
            spaf_ack = "";
            employee_name = "";
            box3_loc1_cp = "";
            ru_comments = "";
            optionalTrainSeed = "";
            optionalEngineSeed = "";
            box1_joint_occupancy = "";
            requesting_employee = "";
            userId = "";
            division_name = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SendRD_RTIR_FBAStyle Instance
        {
            get { return instance; }
        }

#region Variables

        string _district_name;

        /// <summary>
        /// Gets or sets the value of variable district_name.
        /// </summary>
        [TestVariable("4de854f5-e3a4-4f82-8ce3-1ba52fbcbf52")]
        public string district_name
        {
            get { return _district_name; }
            set { _district_name = value; }
        }

        string _type;

        /// <summary>
        /// Gets or sets the value of variable type.
        /// </summary>
        [TestVariable("e16ad4e7-9254-43e9-a987-54f1f253c1d0")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        string _to;

        /// <summary>
        /// Gets or sets the value of variable to.
        /// </summary>
        [TestVariable("c1d80447-72dd-4e8d-8796-641bbf038dbd")]
        public string to
        {
            get { return _to; }
            set { _to = value; }
        }

        string _at;

        /// <summary>
        /// Gets or sets the value of variable at.
        /// </summary>
        [TestVariable("45a0febc-232d-41ec-b1e0-dceb54424316")]
        public string at
        {
            get { return _at; }
            set { _at = value; }
        }

        string _box1_yn;

        /// <summary>
        /// Gets or sets the value of variable box1_yn.
        /// </summary>
        [TestVariable("8369cba4-b825-40ec-bcdd-b671c23f7f01")]
        public string box1_yn
        {
            get { return _box1_yn; }
            set { _box1_yn = value; }
        }

        string _box1_void;

        /// <summary>
        /// Gets or sets the value of variable box1_void.
        /// </summary>
        [TestVariable("21aaeb12-3293-4337-9301-57a67af5c76a")]
        public string box1_void
        {
            get { return _box1_void; }
            set { _box1_void = value; }
        }

        string _box2_yn;

        /// <summary>
        /// Gets or sets the value of variable box2_yn.
        /// </summary>
        [TestVariable("9aea68f4-8eed-4cdf-9ee4-37d602ed0cd0")]
        public string box2_yn
        {
            get { return _box2_yn; }
            set { _box2_yn = value; }
        }

        string _box2_fsw;

        /// <summary>
        /// Gets or sets the value of variable box2_fsw.
        /// </summary>
        [TestVariable("a195f1d1-bfc0-439b-997c-4deb500a7d9a")]
        public string box2_fsw
        {
            get { return _box2_fsw; }
            set { _box2_fsw = value; }
        }

        string _box2_to;

        /// <summary>
        /// Gets or sets the value of variable box2_to.
        /// </summary>
        [TestVariable("db9656ac-8d98-4539-ab6b-037f8cf0b35d")]
        public string box2_to
        {
            get { return _box2_to; }
            set { _box2_to = value; }
        }

        string _box2_from;

        /// <summary>
        /// Gets or sets the value of variable box2_from.
        /// </summary>
        [TestVariable("3ed24f83-34b3-47a6-a0fd-b28d4fdbc634")]
        public string box2_from
        {
            get { return _box2_from; }
            set { _box2_from = value; }
        }

        string _box2_track1;

        /// <summary>
        /// Gets or sets the value of variable box2_track1.
        /// </summary>
        [TestVariable("f482ce94-f462-4f80-a4d1-e9a30dfd7c92")]
        public string box2_track1
        {
            get { return _box2_track1; }
            set { _box2_track1 = value; }
        }

        string _box2_to2;

        /// <summary>
        /// Gets or sets the value of variable box2_to2.
        /// </summary>
        [TestVariable("2bd1b5a9-4aea-46b5-9907-3652812071ea")]
        public string box2_to2
        {
            get { return _box2_to2; }
            set { _box2_to2 = value; }
        }

        string _box2_track2;

        /// <summary>
        /// Gets or sets the value of variable box2_track2.
        /// </summary>
        [TestVariable("940f2b2e-b38c-45e3-86d5-6d7b1910cfc2")]
        public string box2_track2
        {
            get { return _box2_track2; }
            set { _box2_track2 = value; }
        }

        string _box2_to3;

        /// <summary>
        /// Gets or sets the value of variable box2_to3.
        /// </summary>
        [TestVariable("18b09423-2711-4d19-8341-2bc1d8c1cbcb")]
        public string box2_to3
        {
            get { return _box2_to3; }
            set { _box2_to3 = value; }
        }

        string _box2_track3;

        /// <summary>
        /// Gets or sets the value of variable box2_track3.
        /// </summary>
        [TestVariable("e9da49b3-e1c8-4d1e-8be5-b705a92c68e7")]
        public string box2_track3
        {
            get { return _box2_track3; }
            set { _box2_track3 = value; }
        }

        string _box2_zones;

        /// <summary>
        /// Gets or sets the value of variable box2_zones.
        /// </summary>
        [TestVariable("de8b5e6d-c935-427d-a513-178ecdc1d0dd")]
        public string box2_zones
        {
            get { return _box2_zones; }
            set { _box2_zones = value; }
        }

        string _box3_yn;

        /// <summary>
        /// Gets or sets the value of variable box3_yn.
        /// </summary>
        [TestVariable("b0d269a5-c2aa-4b95-bac8-479583f4047c")]
        public string box3_yn
        {
            get { return _box3_yn; }
            set { _box3_yn = value; }
        }

        string _box3_loc1;

        /// <summary>
        /// Gets or sets the value of variable box3_loc1.
        /// </summary>
        [TestVariable("c6a30f1d-71fa-403f-a7e7-5853991d5ea2")]
        public string box3_loc1
        {
            get { return _box3_loc1; }
            set { _box3_loc1 = value; }
        }

        string _box3_loc1_os;

        /// <summary>
        /// Gets or sets the value of variable box3_loc1_os.
        /// </summary>
        [TestVariable("bfe1a053-000a-4e1a-8d82-2a1b1b2cc902")]
        public string box3_loc1_os
        {
            get { return _box3_loc1_os; }
            set { _box3_loc1_os = value; }
        }

        string _box3_loc2;

        /// <summary>
        /// Gets or sets the value of variable box3_loc2.
        /// </summary>
        [TestVariable("ee2a587f-d256-44a3-bbb9-7691c9813d76")]
        public string box3_loc2
        {
            get { return _box3_loc2; }
            set { _box3_loc2 = value; }
        }

        string _box3_loc2_cp;

        /// <summary>
        /// Gets or sets the value of variable box3_loc2_cp.
        /// </summary>
        [TestVariable("1b1d8227-6edf-4328-9503-9147d2a70ff6")]
        public string box3_loc2_cp
        {
            get { return _box3_loc2_cp; }
            set { _box3_loc2_cp = value; }
        }

        string _box3_track1;

        /// <summary>
        /// Gets or sets the value of variable box3_track1.
        /// </summary>
        [TestVariable("5210bf61-96c3-43fb-950e-de61ff6215dc")]
        public string box3_track1
        {
            get { return _box3_track1; }
            set { _box3_track1 = value; }
        }

        string _box3_track2;

        /// <summary>
        /// Gets or sets the value of variable box3_track2.
        /// </summary>
        [TestVariable("c2e19ba9-149d-45a1-b097-c3fcae80427a")]
        public string box3_track2
        {
            get { return _box3_track2; }
            set { _box3_track2 = value; }
        }

        string _box3_track3;

        /// <summary>
        /// Gets or sets the value of variable box3_track3.
        /// </summary>
        [TestVariable("abbab6d4-1090-4859-9279-5dfcb0cf79fd")]
        public string box3_track3
        {
            get { return _box3_track3; }
            set { _box3_track3 = value; }
        }

        string _box3_track4;

        /// <summary>
        /// Gets or sets the value of variable box3_track4.
        /// </summary>
        [TestVariable("fa8e7847-dfb3-455f-8485-f0cf3997811d")]
        public string box3_track4
        {
            get { return _box3_track4; }
            set { _box3_track4 = value; }
        }

        string _box3_track5;

        /// <summary>
        /// Gets or sets the value of variable box3_track5.
        /// </summary>
        [TestVariable("d5122b80-a169-4a22-950b-caba1e2619a3")]
        public string box3_track5
        {
            get { return _box3_track5; }
            set { _box3_track5 = value; }
        }

        string _zone_list;

        /// <summary>
        /// Gets or sets the value of variable zone_list.
        /// </summary>
        [TestVariable("ae422d89-8ba0-40a9-a332-2429300a7913")]
        public string zone_list
        {
            get { return _zone_list; }
            set { _zone_list = value; }
        }

        string _box4_yn;

        /// <summary>
        /// Gets or sets the value of variable box4_yn.
        /// </summary>
        [TestVariable("5ff403b9-9491-4a5c-af5b-6ba24f11f558")]
        public string box4_yn
        {
            get { return _box4_yn; }
            set { _box4_yn = value; }
        }

        string _box4_from;

        /// <summary>
        /// Gets or sets the value of variable box4_from.
        /// </summary>
        [TestVariable("b9a54e37-4c38-4ce0-9914-d7f60687af14")]
        public string box4_from
        {
            get { return _box4_from; }
            set { _box4_from = value; }
        }

        string _box4_fsw;

        /// <summary>
        /// Gets or sets the value of variable box4_fsw.
        /// </summary>
        [TestVariable("d9b78e6f-666b-4b53-bd86-e08b5fa2c8cd")]
        public string box4_fsw
        {
            get { return _box4_fsw; }
            set { _box4_fsw = value; }
        }

        string _box4_to;

        /// <summary>
        /// Gets or sets the value of variable box4_to.
        /// </summary>
        [TestVariable("9184704d-ef17-4ee6-a75d-6b2250163559")]
        public string box4_to
        {
            get { return _box4_to; }
            set { _box4_to = value; }
        }

        string _box4_track1;

        /// <summary>
        /// Gets or sets the value of variable box4_track1.
        /// </summary>
        [TestVariable("f62c387a-c2fb-4fe4-90c4-45f5abce81af")]
        public string box4_track1
        {
            get { return _box4_track1; }
            set { _box4_track1 = value; }
        }

        string _box4_to2;

        /// <summary>
        /// Gets or sets the value of variable box4_to2.
        /// </summary>
        [TestVariable("7e09f94f-96bc-4b40-baa7-def6c86b61bf")]
        public string box4_to2
        {
            get { return _box4_to2; }
            set { _box4_to2 = value; }
        }

        string _box4_track2;

        /// <summary>
        /// Gets or sets the value of variable box4_track2.
        /// </summary>
        [TestVariable("48ea47a3-8418-4570-80ec-9f14e4039602")]
        public string box4_track2
        {
            get { return _box4_track2; }
            set { _box4_track2 = value; }
        }

        string _box4_to3;

        /// <summary>
        /// Gets or sets the value of variable box4_to3.
        /// </summary>
        [TestVariable("2969d0da-44ec-4db4-80c0-5123d6bb2f4b")]
        public string box4_to3
        {
            get { return _box4_to3; }
            set { _box4_to3 = value; }
        }

        string _box4_track3;

        /// <summary>
        /// Gets or sets the value of variable box4_track3.
        /// </summary>
        [TestVariable("96309f7d-434e-4158-996a-3d37fff57fe4")]
        public string box4_track3
        {
            get { return _box4_track3; }
            set { _box4_track3 = value; }
        }

        string _box5_time;

        /// <summary>
        /// Gets or sets the value of variable box5_time.
        /// </summary>
        [TestVariable("5fc521a1-e592-46c9-9a51-8e0c67d79c4e")]
        public string box5_time
        {
            get { return _box5_time; }
            set { _box5_time = value; }
        }

        string _box7_yn;

        /// <summary>
        /// Gets or sets the value of variable box7_yn.
        /// </summary>
        [TestVariable("7bf697be-6b01-41a1-8bc7-e1b87744b972")]
        public string box7_yn
        {
            get { return _box7_yn; }
            set { _box7_yn = value; }
        }

        string _box9_yn;

        /// <summary>
        /// Gets or sets the value of variable box9_yn.
        /// </summary>
        [TestVariable("7e68d698-3d7f-4c61-96ab-bc8023283bcc")]
        public string box9_yn
        {
            get { return _box9_yn; }
            set { _box9_yn = value; }
        }

        string _box13_subdiv;

        /// <summary>
        /// Gets or sets the value of variable box13_subdiv.
        /// </summary>
        [TestVariable("11a2f685-1c49-4cd6-b073-860173826a80")]
        public string box13_subdiv
        {
            get { return _box13_subdiv; }
            set { _box13_subdiv = value; }
        }

        string _box13_subdiv_limit;

        /// <summary>
        /// Gets or sets the value of variable box13_subdiv_limit.
        /// </summary>
        [TestVariable("614d603b-afb6-4599-b112-1bfeacb53cc0")]
        public string box13_subdiv_limit
        {
            get { return _box13_subdiv_limit; }
            set { _box13_subdiv_limit = value; }
        }

        string _box13_subdiv_side;

        /// <summary>
        /// Gets or sets the value of variable box13_subdiv_side.
        /// </summary>
        [TestVariable("f2c420a0-509a-4e61-b3df-cf7202b941b8")]
        public string box13_subdiv_side
        {
            get { return _box13_subdiv_side; }
            set { _box13_subdiv_side = value; }
        }

        string _spaf_ack;

        /// <summary>
        /// Gets or sets the value of variable spaf_ack.
        /// </summary>
        [TestVariable("f65efc53-546c-43c9-9688-0fa9b4aed355")]
        public string spaf_ack
        {
            get { return _spaf_ack; }
            set { _spaf_ack = value; }
        }

        string _employee_name;

        /// <summary>
        /// Gets or sets the value of variable employee_name.
        /// </summary>
        [TestVariable("1b5798f4-3908-4094-9528-6a5b6be6eae6")]
        public string employee_name
        {
            get { return _employee_name; }
            set { _employee_name = value; }
        }

        string _box3_loc1_cp;

        /// <summary>
        /// Gets or sets the value of variable box3_loc1_cp.
        /// </summary>
        [TestVariable("a434d428-4738-409d-9ca3-bef4022e87b4")]
        public string box3_loc1_cp
        {
            get { return _box3_loc1_cp; }
            set { _box3_loc1_cp = value; }
        }

        string _ru_comments;

        /// <summary>
        /// Gets or sets the value of variable ru_comments.
        /// </summary>
        [TestVariable("5731c3ed-ddb7-48ea-addc-79a3b19dde39")]
        public string ru_comments
        {
            get { return _ru_comments; }
            set { _ru_comments = value; }
        }

        string _optionalTrainSeed;

        /// <summary>
        /// Gets or sets the value of variable optionalTrainSeed.
        /// </summary>
        [TestVariable("3be6d92a-bd44-4960-bfc8-2c51cbcd529c")]
        public string optionalTrainSeed
        {
            get { return _optionalTrainSeed; }
            set { _optionalTrainSeed = value; }
        }

        string _optionalEngineSeed;

        /// <summary>
        /// Gets or sets the value of variable optionalEngineSeed.
        /// </summary>
        [TestVariable("6d261c8c-6bb3-4a98-a578-772af2a74fac")]
        public string optionalEngineSeed
        {
            get { return _optionalEngineSeed; }
            set { _optionalEngineSeed = value; }
        }

        string _box1_joint_occupancy;

        /// <summary>
        /// Gets or sets the value of variable box1_joint_occupancy.
        /// </summary>
        [TestVariable("d15c7660-35bd-49f4-8123-8e778bf6b36f")]
        public string box1_joint_occupancy
        {
            get { return _box1_joint_occupancy; }
            set { _box1_joint_occupancy = value; }
        }

        string _requesting_employee;

        /// <summary>
        /// Gets or sets the value of variable requesting_employee.
        /// </summary>
        [TestVariable("4335ca93-3dfe-4512-b7e5-2ff592a5d48d")]
        public string requesting_employee
        {
            get { return _requesting_employee; }
            set { _requesting_employee = value; }
        }

        string _userId;

        /// <summary>
        /// Gets or sets the value of variable userId.
        /// </summary>
        [TestVariable("63f6c925-7ed1-448c-84a7-169cbaaab628")]
        public string userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        string _division_name;

        /// <summary>
        /// Gets or sets the value of variable division_name.
        /// </summary>
        [TestVariable("e960298a-5c96-4224-bcc7-6eab547876ce")]
        public string division_name
        {
            get { return _division_name; }
            set { _division_name = value; }
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

            UserCodeCollections.NS_RUM.NS_SendRD_RTIR_FBAStyle(optionalTrainSeed, optionalEngineSeed, district_name, type, to, at, box1_yn, box1_void, box2_yn, box2_from, box2_fsw, box2_to, box2_track1, box2_to2, box2_track2, box2_to3, box2_track3, box2_zones, box3_yn, box3_loc1, box3_loc1_cp, box3_loc1_os, box3_loc2, box3_loc2_cp, box3_track1, box3_track2, box3_track3, box3_track4, box3_track5, zone_list, box4_yn, box4_from, box4_fsw, box4_to, box4_track1, box4_to2, box4_track2, box4_to3, box4_track3, box5_time, box7_yn, box9_yn, box13_subdiv, box13_subdiv_limit, box13_subdiv_side, spaf_ack, requesting_employee, employee_name, ru_comments, box1_joint_occupancy, userId, division_name);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
