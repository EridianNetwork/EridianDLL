using System;

// Token: 0x02000417 RID: 1047
public class LevelTriggerInteraction : Interaction
{
	// Token: 0x06001A28 RID: 6696 RVA: 0x00086F4C File Offset: 0x0008514C
	protected override InteractionClient vmethod_6()
	{
		LevelObjectSync levelObjectSync = LevelObjectSyncManager.LevelObjectSyncManager_0.method_4((int)this.m_param);
		return levelObjectSync as InteractionClient;
	}
}
