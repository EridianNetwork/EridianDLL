using System;
using UnityEngine;

// Token: 0x02000256 RID: 598
public class TurretRocket : MonoBehaviour
{
	// Token: 0x06000C32 RID: 3122 RVA: 0x000697F8 File Offset: 0x000679F8
	private void Start()
	{
		this.m_bDestoryed = false;
		if (this.m_targetEntity as EntityNpc != null)
		{
			this.m_hightOffest = (this.m_targetEntity as EntityNpc).m_entityHeight * 0.7f;
		}
		else if (this.m_targetEntity as EntityPlayer != null)
		{
			this.m_hightOffest = 1.5f;
		}
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x0006985C File Offset: 0x00067A5C
	private void Update()
	{
		if (this.m_bDestoryed)
		{
			return;
		}
		this.m_fLifeTime -= Time.deltaTime;
		bool flag = false;
		if (this.m_targetEntity != null)
		{
			Vector3 vector = this.m_targetEntity.method_1();
			vector.y += this.m_hightOffest;
			Vector3 normalized = (vector - base.transform.position).normalized;
			base.transform.forward = Vector3.Lerp(base.transform.forward, normalized, 0.2f);
			base.transform.position += base.transform.forward * this.m_fSpeed * Time.deltaTime;
			flag = (base.transform.position - vector).sqrMagnitude <= this.m_fSpeed * Time.deltaTime * this.m_fSpeed * Time.deltaTime;
		}
		else
		{
			base.transform.position += base.transform.forward * this.m_fSpeed * Time.deltaTime;
		}
		if (!this.method_0() && !flag)
		{
			return;
		}
		base.GetComponent<VFXManager>().method_13(ENPCParticleType.E_TurretRocket);
		base.GetComponent<VFXManager>().method_4(ENPCParticleType.E_KnoxxMissileBurst, 1f, true);
		this.m_bDestoryed = true;
		global::UnityEngine.Object.Destroy(base.gameObject, 1f);
		Renderer componentInChildren = base.gameObject.GetComponentInChildren<Renderer>();
		if (componentInChildren != null)
		{
			componentInChildren.enabled = false;
		}
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x0000BD1A File Offset: 0x00009F1A
	private bool method_0()
	{
		return this.m_fLifeTime < 0f || this.m_BHVTaskManager == null || this.m_BHVTaskManager.m_entity == null;
	}

	// Token: 0x04000B07 RID: 2823
	[HideInInspector]
	public float m_fSpeed = 15f;

	// Token: 0x04000B08 RID: 2824
	[HideInInspector]
	public float m_fLifeTime = 5f;

	// Token: 0x04000B09 RID: 2825
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000B0A RID: 2826
	[HideInInspector]
	public Entity m_targetEntity;

	// Token: 0x04000B0B RID: 2827
	private float m_hightOffest = 1f;

	// Token: 0x04000B0C RID: 2828
	private bool m_bDestoryed;
}
