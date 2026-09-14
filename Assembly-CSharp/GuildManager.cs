using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;

// Token: 0x02000679 RID: 1657
public class GuildManager : IGuildServiceNotificationListerner
{
	// Token: 0x06002A1C RID: 10780 RVA: 0x000C5D00 File Offset: 0x000C3F00
	private GuildManager()
	{
		if (this.m_SearchResult == null)
		{
			this.m_SearchResult = new List<Guild>();
			this.m_SearchResult.Clear();
		}
		if (this.m_AppliedGuild == null)
		{
			this.m_AppliedGuild = new List<Guild>();
			this.m_AppliedGuild.Clear();
		}
		if (this.m_AppliedGuildID == null)
		{
			this.m_AppliedGuildID = new List<int>();
			this.m_AppliedGuildID.Clear();
		}
		if (this.m_ApplicationMap == null)
		{
			this.m_ApplicationMap = new Dictionary<int, GuildManager.GuildApplicationData>();
			this.m_ApplicationMap.Clear();
		}
		if (this.m_GuildNews == null)
		{
			this.m_GuildNews = new List<GuildNews>();
			this.m_GuildNews.Clear();
		}
		if (this.m_GuildProgressionTable == null)
		{
			this.m_GuildProgressionTable = new Dictionary<int, int>();
			this.m_GuildProgressionTable.Clear();
			this.method_0();
		}
		if (this.m_GuildManagerList == null)
		{
			this.m_GuildManagerList = new List<int>();
			this.m_GuildManagerList.Clear();
		}
		if (this.m_GuildSkillList == null)
		{
			this.m_GuildSkillList = new List<int>();
			this.m_GuildSkillList.Clear();
		}
	}

	// Token: 0x06002A1D RID: 10781 RVA: 0x0001BADA File Offset: 0x00019CDA
	public static GuildManager smethod_0()
	{
		if (GuildManager._GuildInstance == null)
		{
			GuildManager._GuildInstance = new GuildManager();
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_0(GuildManager._GuildInstance);
		}
		return GuildManager._GuildInstance;
	}

	// Token: 0x06002A1E RID: 10782 RVA: 0x000C5E34 File Offset: 0x000C4034
	protected void method_0()
	{
		this.m_GuildProgressionTable.Clear();
		for (int i = 0; i < MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_progressionTable.Length; i++)
		{
			int levelNumber = MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_progressionTable[i].m_levelNumber;
			int expRequirement = MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_progressionTable[i].m_expRequirement;
			if (levelNumber > this.m_nMaxLevel)
			{
				this.m_nMaxLevel = levelNumber;
			}
			this.m_GuildProgressionTable.Add(levelNumber, expRequirement);
		}
	}

	// Token: 0x06002A1F RID: 10783 RVA: 0x000C5EB4 File Offset: 0x000C40B4
	public bool method_1(int int_0)
	{
		if (this.m_MyGuildInfo == null)
		{
			return false;
		}
		for (int i = 0; i < this.m_MyGuildInfo.List_0.Count; i++)
		{
			if (this.m_MyGuildInfo.List_0[i].mCharacterId == int_0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002A20 RID: 10784 RVA: 0x0001BB01 File Offset: 0x00019D01
	public int method_2()
	{
		if (this.m_MyGuildInfo != null)
		{
			return this.m_MyGuildInfo.Experience;
		}
		return 0;
	}

	// Token: 0x06002A21 RID: 10785 RVA: 0x000C5F04 File Offset: 0x000C4104
	public int method_3()
	{
		if (this.m_MyGuildInfo == null)
		{
			return 0;
		}
		int level = this.m_MyGuildInfo.Level;
		if (level > this.m_nMaxLevel)
		{
			return this.m_GuildProgressionTable[this.m_nMaxLevel];
		}
		if (this.m_GuildProgressionTable.ContainsKey(level))
		{
			return this.m_GuildProgressionTable[level];
		}
		return this.m_GuildProgressionTable[this.m_nMaxLevel];
	}

	// Token: 0x06002A22 RID: 10786 RVA: 0x000C5F70 File Offset: 0x000C4170
	public int method_4()
	{
		if (this.m_MyGuildInfo == null)
		{
			return 0;
		}
		int num = this.m_MyGuildInfo.Level + 1;
		if (num > this.m_nMaxLevel)
		{
			return this.m_GuildProgressionTable[this.m_nMaxLevel];
		}
		if (this.m_GuildProgressionTable.ContainsKey(num))
		{
			return this.m_GuildProgressionTable[num];
		}
		return this.m_GuildProgressionTable[this.m_nMaxLevel];
	}

	// Token: 0x06002A23 RID: 10787 RVA: 0x000C5FDC File Offset: 0x000C41DC
	public bool method_5()
	{
		if (this.method_7())
		{
			return false;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return false;
		}
		AvatarDNA avatarDna = localPlayer.m_avatarDna;
		return avatarDna != null && MonoSingleton<LevelingManager>.Instance.method_3(avatarDna.method_5(), localPlayer.m_exp) >= LevelingManager.CREATEGUILD_UNLOCK_LEVEL;
	}

	// Token: 0x06002A24 RID: 10788 RVA: 0x0001BB18 File Offset: 0x00019D18
	public bool method_6()
	{
		return !this.method_7();
	}

	// Token: 0x06002A25 RID: 10789 RVA: 0x0001BB25 File Offset: 0x00019D25
	public bool method_7()
	{
		return this.m_bInGuild;
	}

	// Token: 0x06002A26 RID: 10790 RVA: 0x0001BB2D File Offset: 0x00019D2D
	public bool method_8()
	{
		return this.m_bInGuild && OnlineService.s_characterId == this.m_nChairmanID;
	}

	// Token: 0x06002A27 RID: 10791 RVA: 0x0001BB46 File Offset: 0x00019D46
	public bool method_9(int int_0)
	{
		return int_0 == this.m_nChairmanID;
	}

	// Token: 0x06002A28 RID: 10792 RVA: 0x000C6038 File Offset: 0x000C4238
	public void method_10()
	{
		if (this.m_MyGuildInfo == null)
		{
			return;
		}
		if (this.m_MyGuildInfo.mMemberList.Count <= 1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildMember);
			return;
		}
		this.m_MyGuildInfo.mMemberList.Sort(new Comparison<Presence>(this.method_13));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildMember);
	}

	// Token: 0x06002A29 RID: 10793 RVA: 0x000C60A8 File Offset: 0x000C42A8
	public void method_11()
	{
		if (this.m_MyGuildInfo == null)
		{
			return;
		}
		if (this.m_MyGuildInfo.mMemberList.Count <= 1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildMember);
			return;
		}
		this.m_MyGuildInfo.mMemberList.Sort(new Comparison<Presence>(this.method_12));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildMember);
	}

	// Token: 0x06002A2A RID: 10794 RVA: 0x000C6118 File Offset: 0x000C4318
	private int method_12(Presence presence_0, Presence presence_1)
	{
		if (presence_1.mCharacterId == this.m_MyGuildInfo.MasterCharacterId)
		{
			return 1;
		}
		if (presence_0.mCharacterId == this.m_MyGuildInfo.MasterCharacterId)
		{
			return -1;
		}
		if (!this.method_83(presence_0.mCharacterId) && this.method_83(presence_1.mCharacterId))
		{
			return 1;
		}
		if (presence_0.mCharacterId != this.m_MyGuildInfo.MasterCharacterId && !this.method_83(presence_0.mCharacterId) && !presence_0.mIsOnline && presence_1.mIsOnline)
		{
			return 1;
		}
		if (presence_0.mCharacterId == presence_1.mCharacterId)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06002A2B RID: 10795 RVA: 0x000C61B4 File Offset: 0x000C43B4
	private int method_13(Presence presence_0, Presence presence_1)
	{
		if (presence_0.mCharacterId == presence_1.mCharacterId)
		{
			return 1;
		}
		if (presence_0.mIsOnline && presence_1.mIsOnline)
		{
			if (presence_0.mCharacterId != this.m_MyGuildInfo.MasterCharacterId && presence_1.mCharacterId == this.m_MyGuildInfo.MasterCharacterId)
			{
				return 1;
			}
			if (presence_0.mCharacterId == this.m_MyGuildInfo.MasterCharacterId && presence_1.mCharacterId != this.m_MyGuildInfo.MasterCharacterId)
			{
				return -1;
			}
			if (!this.method_83(presence_0.mCharacterId) && presence_0.mCharacterId != this.m_MyGuildInfo.MasterCharacterId && this.method_83(presence_1.mCharacterId))
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (!presence_0.mIsOnline && presence_1.mIsOnline)
			{
				return 1;
			}
			if (presence_0.mIsOnline && !presence_1.mIsOnline)
			{
				return -1;
			}
			if (!presence_0.mIsOnline && !presence_1.mIsOnline)
			{
				return -1;
			}
			return 0;
		}
	}

	// Token: 0x06002A2C RID: 10796 RVA: 0x0001BB51 File Offset: 0x00019D51
	public void method_14()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_3(new GetMyGuildInfoCallback(this.method_51));
	}

	// Token: 0x06002A2D RID: 10797 RVA: 0x0001BB69 File Offset: 0x00019D69
	public void method_15(string string_0, string string_1, GuildPreference guildPreference_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_6(new CreateGuildCallback(this.method_49), string_0, string_1, guildPreference_0);
	}

	// Token: 0x06002A2E RID: 10798 RVA: 0x0001BB84 File Offset: 0x00019D84
	public int method_16()
	{
		if (this.m_MyGuildInfo != null)
		{
			return this.m_MyGuildInfo.MaxMemberCount;
		}
		return this.m_nMaxGuildMemberCount;
	}

	// Token: 0x06002A2F RID: 10799 RVA: 0x000C62A4 File Offset: 0x000C44A4
	public void method_17()
	{
		if (this.m_MyGuildInfo != null && this.method_8())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("GUILD_Dismiss_WARNING")), new Delegate_EventProc(this.method_18), new Delegate_EventProc(this.method_19));
		}
	}

	// Token: 0x06002A30 RID: 10800 RVA: 0x0001BBA0 File Offset: 0x00019DA0
	protected void method_18()
	{
		if (this.m_MyGuildInfo != null && this.method_8())
		{
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_7(new DismissGuildCallback(this.method_60), this.m_MyGuildInfo.Id);
		}
	}

	// Token: 0x06002A31 RID: 10801 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_19()
	{
	}

	// Token: 0x06002A32 RID: 10802 RVA: 0x0001BBD3 File Offset: 0x00019DD3
	public void method_20(string string_0)
	{
		if (this.method_8())
		{
			this.m_strGuildDec = string_0;
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_2(new ChangeGuildBannerCallback(this.method_21), this.m_MyGuildInfo.Id, string_0);
		}
	}

	// Token: 0x06002A33 RID: 10803 RVA: 0x0001BC06 File Offset: 0x00019E06
	protected void method_21(bool bool_0)
	{
		if (!bool_0)
		{
			this.m_strGuildDec = this.m_MyGuildInfo.Banner;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A34 RID: 10804 RVA: 0x0001BC31 File Offset: 0x00019E31
	public void method_22()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_15(new GetGuildApplicationsCallback(this.method_23), this.m_MyGuildInfo.Id);
	}

	// Token: 0x06002A35 RID: 10805 RVA: 0x000C62FC File Offset: 0x000C44FC
	protected void method_23(List<Presence> list_0)
	{
		this.m_ApplicationMap.Clear();
		if (list_0 != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				GuildManager.GuildApplicationData guildApplicationData = new GuildManager.GuildApplicationData();
				guildApplicationData.ApplicantPresence = list_0[i];
				if (!this.m_ApplicationMap.ContainsKey(list_0[i].mCharacterId))
				{
					this.m_ApplicationMap.Add(list_0[i].mCharacterId, guildApplicationData);
				}
			}
		}
	}

	// Token: 0x06002A36 RID: 10806 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_24(string string_0)
	{
	}

	// Token: 0x06002A37 RID: 10807 RVA: 0x0001BC54 File Offset: 0x00019E54
	public int method_25()
	{
		return this.m_SearchResult.Count;
	}

	// Token: 0x06002A38 RID: 10808 RVA: 0x0001BC61 File Offset: 0x00019E61
	public int method_26()
	{
		return this.m_AppliedGuild.Count;
	}

	// Token: 0x06002A39 RID: 10809 RVA: 0x000C636C File Offset: 0x000C456C
	public void method_27(bool bool_0)
	{
		List<InvitationReply> list = new List<InvitationReply>();
		list.Add(new InvitationReply
		{
			Reply = bool_0,
			GuildId = this.m_Invitation.guildId
		});
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_19(new ProcessGuildInvitationsCallback(this.method_77), list);
	}

	// Token: 0x06002A3A RID: 10810 RVA: 0x000C63BC File Offset: 0x000C45BC
	public void method_28(int int_0, bool bool_0)
	{
		if (!this.method_8() && !this.method_82())
		{
			return;
		}
		List<ApplicantApproval> list = new List<ApplicantApproval>();
		list.Clear();
		list.Add(new ApplicantApproval
		{
			IsAllowedToJoin = bool_0,
			ApplicantCharacterId = int_0
		});
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_16(new ProcessGuildApplicationsCallback(this.method_81), this.m_MyGuildInfo.Id, list);
		if (this.m_ApplicationMap.ContainsKey(int_0))
		{
			this.m_ApplicationMap.Remove(int_0);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A3B RID: 10811 RVA: 0x0001BC6E File Offset: 0x00019E6E
	public void method_29(int int_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_12(new ApplyToGuildCallback(this.method_62), int_0);
	}

	// Token: 0x06002A3C RID: 10812 RVA: 0x0001BC87 File Offset: 0x00019E87
	public void method_30(int int_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_13(new CancelMyGuildApplicationCallback(this.method_80), int_0);
	}

	// Token: 0x06002A3D RID: 10813 RVA: 0x000C6454 File Offset: 0x000C4654
	public void method_31(object object_0)
	{
		if ((this.method_8() || this.method_82()) && this.m_MyGuildInfo != null)
		{
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_17(new InviteToGuildCallback(this.method_78), this.m_MyGuildInfo.Id, (int)object_0);
		}
	}

	// Token: 0x06002A3E RID: 10814 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_32(int int_0)
	{
	}

	// Token: 0x06002A3F RID: 10815 RVA: 0x0001BCA0 File Offset: 0x00019EA0
	public void method_33(GuildPreference guildPreference_0, int int_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_11(new SearchGuildCallback(this.method_61), guildPreference_0, int_0);
	}

	// Token: 0x06002A40 RID: 10816 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildMemberJoin(int guildId, int characterId)
	{
	}

	// Token: 0x06002A41 RID: 10817 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnReceivedGuildMemberQuit(int guildId, int characterId)
	{
	}

	// Token: 0x06002A42 RID: 10818 RVA: 0x0001BCBA File Offset: 0x00019EBA
	public void method_34()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("GUILD_QUIT_WARNING")), new Delegate_EventProc(this.method_35), new Delegate_EventProc(this.method_36));
	}

	// Token: 0x06002A43 RID: 10819 RVA: 0x0001BCF7 File Offset: 0x00019EF7
	private void method_35()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_9(new QuitGuildCallback(this.method_42), this.m_MyGuildInfo.Id);
	}

	// Token: 0x06002A44 RID: 10820 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_36()
	{
	}

	// Token: 0x06002A45 RID: 10821 RVA: 0x0001BD1A File Offset: 0x00019F1A
	public void method_37(object object_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_10(new ExpellFromGuildCallback(this.method_43), this.m_MyGuildInfo.Id, (int)object_0);
	}

	// Token: 0x06002A46 RID: 10822 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_38()
	{
	}

	// Token: 0x06002A47 RID: 10823 RVA: 0x0001BD43 File Offset: 0x00019F43
	protected void method_39()
	{
		this.m_bInGuild = true;
	}

	// Token: 0x06002A48 RID: 10824 RVA: 0x0001BD4C File Offset: 0x00019F4C
	protected void method_40()
	{
		this.m_bInGuild = false;
	}

	// Token: 0x06002A49 RID: 10825 RVA: 0x0001BD43 File Offset: 0x00019F43
	protected void method_41()
	{
		this.m_bInGuild = true;
	}

	// Token: 0x06002A4A RID: 10826 RVA: 0x000C64A0 File Offset: 0x000C46A0
	protected void method_42(bool bool_0)
	{
		if (bool_0)
		{
			this.m_bInGuild = false;
			this.m_nChairmanID = -1;
			this.m_MyGuildInfo = null;
			this.m_GuildSkillList.Clear();
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_1 = false;
			}
		}
	}

	// Token: 0x06002A4B RID: 10827 RVA: 0x000C64FC File Offset: 0x000C46FC
	protected void method_43(bool bool_0, int int_0)
	{
		if (!bool_0)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < m_MyGuildInfo.mMemberList.Count; i++)
		{
			if (m_MyGuildInfo.mMemberList[i].mCharacterId == int_0)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			m_MyGuildInfo.mMemberList.RemoveAt(num);
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5();
		}
	}
	// Token: 0x06002A4C RID: 10828 RVA: 0x0001BD55 File Offset: 0x00019F55
	protected void method_44(bool bool_0)
	{
		if (bool_0)
		{
			this.m_bInGuild = false;
			this.m_nChairmanID = -1;
			this.m_MyGuildInfo = null;
			this.m_GuildSkillList.Clear();
		}
	}

	// Token: 0x06002A4D RID: 10829 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_45()
	{
	}

	// Token: 0x06002A4E RID: 10830 RVA: 0x0001BD7A File Offset: 0x00019F7A
	public void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount)
	{
		this.method_14();
	}

	// Token: 0x06002A4F RID: 10831 RVA: 0x0001BD82 File Offset: 0x00019F82
	public void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount)
	{
		if (!this.m_GuildSkillList.Contains(skillId))
		{
			this.m_GuildSkillList.Add(skillId);
		}
		this.m_MyGuildInfo.FreeSkillCount = remainFreeSkillCount;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A50 RID: 10832 RVA: 0x0001BDBF File Offset: 0x00019FBF
	public void OnReceivedGuildManagerAssigned(int guildId)
	{
		if (this.m_MyGuildInfo != null && this.m_MyGuildInfo.Id == guildId && !this.m_GuildManagerList.Contains(OnlineService.s_characterId))
		{
			this.m_GuildManagerList.Add(OnlineService.s_characterId);
			this.method_11();
		}
	}

	// Token: 0x06002A51 RID: 10833 RVA: 0x000C6574 File Offset: 0x000C4774
	public void OnReceivedGuildManagerDischarged(int guildId)
	{
		if (this.m_MyGuildInfo != null && this.m_MyGuildInfo.Id == guildId && this.m_GuildManagerList.Contains(OnlineService.s_characterId))
		{
			this.m_GuildManagerList.Remove(OnlineService.s_characterId);
			this.method_11();
		}
	}

	// Token: 0x06002A52 RID: 10834 RVA: 0x0001BD7A File Offset: 0x00019F7A
	public void OnReceivedGuildMasterChanged(int guildId)
	{
		this.method_14();
	}

	// Token: 0x06002A53 RID: 10835 RVA: 0x000C65C0 File Offset: 0x000C47C0
	public void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName)
	{
		if (this.m_bCanShowMessage && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildOptionView>().Boolean_0)
		{
			this.m_Invitation.guildId = guildId;
			this.m_Invitation.guildMasterName = guildMasterNick;
			this.m_Invitation.guildName = guildName;
			this.m_bCanShowMessage = false;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildOptionView>().Boolean_1 = true;
		}
	}

	// Token: 0x06002A54 RID: 10836 RVA: 0x000C662C File Offset: 0x000C482C
	public void OnReceivedGuildJoined(int guildId, string guildName, bool isJoined)
	{
		if (isJoined)
		{
			if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				DebugUtils.Log(LogCategory.Network, MonoSingleton<Session>.Instance.GetLocalPlayer().m_name + " Join " + guildName);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.Guild, string.Empty, Utility.smethod_5(LocalizedString.smethod_0(new LocalizedString("GUILD_JOIN_SUCCESS")), guildName), 0, string.Empty);
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().Boolean_1 = false;
			}
			this.method_14();
		}
	}

	// Token: 0x06002A55 RID: 10837 RVA: 0x0001BDFF File Offset: 0x00019FFF
	public void OnReceivedGuildExpelled(int guildId, string guildName, bool isGuildDismissed)
	{
		if (this.m_MyGuildInfo != null && guildId == this.m_MyGuildInfo.Id)
		{
			this.m_bInGuild = false;
			this.m_nChairmanID = -1;
			this.m_MyGuildInfo = null;
		}
	}

	// Token: 0x06002A56 RID: 10838 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_46()
	{
	}

	// Token: 0x06002A57 RID: 10839 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_47()
	{
	}

	// Token: 0x06002A58 RID: 10840 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_48(string string_0)
	{
	}

	// Token: 0x06002A59 RID: 10841 RVA: 0x000C66D8 File Offset: 0x000C48D8
	protected void method_49(GuildCreationResult guildCreationResult_0, Guild guild_0)
	{
		if (guild_0 != null)
		{
			this.m_bInGuild = true;
			this.m_nChairmanID = guild_0.MasterCharacterId;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildCreateView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildCreateView>().vmethod_4();
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_15();
			}
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		}
		else
		{
			if (guildCreationResult_0 == GuildCreationResult.FAILURE_GUILDNAME_EXISTS)
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81003");
			}
			if (guildCreationResult_0 == GuildCreationResult.FAILURE_INSUFFICIENCY_MONEY)
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81004");
			}
			if (guildCreationResult_0 == GuildCreationResult.FAILURE_GUILDNAME_PROFANITY)
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81007");
			}
		}
		this.m_MyGuildInfo = guild_0;
	}

	// Token: 0x06002A5A RID: 10842 RVA: 0x0001BE2C File Offset: 0x0001A02C
	private void method_50(int int_0, Guild guild_0)
	{
		if (guild_0 != null && guild_0.Id != -1)
		{
			this.m_bInGuild = true;
			this.m_nChairmanID = guild_0.MasterCharacterId;
		}
		this.m_MyGuildInfo = guild_0;
	}

	// Token: 0x06002A5B RID: 10843 RVA: 0x000C67A0 File Offset: 0x000C49A0
	private void method_51(int int_0, Guild guild_0)
	{
		if (guild_0 != null && guild_0.Id != -1)
		{
			this.m_bInGuild = true;
			this.m_nChairmanID = guild_0.MasterCharacterId;
			this.m_strGuildDec = guild_0.Banner;
		}
		this.m_MyGuildInfo = guild_0;
		if (this.m_MyGuildInfo == null)
		{
			this.m_bInGuild = false;
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_14(new GetMyGuildApplicationsCallback(this.method_79));
		}
		else
		{
			this.method_58();
			this.method_52();
		}
	}

	// Token: 0x06002A5C RID: 10844 RVA: 0x0001BE54 File Offset: 0x0001A054
	public void method_52()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_24(new GetMyGuildSkillListCallback(this.method_53));
	}

	// Token: 0x06002A5D RID: 10845 RVA: 0x000C6814 File Offset: 0x000C4A14
	private void method_53(List<GuildSkill> list_0)
	{
		this.m_GuildSkillList.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			this.m_GuildSkillList.Add(list_0[i].Id);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildSkill);
	}

	// Token: 0x06002A5E RID: 10846 RVA: 0x0001BE6C File Offset: 0x0001A06C
	public void method_54(int int_0)
	{
		if ((this.method_8() || this.method_82()) && this.m_MyGuildInfo != null && this.m_MyGuildInfo.FreeSkillCount > 0)
		{
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_23(new ActivateGuildSkillCallback(this.method_55), int_0);
		}
	}

	// Token: 0x06002A5F RID: 10847 RVA: 0x0001BEAB File Offset: 0x0001A0AB
	private void method_55(bool bool_0, int int_0)
	{
		if (bool_0)
		{
			if (!this.m_GuildSkillList.Contains(int_0))
			{
				this.m_GuildSkillList.Add(int_0);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
		}
	}

	// Token: 0x06002A60 RID: 10848 RVA: 0x000C686C File Offset: 0x000C4A6C
	public bool method_56(int int_0)
	{
		if (m_MyGuildInfo == null)
		{
			return true;
		}
		if (m_GuildSkillList.Contains(int_0))
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills.Length; i++)
		{
			if (ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[i].m_id == int_0)
			{
				num = ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[i].m_unlockLevel;
				break;
			}
		}
		if (num == 0)
		{
			return true;
		}
		if (m_MyGuildInfo.Level < num)
		{
			return true;
		}
		int num2 = -1;
		int num3 = -1;
		int num4 = 0;
		for (int j = 0; j < ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills.Length; j++)
		{
			if (ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[j].m_unlockLevel == num)
			{
				if (num4 == 0)
				{
					num2 = ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[j].m_id;
					num4++;
				}
				else
				{
					num3 = ns0.MonoSingleton<GuildProgressionSetting>.Instance.m_progressionSetup.m_guildSkills[j].m_id;
				}
			}
		}
		if (num2 == int_0 && m_GuildSkillList.Contains(num3))
		{
			return true;
		}
		if (num3 == int_0 && m_GuildSkillList.Contains(num2))
		{
			return true;
		}
		return false;
	}
	// Token: 0x06002A61 RID: 10849 RVA: 0x0001BEDF File Offset: 0x0001A0DF
	public bool method_57(int int_0)
	{
		return this.m_GuildSkillList.Contains(int_0);
	}

	// Token: 0x06002A62 RID: 10850 RVA: 0x0001BEED File Offset: 0x0001A0ED
	public void method_58()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_25(new GetGuildManagerListCallback(this.method_59), this.m_MyGuildInfo.Id);
	}

	// Token: 0x06002A63 RID: 10851 RVA: 0x000C69A0 File Offset: 0x000C4BA0
	public void method_59(List<int> list_0)
	{
		this.m_GuildManagerList.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			this.m_GuildManagerList.Add(list_0[i]);
		}
		this.method_11();
	}

	// Token: 0x06002A64 RID: 10852 RVA: 0x000C69E4 File Offset: 0x000C4BE4
	private void method_60(bool bool_0)
	{
		if (bool_0)
		{
			this.m_bInGuild = false;
			this.m_nChairmanID = -1;
			this.m_MyGuildInfo = null;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCInteractiveView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCInteractiveView>().method_3();
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_20();
			}
		}
	}

	// Token: 0x06002A65 RID: 10853 RVA: 0x000C6A60 File Offset: 0x000C4C60
	private void method_61(List<Guild> list_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_7() == 0)
		{
			this.m_SearchResult.Clear();
			if (list_0 != null)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					this.m_SearchResult.Add(list_0[i]);
				}
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_6(list_0.Count);
		}
		else
		{
			if (list_0.Count != 0)
			{
				this.m_SearchResult.Clear();
				if (list_0 != null)
				{
					for (int j = 0; j < list_0.Count; j++)
					{
						this.m_SearchResult.Add(list_0[j]);
					}
				}
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_6(list_0.Count);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A66 RID: 10854 RVA: 0x000C6B3C File Offset: 0x000C4D3C
	private void method_62(bool bool_0, int int_0, int int_1, List<Guild> list_0)
	{
		this.m_AppliedGuild.Clear();
		if (bool_0 && !this.m_AppliedGuildID.Contains(int_0))
		{
			this.m_AppliedGuildID.Add(int_0);
		}
		if (list_0 != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				this.m_AppliedGuild.Add(list_0[i]);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A67 RID: 10855 RVA: 0x0001BF10 File Offset: 0x0001A110
	public bool method_63()
	{
		return this.m_AppliedGuild.Count > 10;
	}

	// Token: 0x06002A68 RID: 10856 RVA: 0x0001BF21 File Offset: 0x0001A121
	public bool method_64(int int_0)
	{
		return this.m_AppliedGuildID.Contains(int_0);
	}

	// Token: 0x06002A69 RID: 10857 RVA: 0x0001BF2F File Offset: 0x0001A12F
	public int method_65()
	{
		if (this.m_AppliedGuildID.Count > 10)
		{
			return 0;
		}
		return 10 - this.m_AppliedGuildID.Count;
	}

	// Token: 0x06002A6A RID: 10858 RVA: 0x000C6BB0 File Offset: 0x000C4DB0
	public bool method_66(int int_0)
	{
		bool flag = !this.method_63();
		if (this.m_MyGuildInfo != null)
		{
			if (this.m_MyGuildInfo.Id == int_0)
			{
				flag = false;
			}
		}
		else if (this.m_AppliedGuildID.Contains(int_0))
		{
			flag = false;
		}
		else
		{
			for (int i = 0; i < this.m_AppliedGuild.Count; i++)
			{
				if (int_0 == this.m_AppliedGuild[i].Id)
				{
					flag = false;
					break;
				}
			}
		}
		return flag;
	}

	// Token: 0x06002A6B RID: 10859 RVA: 0x0001BF50 File Offset: 0x0001A150
	public void method_67()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_14(new GetMyGuildApplicationsCallback(this.method_79));
	}

	// Token: 0x06002A6C RID: 10860 RVA: 0x000C6C28 File Offset: 0x000C4E28
	public Guild method_68(int int_0)
	{
		Guild guild = null;
		if (int_0 >= 0 && int_0 < this.m_SearchResult.Count)
		{
			guild = this.m_SearchResult[int_0];
		}
		return guild;
	}

	// Token: 0x06002A6D RID: 10861 RVA: 0x000C6C58 File Offset: 0x000C4E58
	public Guild method_69(int int_0)
	{
		Guild guild = null;
		if (int_0 >= 0 && int_0 < this.m_AppliedGuild.Count)
		{
			guild = this.m_AppliedGuild[int_0];
		}
		return guild;
	}

	// Token: 0x06002A6E RID: 10862 RVA: 0x000C6C88 File Offset: 0x000C4E88
	public Presence method_70(int int_0)
	{
		Presence presence = null;
		if (int_0 >= 0 && int_0 < this.m_ApplicationMap.Count)
		{
			presence = this.m_ApplicationMap.ElementAt<KeyValuePair<int, GuildManager.GuildApplicationData>>(int_0).Value.ApplicantPresence;
		}
		return presence;
	}

	// Token: 0x06002A6F RID: 10863 RVA: 0x000C6CC4 File Offset: 0x000C4EC4
	public Presence method_71(int int_0)
	{
		Presence presence = null;
		if (int_0 >= 0 && int_0 < this.m_MyGuildInfo.mMemberList.Count)
		{
			presence = this.m_MyGuildInfo.mMemberList[int_0];
		}
		return presence;
	}

	// Token: 0x06002A70 RID: 10864 RVA: 0x000C6D00 File Offset: 0x000C4F00
	public int method_72()
	{
		int num = 0;
		if (this.m_MyGuildInfo != null)
		{
			num = this.m_MyGuildInfo.mMemberList.Count;
		}
		return num;
	}

	// Token: 0x06002A71 RID: 10865 RVA: 0x000C6D2C File Offset: 0x000C4F2C
	public int method_73()
	{
		int num = 0;
		if (this.m_MyGuildInfo != null)
		{
			for (int i = 0; i < this.m_MyGuildInfo.mMemberList.Count; i++)
			{
				if (this.m_MyGuildInfo.mMemberList[i].mIsOnline)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06002A72 RID: 10866 RVA: 0x000C6D7C File Offset: 0x000C4F7C
	public bool method_74()
	{
		bool flag = false;
		for (int i = 0; i < this.m_MyGuildInfo.mMemberList.Count; i++)
		{
			if (this.method_9(this.m_MyGuildInfo.mMemberList[i].mCharacterId))
			{
				flag = this.m_MyGuildInfo.mMemberList[i].mIsOnline;
				return flag;
			}
		}
		return flag;
	}

	// Token: 0x06002A73 RID: 10867 RVA: 0x000C6DE0 File Offset: 0x000C4FE0
	public GuildManager.ApplicationStatus method_75(int int_0)
	{
		GuildManager.ApplicationStatus applicationStatus = GuildManager.ApplicationStatus.e_WaitingForDecide;
		if (int_0 >= 0 && int_0 < this.m_ApplicationMap.Count)
		{
			applicationStatus = this.m_ApplicationMap.ElementAt<KeyValuePair<int, GuildManager.GuildApplicationData>>(int_0).Value.Status;
		}
		return applicationStatus;
	}

	// Token: 0x06002A74 RID: 10868 RVA: 0x0001BF68 File Offset: 0x0001A168
	public int method_76()
	{
		return this.m_ApplicationMap.Count;
	}

	// Token: 0x06002A75 RID: 10869 RVA: 0x000C6E1C File Offset: 0x000C501C
	private void method_77(Guild guild_0)
	{
		this.m_bCanShowMessage = true;
		if (guild_0 != null)
		{
			this.m_bInGuild = true;
			this.m_nChairmanID = guild_0.MasterAccountId;
			this.m_MyGuildInfo = guild_0;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.Guild, string.Empty, Utility.smethod_5(LocalizedString.smethod_0(new LocalizedString("GUILD_JOIN_SUCCESS")), guild_0.Name), 0, string.Empty);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildOptionView>().Boolean_1 = false;
	}

	// Token: 0x06002A76 RID: 10870 RVA: 0x0001BF75 File Offset: 0x0001A175
	private void method_78(GuildInvitationResult guildInvitationResult_0)
	{
		if (guildInvitationResult_0 != GuildInvitationResult.SUCCESS)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81001");
		}
	}

	// Token: 0x06002A77 RID: 10871 RVA: 0x000C6E9C File Offset: 0x000C509C
	private void method_79(List<Guild> list_0)
	{
		this.m_AppliedGuild.Clear();
		this.m_AppliedGuildID.Clear();
		if (list_0 != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				this.m_AppliedGuild.Add(list_0[i]);
				this.m_AppliedGuildID.Add(list_0[i].Id);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_None);
	}

	// Token: 0x06002A78 RID: 10872 RVA: 0x0001BF89 File Offset: 0x0001A189
	private void method_80(bool bool_0)
	{
		if (bool_0)
		{
			ServiceWrapperBase<GuildServiceWrapper>.Instance.method_14(new GetMyGuildApplicationsCallback(this.method_79));
		}
	}

	// Token: 0x06002A79 RID: 10873 RVA: 0x0001BFA4 File Offset: 0x0001A1A4
	private void method_81(int int_0, int int_1)
	{
		if (int_1 > 0)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81009");
		}
	}

	// Token: 0x06002A7A RID: 10874 RVA: 0x0001BFB9 File Offset: 0x0001A1B9
	public bool method_82()
	{
		return this.m_bInGuild && this.m_GuildManagerList.Contains(OnlineService.s_characterId);
	}

	// Token: 0x06002A7B RID: 10875 RVA: 0x0001BFD5 File Offset: 0x0001A1D5
	public bool method_83(int int_0)
	{
		return this.m_GuildManagerList.Contains(int_0);
	}

	// Token: 0x06002A7C RID: 10876 RVA: 0x0001BFE8 File Offset: 0x0001A1E8
	public void method_84(object object_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_21(new AssignGuildManagerCallback(this.method_85), this.m_MyGuildInfo.Id, (int)object_0);
	}

	// Token: 0x06002A7D RID: 10877 RVA: 0x0001C011 File Offset: 0x0001A211
	private void method_85(bool bool_0, int int_0)
	{
		if (bool_0)
		{
			if (!this.m_GuildManagerList.Contains(int_0))
			{
				this.m_GuildManagerList.Add(int_0);
				this.method_11();
			}
		}
		else
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81014");
		}
	}

	// Token: 0x06002A7E RID: 10878 RVA: 0x0001C047 File Offset: 0x0001A247
	public void method_86(object object_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_22(new DischargeGuildManagerCallback(this.method_87), this.m_MyGuildInfo.Id, (int)object_0);
	}

	// Token: 0x06002A7F RID: 10879 RVA: 0x0001C070 File Offset: 0x0001A270
	private void method_87(bool bool_0, int int_0)
	{
		if (bool_0 && this.m_GuildManagerList.Contains(int_0))
		{
			this.m_GuildManagerList.Remove(int_0);
			this.method_11();
		}
	}

	// Token: 0x06002A80 RID: 10880 RVA: 0x0001C096 File Offset: 0x0001A296
	public void method_88(object object_0)
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_8(new ChangeGuildMasterCallback(this.method_89), (int)object_0);
	}

	// Token: 0x06002A81 RID: 10881 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
	private void method_89(bool bool_0, int int_0)
	{
		if (bool_0)
		{
			this.m_MyGuildInfo.MasterCharacterId = int_0;
			this.m_nChairmanID = int_0;
			this.method_11();
		}
	}

	// Token: 0x06002A82 RID: 10882 RVA: 0x0001C0D2 File Offset: 0x0001A2D2
	public string method_90()
	{
		if (this.m_MyGuildInfo != null)
		{
			return this.m_MyGuildInfo.Name;
		}
		return string.Empty;
	}

	// Token: 0x06002A83 RID: 10883 RVA: 0x000C6F14 File Offset: 0x000C5114
	public int method_91()
	{
		int num = 1;
		if (this.m_MyGuildInfo != null)
		{
			num = this.m_MyGuildInfo.Level;
		}
		return num;
	}

	// Token: 0x06002A84 RID: 10884 RVA: 0x0001C0ED File Offset: 0x0001A2ED
	public string method_92()
	{
		return this.m_strGuildDec;
	}

	// Token: 0x06002A85 RID: 10885 RVA: 0x0001C0F5 File Offset: 0x0001A2F5
	public void method_93()
	{
		this.m_SearchResult.Clear();
	}

	// Token: 0x06002A86 RID: 10886 RVA: 0x0001C102 File Offset: 0x0001A302
	public void method_94()
	{
		ServiceWrapperBase<GuildServiceWrapper>.Instance.method_20(new GetMyGuildNewsCallback(this.method_95));
	}

	// Token: 0x06002A87 RID: 10887 RVA: 0x000C6F38 File Offset: 0x000C5138
	protected void method_95(List<GuildNews> list_0)
	{
		this.m_GuildNews.Clear();
		if (list_0 != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				this.m_GuildNews.Add(list_0[i]);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_5(GuildSearchView.GuildSearchPart.e_GuildNews);
	}

	// Token: 0x06002A88 RID: 10888 RVA: 0x0001C11A File Offset: 0x0001A31A
	public int method_96()
	{
		return this.m_GuildNews.Count;
	}

	// Token: 0x06002A89 RID: 10889 RVA: 0x000C6F8C File Offset: 0x000C518C
	public Presence method_97(int int_0)
	{
		Presence presence = null;
		if (this.m_MyGuildInfo != null)
		{
			for (int i = 0; i < this.m_MyGuildInfo.List_0.Count; i++)
			{
				if (this.m_MyGuildInfo.List_0[i].mCharacterId == int_0)
				{
					presence = this.m_MyGuildInfo.List_0[i];
					break;
				}
			}
		}
		return presence;
	}

	// Token: 0x06002A8A RID: 10890 RVA: 0x0001C127 File Offset: 0x0001A327
	public GuildNews method_98(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_GuildNews.Count)
		{
			return this.m_GuildNews[int_0];
		}
		return null;
	}

	// Token: 0x06002A8B RID: 10891 RVA: 0x000C6FF0 File Offset: 0x000C51F0
	public int method_99()
	{
		int num = 0;
		if (this.m_MyGuildInfo != null)
		{
			return this.m_MyGuildInfo.FreeSkillCount;
		}
		return num;
	}

	// Token: 0x06002A8C RID: 10892 RVA: 0x0001C149 File Offset: 0x0001A349
	public int method_100()
	{
		if (this.m_MyGuildInfo == null)
		{
			return 0;
		}
		return this.m_MyGuildInfo.Level;
	}

	// Token: 0x06002A8D RID: 10893 RVA: 0x000C7014 File Offset: 0x000C5214
	public void method_101(int int_0)
	{
		if (int_0 == -1)
		{
			return;
		}
		Presence presence = this.method_97(int_0);
		MenuItemDef[] array = new MenuItemDef[7];
		array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Invitation"));
		array[0].itemData = int_0;
		if (GroupManager.smethod_0().method_18() && (!GroupManager.smethod_0().method_19() || GroupManager.smethod_0().method_17(int_0)))
		{
			array[0].itemFunc = null;
		}
		else if (OnlineService.s_characterId != int_0)
		{
			GroupManager.smethod_0().method_0(int_0);
			array[0].itemFunc = new MenuItemProcessFunc(GroupManager.smethod_0().method_14);
		}
		else
		{
			array[0].itemFunc = null;
		}
		array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("Friend_Invitation"));
		array[1].itemData = int_0;
		if (!FriendManager.smethod_0().method_26(int_0) && FriendManager.smethod_0().method_13() && OnlineService.s_characterId != int_0)
		{
			FriendManager.smethod_0().method_1(int_0);
			array[1].itemFunc = new MenuItemProcessFunc(FriendManager.smethod_0().method_14);
		}
		else
		{
			array[1].itemFunc = null;
		}
		array[2].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Exple"));
		array[2].itemData = int_0;
		if ((this.method_8() || this.method_82()) && int_0 != this.m_MyGuildInfo.MasterCharacterId)
		{
			if (this.method_8())
			{
				array[2].itemFunc = new MenuItemProcessFunc(this.method_37);
			}
			else if (this.method_82())
			{
				if (this.method_83(int_0))
				{
					array[2].itemFunc = null;
				}
				else
				{
					array[2].itemFunc = new MenuItemProcessFunc(this.method_37);
				}
			}
			else
			{
				array[2].itemFunc = null;
			}
		}
		else
		{
			array[2].itemFunc = null;
		}
		array[3].itemTitle = LocalizedString.smethod_0(new LocalizedString("GUILD_Manager_Assign"));
		array[3].itemData = int_0;
		if (this.method_8() && !this.method_83(int_0) && OnlineService.s_characterId != int_0)
		{
			if (this.m_GuildManagerList.Count < this.m_nMaxGuildManagerCount)
			{
				array[3].itemFunc = new MenuItemProcessFunc(this.method_84);
			}
			else
			{
				array[3].itemFunc = null;
			}
		}
		else
		{
			array[3].itemFunc = null;
		}
		array[4].itemTitle = LocalizedString.smethod_0(new LocalizedString("GUILD_Manager_Discharge"));
		array[4].itemData = int_0;
		if (this.method_8() && this.method_83(int_0) && OnlineService.s_characterId != int_0)
		{
			array[4].itemFunc = new MenuItemProcessFunc(this.method_86);
		}
		else
		{
			array[4].itemFunc = null;
		}
		array[5].itemTitle = LocalizedString.smethod_0(new LocalizedString("GUILD_Owner_Assign"));
		array[5].itemData = int_0;
		if (this.method_8() && OnlineService.s_characterId != int_0)
		{
			array[5].itemFunc = new MenuItemProcessFunc(this.method_88);
		}
		else
		{
			array[5].itemFunc = null;
		}
		array[6].itemTitle = LocalizedString.smethod_0(new LocalizedString("Chat_Send"));
		if (presence != null)
		{
			array[6].itemData = presence.mCharacterName;
			if (presence.mIsOnline)
			{
				if (presence.mCharacterName == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9())
				{
					array[6].itemFunc = null;
				}
				else
				{
					array[6].itemFunc = new MenuItemProcessFunc(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_3);
				}
			}
			else
			{
				array[6].itemFunc = null;
			}
		}
		else
		{
			array[6].itemFunc = null;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
	}

	// Token: 0x04001DF2 RID: 7666
	public int m_nMaxGuildMemberCount = 200;

	// Token: 0x04001DF3 RID: 7667
	public int m_nMaxGuildManagerCount = 3;

	// Token: 0x04001DF4 RID: 7668
	protected static GuildManager _GuildInstance;

	// Token: 0x04001DF5 RID: 7669
	private bool m_bInGuild;

	// Token: 0x04001DF6 RID: 7670
	private int m_nChairmanID = -1;

	// Token: 0x04001DF7 RID: 7671
	public bool m_bCanShowMessage = true;

	// Token: 0x04001DF8 RID: 7672
	public GuildManager.GuildInvitationData m_Invitation;

	// Token: 0x04001DF9 RID: 7673
	private string m_strGuildDec = string.Empty;

	// Token: 0x04001DFA RID: 7674
	private int m_nMaxLevel;

	// Token: 0x04001DFB RID: 7675
	private Guild m_MyGuildInfo;

	// Token: 0x04001DFC RID: 7676
	private List<Guild> m_SearchResult;

	// Token: 0x04001DFD RID: 7677
	private List<Guild> m_AppliedGuild;

	// Token: 0x04001DFE RID: 7678
	private List<int> m_AppliedGuildID;

	// Token: 0x04001DFF RID: 7679
	private Dictionary<int, GuildManager.GuildApplicationData> m_ApplicationMap;

	// Token: 0x04001E00 RID: 7680
	private List<GuildNews> m_GuildNews;

	// Token: 0x04001E01 RID: 7681
	private List<int> m_GuildManagerList;

	// Token: 0x04001E02 RID: 7682
	private List<int> m_GuildSkillList;

	// Token: 0x04001E03 RID: 7683
	private Dictionary<int, int> m_GuildProgressionTable;

	// Token: 0x0200067A RID: 1658
	public struct GuildInvitationData
	{
		// Token: 0x04001E04 RID: 7684
		public int guildId;

		// Token: 0x04001E05 RID: 7685
		public string guildName;

		// Token: 0x04001E06 RID: 7686
		public string guildMasterName;
	}

	// Token: 0x0200067B RID: 1659
	public enum ApplicationStatus
	{
		// Token: 0x04001E08 RID: 7688
		e_WaitingForDecide,
		// Token: 0x04001E09 RID: 7689
		e_Accepted,
		// Token: 0x04001E0A RID: 7690
		e_Rejected
	}

	// Token: 0x0200067C RID: 1660
	private class GuildApplicationData
	{
		// Token: 0x06002A8E RID: 10894 RVA: 0x0001C160 File Offset: 0x0001A360
		public GuildApplicationData()
		{
			this.Status = GuildManager.ApplicationStatus.e_WaitingForDecide;
		}

		// Token: 0x04001E0B RID: 7691
		public Presence ApplicantPresence;

		// Token: 0x04001E0C RID: 7692
		public GuildManager.ApplicationStatus Status;
	}
}
