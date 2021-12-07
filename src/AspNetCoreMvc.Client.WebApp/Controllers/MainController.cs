using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Client.WebApp.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
    }
}
