using System;
using System.Collections.Generic;

// Token: 0x02000A88 RID: 2696
public class ArrayPool<T> where T : new()
{
	// Token: 0x060048EC RID: 18668 RVA: 0x0012F71C File Offset: 0x0012D91C
	public T[] method_0(int int_0)
	{
		List<T[]> list;
		this.m_Pool.TryGetValue(int_0, out list);
		if (list == null)
		{
			this.m_Pool[int_0] = new List<T[]>();
			T[] array = new T[int_0];
			this.method_1(this.m_Used, int_0, array);
			return array;
		}
		if (list.Count > 0)
		{
			T[] array2 = list[0];
			this.method_1(this.m_Used, int_0, array2);
			list.Remove(array2);
			return array2;
		}
		T[] array3 = new T[int_0];
		this.method_1(this.m_Used, int_0, array3);
		return array3;
	}

	// Token: 0x060048ED RID: 18669 RVA: 0x0012F7A4 File Offset: 0x0012D9A4
	private void method_1(Dictionary<int, List<T[]>> dictionary_0, int int_0, T[] gparam_0)
	{
		List<T[]> list;
		dictionary_0.TryGetValue(int_0, out list);
		if (list != null)
		{
			dictionary_0[int_0].Add(gparam_0);
		}
		else
		{
			dictionary_0[int_0] = new List<T[]>();
			dictionary_0[int_0].Add(gparam_0);
		}
	}

	// Token: 0x060048EE RID: 18670 RVA: 0x0012F7E8 File Offset: 0x0012D9E8
	private void method_2(Dictionary<int, List<T[]>> dictionary_0, int int_0, List<T[]> list_0)
	{
		List<T[]> list;
		dictionary_0.TryGetValue(int_0, out list);
		if (list != null)
		{
			dictionary_0[int_0].AddRange(list_0);
		}
		else
		{
			dictionary_0[int_0] = new List<T[]>();
			dictionary_0[int_0].AddRange(list_0);
		}
	}

	// Token: 0x060048EF RID: 18671 RVA: 0x0012F82C File Offset: 0x0012DA2C
	public void method_3(T[] gparam_0)
	{
		int num = gparam_0.Length;
		List<T[]> list;
		this.m_Used.TryGetValue(num, out list);
		if (list != null)
		{
			list.Remove(gparam_0);
			this.method_1(this.m_Pool, num, gparam_0);
		}
	}

	// Token: 0x060048F0 RID: 18672 RVA: 0x0012F868 File Offset: 0x0012DA68
	public void method_4()
	{
		Dictionary<int, List<T[]>>.Enumerator enumerator = this.m_Used.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<int, List<T[]>> pool = this.m_Pool;
			KeyValuePair<int, List<T[]>> keyValuePair = enumerator.Current;
			int key = keyValuePair.Key;
			KeyValuePair<int, List<T[]>> keyValuePair2 = enumerator.Current;
			this.method_2(pool, key, keyValuePair2.Value);
			KeyValuePair<int, List<T[]>> keyValuePair3 = enumerator.Current;
			keyValuePair3.Value.Clear();
		}
	}

	// Token: 0x04003580 RID: 13696
	public Dictionary<int, List<T[]>> m_Pool = new Dictionary<int, List<T[]>>();

	// Token: 0x04003581 RID: 13697
	public Dictionary<int, List<T[]>> m_Used = new Dictionary<int, List<T[]>>();
}
