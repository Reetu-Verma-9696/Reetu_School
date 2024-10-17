using MediatR;
using NuGet.Protocol.Plugins;
using Reetu_School.Common;
using Reetu_School.Models;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.CommonHandler
{
    public class CommonHandler:
        IRequestHandler<UploadingData ,object>,
        IRequestHandler<GetUploadingData, object>,
        IRequestHandler<SaveStudentRegistration, object>,
        IRequestHandler<StudentCommandList, object>,
        IRequestHandler<DeleteUploadingData, object>,
         IRequestHandler<SendEnquiry, object>,
        IRequestHandler<UpdateStatusList,object>
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
        public async Task<object> Handle(SaveStudentRegistration request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    StudentFirstName = request.StudentFirstName,
                    StudentMiddleName = request.StudentMiddleName,
                    StudentLastName = request.StudentLastName,
                    FatherFirstName = request.FatherFirstName,
                    FatherMiddleName = request.FatherMiddleName,
                    FatherLastName = request.FatherLastName,
                    Gender = request.Gender,
                    DOB = request.DOB,
                    Nationality = request.Nationality,
                    PlaceofBirth = request.PlaceofBirth,
                    PAN = request.PAN,
                    Category = request.Category,
                    Adhar = request.Adhar,
                    MobNumber = request.MobNumber,
                    Email = request.Email,
                    Address = request.Address,
                    PermaAddress = request.PermaAddress,
                    IsActive = request.IsActive

                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_SaveStudentRegistration", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SaveStudentRegistration");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(StudentCommandList request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_StudentList", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "StudentCommandList");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object>Handle(DeleteUploadingData request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryFirstOrDefaultAsync("Proc_DeleteUploadingData", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex.Message, "DeleteUploadingData");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(SendEnquiry request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Message = request.Message,

                };
                data = await DataLayer.QueryFirstOrDefaultAsync("Proc_SendEnquiry", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SendEnquiry");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(UpdateStatusList request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryFirstOrDefaultAsync("Proc_UpdateStatusList", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SendEnquiry");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
    }
}
