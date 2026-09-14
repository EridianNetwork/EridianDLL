using System;
using XsdSettings;

// Token: 0x02000326 RID: 806
public class LobbyServiceOffline : ILobbyService
{
	// Token: 0x060013E9 RID: 5097 RVA: 0x0000F201 File Offset: 0x0000D401
	public void imethod_0(OnCreateLobby onCreateLobby_0, bool bool_0)
	{
		if (onCreateLobby_0 != null)
		{
			onCreateLobby_0(null);
		}
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x0000F20D File Offset: 0x0000D40D
	public void imethod_1(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0)
	{
		if (onOpenLobby_0 != null)
		{
			onOpenLobby_0(null);
		}
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x0000F219 File Offset: 0x0000D419
	public void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		if (onInviteToLobby_0 != null)
		{
			onInviteToLobby_0(false);
		}
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x0000F225 File Offset: 0x0000D425
	public void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		if (onAcceptLobbyInvitation_0 != null)
		{
			onAcceptLobbyInvitation_0(null);
		}
	}

	// Token: 0x060013ED RID: 5101 RVA: 0x0000F231 File Offset: 0x0000D431
	public void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		if (onRejectLobbyInvitation_0 != null)
		{
			onRejectLobbyInvitation_0(false);
		}
	}

	// Token: 0x060013EE RID: 5102 RVA: 0x0000F23D File Offset: 0x0000D43D
	public void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		if (onKickPlayerFromLobby_0 != null)
		{
			onKickPlayerFromLobby_0(false, -1);
		}
	}

	// Token: 0x060013EF RID: 5103 RVA: 0x0000F24A File Offset: 0x0000D44A
	public void imethod_6(OnLeaveLobby onLeaveLobby_0)
	{
		if (onLeaveLobby_0 != null)
		{
			onLeaveLobby_0(false);
		}
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x0000F256 File Offset: 0x0000D456
	public void imethod_7(OnStartLobbyGame onStartLobbyGame_0)
	{
		if (onStartLobbyGame_0 != null)
		{
			onStartLobbyGame_0(false);
		}
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x0000F262 File Offset: 0x0000D462
	public void imethod_8(OnGetLobby onGetLobby_0)
	{
		if (onGetLobby_0 != null)
		{
			onGetLobby_0(null);
		}
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x0000F26E File Offset: 0x0000D46E
	public void imethod_9(OnCloseLobby onCloseLobby_0)
	{
		if (onCloseLobby_0 == null)
		{
			onCloseLobby_0(false);
		}
	}

	// Token: 0x060013F3 RID: 5107 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_10(OnPlayerJoinLobby onPlayerJoinLobby_0)
	{
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(OnPlayerJoinLobby onPlayerJoinLobby_0)
	{
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_12(OnPlayerLeaveLobby onPlayerLeaveLobby_0)
	{
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_13(OnPlayerLeaveLobby onPlayerLeaveLobby_0)
	{
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(OnLobbyCreated onLobbyCreated_0)
	{
	}

	// Token: 0x060013F8 RID: 5112 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_15(OnLobbyCreated onLobbyCreated_0)
	{
	}

	// Token: 0x060013F9 RID: 5113 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_16(OnLobbyGameStart onLobbyGameStart_0)
	{
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17(OnLobbyGameStart onLobbyGameStart_0)
	{
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18(OnLobbyClose onLobbyClose_0)
	{
	}

	// Token: 0x060013FC RID: 5116 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_19(OnLobbyClose onLobbyClose_0)
	{
	}

	// Token: 0x060013FD RID: 5117 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_20(OnLobbyDelete onLobbyDelete_0)
	{
	}

	// Token: 0x060013FE RID: 5118 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_21(OnLobbyDelete onLobbyDelete_0)
	{
	}

	// Token: 0x060013FF RID: 5119 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_22(OnLobbyOwnerChange onLobbyOwnerChange_0)
	{
	}

	// Token: 0x06001400 RID: 5120 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_23(OnLobbyOwnerChange onLobbyOwnerChange_0)
	{
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_24(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0)
	{
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_25(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0)
	{
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_26(OnGroupJoinLobby onGroupJoinLobby_0)
	{
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_27(OnGroupJoinLobby onGroupJoinLobby_0)
	{
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_28(OnGroupLeaveLobby onGroupLeaveLobby_0)
	{
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_29(OnGroupLeaveLobby onGroupLeaveLobby_0)
	{
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_30(OnNewLobby onNewLobby_0)
	{
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_31(OnNewLobby onNewLobby_0)
	{
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x0000F27A File Offset: 0x0000D47A
	public void method_0(OnGetLobby onGetLobby_0, int int_0)
	{
		if (onGetLobby_0 == null)
		{
			onGetLobby_0(null);
		}
	}

	// Token: 0x0600140A RID: 5130 RVA: 0x0000F26E File Offset: 0x0000D46E
	public void method_1(OnCloseLobby onCloseLobby_0, int int_0)
	{
		if (onCloseLobby_0 == null)
		{
			onCloseLobby_0(false);
		}
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x0000F286 File Offset: 0x0000D486
	public void method_2(OnSetPlayerTeamID onSetPlayerTeamID_0, int int_0, int int_1)
	{
		if (onSetPlayerTeamID_0 == null)
		{
			onSetPlayerTeamID_0(false);
		}
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x0000F292 File Offset: 0x0000D492
	public void method_3(OnSubmitPvPResults onSubmitPvPResults_0, int int_0, params int[] int_1)
	{
		if (onSubmitPvPResults_0 == null)
		{
			onSubmitPvPResults_0(0);
		}
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x0000F292 File Offset: 0x0000D492
	public void method_4(OnSubmitPvPResults onSubmitPvPResults_0, int int_0, params int[] int_1)
	{
		if (onSubmitPvPResults_0 == null)
		{
			onSubmitPvPResults_0(0);
		}
	}
}
