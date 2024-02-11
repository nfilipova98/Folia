namespace Plants.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
    }
}
