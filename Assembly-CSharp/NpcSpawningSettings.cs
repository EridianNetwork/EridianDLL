using System;

// Token: 0x02000407 RID: 1031
[Serializable]
public class NpcSpawningSettings
{
	// Token: 0x04001151 RID: 4433
	public NpcSpawningSettings.InitialState m_initialState;

	// Token: 0x04001152 RID: 4434
	public PatrolSettings m_patrolSetting = new PatrolSettings();

	// Token: 0x04001153 RID: 4435
	public bool m_bDefenseMode;

	// Token: 0x04001154 RID: 4436
	public bool m_bCombatSlot;

	// Token: 0x04001155 RID: 4437
	public float m_spawnDistance;

	// Token: 0x02000408 RID: 1032
	public enum InitialState
	{
		// Token: 0x04001157 RID: 4439
		Patrol,
		// Token: 0x04001158 RID: 4440
		Idle,
		// Token: 0x04001159 RID: 4441
		Cover,
		// Token: 0x0400115A RID: 4442
		Spawn,
		// Token: 0x0400115B RID: 4443
		AdvanceSpawn,
		// Token: 0x0400115C RID: 4444
		CombatSpawn
	}
}
