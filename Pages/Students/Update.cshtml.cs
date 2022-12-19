using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Students
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();

        //ftiaxnw service
        private readonly IStudentService service;




        //kalw connstructor kai kanw injection sto service to dao
        public UpdateModel()
        {
            service = new StudentServiceImple(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);

                if (student != null)
                {
                    studentDTO = ConvertToDto(student);
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }   
        }

        public void OnPost() 
        {
            errorMessage = "";

            //get dto apo form
            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            //validate
            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals(""))
            {
                return;
            }

            try
            {
                service.UpdateStudent(studentDTO);
                Response.Redirect("/Students/index");
            }
            catch (Exception e) 
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentDTO ConvertToDto(Student student) 
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
