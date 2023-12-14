using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPlatform.Domain.Entities.SP
{
    public class SP
    {
        public const string Sp_UpdatePasswordAndPasswordTokenValidity = "dbo.Sp_UpdatePasswordAndPasswordTokenValidity @password, @salt, @userId,  @isValid, @changePasswordId";
    }
}
