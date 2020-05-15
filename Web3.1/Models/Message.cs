using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web3.Data;

namespace Web2.Models
{
    public class Message : IEntity
    {
        private static int ID;
        public int id { get; set; }
        private IChattable chatGroup;
        public User author { get; private set; }
        public string authorName { get => author.name; }
        public DateTime time { get; private set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string text { get; private set; }

        public Message(User author, IChattable chatGroup, string content)
        {
            this.time = DateTime.Now;
            chatGroup.AddMessage(this);
            this.id = ID;
            this.author = author;
            this.chatGroup = chatGroup;
            this.text = content;
            ID++;
        }
    }
}
