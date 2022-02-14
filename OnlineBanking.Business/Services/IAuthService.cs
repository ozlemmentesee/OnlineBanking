using OnlineBanking.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Business
{
    public interface IAuthService
    {
        string GetToken(UserRequest request);
    }
}
