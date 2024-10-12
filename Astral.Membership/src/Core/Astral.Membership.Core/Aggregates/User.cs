namespace Astral.Membership.Core.Aggregates
{
    public record User
    {
        public User()
        {

        }
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public bool IsApproved { get; private set; }

        public static User CreateUser(string userName, string Password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Password = Password,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                IsApproved = false
            };
        }

        public void UpdatePassword(string password)
        {
            Password = password;
            UpdateTime = DateTime.Now;
        }
    }
}
