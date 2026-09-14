using System;
using System.Collections.Generic;
using BHV;
using UnityEngine;

// Token: 0x0200045A RID: 1114
public class EntityObject : Entity
{
	// Token: 0x1700016C RID: 364
	// (get) Token: 0x06001BC5 RID: 7109 RVA: 0x00013F5B File Offset: 0x0001215B
	// (set) Token: 0x06001BC6 RID: 7110 RVA: 0x00013F63 File Offset: 0x00012163
	public Entity m_owner { get; private set; }

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06001BC7 RID: 7111 RVA: 0x00013F6C File Offset: 0x0001216C
	// (set) Token: 0x06001BC8 RID: 7112 RVA: 0x00013F74 File Offset: 0x00012174
	public Pickable m_pickable { get; private set; }

	// Token: 0x06001BC9 RID: 7113 RVA: 0x0008B06C File Offset: 0x0008926C
	public override void Start()
	{
		base.Start();
		this.m_pickable = base.GetComponent<Pickable>();
		this.m_rigidBody = base.GetComponent<Rigidbody>();
		this.m_equipment = base.GetComponent<EquipmentInventoryEntity>();
		this.m_collisionManager = base.GetComponent<CollisionManager>();
		if (this.m_collisionManager != null)
		{
			this.m_collisionManager.method_0(false);
		}
	}

	// Token: 0x06001BCA RID: 7114 RVA: 0x0008B0CC File Offset: 0x000892CC
	public Rigidbody method_10()
	{
		if (this.method_11())
		{
			this.method_12(true);
			if (this.m_rigidBody == null)
			{
				this.m_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			}
			if (this.m_rigidBody)
			{
				this.m_rigidBody.useGravity = true;
				this.m_rigidBody.drag = 1f;
				this.m_rigidBody.mass = 1f;
				this.m_rigidBody.sleepVelocity = 10f;
				this.m_rigidBody.sleepAngularVelocity = 10f;
				if (this.m_subType == EntityObject.EntitySubType.HealthPack || this.m_subType == EntityObject.EntitySubType.MoneyPack)
				{
					this.m_rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
					this.m_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
				}
			}
		}
		return this.m_rigidBody;
	}

	// Token: 0x06001BCB RID: 7115 RVA: 0x00013F7D File Offset: 0x0001217D
	public override CollisionManager vmethod_21()
	{
		return this.m_collisionManager;
	}

	// Token: 0x06001BCC RID: 7116 RVA: 0x00013F85 File Offset: 0x00012185
	public bool method_11()
	{
		return base.collider != null || (this.m_collisionManager != null && this.m_collisionManager.method_6());
	}

	// Token: 0x06001BCD RID: 7117 RVA: 0x0008B194 File Offset: 0x00089394
	public void method_12(bool bool_0)
	{
		if (base.collider != null)
		{
			base.collider.enabled = bool_0;
		}
		else if (this.m_collisionManager != null && this.m_collisionManager.method_6())
		{
			this.m_collisionManager.method_9(bool_0);
		}
	}

	// Token: 0x06001BCE RID: 7118 RVA: 0x00013FB4 File Offset: 0x000121B4
	public override EquipmentInventoryEntity vmethod_19()
	{
		return this.m_equipment;
	}

	// Token: 0x06001BCF RID: 7119 RVA: 0x00013FBC File Offset: 0x000121BC
	public override Entity.EntityType vmethod_8()
	{
		return Entity.EntityType.Object;
	}

	// Token: 0x06001BD0 RID: 7120 RVA: 0x000039EC File Offset: 0x00001BEC
	public virtual bool vmethod_62()
	{
		return true;
	}

	// Token: 0x06001BD1 RID: 7121 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_63(Entity entity_0)
	{
	}

	// Token: 0x06001BD2 RID: 7122 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_64()
	{
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00013FBF File Offset: 0x000121BF
	public ItemDNA method_13()
	{
		if (this.m_pickable)
		{
			return this.m_pickable.method_0();
		}
		return null;
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x00013FDB File Offset: 0x000121DB
	public virtual void vmethod_65()
	{
		if (this.m_pickable)
		{
			this.m_pickable.OnPick();
		}
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x0008B1E4 File Offset: 0x000893E4
	public virtual void vmethod_66(Vector3 vector3_0, Quaternion quaternion_0, Vector3 vector3_1)
	{
		Rigidbody rigidbody = this.method_10();
		base.transform.position = vector3_0;
		base.transform.rotation = quaternion_0;
		if (rigidbody != null)
		{
			// A genuine drop (server sends zero launch velocity, e.g. chest loot) should just settle under
			// gravity, not get kicked with a random impulse torque on top of whatever spawn-overlap
			// depenetration push physics already applies. Only NPC/enemy-thrown drops carry real velocity.
			if (vector3_1 != Vector3.zero)
			{
				rigidbody.AddForce(vector3_1 / 2f, ForceMode.VelocityChange);
				rigidbody.AddTorque(global::UnityEngine.Random.insideUnitSphere, ForceMode.Impulse);
			}
		}
		if (this.m_pickable)
		{
			this.m_pickable.OnDrop();
		}
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x00013FF5 File Offset: 0x000121F5
	public virtual bool vmethod_67()
	{
		return this.m_pickable != null && this.m_pickable.method_5();
	}

	// Token: 0x06001BD7 RID: 7127 RVA: 0x00014013 File Offset: 0x00012213
	public bool method_14()
	{
		return this.vmethod_67() && this.m_pickable.m_autoPickup;
	}

	// Token: 0x06001BD8 RID: 7128 RVA: 0x0001402B File Offset: 0x0001222B
	public void method_15(Entity entity_0)
	{
		this.m_owner = entity_0;
		if (this.m_pickable != null)
		{
			this.m_pickable.OnOwnerChanged();
		}
	}

	// Token: 0x06001BD9 RID: 7129 RVA: 0x0001404D File Offset: 0x0001224D
	public static string[] smethod_0()
	{
		return Enum.GetNames(typeof(EntityObject.EntitySubType));
	}

	// Token: 0x06001BDA RID: 7130 RVA: 0x0001405E File Offset: 0x0001225E
	public override int vmethod_9()
	{
		return 254;
	}

	// Token: 0x06001BDB RID: 7131 RVA: 0x00014065 File Offset: 0x00012265
	public override void vmethod_55(Dictionary<int, BHVTask> dictionary_0)
	{
		if (dictionary_0 == null)
		{
			return;
		}
		if (this.m_subType == EntityObject.EntitySubType.Claptrap)
		{
			dictionary_0.Add(1, new BHVTaskIdle());
			dictionary_0.Add(107, new BHVTaskAttachBomb());
			dictionary_0.Add(106, new BHVTaskDropBomb());
		}
	}

	// Token: 0x04001275 RID: 4725
	public EntityObject.EntitySubType m_subType;

	// Token: 0x04001276 RID: 4726
	protected Rigidbody m_rigidBody;

	// Token: 0x04001277 RID: 4727
	protected CollisionManager m_collisionManager;

	// Token: 0x04001278 RID: 4728
	protected EquipmentInventoryEntity m_equipment;

	// Token: 0x0200045B RID: 1115
	public enum EntitySubType
	{
		// Token: 0x0400127C RID: 4732
		None,
		// Token: 0x0400127D RID: 4733
		Weapon,
		// Token: 0x0400127E RID: 4734
		AmmoPack,
		// Token: 0x0400127F RID: 4735
		HealthPack,
		// Token: 0x04001280 RID: 4736
		MoneyPack,
		// Token: 0x04001281 RID: 4737
		Grenade,
		// Token: 0x04001282 RID: 4738
		Shield,
		// Token: 0x04001283 RID: 4739
		ExposiveDestructible_Barrel,
		// Token: 0x04001284 RID: 4740
		NPC_Grenade,
		// Token: 0x04001285 RID: 4741
		NPC_Armor,
		// Token: 0x04001286 RID: 4742
		Material,
		// Token: 0x04001287 RID: 4743
		DestoryableObj,
		// Token: 0x04001288 RID: 4744
		ClassMode,
		// Token: 0x04001289 RID: 4745
		Claptrap
	}
}
