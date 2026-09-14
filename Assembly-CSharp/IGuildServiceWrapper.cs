using System;
using System.Collections.Generic;

// Token: 0x020002DF RID: 735
public interface IGuildServiceWrapper : IServiceWrapper
{
	// Token: 0x0600107A RID: 4218
	void imethod_2(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0);

	// Token: 0x0600107B RID: 4219
	void imethod_3(GetMyGuildInfoCallback getMyGuildInfoCallback_0);

	// Token: 0x0600107C RID: 4220
	void imethod_4(GetMyGuildIdCallback getMyGuildIdCallback_0);

	// Token: 0x0600107D RID: 4221
	void imethod_5(GetGuildInfoCallback getGuildInfoCallback_0, int int_0);

	// Token: 0x0600107E RID: 4222
	void imethod_6(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None);

	// Token: 0x0600107F RID: 4223
	void imethod_7(DismissGuildCallback dismissGuildCallback_0, int int_0);

	// Token: 0x06001080 RID: 4224
	void imethod_8(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0);

	// Token: 0x06001081 RID: 4225
	void imethod_9(QuitGuildCallback quitGuildCallback_0, int int_0);

	// Token: 0x06001082 RID: 4226
	void imethod_10(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1);

	// Token: 0x06001083 RID: 4227
	void imethod_11(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50);

	// Token: 0x06001084 RID: 4228
	void imethod_12(ApplyToGuildCallback applyToGuildCallback_0, int int_0);

	// Token: 0x06001085 RID: 4229
	void imethod_13(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0);

	// Token: 0x06001086 RID: 4230
	void imethod_14(GetMyGuildNewsCallback getMyGuildNewsCallback_0);

	// Token: 0x06001087 RID: 4231
	void imethod_15(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0);

	// Token: 0x06001088 RID: 4232
	void imethod_16(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0);

	// Token: 0x06001089 RID: 4233
	void imethod_17(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0);

	// Token: 0x0600108A RID: 4234
	void imethod_18(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1);

	// Token: 0x0600108B RID: 4235
	void imethod_19(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0);

	// Token: 0x0600108C RID: 4236
	void imethod_20(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0);

	// Token: 0x0600108D RID: 4237
	void imethod_21(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1);

	// Token: 0x0600108E RID: 4238
	void imethod_22(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1);

	// Token: 0x0600108F RID: 4239
	void imethod_23(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0);

	// Token: 0x06001090 RID: 4240
	void imethod_24(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0);

	// Token: 0x06001091 RID: 4241
	void imethod_25(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0);
}
