namespace SimpleInputDataValidator
{
    public interface IValidator
    {
        string PropertyName { get; }
        string Message { get; }
        bool Validate();
    }
}
