namespace SosialMediaProject.Business.Exceptions
{
    public class InvalidNotFoundException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidNotFoundException()
        {

        }
        public InvalidNotFoundException(string message) : base(message)
        {

        }
        public InvalidNotFoundException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
