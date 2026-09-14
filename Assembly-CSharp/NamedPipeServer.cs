using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Core;
using Microsoft.Win32.SafeHandles;

// Token: 0x0200064D RID: 1613
public class NamedPipeServer
{
	// Token: 0x060028C5 RID: 10437 RVA: 0x0001AC1E File Offset: 0x00018E1E
	public NamedPipeServer(string string_0, int int_0)
	{
		this.pipeName = string_0;
		this.ClientType = int_0;
	}

	// Token: 0x060028C6 RID: 10438
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern SafeFileHandle CreateNamedPipe(string string_0, uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, IntPtr intptr_0);

	// Token: 0x060028C7 RID: 10439
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern int ConnectNamedPipe(SafeFileHandle safeFileHandle_0, IntPtr intptr_0);

	// Token: 0x060028C8 RID: 10440
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern int DisconnectNamedPipe(SafeFileHandle safeFileHandle_0);

	// Token: 0x060028C9 RID: 10441 RVA: 0x0001AC34 File Offset: 0x00018E34
	public bool Start()
	{
		this.listenThread = new Thread(new ThreadStart(this.method_0));
		this.listenThread.Start();
		return this.Boolean_0;
	}

	// Token: 0x060028CA RID: 10442 RVA: 0x000C1048 File Offset: 0x000BF248
	private void method_0()
	{
		for (;;)
		{
			this.clientHandle = NamedPipeServer.CreateNamedPipe(this.pipeName, 1073741827U, 0U, 255U, 100U, 100U, 0U, IntPtr.Zero);
			if (this.clientHandle.IsInvalid)
			{
				break;
			}
			int num = NamedPipeServer.ConnectNamedPipe(this.clientHandle, IntPtr.Zero);
			if (num == 0)
			{
				return;
			}
			this.clientse = new NamedPipeServer.Client();
			this.clientse.handle = this.clientHandle;
			this.clientse.stream = new FileStream(this.clientse.handle.DangerousGetHandle(), FileAccess.ReadWrite, true, 100);
			if (this.ClientType == 0)
			{
				Thread thread = new Thread(new ThreadStart(this.method_1));
				thread.Start();
				DebugUtils.Log(LogCategory.Tool, "client read open");
			}
		}
	}

	// Token: 0x060028CB RID: 10443 RVA: 0x000C1114 File Offset: 0x000BF314
	private void method_1()
	{
		byte[] array = null;
		ASCIIEncoding asciiencoding = new ASCIIEncoding();
		for (;;)
		{
			int num = 0;
			try
			{
				array = new byte[100];
				num = this.clientse.stream.Read(array, 0, 100);
			}
			catch
			{
				break;
			}
			if (num == 0)
			{
				break;
			}
			int num2 = 0;
			int num3 = 0;
			while (num3 < 100 && array[num3].ToString("x2") != "cc")
			{
				num2++;
				num3++;
			}
			if (num2 > 0)
			{
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(array, 0, array2, 0, num2);
				Console.WriteLine(string.Concat(new object[]
				{
					"C# App: Received ",
					num2,
					" Bytes: ",
					asciiencoding.GetString(array2, 0, num2)
				}));
				array.Initialize();
			}
		}
		this.clientse.stream.Close();
		this.clientse.handle.Close();
	}

	// Token: 0x060028CC RID: 10444 RVA: 0x000C1218 File Offset: 0x000BF418
	public void method_2(ProfileSample profileSample_0, NamedPipeServer.Client client_0)
	{
		if (client_0.stream.CanWrite)
		{
			byte[] array = profileSample_0.method_4();
			client_0.stream.Write(array, 0, array.Length);
			client_0.stream.Flush();
		}
	}

	// Token: 0x060028CD RID: 10445 RVA: 0x0001AC5E File Offset: 0x00018E5E
	public bool method_3()
	{
		NamedPipeServer.DisconnectNamedPipe(this.clientHandle);
		this.listenThread.Abort();
		this.clientHandle.Dispose();
		this.clientse = null;
		DebugUtils.Log(LogCategory.Tool, "Server stops");
		return !this.Boolean_0;
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x060028CE RID: 10446 RVA: 0x0001AC9E File Offset: 0x00018E9E
	public bool Boolean_0
	{
		get
		{
			return this.listenThread.IsAlive;
		}
	}

	// Token: 0x04001D1C RID: 7452
	public const uint DUPLEX = 3U;

	// Token: 0x04001D1D RID: 7453
	public const uint FILE_FLAG_OVERLAPPED = 1073741824U;

	// Token: 0x04001D1E RID: 7454
	public const int BUFFER_SIZE = 100;

	// Token: 0x04001D1F RID: 7455
	public NamedPipeServer.Client clientse;

	// Token: 0x04001D20 RID: 7456
	public string pipeName;

	// Token: 0x04001D21 RID: 7457
	private Thread listenThread;

	// Token: 0x04001D22 RID: 7458
	private SafeFileHandle clientHandle;

	// Token: 0x04001D23 RID: 7459
	public int ClientType;

	// Token: 0x0200064E RID: 1614
	public class Client
	{
		// Token: 0x04001D24 RID: 7460
		public SafeFileHandle handle;

		// Token: 0x04001D25 RID: 7461
		public FileStream stream;
	}
}
