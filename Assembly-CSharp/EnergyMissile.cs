using System;
using UnityEngine;

// Token: 0x0200024C RID: 588
public class EnergyMissile : MonoBehaviour
{
	// Token: 0x06000C01 RID: 3073 RVA: 0x0000BA94 File Offset: 0x00009C94
	private void Start()
	{
		this.m_bVfxReady = false;
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x000683CC File Offset: 0x000665CC
	private void Update()
	{
		if (this.m_taskManager == null)
		{
			return;
		}
		if (AIServiceUtility.AIServiceUtility_0.m_bPlayCutScene)
		{
			this.m_destroydelay = 0.01f;
			this.method_3();
		}
		if (!this.m_bVfxReady)
		{
			this.m_bVfxReady = base.GetComponent<VFXManager>().method_5(ENPCParticleType.E_archangelEnergyMissile, null, base.transform, Vector3.zero, Quaternion.identity, 0f, true);
		}
		if (this.m_timer > 0f)
		{
			this.m_timer -= Time.deltaTime;
			if (this.m_timer > 0f)
			{
				this.method_1();
				return;
			}
		}
		if (!this.m_bFlyFinished)
		{
			float sqrMagnitude = (this.m_vTargetPos - base.transform.position).sqrMagnitude;
			if (sqrMagnitude < Time.deltaTime * this.m_speed * Time.deltaTime * this.m_speed)
			{
				base.transform.position = this.m_vTargetPos;
				this.method_3();
			}
			else
			{
				if (this.method_2())
				{
					this.method_3();
					return;
				}
				base.transform.position += this.m_vFlyDir * Time.deltaTime * this.m_speed;
			}
		}
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x0000BA9D File Offset: 0x00009C9D
	public void method_0(BHVTaskManager bhvtaskManager_0, Entity entity_0, float float_0)
	{
		this.m_speed = float_0;
		this.m_targetEntity = entity_0;
		this.m_taskManager = bhvtaskManager_0;
		this.m_timer = 3f;
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0006850C File Offset: 0x0006670C
	private void method_1()
	{
		Vector3 vector = global::UnityEngine.Random.insideUnitSphere * 1.5f;
		vector.y = 0f;
		if (this.m_targetEntity != null)
		{
			this.m_vTargetPos = this.m_targetEntity.method_1() + vector;
		}
		else
		{
			this.m_vTargetPos = base.transform.position + Vector3.down * 30f;
		}
		this.m_vFlyDir = (this.m_vTargetPos - base.transform.position).normalized;
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x000685A8 File Offset: 0x000667A8
	private bool method_2()
	{
		int num = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float num2 = this.m_speed * Time.deltaTime;
		num2 = Mathf.Clamp(num2, 0.3f, 1.5f);
		RaycastHit raycastHit;
		return Physics.Raycast(base.transform.position, this.m_vFlyDir, out raycastHit, num2, num);
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x00068654 File Offset: 0x00066854
	private void method_3()
	{
		this.m_bFlyFinished = true;
		VFXManager component = base.GetComponent<VFXManager>();
		if (component != null)
		{
			component.method_13(ENPCParticleType.E_archangelEnergyMissile);
			component.method_8(ENPCParticleType.E_ArchangelEnergyExplosive, null, base.transform.position, Quaternion.identity, true);
		}
		global::UnityEngine.Object.Destroy(base.gameObject, this.m_destroydelay);
	}

	// Token: 0x04000AA9 RID: 2729
	private BHVTaskManager m_taskManager;

	// Token: 0x04000AAA RID: 2730
	private float m_speed = 10f;

	// Token: 0x04000AAB RID: 2731
	private Vector3 m_vTargetPos;

	// Token: 0x04000AAC RID: 2732
	private Vector3 m_vFlyDir;

	// Token: 0x04000AAD RID: 2733
	private bool m_bFlyFinished;

	// Token: 0x04000AAE RID: 2734
	private float m_timer = 3f;

	// Token: 0x04000AAF RID: 2735
	private float m_destroydelay = 3f;

	// Token: 0x04000AB0 RID: 2736
	private Entity m_targetEntity;

	// Token: 0x04000AB1 RID: 2737
	private bool m_bVfxReady;
}
