using System;

// Token: 0x020000D1 RID: 209
public class BinaryHeap
{
	// Token: 0x060004E3 RID: 1251 RVA: 0x00006652 File Offset: 0x00004852
	public BinaryHeap(QEMEdge[] qemedge_0)
	{
		this.m_array = qemedge_0;
		this.m_heapSize = this.m_array.Length;
		this.method_5();
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00006675 File Offset: 0x00004875
	public QEMEdge method_0()
	{
		return this.method_1(0);
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x0004C0C0 File Offset: 0x0004A2C0
	public QEMEdge method_1(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_heapSize)
		{
			this.method_6(int_0, --this.m_heapSize);
			this.method_7(int_0);
			return this.m_array[this.m_heapSize];
		}
		return null;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x0000667E File Offset: 0x0000487E
	public int method_2()
	{
		return this.m_heapSize;
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00006686 File Offset: 0x00004886
	public void method_3(int int_0)
	{
		this.method_8(int_0);
		this.method_7(int_0);
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00006696 File Offset: 0x00004896
	public QEMEdge method_4(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_heapSize)
		{
			return this.m_array[int_0];
		}
		return null;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x0004C108 File Offset: 0x0004A308
	private void method_5()
	{
		for (int i = this.m_heapSize / 2 - 1; i >= 0; i--)
		{
			this.method_7(i);
		}
		for (int j = 0; j < this.m_heapSize; j++)
		{
			this.m_array[j].m_index = j;
		}
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x0004C150 File Offset: 0x0004A350
	private void method_6(int int_0, int int_1)
	{
		if (int_0 != int_1)
		{
			QEMEdge qemedge = this.m_array[int_0];
			this.m_array[int_0] = this.m_array[int_1];
			this.m_array[int_1] = qemedge;
			this.m_array[int_0].m_index = int_0;
			this.m_array[int_1].m_index = int_1;
		}
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x0004C1A0 File Offset: 0x0004A3A0
	public void method_7(int int_0)
	{
		int num = int_0;
		int num2 = this.method_10(num);
		while (num >= 0 && num < this.m_heapSize && num2 >= 0)
		{
			int num3 = num2 + 1;
			if (num3 < this.m_heapSize && this.m_array[num3].method_9() < this.m_array[num2].method_9())
			{
				num2 = num3;
			}
			if (this.m_array[num2].method_9() < this.m_array[num].method_9())
			{
				this.method_6(num, num2);
				num = num2;
				num2 = this.method_10(num);
			}
			else
			{
				int num4 = -1;
				num2 = -1;
				num = num4;
			}
		}
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x0004C22C File Offset: 0x0004A42C
	private void method_8(int int_0)
	{
		int num = int_0;
		int num2 = this.method_9(num);
		while (num >= 0 && num < this.m_heapSize && num2 >= 0)
		{
			if (this.m_array[num].method_9() < this.m_array[num2].method_9())
			{
				this.method_6(num, num2);
				num = num2;
				num2 = this.method_9(num);
			}
			else
			{
				int num3 = -1;
				num2 = -1;
				num = num3;
			}
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x000066AF File Offset: 0x000048AF
	private int method_9(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_heapSize)
		{
			return (int_0 - 1) / 2;
		}
		return -1;
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x000066C5 File Offset: 0x000048C5
	private int method_10(int int_0)
	{
		if (int_0 >= 0)
		{
			int_0 = 2 * int_0 + 1;
			if (int_0 < this.m_heapSize)
			{
				return int_0;
			}
		}
		return -1;
	}

	// Token: 0x0400049B RID: 1179
	private QEMEdge[] m_array;

	// Token: 0x0400049C RID: 1180
	private int m_heapSize;
}
