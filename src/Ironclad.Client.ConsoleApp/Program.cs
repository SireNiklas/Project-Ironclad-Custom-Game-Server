using Ironclad.Client.Core.Services;
using Ironclad.Shared.DTOs;

namespace Ironclad.Client.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
		GameConnection gameConnection = new GameConnection();
        
        gameConnection.OnMessageAllReceived += (sender, message) => Console.WriteLine($"Global: {message}");
        gameConnection.OnMessageOthersReceived += (sender, message) => Console.WriteLine($"Others: {message}");
        gameConnection.OnMessageCallerReceived += (sender, message) => Console.WriteLine($"Me: {message}");
        gameConnection.OnCardPlayedReceived += (sender, cardDTO) => Console.WriteLine($"Me: {cardDTO.Name}");

        await gameConnection.ConnectAsync("http://localhost:5177/game");
        Console.WriteLine("Connected to server");
        
        await gameConnection.PlayCardAsync(new CardDTO("TestCard", 5, 7, 2));
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        
        await gameConnection.DisconnectAsync();
        Console.WriteLine("Disconnected from server");
    }
}