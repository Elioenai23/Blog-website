using System;

namespace backend.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        // Subscriber User Fk
        public int SubscriberId { get; set; }
        public User Subscriber { get; set; } = null!;

        // SubscribedTo User Fk
        public int SubscribedToId { get; set; }
        public User SubscribedTo { get; set; } = null!;

        public DateTime SubscribedOn { get; set; } = DateTime.UtcNow;
    }
}