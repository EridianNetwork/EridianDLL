using System;
using Core;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class QEMMatrix
{
	// Token: 0x06000552 RID: 1362 RVA: 0x00006BA0 File Offset: 0x00004DA0
	public QEMMatrix()
	{
		this.m_A = new QEMMatrixNxN();
		this.m_b = new QEMVectorN();
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0004DCA8 File Offset: 0x0004BEA8
	public static void smethod_0(int int_0)
	{
		if (int_0 < 3)
		{
			DebugUtils.Log(LogCategory.Graphics, "size < 3");
			int_0 = 3;
		}
		QEMVectorN.s_n = int_0;
		QEMMatrix.s_n = int_0;
		QEMVectorN.s_tempVector = new QEMVectorN();
		QEMMatrix.s_tempQEMMatrix0 = new QEMMatrix();
		QEMMatrix.s_tempQEMMatrix1 = new QEMMatrix();
		QEMMatrix.s_tempQEMMatrix2 = new QEMMatrix();
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0004DD00 File Offset: 0x0004BF00
	public static void smethod_1(QEMMatrix qemmatrix_0, QEMMatrix qemmatrix_1, ref QEMMatrix qemmatrix_2)
	{
		QEMMatrixNxN.smethod_0(qemmatrix_0.m_A, qemmatrix_1.m_A, ref qemmatrix_2.m_A);
		QEMVectorN.smethod_0(qemmatrix_0.m_b, qemmatrix_1.m_b, ref qemmatrix_2.m_b);
		qemmatrix_2.m_c = qemmatrix_0.m_c + qemmatrix_1.m_c;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00006BC6 File Offset: 0x00004DC6
	public void method_0(QEMMatrix qemmatrix_0)
	{
		this.m_A.method_4(qemmatrix_0.m_A);
		this.m_b.method_7(qemmatrix_0.m_b);
		this.m_c += qemmatrix_0.m_c;
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x00006BFD File Offset: 0x00004DFD
	public void method_1(float float_0)
	{
		this.m_A.method_2(float_0);
		this.m_b.method_6(float_0);
		this.m_c *= float_0;
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0004DD54 File Offset: 0x0004BF54
	public float method_2(QEMVectorN qemvectorN_0)
	{
		this.m_A.method_3(qemvectorN_0, ref QEMVectorN.s_tempVector);
		float num = QEMVectorN.smethod_1(QEMVectorN.s_tempVector, qemvectorN_0);
		num += 2f * QEMVectorN.smethod_1(qemvectorN_0, this.m_b);
		return num + this.m_c;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x00006C25 File Offset: 0x00004E25
	public void method_3()
	{
		this.m_A.method_5();
		this.m_b.method_4();
		this.m_c = 0f;
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0004DDA0 File Offset: 0x0004BFA0
	public void method_4(Vector3 vector3_0, float float_0)
	{
		float x = vector3_0.x;
		float y = vector3_0.y;
		float z = vector3_0.z;
		this.m_A.m_AC[0] = x * x;
		this.m_A.m_AC[1] = x * y;
		this.m_A.m_AC[2] = y * y;
		this.m_A.m_AC[3] = x * z;
		this.m_A.m_AC[4] = y * z;
		this.m_A.m_AC[5] = z * z;
		this.m_A.m_diagonal = 1f;
		Vector3 vector = float_0 * vector3_0;
		this.m_b[0] = vector.x;
		this.m_b[1] = vector.y;
		this.m_b[2] = vector.z;
		this.m_c = float_0 * float_0;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0004DE98 File Offset: 0x0004C098
	private bool method_5(Matrix4x4 matrix4x4_0, float float_0)
	{
		float num = matrix4x4_0.m00 * matrix4x4_0.m11 * matrix4x4_0.m22 * matrix4x4_0.m33 + matrix4x4_0.m01 * matrix4x4_0.m12 * matrix4x4_0.m23 * matrix4x4_0.m30 + matrix4x4_0.m02 * matrix4x4_0.m13 * matrix4x4_0.m20 * matrix4x4_0.m31 + matrix4x4_0.m03 * matrix4x4_0.m10 * matrix4x4_0.m21 * matrix4x4_0.m32;
		num -= matrix4x4_0.m03 * matrix4x4_0.m12 * matrix4x4_0.m21 * matrix4x4_0.m30 + matrix4x4_0.m13 * matrix4x4_0.m22 * matrix4x4_0.m31 * matrix4x4_0.m00 + matrix4x4_0.m23 * matrix4x4_0.m32 * matrix4x4_0.m01 * matrix4x4_0.m10 + matrix4x4_0.m33 * matrix4x4_0.m02 * matrix4x4_0.m11 * matrix4x4_0.m20;
		num *= num;
		return num > float_0;
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0004DFB4 File Offset: 0x0004C1B4
	public bool method_6(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, float float_0, float float_1, float float_2, int int_0)
	{
		Matrix4x4 matrix4x = default(Matrix4x4);
		matrix4x.SetRow(0, new Vector4(vector3_0.x, vector3_0.y, vector3_0.z, 1f));
		matrix4x.SetRow(1, new Vector4(vector3_1.x, vector3_1.y, vector3_1.z, 1f));
		matrix4x.SetRow(2, new Vector4(vector3_2.x, vector3_2.y, vector3_2.z, 1f));
		matrix4x.SetRow(3, new Vector4(vector3_3.x, vector3_3.y, vector3_3.z, 0f));
		Vector4 vector = matrix4x.inverse * new Vector4(float_0, float_1, float_2, 0f);
		float x = vector.x;
		float y = vector.y;
		float z = vector.z;
		float w = vector.w;
		QEMMatrixNxN a = this.m_A;
		ref QEMMatrix3x3 ptr = ref a.m_AC;
		int num = 0;
		float num2 = ptr[0];
		a.m_AC[num] = num2 + x * x;
		QEMMatrixNxN a2 = this.m_A;
		ref QEMMatrix3x3 ptr2 = ref a2.m_AC;
		int num3 = 1;
		num2 = ptr2[1];
		a2.m_AC[num3] = num2 + x * y;
		QEMMatrixNxN a3 = this.m_A;
		ref QEMMatrix3x3 ptr3 = ref a3.m_AC;
		int num4 = 2;
		num2 = ptr3[2];
		a3.m_AC[num4] = num2 + y * y;
		QEMMatrixNxN a4 = this.m_A;
		ref QEMMatrix3x3 ptr4 = ref a4.m_AC;
		int num5 = 3;
		num2 = ptr4[3];
		a4.m_AC[num5] = num2 + x * z;
		QEMMatrixNxN a5 = this.m_A;
		ref QEMMatrix3x3 ptr5 = ref a5.m_AC;
		int num6 = 4;
		num2 = ptr5[4];
		a5.m_AC[num6] = num2 + y * z;
		QEMMatrixNxN a6 = this.m_A;
		ref QEMMatrix3x3 ptr6 = ref a6.m_AC;
		int num7 = 5;
		num2 = ptr6[5];
		a6.m_AC[num7] = num2 + z * z;
		this.m_A.m_AB.method_0(int_0, new Vector3(-x, -y, -z));
		QEMVectorN b;
		QEMVectorN qemvectorN = (b = this.m_b);
		int num8 = 0;
		num2 = b[0];
		qemvectorN[num8] = num2 + w * x;
		QEMVectorN b2;
		QEMVectorN qemvectorN2 = (b2 = this.m_b);
		int num9 = 1;
		num2 = b2[1];
		qemvectorN2[num9] = num2 + w * y;
		QEMVectorN b3;
		QEMVectorN qemvectorN3 = (b3 = this.m_b);
		int num10 = 2;
		num2 = b3[2];
		qemvectorN3[num10] = num2 + w * z;
		this.m_b[int_0 + 3] = -w;
		this.m_c += w * w;
		return true;
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0004E224 File Offset: 0x0004C424
	public bool method_7(float float_0, int int_0)
	{
		this.m_A.m_AB.method_0(int_0, new Vector3(-0f, -0f, -0f));
		this.m_b[int_0 + 3] = -float_0;
		this.m_c += float_0 * float_0;
		return true;
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0004E27C File Offset: 0x0004C47C
	public bool method_8(ref QEMVectorN qemvectorN_0)
	{
		Vector3 vector = default(Vector3);
		QEMMatrix3x3 qemmatrix3x = QEMMatrix3x3.smethod_0(this.m_A.m_AC, this.m_A.m_AB.method_5().method_0(-1f / this.m_A.m_diagonal));
		float num = qemmatrix3x.method_5();
		if (Mathf.Abs(num) > 1E-05f)
		{
			this.m_b.method_6(-1f);
			Vector3 vector2 = this.m_A.m_AB.method_3(this.m_b.m_b2) * (-1f / this.m_A.m_diagonal) + this.m_b.m_b1;
			vector = qemmatrix3x.method_6().method_2(vector2);
			this.m_A.m_AB.method_4(vector, ref QEMVectorN.s_tempVector.m_b2);
			QEMVectorN.s_tempVector.m_b2.method_2(-1f);
			QEMVectorAttribute.smethod_0(this.m_b.m_b2, QEMVectorN.s_tempVector.m_b2, ref qemvectorN_0.m_b2);
			qemvectorN_0.m_b2.method_2(1f / this.m_A.m_diagonal);
			qemvectorN_0.m_b1 = vector;
			this.m_b.method_6(-1f);
			return true;
		}
		return false;
	}

	// Token: 0x040004C0 RID: 1216
	public static QEMMatrix s_tempQEMMatrix0;

	// Token: 0x040004C1 RID: 1217
	public static QEMMatrix s_tempQEMMatrix1;

	// Token: 0x040004C2 RID: 1218
	public static QEMMatrix s_tempQEMMatrix2;

	// Token: 0x040004C3 RID: 1219
	public static int s_n = 3;

	// Token: 0x040004C4 RID: 1220
	private QEMMatrixNxN m_A;

	// Token: 0x040004C5 RID: 1221
	private QEMVectorN m_b;

	// Token: 0x040004C6 RID: 1222
	private float m_c;
}
