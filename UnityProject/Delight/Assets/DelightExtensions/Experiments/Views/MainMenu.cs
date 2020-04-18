#region Using Statements
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainMenu
    {
        public void Play()
        {
            SubmenuSwitcher.SwitchTo(LevelSelect);
        }

        public void ShowOptions()
        {
            SubmenuSwitcher.SwitchTo(Options);
        }

        public void Quit()
        {
            Debug.Log("Quit clicked");
        }
    }
}
