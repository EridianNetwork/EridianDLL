using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

// Token: 0x020002BC RID: 700
public class ShandaWrapper : MonoBehaviour
{
	// Token: 0x06000F10 RID: 3856
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void Setup(int int_0, string string_0, string string_1, int int_1, int int_2);

	// Token: 0x06000F11 RID: 3857
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool Run(StringBuilder stringBuilder_0);

	// Token: 0x06000F12 RID: 3858
	[DllImport("ShandaLoginWrapper", SetLastError = true)]
	private static extern void Exit();

	// Token: 0x06000F13 RID: 3859
	[DllImport("ShandaLoginWrapper", SetLastError = true)]
	private static extern void OpenWidget();

	// Token: 0x06000F14 RID: 3860
	[DllImport("ShandaLoginWrapper", SetLastError = true)]
	private static extern void StartGPK();

	// Token: 0x06000F15 RID: 3861
	[DllImport("ShandaLoginWrapper", SetLastError = true)]
	private static extern void StopGPK();

	// Token: 0x06000F16 RID: 3862
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	private static extern bool SetDynCode(IntPtr intptr_0, int int_0);

	// Token: 0x06000F17 RID: 3863
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	private static extern int ProcessAuth(IntPtr intptr_0, int int_0);

	// Token: 0x06000F18 RID: 3864 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x0000D2A9 File Offset: 0x0000B4A9
	private void Start()
	{
		this.m_isActive = false;
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x00074770 File Offset: 0x00072970
	public static void smethod_0(byte[] byte_0)
	{
		int num = Marshal.SizeOf(byte_0[0]) * byte_0.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.Copy(byte_0, 0, intPtr, byte_0.Length);
		}
		finally
		{
		}
		ShandaWrapper.SetDynCode(intPtr, byte_0.Length);
		Marshal.FreeHGlobal(intPtr);
	}

	// Token: 0x06000F1B RID: 3867 RVA: 0x000747C4 File Offset: 0x000729C4
	public static void smethod_1(ref byte[] byte_0)
	{
		int num = Marshal.SizeOf(byte_0[0]) * byte_0.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.Copy(byte_0, 0, intPtr, byte_0.Length);
		}
		finally
		{
		}
		ShandaWrapper.ProcessAuth(intPtr, byte_0.Length);
		Marshal.Copy(intPtr, byte_0, 0, byte_0.Length);
		Marshal.FreeHGlobal(intPtr);
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x0000D2B2 File Offset: 0x0000B4B2
	public static void smethod_2()
	{
		ShandaWrapper.OpenWidget();
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnDestroy()
	{
	}

	// Token: 0x04000D63 RID: 3427
	public static int ApplicationId = 991002125;

	// Token: 0x04000D64 RID: 3428
	public static string ApplicationName = "BorderlandsOnline";

	// Token: 0x04000D65 RID: 3429
	public static int AreaID;

	// Token: 0x04000D66 RID: 3430
	public static int GroupId;

	// Token: 0x04000D67 RID: 3431
	public static string ShandaTicket;

	// Token: 0x04000D68 RID: 3432
	private bool m_isActive;
}
