using System;

// Token: 0x02000415 RID: 1045
public abstract class Interaction : global::Action
{
	// Token: 0x06001A21 RID: 6689 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_5()
	{
	}

	// Token: 0x06001A22 RID: 6690 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_3()
	{
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_4()
	{
	}

	// Token: 0x06001A24 RID: 6692
	protected abstract InteractionClient vmethod_6();

	// Token: 0x04001182 RID: 4482
	protected const float LONG_INTERACTION_DURATION = 0.8f;

	// Token: 0x04001183 RID: 4483
	protected float m_startTime;

	// Token: 0x04001184 RID: 4484
	protected bool m_hasInteracted;
}
