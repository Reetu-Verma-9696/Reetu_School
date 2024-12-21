using MediatR;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Plugins;
using Reetu_School.Common;
using Reetu_School.Models;
using static Dapper.SqlMapper;
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
        IRequestHandler<UpdateStatusList,object>,
        IRequestHandler<InsertUserRole, object>,
        IRequestHandler<GetUserRoleDetails,object>,
        IRequestHandler<DeleteUserRole, object>,
        IRequestHandler<BindCountry,object>,
        IRequestHandler<InsertCountry,object>,
        IRequestHandler<GetCountry,object>,
        IRequestHandler<InsertState,object>,
        IRequestHandler<GetState,object>,
        IRequestHandler<InsertCity, object>,
        IRequestHandler<GetCity, object>,
        IRequestHandler<DeleteState,object>,
        IRequestHandler<DeleteCity,object>,
        IRequestHandler<BindState,object>,
        IRequestHandler<BindCity, object>,
        IRequestHandler<AddServices,object>,
        IRequestHandler<GetServiceDetails, object>,
        IRequestHandler<DeleteService,object>,
        IRequestHandler<BindCompany,object>,
        IRequestHandler<AssignService,object>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly string _createdBy;
        private readonly string _createdIP;

        public CommonHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            //_createdBy = Identity.FindFirst(ClaimsTypes.NameIdentifier).Value.ToString();
            _createdIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

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
        public async Task<object> Handle(InsertUserRole request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    UserRole = request.UserRole,
                    IsActive = request.IsActive,
                    Optionaldata = request.Optionaldata,
                    //createdby = Identity.FindFirst(ClaimsTypes.NameIdentifier).value.ToString(),
                    CreatedIP = _createdIP
                };
                data = await DataLayer.QueryFirstOrDefaultAsync("Proc_InsertUserRole", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "InsertUserRole");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetUserRoleDetails request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_GetUserRoleDetails", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetUserRoleDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteUserRole request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_DeleteUserRole", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetUserRoleDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(BindCountry request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    SpCode = 0
                };
                data = await DataLayer.QueryAsync("Proc_BindMasterCountryStateCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_BindMasterCountryStateCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(InsertCountry request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    Country = request.Country,
                    CountryId = request.CountryId
                };
                data = await DataLayer.QueryAsync("Proc_InsertCountry", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "InsertCountry");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetCountry request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_GetCountry", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetCountry");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(InsertState request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    State = request.State,
                    StateId = request.StateId,
                    CountryId = request.CountryId
                };
                data = await DataLayer.QueryAsync("Proc_InsertState", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "InsertState");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetState request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_GetState", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetState");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(InsertCity request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    City = request.City,
                    CityId = request.CityId,
                    StateId = request.StateId
                };
                data = await DataLayer.QueryAsync("Proc_InsertCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "InsertCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetCity request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_GetCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteState request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_DeleteState", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "DeleteState");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteCity request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_DeleteCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "DeleteCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(BindState request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    SpCode = 1,
                    CountryId = request.CountryId
                };
                data = await DataLayer.QueryAsync("Proc_BindMasterCountryStateCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_BindMasterCountryStateCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(BindCity request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    SpCode = 2,
                    StateId = request.StateId
                };
                data = await DataLayer.QueryAsync("Proc_BindMasterCountryStateCity", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_BindMasterCountryStateCity");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(AddServices request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    Service = request.Service,
                    IsActive = request.IsActive,
                    DisplayName = request.DisplayName,
                    CreatedIP = _createdIP
                };
                data = await DataLayer.QueryFirstOrDefaultAsync("Proc_AddServices", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "AddServices");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetServiceDetails request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    IsActive = request.IsActive,
                    SpCode = request.SpCode
                };
                data = await DataLayer.QueryAsync("Proc_GetServiceDetails", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "GetServiceDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteService request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_DeleteService", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "DeleteService");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(BindCompany request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_BindCompany", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "BindCompany");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(AssignService request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    CompanyId = request.CompanyId,
                    ServiceIds = request.ServiceIds
                };
                data = await DataLayer.QueryAsync("Proc_AssignService", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "BindCompany");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
    }
}
