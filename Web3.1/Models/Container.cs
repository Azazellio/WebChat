using System;
using System.Collections.Generic;
using System.Linq;

namespace Web2.Models
{
    public class Container
    {
        public List<IChattable> chatsGroups;
        public List<User> users;
        public List<Device> devices;
        public List<Message> messages;
        public Container()
        {
            chatsGroups = new List<IChattable>();
            users = new List<User>();
            devices = new List<Device>();
            messages = new List<Message>();
        }

        public void Add(params User[] users)
        {
            this.users = users.ToList();
            SetChats();
        }
        public void Add(params IChattable[] chatGroups)
        {
            this.chatsGroups = chatGroups.ToList();
        }
        public void Add(params Message[] messages)
        {
            this.messages = messages.ToList();
        }
        public void Add(params Device[] devices)
        {
            this.devices = devices.ToList();
        }
        private void SetChats()
        {
            foreach(User user in this.users)
            {
                foreach (IChattable chattable in user.GroupsChats)
                {
                    if (!this.chatsGroups.Contains(chattable))
                    {
                        this.chatsGroups.Add(chattable);
                    }
                }
            }
        }
    }
}
