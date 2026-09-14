using System;
using UnityEngine;

// Token: 0x0200024D RID: 589
public class IcePick : MonoBehaviour
{
	// Token: 0x06000C08 RID: 3080 RVA: 0x0000BAD2 File Offset: 0x00009CD2
	private void Start()
	{
		this.m_bLanded = false;
		this.m_bHitObject = false;
	}

	// Token: 0x06000C09 RID: 3081 RVA: 0x000686B0 File Offset: 0x000668B0
	private void Update()
	{
		if (this.m_flyingCurve != null && !(this.m_BHVTaskManager == null) && !this.m_bLanded && !this.m_bHitObject)
		{
			Vector3 vector;
			this.m_bLanded = this.m_flyingCurve.Update(Time.deltaTime, this.m_fSpeed, out vector);
			base.transform.forward = (vector - base.transform.position).normalized;
			base.transform.position = vector;
			this.m_bHitObject = this.method_0();
			if (this.m_bLanded || this.m_bHitObject)
			{
				ObjectParticleManager component = base.GetComponent<ObjectParticleManager>();
				if (component != null)
				{
					component.method_2();
					component.method_0(ENPCParticleType.E_IceBroken);
					component.method_3();
				}
				float num = ((!this.m_bHitObject) ? 3f : 0.5f);
				global::UnityEngine.Object.Destroy(base.gameObject, num);
			}
			return;
		}
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x000687A0 File Offset: 0x000669A0
	private bool method_0()
	{
		if (base.gameObject == null)
		{
			return false;
		}
		int num = ~((1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));
		float num2 = this.m_fSpeed * Time.deltaTime;
		num2 = Mathf.Clamp(num2, 0.3f, 1.5f);
		RaycastHit raycastHit;
		return Physics.Raycast(base.transform.position, base.transform.forward, out raycastHit, num2, num);
	}

	// Token: 0x04000AB2 RID: 2738
	[HideInInspector]
	public Vector3 m_vLandPos;

	// Token: 0x04000AB3 RID: 2739
	[HideInInspector]
	public AIServiceCurve.Curve m_flyingCurve;

	// Token: 0x04000AB4 RID: 2740
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000AB5 RID: 2741
	[HideInInspector]
	public float m_damageRadius;

	// Token: 0x04000AB6 RID: 2742
	[HideInInspector]
	public int m_damage;

	// Token: 0x04000AB7 RID: 2743
	public float m_fSpeed = 25f;

	// Token: 0x04000AB8 RID: 2744
	private bool m_bLanded;

	// Token: 0x04000AB9 RID: 2745
	private bool m_bHitObject;
}
