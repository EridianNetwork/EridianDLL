using System;
using Core;

// Token: 0x02000AA1 RID: 2721
public class RingBuffer
{
	// Token: 0x060049B9 RID: 18873 RVA: 0x0003037C File Offset: 0x0002E57C
	public RingBuffer(int int_0, bool bool_0)
	{
		this.m_tail = 0;
		this.m_head = 0;
		this.m_cap = int_0;
		this.m_discard = bool_0;
		this.m_buffer = new object[this.m_cap];
		this.m_empty = true;
	}

	// Token: 0x060049BA RID: 18874 RVA: 0x0013203C File Offset: 0x0013023C
	public bool Enqueue(object object_0)
	{
		this.m_empty = false;
		if (!this.m_full)
		{
			this.m_buffer[this.m_tail] = object_0;
			this.m_tail = this.GetNextIndex(this.m_tail);
			if (this.m_tail == this.m_head)
			{
				this.m_full = true;
			}
		}
		else
		{
			if (!this.m_discard)
			{
				return false;
			}
			this.m_buffer[this.m_tail] = object_0;
			this.m_tail = this.GetNextIndex(this.m_tail);
			this.m_head = this.GetNextIndex(this.m_head);
		}
		return true;
	}

	// Token: 0x060049BB RID: 18875 RVA: 0x000303B8 File Offset: 0x0002E5B8
	public object PeekLast()
	{
		return this.m_buffer[this.GetPreviousIndex(this.m_tail)];
	}

	// Token: 0x060049BC RID: 18876 RVA: 0x000303CD File Offset: 0x0002E5CD
	public object PeekSecondLast()
	{
		return this.m_buffer[this.GetPreviousIndexWithOffset(this.m_tail, 2)];
	}

	// Token: 0x060049BD RID: 18877 RVA: 0x000303E3 File Offset: 0x0002E5E3
	public object PeekAt(int int_0)
	{
		if (int_0 < this.GetCount() && int_0 >= 0)
		{
			return this.m_buffer[this.GetIndexOffsetForward(this.m_head, int_0)];
		}
		if (int_0 > this.GetCount())
		{
			DebugUtils.LogWarning(LogCategory.System, "try to access beyond buffer");
		}
		return null;
	}

	// Token: 0x060049BE RID: 18878 RVA: 0x001320CC File Offset: 0x001302CC
	public object Dequeue()
	{
		this.m_full = false;
		if (!this.m_empty)
		{
			int head = this.m_head;
			this.m_head = this.GetNextIndex(this.m_head);
			if (this.m_head == this.m_tail)
			{
				this.m_empty = true;
			}
			return this.m_buffer[head];
		}
		return null;
	}

	// Token: 0x060049BF RID: 18879 RVA: 0x0003041D File Offset: 0x0002E61D
	private int GetNextIndex(int int_0)
	{
		return (int_0 + 1) % this.m_cap;
	}

	// Token: 0x060049C0 RID: 18880 RVA: 0x00030429 File Offset: 0x0002E629
	private int GetPreviousIndex(int int_0)
	{
		if (int_0 == 0)
		{
			return this.m_cap - 1;
		}
		return (int_0 - 1) % this.m_cap;
	}

	// Token: 0x060049C1 RID: 18881 RVA: 0x00030441 File Offset: 0x0002E641
	private int GetIndexOffsetForward(int int_0, int int_1)
	{
		return (int_0 + int_1) % this.m_cap;
	}

	// Token: 0x060049C2 RID: 18882 RVA: 0x0003044D File Offset: 0x0002E64D
	private int GetPreviousIndexWithOffset(int int_0, int int_1)
	{
		return (int_0 + this.m_cap - int_1) % this.m_cap;
	}

	// Token: 0x060049C3 RID: 18883 RVA: 0x00132120 File Offset: 0x00130320
	public int GetCount()
	{
		if (this.m_full)
		{
			return this.m_cap;
		}
		if (this.m_empty)
		{
			return 0;
		}
		return (this.m_tail - this.m_head < 0) ? (this.m_tail - this.m_head + this.m_cap) : (this.m_tail - this.m_head);
	}

	// Token: 0x060049C4 RID: 18884 RVA: 0x00030460 File Offset: 0x0002E660
	public void Clear()
	{
		this.m_tail = this.m_head;
	}

	// Token: 0x060049C5 RID: 18885 RVA: 0x0003046E File Offset: 0x0002E66E
	public int GetCapacity()
	{
		return this.m_cap;
	}

	// Token: 0x040035ED RID: 13805
	private object[] m_buffer;

	// Token: 0x040035EE RID: 13806
	private int m_tail;

	// Token: 0x040035EF RID: 13807
	private int m_head;

	// Token: 0x040035F0 RID: 13808
	private int m_cap;

	// Token: 0x040035F1 RID: 13809
	private bool m_discard;

	// Token: 0x040035F2 RID: 13810
	private bool m_full;

	// Token: 0x040035F3 RID: 13811
	private bool m_empty;
}
