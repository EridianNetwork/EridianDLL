using System;
using System.Collections.Generic;

// Token: 0x020002DD RID: 733
public class GroupServiceWrapper : ServiceWrapper<IGroupServiceWrapper, GroupServiceWrapper>
{
	// Token: 0x0600105B RID: 4187 RVA: 0x0000DD11 File Offset: 0x0000BF11
	public void method_0(IGroupServiceNotificationListerner igroupServiceNotificationListerner_0)
	{
		this.m_listerner.Add(igroupServiceNotificationListerner_0);
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x0000DD1F File Offset: 0x0000BF1F
	public void method_1(IGroupServiceNotificationListerner igroupServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(igroupServiceNotificationListerner_0);
	}

	// Token: 0x0600105D RID: 4189 RVA: 0x0000DD2E File Offset: 0x0000BF2E
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new GroupServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x0600105E RID: 4190 RVA: 0x0000DD41 File Offset: 0x0000BF41
	public void method_2(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		this.vmethod_0().imethod_2(onGotMyGroupInfo_0);
	}

	// Token: 0x0600105F RID: 4191 RVA: 0x0000DD4F File Offset: 0x0000BF4F
	public void method_3(OnSendGroupInvitation onSendGroupInvitation_0, int int_0)
	{
		this.vmethod_0().imethod_3(onSendGroupInvitation_0, int_0);
	}

	// Token: 0x06001060 RID: 4192 RVA: 0x0000DD5E File Offset: 0x0000BF5E
	public void method_4(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0)
	{
		this.vmethod_0().imethod_5(onGroupInviteAccepted_0, int_0);
	}

	// Token: 0x06001061 RID: 4193 RVA: 0x0000DD6D File Offset: 0x0000BF6D
	public void method_5(int int_0)
	{
		this.vmethod_0().imethod_6(int_0);
	}

	// Token: 0x06001062 RID: 4194 RVA: 0x0000DD7B File Offset: 0x0000BF7B
	public void method_6(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0)
	{
		this.vmethod_0().imethod_7(onKickPlayerFromGroup_0, int_0);
	}

	// Token: 0x06001063 RID: 4195 RVA: 0x0000DD8A File Offset: 0x0000BF8A
	public void method_7(OnLeaveGroup onLeaveGroup_0)
	{
		this.vmethod_0().imethod_8(onLeaveGroup_0);
	}

	// Token: 0x06001064 RID: 4196 RVA: 0x0000DD98 File Offset: 0x0000BF98
	public void method_8()
	{
		this.vmethod_0().imethod_4();
	}

	// Token: 0x06001065 RID: 4197 RVA: 0x0000DDA5 File Offset: 0x0000BFA5
	public void method_9(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		this.vmethod_0().imethod_9(onGotMyGroupInfo_0);
	}

	// Token: 0x06001066 RID: 4198 RVA: 0x00075CC0 File Offset: 0x00073EC0
	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnReceivedGroupInvitation(senderCharacterId, groupId, messageId);
		}
	}

	// Token: 0x06001067 RID: 4199 RVA: 0x00075CF8 File Offset: 0x00073EF8
	public void OnKickedFromGroup()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnKickedFromGroup();
		}
	}

	// Token: 0x06001068 RID: 4200 RVA: 0x00075D2C File Offset: 0x00073F2C
	public void OnNewGroupLeader(int characterId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnNewGroupLeader(characterId);
		}
	}

	// Token: 0x06001069 RID: 4201 RVA: 0x00075D64 File Offset: 0x00073F64
	public void OnNewGroupMember(Presence characterinfo)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnNewGroupMember(characterinfo);
		}
	}

	// Token: 0x0600106A RID: 4202 RVA: 0x00075D9C File Offset: 0x00073F9C
	public void OnGroupInviteRejected(int characterId, string characterName)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupInviteRejected(characterId, characterName);
		}
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x00075DD4 File Offset: 0x00073FD4
	public void OnGroupMemberLeft(int characterId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupMemberLeft(characterId);
		}
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x00075E0C File Offset: 0x0007400C
	public void OnGroupDisbanded()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupDisbanded();
		}
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x00075E40 File Offset: 0x00074040
	public void OnGroupMatchmakingStarted()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupMatchmakingStarted();
		}
	}

	// Token: 0x04000DCC RID: 3532
	private List<IGroupServiceNotificationListerner> m_listerner = new List<IGroupServiceNotificationListerner>();
}
