using System.Web.Mvc;

namespace MSMS.Areas.OwnerProfile
{
    public class OwnerProfileAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OwnerProfile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OwnerProfile_default",
                "OwnerProfile/{controller}/{action}/{id}",
                new { controller = "Profile", action = "Dashboard", id = UrlParameter.Optional }
            );
        }
    }
}