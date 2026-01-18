using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Authentication
{
    public static class AuthUtil
    {
        public static User.AccessLevel getAccessLevel(this User user)
        {
            return user.accessLevel;
        }
    }
}
