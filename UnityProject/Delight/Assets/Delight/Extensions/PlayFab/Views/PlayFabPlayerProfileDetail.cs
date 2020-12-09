#if DELIGHT_MODULE_PLAYFAB

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
#endregion

namespace Delight
{
    public partial class PlayFabPlayerProfileDetail
    {
        public async Task AddFriend()
        {
            // add specific friend
            await Models.PlayFabUser.AddFriend("291530D1A856E88A");
        }

        public async Task RemoveFriend()
        {
            // remove specific friend
            await Models.PlayFabUser.RemoveFriend("291530D1A856E88A");
        }
    }
}

#endif