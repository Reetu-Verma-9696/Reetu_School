using Dapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Reetu_School.Common;
using Reetu_School.Models;
using System.Data;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Claims;
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
        IRequestHandler<SaveEmpData, object>,
        IRequestHandler<RegistrationCommand, object>,
        IRequestHandler<DeleteSignUpRecord, object>
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
            var Result = (dynamic)null;
            using (IDbConnection db = ORMConnection.GetConnection())
            {
                try
                {
                    if (string.IsNullOrEmpty(request.Email))
                    {
                        Result = ResponseResult.FailedResponse("Email is required.");
                    }
                    else if (string.IsNullOrEmpty(request.Password))
                    {
                        Result = ResponseResult.FailedResponse("Password is required.");
                    }
                    else
                    {
                        var param = new
                        {
                            Email = request.Email,
                            Password = request.Password
                        };
                        db.Open();
                        Result = await db.QueryFirstOrDefaultAsync<object>("[Proc_Login]", param, commandType: CommandType.StoredProcedure);
                        if (Convert.ToInt32(Result.responseCode) == 200)
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim("CustomerId", Convert.ToString(Result.CustomerId)));
                            claims.Add(new Claim("UserRoleId", Convert.ToString(Result.UserRoleId)));
                            claims.Add(new Claim("LoginId", Convert.ToString(Result.Id)));
                            claims.Add(new Claim(ClaimTypes.Email, Convert.ToString(Result.Email)));
                            claims.Add(new Claim(ClaimTypes.MobilePhone, Convert.ToString(Result.Mobile)));
                            claims.Add(new Claim(ClaimTypes.Role, Convert.ToString(Result.UserRoleName)));
                            claims.Add(new Claim(ClaimTypes.GivenName, Convert.ToString(Result.Name)));


                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Result = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message.ToString());
                }
                finally
                {
                    db.Close();
                }
            }
            return Result;
            //var data = (dynamic)null;
            //using (IDbConnection db = ORMConnection.GetConnection())
            //{
            //    try
            //    {
            //        if (string.IsNullOrEmpty(request.UserName))
            //        {
            //            return DataLayer.ResponseResult.FailedResponse("UserName is Required");
            //        }
            //        if (string.IsNullOrEmpty(request.Password))
            //        {
            //            return DataLayer.ResponseResult.FailedResponse("Password is Required");
            //        }
            //        var param = new
            //        {
            //            UserName = request.UserName,
            //            Password = request.Password,
            //        };
            //        db.Open();
            //    data = await db.QueryFirstOrDefaultAsync<object>("Proc_Login", param, commandType: CommandType.StoredProcedure);
            //        data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_Login", param);
            //        if (Convert.ToInt32(data.responseCode) == 200)
            //        {
            //            List<Claim> claims = new List<Claim>();
            //            claims.Add(new Claim(ClaimTypes.Name, Convert.ToString(data.UserRoleCode)));
            //            claims.Add(new Claim("StateName", Convert.ToString(data.StateName)));
            //            claims.Add(new Claim("WebsiteId", Convert.ToString(data.WebsiteId)));
            //            claims.Add(new Claim("CustomerId", Convert.ToString(data.CustomerId)));
            //            claims.Add(new Claim("UserRoleId", Convert.ToString(data.UserRoleId)));
            //            claims.Add(new Claim("LoginId", Convert.ToString(data.Id)));
            //            claims.Add(new Claim(ClaimTypes.Email, Convert.ToString(data.Email)));
            //            claims.Add(new Claim(ClaimTypes.MobilePhone, Convert.ToString(data.Mobile)));
            //            claims.Add(new Claim(ClaimTypes.Role, Convert.ToString(data.UserRoleName)));
            //            claims.Add(new Claim(ClaimTypes.GivenName, Convert.ToString(data.Name)));

            //            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            //            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            //            return DataLayer.ResponseResult.SuccessResponse("Login Successfully", data);
            //        }
            //        else
            //        {
            //            return DataLayer.ResponseResult.FailedResponse("Invalid UserName or Password");
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        Serilog.Log.Error(ex, "Error occurred during Sign-up");
            //        return ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            //    }
            //    finally
            //    {
            //        db.Close();
            //        GC.SuppressFinalize(this);
            //    }
            //}
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
        public async Task<object> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var Identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
                var param = new
                {
                    Id = request.Id,
                    UserName = request.UserName,
                    Email = request.Email,
                    MobileNo = request.MobileNo,
                    Password = request.Password,
                    CountryId = request.CountryId,
                    StateId = request.StateId,
                    CityId = request.CityId,
                    CreatedIP = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                data = await DataLayer.QueryFirstOrDefaultAsyncWithDBResponse("Proc_RegistrationCommand", param);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, "RegistrationCommand");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
        public async Task<object>Handle(DeleteSignUpRecord request, CancellationToken cancellationToken)
        {
            var data = (dynamic)null;
            try
            {
                var param = new
                {
                    Id = request.Id
                };
                data = await DataLayer.QueryFirstOrDefault("Proc_DeleteSignUpRecord", param);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error("DeleteSignUpRecord", ex.Message);
                data = ResponseResult.ExceptionResponse("Internal Server Error",ex.Message);
            }
            return data;
        }

    }
}


