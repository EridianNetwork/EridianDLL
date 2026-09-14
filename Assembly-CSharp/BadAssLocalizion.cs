using System;
using ns0;
using UnityEngine;

// Token: 0x020005F4 RID: 1524
public class BadAssLocalizion : MonoBehaviour
{
	// Token: 0x060026C0 RID: 9920 RVA: 0x0001A0BA File Offset: 0x000182BA
	private void Start()
	{
		this._locStringMgr = new LocalizedStringManager();
		LocalizeSystem.smethod_0().method_1<LocalizedString>(this._locStringMgr);
		LocalizeSystem.smethod_0().method_0(MonoSingleton<AppManager>.Instance.m_language);
	}

	// Token: 0x060026C1 RID: 9921 RVA: 0x0001A0EB File Offset: 0x000182EB
	public void method_0(string string_0)
	{
		LocalizeSystem.smethod_0().method_0(string_0);
	}

	// Token: 0x04001C2E RID: 7214
	private LocalizedStringManager _locStringMgr;

	// Token: 0x04001C2F RID: 7215
	private static readonly string[] _langCodes = new string[] { "INT", "CHI" };

	// Token: 0x020005F5 RID: 1525
	public enum BADASS_SUPPORTED_LANGUAGE
	{
		// Token: 0x04001C31 RID: 7217
		LANG_INT,
		// Token: 0x04001C32 RID: 7218
		LANG_CHI
	}
}
