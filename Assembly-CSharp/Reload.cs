using System;

// Token: 0x02000414 RID: 1044
public class Reload : global::Action
{
	// Token: 0x06001A1F RID: 6687 RVA: 0x00086EE0 File Offset: 0x000850E0
	protected override void vmethod_5()
	{
		if (this.m_entity is EntityWeapon)
		{
			EntityWeapon entityWeapon = (EntityWeapon)this.m_entity;
			entityWeapon.method_40(base.m_actionDelay, this.LastActionMessage);
		}
	}
}
