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
            AdminUserContext db = new AdminUserContext();
            List<AdminUser> adminUsers = db.AdminUsers.ToList();
            return Ok(adminUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AdminUserContext db = new AdminUserContext();
            AdminUser adminUser = db.AdminUsers.FirstOrDefault(x => x.Id == id);

            if (adminUser == null)
            {
                return NotFound("Böyle bir kullanıcı bulunamadı.");
            }
            return Ok(adminUser);
        }

        [HttpPost]
        public IActionResult Post(AdminUser adminUser)
        {
            AdminUserContext db = new AdminUserContext();
            db.AdminUsers.Add(adminUser);
            db.SaveChanges();

            return Ok("Ekleme islemi basarili.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdminUserContext db = new AdminUserContext();
            AdminUser adminUser = db.AdminUsers.Find(id);

            if (adminUser==null)
            {
                return NotFound("Böyle bir kullanıcı bulunamadı.");
            }

            db.AdminUsers.Remove(adminUser);
            db.SaveChanges();
            return Ok("İşlem başarılı");
        }

        [HttpPut]
        public IActionResult Put(AdminUser adminUser)
        {
            AdminUserContext db = new AdminUserContext();
            AdminUser entity = db.AdminUsers.FirstOrDefault(x=> x.Id== adminUser.Id);

            entity.UserName=adminUser.UserName;
            entity.Surname=adminUser.Surname;
            entity.Email = adminUser.Email;
            entity.Phone=adminUser.Phone;
            entity.AddDate= adminUser.AddDate;
            entity.IsDeleted=adminUser.IsDeleted;

            db.SaveChanges();

            return Ok("Guncelleme islemi basarili.");


        }

    }
}
