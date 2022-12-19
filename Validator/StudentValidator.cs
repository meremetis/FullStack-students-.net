using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class StudentValidator
    {
        //utility class 

        //No instances of this class should be available
        private StudentValidator() { }

        public static string Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length < 4) || (dto!.Lastname!.Length < 4))
            {
                return "firstname or lastname should not be less than 3 chars";
            }
            else 
            {
                return "";
            }
           
        }



    }
}
