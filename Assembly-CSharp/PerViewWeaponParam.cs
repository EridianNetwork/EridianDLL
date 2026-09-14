using System;

// Token: 0x02000901 RID: 2305
[Serializable]
public class PerViewWeaponParam : ICloneable
{
	// Token: 0x06003F80 RID: 16256 RVA: 0x0012C350 File Offset: 0x0012A550
	public object Clone()
	{
		return (PerViewWeaponParam)base.MemberwiseClone();
	}

	// Token: 0x04002CA3 RID: 11427
	public float m_AccuracyMin;

	// Token: 0x04002CA4 RID: 11428
	public float m_AccuracyMax;

	// Token: 0x04002CA5 RID: 11429
	public float m_AccuracyDecrease;

	// Token: 0x04002CA6 RID: 11430
	public float m_AccuracyRegenerationRateActive;

	// Token: 0x04002CA7 RID: 11431
	public float m_AccuracyRegenerationRateOnIdle;

	// Token: 0x04002CA8 RID: 11432
	public float m_rotationTime;

	// Token: 0x04002CA9 RID: 11433
	public float m_switchViewTime;

	// Token: 0x04002CAA RID: 11434
	public float m_InnerAccuracyMin;

	// Token: 0x04002CAB RID: 11435
	public float m_InnerAccuracyMax;

	// Token: 0x04002CAC RID: 11436
	public float m_InnerAccuracyDecrease;

	// Token: 0x04002CAD RID: 11437
	public float m_InnerAccuracyRegenerationRateActive;

	// Token: 0x04002CAE RID: 11438
	public float m_InnerAccuracyRatio;

	// Token: 0x04002CAF RID: 11439
	public float m_InnerAccuracy;

	// Token: 0x04002CB0 RID: 11440
	public float m_recoverTime = 0.2f;
}
