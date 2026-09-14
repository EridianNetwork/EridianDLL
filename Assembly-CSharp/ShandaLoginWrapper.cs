using System;
using System.Runtime.InteropServices;
using System.Text;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020002BB RID: 699
public class ShandaLoginWrapper : MonoBehaviour
{
	// Token: 0x06000F09 RID: 3849
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void Setup(int int_0, string string_0, string string_1, int int_1, int int_2);

	// Token: 0x06000F0A RID: 3850
	[DllImport("ShandaLoginWrapper", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool Run(StringBuilder stringBuilder_0);

	// Token: 0x06000F0B RID: 3851
	[DllImport("ShandaLoginWrapper", SetLastError = true)]
	private static extern void Exit();

	// Token: 0x06000F0C RID: 3852 RVA: 0x000746D8 File Offset: 0x000728D8
	private void Start()
	{
		if (MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
		{
			this.m_isActive = true;
			ShandaLoginWrapper.Setup(ShandaLoginWrapper.ApplicationId, ShandaLoginWrapper.ApplicationName, ShandaLoginWrapper.VersionId, 1, 1);
			StringBuilder stringBuilder = new StringBuilder(255);
			if (ShandaLoginWrapper.Run(stringBuilder))
			{
				DebugUtils.Log(LogCategory.Framework, "ShandaLogin.Start Done [" + stringBuilder + "]");
				ShandaLoginWrapper.ShandaTicket = stringBuilder.ToString();
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().accountName = ShandaLoginWrapper.ShandaTicket;
			}
			else
			{
				this.m_isActive = false;
				ShandaLoginWrapper.Exit();
				MonoSingleton<AppManager>.Instance.method_8();
			}
		}
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x0000D27D File Offset: 0x0000B47D
	private void OnDestroy()
	{
		if (this.m_isActive)
		{
			this.m_isActive = false;
			ShandaLoginWrapper.Exit();
		}
	}

	// Token: 0x04000D5E RID: 3422
	public static int ApplicationId = 991002125;

	// Token: 0x04000D5F RID: 3423
	public static string ApplicationName = "BorderlandsOnline";

	// Token: 0x04000D60 RID: 3424
	public static string VersionId = "0.7.0.0";

	// Token: 0x04000D61 RID: 3425
	public static string ShandaTicket;

	// Token: 0x04000D62 RID: 3426
	private bool m_isActive;
}
