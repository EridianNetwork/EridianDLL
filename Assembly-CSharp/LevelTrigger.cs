using System;

// Token: 0x02000515 RID: 1301
public class LevelTrigger : LevelObjectSync
{
	// Token: 0x060021B0 RID: 8624 RVA: 0x000A1814 File Offset: 0x0009FA14
	public override void vmethod_0(LevelObjectSync.LevelObjectSyncState levelObjectSyncState_0)
	{
		if (this.m_useOnce && !this.m_used)
		{
			LevelObjectSync.LevelObjectSyncState levelObjectSyncState = base.method_2();
			base.vmethod_0(levelObjectSyncState_0);
			LevelObjectSync.LevelObjectSyncState levelObjectSyncState2 = base.method_2();
			this.m_used |= levelObjectSyncState != levelObjectSyncState2;
		}
	}

	// Token: 0x04001664 RID: 5732
	public bool m_useOnce;

	// Token: 0x04001665 RID: 5733
	protected bool m_used;
}
