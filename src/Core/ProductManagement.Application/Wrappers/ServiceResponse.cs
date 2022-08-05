using ProductManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductManagement.Application.Wrappers
{
    public class ServiceResponse<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccesful { get; private set; }
        public ErrorDto Error { get; private set; }


        public static ServiceResponse<T> Success(T data, int statusCode)
        {
            return new ServiceResponse<T> { Data = data, StatusCode = statusCode, IsSuccesful = true };
        }

        public static ServiceResponse<T> Success(int statusCode)
        {
            return new ServiceResponse<T> { Data = default, StatusCode = statusCode, IsSuccesful = true };
        }

        public static ServiceResponse<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ServiceResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccesful = false };
        }

        public static ServiceResponse<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new ServiceResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccesful = false };
        }
    }
}
