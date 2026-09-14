using System;

// Token: 0x020002CC RID: 716
public interface ICharacterServiceNotificationListerner
{
	// Token: 0x06000F87 RID: 3975
	void OnGotMyCurrencies(CurrencyInfo currency);

	// Token: 0x06000F88 RID: 3976
	void OnExperienceUpdated(int experience);

	// Token: 0x06000F89 RID: 3977
	void OnGetPersonalSettings(string strSettings);

	// Token: 0x06000F8A RID: 3978
	void OnSetPersonalSettings(int iResult);

	// Token: 0x06000F8B RID: 3979
	void OnGetCharacterSettings(string strSettings);

	// Token: 0x06000F8C RID: 3980
	void OnSetCharacterSettings(int iResult);
}
