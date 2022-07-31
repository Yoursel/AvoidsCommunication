using AvoidsCommunication.Domain.Enum;

namespace AvoidsCommunication.Domain.Entity
{
    public class Rambling
    {
        public int RamblingId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Cover { get; set; }

        public string Content { get; set; }

        public Topic Topic { get; set; }

        public User User { get; set; }
    }
}
