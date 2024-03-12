namespace Plants.Areas.Administration.Controllers
{
    using Plants.Controllers;

    using Microsoft.AspNetCore.Authorization;

    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class AdminController : BaseController
    {

    }
}
