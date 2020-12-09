#if DELIGHT_MODULE_PLAYFAB

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PlayFab;
using PlayFab.ClientModels;
using System.Threading.Tasks;
#endregion

namespace Delight
{
    public partial class PlayFabLogin
    {
        #region Methods

        protected override void AfterLoad()
        {
            base.AfterLoad();
            if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            {
                PlayFabSettings.TitleId = "E5CB4";
            }
        }

        public async Task LogIn()
        {
            await Models.PlayFabUser.LogIn(Email, Password);

            if (Models.PlayFabUser.IsLoggedIn)
            {
                // load another user into the player profiles list
                await Models.PlayFabPlayerProfiles.GetAsync("14BB555B023A433A");
            }
        }

        public void LogOut()
        {
            Models.PlayFabUser.LogOut();
        }

        #endregion
    }
}

#endif