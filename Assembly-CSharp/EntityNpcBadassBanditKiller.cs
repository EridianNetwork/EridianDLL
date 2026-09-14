using System;
using XsdSettings;

// Token: 0x02000455 RID: 1109
public class EntityNpcBadassBanditKiller : EntityNpc
{
	// Token: 0x06001BAF RID: 7087 RVA: 0x00013E81 File Offset: 0x00012081
	public override bool vmethod_48(AttackInfo attackInfo_0)
	{
		return attackInfo_0.m_subType == AttackSubType.AreaExplosion && attackInfo_0.m_attacker == attackInfo_0.m_owner;
	}

	// Token: 0x06001BB0 RID: 7088 RVA: 0x00013E9E File Offset: 0x0001209E
	public override ENPCParticleType vmethod_13(ENPCParticleType enpcparticleType_0, WeakPoint weakPoint_0)
	{
		if (weakPoint_0.m_partInfo == WeakPoint.PartInfo.ExtraPart)
		{
			return ENPCParticleType.E_DamagedBulletShock;
		}
		return enpcparticleType_0;
	}
}
