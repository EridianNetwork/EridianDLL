using System;

// Token: 0x02000573 RID: 1395
public interface IDamageListener
{
	// Token: 0x060023C4 RID: 9156
	void OnDamaged(DamageContext context);

	// Token: 0x060023C5 RID: 9157
	void OnEntityKill(KillContext context);
}
