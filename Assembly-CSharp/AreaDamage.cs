using System;

// Token: 0x02000429 RID: 1065
public class AreaDamage : global::Action
{
	// Token: 0x06001A51 RID: 6737 RVA: 0x00087168 File Offset: 0x00085368
	protected override void vmethod_5()
	{
		if (this.m_entity is AreaDamager)
		{
			AreaDamager areaDamager = (AreaDamager)this.m_entity;
			areaDamager.imethod_0();
		}
	}
}
