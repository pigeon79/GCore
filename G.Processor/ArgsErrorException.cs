using G.Core;

namespace G.Processor
{
    public class ArgsErrorException : CoreException
    {
        public readonly int ReturnCode;

        public ArgsErrorException(int returnCode, string message) : base(message)
        {
            this.ReturnCode = returnCode;
        }
    }
}
