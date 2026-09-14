using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200038B RID: 907
public class GuildService : OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>, IGuildService
{
	// Token: 0x060016B7 RID: 5815 RVA: 0x0007C36C File Offset: 0x0007A56C
	public GuildService()
	{
		PhotonNetwork.onlinePeer.method_5(100, new OperationResponseCallback(this.OnChangeGuildBannerCallback));
		PhotonNetwork.onlinePeer.method_5(101, new OperationResponseCallback(this.OnMyGuildInfoCallback));
		PhotonNetwork.onlinePeer.method_5(102, new OperationResponseCallback(this.OnMyGuildIdCallback));
		PhotonNetwork.onlinePeer.method_5(103, new OperationResponseCallback(this.OnGuildInfoCallback));
		PhotonNetwork.onlinePeer.method_5(104, new OperationResponseCallback(this.OnCreateGuildCallback));
		PhotonNetwork.onlinePeer.method_5(105, new OperationResponseCallback(this.OnDismissGuildCallback));
		PhotonNetwork.onlinePeer.method_5(107, new OperationResponseCallback(this.OnChangeGuildMasterCallback));
		PhotonNetwork.onlinePeer.method_5(112, new OperationResponseCallback(this.OnQuitGuildCallback));
		PhotonNetwork.onlinePeer.method_5(113, new OperationResponseCallback(this.OnExpellFromGuildCallback));
		PhotonNetwork.onlinePeer.method_5(108, new OperationResponseCallback(this.OnSearchGuildCallback));
		PhotonNetwork.onlinePeer.method_5(109, new OperationResponseCallback(this.OnApplyToGuildCallback));
		PhotonNetwork.onlinePeer.method_5(110, new OperationResponseCallback(this.OnGetGuildApplicationsCallback));
		PhotonNetwork.onlinePeer.method_5(77, new OperationResponseCallback(this.OnGetMyGuildApplicationsCallback));
		PhotonNetwork.onlinePeer.method_5(76, new OperationResponseCallback(this.OnCancelMyGuildApplicationCallback));
		PhotonNetwork.onlinePeer.method_5(111, new OperationResponseCallback(this.OnProcessGuildApplicationsCallback));
		PhotonNetwork.onlinePeer.method_5(114, new OperationResponseCallback(this.OnInviteToGuildCallback));
		PhotonNetwork.onlinePeer.method_5(115, new OperationResponseCallback(this.OnGetMyGuildInvitationsCallback));
		PhotonNetwork.onlinePeer.method_5(116, new OperationResponseCallback(this.OnProcessGuildInvitationsCallback));
		PhotonNetwork.onlinePeer.method_5(78, new OperationResponseCallback(this.OnGetMyGuildNewsCallback));
		PhotonNetwork.onlinePeer.method_5(73, new OperationResponseCallback(this.OnAssignGuildManagerCallback));
		PhotonNetwork.onlinePeer.method_5(72, new OperationResponseCallback(this.OnDischargeGuildManagerCallback));
		PhotonNetwork.onlinePeer.method_5(64, new OperationResponseCallback(this.OnActivateGuildSkillCallback));
		PhotonNetwork.onlinePeer.method_5(65, new OperationResponseCallback(this.OnGetMyGuildSkillListCallback));
		PhotonNetwork.onlinePeer.method_5(63, new OperationResponseCallback(this.OnGetGuildManagerListCallback));
		PhotonNetwork.onlinePeer.method_7(231, new EventCallback(this.OnGuildInvitationEvent));
		PhotonNetwork.onlinePeer.method_7(232, new EventCallback(this.OnGuildJoinedEvent));
		PhotonNetwork.onlinePeer.method_7(233, new EventCallback(this.OnGuildExpelledEvent));
		PhotonNetwork.onlinePeer.method_7(234, new EventCallback(this.OnFreeGuildSkillSlotGivenEvent));
		PhotonNetwork.onlinePeer.method_7(235, new EventCallback(this.OnGuildSkillSelectedEvent));
		PhotonNetwork.onlinePeer.method_7(236, new EventCallback(this.OnGuildManagerAssignedEvent));
		PhotonNetwork.onlinePeer.method_7(237, new EventCallback(this.OnGuildManagerDischargedEvent));
		PhotonNetwork.onlinePeer.method_7(238, new EventCallback(this.OnGuildMasterChangedEvent));
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x00010B7D File Offset: 0x0000ED7D
	public void imethod_0(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0)
	{
		this.mOnChangedGuildBanner = changeGuildBannerCallback_0;
		PhotonNetwork.onlinePeer.method_3(100, new object[] { int_0, string_0 });
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x00010BA6 File Offset: 0x0000EDA6
	private void OnChangeGuildBannerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnChangedGuildBanner != null)
		{
			if (operationResponse == 0)
			{
				this.mOnChangedGuildBanner(true);
			}
			else
			{
				this.mOnChangedGuildBanner(false);
			}
			this.mOnChangedGuildBanner = null;
		}
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x00010BD4 File Offset: 0x0000EDD4
	public void imethod_1(GetMyGuildInfoCallback getMyGuildInfoCallback_0)
	{
		this.mOnGotMyGuildInfo = getMyGuildInfoCallback_0;
		PhotonNetwork.onlinePeer.method_3(101, new object[0]);
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x0007C708 File Offset: 0x0007A908
	private void OnMyGuildInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildInfo != null)
		{
			if (operationResponse == 0 && parameters.Count == 2 && parameters[0] != null && parameters[1] != null)
			{
				int num = (int)parameters[0];
				Guild guild = new Guild((Hashtable)parameters[1]);
				this.mOnGotMyGuildInfo(num, guild);
			}
			else
			{
				this.mOnGotMyGuildInfo(-1, null);
			}
			this.mOnGotMyGuildInfo = null;
		}
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x00010BF0 File Offset: 0x0000EDF0
	public void imethod_2(GetMyGuildIdCallback getMyGuildIdCallback_0)
	{
		this.mOnGotMyGuildId = getMyGuildIdCallback_0;
		PhotonNetwork.onlinePeer.method_3(102, new object[0]);
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x0007C780 File Offset: 0x0007A980
	private void OnMyGuildIdCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildId != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = (int)parameters[0];
				this.mOnGotMyGuildId(num);
			}
			else
			{
				this.mOnGotMyGuildId(-1);
			}
			this.mOnGotMyGuildId = null;
		}
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x00010C0C File Offset: 0x0000EE0C
	public void imethod_3(GetGuildInfoCallback getGuildInfoCallback_0, int int_0)
	{
		this.mOnGotGuildInfo = getGuildInfoCallback_0;
		PhotonNetwork.onlinePeer.method_3(103, new object[] { int_0 });
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x0007C7D8 File Offset: 0x0007A9D8
	private void OnGuildInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotGuildInfo != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				Guild guild = new Guild((Hashtable)parameters[0]);
				this.mOnGotGuildInfo(guild);
			}
			else
			{
				this.mOnGotGuildInfo(null);
			}
			this.mOnGotGuildInfo = null;
		}
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x00010C31 File Offset: 0x0000EE31
	public void imethod_4(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None)
	{
		this.mOnCreatedGuild = createGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(104, new object[] { string_0, string_1, guildPreference_0 });
	}

	// Token: 0x060016C1 RID: 5825 RVA: 0x0007C838 File Offset: 0x0007AA38
	private void OnCreateGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnCreatedGuild != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				GuildCreationResult guildCreationResult = (GuildCreationResult)((int)parameters[0]);
				this.mOnCreatedGuild(guildCreationResult, (parameters.Count <= 1 || parameters[1] == null) ? null : new Guild((Hashtable)parameters[1]));
			}
			else
			{
				this.mOnCreatedGuild(GuildCreationResult.FAILURE_ETC, null);
			}
			this.mOnCreatedGuild = null;
		}
	}

	// Token: 0x060016C2 RID: 5826 RVA: 0x00010C5F File Offset: 0x0000EE5F
	public void imethod_5(DismissGuildCallback dismissGuildCallback_0, int int_0)
	{
		this.mOnDismissedGuild = dismissGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(105, new object[] { int_0 });
	}

	// Token: 0x060016C3 RID: 5827 RVA: 0x00010C84 File Offset: 0x0000EE84
	private void OnDismissGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnDismissedGuild != null)
		{
			if (operationResponse == 0)
			{
				this.mOnDismissedGuild(true);
			}
			else
			{
				this.mOnDismissedGuild(false);
			}
			this.mOnDismissedGuild = null;
		}
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x00010CB2 File Offset: 0x0000EEB2
	public void imethod_6(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0)
	{
		this.mOnChangedGuildMaster = changeGuildMasterCallback_0;
		PhotonNetwork.onlinePeer.method_3(107, new object[] { int_0 });
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x0007C8B8 File Offset: 0x0007AAB8
	private void OnChangeGuildMasterCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnChangedGuildMaster != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				this.mOnChangedGuildMaster(true, num);
			}
			else
			{
				this.mOnChangedGuildMaster(false, 0);
			}
			this.mOnChangedGuildMaster = null;
		}
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x00010CD7 File Offset: 0x0000EED7
	public void imethod_7(QuitGuildCallback quitGuildCallback_0, int int_0)
	{
		this.mOnQuitGuild = quitGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(112, new object[] { int_0 });
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x00010CFC File Offset: 0x0000EEFC
	private void OnQuitGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnQuitGuild != null)
		{
			if (operationResponse == 0)
			{
				this.mOnQuitGuild(true);
			}
			else
			{
				this.mOnQuitGuild(false);
			}
			this.mOnQuitGuild = null;
		}
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x00010D2A File Offset: 0x0000EF2A
	public void imethod_8(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1)
	{
		this.mOnExpelledFromGuild = expellFromGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(113, new object[] { int_0, int_1 });
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x0007C914 File Offset: 0x0007AB14
	private void OnExpellFromGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnExpelledFromGuild != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				this.mOnExpelledFromGuild(true, num);
			}
			else
			{
				this.mOnExpelledFromGuild(false, 0);
			}
			this.mOnExpelledFromGuild = null;
		}
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x00010D58 File Offset: 0x0000EF58
	public void imethod_9(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50)
	{
		this.mOnSearchedGuild = searchGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(108, new object[] { guildPreference_0, int_0 });
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x0007C970 File Offset: 0x0007AB70
	private void OnSearchGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSearchedGuild != null)
		{
			List<Guild> list = new List<Guild>();
			list.Clear();
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new Guild((Hashtable)parameters[b]));
					b += 1;
				}
			}
			this.mOnSearchedGuild(list);
			this.mOnSearchedGuild = null;
		}
	}

	// Token: 0x060016CC RID: 5836 RVA: 0x00010D86 File Offset: 0x0000EF86
	public void imethod_10(ApplyToGuildCallback applyToGuildCallback_0, int int_0)
	{
		this.mOnAppliedToGuild = applyToGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(109, new object[] { int_0 });
	}

	// Token: 0x060016CD RID: 5837 RVA: 0x0007C9E4 File Offset: 0x0007ABE4
	private void OnApplyToGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnAppliedToGuild != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null && parameters[1] != null && parameters[2] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				int num2 = Convert.ToInt32(parameters[1]);
				List<Guild> list = new List<Guild>();
				list.Clear();
				Hashtable[] array = (Hashtable[])parameters[2];
				byte b = 0;
				while ((int)b < array.Length)
				{
					list.Add(new Guild(array[(int)b]));
					b += 1;
				}
				this.mOnAppliedToGuild(true, num, num2, list);
			}
			else
			{
				this.mOnAppliedToGuild(false, 0, 0, null);
			}
			this.mOnAppliedToGuild = null;
		}
	}

	// Token: 0x060016CE RID: 5838 RVA: 0x00010DAB File Offset: 0x0000EFAB
	public void imethod_13(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0)
	{
		this.mOnCanceledMyGuildApplication = cancelMyGuildApplicationCallback_0;
		PhotonNetwork.onlinePeer.method_3(76, new object[] { int_0 });
	}

	// Token: 0x060016CF RID: 5839 RVA: 0x00010DD0 File Offset: 0x0000EFD0
	private void OnCancelMyGuildApplicationCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnCanceledMyGuildApplication != null)
		{
			if (operationResponse == 0)
			{
				this.mOnCanceledMyGuildApplication(true);
			}
			else
			{
				this.mOnCanceledMyGuildApplication(false);
			}
			this.mOnCanceledMyGuildApplication = null;
		}
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x00010DFE File Offset: 0x0000EFFE
	public void imethod_12(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0)
	{
		this.mOnGotMyGuildApplications = getMyGuildApplicationsCallback_0;
		PhotonNetwork.onlinePeer.method_3(77, new object[0]);
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x0007CAA8 File Offset: 0x0007ACA8
	private void OnGetMyGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildApplications != null)
		{
			List<Guild> list = new List<Guild>();
			list.Clear();
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new Guild((Hashtable)parameters[b]));
					b += 1;
				}
			}
			this.mOnGotMyGuildApplications(list);
			this.mOnGotMyGuildApplications = null;
		}
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x00010E1A File Offset: 0x0000F01A
	public void imethod_11(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0)
	{
		this.mOnGotGuildApplications = getGuildApplicationsCallback_0;
		PhotonNetwork.onlinePeer.method_3(110, new object[] { int_0 });
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x0007CB1C File Offset: 0x0007AD1C
	private void OnGetGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotGuildApplications != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<Presence> list = new List<Presence>();
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new Presence((Hashtable)parameters[b]));
					b += 1;
				}
				this.mOnGotGuildApplications(list);
			}
			else
			{
				this.mOnGotGuildApplications(null);
			}
			this.mOnGotGuildApplications = null;
		}
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x0007CB90 File Offset: 0x0007AD90
	public void imethod_14(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0)
	{
		this.mOnProcessedGuildApplications = processGuildApplicationsCallback_0;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		foreach (ApplicantApproval applicantApproval in list_0)
		{
			dictionary[num++] = new Hashtable
			{
				{ 0, applicantApproval.ApplicantCharacterId },
				{ 1, applicantApproval.IsAllowedToJoin }
			};
		}
		PhotonNetwork.onlinePeer.method_3(111, new object[] { int_0, dictionary });
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x0007CC4C File Offset: 0x0007AE4C
	private void OnProcessGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnProcessedGuildApplications != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				int num2 = Convert.ToInt32(parameters[1]);
				this.mOnProcessedGuildApplications(num, num2);
			}
			else
			{
				this.mOnProcessedGuildApplications(0, 0);
			}
			this.mOnProcessedGuildApplications = null;
		}
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x00010E3F File Offset: 0x0000F03F
	public void imethod_15(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1)
	{
		this.mOnInvitedToGuild = inviteToGuildCallback_0;
		PhotonNetwork.onlinePeer.method_3(114, new object[] { int_0, int_1 });
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x0007CCB4 File Offset: 0x0007AEB4
	private void OnInviteToGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnInvitedToGuild != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				GuildInvitationResult guildInvitationResult = (GuildInvitationResult)((int)parameters[0]);
				this.mOnInvitedToGuild(guildInvitationResult);
			}
			else
			{
				this.mOnInvitedToGuild(GuildInvitationResult.FAILURE_ETC);
			}
			this.mOnInvitedToGuild = null;
		}
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x00010E6D File Offset: 0x0000F06D
	public void imethod_16(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0)
	{
		this.mOnGotMyGuildInvitations = getMyGuildInvitationsCallback_0;
		PhotonNetwork.onlinePeer.method_3(115, new object[0]);
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x0007CD0C File Offset: 0x0007AF0C
	private void OnGetMyGuildInvitationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildInvitations != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<Invitation> list = new List<Invitation>();
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new Invitation((Hashtable)parameters[b]));
					b += 1;
				}
				this.mOnGotMyGuildInvitations(list);
			}
			else
			{
				this.mOnGotMyGuildInvitations(null);
			}
			this.mOnGotMyGuildInvitations = null;
		}
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x0007CD80 File Offset: 0x0007AF80
	public void imethod_17(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0)
	{
		this.mOnProcessedGuildInvitations = processGuildInvitationsCallback_0;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		foreach (InvitationReply invitationReply in list_0)
		{
			dictionary[num++] = new Hashtable
			{
				{ 0, invitationReply.GuildId },
				{ 1, invitationReply.Reply },
				{ 2, invitationReply.GuildInviterCharacterId }
			};
		}
		PhotonNetwork.onlinePeer.method_3(116, new object[] { dictionary });
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x0007CE48 File Offset: 0x0007B048
	private void OnProcessGuildInvitationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnProcessedGuildInvitations != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				this.mOnProcessedGuildInvitations(new Guild((Hashtable)parameters[0]));
			}
			else
			{
				this.mOnProcessedGuildInvitations(null);
			}
			this.mOnProcessedGuildInvitations = null;
		}
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x00010E89 File Offset: 0x0000F089
	public void imethod_18(GetMyGuildNewsCallback getMyGuildNewsCallback_0)
	{
		this.mOnGotMyGuildNews = getMyGuildNewsCallback_0;
		PhotonNetwork.onlinePeer.method_3(78, new object[0]);
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x0007CEA4 File Offset: 0x0007B0A4
	private void OnGetMyGuildNewsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildNews != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<GuildNews> list = new List<GuildNews>();
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new GuildNews((Hashtable)parameters[b]));
					b += 1;
				}
				this.mOnGotMyGuildNews(list);
			}
			else
			{
				this.mOnGotMyGuildNews(null);
			}
			this.mOnGotMyGuildNews = null;
		}
	}

	// Token: 0x060016DE RID: 5854 RVA: 0x00010EA5 File Offset: 0x0000F0A5
	public void imethod_20(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1)
	{
		this.mOnDischargedGuildManager = dischargeGuildManagerCallback_0;
		PhotonNetwork.onlinePeer.method_3(72, new object[] { int_0, int_1 });
	}

	// Token: 0x060016DF RID: 5855 RVA: 0x0007CF18 File Offset: 0x0007B118
	private void OnDischargeGuildManagerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnDischargedGuildManager != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				this.mOnDischargedGuildManager(true, num);
			}
			else
			{
				this.mOnDischargedGuildManager(false, 0);
			}
			this.mOnDischargedGuildManager = null;
		}
	}

	// Token: 0x060016E0 RID: 5856 RVA: 0x00010ED3 File Offset: 0x0000F0D3
	public void imethod_19(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1)
	{
		this.mOnAssignedGuildManager = assignGuildManagerCallback_0;
		PhotonNetwork.onlinePeer.method_3(73, new object[] { int_0, int_1 });
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x0007CF74 File Offset: 0x0007B174
	private void OnAssignGuildManagerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnAssignedGuildManager != null)
		{
			if (operationResponse == 0 && parameters.Count > 0 && parameters[0] != null)
			{
				int num = Convert.ToInt32(parameters[0]);
				this.mOnAssignedGuildManager(true, num);
			}
			else
			{
				this.mOnAssignedGuildManager(false, 0);
			}
			this.mOnAssignedGuildManager = null;
		}
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x00010F01 File Offset: 0x0000F101
	public void imethod_23(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0)
	{
		this.mOnGetGuildManagerListCallback = getGuildManagerListCallback_0;
		PhotonNetwork.onlinePeer.method_3(63, new object[] { int_0 });
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x0007CFD0 File Offset: 0x0007B1D0
	private void OnGetGuildManagerListCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetGuildManagerListCallback != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<int> list = new List<int>();
				for (int i = 0; i < ((Hashtable)parameters[0]).Count; i++)
				{
					list.Add(Convert.ToInt32(((Hashtable)parameters[0])[i]));
				}
				this.mOnGetGuildManagerListCallback(list);
			}
			this.mOnGetGuildManagerListCallback = null;
		}
	}

	// Token: 0x060016E4 RID: 5860 RVA: 0x00010F26 File Offset: 0x0000F126
	public void imethod_21(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0)
	{
		this.mOnGotMyGuildSkillList = getMyGuildSkillListCallback_0;
		PhotonNetwork.onlinePeer.method_3(65, new object[0]);
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x0007D048 File Offset: 0x0007B248
	private void OnGetMyGuildSkillListCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGuildSkillList != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<GuildSkill> list = new List<GuildSkill>();
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new GuildSkill((Hashtable)parameters[b]));
					b += 1;
				}
				this.mOnGotMyGuildSkillList(list);
			}
			this.mOnGotMyGuildSkillList = null;
		}
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x00010F42 File Offset: 0x0000F142
	public void imethod_22(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0)
	{
		this.mOnActivatedGuildSkill = activateGuildSkillCallback_0;
		PhotonNetwork.onlinePeer.method_3(64, new object[] { int_0 });
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x0007D0AC File Offset: 0x0007B2AC
	private void OnActivateGuildSkillCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnActivatedGuildSkill != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				this.mOnActivatedGuildSkill(true, Convert.ToInt32(parameters[0]));
			}
			else
			{
				this.mOnActivatedGuildSkill(false, 0);
			}
			this.mOnActivatedGuildSkill = null;
		}
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x0007D0FC File Offset: 0x0007B2FC
	private void OnGuildInvitationEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 3)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			string masterName = Convert.ToString(parameters[1]);
			string guildName = Convert.ToString(parameters[2]);
			mOnReceivedGuildInvitation.ForEach(delegate(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0)
			{
				receiveGuildInvitationCallback_0(guildId, masterName, guildName);
			});
		}
	}
	// Token: 0x060016E9 RID: 5865 RVA: 0x00010F67 File Offset: 0x0000F167
	public void imethod_24(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0)
	{
		this.mOnReceivedGuildInvitation.Add(receiveGuildInvitationCallback_0);
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x00010F75 File Offset: 0x0000F175
	public void imethod_25(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0)
	{
		this.mOnReceivedGuildInvitation.Remove(receiveGuildInvitationCallback_0);
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x0007D168 File Offset: 0x0007B368
	private void OnGuildJoinedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 3)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			string guildName = Convert.ToString(parameters[1]);
			bool isJoined = Convert.ToBoolean(parameters[2]);
			mOnReceivedGuildJoined.ForEach(delegate(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0)
			{
				receiveGuildJoinedCallback_0(guildId, guildName, isJoined);
			});
		}
	}
	// Token: 0x060016EC RID: 5868 RVA: 0x00010F84 File Offset: 0x0000F184
	public void imethod_26(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0)
	{
		this.mOnReceivedGuildJoined.Add(receiveGuildJoinedCallback_0);
	}

	// Token: 0x060016ED RID: 5869 RVA: 0x00010F92 File Offset: 0x0000F192
	public void imethod_27(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0)
	{
		this.mOnReceivedGuildJoined.Remove(receiveGuildJoinedCallback_0);
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x0007D1D4 File Offset: 0x0007B3D4
	private void OnGuildExpelledEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 3)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			string guildName = Convert.ToString(parameters[1]);
			bool isGuildDismissed = Convert.ToBoolean(parameters[2]);
			mOnReceivedGuildExpelled.ForEach(delegate(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0)
			{
				receiveGuildExpelledCallback_0(guildId, guildName, isGuildDismissed);
			});
		}
	}
	// Token: 0x060016EF RID: 5871 RVA: 0x00010FA1 File Offset: 0x0000F1A1
	public void imethod_28(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0)
	{
		this.mOnReceivedGuildExpelled.Add(receiveGuildExpelledCallback_0);
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x00010FAF File Offset: 0x0000F1AF
	public void imethod_29(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0)
	{
		this.mOnReceivedGuildExpelled.Remove(receiveGuildExpelledCallback_0);
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x0007D240 File Offset: 0x0007B440
	private void OnFreeGuildSkillSlotGivenEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 2)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			int remainFreeSkillCount = Convert.ToInt32(parameters[1]);
			mOnReceivedFreeGuildSkillSlotGiven.ForEach(delegate(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0)
			{
				receiveFreeGuildSkillSlotGivenCallback_0(guildId, remainFreeSkillCount);
			});
		}
	}
	// Token: 0x060016F2 RID: 5874 RVA: 0x00010FBE File Offset: 0x0000F1BE
	public void imethod_30(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0)
	{
		this.mOnReceivedFreeGuildSkillSlotGiven.Add(receiveFreeGuildSkillSlotGivenCallback_0);
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x00010FCC File Offset: 0x0000F1CC
	public void imethod_31(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0)
	{
		this.mOnReceivedFreeGuildSkillSlotGiven.Remove(receiveFreeGuildSkillSlotGivenCallback_0);
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x0007D298 File Offset: 0x0007B498
	private void OnGuildSkillSelectedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 3)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			int skillId = Convert.ToInt32(parameters[1]);
			int remainFreeSkillCount = Convert.ToInt32(parameters[2]);
			mOnReceivedGuildSkillSelected.ForEach(delegate(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0)
			{
				receiveGuildSkillSelectedCallback_0(guildId, skillId, remainFreeSkillCount);
			});
		}
	}
	// Token: 0x060016F5 RID: 5877 RVA: 0x00010FDB File Offset: 0x0000F1DB
	public void imethod_38(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0)
	{
		this.mOnReceivedGuildSkillSelected.Add(receiveGuildSkillSelectedCallback_0);
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x00010FE9 File Offset: 0x0000F1E9
	public void imethod_39(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0)
	{
		this.mOnReceivedGuildSkillSelected.Remove(receiveGuildSkillSelectedCallback_0);
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x0007D304 File Offset: 0x0007B504
	private void OnGuildManagerAssignedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 1)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			mOnReceivedGuildManagerAssigned.ForEach(delegate(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0)
			{
				receiveGuildManagerAssignedCallback_0(guildId);
			});
		}
	}
	// Token: 0x060016F8 RID: 5880 RVA: 0x00010FF8 File Offset: 0x0000F1F8
	public void imethod_32(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0)
	{
		this.mOnReceivedGuildManagerAssigned.Add(receiveGuildManagerAssignedCallback_0);
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x00011006 File Offset: 0x0000F206
	public void imethod_33(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0)
	{
		this.mOnReceivedGuildManagerAssigned.Remove(receiveGuildManagerAssignedCallback_0);
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x0007D34C File Offset: 0x0007B54C
	private void OnGuildManagerDischargedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 1)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			mOnReceivedGuildManagerDischarged.ForEach(delegate(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0)
			{
				receiveGuildManagerDischargedCallback_0(guildId);
			});
		}
	}
	// Token: 0x060016FB RID: 5883 RVA: 0x00011015 File Offset: 0x0000F215
	public void imethod_34(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0)
	{
		this.mOnReceivedGuildManagerDischarged.Add(receiveGuildManagerDischargedCallback_0);
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x00011023 File Offset: 0x0000F223
	public void imethod_35(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0)
	{
		this.mOnReceivedGuildManagerDischarged.Remove(receiveGuildManagerDischargedCallback_0);
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x0007D394 File Offset: 0x0007B594
	private void OnGuildMasterChangedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count >= 1)
		{
			int guildId = Convert.ToInt32(parameters[0]);
			mOnReceivedGuildMasterChanged.ForEach(delegate(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0)
			{
				receiveGuildMasterChangedCallback_0(guildId);
			});
		}
	}
	// Token: 0x060016FE RID: 5886 RVA: 0x00011032 File Offset: 0x0000F232
	public void imethod_36(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0)
	{
		this.mOnReceivedGuildMasterChanged.Add(receiveGuildMasterChangedCallback_0);
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x00011040 File Offset: 0x0000F240
	public void imethod_37(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0)
	{
		this.mOnReceivedGuildMasterChanged.Remove(receiveGuildMasterChangedCallback_0);
	}

	// Token: 0x04000F88 RID: 3976
	private ChangeGuildBannerCallback mOnChangedGuildBanner;

	// Token: 0x04000F89 RID: 3977
	private GetMyGuildInfoCallback mOnGotMyGuildInfo;

	// Token: 0x04000F8A RID: 3978
	private GetMyGuildIdCallback mOnGotMyGuildId;

	// Token: 0x04000F8B RID: 3979
	private GetGuildInfoCallback mOnGotGuildInfo;

	// Token: 0x04000F8C RID: 3980
	private CreateGuildCallback mOnCreatedGuild;

	// Token: 0x04000F8D RID: 3981
	private DismissGuildCallback mOnDismissedGuild;

	// Token: 0x04000F8E RID: 3982
	private ChangeGuildMasterCallback mOnChangedGuildMaster;

	// Token: 0x04000F8F RID: 3983
	private QuitGuildCallback mOnQuitGuild;

	// Token: 0x04000F90 RID: 3984
	private ExpellFromGuildCallback mOnExpelledFromGuild;

	// Token: 0x04000F91 RID: 3985
	private SearchGuildCallback mOnSearchedGuild;

	// Token: 0x04000F92 RID: 3986
	private ApplyToGuildCallback mOnAppliedToGuild;

	// Token: 0x04000F93 RID: 3987
	private GetMyGuildApplicationsCallback mOnGotMyGuildApplications;

	// Token: 0x04000F94 RID: 3988
	private CancelMyGuildApplicationCallback mOnCanceledMyGuildApplication;

	// Token: 0x04000F95 RID: 3989
	private GetGuildApplicationsCallback mOnGotGuildApplications;

	// Token: 0x04000F96 RID: 3990
	private ProcessGuildApplicationsCallback mOnProcessedGuildApplications;

	// Token: 0x04000F97 RID: 3991
	private InviteToGuildCallback mOnInvitedToGuild;

	// Token: 0x04000F98 RID: 3992
	private GetMyGuildInvitationsCallback mOnGotMyGuildInvitations;

	// Token: 0x04000F99 RID: 3993
	private ProcessGuildInvitationsCallback mOnProcessedGuildInvitations;

	// Token: 0x04000F9A RID: 3994
	private GetMyGuildNewsCallback mOnGotMyGuildNews;

	// Token: 0x04000F9B RID: 3995
	private AssignGuildManagerCallback mOnAssignedGuildManager;

	// Token: 0x04000F9C RID: 3996
	private DischargeGuildManagerCallback mOnDischargedGuildManager;

	// Token: 0x04000F9D RID: 3997
	private GetMyGuildSkillListCallback mOnGotMyGuildSkillList;

	// Token: 0x04000F9E RID: 3998
	private ActivateGuildSkillCallback mOnActivatedGuildSkill;

	// Token: 0x04000F9F RID: 3999
	private GetGuildManagerListCallback mOnGetGuildManagerListCallback;

	// Token: 0x04000FA0 RID: 4000
	private List<ReceiveGuildInvitationCallback> mOnReceivedGuildInvitation = new List<ReceiveGuildInvitationCallback>();

	// Token: 0x04000FA1 RID: 4001
	private List<ReceiveGuildJoinedCallback> mOnReceivedGuildJoined = new List<ReceiveGuildJoinedCallback>();

	// Token: 0x04000FA2 RID: 4002
	private List<ReceiveGuildExpelledCallback> mOnReceivedGuildExpelled = new List<ReceiveGuildExpelledCallback>();

	// Token: 0x04000FA3 RID: 4003
	private List<ReceiveFreeGuildSkillSlotGivenCallback> mOnReceivedFreeGuildSkillSlotGiven = new List<ReceiveFreeGuildSkillSlotGivenCallback>();

	// Token: 0x04000FA4 RID: 4004
	private List<ReceiveGuildSkillSelectedCallback> mOnReceivedGuildSkillSelected = new List<ReceiveGuildSkillSelectedCallback>();

	// Token: 0x04000FA5 RID: 4005
	private List<ReceiveGuildManagerAssignedCallback> mOnReceivedGuildManagerAssigned = new List<ReceiveGuildManagerAssignedCallback>();

	// Token: 0x04000FA6 RID: 4006
	private List<ReceiveGuildManagerDischargedCallback> mOnReceivedGuildManagerDischarged = new List<ReceiveGuildManagerDischargedCallback>();

	// Token: 0x04000FA7 RID: 4007
	private List<ReceiveGuildMasterChangedCallback> mOnReceivedGuildMasterChanged = new List<ReceiveGuildMasterChangedCallback>();
}
