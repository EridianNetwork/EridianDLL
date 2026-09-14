using System;

// Token: 0x02000416 RID: 1046
public class EntityInteraction : Interaction
{
	// Token: 0x06001A26 RID: 6694 RVA: 0x00086F18 File Offset: 0x00085118
	protected override InteractionClient vmethod_6()
	{
		EntityObject entityObject = BadAssNetworkView.smethod_4((int)this.m_param) as EntityObject;
		if (entityObject != null)
		{
			return entityObject.m_pickable;
		}
		return null;
	}
}
