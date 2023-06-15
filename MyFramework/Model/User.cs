namespace MyFramework.Model
{
    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string GetUsername() { return username; }

        public string GetPassword() { return password; }

        public override string ToString()
        {
            return $"user {username} password \"{password}\"";
        }
    }
}
