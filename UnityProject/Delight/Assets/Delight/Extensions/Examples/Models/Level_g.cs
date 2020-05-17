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

        public readonly Level Level1_1;
        public readonly Level Level1_2;
        public readonly Level Level1_3;
        public readonly Level Level2_1;
        public readonly Level Level2_2;
        public readonly Level Level2_3;
        public readonly Level Level3_1;
        public readonly Level Level3_2;

        #endregion

        #region Constructor

        public LevelData()
        {
            Level1_1 = new Level { Id = "Level1_1", Name = "Level 1-1", Score = 3, IsLocked = false };
            Add(Level1_1);
            Level1_2 = new Level { Id = "Level1_2", Name = "Level 1-2", Score = 3, IsLocked = false };
            Add(Level1_2);
            Level1_3 = new Level { Id = "Level1_3", Name = "Level 1-3", Score = 2, IsLocked = false };
            Add(Level1_3);
            Level2_1 = new Level { Id = "Level2_1", Name = "Level 2-1", Score = 1, IsLocked = false };
            Add(Level2_1);
            Level2_2 = new Level { Id = "Level2_2", Name = "Level 2-2", Score = 1, IsLocked = false };
            Add(Level2_2);
            Level2_3 = new Level { Id = "Level2_3", Name = "Level 2-3", Score = 0, IsLocked = true };
            Add(Level2_3);
            Level3_1 = new Level { Id = "Level3_1", Name = "Level 3-1", Score = 0, IsLocked = true };
            Add(Level3_1);
            Level3_2 = new Level { Id = "Level3_2", Name = "Level 3-2", Score = 0, IsLocked = true };
            Add(Level3_2);
        }

        #endregion
    }

    public static partial class Models
    {
        public static LevelData Levels = new LevelData();
    }

    #endregion
}
