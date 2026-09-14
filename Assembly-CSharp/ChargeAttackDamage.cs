using System;

// Token: 0x0200042F RID: 1071
public class ChargeAttackDamage : global::Action
{
	// Token: 0x06001A5A RID: 6746 RVA: 0x000871EC File Offset: 0x000853EC
	protected override void vmethod_5()
	{
		if (this.m_entity is ChargeAttackDamager)
		{
			ChargeAttackDamager chargeAttackDamager = (ChargeAttackDamager)this.m_entity;
			chargeAttackDamager.imethod_3();
		}
	}
}
