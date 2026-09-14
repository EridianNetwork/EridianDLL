using System;

// Token: 0x02000418 RID: 1048
public class SecondWindQuickEnd : Interaction
{
	// Token: 0x06001A2A RID: 6698 RVA: 0x00086F78 File Offset: 0x00085178
	protected override InteractionClient vmethod_6()
	{
		EntityPlayer entityPlayer = BadAssNetworkView.smethod_4((int)this.m_param) as EntityPlayer;
		if (entityPlayer != null)
		{
			return entityPlayer;
		}
		return null;
	}
}
