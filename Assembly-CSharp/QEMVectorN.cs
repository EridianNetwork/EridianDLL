using System;
using UnityEngine;

// Token: 0x020000DB RID: 219
public class QEMVectorN
{
	// Token: 0x0600053D RID: 1341 RVA: 0x0004DAE8 File Offset: 0x0004BCE8
	public QEMVectorN()
	{
		this.m_b1 = default(Vector3);
		this.m_b2 = new QEMVectorAttribute();
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x00006A00 File Offset: 0x00004C00
	public void method_0(Vector3 vector3_0)
	{
		this.m_b1 = vector3_0;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00006A09 File Offset: 0x00004C09
	public Vector3 method_1()
	{
		return this.m_b1;
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x00006A11 File Offset: 0x00004C11
	public void method_2(int int_0, float float_0)
	{
		this.m_b2[int_0] = float_0;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x00006A20 File Offset: 0x00004C20
	public float method_3(int int_0)
	{
		return this.m_b2[int_0];
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00006A2E File Offset: 0x00004C2E
	public void method_4()
	{
		this.m_b1 = Vector3.zero;
		this.m_b2.method_0();
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00006A46 File Offset: 0x00004C46
	public int method_5()
	{
		return this.m_b2.method_1() + 3;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x00006A55 File Offset: 0x00004C55
	public void method_6(float float_0)
	{
		this.m_b1 *= float_0;
		this.m_b2.method_2(float_0);
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00006A75 File Offset: 0x00004C75
	public void method_7(QEMVectorN qemvectorN_0)
	{
		this.m_b1 += qemvectorN_0.m_b1;
		this.m_b2.method_3(qemvectorN_0.m_b2);
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x00006A9F File Offset: 0x00004C9F
	public static void smethod_0(QEMVectorN qemvectorN_0, QEMVectorN qemvectorN_1, ref QEMVectorN qemvectorN_2)
	{
		qemvectorN_2.m_b1 = qemvectorN_0.m_b1 + qemvectorN_1.m_b1;
		QEMVectorAttribute.smethod_0(qemvectorN_0.m_b2, qemvectorN_1.m_b2, ref qemvectorN_2.m_b2);
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0004DB18 File Offset: 0x0004BD18
	public static float smethod_1(QEMVectorN qemvectorN_0, QEMVectorN qemvectorN_1)
	{
		float num = 0f;
		int num2 = qemvectorN_0.method_5();
		for (int i = 0; i < num2; i++)
		{
			num += qemvectorN_0[i] * qemvectorN_1[i];
		}
		return num;
	}

	// Token: 0x17000039 RID: 57
	public float this[int int_0]
	{
		get
		{
			if (int_0 < 3)
			{
				return this.m_b1[int_0];
			}
			return this.m_b2[int_0 - 3];
		}
		set
		{
			if (int_0 < 3)
			{
				this.m_b1[int_0] = value;
			}
			else
			{
				this.m_b2[int_0 - 3] = value;
			}
		}
	}

	// Token: 0x040004B9 RID: 1209
	public static QEMVectorN s_tempVector;

	// Token: 0x040004BA RID: 1210
	public static int s_n;

	// Token: 0x040004BB RID: 1211
	public Vector3 m_b1;

	// Token: 0x040004BC RID: 1212
	public QEMVectorAttribute m_b2;
}
