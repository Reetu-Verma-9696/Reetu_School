using MediatR;
using Reetu_School.Common;
using Reetu_School.Models;
using System.Dynamic;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.SignUpHandler
{
    public class SignupHandler :
        IRequestHandler<SignUp, object>,
        IRequestHandler<Login, object>,
        IRequestHandler<GetSignUpDetail, object>,
        IRequestHandler<DeleteCommand, object>,
        IRequestHandler<BindMasterGroupDetails, Object>,
        IRequestHandler<SaveGroupDetails, object>,
        IRequestHandler<AssignDashboard, IEnumerable<AssignDashboardDetails>>,
        IRequestHandler<SaveEmpData, object>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SignupHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<object> Handle(SignUp request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                    StudentName = request.StudentName,
                    MotherName = request.MotherName,
                    FatherName = request.FatherName,
                    Email = request.Email,
                    DOB = request.DOB,
                    MobileNumber = request.MobileNumber,
                    Courses = request.Courses,
                    Password = request.Password,
                    ConfirmPassword = request.ConfirmPassword,
                };

                // Assuming the stored procedure 'SignUp_Insert' handles the insert and returns a result indicating success
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("SignUp", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SignUp");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(Login request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    UserName = request.UserName,
                    Password = request.Password,
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_Login", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Login");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(GetSignUpDetail request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                };
                data = await DataLayer.QueryAsync("Proc_GetSignUpDetail", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetSignUpDetail");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id,
                };
                data = await DataLayer.QueryAsync("Proc_DelSignUpDetail", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "DeleteCommand");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(BindMasterGroupDetails request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryAsync("BindBloodGroup", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "BindMasterGroupDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object> Handle(SaveGroupDetails request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                   // Id = request.Id,
                    Name = request.Name,
                    Email =request.Email,
                    ContactNo = request.ContactNo,
                    BloodGroup = request.BloodGroup
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("SaveGroupDetails", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SaveGroupDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;

        }
        public async Task<IEnumerable<AssignDashboardDetails>> Handle(AssignDashboard request, CancellationToken cancellationToken)
        {
            var response = await DataLayer.QueryAsync<AssignDashboardDetails>("Proc_AssignDashboard", null);
            return response;
            
        }
        public async Task<object> Handle(SaveEmpData request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    request.Id,
                    FName = request.FName,
                    LName = request.LName,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Adhar = request.Adhar,
                    Dob = request.Dob,
                    State = request.State,
                    City = request.City,
                    PinCode = request.PinCode,
                    Qualification = request.Qualification,
                    Gender = request.Gender,
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("SaveEmpData", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "SaveEmpData");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }

    }
}


