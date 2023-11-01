namespace UsersAuth.Models
{
    public static class Users
    {
        public static List<User> users = new List<User>()
        {
            new User{
                Id=1,
                Username="john4545",
                Fullname="John Doe",
                Password="12345",
                Role="Admin"
            }, new User{
                Id=2,
                Username="bk12345",          
                Password="12345",

                Fullname="Albert Lincoln",
                Role="Manager"
            }, new User{
                Id=3,
                Username="elton6767",
                Fullname="Isaac Elton",
                Password="12345",
                Role="Customer"
            }, new User{
                Id=4,
                Username="eliaarklee",
                Fullname="Elia Marklee",
                Password="12345",
                Role="Customer"
            }, new User{
                Id=5,
                Username="Michael Philips",
                Fullname="p23hilips",
                Password="12345",
                Role="Customer"
            }, new User{
                Id=6,
                Username="Johan Muller",
                Fullname="322366545muller",
                Password="12345",
                Role="Customer"
            },
        };

    }
}
