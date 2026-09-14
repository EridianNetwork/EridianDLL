using System;

// Token: 0x02000549 RID: 1353
public class PlayerSkillAction : global::Action
{
	// Token: 0x060022E5 RID: 8933 RVA: 0x00017F1E File Offset: 0x0001611E
	protected override void vmethod_5()
	{
		(this.m_entity as EntityPlayer).PlayerSkillManage_0.OnTriggerAction(base.m_actionDelay);
	}

	// Token: 0x060022E6 RID: 8934 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_3()
	{
	}
}
