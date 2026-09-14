using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000254 RID: 596
public class SpiderantWebTrap : MonoBehaviour
{
	// Token: 0x06000C2B RID: 3115 RVA: 0x0000BCB6 File Offset: 0x00009EB6
	private void Start()
	{
		this.m_bExpanded = false;
		this.m_webCloth = base.GetComponent<InteractiveCloth>();
	}

	// Token: 0x06000C2C RID: 3116 RVA: 0x00069464 File Offset: 0x00067664
	private void Update()
	{
		this.m_lifeTime -= Time.deltaTime;
		if (this.m_lifeTime < 0f)
		{
			int count = this.m_entityList.Count;
			for (int i = 0; i < count; i++)
			{
				if (!(this.m_entityList[i] == null))
				{
					PlayerController component = this.m_entityList[i].GetComponent<PlayerController>();
					if (!(component == null))
					{
						this.m_entityList[i].GetComponent<PlayerController>().method_6(1f / this.m_speedSlowRatio);
					}
				}
			}
			this.m_entityList.Clear();
			global::UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		int num = this.m_webCloth.vertices.Length / 2;
		Vector3 vector = this.m_webCloth.vertices[num];
		if (!this.m_bExpanded && this.m_bLanded)
		{
			this.m_expandTimer += Time.deltaTime;
			if (this.m_expandTimer > 2f)
			{
				this.m_bExpanded = true;
				this.m_webCloth.useGravity = false;
				this.m_webCloth.enabled = false;
			}
		}
		if (!this.m_bLanded)
		{
			Vector3 vector2 = vector - this.m_vLandPos;
			vector2.y = 0f;
			if (vector2.sqrMagnitude < 25f)
			{
				this.m_vForce.x = 0f;
				this.m_vForce.y = -20f;
				this.m_vForce.z = 0f;
				this.m_webCloth.externalAcceleration = this.m_vForce;
				this.m_bLanded = true;
				this.m_expandTimer = 0f;
			}
		}
		else
		{
			List<PlayerInfoSync> list;
			MonoSingleton<Session>.Instance.method_38(out list);
			int count2 = list.Count;
			for (int j = 0; j < count2; j++)
			{
				EntityPlayer entityPlayer = list[j].GetEntity() as EntityPlayer;
				if (!(entityPlayer == null))
				{
					Vector3 vector3 = entityPlayer.transform.position - vector;
					vector3.y = 0f;
					bool flag = vector3.sqrMagnitude < 25f;
					bool flag2 = this.m_entityList.Contains(entityPlayer);
					PlayerController component2 = entityPlayer.GetComponent<PlayerController>();
					if (!(component2 == null))
					{
						float num2 = component2.method_8();
						if (flag)
						{
							if (!flag2 || num2 > 0.9f)
							{
								component2.method_6(this.m_speedSlowRatio);
								this.m_entityList.Add(entityPlayer);
							}
						}
						else if (flag2)
						{
							component2.method_6(1f / this.m_speedSlowRatio);
							this.m_entityList.Remove(entityPlayer);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x00069718 File Offset: 0x00067918
	public void method_0(Vector3 vector3_0)
	{
		this.m_vLandPos = vector3_0;
		this.m_vForce = vector3_0 - base.transform.position;
		this.m_vForce *= 2.5f;
		this.m_vForce.y = -10f;
		this.m_webCloth = base.GetComponent<InteractiveCloth>();
		this.m_webCloth.externalAcceleration = this.m_vForce;
	}

	// Token: 0x04000AF6 RID: 2806
	public float m_lifeTime = 10f;

	// Token: 0x04000AF7 RID: 2807
	public float m_speedSlowRatio = 0.5f;

	// Token: 0x04000AF8 RID: 2808
	public float m_flyingSpeed = 20f;

	// Token: 0x04000AF9 RID: 2809
	public float m_scaleRatio = 5f;

	// Token: 0x04000AFA RID: 2810
	[HideInInspector]
	public InteractiveCloth m_webCloth;

	// Token: 0x04000AFB RID: 2811
	[HideInInspector]
	public Vector3 m_vLandPos;

	// Token: 0x04000AFC RID: 2812
	private bool m_bLanded;

	// Token: 0x04000AFD RID: 2813
	private bool m_bExpanded;

	// Token: 0x04000AFE RID: 2814
	private AIServiceCurve.Curve m_curve;

	// Token: 0x04000AFF RID: 2815
	protected List<EntityPlayer> m_entityList = new List<EntityPlayer>();

	// Token: 0x04000B00 RID: 2816
	private Vector3 m_vForce;

	// Token: 0x04000B01 RID: 2817
	private float m_expandTimer;
}
