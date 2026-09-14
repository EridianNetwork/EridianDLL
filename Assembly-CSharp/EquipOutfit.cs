using System;

// Token: 0x02000423 RID: 1059
public class EquipOutfit : global::Action
{
	// Token: 0x06001A46 RID: 6726 RVA: 0x00087100 File Offset: 0x00085300
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer is EntityPlayer)
		{
			entityPlayer.method_95((byte)((int)this.m_param));
		}
	}
}
