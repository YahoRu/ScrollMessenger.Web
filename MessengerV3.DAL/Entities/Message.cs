using System;
using System.Collections.Generic;

namespace MessengerV3.DAL.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int MessageSenderId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime MessageDate { get; set; }

        public virtual Chat Chat { get; set; } = null!;
        public virtual User MessageSender { get; set; } = null!;
    }
}
