using System;
using Core;
using UnityEngine;

// Token: 0x020000DA RID: 218
public struct QEMMatrix3x3
{
	// Token: 0x06000532 RID: 1330 RVA: 0x0004D488 File Offset: 0x0004B688
	public QEMMatrix3x3 method_0(float float_0)
	{
		this.m_00 *= float_0;
		this.m_01 *= float_0;
		this.m_02 *= float_0;
		this.m_11 *= float_0;
		this.m_12 *= float_0;
		this.m_22 *= float_0;
		return this;
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x0004D4F0 File Offset: 0x0004B6F0
	public QEMMatrix3x3 method_1(QEMMatrix3x3 qemmatrix3x3_0)
	{
		return new QEMMatrix3x3
		{
			m_00 = this.m_00 * qemmatrix3x3_0.m_00 + this.m_01 * qemmatrix3x3_0.m_01 + this.m_02 * qemmatrix3x3_0.m_02,
			m_01 = this.m_00 * qemmatrix3x3_0.m_01 + this.m_01 * qemmatrix3x3_0.m_11 + this.m_02 * qemmatrix3x3_0.m_12,
			m_02 = this.m_00 * qemmatrix3x3_0.m_02 + this.m_01 * qemmatrix3x3_0.m_12 + this.m_02 * qemmatrix3x3_0.m_22,
			m_11 = this.m_01 * qemmatrix3x3_0.m_01 + this.m_11 * qemmatrix3x3_0.m_11 + this.m_12 * qemmatrix3x3_0.m_12,
			m_12 = this.m_01 * qemmatrix3x3_0.m_02 + this.m_11 * qemmatrix3x3_0.m_12 + this.m_12 * qemmatrix3x3_0.m_22,
			m_22 = this.m_02 * qemmatrix3x3_0.m_02 + this.m_12 * qemmatrix3x3_0.m_12 + this.m_22 * qemmatrix3x3_0.m_22
		};
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x0004D638 File Offset: 0x0004B838
	public Vector3 method_2(Vector3 vector3_0)
	{
		float x = vector3_0.x;
		float y = vector3_0.y;
		float z = vector3_0.z;
		return new Vector3(x * this.m_00 + y * this.m_01 + z * this.m_02, x * this.m_01 + y * this.m_11 + z * this.m_12, x * this.m_02 + y * this.m_12 + z * this.m_22);
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0004D6B0 File Offset: 0x0004B8B0
	public static QEMMatrix3x3 smethod_0(QEMMatrix3x3 qemmatrix3x3_0, QEMMatrix3x3 qemmatrix3x3_1)
	{
		return new QEMMatrix3x3
		{
			m_00 = qemmatrix3x3_0.m_00 + qemmatrix3x3_1.m_00,
			m_01 = qemmatrix3x3_0.m_01 + qemmatrix3x3_1.m_01,
			m_02 = qemmatrix3x3_0.m_02 + qemmatrix3x3_1.m_02,
			m_11 = qemmatrix3x3_0.m_11 + qemmatrix3x3_1.m_11,
			m_12 = qemmatrix3x3_0.m_12 + qemmatrix3x3_1.m_12,
			m_22 = qemmatrix3x3_0.m_22 + qemmatrix3x3_1.m_22
		};
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x0004D74C File Offset: 0x0004B94C
	public void method_3(QEMMatrix3x3 qemmatrix3x3_0)
	{
		this.m_00 += qemmatrix3x3_0.m_00;
		this.m_01 += qemmatrix3x3_0.m_01;
		this.m_02 += qemmatrix3x3_0.m_02;
		this.m_11 += qemmatrix3x3_0.m_11;
		this.m_12 += qemmatrix3x3_0.m_12;
		this.m_22 += qemmatrix3x3_0.m_22;
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x0004D7D4 File Offset: 0x0004B9D4
	public void method_4()
	{
		this.m_00 = 0f;
		this.m_01 = 0f;
		this.m_02 = 0f;
		this.m_11 = 0f;
		this.m_12 = 0f;
		this.m_22 = 0f;
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x0004D824 File Offset: 0x0004BA24
	public float method_5()
	{
		return this.m_00 * (this.m_11 * this.m_22 - this.m_12 * this.m_12) + this.m_01 * (this.m_12 * this.m_02 - this.m_22 * this.m_01) + this.m_02 * (this.m_01 * this.m_12 - this.m_11 * this.m_02);
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x0004D89C File Offset: 0x0004BA9C
	public QEMMatrix3x3 method_6()
	{
		QEMMatrix3x3 qemmatrix3x = default(QEMMatrix3x3);
		float num = this.method_5();
		qemmatrix3x.m_00 = (this.m_11 * this.m_22 - this.m_12 * this.m_12) / num;
		qemmatrix3x.m_01 = (this.m_02 * this.m_12 - this.m_01 * this.m_22) / num;
		qemmatrix3x.m_02 = (this.m_01 * this.m_12 - this.m_02 * this.m_11) / num;
		qemmatrix3x.m_11 = (this.m_00 * this.m_22 - this.m_02 * this.m_02) / num;
		qemmatrix3x.m_12 = (this.m_02 * this.m_01 - this.m_00 * this.m_12) / num;
		qemmatrix3x.m_22 = (this.m_00 * this.m_11 - this.m_01 * this.m_01) / num;
		return qemmatrix3x;
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x0004D994 File Offset: 0x0004BB94
	public bool method_7()
	{
		float num = this.m_00 - 1f;
		float num2 = this.m_11 - 1f;
		float num3 = this.m_22 - 1f;
		return num * num < 1E-05f && num2 * num2 < 1E-05f && num3 * num3 < 1E-05f && this.m_01 * this.m_01 < 1E-05f && this.m_02 * this.m_02 < 1E-05f && this.m_12 * this.m_12 < 1E-05f;
	}

	// Token: 0x17000038 RID: 56
	public float this[int int_0]
	{
		get
		{
			if (int_0 == 0)
			{
				return this.m_00;
			}
			if (int_0 == 1)
			{
				return this.m_01;
			}
			if (int_0 == 2)
			{
				return this.m_11;
			}
			if (int_0 == 3)
			{
				return this.m_02;
			}
			if (int_0 == 4)
			{
				return this.m_12;
			}
			if (int_0 == 5)
			{
				return this.m_22;
			}
			DebugUtils.Log(LogCategory.Graphics, "errorrrr");
			return 0f;
		}
		set
		{
			if (int_0 == 0)
			{
				this.m_00 = value;
				return;
			}
			if (int_0 == 1)
			{
				this.m_01 = value;
				return;
			}
			if (int_0 == 2)
			{
				this.m_11 = value;
				return;
			}
			if (int_0 == 3)
			{
				this.m_02 = value;
				return;
			}
			if (int_0 == 4)
			{
				this.m_12 = value;
				return;
			}
			if (int_0 == 5)
			{
				this.m_22 = value;
				return;
			}
			DebugUtils.Log(LogCategory.Graphics, "errorrrr");
		}
	}

	// Token: 0x040004B3 RID: 1203
	public float m_00;

	// Token: 0x040004B4 RID: 1204
	public float m_01;

	// Token: 0x040004B5 RID: 1205
	public float m_02;

	// Token: 0x040004B6 RID: 1206
	public float m_11;

	// Token: 0x040004B7 RID: 1207
	public float m_12;

	// Token: 0x040004B8 RID: 1208
	public float m_22;
}
