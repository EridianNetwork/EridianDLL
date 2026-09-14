using System;

// Token: 0x0200051E RID: 1310
public class ZoneTrigger : LevelTrigger
{
	// Token: 0x0400167F RID: 5759
	public ZoneTrigger.TriggerCondition m_triggerCondition;

	// Token: 0x04001680 RID: 5760
	private int m_playerInTriggerCount;

	// Token: 0x0200051F RID: 1311
	public enum TriggerCondition
	{
		// Token: 0x04001682 RID: 5762
		Enter,
		// Token: 0x04001683 RID: 5763
		Leave,
		// Token: 0x04001684 RID: 5764
		Occupied
	}
}
