using System;

// Token: 0x02000419 RID: 1049
public class SecondWindRevive : Interaction
{
	// Token: 0x06001A2C RID: 6700 RVA: 0x00086F78 File Offset: 0x00085178
	protected override InteractionClient vmethod_6()
	{
		EntityPlayer entityPlayer = BadAssNetworkView.smethod_4((int)this.m_param) as EntityPlayer;
		if (entityPlayer != null)
		{
			return entityPlayer;
		}
		return null;
	}

	// Token: 0x06001A2D RID: 6701 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_5()
	{
	}

	// Token: 0x06001A2E RID: 6702 RVA: 0x00086FA8 File Offset: 0x000851A8
	protected override void vmethod_3()
	{
		InteractionClient interactionClient = this.vmethod_6();
		EntityPlayer entityPlayer = interactionClient as EntityPlayer;
		entityPlayer.method_148(this.m_entity as EntityPlayer);
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_4()
	{
	}
}
