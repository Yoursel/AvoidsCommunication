namespace AvoidsCommunication.Domain.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }  
    }
}
