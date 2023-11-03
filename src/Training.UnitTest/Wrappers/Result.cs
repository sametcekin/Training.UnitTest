namespace Training.UnitTest.Wrappers
{
    public class Result<T>
    {
        public Result(string message,bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public Result(T data, string message,bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }
        public T? Data { get; private set; }
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }
    }
}
