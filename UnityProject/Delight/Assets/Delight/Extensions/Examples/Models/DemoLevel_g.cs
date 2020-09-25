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
    public partial class DemoLevel : ModelObject
    {
        #region Properties

        [SerializeField]
        public string DemoWorldId;
        public DemoWorld DemoWorld
        {
            get { return Models.DemoWorlds[DemoWorldId]; }
            set { SetProperty(ref DemoWorldId, value?.Id); }
        }

        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [SerializeField]
        private int _score;
        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        [SerializeField]
        private bool _isLocked;
        public bool IsLocked
        {
            get { return _isLocked; }
            set { SetProperty(ref _isLocked, value); }
        }

        #endregion
    }

    #region Data Provider

    public partial class DemoLevelData : DataProvider<DemoLevel>
    {
        #region Fields

        public readonly DemoLevel Level1;
        public readonly DemoLevel Level2;
        public readonly DemoLevel Level3;
        public readonly DemoLevel Level4;
        public readonly DemoLevel Level5;
        public readonly DemoLevel Level6;
        public readonly DemoLevel Level7;
        public readonly DemoLevel Level8;
        public readonly DemoLevel Level9;
        public readonly DemoLevel Level10;
        public readonly DemoLevel Level11;
        public readonly DemoLevel Level12;
        public readonly DemoLevel Level13;
        public readonly DemoLevel Level14;
        public readonly DemoLevel Level15;
        public readonly DemoLevel Level16;
        public readonly DemoLevel Level17;
        public readonly DemoLevel Level18;

        #endregion

        #region Constructor

        public DemoLevelData()
        {
            Level1 = new DemoLevel { Id = "Level1", Name = "Level 1", Score = 3, IsLocked = false };
            Add(Level1);
            Level2 = new DemoLevel { Id = "Level2", Name = "Level 2", Score = 3, IsLocked = false };
            Add(Level2);
            Level3 = new DemoLevel { Id = "Level3", Name = "Level 3", Score = 3, IsLocked = false };
            Add(Level3);
            Level4 = new DemoLevel { Id = "Level4", Name = "Level 4", Score = 2, IsLocked = false };
            Add(Level4);
            Level5 = new DemoLevel { Id = "Level5", Name = "Level 5", Score = 1, IsLocked = false };
            Add(Level5);
            Level6 = new DemoLevel { Id = "Level6", Name = "Level 6", Score = 2, IsLocked = false };
            Add(Level6);
            Level7 = new DemoLevel { Id = "Level7", Name = "Level 7", Score = 2, IsLocked = false };
            Add(Level7);
            Level8 = new DemoLevel { Id = "Level8", Name = "Level 8", Score = 1, IsLocked = false };
            Add(Level8);
            Level9 = new DemoLevel { Id = "Level9", Name = "Level 9", Score = 2, IsLocked = false };
            Add(Level9);
            Level10 = new DemoLevel { Id = "Level10", Name = "Level 10", Score = 2, IsLocked = false };
            Add(Level10);
            Level11 = new DemoLevel { Id = "Level11", Name = "Level 11", Score = 3, IsLocked = false };
            Add(Level11);
            Level12 = new DemoLevel { Id = "Level12", Name = "Level 11", Score = 0, IsLocked = false };
            Add(Level12);
            Level13 = new DemoLevel { Id = "Level13", Name = "Level 13", Score = 2, IsLocked = false };
            Add(Level13);
            Level14 = new DemoLevel { Id = "Level14", Name = "Level 14", Score = 2, IsLocked = false };
            Add(Level14);
            Level15 = new DemoLevel { Id = "Level15", Name = "Level 15", Score = 0, IsLocked = false };
            Add(Level15);
            Level16 = new DemoLevel { Id = "Level16", Name = "Level 16", Score = 0, IsLocked = true };
            Add(Level16);
            Level17 = new DemoLevel { Id = "Level17", Name = "Level 17", Score = 0, IsLocked = true };
            Add(Level17);
            Level18 = new DemoLevel { Id = "Level18", Name = "Level 18", Score = 0, IsLocked = true };
            Add(Level18);
        }

        #endregion

        #region Methods

        protected Dictionary<string, BindableCollectionSubset<DemoLevel>> _demoWorldDemoLevels = new Dictionary<string, BindableCollectionSubset<DemoLevel>>();
        public virtual BindableCollectionSubset<DemoLevel> Get(DemoWorld demoWorld)
        {
            if (demoWorld == null)
                return null;

            string demoWorldId = demoWorld.Id;
            BindableCollectionSubset<DemoLevel> demoWorldDemoLevels;
            if (_demoWorldDemoLevels.TryGetValue(demoWorldId, out demoWorldDemoLevels))
                return demoWorldDemoLevels;

            demoWorldDemoLevels = new BindableCollectionSubset<DemoLevel>(this, x => x.DemoWorldId == demoWorldId, x => x.DemoWorldId = demoWorldId);
            _demoWorldDemoLevels.Add(demoWorldId, demoWorldDemoLevels);
            return demoWorldDemoLevels;
        }

        #endregion
    }

    public static partial class Models
    {
        public static DemoLevelData DemoLevels = new DemoLevelData();
    }

    #endregion
}
