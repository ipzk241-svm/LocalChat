using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ChatLibrary
{
    [ServiceContract(CallbackContract = typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract]
        Task<bool> ConnectAsync(string username);

        [OperationContract]
        Task DisconnectAsync(string username);

        [OperationContract]
        Task SendMessageToGroupAsync(string message, string sender );

        [OperationContract]
        Task SendPrivateMessageAsync(string message, string recipient, string sender);

        [OperationContract]
        Task<List<string>> GetOnlineUsersAsync();
    }

    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string message);

        [OperationContract(IsOneWay = true)]
        void UpdateUserList(List<string> users);
    }

}