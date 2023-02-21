using System.Text.Json.Serialization;

namespace Web.Shared
{
    public class Response<T>
    {
        //Entity
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool Successfull { get; set; }
        public int TotalCount { get; set; }
        public List<string> Errors { get; set; }
        public static Response<T> Success(T data, int statusCode, int Count)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, TotalCount = Count, Successfull = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, Successfull = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, Successfull = false };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string>() { error }, StatusCode = statusCode, Successfull = false };
        }
    }
}
