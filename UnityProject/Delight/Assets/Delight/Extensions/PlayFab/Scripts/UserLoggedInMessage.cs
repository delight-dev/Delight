#region Using Statements
using System;
#endregion

namespace Delight
{
    public class UserLoggedInMessage
    {
        public static UserLoggedInMessage Default = new UserLoggedInMessage();

        public bool LoggedInWithCustomID { get; set; }
    }
}

