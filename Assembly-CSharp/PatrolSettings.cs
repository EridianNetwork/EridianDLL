using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class PatrolSettings
{
	// Token: 0x0400114B RID: 4427
	public PatrolSettings.PatrolPolicy m_patrolPolicy;

	// Token: 0x0400114C RID: 4428
	public PatrolPoint[] m_patrolPath = new PatrolPoint[0];

	// Token: 0x02000406 RID: 1030
	public enum PatrolPolicy
	{
		// Token: 0x0400114E RID: 4430
		None,
		// Token: 0x0400114F RID: 4431
		Sequencial,
		// Token: 0x04001150 RID: 4432
		Random
	}
}
