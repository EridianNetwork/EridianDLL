using System;

// Token: 0x02000576 RID: 1398
[Serializable]
public class DamageSettings
{
	// Token: 0x04001894 RID: 6292
	public float m_pve_damageMin;

	// Token: 0x04001895 RID: 6293
	public float m_pve_damageMax;

	// Token: 0x04001896 RID: 6294
	public float m_pvp_damageMin;

	// Token: 0x04001897 RID: 6295
	public float m_pvp_damageMax;

	// Token: 0x04001898 RID: 6296
	public float[] m_weakpointStrengthModifiers = new float[6];

	// Token: 0x04001899 RID: 6297
	public int m_DOT_LIMIT_AI;

	// Token: 0x0400189A RID: 6298
	public int m_DOT_LIMIT_PLAYER;

	// Token: 0x0400189B RID: 6299
	public int[] m_meleeDamage = new int[20];
}
