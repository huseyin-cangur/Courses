
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Courses.Shared.Extensions
{
    public static class EndpointResultExt
    {
        public static IResult ToResult<T>(this ServiceResult<T> serviceResult)
        {
            return serviceResult.Status switch
            {
                HttpStatusCode.OK => Results.Ok(serviceResult.Data),
                HttpStatusCode.Created => Results.Created(serviceResult.UrlAsCreated, serviceResult.Data),
                HttpStatusCode.NotFound => Results.NotFound(serviceResult.Fail),
                _ => Results.Problem(serviceResult.Fail)

            };
        }

          public static IResult ToResult(this ServiceResult serviceResult)
        {
            return serviceResult.Status switch
            {
                 
                HttpStatusCode.NotFound => Results.NotFound(serviceResult.Fail),
                HttpStatusCode.NoContent => Results.NoContent(),
                _ => Results.Problem(serviceResult.Fail)

            };
        }
    }
}