using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using startModel.Data;
using startModel.Migrations.AppDb;
using startModel.Models;

namespace startModel.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentsController(AppDbContext appDbContext)
        {
             _appDbContext=appDbContext;
        }
        public IActionResult DepartmentSection()
        {
             IEnumerable< Department > departmentList = _appDbContext.departments.ToList();

            return View(departmentList);
        }
    }
}
