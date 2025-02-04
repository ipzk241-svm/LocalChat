using ChatLibrary;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatForm
{
	[CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public partial class Form1 : Form, IChatCallback
	{
		private IChatService _chatService;
		private DuplexChannelFactory<IChatService> _factory;
		private string _username;
		private string _selectedUser;
		private Dictionary<string, List<string>> _privateChats = new Dictionary<string, List<string>>();
		private string CurrentChatUser = null;
		private List<string> _groupChat = new List<string>();


		public Form1()
		{
			InitializeComponent();
		}

		private async Task ConnectToServerAsync()
		{
			try
			{
				_factory = new DuplexChannelFactory<IChatService>(this, new NetTcpBinding(),
					new EndpointAddress("net.tcp://localhost:8000/ChatService"));
				_chatService = _factory.CreateChannel();

				var connected = await _chatService.ConnectAsync(_username);

				if (connected)
				{
					ChatBox.AppendText("Connected to chat." + Environment.NewLine);
					ConnectButton.Enabled = false;
					UsernameBox.Enabled = false;
					SendButton.Enabled = true;
					OnlineUsers.Enabled = true;
					DisconnectButton.Enabled = true;
					MessageBox.Enabled = true;
				}
				else
				{
					ChatBox.AppendText("Failed to connect." + Environment.NewLine);
				}
			}
			catch
			{
				ChatBox.AppendText("Failed to connect." + Environment.NewLine);
			}
		}

		public void ReceiveMessage(string message)
		{
			ChatBox.Invoke(new MethodInvoker(() =>
			{
				if (message.Contains(ChatConstants.PrivateMessagePrefix))
				{
					var sender = message.Split(' ')[2].TrimEnd(':');
					if (!_privateChats.ContainsKey(sender))
					{
						_privateChats[sender] = new List<string>();
					}
					_privateChats[sender].Add(message);
				}
				else
				{
					_groupChat.Add(message);
				}

                if (!string.IsNullOrEmpty(_selectedUser) && _selectedUser != _username && _privateChats.ContainsKey(_selectedUser))
                {
                    UpdateChat(_privateChats[_selectedUser]); // Оновлюємо приватний чат
                }
                else
                {
                    UpdateChat(_groupChat); // Оновлюємо загальний чат
                }
            }));
		}

		public void UpdateUserList(List<string> users)
		{
			if (OnlineUsers.InvokeRequired)
			{
				OnlineUsers.Invoke(new Action(() =>
				{
					OnlineUsers.Items.Clear();
					foreach (var user in users)
					{
						OnlineUsers.Items.Add(user);
					}
				}));
			}
			else
			{
				OnlineUsers.Items.Clear();
				foreach (var user in users)
				{
					OnlineUsers.Items.Add(user);
				}
			}
		}
		private async void ConnectButton_Click(object sender, EventArgs e)
		{
			_username = UsernameBox.Text;
			await ConnectToServerAsync();
		}

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Text.Trim();

            if (!string.IsNullOrEmpty(_selectedUser) && _selectedUser != _username)
            {
                await SendPrivateMessageAsync(message, _selectedUser);
            }
            else
            {
                await _chatService.SendMessageToGroupAsync(message, _username);
            }

            MessageBox.Clear();
        }

        private async Task SendPrivateMessageAsync(string message, string recipient)
        {
            var timestamp = DateTime.Now.ToString("HH:mm");
            var privateMessage = $"[{timestamp}] [You -> {recipient}]: {message}";

            if (!_privateChats.ContainsKey(recipient))
            {
                _privateChats[recipient] = new List<string>();
            }
            _privateChats[recipient].Add(privateMessage);

            if (!string.IsNullOrEmpty(_selectedUser) && _selectedUser != _username && _privateChats.ContainsKey(_selectedUser))
            {
                UpdateChat(_privateChats[_selectedUser]); // Оновлюємо приватний чат
            }
            else
            {
                UpdateChat(_groupChat); // Оновлюємо загальний чат
            }

            await _chatService.SendPrivateMessageAsync(message, recipient, _username);
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_chatService != null && !string.IsNullOrEmpty(_username))
			{
				await _chatService.DisconnectAsync(_username);
			}
		}

        private void OnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnlineUsers.SelectedItem != null)
            {
                _selectedUser = OnlineUsers.SelectedItem.ToString();

                if (_selectedUser == CurrentChatUser)
                {
                    DeselectCurrentChat();
                    return;
                }

                CurrentChatUser = _selectedUser;
                ChatBox.Clear();

                if (IsCurrentUserOrEmpty(_selectedUser))
                {
                    DeselectCurrentChat();
                }
                else
                {
                    UpdatePrivateChat(_selectedUser);
                }
            }
            else
            {
                SwitchToGeneralChat();
            }
        }

        private void DeselectCurrentChat()
        {
            CurrentChatUser = null;
            OnlineUsers.SelectedItem = null;
            UpdateGeneralChat();
        }

        private bool IsCurrentUserOrEmpty(string selectedUser)
        {
            return selectedUser == _username || string.IsNullOrEmpty(selectedUser);
        }

        private void UpdateChat(IEnumerable<string> messages)
        {
            ChatBox.Clear();
            foreach (var message in messages)
            {
                ChatBox.AppendText(message + Environment.NewLine);
            }
        }
        private void UpdatePrivateChat(string selectedUser)
        {
            if (_privateChats.ContainsKey(selectedUser))
            {
                UpdateChat(_privateChats[selectedUser]);
            }
        }
        private void UpdateGeneralChat() => UpdateChat(_groupChat);

        private void SwitchToGeneralChat()
        {
            _selectedUser = null;
            CurrentChatUser = null;
            ChatBox.Clear();
            ChatBox.AppendText("You are now in the general chat." + Environment.NewLine);
            UpdateGeneralChat();
        }

        private void Form1_Load(object sender, EventArgs e)
		{

		}

		private async void DisconnectButton_Click(object sender, EventArgs e)
		{
			if (_chatService != null && !string.IsNullOrEmpty(_username))
			{
				try
				{
					await _chatService.DisconnectAsync(_username);
					ChatBox.AppendText("Disconnected from chat." + Environment.NewLine);
				}
				catch
				{
					ChatBox.AppendText("Failed to disconnect properly." + Environment.NewLine);
				}
				finally
				{
					DisconnectCleanup();
				}
			}
		}

		private void DisconnectCleanup()
		{
			_username = null;
			_selectedUser = null;

			ConnectButton.Enabled = true;
			UsernameBox.Enabled = true;
			DisconnectButton.Enabled = false;
            SendButton.Enabled = false;
            OnlineUsers.Enabled = false;
            MessageBox.Enabled = false;

            OnlineUsers.Items.Clear();
			ChatBox.AppendText("You are offline." + Environment.NewLine);
		}

	}
}