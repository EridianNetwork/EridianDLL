using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class BerserkDash : global::Action, Echo
{
	// Token: 0x06001A61 RID: 6753 RVA: 0x00013489 File Offset: 0x00011689
	public override void vmethod_2(Vector3 vector3_0)
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_17(base.method_5(), this.m_entity, vector3_0);
	}

	// Token: 0x06001A62 RID: 6754 RVA: 0x00087248 File Offset: 0x00085448
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer != null && entityPlayer.PlayerSkillManage_0 is BerserkManage)
		{
			entityPlayer.method_81(0f);
		}
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x000134A2 File Offset: 0x000116A2
	public void OnEcho()
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_15(base.method_5(), this.m_entity, (Vector3)this.m_param, 1);
	}
}
