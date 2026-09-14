using System;
using UnityEngine;

// Token: 0x02000250 RID: 592
public class PlasmaBall : MonoBehaviour
{
	// Token: 0x06000C21 RID: 3105 RVA: 0x00068E40 File Offset: 0x00067040
	private void Start()
	{
		this.m_state = PlasmaBall.EStateOfPlasmaBall.ECharge;
		base.GetComponent<VFXManager>().method_4(ENPCParticleType.E_PlasmaBallCharge, 1f, true);
		this.m_collider = base.GetComponent<SphereCollider>();
		this.m_collider.enabled = false;
		this.m_collider.radius = 0.001f;
		this.m_hurtZone = base.GetComponent<PlasmaHurtZone>();
		this.m_hurtZone.enabled = false;
		this.m_bStartFlying = false;
		this.m_chargeTimer = 0f;
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x00068EBC File Offset: 0x000670BC
	private void Update()
	{
		if (base.gameObject == null)
		{
			return;
		}
		if (this.m_BHVTaskManager.m_entity == null)
		{
			return;
		}
		VFXManager component = base.GetComponent<VFXManager>();
		if (component == null)
		{
			return;
		}
		if (this.m_state == PlasmaBall.EStateOfPlasmaBall.ECharge)
		{
			this.m_chargeTimer += Time.deltaTime;
			if (this.m_chargeTimer < this.m_chargeTime)
			{
				return;
			}
			base.transform.parent = null;
			if (this.m_attackObject != null)
			{
				this.m_vTargetPos = this.m_attackObject.transform.position + Vector3.up * 1.4f;
			}
			this.m_vFlyingDir = this.m_BHVTaskManager.m_entity.transform.forward;
			this.m_vFlyingDir.y = (this.m_vTargetPos - base.transform.position).normalized.y;
			this.m_flyingTime = (base.transform.position - this.m_vTargetPos).magnitude / this.m_flyingSpeed;
			component.method_4(ENPCParticleType.E_PlasmaBallFly, this.m_flyingTime, true);
			this.m_state = PlasmaBall.EStateOfPlasmaBall.EFlying;
		}
		else if (this.m_state == PlasmaBall.EStateOfPlasmaBall.EFlying)
		{
			this.m_flyingTime -= Time.deltaTime;
			if (this.m_flyingTime > 0f && !this.method_0())
			{
				base.transform.position += this.m_vFlyingDir * this.m_flyingSpeed * Time.deltaTime;
			}
			else
			{
				component.method_4(ENPCParticleType.E_PlasmaBallBurst, this.m_damageDuration, true);
				this.m_state = PlasmaBall.EStateOfPlasmaBall.EBurst;
			}
		}
		else
		{
			this.m_damageDuration -= Time.deltaTime;
			if (this.m_damageDuration < 0f)
			{
				global::UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
		}
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x000690A8 File Offset: 0x000672A8
	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component == null)
		{
			return;
		}
		if (this.m_state == PlasmaBall.EStateOfPlasmaBall.EFlying)
		{
			this.m_flyingTime = 0f;
		}
	}

	// Token: 0x06000C24 RID: 3108 RVA: 0x000690DC File Offset: 0x000672DC
	private bool method_0()
	{
		if (base.gameObject == null)
		{
			return false;
		}
		int num = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float num2 = this.m_flyingSpeed * Time.deltaTime;
		num2 = Mathf.Clamp(num2, 0.3f, 1.5f);
		RaycastHit raycastHit;
		return Physics.Raycast(base.transform.position, base.transform.forward, out raycastHit, num2, num) && !(raycastHit.transform.parent == this.m_BHVTaskManager.transform);
	}

	// Token: 0x04000AD4 RID: 2772
	[HideInInspector]
	public bool m_bStartFlying;

	// Token: 0x04000AD5 RID: 2773
	[HideInInspector]
	public Vector3 m_vFlyingDir;

	// Token: 0x04000AD6 RID: 2774
	[HideInInspector]
	public Vector3 m_vTargetPos;

	// Token: 0x04000AD7 RID: 2775
	[HideInInspector]
	public float m_flyingSpeed;

	// Token: 0x04000AD8 RID: 2776
	[HideInInspector]
	public float m_damageDuration = 2f;

	// Token: 0x04000AD9 RID: 2777
	[HideInInspector]
	public float m_damage = 10f;

	// Token: 0x04000ADA RID: 2778
	[HideInInspector]
	public float m_chargeTime = 1f;

	// Token: 0x04000ADB RID: 2779
	[HideInInspector]
	public float m_damageRadius = 2f;

	// Token: 0x04000ADC RID: 2780
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000ADD RID: 2781
	[HideInInspector]
	public GameObject m_attackObject;

	// Token: 0x04000ADE RID: 2782
	private SphereCollider m_collider;

	// Token: 0x04000ADF RID: 2783
	private PlasmaHurtZone m_hurtZone;

	// Token: 0x04000AE0 RID: 2784
	private float m_chargeTimer;

	// Token: 0x04000AE1 RID: 2785
	private float m_flyingTime = 10f;

	// Token: 0x04000AE2 RID: 2786
	private PlasmaBall.EStateOfPlasmaBall m_state;

	// Token: 0x02000251 RID: 593
	private enum EStateOfPlasmaBall
	{
		// Token: 0x04000AE4 RID: 2788
		ECharge,
		// Token: 0x04000AE5 RID: 2789
		EFlying,
		// Token: 0x04000AE6 RID: 2790
		EBurst
	}
}
