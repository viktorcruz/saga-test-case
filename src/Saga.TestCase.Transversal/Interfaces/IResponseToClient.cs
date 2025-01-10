namespace Saga.TestCase.Transversal.Interfaces
{
    public interface IResponseToClient<T>
    {
        T Result { get; set; }
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}

