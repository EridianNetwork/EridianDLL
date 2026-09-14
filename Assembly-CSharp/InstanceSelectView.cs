using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200070A RID: 1802
public class InstanceSelectView : BaseView, ISkillTreeServiceNotificationListerner
{
	// Token: 0x06002F92 RID: 12178 RVA: 0x0001F412 File Offset: 0x0001D612
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_1(this);
		MonoSingleton<InputManager>.Instance.method_26(new InputManager.OnKeySettingsChanged(this.OnKeySettingChanged));
	}

	// Token: 0x06002F93 RID: 12179 RVA: 0x0001F44B File Offset: 0x0001D64B
	public void OnKeySettingChanged(Dictionary<string, InputManager.InputKeyBinding> newKeySettings)
	{
		this.vmethod_5(newKeySettings);
	}

	// Token: 0x06002F94 RID: 12180 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(Dictionary<string, InputManager.InputKeyBinding> dictionary_0)
	{
	}

	// Token: 0x06002F95 RID: 12181 RVA: 0x0001F454 File Offset: 0x0001D654
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
		MonoSingleton<InputManager>.Instance.method_27(new InputManager.OnKeySettingsChanged(this.OnKeySettingChanged));
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_2(this);
	}

	// Token: 0x06002F96 RID: 12182 RVA: 0x000DA1FC File Offset: 0x000D83FC
	protected void method_3()
	{
		int int32_ = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1;
		int int32_2 = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0;
		bool flag = int32_ > 0;
		this.vmethod_9(flag);
		bool flag2 = int32_ > 0 && int32_2 == int32_;
		this.vmethod_8(flag2);
	}

	// Token: 0x06002F97 RID: 12183 RVA: 0x0001F48D File Offset: 0x0001D68D
	public virtual void vmethod_6(int int_0)
	{
		this._iLevel = int_0;
	}

	// Token: 0x06002F98 RID: 12184 RVA: 0x0001F496 File Offset: 0x0001D696
	public virtual void vmethod_7(PlayerProperties playerProperties_0)
	{
		if (playerProperties_0 != null)
		{
			this._playerInfo = playerProperties_0;
		}
	}

	// Token: 0x06002F99 RID: 12185 RVA: 0x0001F4A2 File Offset: 0x0001D6A2
	public virtual void vmethod_8(bool bool_0)
	{
		this._bSkillIconBlink = bool_0;
	}

	// Token: 0x06002F9A RID: 12186 RVA: 0x0001F4AB File Offset: 0x0001D6AB
	public virtual void vmethod_9(bool bool_0)
	{
		this._bSkillBtnEnable = bool_0;
	}

	// Token: 0x06002F9B RID: 12187 RVA: 0x0001F4B4 File Offset: 0x0001D6B4
	public virtual void vmethod_10(int int_0)
	{
		if (this._iPlayerExp == -1)
		{
			this._iPlayerExp = int_0;
		}
		this._iPlayerExp = int_0;
	}

	// Token: 0x06002F9C RID: 12188 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_11(bool bool_0)
	{
	}

	// Token: 0x06002F9D RID: 12189 RVA: 0x000DA240 File Offset: 0x000D8440
	private void method_4(int int_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().Boolean_0 = true;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().vmethod_5();
			MonoSingleton<GameFlowManager>.Instance.method_8(int_0);
		}
	}

	// Token: 0x06002F9E RID: 12190 RVA: 0x0001F4CD File Offset: 0x0001D6CD
	private void method_5(object object_0)
	{
		this.method_4((int)object_0);
	}

	// Token: 0x06002F9F RID: 12191 RVA: 0x000DA294 File Offset: 0x000D8494
	private void method_6()
	{
		int[] array = new int[] { 1001, 1002 };
		MenuItemDef[] array2 = new MenuItemDef[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(array[i]);
			array2[i].itemTitle = playlist.m_name;
			array2[i].itemData = playlist.m_id;
			array2[i].itemFunc = new MenuItemProcessFunc(this.method_5);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_4(array2, new Vector2(0f, 0f), null);
	}

	// Token: 0x06002FA0 RID: 12192 RVA: 0x0001F4DB File Offset: 0x0001D6DB
	protected void method_7()
	{
		DebugUtils.Log(LogCategory.GUI, " onPVPClick:");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = true;
	}

	// Token: 0x06002FA1 RID: 12193 RVA: 0x0001F4FD File Offset: 0x0001D6FD
	protected void method_8()
	{
		DebugUtils.Log(LogCategory.GUI, " onSurviveClick:");
		this.method_4(6);
	}

	// Token: 0x06002FA2 RID: 12194 RVA: 0x000DA344 File Offset: 0x000D8544
	protected void method_9()
	{
		bool flag = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().Boolean_1;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().Boolean_1 = flag;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().Boolean_1 = flag;
	}

	// Token: 0x06002FA3 RID: 12195 RVA: 0x000DA394 File Offset: 0x000D8594
	protected void method_10()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestListView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestListView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestListView>().Boolean_1;
		}
	}

	// Token: 0x06002FA4 RID: 12196 RVA: 0x000DA3E4 File Offset: 0x000D85E4
	protected void method_11()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SkillTreeView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SkillTreeView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SkillTreeView>().Boolean_1;
		}
	}

	// Token: 0x06002FA5 RID: 12197 RVA: 0x000DA434 File Offset: 0x000D8634
	protected void method_12()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_1;
		}
	}

	// Token: 0x06002FA6 RID: 12198 RVA: 0x000DA484 File Offset: 0x000D8684
	protected void method_13()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_1;
		}
	}

	// Token: 0x06002FA7 RID: 12199 RVA: 0x000DA434 File Offset: 0x000D8634
	protected void method_14()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().Boolean_1;
		}
	}

	// Token: 0x06002FA8 RID: 12200 RVA: 0x000DA4D4 File Offset: 0x000D86D4
	protected void method_15()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_1;
		}
	}

	// Token: 0x06002FA9 RID: 12201 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_16()
	{
	}

	// Token: 0x06002FAA RID: 12202 RVA: 0x000DA524 File Offset: 0x000D8724
	protected void method_17()
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().Boolean_1 = !MonoSingleton<AppManager>.Instance.method_0().vmethod_5<AchievementBoardView>().Boolean_1;
		}
	}

	// Token: 0x06002FAB RID: 12203 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_12()
	{
	}

	// Token: 0x06002FAC RID: 12204 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_13()
	{
	}

	// Token: 0x06002FAD RID: 12205 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_14()
	{
	}

	// Token: 0x06002FAE RID: 12206 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15()
	{
	}

	// Token: 0x06002FAF RID: 12207 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_16()
	{
	}

	// Token: 0x06002FB0 RID: 12208 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_17()
	{
	}

	// Token: 0x06002FB1 RID: 12209 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_18()
	{
	}

	// Token: 0x06002FB2 RID: 12210 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_19()
	{
	}

	// Token: 0x06002FB3 RID: 12211 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_20()
	{
	}

	// Token: 0x06002FB4 RID: 12212 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_21()
	{
	}

	// Token: 0x06002FB5 RID: 12213 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_22()
	{
		return false;
	}

	// Token: 0x06002FB6 RID: 12214 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_23()
	{
		return false;
	}

	// Token: 0x06002FB7 RID: 12215 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_24()
	{
	}

	// Token: 0x06002FB8 RID: 12216 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_25()
	{
	}

	// Token: 0x06002FB9 RID: 12217 RVA: 0x0001F511 File Offset: 0x0001D711
	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		this.method_3();
	}

	// Token: 0x06002FBA RID: 12218 RVA: 0x0001F511 File Offset: 0x0001D711
	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		this.method_3();
	}

	// Token: 0x06002FBB RID: 12219 RVA: 0x0001F511 File Offset: 0x0001D711
	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		this.method_3();
	}

	// Token: 0x06002FBC RID: 12220 RVA: 0x0001F511 File Offset: 0x0001D711
	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		this.method_3();
	}

	// Token: 0x06002FBD RID: 12221 RVA: 0x0001F511 File Offset: 0x0001D711
	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		this.method_3();
	}

	// Token: 0x04002132 RID: 8498
	public Delegate_EnterLevelProc _enterLevelFunc;

	// Token: 0x04002133 RID: 8499
	protected PlayerProperties _playerInfo;

	// Token: 0x04002134 RID: 8500
	protected int _iPlayerExp = -1;

	// Token: 0x04002135 RID: 8501
	protected bool _bSkillIconBlink;

	// Token: 0x04002136 RID: 8502
	protected bool _bSkillBtnEnable;

	// Token: 0x04002137 RID: 8503
	protected int _iLevel;

	// Token: 0x0200070B RID: 1803
	public struct InstanceInfo
	{
		// Token: 0x04002138 RID: 8504
		public int iUnlockExp;

		// Token: 0x04002139 RID: 8505
		public int iID;

		// Token: 0x0400213A RID: 8506
		public bool bUnlocked;
	}
}
