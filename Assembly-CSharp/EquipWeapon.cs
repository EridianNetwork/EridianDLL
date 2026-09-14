using System;

// Token: 0x0200041C RID: 1052
public class EquipWeapon : global::Action
{
	// Token: 0x06001A38 RID: 6712 RVA: 0x00087088 File Offset: 0x00085288
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer is EntityPlayer)
		{
			entityPlayer.method_89((byte)((int)this.m_param & 255), (byte)(((int)this.m_param & 65280) >> 8));
		}
	}
}
