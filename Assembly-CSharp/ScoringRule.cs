using System;
using XsdSettings;

// Token: 0x02000537 RID: 1335
public interface ScoringRule
{
	// Token: 0x06002257 RID: 8791
	void imethod_0();

	// Token: 0x06002258 RID: 8792
	void OnDamagedPreStat(DamageContext context);

	// Token: 0x06002259 RID: 8793
	void OnDamagedPostStat(DamageContext context);

	// Token: 0x0600225A RID: 8794
	void OnEntityKillPreStat(KillContext context);

	// Token: 0x0600225B RID: 8795
	void OnEntityKillPostStat(KillContext context);

	// Token: 0x0600225C RID: 8796
	void OnPickedUp(EntityPlayer picker, EntityObject item);

	// Token: 0x0600225D RID: 8797
	int imethod_1(ScoringActionType scoringActionType_0, Entity entity_0, Entity entity_1);

	// Token: 0x0600225E RID: 8798
	void imethod_2(int int_0);

	// Token: 0x0600225F RID: 8799
	void imethod_3(Entity entity_0);

	// Token: 0x06002260 RID: 8800
	void OnUpdateMatch();

	// Token: 0x06002261 RID: 8801
	void OnEndMatch();

	// Token: 0x06002262 RID: 8802
	InstanceGrade imethod_4(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0);

	// Token: 0x06002263 RID: 8803
	int imethod_5(EntityNpc.EntityNpcRank entityNpcRank_0);

	// Token: 0x06002264 RID: 8804
	void imethod_6(StatisticsManager.SessionStats sessionStats_0);
}
