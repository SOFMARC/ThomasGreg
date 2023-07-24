namespace ClienteService.Exceptions
{
    public class EntityNotFoundException : CustomException
    {
        public EntityNotFoundException(string entityName)
            : base($"{entityName} not found.", $"{entityName.ToUpper()}_NOT_FOUND")
        {
        }
    }

}
