using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();

        //ftiaxnw service
        private readonly IStudentService service;
        internal string errorMessage = "";



        //kalw connstructor kai kanw injection sto service to dao
        public DeleteModel()
        {
            service = new StudentServiceImple(studentDAO);
        }

    


        public void OnGet()
        {
            StudentDTO studentDTO = new();
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                
                studentDTO.Id = id;
                student = service.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
