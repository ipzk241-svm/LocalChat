using ChatLibrary;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ChatServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
       private readonly Dictionary<string, IChatCallback> _users = new Dictionary<string, IChatCallback>();


       public async Task<bool> ConnectAsync(string username)
       {
           try
           {
               var callback = OperationContext.Current?.GetCallbackChannel<IChatCallback>();

               if (_users.ContainsKey(username))
               {
                   return false; 
               }

               _users.Add(username, callback);
               await UpdateAllUsersAsync();
               return true;
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error while connecting user {username}: {ex.Message}");
               return false;
           }
       }


        public async Task DisconnectAsync(string username)
        {
            if (_users.ContainsKey(username))
            {
                _users.Remove(username);
                await UpdateAllUsersAsync();
            }
        }

		public async Task SendMessageToGroupAsync(string message, string sender)
		{
			if (string.IsNullOrWhiteSpace(message)) return;
            var formattedMessage = FormatMessage(sender, message);

			foreach (var user in _users.Values)
			{
				user.ReceiveMessage(formattedMessage);
			}
		}

		public async Task SendPrivateMessageAsync(string message, string recipient, string sender)
        {
            var formattedMessage = FormatMessage(sender, message, isPrivate: true);
            if (_users.TryGetValue(recipient, out var callback))
            {
                callback.ReceiveMessage(formattedMessage);
            }
            else
            {
                if (_users.TryGetValue(sender, out var senderCallback))
                {
                    senderCallback.ReceiveMessage($"[System]: User '{recipient}' is not online.");
                }
            }
        }

        private static string FormatMessage(string sender, string message, bool isPrivate = false)
        {
            var currentTime = DateTime.Now.ToString("HH:mm");
            return isPrivate
                ? $"[{currentTime}] [Private] {sender}: {message}"
                : $"[{currentTime}] {sender}: {message}";
        }

        public async Task<List<string>> GetOnlineUsersAsync()
        {
            return new List<string>(_users.Keys);
        }

        private async Task UpdateAllUsersAsync()
        {
            var users = await GetOnlineUsersAsync();
            foreach (var callback in _users.Values)
            {
                 callback.UpdateUserList(users);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChatService), new Uri("net.tcp://localhost:8000/ChatService"));
            host.AddServiceEndpoint(typeof(IChatService), new NetTcpBinding(), "");
            host.Open();

            Console.WriteLine("Chat server is running...");
            Console.ReadLine();

            host.Close();
        }
    }
}
