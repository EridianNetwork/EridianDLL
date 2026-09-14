using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class Throw : global::Action, InstantiateManager.InstanciationClient
{
	// Token: 0x06001A31 RID: 6705 RVA: 0x00086FD4 File Offset: 0x000851D4
	protected override void vmethod_5()
	{
		if (this.m_entity is EntityPlayer)
		{
			EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
			if (entityPlayer)
			{
				entityPlayer.method_85(base.m_actionDelay);
			}
		}
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_6()
	{
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_3()
	{
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x00087010 File Offset: 0x00085210
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		EntityObject component = instance.GetComponent<EntityObject>();
		if (component != null)
		{
			component.method_15(this.m_entity);
			EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
			if (entityPlayer)
			{
				entityPlayer.method_144(instance);
			}
		}
	}
}
