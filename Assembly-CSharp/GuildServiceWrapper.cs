using System;
using System.Collections.Generic;

// Token: 0x020002E1 RID: 737
public class GuildServiceWrapper : ServiceWrapper<IGuildServiceWrapper, GuildServiceWrapper>
{
	// Token: 0x0600109B RID: 4251 RVA: 0x0000DE41 File Offset: 0x0000C041
	public void method_0(IGuildServiceNotificationListerner iguildServiceNotificationListerner_0)
	{
		this.m_listerner.Add(iguildServiceNotificationListerner_0);
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x0000DE4F File Offset: 0x0000C04F
	public void method_1(IGuildServiceNotificationListerner iguildServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(iguildServiceNotificationListerner_0);
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x0000DE5E File Offset: 0x0000C05E
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new GuildServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x0000DE71 File Offset: 0x0000C071
	public void method_2(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0)
	{
		this.vmethod_0().imethod_2(changeGuildBannerCallback_0, int_0, string_0);
	}

	// Token: 0x0600109F RID: 4255 RVA: 0x0000DE81 File Offset: 0x0000C081
	public void method_3(GetMyGuildInfoCallback getMyGuildInfoCallback_0)
	{
		if (this.vmethod_0() != null)
		{
			this.vmethod_0().imethod_3(getMyGuildInfoCallback_0);
		}
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x0000DE97 File Offset: 0x0000C097
	public void method_4(GetMyGuildIdCallback getMyGuildIdCallback_0)
	{
		this.vmethod_0().imethod_4(getMyGuildIdCallback_0);
	}

	// Token: 0x060010A1 RID: 4257 RVA: 0x0000DEA5 File Offset: 0x0000C0A5
	public void method_5(GetGuildInfoCallback getGuildInfoCallback_0, int int_0)
	{
		this.vmethod_0().imethod_5(getGuildInfoCallback_0, int_0);
	}

	// Token: 0x060010A2 RID: 4258 RVA: 0x0000DEB4 File Offset: 0x0000C0B4
	public void method_6(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None)
	{
		this.vmethod_0().imethod_6(createGuildCallback_0, string_0, string_1, guildPreference_0);
	}

	// Token: 0x060010A3 RID: 4259 RVA: 0x0000DEC6 File Offset: 0x0000C0C6
	public void method_7(DismissGuildCallback dismissGuildCallback_0, int int_0)
	{
		this.vmethod_0().imethod_7(dismissGuildCallback_0, int_0);
	}

	// Token: 0x060010A4 RID: 4260 RVA: 0x0000DED5 File Offset: 0x0000C0D5
	public void method_8(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0)
	{
		this.vmethod_0().imethod_8(changeGuildMasterCallback_0, int_0);
	}

	// Token: 0x060010A5 RID: 4261 RVA: 0x0000DEE4 File Offset: 0x0000C0E4
	public void method_9(QuitGuildCallback quitGuildCallback_0, int int_0)
	{
		this.vmethod_0().imethod_9(quitGuildCallback_0, int_0);
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x0000DEF3 File Offset: 0x0000C0F3
	public void method_10(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1)
	{
		this.vmethod_0().imethod_10(expellFromGuildCallback_0, int_0, int_1);
	}

	// Token: 0x060010A7 RID: 4263 RVA: 0x0000DF03 File Offset: 0x0000C103
	public void method_11(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50)
	{
		this.vmethod_0().imethod_11(searchGuildCallback_0, guildPreference_0, int_0);
	}

	// Token: 0x060010A8 RID: 4264 RVA: 0x0000DF13 File Offset: 0x0000C113
	public void method_12(ApplyToGuildCallback applyToGuildCallback_0, int int_0)
	{
		this.vmethod_0().imethod_12(applyToGuildCallback_0, int_0);
	}

	// Token: 0x060010A9 RID: 4265 RVA: 0x0000DF22 File Offset: 0x0000C122
	public void method_13(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0)
	{
		this.vmethod_0().imethod_15(cancelMyGuildApplicationCallback_0, int_0);
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x0000DF31 File Offset: 0x0000C131
	public void method_14(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0)
	{
		this.vmethod_0().imethod_13(getMyGuildApplicationsCallback_0);
	}

	// Token: 0x060010AB RID: 4267 RVA: 0x0000DF3F File Offset: 0x0000C13F
	public void method_15(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0)
	{
		this.vmethod_0().imethod_16(getGuildApplicationsCallback_0, int_0);
	}

	// Token: 0x060010AC RID: 4268 RVA: 0x0000DF4E File Offset: 0x0000C14E
	public void method_16(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0)
	{
		this.vmethod_0().imethod_17(processGuildApplicationsCallback_0, int_0, list_0);
	}

	// Token: 0x060010AD RID: 4269 RVA: 0x0000DF5E File Offset: 0x0000C15E
	public void method_17(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1)
	{
		this.vmethod_0().imethod_18(inviteToGuildCallback_0, int_0, int_1);
	}

	// Token: 0x060010AE RID: 4270 RVA: 0x0000DF6E File Offset: 0x0000C16E
	public void method_18(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0)
	{
		this.vmethod_0().imethod_19(getMyGuildInvitationsCallback_0);
	}

	// Token: 0x060010AF RID: 4271 RVA: 0x0000DF7C File Offset: 0x0000C17C
	public void method_19(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0)
	{
		this.vmethod_0().imethod_20(processGuildInvitationsCallback_0, list_0);
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x0000DF8B File Offset: 0x0000C18B
	public void method_20(GetMyGuildNewsCallback getMyGuildNewsCallback_0)
	{
		this.vmethod_0().imethod_14(getMyGuildNewsCallback_0);
	}

	// Token: 0x060010B1 RID: 4273 RVA: 0x0000DF99 File Offset: 0x0000C199
	public void method_21(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1)
	{
		this.vmethod_0().imethod_21(assignGuildManagerCallback_0, int_0, int_1);
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x0000DFA9 File Offset: 0x0000C1A9
	public void method_22(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1)
	{
		this.vmethod_0().imethod_22(dischargeGuildManagerCallback_0, int_0, int_1);
	}

	// Token: 0x060010B3 RID: 4275 RVA: 0x0000DFB9 File Offset: 0x0000C1B9
	public void method_23(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0)
	{
		this.vmethod_0().imethod_23(activateGuildSkillCallback_0, int_0);
	}

	// Token: 0x060010B4 RID: 4276 RVA: 0x0000DFC8 File Offset: 0x0000C1C8
	public void method_24(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0)
	{
		this.vmethod_0().imethod_24(getMyGuildSkillListCallback_0);
	}

	// Token: 0x060010B5 RID: 4277 RVA: 0x0000DFD6 File Offset: 0x0000C1D6
	public void method_25(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0)
	{
		this.vmethod_0().imethod_25(getGuildManagerListCallback_0, int_0);
	}

	// Token: 0x060010B6 RID: 4278 RVA: 0x00075F8C File Offset: 0x0007418C
	public void method_26(int int_0, string string_0, string string_1)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildInvitation(int_0, string_0, string_1);
		}
	}

	// Token: 0x060010B7 RID: 4279 RVA: 0x00075FC4 File Offset: 0x000741C4
	public void method_27(int int_0, string string_0, bool bool_1)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildJoined(int_0, string_0, bool_1);
		}
	}

	// Token: 0x060010B8 RID: 4280 RVA: 0x00075FFC File Offset: 0x000741FC
	public void method_28(int int_0, string string_0, bool bool_1)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildExpelled(int_0, string_0, bool_1);
		}
	}

	// Token: 0x060010B9 RID: 4281 RVA: 0x00076034 File Offset: 0x00074234
	public void method_29(int int_0, int int_1)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedFreeGuildSkillSlotGiven(int_0, int_1);
		}
	}

	// Token: 0x060010BA RID: 4282 RVA: 0x0007606C File Offset: 0x0007426C
	public void method_30(int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildSkillSelected(int_0, int_1, int_2);
		}
	}

	// Token: 0x060010BB RID: 4283 RVA: 0x000760A4 File Offset: 0x000742A4
	public void method_31(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildManagerAssigned(int_0);
		}
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x000760DC File Offset: 0x000742DC
	public void method_32(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildManagerDischarged(int_0);
		}
	}

	// Token: 0x060010BD RID: 4285 RVA: 0x00076114 File Offset: 0x00074314
	public void method_33(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGuildMasterChanged(int_0);
		}
	}

	// Token: 0x04000DCF RID: 3535
	private List<IGuildServiceNotificationListerner> m_listerner = new List<IGuildServiceNotificationListerner>();
}
