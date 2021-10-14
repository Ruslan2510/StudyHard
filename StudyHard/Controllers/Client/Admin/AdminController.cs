using Microsoft.AspNetCore.Mvc;
using StudyHard.Services.Admin;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.Admin
{
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        public readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("migratedb")]
        public void MigrateDatabase()
        {
            _adminService.MigrateDatabase(CancellationToken.None);
        }
    }
}
