using Dapper;
using System.Data;

namespace Reetu_School.Common
{
    public class DataLayer
    {
        public static class ResponseResult
        {
            public static object SuccessResponse(object ResponseMessage)
            {
                var result = new { responseCode = 200, responseMessage = ResponseMessage };
                return result;
            }

            public static object SuccessResponse(object ResponseMessage, object ResponseResult)
            {
                var result = new { responseCode = 200, responseMessage = ResponseMessage, responseResult = ResponseResult };
                return result;
            }

            public static object FailedResponse(object ResponseMessage)
            {
                var result = new { responseCode = 0, responseMessage = ResponseMessage };
                return result;
            }

            public static object FailedResponse(object ResponseMessage, object ResponseResult)
            {
                var result = new { responseCode = 0, responseMessage = ResponseMessage, responseResult = ResponseResult };
                return result;
            }

            public static object ExceptionResponse(object ResponseMessage)
            {
                var result = new { responseCode = 500, responseMessage = ResponseMessage };
                return result;
            }

            public static object ExceptionResponse(object ResponseMessage, object ResponseResult)
            {
                var result = new { responseCode = 500, responseMessage = ResponseMessage, responseResult = ResponseResult };
                return result;
            }
        }
        public static async Task<object> QueryFirstOrDefault(string procedureName, object parameters)
        {
            dynamic Result = null;
            using (IDbConnection db = ORMConnection.GetConnection())
            {
                try
                {
                    db.Open();
                    Result = db.QueryFirstOrDefault<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    Result = ResponseResult.SuccessResponse("Success", Result);
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
        }
        public static async Task<object> QueryAsync(string procedureName, object parameters)
        {
            dynamic Result = null;
            using (IDbConnection db = ORMConnection.GetConnection())
            {
                try
                {
                    db.Open();
                    Result = await db.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    Result = ResponseResult.SuccessResponse("Success", Result);
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
        }
        public static async Task<object> QueryFirstOrDefaultAsync(string procedureName, object parameters)
        {
            dynamic Result = null;
            using (IDbConnection db = ORMConnection.GetConnection())
            {
                try
                {
                    db.Open();
                    Result = await db.QueryFirstOrDefaultAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    Result = ResponseResult.SuccessResponse("Success", Result);
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
        }

        public static async Task<object> QueryFirstOrDefaultAsyncWithDBResponse(string procedureName, object parameters)
        {
            dynamic Result = null;
            using (IDbConnection db = ORMConnection.GetConnection())
            {
                try
                {
                    db.Open();
                    Result = await db.QueryFirstOrDefaultAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 600);
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
        }
        
    }
}
   