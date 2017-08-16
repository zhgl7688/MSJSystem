using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.IBLL
{
   public interface InterfaceUserService
    {
        ClaimsIdentity CreateIdentity(User user, string authenticationType);
    }
}
