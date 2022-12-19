using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();

        //ftiaxnw service
        private readonly IStudentService service;

       


        //kalw connstructor kai kanw injection sto service to dao
        public CreateModel()
        {
            service = new StudentServiceImple(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";



        public void OnPost()
        {
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDTO);

            if(!errorMessage.Equals("")) return;
            try
            {
                service.InsertStudent(studentDTO);
                Response.Redirect("/Students/index");
            }
            catch (Exception e) 
            {
                errorMessage = e.Message;
                return;

            }
        }

        public void OnGet()
        {

        }
    }
}
