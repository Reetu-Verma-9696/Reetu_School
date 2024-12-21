using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Reetu_School.Models
{
    public class UploadingData : IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Marks { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
    public class GetUploadingData : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class SaveStudentRegistration : IRequest<object>
    {
        public int Id { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentMiddleName { get; set; }
        public string StudentLastName { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Nationality { get; set; }
        public string PlaceofBirth { get; set; }
        public string PAN { get; set; }
        public string Category { get; set; }
        public string Adhar { get; set; }
        public string MobNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PermaAddress { get; set; }
        public bool IsActive { get; set; }
    }
    public class StudentCommandList : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class DeleteUploadingData : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class SendEnquiry : IRequest<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
    }
    public class UpdateStatusList : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class InsertUserRole : IRequest<object>
    {
        public int Id { get; set; }
        public string UserRole { get; set; }
        public string IsActive { get; set; }
        public string Optionaldata { get; set; }
    }
    public class GetUserRoleDetails : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class DeleteUserRole : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class BindCountry : IRequest<object>
    {
       
    }
    public class InsertCountry : IRequest<object>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
    }
    public class GetCountry : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class InsertState : IRequest<object>
    {
        public int Id { get; set; }
        public string State { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
    public class GetState : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class InsertCity : IRequest<object>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
    }
    public class GetCity : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class DeleteState : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class DeleteCity : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class BindState : IRequest<object>
    {
        public int CountryId { get; set; }
    }
    public class BindCity : IRequest<object>
    {
        public int StateId { get; set; }
    }
    public class AddServices : IRequest<object>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Service Name is required")]
        public string Service { get; set; }

        [Required(ErrorMessage = "Display Name is required")]
        public string DisplayName { get; set; }

        public bool IsActive { get; set; }
    }



    public class GetServiceDetails : IRequest<object>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int SpCode { get; set; }
    }
    public class DeleteService : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class BindCompany : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class AssignService : IRequest<object>
    {
        public int CompanyId { get; set; }
        public int ServiceIds { get; set; }
    }
}
