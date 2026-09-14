using System;

// Token: 0x02000435 RID: 1077
public class AntiAddiction
{
	// Token: 0x06001A87 RID: 6791 RVA: 0x00087C54 File Offset: 0x00085E54
	public static float smethod_0(AntiAddiction.Level level_0)
	{
		if (level_0 == AntiAddiction.Level.HalfRewards)
		{
			return 0.5f;
		}
		if (level_0 != AntiAddiction.Level.NoRewards)
		{
			return 1f;
		}
		return 0f;
	}

	// Token: 0x06001A88 RID: 6792 RVA: 0x00013546 File Offset: 0x00011746
	public static AntiAddiction.Level smethod_1(int int_0)
	{
		if ((float)int_0 >= 300f)
		{
			return AntiAddiction.Level.NoRewards;
		}
		if ((float)int_0 >= 180f)
		{
			return AntiAddiction.Level.HalfRewards;
		}
		return AntiAddiction.Level.NormalRewards;
	}

	// Token: 0x06001A89 RID: 6793 RVA: 0x00087C7C File Offset: 0x00085E7C
	public static string smethod_2(int int_0)
	{
		string text = null;
		if ((float)int_0 >= 300f)
		{
			text = LocalizedString.smethod_0(new LocalizedString("Anti_Addiction_5H"));
		}
		else if ((float)int_0 >= 210f)
		{
			text = LocalizedString.smethod_0(new LocalizedString("Anti_Addiction_4H"));
		}
		else if ((float)int_0 >= 180f)
		{
			text = LocalizedString.smethod_0(new LocalizedString("Anti_Addiction_3H"));
		}
		else if ((float)int_0 >= 120f)
		{
			text = LocalizedString.smethod_0(new LocalizedString("Anti_Addiction_2H"));
		}
		else if ((float)int_0 >= 60f)
		{
			text = LocalizedString.smethod_0(new LocalizedString("Anti_Addiction_1H"));
		}
		return text;
	}

	// Token: 0x02000436 RID: 1078
	public enum Level
	{
		// Token: 0x0400118C RID: 4492
		NormalRewards,
		// Token: 0x0400118D RID: 4493
		HalfRewards,
		// Token: 0x0400118E RID: 4494
		NoRewards
	}
}
