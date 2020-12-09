#region Using Statements
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Title represents the title (game) view model.
    /// </summary>
    public partial class PlayFabTitle : ModelObject
    {
        #region Properties

        public string TitleId
        {
            get { return PlayFabSettings.TitleId; }
            set { PlayFabSettings.TitleId = value; }
        }

        [SerializeField]
        private Dictionary<string, string> _data;
        public Dictionary<string, string> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads title data.
        /// </summary>
        public async Task<bool> LoadTitleData(List<string> keys = null)
        {
#if DELIGHT_MODULE_PLAYFAB
            var result = await PlayFabServices.GetTitleData(keys);

            if (!result.Success)
                return false;

            var titleData = result.Result.Data;
            Data = titleData;
            return true;
#else
            await Task.FromResult(0); // just to prevent compiler warning
            return false;
#endif
        }

        #endregion
    }

    #region Data Provider

    public partial class PlayFabTitleData : DataProvider<PlayFabUser>
    {
        #region Methods
        #endregion
    }

    public static partial class Models
    {
        public static PlayFabTitle PlayFabTitle = new PlayFabTitle();
    }

    #endregion
}

