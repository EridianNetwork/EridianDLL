using System;

// Token: 0x0200041B RID: 1051
public class SwitchWeapon : global::Action
{
	// Token: 0x06001A36 RID: 6710 RVA: 0x00087054 File Offset: 0x00085254
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer is EntityPlayer)
		{
			entityPlayer.vmethod_79((byte)((int)this.m_param));
		}
	}
}
