using System;
using XsdSettings;

// Token: 0x02000569 RID: 1385
public static class DamageForceFactor
{
	// Token: 0x060023B6 RID: 9142 RVA: 0x000A9838 File Offset: 0x000A7A38
	public static float smethod_0(AttackInfo attackInfo_0, float float_0)
	{
		if (attackInfo_0 == null)
		{
			return 1f;
		}
		if (attackInfo_0.m_subType == AttackSubType.AreaExplosion)
		{
			return 100f;
		}
		if (attackInfo_0.m_subType == AttackSubType.AreaGrenade)
		{
			return 80f;
		}
		if (attackInfo_0.m_subType == AttackSubType.ProjectileShotgun)
		{
			if (float_0 < 15f)
			{
				return 60f;
			}
		}
		else if (attackInfo_0.m_subType == AttackSubType.ProjectileSniper && float_0 < 15f)
		{
			return 40f;
		}
		return 1f;
	}

	// Token: 0x04001841 RID: 6209
	public const float m_explosionForce = 100f;

	// Token: 0x04001842 RID: 6210
	public const float m_grenadeForce = 80f;

	// Token: 0x04001843 RID: 6211
	public const float m_shotgunForce = 60f;

	// Token: 0x04001844 RID: 6212
	public const float m_sniperForce = 40f;

	// Token: 0x04001845 RID: 6213
	public const float m_rifleForce = 20f;

	// Token: 0x04001846 RID: 6214
	public const float m_defaultForce = 1f;
}
