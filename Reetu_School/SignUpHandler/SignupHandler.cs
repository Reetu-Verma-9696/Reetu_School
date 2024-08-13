using MediatR;
using Reetu_School.Common;
using Reetu_School.Models;
using System.Dynamic;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.SignUpHandler
{
    public class SignupHandler : 
        IRequestHandler<SignUp, object>,
        IRequestHandler<Login,object>
        //IRequestHandler<GetSignUpDetail,object>
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
        public async Task<object>Handle(Login request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    UserName = request.UserName,
                    Password=request.Password,
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_Login", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex.Message, "Login");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        //public async Task<object> Handle(GetSignUpDetail request,CancellationToken cancellationToken)
        //{

        //}
    }
}

    