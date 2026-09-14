using System;
using System.Collections.Generic;
using BHV_Skill;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200053A RID: 1338
public class DamageBloodWing : MonoBehaviour
{
	// Token: 0x0600228B RID: 8843 RVA: 0x00017BD0 File Offset: 0x00015DD0
	private void Awake()
	{
		this.m_moveComp = base.GetComponent<MoveBloodWing>();
	}

	// Token: 0x0600228C RID: 8844 RVA: 0x000A3E44 File Offset: 0x000A2044
	private void Update()
	{
		if (this.m_playerOwner == null)
		{
			this.m_playerOwner = this.m_moveComp.method_14();
			this.m_settings = this.m_playerOwner.PlayerSkillManage_0.method_1<BHVSkillSettingsFireBird>();
		}
		if (this.m_playerOwner == null)
		{
			return;
		}
		MoveBloodWing.TargetType targetType = this.m_moveComp.method_16();
		if (targetType == MoveBloodWing.TargetType.FlyingAway)
		{
			this.method_1();
		}
		if (targetType == MoveBloodWing.TargetType.HurtZone)
		{
			this.method_0();
		}
	}

	// Token: 0x0600228D RID: 8845 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_0()
	{
	}

	// Token: 0x0600228E RID: 8846 RVA: 0x000A3EB4 File Offset: 0x000A20B4
	private void method_1()
	{
		if (!this.m_bTouchedEnemy)
		{
			this.method_2(this.method_8());
			if (this.m_InRangeEnemyList.Count > 0)
			{
				this.m_bTouchedEnemy = true;
				FirebirdManage.smethod_2("[Touch Enemy]");
				this.m_moveComp.method_29();
			}
		}
	}

	// Token: 0x0600228F RID: 8847 RVA: 0x000A3F00 File Offset: 0x000A2100
	public List<Entity> method_2(float float_0)
	{
		this.m_InRangeEnemyList.Clear();
		foreach (Entity entity in DamageManager.DamageManager_0.method_0())
		{
			if (this.method_3(entity, base.transform.position, float_0))
			{
				this.m_InRangeEnemyList.Add(entity);
			}
		}
		return this.m_InRangeEnemyList;
	}

	// Token: 0x06002290 RID: 8848 RVA: 0x000A3F84 File Offset: 0x000A2184
	public bool method_3(Entity entity_0, Vector3 vector3_0, float float_0)
	{
		if (entity_0 == null)
		{
			return false;
		}
		if (entity_0.vmethod_19() == null)
		{
			return false;
		}
		if (entity_0.vmethod_19().vmethod_4() <= 0)
		{
			return false;
		}
		if (this.method_5(entity_0))
		{
			return false;
		}
		if (this.method_4(entity_0, vector3_0))
		{
			return true;
		}
		float num = Vector3.Distance(vector3_0, entity_0.transform.position);
		if (num > float_0)
		{
			if (entity_0.m_entityHeight > 3f)
			{
				Vector3 vector = entity_0.transform.position + Vector3.up * entity_0.m_entityHeight * 0.5f;
				num = Vector3.Distance(vector, base.transform.position);
				if (num <= float_0)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x06002291 RID: 8849 RVA: 0x000A403C File Offset: 0x000A223C
	private bool method_4(Entity entity_0, Vector3 vector3_0)
	{
		EntityNpc entityNpc = entity_0 as EntityNpc;
		if (entityNpc == null)
		{
			return false;
		}
		if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_ArchAngel)
		{
			float num = Vector3.Distance(vector3_0, entity_0.transform.position);
			float num2 = Vector3.Distance(this.m_playerOwner.transform.position, entity_0.transform.position);
			float num3 = 3f + (num2 - 10f);
			num3 = Mathf.Clamp(num3, 3f, 20f);
			if (num < num3)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002292 RID: 8850 RVA: 0x000A40C0 File Offset: 0x000A22C0
	private bool method_5(Entity entity_0)
	{
		return this.m_playerOwner == null || this.m_playerOwner == entity_0 || (entity_0.vmethod_9() == this.m_playerOwner.vmethod_9() && !this.m_playerOwner.vmethod_47());
	}

	// Token: 0x06002293 RID: 8851 RVA: 0x000A4110 File Offset: 0x000A2310
	public float method_6()
	{
		return this.m_settings.m_explosionRadius * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.FirebirdExplosionDamage);
	}

	// Token: 0x06002294 RID: 8852 RVA: 0x000A413C File Offset: 0x000A233C
	private int method_7()
	{
		float num = MonoSingleton<LevelingManager>.Instance.method_6(this.m_playerOwner.vmethod_3());
		float num2 = this.m_settings.m_explosionDamage * num * this.m_playerOwner.method_72();
		float num3 = num2 * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.FirebirdExplosionDamage);
		return (int)num3;
	}

	// Token: 0x06002295 RID: 8853 RVA: 0x000A4190 File Offset: 0x000A2390
	public float method_8()
	{
		if (this.m_settings == null)
		{
			return 0f;
		}
		float num = this.m_settings.m_fireRadius * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.FirebirdRadius);
		return (float)((int)num);
	}

	// Token: 0x040016E9 RID: 5865
	private MoveBloodWing m_moveComp;

	// Token: 0x040016EA RID: 5866
	private List<Entity> m_InRangeEnemyList = new List<Entity>();

	// Token: 0x040016EB RID: 5867
	private BHVSkillSettingsFireBird m_settings;

	// Token: 0x040016EC RID: 5868
	private EntityPlayer m_playerOwner;

	// Token: 0x040016ED RID: 5869
	private bool m_bTouchedEnemy;
}
