using System;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x0200056A RID: 1386
public class AttackInfo
{
	// Token: 0x060023B7 RID: 9143 RVA: 0x00003197 File Offset: 0x00001397
	public AttackInfo()
	{
	}

	// Token: 0x060023B8 RID: 9144 RVA: 0x000187D6 File Offset: 0x000169D6
	public AttackInfo(AttackSubType attackSubType_0)
	{
		this.m_subType = attackSubType_0;
	}

	// Token: 0x060023B9 RID: 9145 RVA: 0x000A98A4 File Offset: 0x000A7AA4
	public AttackInfo(AttackInfo attackInfo_0)
	{
		this.m_subType = attackInfo_0.m_subType;
		this.m_attacker = attackInfo_0.m_attacker;
		this.m_target = attackInfo_0.m_target;
		this.m_origin = attackInfo_0.m_origin;
		this.m_direction = attackInfo_0.m_direction;
		this.m_timeStamp = attackInfo_0.m_timeStamp;
		this.m_damagePoint = attackInfo_0.m_damagePoint;
	}

	// Token: 0x060023BA RID: 9146 RVA: 0x000A990C File Offset: 0x000A7B0C
	public static AttackInfo.AttackType smethod_0(AttackSubType attackSubType_0)
	{
		if (attackSubType_0 > AttackSubType.ProjectileFirst && attackSubType_0 < AttackSubType.ProjectileLast)
		{
			return AttackInfo.AttackType.Projectile;
		}
		if (attackSubType_0 > AttackSubType.AreaFirst && attackSubType_0 < AttackSubType.AreaLast)
		{
			return AttackInfo.AttackType.Area;
		}
		if (attackSubType_0 > AttackSubType.MeleeFirst && attackSubType_0 < AttackSubType.MeleeLast)
		{
			return AttackInfo.AttackType.Melee;
		}
		if (attackSubType_0 > AttackSubType.DamageOverTimeFirst && attackSubType_0 < AttackSubType.DamageOverTimeLast)
		{
			return AttackInfo.AttackType.DamageOverTime;
		}
		if (attackSubType_0 > AttackSubType.ChargeFirst && attackSubType_0 < AttackSubType.ChargeLast)
		{
			return AttackInfo.AttackType.Charge;
		}
		if (attackSubType_0 > AttackSubType.RecoverFirst && attackSubType_0 < AttackSubType.RecoverLast)
		{
			return AttackInfo.AttackType.Recover;
		}
		if (attackSubType_0 > AttackSubType.SkillFirst && attackSubType_0 < AttackSubType.SkillLast)
		{
			return AttackInfo.AttackType.Skill;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Invalid Attack Sub Type [" + attackSubType_0 + "]");
		return AttackInfo.AttackType.Projectile;
	}

	// Token: 0x060023BB RID: 9147 RVA: 0x000A9988 File Offset: 0x000A7B88
	public static AttackInfo.ElementalType smethod_1(AttackSubType attackSubType_0)
	{
		switch (attackSubType_0)
		{
		case AttackSubType.DamageOverTimeFire:
			return AttackInfo.ElementalType.Fire;
		case AttackSubType.DamageOverTimeShock:
			return AttackInfo.ElementalType.Shock;
		case AttackSubType.DamageOverTimeCorrosive:
			return AttackInfo.ElementalType.Corrosive;
		case AttackSubType.DamageOverTimeFirebird:
			return AttackInfo.ElementalType.Fire;
		default:
			return AttackInfo.ElementalType.None;
		}
	}

	// Token: 0x060023BC RID: 9148 RVA: 0x000187E5 File Offset: 0x000169E5
	public AttackInfo.AttackType method_0()
	{
		return AttackInfo.smethod_0(this.m_subType);
	}

	// Token: 0x04001847 RID: 6215
	public AttackSubType m_subType;

	// Token: 0x04001848 RID: 6216
	public int m_attacker;

	// Token: 0x04001849 RID: 6217
	public int m_owner;

	// Token: 0x0400184A RID: 6218
	public int m_target;

	// Token: 0x0400184B RID: 6219
	public Vector3 m_origin;

	// Token: 0x0400184C RID: 6220
	public Vector3 m_direction;

	// Token: 0x0400184D RID: 6221
	public float m_range;

	// Token: 0x0400184E RID: 6222
	public double m_timeStamp;

	// Token: 0x0400184F RID: 6223
	public int m_damagePoint;

	// Token: 0x0200056B RID: 1387
	public enum AttackType
	{
		// Token: 0x04001851 RID: 6225
		Projectile,
		// Token: 0x04001852 RID: 6226
		Area,
		// Token: 0x04001853 RID: 6227
		Melee,
		// Token: 0x04001854 RID: 6228
		DamageOverTime,
		// Token: 0x04001855 RID: 6229
		Charge,
		// Token: 0x04001856 RID: 6230
		Recover,
		// Token: 0x04001857 RID: 6231
		Skill
	}

	// Token: 0x0200056C RID: 1388
	public enum ElementalType
	{
		// Token: 0x04001859 RID: 6233
		None,
		// Token: 0x0400185A RID: 6234
		Fire,
		// Token: 0x0400185B RID: 6235
		Shock,
		// Token: 0x0400185C RID: 6236
		Corrosive,
		// Token: 0x0400185D RID: 6237
		Explosive,
		// Token: 0x0400185E RID: 6238
		Max
	}
}
