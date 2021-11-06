namespace Chef.Common.DTO.User
{
    public class NewUserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UId { get; set; }
        public string AvatarUrl { get; set; }
        public int ProductListId { get; set; }
        public string AccessToken { get; set; }
    }
}
