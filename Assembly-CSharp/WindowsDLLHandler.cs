using System;
using System.IO;
using System.Runtime.InteropServices;

// Token: 0x0200065D RID: 1629
public static class WindowsDLLHandler
{
	// Token: 0x0600291C RID: 10524 RVA: 0x000C2254 File Offset: 0x000C0454
	public static ulong smethod_0()
	{
		WindowsDLLHandler.MEMORYSTATUSEX memorystatusex = new WindowsDLLHandler.MEMORYSTATUSEX();
		WindowsDLLHandler.GlobalMemoryStatusEx(memorystatusex);
		return memorystatusex.ullAvailPhys;
	}

	// Token: 0x0600291D RID: 10525
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool GlobalMemoryStatusEx([In] [Out] WindowsDLLHandler.MEMORYSTATUSEX memorystatusex_0);

	// Token: 0x0600291E RID: 10526
	[DllImport("kernel32.dll")]
	private static extern IntPtr GetCurrentProcess();

	// Token: 0x0600291F RID: 10527
	[DllImport("psapi.dll")]
	private static extern bool GetProcessMemoryInfo(IntPtr intptr_0, out WindowsDLLHandler.PROCESS_MEMORY_COUNTERS process_MEMORY_COUNTERS_0, uint uint_0);

	// Token: 0x06002920 RID: 10528 RVA: 0x000C2274 File Offset: 0x000C0474
	public static void smethod_1(out uint uint_0, out uint uint_1)
	{
		uint_0 = 0U;
		uint_1 = 0U;
		IntPtr currentProcess = WindowsDLLHandler.GetCurrentProcess();
		WindowsDLLHandler.PROCESS_MEMORY_COUNTERS process_MEMORY_COUNTERS;
		process_MEMORY_COUNTERS.cb = 40U;
		if (WindowsDLLHandler.GetProcessMemoryInfo(currentProcess, out process_MEMORY_COUNTERS, process_MEMORY_COUNTERS.cb))
		{
			uint_0 = process_MEMORY_COUNTERS.WorkingSetSize;
			uint_1 = process_MEMORY_COUNTERS.PeakWorkingSetSize;
		}
	}

	// Token: 0x06002921 RID: 10529
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool GetFileTime(IntPtr intptr_0, ref WindowsDLLHandler.FILETIME filetime_0, ref WindowsDLLHandler.FILETIME filetime_1, ref WindowsDLLHandler.FILETIME filetime_2);

	// Token: 0x06002922 RID: 10530 RVA: 0x000C22BC File Offset: 0x000C04BC
	public static long smethod_2(string string_0)
	{
		long num = 0L;
		if (File.Exists(string_0))
		{
			FileAttributes attributes = File.GetAttributes(string_0);
			File.SetAttributes(string_0, FileAttributes.Normal);
			FileStream fileStream = new FileStream(string_0, FileMode.Open);
			WindowsDLLHandler.FILETIME filetime = default(WindowsDLLHandler.FILETIME);
			WindowsDLLHandler.FILETIME filetime2 = default(WindowsDLLHandler.FILETIME);
			WindowsDLLHandler.FILETIME filetime3 = default(WindowsDLLHandler.FILETIME);
			WindowsDLLHandler.GetFileTime(fileStream.Handle, ref filetime, ref filetime2, ref filetime3);
			fileStream.Close();
			File.SetAttributes(string_0, attributes);
			num |= (long)((ulong)filetime3.dwHighDateTime);
			num <<= 32;
			num |= (long)((ulong)filetime3.dwLowDateTime);
		}
		return num;
	}

	// Token: 0x06002923 RID: 10531
	[DllImport("RenderingPlugin")]
	public static extern bool GetPerfKitInfo(out WindowsDLLHandler.PERFKIT_OUTPUT_COUNTERS perfkit_OUTPUT_COUNTERS_0);

	// Token: 0x0200065E RID: 1630
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class MEMORYSTATUSEX
	{
		// Token: 0x06002924 RID: 10532 RVA: 0x0001AFF0 File Offset: 0x000191F0
		public MEMORYSTATUSEX()
		{
			this.dwLength = (uint)Marshal.SizeOf(typeof(WindowsDLLHandler.MEMORYSTATUSEX));
		}

		// Token: 0x04001D64 RID: 7524
		public uint dwLength;

		// Token: 0x04001D65 RID: 7525
		public uint dwMemoryLoad;

		// Token: 0x04001D66 RID: 7526
		public ulong ullTotalPhys;

		// Token: 0x04001D67 RID: 7527
		public ulong ullAvailPhys;

		// Token: 0x04001D68 RID: 7528
		public ulong ullTotalPageFile;

		// Token: 0x04001D69 RID: 7529
		public ulong ullAvailPageFile;

		// Token: 0x04001D6A RID: 7530
		public ulong ullTotalVirtual;

		// Token: 0x04001D6B RID: 7531
		public ulong ullAvailVirtual;

		// Token: 0x04001D6C RID: 7532
		public ulong ullAvailExtendedVirtual;
	}

	// Token: 0x0200065F RID: 1631
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	private struct PROCESS_MEMORY_COUNTERS
	{
		// Token: 0x04001D6D RID: 7533
		public uint cb;

		// Token: 0x04001D6E RID: 7534
		public uint PageFaultCount;

		// Token: 0x04001D6F RID: 7535
		public uint PeakWorkingSetSize;

		// Token: 0x04001D70 RID: 7536
		public uint WorkingSetSize;

		// Token: 0x04001D71 RID: 7537
		public uint QuotaPeakPagedPoolUsage;

		// Token: 0x04001D72 RID: 7538
		public uint QuotaPagedPoolUsage;

		// Token: 0x04001D73 RID: 7539
		public uint QuotaPeakNonPagedPoolUsage;

		// Token: 0x04001D74 RID: 7540
		public uint QuotaNonPagedPoolUsage;

		// Token: 0x04001D75 RID: 7541
		public uint PagefileUsage;

		// Token: 0x04001D76 RID: 7542
		public uint PeakPagefileUsage;
	}

	// Token: 0x02000660 RID: 1632
	private struct FILETIME
	{
		// Token: 0x04001D77 RID: 7543
		public uint dwLowDateTime;

		// Token: 0x04001D78 RID: 7544
		public uint dwHighDateTime;
	}

	// Token: 0x02000661 RID: 1633
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct PERFKIT_OUTPUT_COUNTERS
	{
		// Token: 0x04001D79 RID: 7545
		public int drawCall;
	}
}
