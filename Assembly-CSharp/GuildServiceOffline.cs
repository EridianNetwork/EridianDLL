using System;
using System.Collections.Generic;

// Token: 0x02000323 RID: 803
public class GuildServiceOffline : IGuildService
{
	// Token: 0x060013AD RID: 5037 RVA: 0x0000F033 File Offset: 0x0000D233
	public void imethod_0(ChangeGuildBannerCallback changeGuildBannerCallback_0, int int_0, string string_0)
	{
		if (changeGuildBannerCallback_0 != null)
		{
			changeGuildBannerCallback_0(false);
		}
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x0000F03F File Offset: 0x0000D23F
	public void imethod_1(GetMyGuildInfoCallback getMyGuildInfoCallback_0)
	{
		if (getMyGuildInfoCallback_0 != null)
		{
			getMyGuildInfoCallback_0(-1, null);
		}
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x0000F04C File Offset: 0x0000D24C
	public void imethod_2(GetMyGuildIdCallback getMyGuildIdCallback_0)
	{
		if (getMyGuildIdCallback_0 != null)
		{
			getMyGuildIdCallback_0(-1);
		}
	}

	// Token: 0x060013B0 RID: 5040 RVA: 0x0000F058 File Offset: 0x0000D258
	public void imethod_3(GetGuildInfoCallback getGuildInfoCallback_0, int int_0)
	{
		if (getGuildInfoCallback_0 != null)
		{
			getGuildInfoCallback_0(null);
		}
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x0000F064 File Offset: 0x0000D264
	public void imethod_4(CreateGuildCallback createGuildCallback_0, string string_0, string string_1 = null, GuildPreference guildPreference_0 = GuildPreference.None)
	{
		if (createGuildCallback_0 != null)
		{
			createGuildCallback_0(GuildCreationResult.FAILURE_ETC, null);
		}
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x0000F072 File Offset: 0x0000D272
	public void imethod_5(DismissGuildCallback dismissGuildCallback_0, int int_0)
	{
		if (dismissGuildCallback_0 != null)
		{
			dismissGuildCallback_0(false);
		}
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x0000F07E File Offset: 0x0000D27E
	public void imethod_6(ChangeGuildMasterCallback changeGuildMasterCallback_0, int int_0)
	{
		if (changeGuildMasterCallback_0 != null)
		{
			changeGuildMasterCallback_0(false, 0);
		}
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x0000F08B File Offset: 0x0000D28B
	public void imethod_7(QuitGuildCallback quitGuildCallback_0, int int_0)
	{
		if (quitGuildCallback_0 != null)
		{
			quitGuildCallback_0(false);
		}
	}

	// Token: 0x060013B5 RID: 5045 RVA: 0x0000F097 File Offset: 0x0000D297
	public void imethod_8(ExpellFromGuildCallback expellFromGuildCallback_0, int int_0, int int_1)
	{
		if (expellFromGuildCallback_0 != null)
		{
			expellFromGuildCallback_0(false, 0);
		}
	}

	// Token: 0x060013B6 RID: 5046 RVA: 0x0000F0A4 File Offset: 0x0000D2A4
	public void imethod_9(SearchGuildCallback searchGuildCallback_0, GuildPreference guildPreference_0, int int_0 = 50)
	{
		if (searchGuildCallback_0 != null)
		{
			searchGuildCallback_0(null);
		}
	}

	// Token: 0x060013B7 RID: 5047 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
	public void imethod_10(ApplyToGuildCallback applyToGuildCallback_0, int int_0)
	{
		if (applyToGuildCallback_0 != null)
		{
			applyToGuildCallback_0(false, 0, 0, null);
		}
	}

	// Token: 0x060013B8 RID: 5048 RVA: 0x0000F0BF File Offset: 0x0000D2BF
	public void imethod_11(GetGuildApplicationsCallback getGuildApplicationsCallback_0, int int_0)
	{
		if (getGuildApplicationsCallback_0 != null)
		{
			getGuildApplicationsCallback_0(null);
		}
	}

	// Token: 0x060013B9 RID: 5049 RVA: 0x0000F0CB File Offset: 0x0000D2CB
	public void imethod_12(GetMyGuildApplicationsCallback getMyGuildApplicationsCallback_0)
	{
		if (getMyGuildApplicationsCallback_0 != null)
		{
			getMyGuildApplicationsCallback_0(null);
		}
	}

	// Token: 0x060013BA RID: 5050 RVA: 0x0000F0D7 File Offset: 0x0000D2D7
	public void imethod_13(CancelMyGuildApplicationCallback cancelMyGuildApplicationCallback_0, int int_0)
	{
		if (cancelMyGuildApplicationCallback_0 != null)
		{
			cancelMyGuildApplicationCallback_0(false);
		}
	}

	// Token: 0x060013BB RID: 5051 RVA: 0x0000F0E3 File Offset: 0x0000D2E3
	public void imethod_14(ProcessGuildApplicationsCallback processGuildApplicationsCallback_0, int int_0, List<ApplicantApproval> list_0)
	{
		if (processGuildApplicationsCallback_0 != null)
		{
			processGuildApplicationsCallback_0(0, 0);
		}
	}

	// Token: 0x060013BC RID: 5052 RVA: 0x0000F0F0 File Offset: 0x0000D2F0
	public void imethod_15(InviteToGuildCallback inviteToGuildCallback_0, int int_0, int int_1)
	{
		if (inviteToGuildCallback_0 != null)
		{
			inviteToGuildCallback_0(GuildInvitationResult.FAILURE_ETC);
		}
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x0000F0FC File Offset: 0x0000D2FC
	public void imethod_16(GetMyGuildInvitationsCallback getMyGuildInvitationsCallback_0)
	{
		if (getMyGuildInvitationsCallback_0 != null)
		{
			getMyGuildInvitationsCallback_0(null);
		}
	}

	// Token: 0x060013BE RID: 5054 RVA: 0x0000F108 File Offset: 0x0000D308
	public void imethod_17(ProcessGuildInvitationsCallback processGuildInvitationsCallback_0, List<InvitationReply> list_0)
	{
		if (processGuildInvitationsCallback_0 != null)
		{
			processGuildInvitationsCallback_0(null);
		}
	}

	// Token: 0x060013BF RID: 5055 RVA: 0x0000F114 File Offset: 0x0000D314
	public void imethod_18(GetMyGuildNewsCallback getMyGuildNewsCallback_0)
	{
		if (getMyGuildNewsCallback_0 != null)
		{
			getMyGuildNewsCallback_0(null);
		}
	}

	// Token: 0x060013C0 RID: 5056 RVA: 0x0000F120 File Offset: 0x0000D320
	public void imethod_19(AssignGuildManagerCallback assignGuildManagerCallback_0, int int_0, int int_1)
	{
		if (assignGuildManagerCallback_0 != null)
		{
			assignGuildManagerCallback_0(false, 0);
		}
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x0000F12D File Offset: 0x0000D32D
	public void imethod_20(DischargeGuildManagerCallback dischargeGuildManagerCallback_0, int int_0, int int_1)
	{
		if (dischargeGuildManagerCallback_0 != null)
		{
			dischargeGuildManagerCallback_0(false, 0);
		}
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x0000F13A File Offset: 0x0000D33A
	public void imethod_21(GetMyGuildSkillListCallback getMyGuildSkillListCallback_0)
	{
		if (getMyGuildSkillListCallback_0 != null)
		{
			getMyGuildSkillListCallback_0(null);
		}
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x0000F146 File Offset: 0x0000D346
	public void imethod_22(ActivateGuildSkillCallback activateGuildSkillCallback_0, int int_0)
	{
		if (activateGuildSkillCallback_0 != null)
		{
			activateGuildSkillCallback_0(false, 0);
		}
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x0000F153 File Offset: 0x0000D353
	public void imethod_23(GetGuildManagerListCallback getGuildManagerListCallback_0, int int_0)
	{
		if (getGuildManagerListCallback_0 != null)
		{
			getGuildManagerListCallback_0(null);
		}
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_24(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0)
	{
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_25(ReceiveGuildInvitationCallback receiveGuildInvitationCallback_0)
	{
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_26(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0)
	{
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_27(ReceiveGuildJoinedCallback receiveGuildJoinedCallback_0)
	{
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_28(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0)
	{
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_29(ReceiveGuildExpelledCallback receiveGuildExpelledCallback_0)
	{
	}

	// Token: 0x060013CB RID: 5067 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_30(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0)
	{
	}

	// Token: 0x060013CC RID: 5068 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_31(ReceiveFreeGuildSkillSlotGivenCallback receiveFreeGuildSkillSlotGivenCallback_0)
	{
	}

	// Token: 0x060013CD RID: 5069 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_38(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0)
	{
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_39(ReceiveGuildSkillSelectedCallback receiveGuildSkillSelectedCallback_0)
	{
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_32(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0)
	{
	}

	// Token: 0x060013D0 RID: 5072 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_33(ReceiveGuildManagerAssignedCallback receiveGuildManagerAssignedCallback_0)
	{
	}

	// Token: 0x060013D1 RID: 5073 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_34(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0)
	{
	}

	// Token: 0x060013D2 RID: 5074 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_35(ReceiveGuildManagerDischargedCallback receiveGuildManagerDischargedCallback_0)
	{
	}

	// Token: 0x060013D3 RID: 5075 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_36(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0)
	{
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_37(ReceiveGuildMasterChangedCallback receiveGuildMasterChangedCallback_0)
	{
	}
}
