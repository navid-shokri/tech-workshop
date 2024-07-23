using System.ComponentModel;
using Microsoft.Extensions.Hosting;

namespace Server;

public class MyBackgroundWorker : BackgroundService
{
    private readonly ListenerWrapper _lw;

    public MyBackgroundWorker(ListenerWrapper lw)
    {
        _lw = lw;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _lw.RegisterReceiveAsync();
    }
}