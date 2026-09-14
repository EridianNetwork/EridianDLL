using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200057E RID: 1406
public class StateDamageManager : MonoSingleton<StateDamageManager>
{
	// Token: 0x06002420 RID: 9248 RVA: 0x000AC2D8 File Offset: 0x000AA4D8
	public void method_0(HitInfo hitInfo_0, float float_0, float float_1)
	{
		if (this.method_4(hitInfo_0))
		{
			return;
		}
		DamageEmitter damageEmitter = default(DamageEmitter);
		damageEmitter.m_startDate = Time.time;
		damageEmitter.m_owner = hitInfo_0.m_owner;
		damageEmitter.m_receiver = hitInfo_0.m_to;
		damageEmitter.m_weakpointIndex = hitInfo_0.m_weakPointIndex;
		damageEmitter.m_elementalType = hitInfo_0.m_elementalType;
		damageEmitter.m_attackSubType = StateDamageManager.smethod_1(hitInfo_0);
		damageEmitter.m_damagePerSecond = float_0;
		damageEmitter.m_duration = float_1;
		damageEmitter.m_frequency = 2f;
		this.m_damageEmiters.Add(damageEmitter);
	}

	// Token: 0x06002421 RID: 9249 RVA: 0x000AC36C File Offset: 0x000AA56C
	private void Update()
	{
		if (MonoSingleton<Session>.Instance.method_18())
		{
			return;
		}
		if (this.m_damageManager == null)
		{
			this.m_damageManager = DamageManager.DamageManager_0;
		}
		this.m_toDelete.Clear();
		float time = Time.time;
		for (int i = 0; i < this.m_damageEmiters.Count; i++)
		{
			if (this.m_damageEmiters[i].m_startDate + this.m_damageEmiters[i].m_duration < time)
			{
				this.m_toDelete.Add(this.m_damageEmiters[i]);
			}
			else
			{
				DamageEmitter damageEmitter = this.m_damageEmiters[i];
				float num = time - damageEmitter.m_startDate;
				if ((int)(num * damageEmitter.m_frequency) > damageEmitter.m_damageApplicationCounter)
				{
					this.method_1(ref damageEmitter);
					this.m_damageEmiters[i] = damageEmitter;
				}
			}
		}
		for (int j = 0; j < this.m_toDelete.Count; j++)
		{
			this.m_damageEmiters.Remove(this.m_toDelete[j]);
		}
	}

	// Token: 0x06002422 RID: 9250 RVA: 0x000AC488 File Offset: 0x000AA688
	public static AttackSubType smethod_0(AttackInfo.ElementalType elementalType_0)
	{
		AttackSubType attackSubType = AttackSubType.DamageOverTimeGeneric;
		switch (elementalType_0)
		{
		case AttackInfo.ElementalType.Fire:
			attackSubType = AttackSubType.DamageOverTimeFire;
			break;
		case AttackInfo.ElementalType.Shock:
			attackSubType = AttackSubType.DamageOverTimeShock;
			break;
		case AttackInfo.ElementalType.Corrosive:
			attackSubType = AttackSubType.DamageOverTimeCorrosive;
			break;
		}
		return attackSubType;
	}

	// Token: 0x06002423 RID: 9251 RVA: 0x00018AF4 File Offset: 0x00016CF4
	public static AttackSubType smethod_1(HitInfo hitInfo_0)
	{
		if (hitInfo_0.m_attackSubType == AttackSubType.DamageOverTimeFirebird)
		{
			return hitInfo_0.m_attackSubType;
		}
		return StateDamageManager.smethod_0(hitInfo_0.m_elementalType);
	}

	// Token: 0x06002424 RID: 9252 RVA: 0x000AC4C0 File Offset: 0x000AA6C0
	private void method_1(ref DamageEmitter damageEmitter_0)
	{
		Entity entity = BadAssNetworkView.smethod_4(damageEmitter_0.m_receiver);
		Entity entity2 = BadAssNetworkView.smethod_4(damageEmitter_0.m_owner);
		if (entity == null || entity2 == null)
		{
			return;
		}
		float num = 0f;
		EffectType effectType = DamageSystem.smethod_1(damageEmitter_0.m_elementalType);
		if (effectType != EffectType.Invalid)
		{
			num = DamageSystem.smethod_0(entity2, entity, effectType);
		}
		if (num > global::UnityEngine.Random.Range(0f, 1f))
		{
			return;
		}
		HitInfo hitInfo = new HitInfo();
		hitInfo.m_from = damageEmitter_0.m_owner;
		hitInfo.m_owner = hitInfo.m_from;
		hitInfo.m_to = damageEmitter_0.m_receiver;
		hitInfo.m_timeStamp = (double)Time.time;
		hitInfo.m_damagePoint = (int)(damageEmitter_0.m_damagePerSecond / damageEmitter_0.m_frequency);
		hitInfo.m_attackSubType = damageEmitter_0.m_attackSubType;
		hitInfo.m_elementalType = damageEmitter_0.m_elementalType;
		hitInfo.m_weakPointIndex = damageEmitter_0.m_weakpointIndex;
		this.m_damageManager.method_6(hitInfo, false);
		damageEmitter_0.m_damageApplicationCounter++;
	}

	// Token: 0x06002425 RID: 9253 RVA: 0x000AC5C4 File Offset: 0x000AA7C4
	public void method_2(Entity entity_0)
	{
		for (int i = this.m_damageEmiters.Count - 1; i > 0; i--)
		{
			Entity entity = BadAssNetworkView.smethod_4(this.m_damageEmiters[i].m_receiver);
			if (entity_0 == entity)
			{
				this.m_damageEmiters.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x06002426 RID: 9254 RVA: 0x000AC61C File Offset: 0x000AA81C
	public bool method_3(Entity entity_0, ref AttackInfo.ElementalType elementalType_0)
	{
		for (int i = 0; i < this.m_damageEmiters.Count; i++)
		{
			DamageEmitter damageEmitter = this.m_damageEmiters[i];
			Entity entity = BadAssNetworkView.smethod_4(damageEmitter.m_receiver);
			if (entity_0 == entity)
			{
				elementalType_0 = damageEmitter.m_elementalType;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002427 RID: 9255 RVA: 0x000AC670 File Offset: 0x000AA870
	private bool method_4(HitInfo hitInfo_0)
	{
		for (int i = 0; i < this.m_damageEmiters.Count; i++)
		{
			DamageEmitter damageEmitter = this.m_damageEmiters[i];
			if (damageEmitter.m_owner == hitInfo_0.m_owner && damageEmitter.m_receiver == hitInfo_0.m_to)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040018CA RID: 6346
	private DamageManager m_damageManager;

	// Token: 0x040018CB RID: 6347
	private List<DamageEmitter> m_damageEmiters = new List<DamageEmitter>();

	// Token: 0x040018CC RID: 6348
	private List<DamageEmitter> m_toDelete = new List<DamageEmitter>();
}
