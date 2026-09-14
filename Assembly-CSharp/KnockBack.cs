using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class KnockBack : global::Action, Echo
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x00013489 File Offset: 0x00011689
	public override void vmethod_2(Vector3 vector3_0)
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_17(base.method_5(), this.m_entity, vector3_0);
	}

	// Token: 0x06001A5E RID: 6750 RVA: 0x00087218 File Offset: 0x00085418
	protected override void vmethod_5()
	{
		KnockBackInterface knockBackInterface = this.m_entity as KnockBackInterface;
		if (knockBackInterface != null)
		{
			knockBackInterface.imethod_0((Vector3)this.m_param);
		}
	}

	// Token: 0x06001A5F RID: 6751 RVA: 0x000134A2 File Offset: 0x000116A2
	public void OnEcho()
	{
		AuthoritativeActionManager.AuthoritativeActionManager_0.method_15(base.method_5(), this.m_entity, (Vector3)this.m_param, 1);
	}
}
