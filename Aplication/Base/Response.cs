using System;
using System.Net;
using Domain.Common;

namespace Aplication
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public string DetailTransaction { get; set; }
        public HttpStatusCode Code { get; set; }
    }
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }
        public static Response<T> CreateResponseSuccess(T data, HttpStatusCode code, string message) => new Response<T>
        {
            Code = code,
            Data = data,
            Error = false,
            Message = message,
            DetailTransaction = $"Transacción exitosa sobre {GetNameClass(data)}"
        };
        public static Response<T> CreateResponseError(string nameClass, string method, HttpStatusCode code, string message) => new Response<T>
        {
            Code = code,
            Error = true,
            Message = message,
            DetailTransaction = $"Fallo en {nameClass} en el metodo : '{method}'"
        };
        public static Response<T> CreateResponseError(Exception e, string nameClass, string method, HttpStatusCode code, string message) => new Response<T>
        {
            Code = code,
            Error = true,
            Message = message,
            DetailTransaction = $"Excepción en {nameClass}, metodo '{method}', {GetLineError(e)}, Error: {e.Message}"
        };
        private static string GetNameClass(T data) => CallerMember.GetClassName(data);
        private static string GetLineError(dynamic e) => ErrorLine.GetNumber(e);
    }
}
