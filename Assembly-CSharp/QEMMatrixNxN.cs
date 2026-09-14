using System;

// Token: 0x020000DC RID: 220
public class QEMMatrixNxN
{
	// Token: 0x0600054A RID: 1354 RVA: 0x0004DB54 File Offset: 0x0004BD54
	public QEMMatrixNxN()
	{
		this.m_AC = default(QEMMatrix3x3);
		this.m_AB = new QEMMatrixAttributex3();
		this.m_diagonal = 0f;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00006B16 File Offset: 0x00004D16
	public int method_0()
	{
		return QEMVectorN.s_n;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x0004DB8C File Offset: 0x0004BD8C
	public float method_1(int int_0, int int_1)
	{
		int num = int_0;
		int num2 = int_1;
		if (num < num2)
		{
			num = int_1;
			num2 = int_0;
		}
		if (num < 3 && num2 < 3)
		{
			return this.m_AC[num + num2 + num / 2];
		}
		if (num < 3 || num2 < 3)
		{
			return this.m_AB.m_b[num2][num - 3];
		}
		if (num == num2)
		{
			return this.m_diagonal;
		}
		return 0f;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x00006B1D File Offset: 0x00004D1D
	public void method_2(float float_0)
	{
		this.m_AC.method_0(float_0);
		this.m_AB.method_2(float_0);
		this.m_diagonal *= float_0;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0004DBF0 File Offset: 0x0004BDF0
	public void method_3(QEMVectorN qemvectorN_0, ref QEMVectorN qemvectorN_1)
	{
		int num = qemvectorN_0.method_5();
		for (int i = 0; i < num; i++)
		{
			qemvectorN_1[i] = 0f;
			for (int j = 0; j < num; j++)
			{
				QEMVectorN qemvectorN2;
				QEMVectorN qemvectorN = (qemvectorN2 = qemvectorN_1);
				int num3;
				int num2 = (num3 = i);
				float num4 = qemvectorN2[num3];
				qemvectorN[num2] = num4 + qemvectorN_0[j] * this.method_1(i, j);
			}
		}
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0004DC54 File Offset: 0x0004BE54
	public static void smethod_0(QEMMatrixNxN qemmatrixNxN_0, QEMMatrixNxN qemmatrixNxN_1, ref QEMMatrixNxN qemmatrixNxN_2)
	{
		qemmatrixNxN_2.m_AC = QEMMatrix3x3.smethod_0(qemmatrixNxN_0.m_AC, qemmatrixNxN_1.m_AC);
		QEMMatrixAttributex3.smethod_0(qemmatrixNxN_0.m_AB, qemmatrixNxN_1.m_AB, ref qemmatrixNxN_2.m_AB);
		qemmatrixNxN_2.m_diagonal = qemmatrixNxN_0.m_diagonal + qemmatrixNxN_1.m_diagonal;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00006B46 File Offset: 0x00004D46
	public void method_4(QEMMatrixNxN qemmatrixNxN_0)
	{
		this.m_AC.method_3(qemmatrixNxN_0.m_AC);
		this.m_AB.method_1(qemmatrixNxN_0.m_AB);
		this.m_diagonal += qemmatrixNxN_0.m_diagonal;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x00006B7D File Offset: 0x00004D7D
	public void method_5()
	{
		this.m_AC.method_4();
		this.m_AB.method_6();
		this.m_diagonal = 0f;
	}

	// Token: 0x040004BD RID: 1213
	public QEMMatrix3x3 m_AC;

	// Token: 0x040004BE RID: 1214
	public QEMMatrixAttributex3 m_AB;

	// Token: 0x040004BF RID: 1215
	public float m_diagonal;
}
