using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        //ftiaxnw dao
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();

        //ftiaxnw service
        private readonly IStudentService? service;

        internal List<Student> students = new ();


        //kalw connstructor kai kanw injection sto service to dao
        public IndexModel() 
        {
            service = new StudentServiceImple(studentDAO);
        }

        //adistixei sto http get
        //IActionResult einai h data h selida
        //ean einai void h onget to return iponoite
        //ean epistrefei iactionresult prepei na iparxei to return page
        public IActionResult OnGet()
        {
            students = service!.GetAllStudents();
            return Page();
        }
    }
}
