#if DELIGHT_MODULE_PLAYFAB

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PlayFab;
using System.Threading.Tasks;
#endregion

namespace Delight
{
    public partial class PlayFabRegister
    {
        protected override void AfterLoad()
        {
            base.AfterLoad();
            if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            {
                PlayFabSettings.TitleId = "A228D";
            }
        }

        public override void Setup(object data)
        {
            base.Setup(data);
            Models.PlayFabRegistrationForm.ClearForm();
        }

        public async Task Register()
        {
            await Models.PlayFabRegistrationForm.Register();
        }
    }
}

#endif