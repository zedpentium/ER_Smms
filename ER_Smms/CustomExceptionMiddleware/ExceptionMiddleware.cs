using ER_Smms.Models;
using ER_Smms.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ER_Smms.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;


        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //SqlException sqlError;

                _logger.LogError($"Something went wrong: {ex}");
                HandleExceptionAsync(httpContext, ex);
            }
        }


        private void HandleExceptionAsync(HttpContext context, Exception exception) //, SqlException sqlError)
        {
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //await context.Response.WriteAsync(new ErrorHandleInfo()
            //string extraErrorInfo = "";

            //if (sqlError.Message != null)
            //{ extraErrorInfo = sqlError.Message; }
            //else { extraErrorInfo = ""; }

            string max250limit = "";

            if (exception.InnerException != null)
            { 
                max250limit = exception.InnerException.ToString();
                max250limit = max250limit.Substring(startIndex: 0, length: 250);
            }
            else { max250limit = ""; }

            

            ErrorHandleInfo errHandle = new ErrorHandleInfo()
            {
                //StatusCode = context.Response.StatusCode,

                Message = exception.Message + " - " + max250limit // extraErrorInfo //+ " - " + exception.StackTrace // exception.StackTrace
            };

            context.Response.Redirect($"/Frontend/CatchShowError/?message={errHandle}");

        }

    }
}