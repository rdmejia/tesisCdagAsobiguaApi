using System;
namespace tesisCdagAsobiguaApi.Domain.Services.Communication
{
    public class ObjectResponse<T> : BaseResponse
        where T : class
    {
        public T value { get; private set; }

        public ObjectResponse(bool sucess, string message, T value) : base(sucess, message)
        {
            this.value = value;
        }

        public ObjectResponse(T value) : this(true, string.Empty, value) { }

        public ObjectResponse(string message) : this(false, message, null) { }
    }
}
