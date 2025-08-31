// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Supabase;
using Supabase.Realtime;
using Supabase.Realtime.Channel;
using Supabase.Realtime.Models;
using Client = Supabase.Realtime.Client;

var constr =
    "User Id=postgres.kttozbfsmxnpscaeibdk;Password=N@v!d$hokri5410;Server=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Database=postgres;";

var supabaseOptions = new SupabaseOptions
{
    AutoConnectRealtime = true
};
var client = new Supabase.Client("https://kttozbfsmxnpscaeibdk.supabase.co",
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imt0dG96YmZzbXhucHNjYWVpYmRrIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjUxOTIyNTksImV4cCI6MjA0MDc2ODI1OX0.N0cT_VF87VNK_LaOh2Erw-oqiOrU5yL9HRmHLgeB6rk");
await client.InitializeAsync();
await client.Realtime.ConnectAsync();
var channel = client.Realtime.Channel("test");
var broadcast = channel.Register<CursorBroadcast>();
broadcast.AddBroadcastEventHandler((sender, baseBroadcast) =>
{
    var response = broadcast.Current();
    Console.WriteLine($"{response.Name} {response.Family}");
});
await channel.Subscribe();
await channel.Send(Constants.ChannelEventName.Broadcast, "test", new CursorBroadcast { Name = "Navid", Family = "shokri" });
Console.ReadLine();
/*
client.ConnectAsync().GetAwaiter().GetResult();
var channel = new RealtimeChannel(client.Socket,"test",new ChannelOptions(new ClientOptions(),
    () => { return ""; },new JsonSerializerSettings()));
var broadcast = channel.Register<CursorBroadcast>();
broadcast.AddBroadcastEventHandler((sender, baseBroadcast) =>
{
    var response = broadcast.Current();
    Console.WriteLine($"{response.Name} {response.Family}");
});

await channel.Subscribe();
*/

// Send a broadcast
await broadcast.Send("cursor", new CursorBroadcast { Name = "Navid", Family = "Shokri" });

Console.ReadLine();
class CursorBroadcast : BaseBroadcast
{
    [JsonProperty("name")]
    public string Name {get; set;}

    [JsonProperty("family")]
    public string Family {get; set;}
}
