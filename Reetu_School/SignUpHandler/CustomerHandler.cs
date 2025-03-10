using MediatR;
using Reetu_School.Common;
using Reetu_School.Models;
using static Reetu_School.Common.DataLayer;

namespace Reetu_School.SignUpHandler
{
    public class CustomerHandler : IRequestHandler<GetCustomerProfileDetail, object>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<object> Handle(GetCustomerProfileDetail request,CancellationToken cancellationToken)
        {
            var data = (dynamic) null;
            try
            {
                var param = new
                {
                    request.Id
                };
                data = await DataLayer.QueryAsync("Proc_CustomerProfileDetails", param);
            }
            catch (Exception ex) {
                Serilog.Log.Error(ex.Message, "Proc_CustomerProfileDetails");
                data = ResponseResult.ExceptionResponse("Internal Server Error", ex.Message);
            }
            return data;
        }
    }
}
