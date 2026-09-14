using System;
using UnityEngine;

// Token: 0x02000253 RID: 595
public class PsychoThrowAxe : MonoBehaviour
{
	// Token: 0x06000C27 RID: 3111 RVA: 0x0000BC03 File Offset: 0x00009E03
	private void Start()
	{
		this.m_AudioCtl = base.GetComponentInChildren<BaseEventTriggerCtl>();
		this.m_bFlyingEnd = false;
		this.m_bFlying = false;
		this.m_bHitted = false;
		this.m_bHide = false;
		this.m_lifeTime = 10f;
		this.m_flyingSoundTimer = 0f;
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x0000BC43 File Offset: 0x00009E43
	public void method_0()
	{
		this.m_bFlyingEnd = false;
		this.m_bFlying = true;
		this.m_bHitted = false;
		this.m_bHide = false;
		this.m_lifeTime = 10f;
		this.m_flyingSoundTimer = 0f;
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x000691C0 File Offset: 0x000673C0
	private void Update()
	{
		if (this.m_bHide)
		{
			this.m_hideTimer -= Time.deltaTime;
			if (this.m_hideTimer < 0f)
			{
				base.gameObject.SetActive(false);
			}
		}
		this.m_lifeTime -= Time.deltaTime;
		if (this.m_lifeTime < 1E-45f && this.m_bFlying)
		{
			base.gameObject.SetActive(false);
		}
		if (this.m_bHitted && this.m_attackObject != null)
		{
			base.transform.position = this.m_attackObject.transform.position + this.m_vOffsetToTarget;
			return;
		}
		if (this.m_flyingCurve != null && !(this.m_BHVTaskManager == null) && !this.m_bFlyingEnd && !(this.m_attackObject == null))
		{
			Vector3 vector;
			this.m_bFlyingEnd = this.m_flyingCurve.Update(Time.deltaTime, this.m_fSpeed, out vector);
			Vector3 position = base.transform.position;
			base.transform.position = vector;
			base.transform.RotateAround(base.transform.position, base.transform.right, 1080f * Time.deltaTime);
			if (this.m_AudioCtl != null)
			{
				this.m_flyingSoundTimer += Time.deltaTime;
				if (this.m_flyingSoundTimer > 0.33f)
				{
					this.m_flyingSoundTimer -= 0.33f;
					this.m_AudioCtl.vmethod_1(AudioEventName.Psycho_Axe_Wsh_Rnd);
				}
			}
			if (!this.m_bHitted)
			{
				Vector3 vector2 = this.m_attackObject.transform.position + Vector3.up * 1.4f;
				float sqrMagnitude = (base.transform.position - vector2).sqrMagnitude;
				if (sqrMagnitude < this.m_fSpeed * this.m_fSpeed * Time.deltaTime * Time.deltaTime || sqrMagnitude < 0.64f)
				{
					this.m_bHitted = true;
					Vector3 normalized = (base.transform.position - position).normalized;
					float num = (vector2 - position).magnitude - 0.2f;
					base.transform.position = position + normalized * num;
					this.m_vOffsetToTarget = base.transform.position - this.m_attackObject.transform.position;
				}
			}
			if (this.m_bHitted || this.m_bFlyingEnd)
			{
				this.m_hideTimer = 0.5f;
				this.m_bHide = true;
			}
			return;
		}
	}

	// Token: 0x04000AE7 RID: 2791
	[HideInInspector]
	public Vector3 m_vEndPos;

	// Token: 0x04000AE8 RID: 2792
	[HideInInspector]
	public AIServiceCurve.Curve m_flyingCurve;

	// Token: 0x04000AE9 RID: 2793
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000AEA RID: 2794
	[HideInInspector]
	public GameObject m_attackObject;

	// Token: 0x04000AEB RID: 2795
	[HideInInspector]
	public bool m_bFlying;

	// Token: 0x04000AEC RID: 2796
	public float m_fSpeed = 25f;

	// Token: 0x04000AED RID: 2797
	public int m_damage = 30;

	// Token: 0x04000AEE RID: 2798
	private bool m_bFlyingEnd;

	// Token: 0x04000AEF RID: 2799
	private bool m_bHitted;

	// Token: 0x04000AF0 RID: 2800
	private bool m_bHide;

	// Token: 0x04000AF1 RID: 2801
	private float m_hideTimer;

	// Token: 0x04000AF2 RID: 2802
	private float m_lifeTime = 10f;

	// Token: 0x04000AF3 RID: 2803
	private float m_flyingSoundTimer;

	// Token: 0x04000AF4 RID: 2804
	private Vector3 m_vOffsetToTarget;

	// Token: 0x04000AF5 RID: 2805
	public BaseEventTriggerCtl m_AudioCtl;
}
