using MediatR;
using NuGet.Protocol.Plugins;
using Reetu_School.Common;
using Reetu_School.Models;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.CommonHandler
{
    public class CommonHandler:
        IRequestHandler<UploadingData ,object>,
        IRequestHandler<GetUploadingData, object>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommonHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        } 
        public async Task<object>Handle(UploadingData request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    Name = request.Name,
                    About = request.About,
                    Marks = request.Marks,
                    Subject = request.Subject,
                    Description = request.Description,
                    ImageFile = request.ImageFile
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_UploadingData", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_UploadingData");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object>Handle(GetUploadingData request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id 
                };
                data = await DataLayer.QueryAsync("Proc_GetUploadingData", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_GetUploadingData");
                data = ResponseResult.ExceptionResponse("Internal Server Error");
            }
            return data;
        }
    }
}
