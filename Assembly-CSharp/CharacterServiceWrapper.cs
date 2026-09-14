using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020002CD RID: 717
public class CharacterServiceWrapper : ServiceWrapper<ICharacterServiceWrapper, CharacterServiceWrapper>
{
	// Token: 0x06000F8E RID: 3982 RVA: 0x0000D5D3 File Offset: 0x0000B7D3
	public void method_0(ICharacterServiceNotificationListerner icharacterServiceNotificationListerner_0)
	{
		this.m_listerner.Add(icharacterServiceNotificationListerner_0);
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x0000D5E1 File Offset: 0x0000B7E1
	public void method_1(ICharacterServiceNotificationListerner icharacterServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(icharacterServiceNotificationListerner_0);
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x0000D5F0 File Offset: 0x0000B7F0
	public void method_2()
	{
		this.m_antiAddictionLevel = AntiAddiction.Level.NormalRewards;
	}

	// Token: 0x06000F91 RID: 3985 RVA: 0x0000D5F9 File Offset: 0x0000B7F9
	public AntiAddiction.Level method_3()
	{
		return this.m_antiAddictionLevel;
	}

	// Token: 0x06000F92 RID: 3986 RVA: 0x00074EBC File Offset: 0x000730BC
	public void method_4(Character character_0)
	{
		this.m_character = character_0;
		if (this.m_wrapperOnline != null)
		{
			(this.m_wrapperOnline as CharacterServiceWrapperOnline).method_2(this.m_character.Currency);
		}
		if (this.m_wrapperSession != null)
		{
			(this.m_wrapperSession as CharacterServiceWrapperSession).method_0(this.m_character.Currency);
		}
	}

	// Token: 0x06000F93 RID: 3987 RVA: 0x0000D601 File Offset: 0x0000B801
	public Character method_5()
	{
		return this.m_character;
	}

	// Token: 0x06000F94 RID: 3988 RVA: 0x0000D609 File Offset: 0x0000B809
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new CharacterServiceWrapperOnline();
		this.m_wrapperSession = new CharacterServiceWrapperSession();
		OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_13(new OnNotifyAntiAddiction(this.OnNotifyAntiAddiction));
		this.method_15();
		this.method_16();
		base.vmethod_1();
	}

	// Token: 0x06000F95 RID: 3989 RVA: 0x00074F18 File Offset: 0x00073118
	protected override ICharacterServiceWrapper vmethod_0()
	{
		if (MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16() && MonoSingleton<Session>.Instance.GetLocalPlayer() && this.m_wrapperSession.imethod_1())
		{
			return this.m_wrapperSession;
		}
		return this.m_wrapperOnline;
	}

	// Token: 0x06000F96 RID: 3990 RVA: 0x0000D649 File Offset: 0x0000B849
	public int method_6()
	{
		return this.m_character.Energy;
	}

	// Token: 0x06000F97 RID: 3991 RVA: 0x0000D656 File Offset: 0x0000B856
	public int method_7()
	{
		return this.vmethod_0().imethod_2();
	}

	// Token: 0x06000F98 RID: 3992 RVA: 0x0000D663 File Offset: 0x0000B863
	public int method_8()
	{
		return this.vmethod_0().imethod_3();
	}

	// Token: 0x06000F99 RID: 3993 RVA: 0x0000D670 File Offset: 0x0000B870
	public string method_9()
	{
		return this.vmethod_0().imethod_4();
	}

	// Token: 0x06000F9A RID: 3994 RVA: 0x0000D67D File Offset: 0x0000B87D
	public int method_10()
	{
		return this.vmethod_0().imethod_5();
	}

	// Token: 0x06000F9B RID: 3995 RVA: 0x0000D68A File Offset: 0x0000B88A
	public int method_11()
	{
		return this.vmethod_0().imethod_8();
	}

	// Token: 0x06000F9C RID: 3996 RVA: 0x0000D697 File Offset: 0x0000B897
	public CurrencyInfo method_12()
	{
		return this.vmethod_0().imethod_7();
	}

	// Token: 0x06000F9D RID: 3997 RVA: 0x0000D6A4 File Offset: 0x0000B8A4
	public AvatarDNA method_13()
	{
		return this.vmethod_0().imethod_6();
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x0000D6B1 File Offset: 0x0000B8B1
	private void method_14(string string_0)
	{
		this.vmethod_0().imethod_11(string_0);
	}

	// Token: 0x06000F9F RID: 3999 RVA: 0x0000D6BF File Offset: 0x0000B8BF
	public void method_15()
	{
		this.vmethod_0().imethod_10();
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0000D6CC File Offset: 0x0000B8CC
	public void method_16()
	{
		this.vmethod_0().imethod_12();
	}

	// Token: 0x06000FA1 RID: 4001 RVA: 0x0000D6D9 File Offset: 0x0000B8D9
	public void method_17(string string_0)
	{
		this.vmethod_0().imethod_13(string_0);
		DebugUtils.LogWarning(LogCategory.Gamelogic, "Save setting: = " + string_0);
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x0000D6F8 File Offset: 0x0000B8F8
	public void method_18(byte[] byte_0)
	{
		this.vmethod_0().imethod_14(byte_0);
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x00074F6C File Offset: 0x0007316C
	public float method_19()
	{
		ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_8());
		if (itemDNA == null)
		{
			return 0f;
		}
		WeaponAttribute attribute = itemDNA.method_6().m_attribute;
		if (attribute == null)
		{
			return 0f;
		}
		return FloatAttributeValue.smethod_0(attribute.m_weaponAttribute[99].m_attributeValue as FloatAttributeValue);
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x00074FC8 File Offset: 0x000731C8
	public int method_20(AmmoType ammoType_0, CharacterSetup characterSetup_0)
	{
		for (int i = 0; i < characterSetup_0.m_inventorySetup.m_ammos.Length; i++)
		{
			if (characterSetup_0.m_inventorySetup.m_ammos[i].m_ammoType == ammoType_0)
			{
				return characterSetup_0.m_inventorySetup.m_ammos[i].m_ammoCount;
			}
		}
		return 0;
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x00075018 File Offset: 0x00073218
	public int method_21()
	{
		foreach (KeyValuePair<int, int> keyValuePair in OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_1())
		{
			int key = keyValuePair.Key;
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(key);
			if (playlist != null && playlist.m_gameMode == "GameModeTown")
			{
				return playlist.m_id;
			}
		}
		return -1;
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x0000D706 File Offset: 0x0000B906
	public void method_22()
	{
		this.vmethod_0().imethod_9();
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x0007507C File Offset: 0x0007327C
	public void OnGotCurrencies(CurrencyInfo currency)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGotMyCurrencies(currency);
		}
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0007507C File Offset: 0x0007327C
	public void OnCurrenciesUpdated(CurrencyInfo currency)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGotMyCurrencies(currency);
		}
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x000750B4 File Offset: 0x000732B4
	public void OnExperienceUpdated(int experience)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnExperienceUpdated(experience);
		}
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0000D713 File Offset: 0x0000B913
	public int method_23()
	{
		return (this.m_wrapperOnline as CharacterServiceWrapperOnline).method_3();
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x000750EC File Offset: 0x000732EC
	public void OnNotifyAntiAddiction(int onlineMinutes, int offlineMinutes)
	{
		this.m_antiAddictionLevel = AntiAddiction.smethod_1(onlineMinutes);
		string text = AntiAddiction.smethod_2(onlineMinutes);
		if (!string.IsNullOrEmpty(text))
		{
			ChatView chatView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>();
			if (chatView != null)
			{
				chatView.method_8(ChatParameter.System, string.Empty, text, 0, string.Empty);
			}
			HUDWarningView hudwarningView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>();
			if (hudwarningView != null)
			{
				hudwarningView.vmethod_7(text, new Delegate_EventProc(this.OnClickedFunction), null);
			}
		}
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnClickedFunction()
	{
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x00075164 File Offset: 0x00073364
	public void OnSetPersonalSettings(int iResult)
	{
		foreach (ICharacterServiceNotificationListerner characterServiceNotificationListerner in this.m_listerner)
		{
			characterServiceNotificationListerner.OnSetPersonalSettings(iResult);
		}
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x000751B8 File Offset: 0x000733B8
	public void OnGetCharacterSettings(string strSettings)
	{
		if (strSettings != null && strSettings.Length > 0)
		{
			this.m_CharacterSettingContainer = JSONObject.Create(strSettings, -2, false, false);
		}
		foreach (ICharacterServiceNotificationListerner characterServiceNotificationListerner in this.m_listerner)
		{
			characterServiceNotificationListerner.OnGetCharacterSettings(strSettings);
		}
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x00075228 File Offset: 0x00073428
	public void OnSetCharacterSettings(int iResult)
	{
		foreach (ICharacterServiceNotificationListerner characterServiceNotificationListerner in this.m_listerner)
		{
			characterServiceNotificationListerner.OnSetCharacterSettings(iResult);
		}
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x0007527C File Offset: 0x0007347C
	public void OnGetPersonalSettings(string strSettings)
	{
		if (strSettings != null && strSettings.Length > 0)
		{
			this.m_PlayerSettingContainer = JSONObject.Create(strSettings, -2, false, false);
		}
		foreach (ICharacterServiceNotificationListerner characterServiceNotificationListerner in this.m_listerner)
		{
			characterServiceNotificationListerner.OnGetPersonalSettings(strSettings);
		}
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x000752EC File Offset: 0x000734EC
	public void method_24(string string_0, JSONObject jsonobject_0)
	{
		if (this.m_CharacterSettingContainer == null)
		{
			this.m_CharacterSettingContainer = new JSONObject();
		}
		else if (this.m_CharacterSettingContainer.HasField(string_0))
		{
			this.m_CharacterSettingContainer.RemoveField(string_0);
		}
		this.m_CharacterSettingContainer.AddField(string_0, jsonobject_0);
		this.method_17(this.m_CharacterSettingContainer.ToString());
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x00075348 File Offset: 0x00073548
	public JSONObject method_25(string string_0)
	{
		JSONObject jsonobject = null;
		if (this.m_CharacterSettingContainer != null && this.m_CharacterSettingContainer.HasField(string_0))
		{
			jsonobject = this.m_CharacterSettingContainer.GetField(string_0);
		}
		return jsonobject;
	}

	// Token: 0x06000FB3 RID: 4019 RVA: 0x0007537C File Offset: 0x0007357C
	public void method_26(string string_0, List<int> list_0)
	{
		JSONObject jsonobject = new JSONObject();
		for (int i = 0; i < list_0.Count; i++)
		{
			jsonobject.Add(list_0[i]);
		}
		this.method_24(string_0, jsonobject);
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x000753B8 File Offset: 0x000735B8
	public List<int> method_27(string string_0)
	{
		List<int> list = new List<int>();
		if (this.m_CharacterSettingContainer != null)
		{
			JSONObject field = this.m_CharacterSettingContainer.GetField(string_0);
			if (field != null && field.list != null)
			{
				List<JSONObject> list2 = this.m_CharacterSettingContainer.GetField(string_0).list;
				int count = list2.Count;
				for (int i = 0; i < count; i++)
				{
					JSONObject jsonobject = list2[i];
					list.Add((int)jsonobject.n);
				}
			}
		}
		return list;
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x00075430 File Offset: 0x00073630
	public void method_28(string string_0, JSONObject jsonobject_0)
	{
		if (this.m_PlayerSettingContainer == null)
		{
			this.m_PlayerSettingContainer = new JSONObject();
		}
		else if (this.m_PlayerSettingContainer.HasField(string_0))
		{
			this.m_PlayerSettingContainer.RemoveField(string_0);
		}
		this.m_PlayerSettingContainer.AddField(string_0, jsonobject_0);
		this.method_14(this.m_PlayerSettingContainer.ToString());
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0007548C File Offset: 0x0007368C
	public JSONObject method_29(string string_0)
	{
		JSONObject jsonobject = null;
		if (this.m_PlayerSettingContainer != null && this.m_PlayerSettingContainer.HasField(string_0))
		{
			jsonobject = this.m_PlayerSettingContainer.GetField(string_0);
		}
		return jsonobject;
	}

	// Token: 0x06000FB7 RID: 4023 RVA: 0x000754C0 File Offset: 0x000736C0
	public void method_30(string string_0, List<int> list_0)
	{
		JSONObject jsonobject = new JSONObject();
		foreach (int num in list_0)
		{
			jsonobject.Add(num);
		}
		this.method_28(string_0, jsonobject);
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x0007551C File Offset: 0x0007371C
	public List<int> method_31(string string_0)
	{
		List<int> list = new List<int>();
		if (this.m_PlayerSettingContainer != null)
		{
			JSONObject field = this.m_PlayerSettingContainer.GetField(string_0);
			if (field != null && field.list != null)
			{
				foreach (JSONObject jsonobject in this.m_PlayerSettingContainer.GetField(string_0).list)
				{
					list.Add((int)jsonobject.n);
				}
			}
		}
		return list;
	}

	// Token: 0x04000DAC RID: 3500
	private AntiAddiction.Level m_antiAddictionLevel;

	// Token: 0x04000DAD RID: 3501
	private Character m_character;

	// Token: 0x04000DAE RID: 3502
	private List<ICharacterServiceNotificationListerner> m_listerner = new List<ICharacterServiceNotificationListerner>();

	// Token: 0x04000DAF RID: 3503
	private JSONObject m_PlayerSettingContainer;

	// Token: 0x04000DB0 RID: 3504
	private JSONObject m_CharacterSettingContainer;
}
