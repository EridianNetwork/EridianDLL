using System;

// Token: 0x020000F4 RID: 244
public class AudioEvents
{
	// Token: 0x060005D1 RID: 1489 RVA: 0x000517E8 File Offset: 0x0004F9E8
	public static string smethod_0(AudioEventName audioEventName_0)
	{
		if (audioEventName_0 != AudioEventName.Wep_Ele_Corrosive_DoT)
		{
			return audioEventName_0.ToString();
		}
		return AudioEventName.Wep_Ele_Shock_DoT.ToString();
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00007063 File Offset: 0x00005263
	public static bool smethod_1(string string_0)
	{
		return Enum.IsDefined(typeof(AudioEventName), string_0);
	}
}
