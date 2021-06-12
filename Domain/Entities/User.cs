namespace Domain
{
    public class User
    {
        public User()
        {
            
        }
        public User(int userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}