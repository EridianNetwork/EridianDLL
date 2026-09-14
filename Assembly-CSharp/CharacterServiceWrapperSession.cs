using System;
using ns0;

// Token: 0x020002CF RID: 719
public class CharacterServiceWrapperSession : ICharacterServiceWrapper, IServiceWrapper
{
	// Token: 0x06000FD3 RID: 4051 RVA: 0x000756F8 File Offset: 0x000738F8
	public void imethod_0()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_14(new OnGetPersonalSettings(this.method_1));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_15(new OnSetPersonalSettings(this.method_4));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_19(new OnGetCharacterSettings(this.method_2));
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_20(new OnSetCharacterSettings(this.method_3));
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x0000D87B File Offset: 0x0000BA7B
	public void method_0(CurrencyInfo currencyInfo_0)
	{
		this.m_currency = currencyInfo_0;
		this.m_initialized = true;
	}

	// Token: 0x06000FD5 RID: 4053 RVA: 0x0000D88B File Offset: 0x0000BA8B
	public bool imethod_1()
	{
		if (this.m_initialized && MonoSingleton<Session>.Instance != null)
		{
			this.m_localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (this.m_localPlayer != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x0000D8C3 File Offset: 0x0000BAC3
	public int imethod_2()
	{
		return this.m_localPlayer.m_exp;
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x0000D8D0 File Offset: 0x0000BAD0
	public int imethod_3()
	{
		return MonoSingleton<LevelingManager>.Instance.method_3(this.m_localPlayer.m_avatarDna.method_5(), this.m_localPlayer.m_exp);
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x0000D8F7 File Offset: 0x0000BAF7
	public string imethod_4()
	{
		return this.m_localPlayer.m_name;
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x0000D904 File Offset: 0x0000BB04
	public int imethod_5()
	{
		return this.m_localPlayer.m_teamID;
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x0000D911 File Offset: 0x0000BB11
	public int imethod_8()
	{
		return this.m_localPlayer.m_characterId;
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x0000D91E File Offset: 0x0000BB1E
	public AvatarDNA imethod_6()
	{
		return this.m_localPlayer.m_avatarDna;
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x0000D92B File Offset: 0x0000BB2B
	public CurrencyInfo imethod_7()
	{
		return this.m_currency;
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x0000D933 File Offset: 0x0000BB33
	public void imethod_9()
	{
		this.m_currency.BondCurrency = this.m_localPlayer.m_bondCurrency;
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGotCurrencies(this.m_currency);
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x0000D822 File Offset: 0x0000BA22
	public void imethod_10()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_5();
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x0000D82E File Offset: 0x0000BA2E
	public void imethod_12()
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_8();
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x0000D854 File Offset: 0x0000BA54
	public void imethod_13(string string_0)
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_9(string_0);
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x0000D83A File Offset: 0x0000BA3A
	private void method_1(string string_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGetPersonalSettings(string_0);
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x0000D725 File Offset: 0x0000B925
	private void method_2(string string_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnGetCharacterSettings(string_0);
	}

	// Token: 0x06000FE3 RID: 4067 RVA: 0x0000D732 File Offset: 0x0000B932
	private void method_3(int int_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnSetCharacterSettings(int_0);
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x0000D847 File Offset: 0x0000BA47
	public void imethod_11(string string_0)
	{
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_6(string_0);
	}

	// Token: 0x06000FE5 RID: 4069 RVA: 0x0000D861 File Offset: 0x0000BA61
	private void method_4(int int_0)
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.OnSetPersonalSettings(int_0);
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(byte[] byte_0)
	{
	}

	// Token: 0x04000DB5 RID: 3509
	private PlayerInfoSync m_localPlayer;

	// Token: 0x04000DB6 RID: 3510
	private CurrencyInfo m_currency;

	// Token: 0x04000DB7 RID: 3511
	private bool m_initialized;
}
