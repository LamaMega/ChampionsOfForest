using System;
using System.IO;
using System.Runtime.InteropServices;

using UnityEngine.Windows.Speech;

namespace ChampionsOfForest.Network
{
	public class COTFCommand<ParamT> where ParamT : struct
	{
		public int commandIndex = 0;
		private static COTFCommand<ParamT> instance;

		public delegate void ReceivedDelegate(ParamT p);

		private ReceivedDelegate receivedDelegate;

		public static void Initialize(ReceivedDelegate receivedDelegate)
		{
			if (instance == null)
			{
				instance = new COTFCommand<ParamT>();
				instance.commandIndex = CommandReader.curr_cmd_index++;
				CommandReader.callbacks.Add(instance.commandIndex, COTFCommand<ParamT>.Received);
				instance.receivedDelegate = receivedDelegate;

				var type = typeof(COTFCommand<ParamT>);
				ModAPI.Log.Write($"command {instance.commandIndex} registered: {type.Name}");
			}
		}

		static byte[] GetBytes(ParamT p)
		{
			int size = Marshal.SizeOf(p);
			byte[] arr = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(p, ptr, true);
			Marshal.Copy(ptr, arr, 0, size);
			Marshal.FreeHGlobal(ptr);
			return arr;
		}
		static ParamT GetParam(BinaryReader reader)
		{
			int size = Marshal.SizeOf(default(ParamT));
			IntPtr ptr = Marshal.AllocHGlobal(size);
			byte[] arr = reader.ReadBytes(size);
			Marshal.Copy(arr, 0, ptr, size);
			var param = (ParamT)Marshal.PtrToStructure(ptr, typeof(ParamT));
			Marshal.FreeHGlobal(ptr);
			return param;
		}

		public static void Send(NetworkManager.Target target, in ParamT param)
		{
			using (MemoryStream answerStream = new MemoryStream())
			{
				using (BinaryWriter w = new BinaryWriter(answerStream))
				{
					w.Write(instance.commandIndex);
					w.Write(GetBytes(param));
					w.Close();
				}
				NetworkManager.SendLine(answerStream.ToArray(), target);
				answerStream.Close();
			}
		}
		public static void Send(BoltConnection target_connection, ParamT param)
		{
			using (MemoryStream answerStream = new MemoryStream())
			{
				using (BinaryWriter w = new BinaryWriter(answerStream))
				{
					w.Write(instance.commandIndex);
					w.Write(GetBytes(param));
					w.Close();
				}
				NetworkManager.SendLine(answerStream.ToArray(), target_connection);
				answerStream.Close();
			}
		}
		public static void Received(BinaryReader r)
		{
			var p = GetParam(r);
			instance.receivedDelegate.Invoke(p);
			r.Close();
		}
	}
}
