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
    /// User represents the PlayFab registration form view model.
    /// </summary>
    public partial class PlayFabRegistrationForm : ModelObject
    {
        #region Properties

        [SerializeField]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        [SerializeField]
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        [SerializeField]
        private bool _isRegistering;
        public bool IsRegistering
        {
            get { return _isRegistering; }
            set { SetProperty(ref _isRegistering, value); }
        }

        [SerializeField]
        private bool _showRegistrationMessage;
        public bool ShowRegistrationMessage
        {
            get { return _showRegistrationMessage; }
            set { SetProperty(ref _showRegistrationMessage, value); }
        }

        [SerializeField]
        private string _registrationMessage;
        public string RegistrationMessage
        {
            get { return _registrationMessage; }
            set { SetProperty(ref _registrationMessage, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the user.
        /// </summary>
        public async Task Register()
        {
#if DELIGHT_MODULE_PLAYFAB
            await Register(Email, Password);
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        public async Task Register(string email, string password)
        {
#if DELIGHT_MODULE_PLAYFAB
            IsRegistering = true;
            ShowRegistrationMessage = false;

            // register user
            var result = await PlayFabServices.RegisterWithEmailAddress(email, password);

            IsRegistering = false;
            if (result.Success)
            {
                ClearForm();
                RegistrationMessage = String.Format("Registration successful. PlayerId: " + result.Result.PlayFabId);
                ShowRegistrationMessage = true;
            }
            else
            {
                RegistrationMessage = result.Error.ErrorMessage;
                ShowRegistrationMessage = true;
            }
#else
            await Task.FromResult(0); // just to prevent compiler warning
#endif
        }

        /// <summary>
        /// Clear form.
        /// </summary>
        public void ClearForm()
        {
            ShowRegistrationMessage = false;
            RegistrationMessage = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        #endregion
    }

    public static partial class Models
    {
        public static PlayFabRegistrationForm PlayFabRegistrationForm = new PlayFabRegistrationForm();
    }
}

