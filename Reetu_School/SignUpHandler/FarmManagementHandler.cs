using MediatR;
using Reetu_School.Common;
using Reetu_School.Models;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.SignUpHandler
{
    public class FarmManagementHandler:
        IRequestHandler<SaveMemberDetailss, object>,
        IRequestHandler<GetMemberDetails,object>,
        IRequestHandler<DeleteMember,object>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _createdIP;
        public FarmManagementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _createdIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        public async Task<object> Handle(SaveMemberDetailss request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    FFirstName = request.FFirstName,
                    FMiddleName = request.FMiddleName,
                    FLastName = request.FLastName,
                    Land = request.Land,
                    UOM = request.UOM,
                    Gender = request.Gender,
                    Qualification = request.Qualification,
                    Dob = request.Dob,
                    MobileNo = request.MobileNo,
                    Email = request.Email,
                    Adhar = request.Adhar,
                    Address = request.Address,
                    PermanantAddress = request.PermanantAddress,
                    Pincode = request.Pincode,
                    CreatedIP = _createdIP
                };
             data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_SaveMemberDetails", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_SaveMemberDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetMemberDetails request,CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_GetMemberList", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Proc_GetMemberList");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteMember request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("Proc_DeleteMember", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "DeleteMember");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
    }
}
