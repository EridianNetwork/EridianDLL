using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class CollisionManager : MonoBehaviour
{
	// Token: 0x06001AC8 RID: 6856 RVA: 0x000887A0 File Offset: 0x000869A0
	public void method_0(bool bool_0)
	{
		if (MonoSingleton<Session>.Instance.method_16())
		{
			this.method_19();
		}
		this.m_weakPoints = base.gameObject.GetComponentsInChildren<WeakPoint>();
		Transform transform = base.gameObject.transform.Find("BoundingBox");
		if (transform)
		{
			this.m_boundingBox = (Collider)transform.GetComponent(typeof(Collider));
		}
		this.method_17(false);
		if (bool_0 && this.m_boundingBox != null && this.m_movementBounding == null)
		{
			this.m_movementBounding = base.gameObject.AddComponent<BoxCollider>();
			if (this.m_movementBounding != null)
			{
				this.m_movementBounding.isTrigger = base.enabled;
				this.m_movementBounding.size = this.m_boundingBox.bounds.size + new Vector3(2f, 0.5f, 2f);
				this.m_movementBounding.center = this.m_boundingBox.bounds.center - this.m_boundingBox.transform.position;
				this.m_movementBounds.center = this.m_movementBounding.center;
				this.m_movementBounds.size = this.m_movementBounding.size;
			}
		}
		Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			this.m_colliders.Add(componentsInChildren[i]);
		}
		this.m_inited = true;
	}

	// Token: 0x06001AC9 RID: 6857 RVA: 0x000137D5 File Offset: 0x000119D5
	public bool method_1()
	{
		return this.m_inited;
	}

	// Token: 0x06001ACA RID: 6858 RVA: 0x00088934 File Offset: 0x00086B34
	public bool method_2(Ray ray_0, out RaycastHit raycastHit_0, ref float float_0)
	{
		bool flag = false;
		raycastHit_0 = default(RaycastHit);
		if (ray_0.direction != Vector3.zero)
		{
			for (int i = 0; i < this.m_colliders.Count; i++)
			{
				ray_0.direction = ray_0.direction.normalized;
				Collider collider = this.m_colliders[i];
				if (!(collider == null) && !(collider.gameObject == null) && collider.Raycast(ray_0, out raycastHit_0, float_0))
				{
					flag = true;
					float_0 = raycastHit_0.distance;
				}
			}
		}
		return flag;
	}

	// Token: 0x06001ACB RID: 6859 RVA: 0x000889D0 File Offset: 0x00086BD0
	public bool method_3(Ray ray_0, out RaycastHit raycastHit_0, ref float float_0)
	{
		bool flag = false;
		raycastHit_0 = default(RaycastHit);
		if (ray_0.direction != Vector3.zero)
		{
			this.method_17(true);
			for (int i = 0; i < this.m_weakPoints.Length; i++)
			{
				WeakPoint weakPoint = this.m_weakPoints[i];
				if (!(weakPoint == null) && !(weakPoint.gameObject == null))
				{
					Collider collider = weakPoint.method_0();
					if (!(collider == null) && !(collider.gameObject == null))
					{
						ray_0.direction = ray_0.direction.normalized;
						RaycastHit raycastHit;
						if (collider.Raycast(ray_0, out raycastHit, float_0))
						{
							raycastHit_0 = raycastHit;
							flag = true;
							float_0 = raycastHit_0.distance;
						}
					}
				}
			}
			this.method_17(false);
		}
		return flag;
	}

	// Token: 0x06001ACC RID: 6860 RVA: 0x00088AA4 File Offset: 0x00086CA4
	public bool method_4(Ray ray_0, out RaycastHit raycastHit_0, ref float float_0)
	{
		bool flag = false;
		raycastHit_0 = default(RaycastHit);
		if (ray_0.direction != Vector3.zero && this.m_boundingBox != null)
		{
			ray_0.direction = ray_0.direction.normalized;
			if (this.m_boundingBox.Raycast(ray_0, out raycastHit_0, float_0))
			{
				flag = true;
				float_0 = raycastHit_0.distance;
			}
		}
		return flag;
	}

	// Token: 0x06001ACD RID: 6861 RVA: 0x00088B18 File Offset: 0x00086D18
	public bool method_5(Ray ray_0, out RaycastHit raycastHit_0, ref float float_0)
	{
		bool flag = false;
		raycastHit_0 = default(RaycastHit);
		if (ray_0.direction != Vector3.zero && this.m_movementBounding != null)
		{
			ray_0.direction = ray_0.direction.normalized;
			if (this.m_movementBounding.Raycast(ray_0, out raycastHit_0, float_0))
			{
				flag = true;
				float_0 = raycastHit_0.distance;
			}
		}
		return flag;
	}

	// Token: 0x06001ACE RID: 6862 RVA: 0x000137DD File Offset: 0x000119DD
	public bool method_6()
	{
		return this.m_colliders.Count > 0;
	}

	// Token: 0x06001ACF RID: 6863 RVA: 0x00088B8C File Offset: 0x00086D8C
	public void method_7(Collider collider_0)
	{
		if (!m_colliders.Exists((Collider c) => c == collider_0))
		{
			m_colliders.Add(collider_0);
		}
	}
	// Token: 0x06001AD0 RID: 6864 RVA: 0x00088BD0 File Offset: 0x00086DD0
	public void method_8(Collider collider_0)
	{
		m_colliders.RemoveAll((Collider c) => c == collider_0);
	}
	// Token: 0x06001AD1 RID: 6865 RVA: 0x00088C04 File Offset: 0x00086E04
	public void method_9(bool bool_0)
	{
		for (int i = 0; i < this.m_colliders.Count; i++)
		{
			if (this.m_colliders[i] != null)
			{
				this.m_colliders[i].enabled = bool_0;
			}
		}
	}

	// Token: 0x06001AD2 RID: 6866 RVA: 0x000137ED File Offset: 0x000119ED
	public WeakPoint[] method_10()
	{
		return this.m_weakPoints;
	}

	// Token: 0x06001AD3 RID: 6867 RVA: 0x00088C50 File Offset: 0x00086E50
	public sbyte method_11(WeakPoint weakPoint_0)
	{
		sbyte b = 0;
		while ((int)b < this.m_weakPoints.Length)
		{
			if (this.m_weakPoints[(int)b] == weakPoint_0)
			{
				return b;
			}
			b += 1;
		}
		return -1;
	}

	// Token: 0x06001AD4 RID: 6868 RVA: 0x000137F5 File Offset: 0x000119F5
	public WeakPoint method_12(int int_0)
	{
		if (-1 < int_0 && int_0 < this.m_weakPoints.Length)
		{
			return this.m_weakPoints[int_0];
		}
		return null;
	}

	// Token: 0x06001AD5 RID: 6869 RVA: 0x00013810 File Offset: 0x00011A10
	public Collider method_13()
	{
		if (this.m_boundingBox == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, base.gameObject.name + " dont have bounding box but access it");
		}
		return this.m_boundingBox;
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x00013841 File Offset: 0x00011A41
	public BoxCollider method_14()
	{
		return this.m_movementBounding;
	}

	// Token: 0x06001AD7 RID: 6871 RVA: 0x00013849 File Offset: 0x00011A49
	public Bounds method_15()
	{
		return this.m_movementBounds;
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x00088C88 File Offset: 0x00086E88
	private void OnDrawGizmos()
	{
		foreach (WeakPoint weakPoint in this.m_weakPoints)
		{
			Gizmos.DrawSphere(weakPoint.transform.position, 0.05f);
		}
		if (this.m_boundingBox)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawWireCube(this.m_boundingBox.bounds.center, this.m_boundingBox.bounds.size);
		}
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x00088D08 File Offset: 0x00086F08
	public void method_16()
	{
		for (int i = 0; i < this.m_weakPoints.Length; i++)
		{
			this.m_weakPoints[i].gameObject.layer = LayerMask.NameToLayer("WeakPoint");
		}
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x00088D44 File Offset: 0x00086F44
	public void method_17(bool bool_0)
	{
		for (int i = 0; i < this.m_weakPoints.Length; i++)
		{
			if (this.m_weakPoints[i].method_0() != this.m_boundingBox)
			{
				this.m_weakPoints[i].method_0().enabled = bool_0;
			}
		}
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x00088D94 File Offset: 0x00086F94
	public void method_18()
	{
		this.m_boundingBox.transform.localPosition = Vector3.zero;
		for (int i = 0; i < this.m_weakPoints.Length; i++)
		{
			if (this.m_weakPoints[i].method_0() != this.m_boundingBox)
			{
				this.m_weakPoints[i].method_2();
			}
		}
	}

	// Token: 0x06001ADC RID: 6876 RVA: 0x00088DF0 File Offset: 0x00086FF0
	private void method_19()
	{
		CharacterJoint[] componentsInChildren = base.GetComponentsInChildren<CharacterJoint>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			global::UnityEngine.Object.DestroyImmediate(componentsInChildren[i]);
		}
		Rigidbody[] componentsInChildren2 = base.GetComponentsInChildren<Rigidbody>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (!(componentsInChildren2[j].transform == base.transform))
			{
				global::UnityEngine.Object.DestroyImmediate(componentsInChildren2[j]);
			}
		}
		Collider[] componentsInChildren3 = base.GetComponentsInChildren<Collider>();
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			if (!(componentsInChildren3[k].transform == base.transform))
			{
				global::UnityEngine.Object.DestroyImmediate(componentsInChildren3[k]);
			}
		}
		WeakPoint[] componentsInChildren4 = base.GetComponentsInChildren<WeakPoint>();
		for (int l = 0; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == base.transform))
			{
				global::UnityEngine.Object.DestroyImmediate(componentsInChildren4[l]);
			}
		}
	}

	// Token: 0x06001ADD RID: 6877 RVA: 0x00088EC4 File Offset: 0x000870C4
	public void method_20()
	{
		if (base.GetComponent<Rigidbody>() == null)
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
		}
	}

	// Token: 0x040011A6 RID: 4518
	private List<Collider> m_colliders = new List<Collider>();

	// Token: 0x040011A7 RID: 4519
	private WeakPoint[] m_weakPoints = new WeakPoint[0];

	// Token: 0x040011A8 RID: 4520
	private Collider m_boundingBox;

	// Token: 0x040011A9 RID: 4521
	private BoxCollider m_movementBounding;

	// Token: 0x040011AA RID: 4522
	private Bounds m_movementBounds;

	// Token: 0x040011AB RID: 4523
	private bool m_inited;
}
