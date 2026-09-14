using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020002E2 RID: 738
public class GuildServiceWrapperOnline : IGuildServiceWrapper, IServiceWrapper
{
	// Token: 0x060010BF RID: 4287 RVA: 0x0007614C File Offset: 0x0007434C
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_38(new ReceiveGuildSkillSelectedCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_30));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_2(new GetMyGuildIdCallback(this.OnGotMyGuildId));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_24(new ReceiveGuildInvitationCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_26));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_26(new ReceiveGuildJoinedCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_27));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_28(new ReceiveGuildExpelledCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_28));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_30(new ReceiveFreeGuildSkillSlotGivenCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_29));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_32(new ReceiveGuildManagerAssignedCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_31));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_34(new ReceiveGuildManagerDischargedCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_32));
			OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_36(new ReceiveGuildMasterChangedCallback(ServiceWrapperBase<GuildServiceWrapper>.Instance.method_33));
			GuildManager.smethod_0();
		}
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x0000DFE5 File Offset: 0x0000C1E5
	private void OnGotMyGuildId(int guildId)
	{
		this.m_initialized = true;
	}

	// Token: 0x060010C1 RID: 4289 RVA: 0x0000DFEE File Offset: 0x0000C1EE
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x0000DFF6 File Offset: 0x0000C1F6
	public void imethod_2(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_0(changeGuildBannerCallback_0, int_0, string_0);
	}

	// Token: 0x060010C3 RID: 4291 RVA: 0x0000E005 File Offset: 0x0000C205
	public void imethod_3(GetMyGuildInfoCallback getMyGuildInfoCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_1(getMyGuildInfoCallback_0);
	}

	// Token: 0x060010C4 RID: 4292 RVA: 0x0000E012 File Offset: 0x0000C212
	public void imethod_4(GetMyGuildIdCallback getMyGuildIdCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_2(getMyGuildIdCallback_0);
	}

	// Token: 0x060010C5 RID: 4293 RVA: 0x0000E01F File Offset: 0x0000C21F
	public void imethod_5(GetGuildInfoCallback getGuildInfoCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_3(getGuildInfoCallback_0, int_0);
	}

	// Token: 0x060010C6 RID: 4294 RVA: 0x0000E02D File Offset: 0x0000C22D
	public void imethod_6(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_4(createGuildCallback_0, string_0, string_1, guildPreference_0);
	}

	// Token: 0x060010C7 RID: 4295 RVA: 0x0000E03E File Offset: 0x0000C23E
	public void imethod_7(DismissGuildCallback dismissGuildCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_5(dismissGuildCallback_0, int_0);
	}

	// Token: 0x060010C8 RID: 4296 RVA: 0x0000E04C File Offset: 0x0000C24C
	public void imethod_8(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_6(changeGuildMasterCallback_0, int_0);
	}

	// Token: 0x060010C9 RID: 4297 RVA: 0x0000E05A File Offset: 0x0000C25A
	public void imethod_9(QuitGuildCallback quitGuildCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_7(quitGuildCallback_0, int_0);
	}

	// Token: 0x060010CA RID: 4298 RVA: 0x0000E068 File Offset: 0x0000C268
	public void imethod_10(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_8(expellFromGuildCallback_0, int_0, int_1);
	}

	// Token: 0x060010CB RID: 4299 RVA: 0x0000E077 File Offset: 0x0000C277
	public void imethod_11(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_9(searchGuildCallback_0, guildPreference_0, int_0);
	}

	// Token: 0x060010CC RID: 4300 RVA: 0x0000E086 File Offset: 0x0000C286
	public void imethod_12(ApplyToGuildCallback applyToGuildCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_10(applyToGuildCallback_0, int_0);
	}

	// Token: 0x060010CD RID: 4301 RVA: 0x0000E094 File Offset: 0x0000C294
	public void imethod_13(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_12(getMyGuildApplicationsCallback_0);
	}

	// Token: 0x060010CE RID: 4302 RVA: 0x0000E0A1 File Offset: 0x0000C2A1
	public void imethod_15(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_13(cancelMyGuildApplicationCallback_0, int_0);
	}

	// Token: 0x060010CF RID: 4303 RVA: 0x0000E0AF File Offset: 0x0000C2AF
	public void imethod_16(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_11(getGuildApplicationsCallback_0, int_0);
	}

	// Token: 0x060010D0 RID: 4304 RVA: 0x0000E0BD File Offset: 0x0000C2BD
	public void imethod_17(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_14(processGuildApplicationsCallback_0, int_0, list_0);
	}

	// Token: 0x060010D1 RID: 4305 RVA: 0x0000E0CC File Offset: 0x0000C2CC
	public void imethod_18(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_15(inviteToGuildCallback_0, int_0, int_1);
	}

	// Token: 0x060010D2 RID: 4306 RVA: 0x0000E0DB File Offset: 0x0000C2DB
	public void imethod_19(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_16(getMyGuildInvitationsCallback_0);
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
	public void imethod_20(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_17(processGuildInvitationsCallback_0, list_0);
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x0000E0F6 File Offset: 0x0000C2F6
	public void imethod_14(GetMyGuildNewsCallback getMyGuildNewsCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_18(getMyGuildNewsCallback_0);
	}

	// Token: 0x060010D5 RID: 4309 RVA: 0x0000E103 File Offset: 0x0000C303
	public void imethod_21(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_19(assignGuildManagerCallback_0, int_0, int_1);
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x0000E112 File Offset: 0x0000C312
	public void imethod_22(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_20(dischargeGuildManagerCallback_0, int_0, int_1);
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x0000E121 File Offset: 0x0000C321
	public void imethod_23(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_22(activateGuildSkillCallback_0, int_0);
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x0000E12F File Offset: 0x0000C32F
	public void imethod_24(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_21(getMyGuildSkillListCallback_0);
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x0000E13C File Offset: 0x0000C33C
	public void imethod_25(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.Prop_0.imethod_23(getGuildManagerListCallback_0, int_0);
	}

	// Token: 0x04000DD0 RID: 3536
	private bool m_isInitializing;

	// Token: 0x04000DD1 RID: 3537
	private bool m_initialized;
}
