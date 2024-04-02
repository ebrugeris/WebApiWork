using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWork.Models;

namespace WebApiWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            AdminUserContext db= new AdminUserContext();
            List<AdminUser> adminUsers= db.AdminUsers.ToList();
            return Ok(adminUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AdminUserContext db= new AdminUserContext();
            AdminUser adminUser= db.AdminUsers.FirstOrDefault(x=> x.Id == id );

            if (adminUser==null)
            {
                return NotFound("Böyle bir kullanıcı mevcut değil.");
            }
            return Ok(adminUser);
        }
    }
}
