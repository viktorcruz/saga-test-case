using Saga.TestCase.Transversal.Interfaces;

namespace Saga.TestCase.Transversal.Responses
{
    public class DatabaseResponse : IDatabaseResponse
    {
        public bool ResultStatus { get; set; }
        public string ResultMessage { get; set; }
        public string OperationType { get; set; }
        public int AffectedRecordId { get; set; }
        public DateTime OperationDateTime { get; set; }
        public string ExceptionMessage { get; set; }
    }

    public class RetrieveDatabaseResult<T> : DatabaseResponse
    {
        public T Details { get; set; }
    }
}