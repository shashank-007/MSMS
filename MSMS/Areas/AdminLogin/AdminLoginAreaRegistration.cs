using System.Web.Mvc;

namespace MSMS.Areas.AdminLogin
{
    public class AdminLoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminLogin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminLogin_default1",
                "AdminLogin/{controller}/{action}/{id}",
                new { controller = "OperationsAdmin", action = "OADashboard", id = UrlParameter.Optional }
            );



            context.MapRoute(
                "AdminLogin_default",
                "AdminLogin/{controller}/{action}/{id}",
                new { controller= "AdminLogin", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}