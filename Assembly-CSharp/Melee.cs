using System;

// Token: 0x0200042B RID: 1067
public class Melee : global::Action
{
	// Token: 0x06001A54 RID: 6740 RVA: 0x00087194 File Offset: 0x00085394
	protected override void vmethod_5()
	{
		if (this.m_entity is MeleeAttacker)
		{
			MeleeAttacker meleeAttacker = (MeleeAttacker)this.m_entity;
			meleeAttacker.imethod_1();
		}
	}
}
