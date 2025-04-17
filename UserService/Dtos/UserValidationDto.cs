namespace UserService.Dtos
{
    public class UserValidationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
