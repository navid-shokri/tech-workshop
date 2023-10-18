using Message;

namespace Server;

public class Worker
{
    public async Task HandleCommand(Command command, CancellationToken cancellationToken)
    {
        await Task.Delay(5000, cancellationToken);
        Console.WriteLine($"{command.Name}-{command.Family}");
    }
}