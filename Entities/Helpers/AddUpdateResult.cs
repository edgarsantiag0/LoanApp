namespace Entities.Helpers
{
    public class AddUpdateResult<T>
    {
        public T Value { get; set; }
        public string Msg { get; set; } = "";
        public bool IsValid { get; set; } = true;

        public bool IsNoFound { get; set; } = false;

        public static AddUpdateResult<T> Ok()
        {
            return new AddUpdateResult<T>
            {
                IsValid = true
            };
        }

        public static AddUpdateResult<T> Ok(T value)
        {
            return new AddUpdateResult<T>
            {
                Value = value,
                IsValid = true
            };
        }

        public static AddUpdateResult<T> Error(string msg)
        {
            return new AddUpdateResult<T>
            {
                Msg = msg,
                IsValid = false
            };
        }

        public static AddUpdateResult<T> NotFound()
        {
            return new AddUpdateResult<T>
            {
                IsValid = false,
                IsNoFound = true
            };
        }
    }
}
