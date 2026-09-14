using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000C5A RID: 3162
public static class TerminalLogger
{
	// Token: 0x060052FB RID: 21243
	[DllImport("kernel32.dll")]
	private static extern bool AllocConsole();

	// Token: 0x060052FC RID: 21244
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetStdHandle(int nStdHandle);

	// Token: 0x060052FD RID: 21245
	[DllImport("kernel32.dll")]
	private static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, ushort wAttributes);

	// Token: 0x060052FE RID: 21246
	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern bool SetConsoleTitle(string lpConsoleTitle);

	// Token: 0x060052FF RID: 21247 RVA: 0x00155AD0 File Offset: 0x00153CD0
	public static void InitIfRequested(string[] args)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "-terminal")
				{
					flag = true;
				}
				else if (args[i] == "-logfile" || args[i].StartsWith("-logfile:"))
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				TerminalLogger.AllocConsole();
				TerminalLogger.SetConsoleTitle("Borderlands Online - Debug Log");
				Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
				{
					AutoFlush = true
				});
				TerminalLogger.s_stdOut = TerminalLogger.GetStdHandle(-11);
			}
			if (flag2)
			{
				try
				{
					TerminalLogger.s_file = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.dataPath), "bol_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log"), false)
					{
						AutoFlush = true
					};
					TerminalLogger.s_file.WriteLine("=== Borderlands Online log {0} | {1} | Unity {2} ===", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Application.platform, Application.unityVersion);
				}
				catch (Exception ex)
				{
					TerminalLogger.s_file = null;
					if (TerminalLogger.s_stdOut != IntPtr.Zero)
					{
						Console.WriteLine("[TerminalLogger] file log init failed: " + ex.Message);
					}
				}
			}
			if (flag || TerminalLogger.s_file != null)
			{
				Application.RegisterLogCallback(new Application.LogCallback(TerminalLogger.OnLogMessage));
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06005300 RID: 21248 RVA: 0x00155C58 File Offset: 0x00153E58
	private static void OnLogMessage(string condition, string stackTrace, LogType type)
	{
		ushort num = 7;
		switch (type)
		{
		case LogType.Error:
			num = 12;
			break;
		case LogType.Assert:
			num = 11;
			break;
		case LogType.Warning:
			num = 14;
			break;
		case LogType.Exception:
			num = 13;
			break;
		}
		bool flag = (type == LogType.Exception || type == LogType.Error) && !string.IsNullOrEmpty(stackTrace);
		if (TerminalLogger.s_stdOut != IntPtr.Zero)
		{
			TerminalLogger.SetConsoleTextAttribute(TerminalLogger.s_stdOut, num);
			Console.WriteLine("[{0}] {1}", type, condition);
			if (flag)
			{
				Console.WriteLine(stackTrace);
			}
			TerminalLogger.SetConsoleTextAttribute(TerminalLogger.s_stdOut, 7);
		}
		if (TerminalLogger.s_file != null)
		{
			try
			{
				TerminalLogger.s_file.WriteLine("{0} [{1}] {2}", DateTime.Now.ToString("HH:mm:ss.fff"), type, condition);
				if (flag)
				{
					TerminalLogger.s_file.WriteLine(stackTrace);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	// Token: 0x04003D30 RID: 15664
	private static IntPtr s_stdOut = IntPtr.Zero;

	// Token: 0x04003D31 RID: 15665
	private static StreamWriter s_file = null;
}
