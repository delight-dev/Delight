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

        public string WorldId { get; set; }
        public World World
        {
            get { return Models.Worlds[WorldId]; }
            set { WorldId = value?.Id; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public BindableCollection<Highscore> Highscores
        {
            get { return Models.Highscores.Get(this); }
        }

        #endregion
    }

    #region Data Provider

    public partial class LevelData : DataProvider<Level>
    {
        #region Constructor

        public LevelData()
        {
            Add(new Level { Id = "Level1_1", WorldId = "World1", Name = "Level 1-1" });
            Add(new Level { Id = "Level1_2", WorldId = "World1", Name = "Level 1-2" });
            Add(new Level { Id = "Level1_3", WorldId = "World1", Name = "Level 1-3" });
            Add(new Level { Id = "Level2_1", WorldId = "World2", Name = "Level 2-1" });
            Add(new Level { Id = "Level2_2", WorldId = "World2", Name = "Level 2-2" });
            Add(new Level { Id = "Level2_3", WorldId = "World2", Name = "Level 2-3" });
            Add(new Level { Id = "Level3_1", WorldId = "World3", Name = "Level 3-1" });
            Add(new Level { Id = "Level3_2", WorldId = "World3", Name = "Level 3-2" });
        }

        #endregion

        #region Methods

        protected Dictionary<string, BindableCollectionSubset<Level>> _worldLevels = new Dictionary<string, BindableCollectionSubset<Level>>();
        public virtual BindableCollectionSubset<Level> Get(World world)
        {
            if (world == null)
                return null;

            string worldId = world.Id;
            BindableCollectionSubset<Level> worldLevels;
            if (_worldLevels.TryGetValue(worldId, out worldLevels))
                return worldLevels;

            worldLevels = new BindableCollectionSubset<Level>(this, x => x.WorldId == worldId, x => x.WorldId = worldId);
            _worldLevels.Add(worldId, worldLevels);
            return worldLevels;
        }

        #endregion
    }

    public static partial class Models
    {
        public static LevelData Levels = new LevelData();
    }

    #endregion
}
