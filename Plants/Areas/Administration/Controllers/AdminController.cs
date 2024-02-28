using Plants.Controllers;

namespace Plants.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
    }
}
