using System;
using UnityEngine;

// Token: 0x02000459 RID: 1113
public class EntityNpcSpiderantTalos : EntityNpc
{
	// Token: 0x06001BC1 RID: 7105 RVA: 0x00013F0F File Offset: 0x0001210F
	public override void Start()
	{
		base.Start();
		this.m_bAllArmorDestoryed = false;
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x00013F1E File Offset: 0x0001211E
	public override void Update()
	{
		base.Update();
		if (this.m_bAllArmorDestoryed)
		{
		}
	}

	// Token: 0x06001BC3 RID: 7107 RVA: 0x00013F2E File Offset: 0x0001212E
	public override ENPCParticleType vmethod_13(ENPCParticleType enpcparticleType_0, WeakPoint weakPoint_0)
	{
		if (weakPoint_0.method_1())
		{
			return ENPCParticleType.E_DamageOnArmor;
		}
		if (weakPoint_0.method_3() != WeakPoint.StrengthType.Strong)
		{
			if (weakPoint_0.method_3() != WeakPoint.StrengthType.VeryStrong)
			{
				return enpcparticleType_0;
			}
		}
		return ENPCParticleType.E_DamageOnArmor;
	}

	// Token: 0x0400126F RID: 4719
	public Transform m_armorLeft;

	// Token: 0x04001270 RID: 4720
	public Transform m_armorRight;

	// Token: 0x04001271 RID: 4721
	public Transform m_armorBack;

	// Token: 0x04001272 RID: 4722
	[HideInInspector]
	public bool m_bAllArmorDestoryed;

	// Token: 0x04001273 RID: 4723
	public Transform m_iceEarthquakeShard;

	// Token: 0x04001274 RID: 4724
	public Transform m_icePick;
}
