using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Academic
{
    public class AcademicAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Academic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Academic_default",
                "Academic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}