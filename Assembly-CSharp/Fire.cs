using System;

// Token: 0x02000413 RID: 1043
public class Fire : global::Action
{
	// Token: 0x06001A1B RID: 6683 RVA: 0x00086E28 File Offset: 0x00085028
	protected override void vmethod_5()
	{
		if (this.m_entity is EntityWeapon)
		{
			EntityWeapon entityWeapon = (EntityWeapon)this.m_entity;
			entityWeapon.method_31(this.LastActionMessage);
			if (!(entityWeapon.m_owner is EntityPlayer))
			{
			}
		}
	}

	// Token: 0x06001A1C RID: 6684 RVA: 0x00086E68 File Offset: 0x00085068
	protected override void vmethod_4()
	{
		if (this.m_entity is EntityWeapon)
		{
			EntityWeapon entityWeapon = (EntityWeapon)this.m_entity;
			entityWeapon.method_32(this.LastActionMessage, base.m_actionDelay);
			if (!(entityWeapon.m_owner is EntityPlayer))
			{
			}
		}
	}

	// Token: 0x06001A1D RID: 6685 RVA: 0x00086EB0 File Offset: 0x000850B0
	protected override void vmethod_3()
	{
		EntityWeapon entityWeapon = this.m_entity as EntityWeapon;
		if (entityWeapon == null)
		{
			return;
		}
		entityWeapon.method_34(base.m_actionDelay);
	}
}
