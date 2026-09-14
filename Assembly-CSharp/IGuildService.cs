using System;
using System.Collections.Generic;

// Token: 0x020002F2 RID: 754
public interface IGuildService
{
	// Token: 0x0600114D RID: 4429
	void imethod_0(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0);

	// Token: 0x0600114E RID: 4430
	void imethod_1(GetMyGuildInfoCallback getMyGuildInfoCallback_0);

	// Token: 0x0600114F RID: 4431
	void imethod_2(GetMyGuildIdCallback getMyGuildIdCallback_0);

	// Token: 0x06001150 RID: 4432
	void imethod_3(GetGuildInfoCallback getGuildInfoCallback_0, int int_0);

	// Token: 0x06001151 RID: 4433
	void imethod_4(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None);

	// Token: 0x06001152 RID: 4434
	void imethod_5(DismissGuildCallback dismissGuildCallback_0, int int_0);

	// Token: 0x06001153 RID: 4435
	void imethod_6(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0);

	// Token: 0x06001154 RID: 4436
	void imethod_7(QuitGuildCallback quitGuildCallback_0, int int_0);

	// Token: 0x06001155 RID: 4437
	void imethod_8(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1);

	// Token: 0x06001156 RID: 4438
	void imethod_9(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50);

	// Token: 0x06001157 RID: 4439
	void imethod_10(ApplyToGuildCallback applyToGuildCallback_0, int int_0);

	// Token: 0x06001158 RID: 4440
	void imethod_11(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0);

	// Token: 0x06001159 RID: 4441
	void imethod_12(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0);

	// Token: 0x0600115A RID: 4442
	void imethod_13(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0);

	// Token: 0x0600115B RID: 4443
	void imethod_14(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0);

	// Token: 0x0600115C RID: 4444
	void imethod_15(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1);

	// Token: 0x0600115D RID: 4445
	void imethod_16(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0);

	// Token: 0x0600115E RID: 4446
	void imethod_17(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0);

	// Token: 0x0600115F RID: 4447
	void imethod_18(GetMyGuildNewsCallback getMyGuildNewsCallback_0);

	// Token: 0x06001160 RID: 4448
	void imethod_19(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1);

	// Token: 0x06001161 RID: 4449
	void imethod_20(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1);

	// Token: 0x06001162 RID: 4450
	void imethod_21(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0);

	// Token: 0x06001163 RID: 4451
	void imethod_22(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0);

	// Token: 0x06001164 RID: 4452
	void imethod_23(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0);

	// Token: 0x06001165 RID: 4453
	void imethod_24(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0);

	// Token: 0x06001166 RID: 4454
	void imethod_25(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0);

	// Token: 0x06001167 RID: 4455
	void imethod_26(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0);

	// Token: 0x06001168 RID: 4456
	void imethod_27(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0);

	// Token: 0x06001169 RID: 4457
	void imethod_28(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0);

	// Token: 0x0600116A RID: 4458
	void imethod_29(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0);

	// Token: 0x0600116B RID: 4459
	void imethod_30(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0);

	// Token: 0x0600116C RID: 4460
	void imethod_31(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0);

	// Token: 0x0600116D RID: 4461
	void imethod_32(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0);

	// Token: 0x0600116E RID: 4462
	void imethod_33(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0);

	// Token: 0x0600116F RID: 4463
	void imethod_34(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0);

	// Token: 0x06001170 RID: 4464
	void imethod_35(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0);

	// Token: 0x06001171 RID: 4465
	void imethod_36(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0);

	// Token: 0x06001172 RID: 4466
	void imethod_37(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0);

	// Token: 0x06001173 RID: 4467
	void imethod_38(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0);

	// Token: 0x06001174 RID: 4468
	void imethod_39(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0);
}
