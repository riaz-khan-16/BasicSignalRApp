using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Join a group
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            groupName
        );

        await Clients.Group(groupName)
            .SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} joined {groupName}");
    }

    // Leave a group
    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            groupName
        );
    }

    // Send message to group
    public async Task SendMessageToGroup(
        string groupName,
        string user,
        string message
    )
    {
        await Clients.Group(groupName)
            .SendAsync("ReceiveMessage", user, message);
    }
}
