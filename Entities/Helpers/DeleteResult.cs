using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Helpers
{
    public enum TypeDeleteResult
    {
        Success,
        NotFound,
        ValidationFail
    }

    public class DeleteResult
    {
        public TypeDeleteResult Type { get; private set; }
        public string Message { get; private set; }

        public DeleteResult(TypeDeleteResult type) : this(type, "")
        {

        }

        public DeleteResult(TypeDeleteResult type, string message)
        {
            Type = type;
            Message = message;
        }

        public static DeleteResult Success() => new DeleteResult(TypeDeleteResult.Success);
        public static DeleteResult NotFound() => new DeleteResult(TypeDeleteResult.NotFound);
        public static DeleteResult ValidationFail(string message) => new DeleteResult(TypeDeleteResult.ValidationFail, message);
    }
}
