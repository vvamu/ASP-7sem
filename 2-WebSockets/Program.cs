using _2_WebSockets;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseWebSockets();
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");
app.MapGet("/tws2", async (HttpContext context) =>
{

    Thread hSendCycle = new Thread(new System.Threading.ParameterizedThreadStart(WebSocketsController.SendCycle));
    Thread hReceiveCycle = new Thread(new System.Threading.ParameterizedThreadStart(WebSocketsController.ReceiveCycle));

    byte[] buffer = new byte[1024];
    if (context.WebSockets.IsWebSocketRequest)
    {
        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        hSendCycle.Start(webSocket);
        hReceiveCycle.Start(webSocket);
        hSendCycle.Join();
        hReceiveCycle.Join();
    }

});

app.MapGet("/tws", async (HttpContext context) =>
{



Thread hSendCycle = new Thread(new System.Threading.ParameterizedThreadStart(iiii.SendCycle));
Thread hRecieveCycle = new Thread(new System.Threading.ParameterizedThreadStart(iiii2.RecieveCycle));
byte[] buffer = new byte[4096];
if (context.WebSockets.IsWebSocketRequest)
{
WebSocket ws = await context.WebSockets.AcceptWebSocketAsync();
WebSocketReceiveResult result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
string message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
hSendCycle.Start(ws);
hRecieveCycle.Start(ws);
hSendCycle.Join();
hRecieveCycle.Join();
}
});



app.Run();
public class iiii
{
    public static ParameterizedThreadStart SendCycle = async (Object? ws) =>
    {
        int k = 0;
        WebSocket? xws = (WebSocket?)ws;
        byte[] buffer = new byte[4096];
        while (xws != null && xws.State == WebSocketState.Open)
        {


            await xws.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);


            buffer = Encoding.ASCII.GetBytes(string.Format("Send cycle:{0}", ++k));
            Thread.Sleep(1000);


        }

    };
}
public class iiii2
{
    public static ParameterizedThreadStart RecieveCycle = async (Object? ws) =>
    {
        int k = 0;
        WebSocket? xws = (WebSocket?)ws;
        byte[] buffer = new byte[4096];
        string message = string.Empty;
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        Trace.AutoFlush = true;
        Trace.WriteLine("Start Trace");

        while (xws != null && xws.State == WebSocketState.Open)
        {

            WebSocketReceiveResult result = await xws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
            Trace.WriteLine(message);



        }
        Trace.WriteLine("Finish Trace");
    };
}

