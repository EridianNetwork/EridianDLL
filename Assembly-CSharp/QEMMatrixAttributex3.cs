using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class QEMMatrixAttributex3
{
	// Token: 0x06000529 RID: 1321 RVA: 0x0004D1F8 File Offset: 0x0004B3F8
	public QEMMatrixAttributex3()
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_b[i] = new QEMVectorAttribute();
		}
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x0004D230 File Offset: 0x0004B430
	public void method_0(int int_0, Vector3 vector3_0)
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_b[i][int_0] = vector3_0[i];
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x0004D260 File Offset: 0x0004B460
	public void method_1(QEMMatrixAttributex3 qemmatrixAttributex3_0)
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_b[i].method_3(qemmatrixAttributex3_0.m_b[i]);
		}
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x0004D290 File Offset: 0x0004B490
	public static void smethod_0(QEMMatrixAttributex3 qemmatrixAttributex3_0, QEMMatrixAttributex3 qemmatrixAttributex3_1, ref QEMMatrixAttributex3 qemmatrixAttributex3_2)
	{
		for (int i = 0; i < 3; i++)
		{
			QEMVectorAttribute.smethod_0(qemmatrixAttributex3_0.m_b[i], qemmatrixAttributex3_1.m_b[i], ref qemmatrixAttributex3_2.m_b[i]);
		}
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x0004D2CC File Offset: 0x0004B4CC
	public void method_2(float float_0)
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_b[i].method_2(float_0);
		}
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x0004D2F4 File Offset: 0x0004B4F4
	public Vector3 method_3(QEMVectorAttribute qemvectorAttribute_0)
	{
		Vector3 vector = default(Vector3);
		for (int i = 0; i < 3; i++)
		{
			vector[i] = QEMVectorAttribute.smethod_1(this.m_b[i], qemvectorAttribute_0);
		}
		return vector;
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x0004D32C File Offset: 0x0004B52C
	public void method_4(Vector3 vector3_0, ref QEMVectorAttribute qemvectorAttribute_0)
	{
		int num = this.m_b[0].method_1();
		for (int i = 0; i < num; i++)
		{
			qemvectorAttribute_0[i] = vector3_0.x * this.m_b[0][i] + vector3_0.y * this.m_b[1][i] + vector3_0.z * this.m_b[2][i];
		}
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x0004D3A0 File Offset: 0x0004B5A0
	public QEMMatrix3x3 method_5()
	{
		return new QEMMatrix3x3
		{
			m_00 = QEMVectorAttribute.smethod_1(this.m_b[0], this.m_b[0]),
			m_01 = QEMVectorAttribute.smethod_1(this.m_b[0], this.m_b[1]),
			m_02 = QEMVectorAttribute.smethod_1(this.m_b[0], this.m_b[2]),
			m_11 = QEMVectorAttribute.smethod_1(this.m_b[1], this.m_b[1]),
			m_12 = QEMVectorAttribute.smethod_1(this.m_b[1], this.m_b[2]),
			m_22 = QEMVectorAttribute.smethod_1(this.m_b[2], this.m_b[2])
		};
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x0004D460 File Offset: 0x0004B660
	public void method_6()
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_b[i].method_0();
		}
	}

	// Token: 0x040004B2 RID: 1202
	public QEMVectorAttribute[] m_b = new QEMVectorAttribute[3];
}
