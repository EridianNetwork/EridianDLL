using System;
using ns0;

// Token: 0x020002CE RID: 718
public class CharacterServiceWrapperOnline : ICharacterServiceWrapper, IServiceWrapper
{
	// Token: 0x06000FBA RID: 4026 RVA: 0x000755A8 File Offset: 0x000737A8
	public void imethod_0()
	{
		this.m_localPlayer = MonoSingleton<PlayerManager>.Instance.method_2();
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_1(new OnGetPresence(this.OnGetPresence));
		OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>.Prop_0.imethod_2(new OnCurrenciesUpdated(this.OnCurrenciesUpdated));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_11(new OnExperienceUpdated(this.OnExperienceUpdated));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_14(new OnGetPersonalSettings(this.method_4));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_15(new OnSetPersonalSettings(this.method_5));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_20(new OnSetCharacterSettings(this.method_1));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_19(new OnGetCharacterSettings(this.method_0));
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x0000D725 File Offset: 0x0000B925
	private void method_0(string string_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGetCharacterSettings(string_0);
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x0000D732 File Offset: 0x0000B932
	private void method_1(int int_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnSetCharacterSettings(int_0);
	}

	// Token: 0x06000FBD RID: 4029 RVA: 0x0000D73F File Offset: 0x0000B93F
	public void method_2(CurrencyInfo currencyInfo_0)
	{
		this.m_currency = currencyInfo_0;
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x0000D748 File Offset: 0x0000B948
	private void OnGetPresence(Presence presence)
	{
		this.m_townId = -1;
		if (presence != null)
		{
			this.m_townId = presence.mCurrentTown;
		}
		if (this.m_townId == -1)
		{
			this.m_townId = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_21();
		}
		this.m_initialized = true;
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x0000D780 File Offset: 0x0000B980
	public bool imethod_1()
	{
		if (this.m_initialized)
		{
			this.m_localPlayer = MonoSingleton<PlayerManager>.Instance.method_2();
			if (this.m_localPlayer != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x0000D7A5 File Offset: 0x0000B9A5
	public int imethod_2()
	{
		return this.m_localPlayer.m_exp;
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x0000D7B2 File Offset: 0x0000B9B2
	public int imethod_3()
	{
		return MonoSingleton<LevelingManager>.Instance.method_3(this.m_localPlayer.m_avatarDna.method_5(), this.m_localPlayer.m_exp);
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x0000D7D9 File Offset: 0x0000B9D9
	public string imethod_4()
	{
		return this.m_localPlayer.m_name;
	}

	// Token: 0x06000FC3 RID: 4035 RVA: 0x0000D7E6 File Offset: 0x0000B9E6
	public int imethod_5()
	{
		return this.m_localPlayer.m_id;
	}

	// Token: 0x06000FC4 RID: 4036 RVA: 0x0000D7E6 File Offset: 0x0000B9E6
	public int imethod_8()
	{
		return this.m_localPlayer.m_id;
	}

	// Token: 0x06000FC5 RID: 4037 RVA: 0x0000D7F3 File Offset: 0x0000B9F3
	public AvatarDNA imethod_6()
	{
		return this.m_localPlayer.m_avatarDna;
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x0000D800 File Offset: 0x0000BA00
	public CurrencyInfo imethod_7()
	{
		return this.m_currency;
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x0000D808 File Offset: 0x0000BA08
	public void imethod_9()
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGotCurrencies(this.m_currency);
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x0000D808 File Offset: 0x0000BA08
	private void OnCurrenciesUpdated(int bondCurrency, int circulateCurrency, int specialCurrency)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGotCurrencies(this.m_currency);
	}

	// Token: 0x06000FC9 RID: 4041 RVA: 0x0000D81A File Offset: 0x0000BA1A
	public int method_3()
	{
		return this.m_townId;
	}

	// Token: 0x06000FCA RID: 4042 RVA: 0x00075660 File Offset: 0x00073860
	public void OnExperienceUpdated(int experience)
	{
		if (this.m_localPlayer != null && MonoSingleton<Session>.Instance != null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			int num = MonoSingleton<LevelingManager>.Instance.method_3(this.imethod_6().method_5(), this.m_localPlayer.m_exp);
			int num2 = MonoSingleton<LevelingManager>.Instance.method_3(this.imethod_6().method_5(), experience);
			this.m_localPlayer.m_exp = experience;
			localPlayer.m_exp = experience;
			if (num2 > num)
			{
				MonoSingleton<MessageRelayManager>.Instance.RelayMessage("OnLevelUp", localPlayer);
			}
		}
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnExperienceUpdated(experience);
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x0000D822 File Offset: 0x0000BA22
	public void imethod_10()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_5();
	}

	// Token: 0x06000FCC RID: 4044 RVA: 0x0000D82E File Offset: 0x0000BA2E
	public void imethod_12()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_8();
	}

	// Token: 0x06000FCD RID: 4045 RVA: 0x0000D83A File Offset: 0x0000BA3A
	private void method_4(string string_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGetPersonalSettings(string_0);
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x0000D847 File Offset: 0x0000BA47
	public void imethod_11(string string_0)
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_6(string_0);
	}

	// Token: 0x06000FCF RID: 4047 RVA: 0x0000D854 File Offset: 0x0000BA54
	public void imethod_13(string string_0)
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_9(string_0);
	}

	// Token: 0x06000FD0 RID: 4048 RVA: 0x0000D861 File Offset: 0x0000BA61
	private void method_5(int int_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnSetPersonalSettings(int_0);
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x0000D86E File Offset: 0x0000BA6E
	public void imethod_14(byte[] byte_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_18(byte_0);
	}

	// Token: 0x04000DB1 RID: 3505
	private bool m_initialized;

	// Token: 0x04000DB2 RID: 3506
	private PlayerProperties m_localPlayer;

	// Token: 0x04000DB3 RID: 3507
	private int m_townId;

	// Token: 0x04000DB4 RID: 3508
	private CurrencyInfo m_currency;
}
