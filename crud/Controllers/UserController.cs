using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class UserController : Controller
    {
        private readonly MySQLContext _db;
        public UserController(MySQLContext db)
        {
            _db = db;
        }
        public IActionResult List(string _txtSearch)
        {
            List<TBL_USER> LstUser = new List<TBL_USER>();
            if (!string.IsNullOrEmpty(_txtSearch)) // ช่อง search ไม่เท่ากับ null หรือ ค่าว่าง ให้ where ค้นหาด้วย
            {
                // select * from TBL_USER where FirstName like '%_txtSearch%' or LastName like '%_txtSearh%'
                LstUser = _db.TBL_USER.Where(o => o.FirstName.Contains(_txtSearch) || o.LastName.Contains(_txtSearch)).ToList(); // Contains คือ where like บน sql
            }
            else
            {
                // select * from TBL_USER
                LstUser = _db.TBL_USER.ToList(); 
            }
            return View(LstUser);
        }
        public IActionResult Edit(int UserId)// UserId ส่งมาจาก View ปุ่ม Edit (asp-route-UserId)
        {
            TBL_USER User = new TBL_USER();
            // select * from TBL_USER where UserId = UserId
            User = _db.TBL_USER.FirstOrDefault(o => o.UserId == UserId);
            return View(User);//ส่งข้อมูลที่ View/User/Edit
        }
        public IActionResult Update(TBL_USER _user)
        {
            TBL_USER User = new TBL_USER();
            User = _db.TBL_USER.FirstOrDefault(o => o.UserId == _user.UserId);
            if (User != null)
            {
                //เอาข้อมูลใหม่แทนที่ข้อมูลเดิม
                User.FirstName = _user.FirstName;
                User.LastName = _user.LastName;
                User.IsActive = _user.IsActive;
                _db.SaveChanges();// Save ลง database
            }
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            TBL_USER NewUser = new TBL_USER();
            return View(NewUser);
        }
        public IActionResult Insert(TBL_USER _user)
        {
            _db.TBL_USER.Add(new TBL_USER
            {
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                IsActive = _user.IsActive
            });
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int UserId)
        {
            TBL_USER User = new TBL_USER();
            User = _db.TBL_USER.FirstOrDefault(o => o.UserId == UserId);
            _db.TBL_USER.Remove(User);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
