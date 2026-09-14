using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class EntityProjectile : Entity, IDestructibleObj
{
	// Token: 0x06001D43 RID: 7491 RVA: 0x00014B55 File Offset: 0x00012D55
	public override Entity.EntityType vmethod_8()
	{
		return Entity.EntityType.Projectile;
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_20()
	{
		return true;
	}

	// Token: 0x06001D45 RID: 7493 RVA: 0x00014B58 File Offset: 0x00012D58
	public override int vmethod_9()
	{
		return 253;
	}

	// Token: 0x06001D46 RID: 7494 RVA: 0x00014B5F File Offset: 0x00012D5F
	public override CollisionManager vmethod_21()
	{
		return this.m_collisionManager;
	}

	// Token: 0x06001D47 RID: 7495 RVA: 0x00090A10 File Offset: 0x0008EC10
	public override void Start()
	{
		base.Start();
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_1(base.GetComponent<Entity>());
		}
		this.m_collisionManager = base.GetComponent<CollisionManager>();
		if (this.m_collisionManager != null)
		{
			this.m_collisionManager.method_0(false);
		}
		AIServiceUtility.AIServiceUtility_0.method_0(this);
	}

	// Token: 0x06001D48 RID: 7496 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool imethod_0(AttackInfo attackInfo_0)
	{
		return false;
	}

	// Token: 0x06001D49 RID: 7497 RVA: 0x00014B67 File Offset: 0x00012D67
	public virtual void imethod_1()
	{
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_2(base.GetComponent<Entity>());
		}
	}

	// Token: 0x06001D4A RID: 7498 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_2(int int_0)
	{
	}

	// Token: 0x0400133D RID: 4925
	[HideInInspector]
	public int m_index;

	// Token: 0x0400133E RID: 4926
	private CollisionManager m_collisionManager;
}
