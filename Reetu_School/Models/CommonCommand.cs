using MediatR;

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
}
