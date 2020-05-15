#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    public partial class HighscoreTest
    {
        public void LoadHighscores(PointerEventData pointerData)
        {
            //Models.Load();
        }

        public void SaveHighscores(PointerEventData pointerData)
        {
            //Models.Save();
        }

        public void Clear()
        {
            //Models.Clear();
        }

        public void Add()
        {
            int scoreInt = int.Parse(Score);
            Models.Highscores.Add(new Highscore { PlayerId = PlayerId, Score = scoreInt });
        }

        public void Remove()
        {
            // remove selected item
            if (SelectedHighscore != null)
                Models.Highscores.Remove(SelectedHighscore);
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();
        }
    }
}
