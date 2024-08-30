using MediatR;

namespace Reetu_School.Models
{
    public class SignUp:IRequest<object>
    {
       
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string MobileNumber { get; set; }
        public string Courses { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
    public class Login : IRequest<object>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class GetSignUpDetail : IRequest<object>
    {
        public int Id { get; set; }
    }
}
