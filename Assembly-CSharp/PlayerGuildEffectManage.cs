using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020004B8 RID: 1208
public class PlayerGuildEffectManage : IGuildServiceNotificationListerner
{
	// Token: 0x06002095 RID: 8341 RVA: 0x00016A17 File Offset: 0x00014C17
	public PlayerGuildEffectManage(EntityPlayer entityPlayer_0)
	{
		this.m_playerOwner = entityPlayer_0;
		this.method_1();
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_0(this);
	}

	// Token: 0x06002096 RID: 8342 RVA: 0x0009F578 File Offset: 0x0009D778
	public void OnGetGuildActiveEffect(int guildId, List<GuildSkill> skills)
	{
		if (guildId > 0 && skills != null)
		{
			this.m_guildID = guildId;
			this.m_activeEffectList.Clear();
			for (int i = 0; i < skills.Count; i++)
			{
				this.m_activeEffectList.Add(skills[i].Id);
			}
			this.m_playerOwner.vmethod_80();
			return;
		}
	}

	// Token: 0x06002097 RID: 8343 RVA: 0x0009F5D4 File Offset: 0x0009D7D4
	public void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount)
	{
		if (MonoSingleton<Session>.Instance.method_16() && this.m_guildID > 0 && this.m_guildID == guildId)
		{
			if (!this.m_activeEffectList.Contains(skillId))
			{
				this.m_activeEffectList.Add(skillId);
				this.m_playerOwner.vmethod_80();
			}
			else
			{
				DebugUtils.LogError(LogCategory.Gamelogic, string.Format("{0} is already in active effect list!", skillId));
			}
		}
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x00016A4D File Offset: 0x00014C4D
	public void OnReceivedGuildMemberJoin(int guildId, int characterId)
	{
		if (this.m_playerOwner.method_20() == characterId)
		{
			this.m_guildID = guildId;
		}
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x00016A64 File Offset: 0x00014C64
	public void OnReceivedGuildMemberQuit(int guildId, int characterId)
	{
		if (this.m_playerOwner.method_20() == characterId)
		{
			this.m_guildID = 0;
			this.m_activeEffectList.Clear();
			this.m_playerOwner.vmethod_80();
		}
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x0009F63C File Offset: 0x0009D83C
	public float method_0(EffectType effectType_0, AffectType affectType_0)
	{
		float num = this.m_playerOwner.SkillTreeStatus_0.method_5(affectType_0);
		if (this.m_activeEffectList.Contains((int)effectType_0))
		{
			num = this.m_lookupDic[(int)effectType_0];
		}
		return num;
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x0009F678 File Offset: 0x0009D878
	private void method_1()
	{
		this.m_lookupDic.Clear();
		for (int i = 0; i < MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills.Length; i++)
		{
			GuildSkillData guildSkillData = MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[i];
			this.m_lookupDic.Add(guildSkillData.m_id, guildSkillData.m_value);
		}
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName)
	{
	}

	// Token: 0x0600209D RID: 8349 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildJoined(int guildId, string guildName, bool isJoined)
	{
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildExpelled(int guildId, string guildName, bool isGuildDismissed)
	{
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount)
	{
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildManagerAssigned(int guildId)
	{
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildManagerDischarged(int guildId)
	{
	}

	// Token: 0x060020A2 RID: 8354 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildMasterChanged(int guildId)
	{
	}

	// Token: 0x04001521 RID: 5409
	private EntityPlayer m_playerOwner;

	// Token: 0x04001522 RID: 5410
	private List<int> m_activeEffectList = new List<int>();

	// Token: 0x04001523 RID: 5411
	private Dictionary<int, float> m_lookupDic = new Dictionary<int, float>();

	// Token: 0x04001524 RID: 5412
	private int m_guildID;
}
