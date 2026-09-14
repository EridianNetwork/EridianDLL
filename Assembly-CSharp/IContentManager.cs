using System;

// Token: 0x020005F9 RID: 1529
public abstract class IContentManager
{
	// Token: 0x060026D4 RID: 9940
	public abstract void OnLanguageChange(string language);

	// Token: 0x060026D5 RID: 9941
	public abstract void OnContentAdded(ILocalizedContent content);
}
