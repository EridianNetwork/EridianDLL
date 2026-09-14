using System;
using Core;

// Token: 0x02000A92 RID: 2706
public struct AssertInfo
{
	// Token: 0x0600493E RID: 18750 RVA: 0x0002FE17 File Offset: 0x0002E017
	public AssertInfo(AssertInfo.InfoSource infoSource_0, LogCategory logCategory_0, string string_0, string string_1)
	{
		this.m_from = infoSource_0;
		this.m_type = logCategory_0;
		this.m_msg = string_0;
		this.m_stackTrace = string_1;
	}

	// Token: 0x0600493F RID: 18751 RVA: 0x000039EC File Offset: 0x00001BEC
	public static AssertInfo.InfoSource smethod_0()
	{
		return AssertInfo.InfoSource.FromClient;
	}

	// Token: 0x06004940 RID: 18752 RVA: 0x0002FE36 File Offset: 0x0002E036
	public override int GetHashCode()
	{
		return AssertInfo.smethod_1(this.m_from, this.m_type, this.m_msg, this.m_stackTrace);
	}

	// Token: 0x06004941 RID: 18753 RVA: 0x0002FE55 File Offset: 0x0002E055
	public static int smethod_1(AssertInfo.InfoSource infoSource_0, LogCategory logCategory_0, string string_0, string string_1)
	{
		return infoSource_0.GetHashCode() * 3 + logCategory_0.GetHashCode() * 5 + string_0.GetHashCode() * 7 + string_1.GetHashCode() * 11;
	}

	// Token: 0x040035A8 RID: 13736
	public AssertInfo.InfoSource m_from;

	// Token: 0x040035A9 RID: 13737
	public LogCategory m_type;

	// Token: 0x040035AA RID: 13738
	public string m_msg;

	// Token: 0x040035AB RID: 13739
	public string m_stackTrace;

	// Token: 0x02000A93 RID: 2707
	public enum InfoSource
	{
		// Token: 0x040035AD RID: 13741
		FromHost,
		// Token: 0x040035AE RID: 13742
		FromClient
	}
}
