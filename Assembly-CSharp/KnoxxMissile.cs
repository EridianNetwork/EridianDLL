using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class KnoxxMissile : EntityProjectile, IDestructibleObj
{
	// Token: 0x06000C16 RID: 3094 RVA: 0x0000BB1E File Offset: 0x00009D1E
	protected override void Awake()
	{
		base.GetComponent<BadAssNetworkView>().photonView.Int32_1 = 0;
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x0000BB7D File Offset: 0x00009D7D
	public void method_10(Entity entity_0)
	{
		this.m_targetEntity = entity_0;
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x00068AD0 File Offset: 0x00066CD0
	public override void Start()
	{
		base.Start();
		this.m_bDestory = false;
		this.m_curTime = 0f;
		this.m_maxHP = this.m_HP;
		base.transform.forward = Quaternion.Euler(0f, 0f, (float)(this.m_index % 3) * 30f - 30f) * this.m_initDir;
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x0000BB86 File Offset: 0x00009D86
	public override int vmethod_40()
	{
		return this.m_HP;
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x0000BB8E File Offset: 0x00009D8E
	public override int vmethod_41()
	{
		return this.m_maxHP;
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x00068B3C File Offset: 0x00066D3C
	public override void Update()
	{
		if (this.m_bDestory)
		{
			return;
		}
		this.m_curTime += Time.deltaTime;
		if (this.m_curTime > this.m_lifeTime)
		{
			this.imethod_1();
			return;
		}
		if (this.method_11())
		{
			this.imethod_1();
			return;
		}
		if (this.m_curTime > 0.3f && this.m_targetEntity != null)
		{
			this.m_vDirToTarget = (this.m_targetEntity.method_1() + Vector3.up * 1.4f - base.transform.position).normalized;
			base.transform.forward = Vector3.Lerp(base.transform.forward, this.m_vDirToTarget, this.m_traceTargetSpeed * Time.deltaTime);
		}
		base.transform.position += base.transform.forward * this.m_flyingSpeed * Time.deltaTime;
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x00068C44 File Offset: 0x00066E44
	private bool method_11()
	{
		if (base.gameObject == null)
		{
			return false;
		}
		int num = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float num2 = this.m_flyingSpeed * Time.deltaTime;
		num2 = Mathf.Clamp(num2, 0.3f, 1.5f);
		RaycastHit raycastHit;
		return Physics.Raycast(base.transform.position, base.transform.forward, out raycastHit, num2, num);
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_12()
	{
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00068D04 File Offset: 0x00066F04
	public override void imethod_1()
	{
		this.m_bDestory = true;
		if (base.gameObject != null)
		{
			VFXManager component = base.GetComponent<VFXManager>();
			if (component != null)
			{
				component.method_4(ENPCParticleType.E_KnoxxMissileBurst, 1f, true);
			}
		}
		if (base.gameObject != null)
		{
			MeshRenderer component2 = base.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				base.GetComponent<MeshRenderer>().enabled = false;
			}
		}
		AIServiceUtility.AIServiceUtility_0.method_1(this.m_index);
		global::UnityEngine.Object.Destroy(base.gameObject, 1f);
		base.imethod_1();
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00068D98 File Offset: 0x00066F98
	public override bool imethod_0(AttackInfo attackInfo_0)
	{
		Vector3 normalized = (base.transform.position - attackInfo_0.m_origin).normalized;
		if (Vector3.Dot(normalized, attackInfo_0.m_direction) < 0.8f)
		{
			return false;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(attackInfo_0.m_origin, attackInfo_0.m_direction, out raycastHit, 100f, 1 << LayerMask.NameToLayer("DestructibleObj")) && raycastHit.collider.gameObject == base.gameObject)
		{
			this.m_HP -= attackInfo_0.m_damagePoint;
			if (this.m_HP < 0)
			{
				this.method_12();
			}
			return true;
		}
		return false;
	}

	// Token: 0x04000AC9 RID: 2761
	public int m_HP = 10;

	// Token: 0x04000ACA RID: 2762
	public float m_lifeTime = 5f;

	// Token: 0x04000ACB RID: 2763
	public float m_flyingSpeed = 15f;

	// Token: 0x04000ACC RID: 2764
	public float m_traceTargetSpeed = 2f;

	// Token: 0x04000ACD RID: 2765
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000ACE RID: 2766
	private Entity m_targetEntity;

	// Token: 0x04000ACF RID: 2767
	private bool m_bDestory;

	// Token: 0x04000AD0 RID: 2768
	private Vector3 m_vDirToTarget;

	// Token: 0x04000AD1 RID: 2769
	private Vector3 m_initDir = Vector3.up;

	// Token: 0x04000AD2 RID: 2770
	private float m_curTime;

	// Token: 0x04000AD3 RID: 2771
	private int m_maxHP;
}
