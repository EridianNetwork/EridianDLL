using System;
using System.Collections.Generic;

// Token: 0x020005FA RID: 1530
public class LocalizeSystem
{
	// Token: 0x060026D6 RID: 9942 RVA: 0x0001A1E8 File Offset: 0x000183E8
	private LocalizeSystem()
	{
	}

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x060026D7 RID: 9943 RVA: 0x0001A206 File Offset: 0x00018406
	public string String_0
	{
		get
		{
			return this._curLanguage;
		}
	}

	// Token: 0x060026D8 RID: 9944 RVA: 0x0001A20E File Offset: 0x0001840E
	public static LocalizeSystem smethod_0()
	{
		if (LocalizeSystem.s_instance == null)
		{
			LocalizeSystem.s_instance = new LocalizeSystem();
		}
		return LocalizeSystem.s_instance;
	}

	// Token: 0x060026D9 RID: 9945 RVA: 0x0001A226 File Offset: 0x00018426
	public void method_0(string string_0)
	{
		if (this._curLanguage != string_0)
		{
			this._curLanguage = string_0;
			this.OnLanguageChanged();
		}
	}

	// Token: 0x060026DA RID: 9946 RVA: 0x000BB710 File Offset: 0x000B9910
	public void method_1<T>(IContentManager icontentManager_0) where T : ILocalizedContent
	{
		if (icontentManager_0 == null)
		{
			return;
		}
		if (this._dicContentMgrs.ContainsKey(typeof(T)))
		{
			this._dicContentMgrs[typeof(T)] = icontentManager_0;
		}
		else
		{
			this._dicContentMgrs.Add(typeof(T), icontentManager_0);
		}
		icontentManager_0.OnLanguageChange(this._curLanguage);
	}

	// Token: 0x060026DB RID: 9947 RVA: 0x0001A243 File Offset: 0x00018443
	public virtual void vmethod_0(ILocalizedContent ilocalizedContent_0)
	{
		if (ilocalizedContent_0 == null)
		{
			return;
		}
		if (this._dicContentMgrs.ContainsKey(ilocalizedContent_0.GetType()))
		{
			this._dicContentMgrs[ilocalizedContent_0.GetType()].OnContentAdded(ilocalizedContent_0);
		}
	}

	// Token: 0x060026DC RID: 9948 RVA: 0x000BB774 File Offset: 0x000B9974
	protected virtual void OnLanguageChanged()
	{
		foreach (KeyValuePair<Type, IContentManager> keyValuePair in this._dicContentMgrs)
		{
			keyValuePair.Value.OnLanguageChange(this._curLanguage);
		}
	}

	// Token: 0x04001C3C RID: 7228
	protected string _curLanguage = "INT";

	// Token: 0x04001C3D RID: 7229
	protected Dictionary<Type, IContentManager> _dicContentMgrs = new Dictionary<Type, IContentManager>();

	// Token: 0x04001C3E RID: 7230
	private static LocalizeSystem s_instance;
}
