using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020002C0 RID: 704
public class RetrieveCurrentCharacterDataAsyncTask : AsyncTaskBase, ISkillTreeServiceNotificationListerner
{
	// Token: 0x06000F29 RID: 3881 RVA: 0x0000D2E8 File Offset: 0x0000B4E8
	public void method_4()
	{
		this.float_1 = 60f;
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x000748F4 File Offset: 0x00072AF4
	public override void Start()
	{
		base.Start();
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_1(this);
		CharacterService.GetSelectedCharacterAsyncTask getSelectedCharacterAsyncTask = new CharacterService.GetSelectedCharacterAsyncTask();
		getSelectedCharacterAsyncTask.method_4();
		MonoSingleton<AsyncTaskManager>.Instance.method_1(getSelectedCharacterAsyncTask, new TaskCompletedDelegate(this.OnGetMyCharacter));
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x0000D2F5 File Offset: 0x0000B4F5
	public override void vmethod_0()
	{
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_2(this);
		base.vmethod_0();
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x00074938 File Offset: 0x00072B38
	private void OnGetMyCharacter(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (base.IsStatus())
		{
			return;
		}
		if (result != AsyncTaskStatus.Success)
		{
			base.SetStatus(result);
			return;
		}
		this.m_character = (task as CharacterService.GetSelectedCharacterAsyncTask).m_character;
		PlayerProperties playerProperties = MonoSingleton<PlayerManager>.Instance.method_2();
		if (playerProperties != null)
		{
			playerProperties.m_exp = this.m_character.Experience;
		}
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_4(this.m_character);
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<QuestServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<FriendServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<GroupServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<GuildServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<CraftingServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<ShopServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<MailServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<ChatServiceWarpper>.Instance.vmethod_1();
		ServiceWrapperBase<RankServiceWrapper>.Instance.vmethod_1();
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_7();
		ServiceWrapperBase<AchievementServiceWrapper>.Instance.vmethod_1();
		AchievementManager.AchievementManager_0.method_0();
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x00074A3C File Offset: 0x00072C3C
	public override void Update(float time)
	{
		base.Update(time);
		if (!this.m_isWaitingSkillPoint && this.m_isCharacterServiceWrapperReady && this.m_isInventoryServiceWrapperReady && this.m_isSkillTreeServiceWrapperReady && this.m_isQuestServiceWrapperReady && this.m_isFriendServiceWrapperReady && this.m_isGroupServiceWrapperReady && this.m_isGuildServiceWrapperReady && this.m_isCraftingServiceWrapperReady && this.m_isLobbyServiceWrapperReady && this.m_isShopServiceWrapperReady && this.m_isMailServiceWrapperReady && this.m_isChatServiceWarpperReady)
		{
			ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_7();
			this.m_isWaitingSkillPoint = true;
		}
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x0000D308 File Offset: 0x0000B508
	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		if (characterId == OnlineService.s_characterId)
		{
			base.SetStatus(AsyncTaskStatus.Success);
		}
		else
		{
			base.SetStatus(AsyncTaskStatus.Error);
		}
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnSkillPtEarned(int characterId, int numEarned)
	{
	}

	// Token: 0x04000D70 RID: 3440
	private bool m_isCharacterServiceWrapperReady;

	// Token: 0x04000D71 RID: 3441
	private bool m_isInventoryServiceWrapperReady;

	// Token: 0x04000D72 RID: 3442
	private bool m_isSkillTreeServiceWrapperReady;

	// Token: 0x04000D73 RID: 3443
	private bool m_isQuestServiceWrapperReady;

	// Token: 0x04000D74 RID: 3444
	private bool m_isFriendServiceWrapperReady;

	// Token: 0x04000D75 RID: 3445
	private bool m_isGroupServiceWrapperReady;

	// Token: 0x04000D76 RID: 3446
	private bool m_isGuildServiceWrapperReady;

	// Token: 0x04000D77 RID: 3447
	private bool m_isCraftingServiceWrapperReady;

	// Token: 0x04000D78 RID: 3448
	private bool m_isLobbyServiceWrapperReady;

	// Token: 0x04000D79 RID: 3449
	private bool m_isMailServiceWrapperReady;

	// Token: 0x04000D7A RID: 3450
	private bool m_isShopServiceWrapperReady;

	// Token: 0x04000D7B RID: 3451
	private bool m_isChatServiceWarpperReady;

	// Token: 0x04000D7C RID: 3452
	private bool m_isWaitingSkillPoint;

	// Token: 0x04000D7D RID: 3453
	public Character m_character;
}
