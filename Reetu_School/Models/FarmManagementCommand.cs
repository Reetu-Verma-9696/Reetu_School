using MediatR;

namespace Reetu_School.Models
{
    public class SaveMemberDetailss : IRequest<object>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FFirstName { get; set; }
        public string FMiddleName { get; set; }
        public string FLastName { get; set; }
        public string Land { get; set; }
        public string UOM { get; set; }
        public int Gender { get; set; }
        public string Qualification { get; set; }
        public string Dob { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Adhar { get; set; }
        public string Address { get; set; }
        public string PermanantAddress { get; set; }
        public string Pincode { get; set; }
    }
    public class GetMemberDetails : IRequest<object>
    {
        public int Id { get; set; }
    }
    public class DeleteMember : IRequest<object>
    {
        public int Id { get; set; }
    }

}
