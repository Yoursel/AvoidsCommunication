
namespace AvoidsCommunication.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Rambling> Ramblings { get; set; } = new List<Rambling>();
    }
}
