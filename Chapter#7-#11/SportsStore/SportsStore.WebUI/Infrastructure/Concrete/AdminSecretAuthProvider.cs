using System.Web.Security;
using SportsStore.WebUI.Infrastructure.Abstract;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class AdminSecretAuthProvider: IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            var result = (userName == "admin" && password == "secret");
            if (result)
                FormsAuthentication.SetAuthCookie(userName, false);
            return result;
        }
    }
}