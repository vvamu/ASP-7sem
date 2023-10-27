using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace _2_WebSockets;

public static class WebSocketsController
{
    public static ParameterizedThreadStart SendCycle = async (Object? webSock) =>
    {
        int k = 0;
        var webSocket = webSock as WebSocket;
        //byte[] buffer = new byte[1024];
        while (webSocket != null && webSocket.State == WebSocketState.Open)
        {
            //buffer = Encoding.ASCII.GetBytes;
            var bytes = Encoding.ASCII.GetBytes("Send Cycle");
            await webSocket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
            Thread.Sleep(1000);
        }
    };

    public static ParameterizedThreadStart ReceiveCycle = async (Object? webSock) =>
    {
        int k = 0;
        var webSocket = webSock as WebSocket;
        //Trace.Listeners.Add()
        byte[] buffer = new byte[1024];

        while (webSocket != null && webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer,0,result.Count));
        }
    };

}
