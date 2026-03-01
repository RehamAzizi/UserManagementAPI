namespace TaskOne.Domain.ResultPattern
{
    public sealed class ResultT<TValue> : Result
    {
        private readonly TValue? _value;

        private ResultT(
            TValue value
        ) : base()
        {
            _value = value;
        }

        private ResultT(
            Error error
        ) : base(error)
        {
            _value = default;
        }

        public TValue Value =>
            IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

        //يسمح بتحويل كائن من النوع Error إلى ResultT<TValue> تلقائيًا
        public static implicit operator ResultT<TValue>(Error error) =>
            new(error);
        //يسمح بالتحويل تلقائياً من TValue إلى  ResultT<TValue>
        public static implicit operator ResultT<TValue>(TValue value) =>
            new(value);

        public static ResultT<TValue> Success(TValue value) =>
            new(value);

        public static new ResultT<TValue> Failure(Error error) =>
            new(error);
    }

}