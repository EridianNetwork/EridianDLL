using System;
using UnityEngine;

// Token: 0x02000A89 RID: 2697
public class BolBitArray
{
	// Token: 0x060048F1 RID: 18673 RVA: 0x0012F8CC File Offset: 0x0012DACC
	public BolBitArray(int int_0)
	{
		int num = int_0 / 32 + ((int_0 % 32 != 0) ? 1 : 0);
		this.data = new uint[num];
		this.size = int_0;
	}

	// Token: 0x17000774 RID: 1908
	// (get) Token: 0x060048F2 RID: 18674 RVA: 0x0002FA3D File Offset: 0x0002DC3D
	// (set) Token: 0x060048F3 RID: 18675 RVA: 0x0002FA45 File Offset: 0x0002DC45
	public int size { get; private set; }

	// Token: 0x060048F4 RID: 18676 RVA: 0x0012F904 File Offset: 0x0012DB04
	public void method_0(int int_0, bool bool_0)
	{
		int num = int_0 / 32;
		int num2 = int_0 % 32;
		if (bool_0)
		{
			this.data[num] |= 1U << num2;
		}
		else
		{
			this.data[num] &= ~(1U << num2);
		}
	}

	// Token: 0x060048F5 RID: 18677 RVA: 0x0012F950 File Offset: 0x0012DB50
	public bool method_1(int int_0)
	{
		int num = int_0 / 32;
		int num2 = int_0 % 32;
		return ((ulong)this.data[num] & (ulong)(1L << (num2 & 31))) != 0UL;
	}

	// Token: 0x060048F6 RID: 18678 RVA: 0x0012F988 File Offset: 0x0012DB88
	public void method_2(int int_0)
	{
		this.size = int_0;
		if (int_0 > this.data.Length * 32)
		{
			int num = int_0 / 32 + ((int_0 % 32 != 0) ? 1 : 0);
			this.data = new uint[num];
		}
	}

	// Token: 0x060048F7 RID: 18679 RVA: 0x0012F9C8 File Offset: 0x0012DBC8
	public bool method_3(BolBitArray bolBitArray_0)
	{
		bool flag = true;
		if (bolBitArray_0.size != this.size)
		{
			return false;
		}
		for (int i = 0; i < this.data.Length; i++)
		{
			flag &= this.data[i] == bolBitArray_0.data[i];
		}
		return flag;
	}

	// Token: 0x060048F8 RID: 18680 RVA: 0x0012FA10 File Offset: 0x0012DC10
	public void method_4()
	{
		for (int i = 0; i < this.data.Length; i++)
		{
			this.data[i] = uint.MaxValue;
		}
	}

	// Token: 0x060048F9 RID: 18681 RVA: 0x0012FA3C File Offset: 0x0012DC3C
	public void method_5()
	{
		for (int i = 0; i < this.data.Length; i++)
		{
			this.data[i] = 0U;
		}
	}

	// Token: 0x060048FA RID: 18682 RVA: 0x0012FA68 File Offset: 0x0012DC68
	public bool method_6(BolBitArray bolBitArray_0)
	{
		if (bolBitArray_0.size == this.size)
		{
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] &= bolBitArray_0.data[i];
			}
			return true;
		}
		return false;
	}

	// Token: 0x060048FB RID: 18683 RVA: 0x0012FAB4 File Offset: 0x0012DCB4
	public bool method_7(BolBitArray bolBitArray_0)
	{
		if (bolBitArray_0.size == this.size)
		{
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] |= bolBitArray_0.data[i];
			}
			return true;
		}
		return false;
	}

	// Token: 0x060048FC RID: 18684 RVA: 0x0012FB00 File Offset: 0x0012DD00
	public BolBitArray method_8()
	{
		BolBitArray bolBitArray = new BolBitArray(this.size);
		int num = Mathf.Min(this.data.Length, bolBitArray.data.Length);
		for (int i = 0; i < num; i++)
		{
			bolBitArray.data[i] = this.data[i];
		}
		return bolBitArray;
	}

	// Token: 0x060048FD RID: 18685 RVA: 0x0012F950 File Offset: 0x0012DB50
	private bool method_9(int int_0)
	{
		int num = int_0 / 32;
		int num2 = int_0 % 32;
		return ((ulong)this.data[num] & (ulong)(1L << (num2 & 31))) != 0UL;
	}

	// Token: 0x060048FE RID: 18686 RVA: 0x0012FB4C File Offset: 0x0012DD4C
	public override string ToString()
	{
		string text = string.Empty;
		for (int i = 0; i < this.data.Length * 32; i++)
		{
			text += ((!this.method_9(i)) ? 0 : 1);
		}
		return text + ":" + this.size;
	}

	// Token: 0x04003582 RID: 13698
	private uint[] data;
}
