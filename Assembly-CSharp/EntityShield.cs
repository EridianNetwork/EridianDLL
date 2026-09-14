using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000471 RID: 1137
public class EntityShield : EntityObject
{
	// Token: 0x17000191 RID: 401
	// (get) Token: 0x06001D4C RID: 7500 RVA: 0x00014B85 File Offset: 0x00012D85
	// (set) Token: 0x06001D4D RID: 7501 RVA: 0x00014B8D File Offset: 0x00012D8D
	public ShieldAttribute m_attribute { get; private set; }

	// Token: 0x06001D4E RID: 7502 RVA: 0x00013BC1 File Offset: 0x00011DC1
	protected override void Awake()
	{
		base.Awake();
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x00090ABC File Offset: 0x0008ECBC
	public override void Start()
	{
		base.Start();
		if (this.m_dna == null)
		{
			ItemDNA itemDNA = this.vmethod_7()[0] as ItemDNA;
			if (itemDNA != null && itemDNA.method_7() != null && itemDNA.method_7().m_attribute != null)
			{
				this.m_dna = itemDNA.method_7();
			}
		}
	}

	// Token: 0x06001D50 RID: 7504 RVA: 0x00090B0C File Offset: 0x0008ED0C
	public void method_16(ShieldDNA shieldDNA_0, Entity entity_0, int int_0, float float_0, float float_1)
	{
		this.m_dna = shieldDNA_0;
		this.m_attribute = this.m_dna.m_attribute;
		this.m_maxShieldPoints = int_0;
		this.m_regenerationCooldown = float_0;
		this.m_regenerationRate = float_1;
		SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		int num = (int)this.m_dna.m_attribute.method_0(ShieldAttributeType.Material);
		if (num > 0 && componentInChildren != null && num < componentInChildren.materials.Length)
		{
			componentInChildren.material = componentInChildren.materials[num];
		}
		if (entity_0 as EntityPlayer != null)
		{
			this.m_shieldPoints.method_1(0, this.m_maxShieldPoints);
		}
	}

	// Token: 0x06001D51 RID: 7505 RVA: 0x00014B96 File Offset: 0x00012D96
	public void method_17(int int_0, float float_0, float float_1)
	{
		this.m_maxShieldPoints = int_0;
		this.m_regenerationCooldown = float_0;
		this.m_regenerationRate = float_1;
		this.m_shieldPoints.method_0(this.m_maxShieldPoints);
	}

	// Token: 0x06001D52 RID: 7506 RVA: 0x00090BB0 File Offset: 0x0008EDB0
	public void method_18(ShieldDNA shieldDNA_0, Entity entity_0)
	{
		this.m_dna = shieldDNA_0;
		this.m_attribute = this.m_dna.m_attribute;
		this.m_maxShieldPoints = (int)this.m_attribute.method_0(ShieldAttributeType.Capacity);
		this.m_regenerationCooldown = this.m_attribute.method_0(ShieldAttributeType.RechargeDelay);
		this.m_regenerationRate = (float)this.m_maxShieldPoints * this.m_attribute.method_0(ShieldAttributeType.RechargeRate);
		if (entity_0 as EntityPlayer != null && this.m_dna != null)
		{
			float num = this.m_attribute.method_0(ShieldAttributeType.Capacity) / ShieldAttributeConfig.s_maxShieldPoint;
			int num2 = MonoSingleton<LevelingManager>.Instance.method_5(AvatarType.SIREN, (this.m_dna.m_level <= 0) ? 1 : this.m_dna.m_level);
			this.m_maxShieldPoints = Mathf.FloorToInt(num * (float)num2);
			this.m_regenerationRate = (float)this.m_maxShieldPoints * this.m_attribute.method_0(ShieldAttributeType.RechargeRate);
		}
		SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		int num3 = (int)this.m_dna.m_attribute.method_0(ShieldAttributeType.Material);
		if (num3 > 0 && componentInChildren != null && num3 < componentInChildren.materials.Length)
		{
			componentInChildren.material = componentInChildren.materials[num3];
		}
		if (entity_0 as EntityPlayer != null)
		{
			this.m_shieldPoints.method_1(0, this.m_maxShieldPoints);
		}
	}

	// Token: 0x06001D53 RID: 7507 RVA: 0x00014BBE File Offset: 0x00012DBE
	public ShieldDNA method_19()
	{
		return this.m_dna;
	}

	// Token: 0x06001D54 RID: 7508 RVA: 0x00013BEB File Offset: 0x00011DEB
	public override void vmethod_63(Entity entity_0)
	{
		base.method_15(entity_0);
	}

	// Token: 0x06001D55 RID: 7509 RVA: 0x00014BC6 File Offset: 0x00012DC6
	public override void vmethod_64()
	{
		base.method_15(null);
	}

	// Token: 0x06001D56 RID: 7510 RVA: 0x00090CF4 File Offset: 0x0008EEF4
	public int method_20(int int_0)
	{
		return Mathf.Min(this.m_shieldPoints.method_5(), int_0);
	}

	// Token: 0x06001D57 RID: 7511 RVA: 0x00090D18 File Offset: 0x0008EF18
	public int method_21(int int_0)
	{
		int num = Mathf.Min(this.m_shieldPoints.method_5(), int_0);
		this.m_shieldPoints.method_8(this.m_shieldPoints.method_5() - num);
		return num;
	}

	// Token: 0x06001D58 RID: 7512 RVA: 0x00014BCF File Offset: 0x00012DCF
	public void method_22(int int_0)
	{
		this.m_shieldPoints.method_3(int_0);
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_23()
	{
	}

	// Token: 0x06001D5A RID: 7514 RVA: 0x00090D54 File Offset: 0x0008EF54
	[RPC]
	public void RPC_ShieldPowUp()
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer)
		{
			BaseEventTriggerCtl component = entityPlayer.GetComponent<BaseEventTriggerCtl>();
			if (component != null)
			{
				component.vmethod_1(AudioEventName.Chr_Shr_Shield_Power_Up);
			}
		}
	}

	// Token: 0x06001D5B RID: 7515 RVA: 0x00090D90 File Offset: 0x0008EF90
	public void method_24()
	{
		int num = this.m_shieldPoints.method_4() - this.m_shieldPoints.method_5();
		if (num <= 0)
		{
			return;
		}
		this.m_regenerator.m_attackSubType = AttackSubType.Recover;
		this.m_regenerator.m_from = base.m_owner.vmethod_0();
		this.m_regenerator.m_shieldDamagePoints = num;
		DamageManager.DamageManager_0.method_10(this.m_regenerator.m_from, this.m_regenerator);
		this.m_shieldPoints.method_2();
	}

	// Token: 0x06001D5C RID: 7516 RVA: 0x00090E10 File Offset: 0x0008F010
	public void method_25(float float_0)
	{
		if (float_0 <= 0f)
		{
			return;
		}
		float num = (float)this.m_shieldPoints.method_4() * float_0;
		this.m_regenerator.m_attackSubType = AttackSubType.Recover;
		this.m_regenerator.m_from = base.m_owner.vmethod_0();
		this.m_regenerator.m_shieldDamagePoints = (int)num;
		DamageManager.DamageManager_0.method_10(this.m_regenerator.m_from, this.m_regenerator);
	}

	// Token: 0x06001D5D RID: 7517 RVA: 0x00090E80 File Offset: 0x0008F080
	private float method_26()
	{
		float num = this.m_regenerationRate;
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != null)
		{
			num *= entityPlayer.PlayerEffectManager_0.method_0(EffectType.ShieldRechargeRate);
			num *= entityPlayer.method_72();
		}
		return num;
	}

	// Token: 0x06001D5E RID: 7518 RVA: 0x00090EC4 File Offset: 0x0008F0C4
	private float method_27(EntityPlayer entityPlayer_0)
	{
		float num = this.m_regenerationCooldown;
		if (entityPlayer_0 == null)
		{
			return num;
		}
		float num2 = entityPlayer_0.PlayerEffectManager_0.method_0(EffectType.ShieldRechargeDelay);
		if (Mathf.Abs(num2) > 0f)
		{
			num += num2;
		}
		return num;
	}

	// Token: 0x0400133F RID: 4927
	public int m_maxShieldPoints = 100;

	// Token: 0x04001340 RID: 4928
	public float m_regenerationCooldown = 15f;

	// Token: 0x04001341 RID: 4929
	public float m_regenerationRate = 3f;

	// Token: 0x04001342 RID: 4930
	public Utils.PouchNetwork m_shieldPoints = new Utils.PouchNetwork();

	// Token: 0x04001343 RID: 4931
	private DamageInfo m_regenerator = default(DamageInfo);

	// Token: 0x04001344 RID: 4932
	private ShieldDNA m_dna;
}
