using AGCanteen.Models;
using AGCanteen.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGCanteen.Services.Business
{
    public class SecurityService
    {

        SecurityDAO daoService = new SecurityDAO();


        public bool Authenticate(UserModel userModel)
        {
            return daoService.FindUserId(userModel);


        }

    }
}