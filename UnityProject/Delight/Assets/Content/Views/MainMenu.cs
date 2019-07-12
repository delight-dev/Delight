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
        public void Play(PointerEventData pointerData)
        {
            Debug.Log("Play clicked");
        }

        public void Options(PointerEventData pointerData)
        {
            Debug.Log("Options clicked");
        }

        public void Quit(PointerEventData pointerData)
        {
            Debug.Log("Quit clicked");
        }

        public void QuitMouseDown(PointerEventData pointerData)
        {
        }

    }
}
