using Microsoft.AspNetCore.SignalR;

class TrackerHub : Hub
{
    public async Task StreamPosition(string connectionId, Position position) 
    {
        await Clients.Client(connectionId).SendAsync("StreamPosition", position);
    }

    public string GetConnectionId() => Context.ConnectionId;
}