using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000570 RID: 1392
public class BulletResolver : Arbitrator.ArbitratorClient, IAttackResolver
{
	// Token: 0x060023C2 RID: 9154 RVA: 0x000A9B04 File Offset: 0x000A7D04
	public void OnArbitrated(Arbitrator.ArbitrableData data)
	{
		HitInfo hitInfo = data as HitInfo;
		this.m_damageManager.method_6(hitInfo, true);
	}

	// Token: 0x060023C3 RID: 9155 RVA: 0x000A9B28 File Offset: 0x000A7D28
	public void imethod_0(AttackInfo attackInfo_0)
	{
		if (this.m_damageManager == null)
		{
			this.m_damageManager = DamageManager.DamageManager_0;
		}
		Entity entity = BadAssNetworkView.smethod_4(attackInfo_0.m_owner);
		Entity entity2 = BadAssNetworkView.smethod_4(attackInfo_0.m_attacker);
		if (this.m_damageManager != null)
		{
			AIServiceUtility.AIServiceUtility_0.method_2(attackInfo_0);
			Collider collider = null;
			float maxValue = float.MaxValue;
			Entity entity3 = TargetingService.smethod_1(attackInfo_0.m_origin, attackInfo_0.m_direction, entity, out collider, ref maxValue, ColliderType.WeakPoint, false);
			if (entity3 != null)
			{
				if (!entity3.m_bCanReceiveShootDamage)
				{
					return;
				}
				EntityWeapon entityWeapon = entity2 as EntityWeapon;
				float num = (float)attackInfo_0.m_damagePoint;
				if (entityWeapon != null)
				{
					float num2 = entityWeapon.method_68();
					float num3 = entityWeapon.method_69();
					if (maxValue > num2 && maxValue <= num3)
					{
						num = ((float)attackInfo_0.m_damagePoint * (entityWeapon.method_69() - maxValue) + (float)attackInfo_0.m_damagePoint * entityWeapon.method_70() * (maxValue - entityWeapon.method_68())) / (entityWeapon.method_69() - entityWeapon.method_68());
					}
					else if (maxValue > num3)
					{
						num *= entityWeapon.method_70();
					}
				}
				EntityNpc entityNpc = entity3 as EntityNpc;
				if (entityNpc != null && entityNpc.method_17())
				{
					EntityPlayer entityPlayer = entity as EntityPlayer;
					if (entityPlayer != null)
					{
						float num4 = entityPlayer.PlayerEffectManager_0.method_0(EffectType.BadassDamageBonus);
						if (num4 > 0f)
						{
							num *= 1f + num4;
						}
					}
				}
				HitInfo hitInfo = new HitInfo();
				hitInfo.m_from = attackInfo_0.m_attacker;
				hitInfo.m_owner = attackInfo_0.m_owner;
				hitInfo.m_to = entity3.vmethod_0();
				hitInfo.m_timeStamp = attackInfo_0.m_timeStamp;
				hitInfo.m_distance = maxValue;
				hitInfo.m_rayOrigin = attackInfo_0.m_origin;
				hitInfo.m_rayDirection = attackInfo_0.m_direction * DamageForceFactor.smethod_0(attackInfo_0, maxValue);
				hitInfo.m_damagePoint = (int)num;
				hitInfo.m_attackSubType = attackInfo_0.m_subType;
				hitInfo.m_elementalType = entity2.vmethod_1();
				WeakPoint component = collider.gameObject.GetComponent<WeakPoint>();
				if (component)
				{
					hitInfo.m_weakPointIndex = entity3.vmethod_21().method_11(component);
				}
				MonoSingleton<Arbitrator>.Instance.method_0(this, hitInfo);
			}
		}
	}

	// Token: 0x04001876 RID: 6262
	private DamageManager m_damageManager;
}
