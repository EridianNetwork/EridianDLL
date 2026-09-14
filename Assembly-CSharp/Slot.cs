using System;
using UnityEngine;

// Token: 0x02000552 RID: 1362
[Serializable]
public class Slot : ICloneable
{
	// Token: 0x06002316 RID: 8982 RVA: 0x00018154 File Offset: 0x00016354
	public void method_0(Vector3 vector3_0)
	{
		if (this.vmethod_0() == null)
		{
			return;
		}
		this.m_localePosition = this.vmethod_0().gameObject.transform.InverseTransformPoint(vector3_0);
	}

	// Token: 0x06002317 RID: 8983 RVA: 0x000A6510 File Offset: 0x000A4710
	public void method_1()
	{
		float num = 20f;
		Vector3 vector = this.method_2();
		Vector3 vector2 = vector + Vector3.up * num;
		RaycastHit raycastHit;
		if (Physics.Raycast(vector2, -Vector3.up, out raycastHit, 40f, 1 << LayerMask.NameToLayer("Walkable")))
		{
			vector.y = raycastHit.point.y;
			this.method_0(vector);
		}
	}

	// Token: 0x06002318 RID: 8984 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual SlotContainer vmethod_0()
	{
		throw new NotImplementedException();
	}

	// Token: 0x06002319 RID: 8985 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual void vmethod_1(SlotContainer slotContainer_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0600231A RID: 8986 RVA: 0x00018181 File Offset: 0x00016381
	public Vector3 method_2()
	{
		if (this.vmethod_0() == null)
		{
			return Vector3.zero;
		}
		return this.vmethod_0().gameObject.transform.TransformPoint(this.m_localePosition);
	}

	// Token: 0x0600231B RID: 8987 RVA: 0x000181B2 File Offset: 0x000163B2
	public Quaternion method_3()
	{
		return Quaternion.LookRotation(this.method_4());
	}

	// Token: 0x0600231C RID: 8988 RVA: 0x000181BF File Offset: 0x000163BF
	public Vector3 method_4()
	{
		if (this.vmethod_0() == null)
		{
			return Vector3.forward;
		}
		return this.vmethod_0().gameObject.transform.TransformDirection(this.m_localeFacingDirection);
	}

	// Token: 0x0600231D RID: 8989 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual object Clone()
	{
		throw new NotImplementedException();
	}

	// Token: 0x040017BB RID: 6075
	public Vector3 m_localePosition;

	// Token: 0x040017BC RID: 6076
	public Vector3 m_localeFacingDirection;
}
