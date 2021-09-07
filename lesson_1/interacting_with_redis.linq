<Query Kind="Program">
  <Namespace>System.Net.Sockets</Namespace>
</Query>

void Main()
{
	var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	
	socket.Connect("127.0.0.1", 6379);
	
	var responseStream = new BufferedStream(new NetworkStream(socket), 1024);
	
	var requestString = "*2\r\n$3\r\nGET\r\n$3\r\ncat\r\n";
	byte[] request = Encoding.UTF8.GetBytes(requestString);
	socket.Send(request);
	
	
	var result = new StringBuilder();
	int b;
	
	while((b = responseStream.ReadByte()) != -1){
		if(b == '\r'){
			responseStream.ReadByte();
			break;
		}
		result.Append((char) b);
	}
	
	var responseLength = int.Parse(result.ToString().Substring(1));
	var responseValue = new byte[responseLength];
	responseStream.Read(responseValue, 0, responseLength);
	Encoding.UTF8.GetString(responseValue).Dump("result");
}