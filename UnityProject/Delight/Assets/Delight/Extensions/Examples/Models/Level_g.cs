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
    public partial class Level : ModelObject
    {
        #region Properties

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

    public partial class LevelData : DataProvider<Level>
    {
        #region Fields

        public readonly Level Level1;
        public readonly Level Level2;
        public readonly Level Level3;
        public readonly Level Level4;
        public readonly Level Level5;
        public readonly Level Level6;
        public readonly Level Level7;
        public readonly Level Level8;
        public readonly Level Level9;
        public readonly Level Level10;
        public readonly Level Level11;
        public readonly Level Level12;
        public readonly Level Level13;
        public readonly Level Level14;
        public readonly Level Level15;
        public readonly Level Level16;
        public readonly Level Level17;
        public readonly Level Level18;

        #endregion

        #region Constructor

        public LevelData()
        {
            Level1 = new Level { Id = "Level1", Name = "Level 1", Score = 3, IsLocked = false };
            Add(Level1);
            Level2 = new Level { Id = "Level2", Name = "Level 2", Score = 3, IsLocked = false };
            Add(Level2);
            Level3 = new Level { Id = "Level3", Name = "Level 3", Score = 3, IsLocked = false };
            Add(Level3);
            Level4 = new Level { Id = "Level4", Name = "Level 4", Score = 2, IsLocked = false };
            Add(Level4);
            Level5 = new Level { Id = "Level5", Name = "Level 5", Score = 1, IsLocked = false };
            Add(Level5);
            Level6 = new Level { Id = "Level6", Name = "Level 6", Score = 2, IsLocked = false };
            Add(Level6);
            Level7 = new Level { Id = "Level7", Name = "Level 7", Score = 2, IsLocked = false };
            Add(Level7);
            Level8 = new Level { Id = "Level8", Name = "Level 8", Score = 1, IsLocked = false };
            Add(Level8);
            Level9 = new Level { Id = "Level9", Name = "Level 9", Score = 2, IsLocked = false };
            Add(Level9);
            Level10 = new Level { Id = "Level10", Name = "Level 10", Score = 2, IsLocked = false };
            Add(Level10);
            Level11 = new Level { Id = "Level11", Name = "Level 11", Score = 3, IsLocked = false };
            Add(Level11);
            Level12 = new Level { Id = "Level12", Name = "Level 11", Score = 0, IsLocked = false };
            Add(Level12);
            Level13 = new Level { Id = "Level13", Name = "Level 13", Score = 2, IsLocked = false };
            Add(Level13);
            Level14 = new Level { Id = "Level14", Name = "Level 14", Score = 2, IsLocked = false };
            Add(Level14);
            Level15 = new Level { Id = "Level15", Name = "Level 15", Score = 0, IsLocked = false };
            Add(Level15);
            Level16 = new Level { Id = "Level16", Name = "Level 16", Score = 0, IsLocked = true };
            Add(Level16);
            Level17 = new Level { Id = "Level17", Name = "Level 17", Score = 0, IsLocked = true };
            Add(Level17);
            Level18 = new Level { Id = "Level18", Name = "Level 18", Score = 0, IsLocked = true };
            Add(Level18);
        }

        #endregion
    }

    public static partial class Models
    {
        public static LevelData Levels = new LevelData();
    }

    #endregion
}
