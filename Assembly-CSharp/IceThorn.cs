using System;
using ns0;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class IceThorn : EntityProjectile, IDestructibleObj
{
	// Token: 0x06000C0C RID: 3084 RVA: 0x0000BB1E File Offset: 0x00009D1E
	protected override void Awake()
	{
		base.GetComponent<BadAssNetworkView>().photonView.Int32_1 = 0;
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x00068860 File Offset: 0x00066A60
	public override void Start()
	{
		base.Start();
		this.m_curTime = 0f;
		this.m_totalRaiseHeight = 0f;
		this.m_bDestoryed = false;
		this.m_bDestoryedByPlayer = false;
		this.m_blockTime = 0f;
		base.GetComponent<VFXManager>().method_9(ENPCParticleType.E_IceThorn, base.transform.position + Vector3.up * 4.5f, base.transform.rotation, true);
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x0000BB31 File Offset: 0x00009D31
	public override int vmethod_40()
	{
		return this.m_HP;
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0000BB39 File Offset: 0x00009D39
	public override int vmethod_41()
	{
		return this.m_maxHP;
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x000688DC File Offset: 0x00066ADC
	public override void Update()
	{
		if (this.m_BHVTaskManager == null || this.m_bDestoryed)
		{
			return;
		}
		if (this.m_BHVTaskManager.m_entity.vmethod_40() <= 0)
		{
			this.imethod_1();
			return;
		}
		this.m_curTime += Time.deltaTime;
		if (this.m_curTime < this.m_warningTime)
		{
			return;
		}
		if (this.m_totalRaiseHeight >= this.m_raiseHeight)
		{
			this.m_blockTime += Time.deltaTime;
			if (this.m_blockTime < this.m_lifeTime)
			{
				return;
			}
			this.imethod_1();
		}
		else
		{
			float num = Time.deltaTime * this.m_fRaiseSpeed;
			if (num + this.m_totalRaiseHeight > this.m_raiseHeight)
			{
				num = this.m_raiseHeight - this.m_totalRaiseHeight;
			}
			this.m_vDeltaRaise = base.transform.position;
			this.m_vDeltaRaise.y = this.m_vDeltaRaise.y + num;
			base.transform.position = this.m_vDeltaRaise;
			this.m_totalRaiseHeight += num;
		}
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x000689E8 File Offset: 0x00066BE8
	public override void imethod_1()
	{
		this.m_bDestoryed = true;
		base.GetComponent<VFXManager>().method_9(ENPCParticleType.E_IceBroken, base.transform.position + Vector3.up * 2f, base.transform.rotation, true);
		base.GetComponent<MeshRenderer>().enabled = false;
		if (this.m_bDestoryedByPlayer)
		{
		}
		AIServiceUtility.AIServiceUtility_0.method_1(this.m_index);
		global::UnityEngine.Object.Destroy(base.gameObject, 0.5f);
		base.imethod_1();
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_10()
	{
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool imethod_0(AttackInfo attackInfo_0)
	{
		return false;
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x00068A70 File Offset: 0x00066C70
	public override void imethod_2(int int_0)
	{
		int num = this.m_HP - int_0;
		if (num > 0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWorldTipsView>().vmethod_5(num, WeakPoint.StrengthType.Normal, base.gameObject.transform.position + Vector3.up * 2.5f, AttackInfo.ElementalType.None, false, false);
		}
		this.m_HP = int_0;
	}

	// Token: 0x04000ABA RID: 2746
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000ABB RID: 2747
	[HideInInspector]
	public float m_damageRadius;

	// Token: 0x04000ABC RID: 2748
	[HideInInspector]
	public int m_damage;

	// Token: 0x04000ABD RID: 2749
	public int m_HP = 10;

	// Token: 0x04000ABE RID: 2750
	public float m_fRaiseSpeed = 1.5f;

	// Token: 0x04000ABF RID: 2751
	public float m_warningTime = 1f;

	// Token: 0x04000AC0 RID: 2752
	public float m_raiseHeight = 3f;

	// Token: 0x04000AC1 RID: 2753
	public float m_lifeTime = 10f;

	// Token: 0x04000AC2 RID: 2754
	[HideInInspector]
	public int m_maxHP;

	// Token: 0x04000AC3 RID: 2755
	private float m_curTime;

	// Token: 0x04000AC4 RID: 2756
	private float m_blockTime;

	// Token: 0x04000AC5 RID: 2757
	private float m_totalRaiseHeight;

	// Token: 0x04000AC6 RID: 2758
	private Vector3 m_vDeltaRaise;

	// Token: 0x04000AC7 RID: 2759
	private bool m_bDestoryed;

	// Token: 0x04000AC8 RID: 2760
	private bool m_bDestoryedByPlayer;
}
