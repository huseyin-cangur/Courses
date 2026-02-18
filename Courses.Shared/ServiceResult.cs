

using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Refit;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;



namespace Courses.Shared
{

    public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestByServiceResult : IRequest<ServiceResult>;

    public class ServiceResult
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
        public ProblemDetails? Fail { get; set; }
        [JsonIgnore]
        public bool IsSuccess => Fail is null;
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NoContent
            };
        }

        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found."
                }
            };
        }

        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {
            if (exception.Content is null)
            {
                return new ServiceResult
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message

                    }
                };
            }

            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return new ServiceResult
            {
                Status = exception.StatusCode,
                Fail = problemDetails
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = problemDetails
            };
        }

        public static ServiceResult Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Detail = description,
                    Status = (int)statusCode
                }
            };
        }

        public static ServiceResult Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Status = statusCode,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Status = (int)statusCode
                }
            };
        }


        public static ServiceResult ErrorFromValidation(IDictionary<string, object>? errors)
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails
                {
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Extensions = errors,
                    Status = (int)HttpStatusCode.BadRequest

                }
            };
        }

    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        [JsonIgnore]
        public string? UrlAsCreated { get; set; }

        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data
            };
        }

        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.Created,
                Data = data,
                UrlAsCreated = urlAsCreated
            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {
            if (exception.Content is null)
            {
                return new ServiceResult<T>
                {
                    Status = exception.StatusCode,
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message

                    }
                };
            }

            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return new ServiceResult<T>
            {
                Status = exception.StatusCode,
                Fail = problemDetails
            };
        }

        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = problemDetails
            };
        }

        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Detail = description,
                    Status = (int)statusCode
                }
            };
        }

        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Status = statusCode,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Status = (int)statusCode
                }
            };
        }


        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object>? errors)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails
                {
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Extensions = errors,
                    Status = (int)HttpStatusCode.BadRequest

                }
            };
        }
    }
}