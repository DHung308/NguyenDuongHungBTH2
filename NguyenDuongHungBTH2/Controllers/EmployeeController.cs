using NguyenDuongHungBTH2.Models;
using NguyenDuongHungBTH2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenDuongHungBTH2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public EmployeeController(ApplicationDbcontext context)
        {
            _context = context;
        }
        //GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }
        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmpID == id);
        }
        public async Task<IActionResult>Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xls")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath =  Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //Save file to sever
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return View();
        }
    }
}
