using System;
using UnityEngine;

// Token: 0x020006E1 RID: 1761
public class UIModelController : MonoBehaviour
{
	// Token: 0x06002E70 RID: 11888 RVA: 0x0001EAD9 File Offset: 0x0001CCD9
	private void Awake()
	{
		this._oriRotation = base.gameObject.transform.localRotation;
	}

	// Token: 0x06002E71 RID: 11889 RVA: 0x0001EAF1 File Offset: 0x0001CCF1
	private void Update()
	{
		this.method_2();
	}

	// Token: 0x06002E72 RID: 11890 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06002E73 RID: 11891 RVA: 0x0001EAF9 File Offset: 0x0001CCF9
	public void method_0(Vector3 vector3_0)
	{
		this._vecRotateSpeed = vector3_0;
	}

	// Token: 0x06002E74 RID: 11892 RVA: 0x0001EB02 File Offset: 0x0001CD02
	public void method_1()
	{
		base.gameObject.transform.localRotation = this._oriRotation;
	}

	// Token: 0x06002E75 RID: 11893 RVA: 0x000D87A8 File Offset: 0x000D69A8
	protected void method_2()
	{
		Vector3 vector = Input.mousePosition - this._vecLastFrameMousePos;
		this._vecLastFrameMousePos = Input.mousePosition;
		Quaternion quaternion = base.gameObject.transform.localRotation;
		if (this.method_3(this._vecRotateSpeed.x))
		{
			quaternion *= Quaternion.AngleAxis(this._vecRotateSpeed.x * vector.x, Vector3.up);
		}
		if (this.method_3(this._vecRotateSpeed.y))
		{
			quaternion *= Quaternion.AngleAxis(this._vecRotateSpeed.y * vector.y, Vector3.left);
		}
		base.gameObject.transform.localRotation = quaternion;
	}

	// Token: 0x06002E76 RID: 11894 RVA: 0x0001EB1A File Offset: 0x0001CD1A
	public bool method_3(float float_0)
	{
		return !object.Equals(float_0, 0f) && !float.IsNaN(float_0) && !float.IsInfinity(float_0);
	}

	// Token: 0x040020AC RID: 8364
	protected byte _rotateAxis;

	// Token: 0x040020AD RID: 8365
	protected Vector3 _vecLastFrameMousePos;

	// Token: 0x040020AE RID: 8366
	protected Vector3 _vecRotateSpeed = Vector3.zero;

	// Token: 0x040020AF RID: 8367
	protected float _rotateSpeed = 2f;

	// Token: 0x040020B0 RID: 8368
	protected Quaternion _oriRotation;
}
