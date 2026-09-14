using System;

// Token: 0x0200042D RID: 1069
public class SpitDamage : global::Action
{
	// Token: 0x06001A57 RID: 6743 RVA: 0x000871C0 File Offset: 0x000853C0
	protected override void vmethod_5()
	{
		if (this.m_entity is SpitDamager)
		{
			SpitDamager spitDamager = (SpitDamager)this.m_entity;
			spitDamager.imethod_2();
		}
	}
}
