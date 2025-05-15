public class ModuleMissingException : System.Exception
{
    public ModuleMissingException() { }
    public ModuleMissingException(string message) : base(message) { }
    public ModuleMissingException(string message, System.Exception inner) : base(message, inner) { }
    protected ModuleMissingException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}