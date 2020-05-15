using System;
using System.Collections.Generic;
using System.Linq;

namespace Web2.Models
{
    public class Chat : IChattable
    {
        public static int ID = 0;

        readonly int id;
        public string name { get; private set; }

        private List<Message> messagesP;
        public IReadOnlyList<Message> messages { get => messagesP.AsReadOnly(); }

        private User[] users = new User[2];

        public Chat(User u1, User u2)
        {
            this.messagesP = new List<Message>();
            u1.AddChatToList(this);
            u2.AddChatToList(this);
            this.users[0] = u1;
            this.users[1] = u2;
            this.id = ID;
            ID++;
        }
        public Chat() { }
        public void AddMessage(Message message)
        {
            this.messagesP.Add(message);
        }
        public string GetName()
        {
            throw new NotImplementedException();
        }
        public int GetId()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return this.users.ToList();
        }

        public List<Message> GetAllMessages()
        {
            return this.messagesP;
        }
        public string GetAllMessagesS()
        {
            var res = "";
            foreach(Message m in this.messagesP)
            {
                res += String.Format("[{0}]", m.authorName) + Environment.NewLine + m.text + Environment.NewLine + Environment.NewLine;
            }
            return res;
        }
        public List<Message> GetMessagesFrom(string name)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesFrom(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string name)
        {
            throw new NotImplementedException();
        }

        public string Info()
        {
            return "chat";
        }
    }
}
