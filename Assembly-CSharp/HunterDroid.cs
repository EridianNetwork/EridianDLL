using System;
using Photon;
using UnityEngine;

// Token: 0x02000540 RID: 1344
public class HunterDroid : global::Photon.MonoBehaviour
{
	// Token: 0x060022C1 RID: 8897 RVA: 0x00017DAB File Offset: 0x00015FAB
	private void Start()
	{
		this.method_0();
	}

	// Token: 0x060022C2 RID: 8898 RVA: 0x000A4EF0 File Offset: 0x000A30F0
	private void method_0()
	{
		int num = (int)base.photonView.Object_0[0];
		this.m_playerOwner = BadAssNetworkView.smethod_4(num) as EntityPlayer;
		this.m_skillMgr = this.m_playerOwner.PlayerSkillManage_0 as HunterManage;
		if (this.m_playerOwner.vmethod_25().IsMyActor())
		{
			Transform transform = this.m_playerOwner.method_45().transform;
			base.transform.position = transform.position + transform.TransformDirection(this.m_skillMgr.method_22());
			base.transform.rotation = transform.rotation * Quaternion.Euler(this.m_skillMgr.m_settings.m_pitch_droid, this.m_skillMgr.m_settings.m_yaw_droid, 0f);
			base.transform.parent = transform;
		}
		else
		{
			base.transform.position = this.m_playerOwner.transform.position + this.m_playerOwner.transform.TransformDirection(this.m_skillMgr.method_22());
			base.transform.rotation = this.m_playerOwner.transform.rotation * Quaternion.Euler(this.m_skillMgr.m_settings.m_pitch_droid, this.m_skillMgr.m_settings.m_yaw_droid, 0f);
			base.transform.parent = this.m_playerOwner.transform;
		}
		this.m_skillMgr.method_11(this);
	}

	// Token: 0x060022C3 RID: 8899 RVA: 0x00017DB3 File Offset: 0x00015FB3
	private void Update()
	{
		base.transform.rotation = Quaternion.LookRotation(this.m_playerOwner.vmethod_27());
	}

	// Token: 0x0400171A RID: 5914
	private EntityPlayer m_playerOwner;

	// Token: 0x0400171B RID: 5915
	private HunterManage m_skillMgr;
}
