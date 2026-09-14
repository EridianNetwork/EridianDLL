using System;
using UnityEngine;

// Token: 0x0200064C RID: 1612
public class ConcurrentEditInfo : MonoBehaviour
{
	// Token: 0x060028C3 RID: 10435 RVA: 0x000C1014 File Offset: 0x000BF214
	public static string smethod_0()
	{
		return string.Format("{0}_{1}", Environment.GetEnvironmentVariable("COMPUTERNAME"), DateTime.Now.ToString("s"));
	}

	// Token: 0x060028C4 RID: 10436 RVA: 0x0001AC11 File Offset: 0x00018E11
	public void method_0()
	{
		this.m_ConcurrentEditInfo = ConcurrentEditInfo.smethod_0();
	}

	// Token: 0x04001D1B RID: 7451
	public string m_ConcurrentEditInfo = string.Empty;
}
