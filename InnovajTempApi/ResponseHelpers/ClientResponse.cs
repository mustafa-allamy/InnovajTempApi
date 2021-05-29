namespace InnovajTempApi.ResponseHelpers
{
    public class ClientResponse<T>
    {
        public ClientResponse()
        {
        }
        public ClientResponse(bool error, string message)
        {
            Error = error;
            Message = message;
        }
        public ClientResponse(bool error, int errorCode, string message)
        {
            Error = error;
            Message = message;
            ErrorCode = errorCode;
        }
        public ClientResponse(T data, int totalCount = 1)
        {
            Error = false;
            Message = null;
            Data = data;
            TotalCount = totalCount;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public int ErrorCode { get; set; }
    }
}