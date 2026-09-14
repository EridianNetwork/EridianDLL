using System;
using Photon;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class PlayerSkillTreeManage : global::Photon.MonoBehaviour
{
	// Token: 0x06002105 RID: 8453 RVA: 0x00016DCE File Offset: 0x00014FCE
	public void OnLocalSkillUpgrade()
	{
		base.photonView.method_4("RPC_L2H_RequestSyncSkill", PhotonTargets.MasterClient, new object[0]);
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x0009FF90 File Offset: 0x0009E190
	[RPC]
	private void RPC_H2C_SkillEvent(int _target, int _networkId, int _event, float _fParam, Vector3 _vParam, PhotonMessageInfo info)
	{
		EntityPlayer entityPlayer = BadAssNetworkView.smethod_4(_networkId) as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		if (entityPlayer.vmethod_25() == null)
		{
			return;
		}
		if (entityPlayer.PlayerSkillManage_0 == null)
		{
			return;
		}
		if (entityPlayer.vmethod_25().IsMyActor())
		{
			entityPlayer.PlayerSkillManage_0.OnSkillEvent_Local((SkillEvent)_event, _fParam, _vParam);
		}
		if (_target == 1)
		{
			entityPlayer.PlayerSkillManage_0.OnSkillEvent_Client((SkillEvent)_event, _fParam, _vParam);
		}
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x000A0004 File Offset: 0x0009E204
	public void method_0(SkillItem skillItem_0)
	{
		object[] array = new object[]
		{
			(int)skillItem_0.m_type,
			skillItem_0.m_expect_grade
		};
		base.photonView.method_4("RPC_L2H_Hack_SetSkillPt", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x000A0048 File Offset: 0x0009E248
	public void method_1(MarkManager.ESlowdownType eslowdownType_0)
	{
		object[] array = new object[] { (int)eslowdownType_0 };
		base.photonView.method_4("RPC_L2H_SetSlowdownType", PhotonTargets.MasterClient, array);
	}
}
