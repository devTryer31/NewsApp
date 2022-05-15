using Microsoft.AspNetCore.Mvc;

namespace News.Identity.Components
{
    public class UserInfo : ViewComponent
    {
        public IViewComponentResult Invoke() =>
            User.Identity.IsAuthenticated
            ? View("LoggedIn") : View();
    }
}
