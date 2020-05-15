using System;
using System.Collections.Generic;

namespace Web2.Models
{
    public class User
    {
        private static int ID;
        private readonly int id;
        public string name { get; private set; }

        private List<IChattable> GroupsChatsP;
        public IReadOnlyList<IChattable> GroupsChats { get => GroupsChatsP.AsReadOnly(); }

        private List<Device> devicesP;
        public IReadOnlyList<Device> devices { get => devicesP.AsReadOnly(); }

        public bool ChatExists(User user)
        {
            foreach(IChattable chattable in this.GroupsChatsP)
            {
                if (chattable.GetUsers().Contains(user))
                {
                    return true;
                }
            }
            return false;
        }
        public IChattable FindChatWith(User user)
        {
            IChattable chat = new Chat();
            foreach(IChattable chattable in this.GroupsChatsP)
            {
                if (chattable.GetUsers().Contains(user) & chattable.Info() == "chat")
                {
                    chat = chattable;
                }
            }
            return chat;
        }
        public User(string name)
        {
            this.name = name;
            GroupsChatsP = new List<IChattable>();
            devicesP = new List<Device>();
            this.id = ID;
            ID++;
        }
        public Group AddGroup(string name)
        {
            var cG = new Group(name);
            this.GroupsChatsP.Add(cG);
            return cG;
        }
        public void AddGroupToList(Group group)
        {
            this.GroupsChatsP.Add(group);
        }
        public Chat AddChatWith(User user)
        {
            var c = new Chat(this, user);
            return c;
        }

        public void AddChatToList(IChattable chattable)
        {
            this.GroupsChatsP.Add(chattable);
        }

        public void AddChatEnding(Chat chat)
        {
            var temp = chat.GetUsers();
            User neededUser;
            if (temp[0] == this)
            {
                neededUser = temp[1];
            }
            else
            {
                neededUser = temp[0];
            }
            neededUser.AddChatEnding(chat);
        }
        public Message WriteMessage(string text, User user)
        {
            IChattable chat;
            if (!this.ChatExists(user))
            {
                chat = this.AddChatWith(user);
            }
            else
            {
                chat = this.FindChatWith(user);
            }
            chat = new Chat(this, user);
            return new Message(this, chat, text);
        }

        public Message WriteMessage(string text, Group group)
        {
            if (this.GroupsChatsP.Contains(group))
            {
                return new Message(this, group, text);
            }
            else
            {
                throw new Exception("User is not in a group");
            }
        }

        public string GetOtherUserName(IChattable chattable)
        {
            var temp = chattable.GetUsers();
            User neededUser;
            if (temp[0] == this)
            {
                neededUser = temp[1];
            }
            else
            {
                neededUser = temp[0];
            }
            return neededUser.name;
        }

        public string GetDiscussions()
        {
            var res = "";
            foreach(IChattable chattable in this.GroupsChatsP)
            {
                res += chattable.GetAllMessagesS();
            }
            return res;
        }
    }
}
