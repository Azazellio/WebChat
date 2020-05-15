using System;
using System.Collections.Generic;

namespace Web2.Models
{
    public class Group : IChattable
    {
        public string name { get; private set; }
        public int id { get; private set; }
        private static int ID
        {
            get
            {
                var i = Chat.ID;
                Chat.ID++;
                return i;
            }
        }

        private List<User> usersP;
        public IReadOnlyList<User> users { get => usersP.AsReadOnly(); }

        private List<Message> messagesP;
        public IReadOnlyList<Message> messages { get => messagesP.AsReadOnly(); }

        public Group(string name)
        {
            this.usersP = new List<User>();
            this.messagesP = new List<Message>();
            this.name = name;
            this.id = ID;
        }


        public void AddUsers(params User[] users)
        {
            foreach(User user in users)
            {
                this.usersP.Add(user);
                user.AddGroupToList(this);
            }
        }
        public void AddMessage(Message message)
        {
            this.messagesP.Add(message);
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string name)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesFrom(string name)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesFrom(int id)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return this.usersP;
        }

        public string Info()
        {
            return "group";
        }

        public string GetAllMessagesS()
        {
            var res = "";
            foreach (Message m in this.messagesP)
            {
                res += String.Format("[{0}]", m.authorName) + Environment.NewLine + m.text + Environment.NewLine + Environment.NewLine;
            }
            return res;
        }
    }
}
