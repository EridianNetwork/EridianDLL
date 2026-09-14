using System;

// Token: 0x02000422 RID: 1058
public class Tidy : global::Action
{
	// Token: 0x06001A44 RID: 6724 RVA: 0x000870D8 File Offset: 0x000852D8
	protected override void vmethod_5()
	{
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer is EntityPlayer)
		{
			entityPlayer.method_96();
		}
	}
}
