using MyFramework.Model;

namespace MyFramework.Service
{
    public class UserCreator
    {
        private static TestDataReader dataReader = new TestDataReader();

        private static string protonUsername => dataReader.GetTestData("proton.user.name");
        private static string protonPassword => dataReader.GetTestData("proton.user.password");
        private static string gmailUsername => dataReader.GetTestData("gmail.user.name");
        private static string gmailPassword => dataReader.GetTestData("gmail.user.password");

        public static User withGmailCredentials()
        {
            return new User(gmailUsername, gmailPassword);
        }

        public static User withProtonCredentials()
        {
            return new User(protonUsername, protonPassword);
        }

        public static User withEmptyUsername()
        {
            return new User("", gmailPassword);
        }

        public static User gmailWithEmptyPassword()
        {
            return new User(gmailUsername, "");
        }

        public static User protonWithEmptyPassword()
        {
            return new User(protonUsername, "");
        }

        public static User gmailWithInvalidPassword()
        {
            return new User(gmailUsername, "invalidPassword");
        }

        public static User withInvalidLogin()
        {
            return new User("InvalidEmail@notexited.cc", gmailPassword);
        }
    }
}
