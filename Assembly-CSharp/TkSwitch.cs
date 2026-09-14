using System;
using Core;
using UnityEngine;

// Token: 0x02000119 RID: 281
public class TkSwitch : ScriptableObject
{
	// Token: 0x06000648 RID: 1608 RVA: 0x000074A5 File Offset: 0x000056A5
	public static TkSwitch smethod_0()
	{
		return ScriptableObject.CreateInstance<TkSwitch>();
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x000074AC File Offset: 0x000056AC
	public bool method_0(string string_0)
	{
		return this.cases != null && -1 != Array.IndexOf<string>(this.cases, string_0);
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x000074CB File Offset: 0x000056CB
	public bool method_1()
	{
		return this.m_defaultCase >= 0 && this.m_defaultCase < this.cases.Length;
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x0600064B RID: 1611 RVA: 0x000074E9 File Offset: 0x000056E9
	public string String_0
	{
		get
		{
			if (this.method_1())
			{
				return this.cases[this.m_defaultCase];
			}
			DebugUtils.LogWarning(LogCategory.Audio, "Tkswitch defaultCase is a invalid value in" + base.name);
			return null;
		}
	}

	// Token: 0x040005BB RID: 1467
	public int m_defaultCase;

	// Token: 0x040005BC RID: 1468
	public string[] cases;

	// Token: 0x0200011A RID: 282
	// (Invoke) Token: 0x0600064D RID: 1613
	public delegate string SolveDelegate(Component go, string switchType);
}
