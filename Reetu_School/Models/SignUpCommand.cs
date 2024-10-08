using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Reetu_School.Models
{
    public class SignUp:IRequest<object>
    {
        public int Id { get; set; }
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
    public class DeleteCommand : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class BindMasterGroupDetails : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class SaveGroupDetails : IRequest<object>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string BloodGroup { get; set; }
    }
    public class AssignDashboard : IRequest<IEnumerable<AssignDashboardDetails>>
    {
        
    }
    public class AssignDashboardDetails
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
    public class SaveEmpData : IRequest<object>
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public int Adhar { get; set; }
        public string Dob { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Qualification { get; set; }
        public string Gender { get; set; }
    }

}
