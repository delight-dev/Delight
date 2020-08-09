// Model generated from "Schema.txt"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    [Serializable]
    public partial class DemoPlayer : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class DemoPlayerData : DataProvider<DemoPlayer>
    {
        #region Fields

        public readonly DemoPlayer Player1;
        public readonly DemoPlayer Player2;
        public readonly DemoPlayer Player3;
        public readonly DemoPlayer Player4;
        public readonly DemoPlayer Player5;
        public readonly DemoPlayer Player6;
        public readonly DemoPlayer Player7;
        public readonly DemoPlayer Player8;
        public readonly DemoPlayer Player9;
        public readonly DemoPlayer Player10;
        public readonly DemoPlayer Player11;
        public readonly DemoPlayer Player12;
        public readonly DemoPlayer Player13;

        #endregion

        #region Constructor

        public DemoPlayerData()
        {
            Player1 = new DemoPlayer { Id = "Player1", Name = "Wizball" };
            Add(Player1);
            Player2 = new DemoPlayer { Id = "Player2", Name = "asdf" };
            Add(Player2);
            Player3 = new DemoPlayer { Id = "Player3", Name = "Yesper" };
            Add(Player3);
            Player4 = new DemoPlayer { Id = "Player4", Name = "Jacob4" };
            Add(Player4);
            Player5 = new DemoPlayer { Id = "Player5", Name = "xCool" };
            Add(Player5);
            Player6 = new DemoPlayer { Id = "Player6", Name = "pking1" };
            Add(Player6);
            Player7 = new DemoPlayer { Id = "Player7", Name = "pjkminCoo" };
            Add(Player7);
            Player8 = new DemoPlayer { Id = "Player8", Name = "Machin1st" };
            Add(Player8);
            Player9 = new DemoPlayer { Id = "Player9", Name = "DWerck16" };
            Add(Player9);
            Player10 = new DemoPlayer { Id = "Player10", Name = "Pfauxhypocricy" };
            Add(Player10);
            Player11 = new DemoPlayer { Id = "Player11", Name = "Bananaman13" };
            Add(Player11);
            Player12 = new DemoPlayer { Id = "Player12", Name = "Opwiz" };
            Add(Player12);
            Player13 = new DemoPlayer { Id = "Player13", Name = "afauxicy" };
            Add(Player13);
        }

        #endregion
    }

    public static partial class Models
    {
        public static DemoPlayerData DemoPlayers = new DemoPlayerData();
    }

    #endregion
}
