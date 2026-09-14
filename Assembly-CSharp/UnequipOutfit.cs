using System;

// Token: 0x02000424 RID: 1060
public class UnequipOutfit : global::Action
{
	// Token: 0x06001A48 RID: 6728 RVA: 0x00087134 File Offset: 0x00085334
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer is EntityPlayer)
		{
			entityPlayer.method_97((byte)((int)this.m_param));
		}
	}
}
