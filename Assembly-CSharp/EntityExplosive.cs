using System;
using System.Collections.Generic;
using BHV;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class EntityExplosive : EntityObject, AreaDamager
{
	// Token: 0x06001B66 RID: 7014 RVA: 0x00089FB0 File Offset: 0x000881B0
	public override void Start()
	{
		base.Start();
		this.m_ability.method_0(new AreaDamage());
		if (this.m_subType == EntityObject.EntitySubType.Grenade)
		{
			object[] array = this.vmethod_7();
			if (array != null && array.Length > 0)
			{
				int num = (int)array[0];
				base.method_15(BadAssNetworkView.smethod_4(num));
			}
		}
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x06001B68 RID: 7016 RVA: 0x0008A004 File Offset: 0x00088204
	public void method_16()
	{
		if (this.m_brokenEntity_prefab != null)
		{
			this.brokenEntity = global::UnityEngine.Object.Instantiate(this.m_brokenEntity_prefab, base.transform.position, this.m_brokenEntity_prefab.rotation) as Transform;
			if (this.brokenEntity != null)
			{
				Rigidbody componentInChildren = this.brokenEntity.GetComponentInChildren<Rigidbody>();
				if (componentInChildren != null)
				{
					componentInChildren.isKinematic = false;
					componentInChildren.transform.position += Vector3.up * 0.5f;
					componentInChildren.velocity = Vector3.up * this.m_ExplosiveForce;
					componentInChildren.angularVelocity = global::UnityEngine.Random.insideUnitSphere * global::UnityEngine.Random.Range(6f, 15f);
				}
			}
		}
	}

	// Token: 0x06001B69 RID: 7017 RVA: 0x00013C22 File Offset: 0x00011E22
	public override bool vmethod_47()
	{
		if (this.m_subType != EntityObject.EntitySubType.ExposiveDestructible_Barrel)
		{
			if (this.m_subType != EntityObject.EntitySubType.NPC_Grenade)
			{
				return base.vmethod_47();
			}
		}
		return true;
	}

	// Token: 0x06001B6A RID: 7018 RVA: 0x0008A0D4 File Offset: 0x000882D4
	public override bool vmethod_53()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager == null)
		{
			return true;
		}
		BHVTask bhvtask = bhvtaskManager.method_12();
		return bhvtask == null || bhvtask.m_Type == BHVTaskType.Dead;
	}

	// Token: 0x06001B6B RID: 7019 RVA: 0x0008A108 File Offset: 0x00088308
	public override void vmethod_55(Dictionary<int, BHVTask> dictionary_0)
	{
		if (dictionary_0 == null)
		{
			return;
		}
		if (this.m_subType == EntityObject.EntitySubType.Grenade)
		{
			dictionary_0.Add(37, new BHVTaskCountDown());
			dictionary_0.Add(38, new BHVTaskBlowUp());
		}
		else if (this.m_subType == EntityObject.EntitySubType.ExposiveDestructible_Barrel)
		{
			dictionary_0.Add(35, new BHVTaskDefault());
			dictionary_0.Add(38, new BHVTaskBlowUp());
			dictionary_0.Add(51, new BHVTaskDisabled());
		}
	}

	// Token: 0x040011F7 RID: 4599
	public Transform m_brokenEntity_prefab;

	// Token: 0x040011F8 RID: 4600
	public float m_ExplosiveForce = 300f;

	// Token: 0x040011F9 RID: 4601
	public float m_colliderRadius;

	// Token: 0x040011FA RID: 4602
	protected Transform brokenEntity;
}
