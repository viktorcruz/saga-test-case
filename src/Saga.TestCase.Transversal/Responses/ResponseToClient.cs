using Saga.TestCase.Transversal.Interfaces;

namespace Saga.TestCase.Transversal.Responses
{
    public class ResponseToClient<T> : IResponseToClient<T>
    {
        #region Properties
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        #endregion
    }
}
