using System;

// Token: 0x020000D8 RID: 216
public class QEMVectorAttribute
{
	// Token: 0x06000520 RID: 1312 RVA: 0x000069C7 File Offset: 0x00004BC7
	public QEMVectorAttribute()
	{
		this.m_vector = new float[QEMVectorN.s_n - 3];
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x0004D0E8 File Offset: 0x0004B2E8
	public void method_0()
	{
		int num = this.method_1();
		for (int i = 0; i < num; i++)
		{
			this.m_vector[i] = 0f;
		}
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x000069E1 File Offset: 0x00004BE1
	public int method_1()
	{
		return this.m_vector.Length;
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x0004D118 File Offset: 0x0004B318
	public void method_2(float float_0)
	{
		int num = this.method_1();
		for (int i = 0; i < num; i++)
		{
			this.m_vector[i] *= float_0;
		}
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x0004D14C File Offset: 0x0004B34C
	public void method_3(QEMVectorAttribute qemvectorAttribute_0)
	{
		int num = this.method_1();
		for (int i = 0; i < num; i++)
		{
			this.m_vector[i] += qemvectorAttribute_0[i];
		}
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x0004D184 File Offset: 0x0004B384
	public static void smethod_0(QEMVectorAttribute qemvectorAttribute_0, QEMVectorAttribute qemvectorAttribute_1, ref QEMVectorAttribute qemvectorAttribute_2)
	{
		int num = qemvectorAttribute_2.method_1();
		for (int i = 0; i < num; i++)
		{
			qemvectorAttribute_2[i] = qemvectorAttribute_0[i] + qemvectorAttribute_1[i];
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x0004D1BC File Offset: 0x0004B3BC
	public static float smethod_1(QEMVectorAttribute qemvectorAttribute_0, QEMVectorAttribute qemvectorAttribute_1)
	{
		float num = 0f;
		int num2 = qemvectorAttribute_0.method_1();
		for (int i = 0; i < num2; i++)
		{
			num += qemvectorAttribute_0[i] * qemvectorAttribute_1[i];
		}
		return num;
	}

	// Token: 0x17000037 RID: 55
	public float this[int int_0]
	{
		get
		{
			return this.m_vector[int_0];
		}
		set
		{
			this.m_vector[int_0] = value;
		}
	}

	// Token: 0x040004B1 RID: 1201
	private float[] m_vector;
}
