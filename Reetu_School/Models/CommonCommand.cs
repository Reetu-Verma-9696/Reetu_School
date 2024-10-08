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
}
