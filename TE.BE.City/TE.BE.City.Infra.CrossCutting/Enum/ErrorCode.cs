using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TE.BE.City.Infra.CrossCutting.Enum
{
    public enum ErrorCode
    {
        [Description("User/password invalid.")]
        UserNotIdentified = 1000,
    }
}
