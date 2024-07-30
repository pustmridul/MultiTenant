using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Com.Login.Models
{
    public class LoginModel
    {
    }
    public record LoginResponse 
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; }= string.Empty;

    }
}
