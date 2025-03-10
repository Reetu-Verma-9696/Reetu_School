using MediatR;

namespace Reetu_School.Models
{
    public class GetCustomerProfileDetail : IRequest<object>
    {
        public int Id { get; set; }
    }
}
