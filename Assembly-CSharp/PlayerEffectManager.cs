using System;
using ns0;
using XsdSettings;

// Token: 0x020004B7 RID: 1207
public class PlayerEffectManager
{
	// Token: 0x06002090 RID: 8336 RVA: 0x00016A08 File Offset: 0x00014C08
	public PlayerEffectManager(EntityPlayer entityPlayer_0)
	{
		this.m_owner = entityPlayer_0;
	}

	// Token: 0x06002091 RID: 8337 RVA: 0x0009F3A0 File Offset: 0x0009D5A0
	public float method_0(EffectType effectType_0)
	{
		AffectType affectType = this.m_owner.SkillTreeStatus_0.method_3(effectType_0);
		float num = this.m_owner.SkillTreeStatus_0.method_4(effectType_0);
		float num2 = this.m_owner.method_13(effectType_0, affectType);
		float num3 = this.m_owner.method_15(effectType_0, affectType);
		float num4 = this.m_owner.method_17(effectType_0, affectType);
		float num5 = this.m_owner.method_16(effectType_0, affectType);
		float num6 = num + num2 + num3 + num4 + num5;
		if (affectType == AffectType.Scale)
		{
			num6 -= 4f;
		}
		return num6;
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x0009F428 File Offset: 0x0009D628
	public float method_1(EffectType effectType_0, float float_0, Entity entity_0)
	{
		float num = 0f;
		AffectType affectType = this.m_owner.SkillTreeStatus_0.method_3(effectType_0);
		float num2 = this.m_owner.method_13(effectType_0, affectType);
		num += num2;
		float num3 = this.m_owner.method_15(effectType_0, affectType);
		num += num3;
		float num4 = this.m_owner.method_16(effectType_0, affectType);
		num += num4;
		float num5 = 1f;
		EntityNpc entityNpc = entity_0 as EntityNpc;
		if (!(entityNpc != null))
		{
			EntityPlayer entityPlayer = entity_0 as EntityPlayer;
			if (entityPlayer != null)
			{
				num5 = MonoSingleton<LevelingManager>.Instance.method_6(entityPlayer.vmethod_3());
			}
		}
		float num6;
		if (MonoSingleton<Session>.Instance.method_12())
		{
			num *= this.m_owner.method_72();
			num6 = num / (num + float_0 * MonoSingleton<LevelingManager>.Instance.method_7());
		}
		else
		{
			num6 = num / (num + float_0 * num5);
		}
		return num6;
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x0009F504 File Offset: 0x0009D704
	public float method_2(EffectType effectType_0)
	{
		float num = 0f;
		AffectType affectType = this.m_owner.SkillTreeStatus_0.method_3(effectType_0);
		float num2 = this.m_owner.method_13(effectType_0, affectType);
		num += num2;
		if (this.m_owner.method_27() != null)
		{
			float num3 = this.m_owner.method_15(effectType_0, affectType);
			num += num3;
		}
		float num4 = this.m_owner.method_16(effectType_0, affectType);
		return num + num4;
	}

	// Token: 0x06002094 RID: 8340 RVA: 0x0000311B File Offset: 0x0000131B
	public static void smethod_0(EffectType effectType_0, string string_0, float float_0)
	{
	}

	// Token: 0x04001520 RID: 5408
	private EntityPlayer m_owner;
}
