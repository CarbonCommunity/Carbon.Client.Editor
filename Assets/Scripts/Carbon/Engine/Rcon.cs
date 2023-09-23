using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;
using Carbon.Client;
using UnityEngine.Rendering;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.PlayerLoop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Carbon
{
	[ExecuteAlways]
	public class Rcon : MonoBehaviour
	{
		internal static Rcon _instance;
		public static Rcon Singleton => _instance ?? (_instance = FindObjectOfType<Rcon>());

		public static RconEntity.EntityData[] Entities = new RconEntity.EntityData[0];

		public WebRcon Instance;

		public string Ip { get { return PlayerPrefs.GetString("rconip"); } set { PlayerPrefs.SetString("rconip", value); } }
		public int Port { get { return PlayerPrefs.GetInt("rconport"); } set { PlayerPrefs.SetInt("rconport", value); } }
		public string Password { get { return PlayerPrefs.GetString("rconpassword"); } set { PlayerPrefs.SetString("rconpassword", value); } }

		public bool SyncServer;

		public bool IsConnected => Instance != null && Instance.IsConnected;

		public void SendMap(string path, string prefab)
		{
			if (!IsConnected)
			{
				return;
			}

			Instance.SendCommandAsync($"rebuildmap {path} {prefab}");
		}

		public void Update()
		{
			if (!SyncServer)
			{
				return;
			}

			foreach (var entity in Entities)
			{
				RconEntity.CreateOrUpdate(entity);
			}
		}
		public void Connect()
		{
			Instance?.Stop();
			Instance = new WebRcon(Ip, Port.ToString(), Password);
			Instance.Start();

			Instance.OnServerConnected += () =>
			{
				Instance.SendCommandAsync("echo Hello world!");
			};
			Instance.OnEntityUpdate += update =>
			{
				if (SyncServer)
				{
					Entities = update.Entities;
				}
			};
			Instance.OnRawMessage += (data, rawData) =>
			{
				if (string.IsNullOrEmpty(data))
				{
					return;
				}
			};
		}
		public void Disconnect()
		{
			Instance?.Stop();
			Instance = null;
		}

		public class WebRcon
		{
			public static WaitForSeconds WFS_05 { get; set; } = new WaitForSeconds(0.5f);

			private IWebSocketConnection Connection { get; set; }

			public bool IsConnected => Connection.IsOpen;

			public WebRcon(string ipAddress, string port, string password)
			{
				Connection = new WebSocketConnectionFactory(ipAddress, port, password).Create();
				Connection.SocketError += WebSocketConnection_SocketError;
				Connection.SocketClosed += WebSocketConnection_SocketClosed;
				Connection.SocketOpened += WebSocketConnection_SocketOpened;
			}

			public Action<string, byte[]> OnRawMessage { get; set; }
			public Action<Message> OnMessage { get; set; }
			public Action<Command> OnCommandReceived { get; set; }
			public Action<EntityUpdate> OnEntityUpdate { get; set; }
			public Action<string, string[], RconIdentifiers> OnCommandSent { get; set; }

			public Action OnServerConnected { get; set; }
			public Action<string, int> OnServerDisconnected { get; set; }
			public Action<string, Exception> OnServerError { get; set; }

			public void Start()
			{
				if (!Connection.IsOpen)
				{
					Connection.Connect();
					Read();
				}
			}
			public void Stop()
			{
				if (Connection.IsOpen)
				{
					Connection.Disconnect();
				}
			}

			public void Reconnect()
			{
				if (!Connection.IsOpen)
				{
					Connection.Connect();
				}
			}
			public void SendMessageAsync(string message)
			{
				SendCommandAsync($"say {message}", RconIdentifiers.Chat);
			}
			public void SendCommandAsync(string command, RconIdentifiers identifier = RconIdentifiers.Generic)
			{
				var request = JsonConvert.SerializeObject(
					new WebRconRequest()
					{
						Message = command,
						Identifier = Convert.ToInt32(identifier),
						Name = "WebRcon"
					});

				Connection.Send(request);

				var split = command.Split(' ');
				var onlyCommand = split[0];
				var arguments = split.Skip(1).ToArray();
				OnCommandSent?.Invoke(onlyCommand, arguments, identifier);
			}

			public Action<WebRconResponse> OnSendAndReceiveCommand { get; set; }
			public IEnumerator SendAndReceiveCommandAsync(string command, RconIdentifiers identifier)
			{
				var resultReturned = false;
				var timeOut = 0;
				var rconResponse = (WebRconResponse)null;

				EventHandler<WebSocketMessageEventArgs> handler = (s, e) =>
				{
					if (!resultReturned)
					{
						rconResponse = JsonConvert.DeserializeObject<WebRconResponse>(e.Data);
						resultReturned = (RconIdentifiers)rconResponse.Identifier == identifier;
						OnSendAndReceiveCommand?.Invoke(rconResponse);
					}
				};

				Connection.MessageReceived += handler;
				SendCommandAsync(command, identifier);

				while (!resultReturned)
				{
					if (timeOut > 10)
					{
						rconResponse = new WebRconResponse() { Message = "Response timed out" };
						OnSendAndReceiveCommand?.Invoke(rconResponse);
						break;
					}
					timeOut++;

					yield return WFS_05;
				}


				yield return null;
			}

			private void Read()
			{
				Connection.MessageReceived += (s, e) =>
				{
					var response = JsonConvert.DeserializeObject<WebRconResponse>(e.Data);
					var message = response.Message.TrimStart('\"').TrimEnd('\"').Replace("\\\"", "\"").Replace("\\\\\"", "\\\\\\\"").Replace("\\r\\n", "");

					OnRawMessage?.Invoke(message, e.RawData);
					Handle(message);
				};
			}
			private void Handle(string jsonData)
			{
				var data = (RconMessage)null;

				try
				{
					data = JsonConvert.DeserializeObject<RconMessage>(jsonData);
					if (string.IsNullOrEmpty(data.Type)) data = null;
					if (data == null) return;

					switch (data.Type)
					{
						case "Message":
							OnMessage?.Invoke(JsonConvert.DeserializeObject<Message>(jsonData));
							break;

						case "Command":
							OnCommandReceived?.Invoke(JsonConvert.DeserializeObject<Command>(jsonData));
							break;

						case "EntityUpdate":
							OnEntityUpdate?.Invoke(JsonConvert.DeserializeObject<EntityUpdate>(jsonData));
							break;
					}
				}
				catch
				{

				}
			}

			private void WebSocketConnection_SocketOpened(object sender, WebSocketOpenEventArgs e)
			{
				OnServerConnected?.Invoke();
			}
			private void WebSocketConnection_SocketClosed(object sender, WebSocketCloseEventArgs e)
			{
				OnServerDisconnected?.Invoke(e.Reason, e.Code);
			}
			private void WebSocketConnection_SocketError(object sender, WebSocketErrorEventArgs e)
			{
				OnServerError?.Invoke(e.Message, e.Exception);
			}

			#region Classes

			public class RconMessage
			{
				public virtual string Type { get; set; }
			}

			public class Vector3 : RconMessage
			{
				public override string Type => "Vector3";

				public float X { get; set; }
				public float Y { get; set; }
				public float Z { get; set; }

				public override string ToString()
				{
					return $"({X},{Y},{Z})";
				}
			}

			public class Message : RconMessage
			{
				public override string Type => "Message";

				public ulong Player { get; set; }
				public string Text { get; set; }
				public Channels Channel { get; set; }

				public enum Channels
				{
					Global = 0,
					Team = 1,
					Server = 2
				}
			}

			public class Command : RconMessage
			{
				public override string Type => "Command";

				public ulong Player { get; set; }
				public string Text { get; set; }
				public string[] Arguments { get; set; }
			}

			public class EntityUpdate : RconMessage
			{
				public new string Type = "EntityUpdate";

				public RconEntity.EntityData[] Entities { get; set; }
			}
		}

		public enum RconIdentifiers
		{
			Chat = -1,
			Generic = 0,
			Other = 9999,
			PlayerList = 1001,
			ServerInfo = 1002,
			ServerVersion = 1003,
			EchoRequest = 1004,
		}

		public interface IWebSocketConnection
		{
			event EventHandler<WebSocketMessageEventArgs> MessageReceived;
			event EventHandler<WebSocketOpenEventArgs> SocketOpened;
			event EventHandler<WebSocketCloseEventArgs> SocketClosed;
			event EventHandler<WebSocketErrorEventArgs> SocketError;

			bool IsOpen { get; }

			void Connect();
			void Disconnect();
			void Send(string data);
		}
		internal class WebSocketConnection : IWebSocketConnection
		{
			public event EventHandler<WebSocketMessageEventArgs> MessageReceived;
			public event EventHandler<WebSocketOpenEventArgs> SocketOpened;
			public event EventHandler<WebSocketCloseEventArgs> SocketClosed;
			public event EventHandler<WebSocketErrorEventArgs> SocketError;

			public bool IsOpen { get { return _webSocket.ReadyState == WebSocketState.Open; } }

			private WebSocket _webSocket;

			public WebSocketConnection(string ipAddress, string port, string password)
				: this($"ws://{ipAddress}:{port}/{password}")
			{

			}
			public WebSocketConnection(string connectionString)
			{
				_webSocket = new WebSocket(connectionString);
				_webSocket.OnMessage += WebSocket_OnMessage;
				_webSocket.OnOpen += WebSocket_OnOpen;
				_webSocket.OnClose += WebSocket_OnClose;
				_webSocket.OnError += WebSocket_OnError;
			}

			public void Connect()
			{
				_webSocket.ConnectAsync();
				_webSocket.Log.Output = (LogData log, string data) => { };
			}
			public void Disconnect()
			{
				_webSocket.CloseAsync(CloseStatusCode.Normal, "Disposing.");
			}
			public void Send(string data)
			{
				if (_webSocket.ReadyState == WebSocketState.Open)
				{
					_webSocket.SendAsync(data, null);
				}
			}

			private void WebSocket_OnMessage(object sender, MessageEventArgs e)
			{
				if (e.IsText)
				{
					MessageReceived?.Invoke(sender,
						new WebSocketMessageEventArgs(e.RawData, e.Data, string.IsNullOrEmpty(e.Data)));
				}
			}

			private void WebSocket_OnOpen(object sender, EventArgs e)
			{
				SocketOpened?.Invoke(sender,
					new WebSocketOpenEventArgs());
			}
			private void WebSocket_OnClose(object sender, CloseEventArgs e)
			{
				SocketClosed?.Invoke(sender,
					new WebSocketCloseEventArgs(e.Code, e.Reason, e.WasClean));
			}
			private void WebSocket_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
			{
				SocketError?.Invoke(sender,
					new WebSocketErrorEventArgs(e.Exception, e.Message));
			}
		}
		internal class WebSocketConnectionFactory
		{
			private readonly string ipAddress;
			private readonly string port;
			private readonly string password;

			public WebSocketConnectionFactory(string ipAddress, string port, string password)
			{
				this.ipAddress = ipAddress;
				this.port = port;
				this.password = password;
			}

			public IWebSocketConnection Create()
			{
				return new WebSocketConnection(ipAddress, port, password);
			}
		}

		public class WebSocketCloseEventArgs : EventArgs
		{
			public int Code { get; }

			public string Reason { get; }

			public bool WasClean { get; }

			public WebSocketCloseEventArgs(int code, string reason, bool wasClean)
			{
				Code = code;
				Reason = reason;
				WasClean = wasClean;
			}
		}
		public class WebSocketErrorEventArgs : EventArgs
		{
			public WebSocketErrorEventArgs(Exception exception, string message)
			{
				Exception = exception;
				Message = message;
			}

			public Exception Exception { get; }

			public string Message { get; }
		}
		public class WebSocketMessageEventArgs : EventArgs
		{
			public WebSocketMessageEventArgs(byte[] rawData, string data, bool isBinary)
			{
				RawData = rawData;
				Data = data;
				IsBinary = isBinary;
			}

			public bool IsBinary { get; }
			public byte[] RawData { get; }
			public string Data { get; }
		}
		public class WebSocketOpenEventArgs : EventArgs
		{
			public WebSocketOpenEventArgs()
			{

			}
		}

		#region Entities

		public class WebRconResponse
		{
			public string Message { get; set; }
			public int Identifier { get; set; }
			public string Type { get; set; }
			public string Stacktrace { get; set; }
		}
		public class WebRconRequest
		{
			public int Identifier { get; set; }
			public string Message { get; set; }
			public string Name { get; set; }
		}
		public class ServerVersion
		{
			public string Protocol { get; set; }
			public string BuildDate { get; set; }
			public string UnityVersion { get; set; }
			public string Changeset { get; set; }
			public string Branch { get; set; }
		}
		public class ServerPlayerInfo
		{
			public string SteamID { get; set; }
			public string OwnerSteamID { get; set; }
			public string DisplayName { get; set; }
			public int Ping { get; set; }
			public string Address { get; set; }
			public int ConnectedSeconds { get; set; }
			public float VoiationLevel { get; set; }
			public float CurrentLevel { get; set; }
			public float UnspentXp { get; set; }
			public float Health { get; set; }
		}
		public class ServerInfo
		{
			public string Hostname { get; set; }
			public int MaxPlayers { get; set; }
			public int Players { get; set; }
			public int Queued { get; set; }
			public int Joining { get; set; }
			public int EntityCount { get; set; }
			public string GameTime { get; set; }
			public int Uptime { get; set; }
			public string Map { get; set; }
			public float Framerate { get; set; }
			public int Memory { get; set; }
			public int Collections { get; set; }
			public int NetworkIn { get; set; }
			public int NetworkOut { get; set; }
			public bool Restarting { get; set; }
			public string SaveCreatedTime { get; set; }
		}

		#endregion

		#endregion
	}

#if UNITY_EDITOR
	[UnityEditor.CustomEditor(typeof(Rcon))]
	public class RconEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			var rcon = (Rcon)target;

			GUILayout.BeginHorizontal();
			rcon.Ip = EditorGUILayout.TextField("IP:Port", rcon.Ip);
			rcon.Port = EditorGUILayout.IntField(string.Empty, rcon.Port, GUILayout.Width(100));
			GUILayout.EndHorizontal();

			rcon.Password = EditorGUILayout.PasswordField("Password", rcon.Password);
			rcon.SyncServer = EditorGUILayout.Toggle("Sync Server", rcon.SyncServer);

			EditorGUILayout.Separator();

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			using (CarbonUtils.GUIColorChange.New(rcon.IsConnected ? Color.green : Color.grey, false))
			{
				GUILayout.Label(rcon.IsConnected ? "RCON successfully connected!" : "RCON is not connected.");
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			if (GUILayout.Button(rcon.IsConnected ? "Disconnect" : "Connect"))
			{
				if (rcon.IsConnected)
				{
					rcon.Disconnect();
				}
				else
				{
					rcon.Connect();
				}
			}
		}
	}
#endif
}
