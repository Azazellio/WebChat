using System;
using System.Collections.Generic;

namespace Web2.Models
{
    public interface IChattable
    {
        string GetName();
        int GetId();
        string Info();
        void AddMessage(Message message);
        List<User> GetUsers();
        List<Message> GetAllMessages();
        string GetAllMessagesS();
        List<Message> GetMessagesFrom(string name);
        List<Message> GetMessagesFrom(int id);
        User FindUser(int id);
        User FindUser(string name);
    }
}
