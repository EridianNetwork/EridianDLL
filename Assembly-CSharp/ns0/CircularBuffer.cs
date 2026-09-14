using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ns0
{
	// Token: 0x02000274 RID: 628
	public class CircularBuffer<T> : IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>
	{
		// Token: 0x06000D55 RID: 3413 RVA: 0x0000C6CA File Offset: 0x0000A8CA
		public CircularBuffer(int int_3)
		{
			if (int_3 <= 0)
			{
				throw new ArgumentException("Must be greater than zero", "capacity");
			}
			this.Capacity = int_3;
			this.gparam_0 = new T[int_3];
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x0000311D File Offset: 0x0000131D
		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x0000C6F9 File Offset: 0x0000A8F9
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x17000080 RID: 128
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
				{
					throw new IndexOutOfRangeException();
				}
				int num = (this.int_0 - this.Count + index + this.Capacity) % this.Capacity;
				return this.gparam_0[num];
			}
			set
			{
				this.Insert(index, value);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x0000C70B File Offset: 0x0000A90B
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x0000C713 File Offset: 0x0000A913
		public int Capacity { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x0000C71C File Offset: 0x0000A91C
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x0000C724 File Offset: 0x0000A924
		public int Count { get; private set; }

		// Token: 0x06000D5E RID: 3422 RVA: 0x0006F934 File Offset: 0x0006DB34
		public void Add(T item)
		{
			if (this.int_0 == 2147483647)
			{
				this.int_0 %= this.Capacity;
			}
			this.gparam_0[this.int_0++ % this.Capacity] = item;
			if (this.Count < this.Capacity)
			{
				this.Count++;
			}
			this.long_0 += 1L;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0006F9B8 File Offset: 0x0006DBB8
		public void Clear()
		{
			for (int i = 0; i < this.Capacity; i++)
			{
				this.gparam_0[i] = default(T);
			}
			this.int_0 = 0;
			this.Count = 0;
			this.long_0 += 1L;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x0006FA10 File Offset: 0x0006DC10
		public bool Contains(T item)
		{
			int num = this.IndexOf(item);
			return num != -1;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x0006FA2C File Offset: 0x0006DC2C
		public void CopyTo(T[] array, int arrayIndex)
		{
			int num = array.Length;
			for (int i = 0; i < this.Count; i++)
			{
				array[(i + arrayIndex) % num] = this.gparam_0[(this.int_0 - this.Count + i + this.Capacity) % this.Capacity];
			}
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x0006FA84 File Offset: 0x0006DC84
		[DebuggerHidden]
		public IEnumerator<T> GetEnumerator()
		{
			CircularBuffer<T>.Class0 @class = new CircularBuffer<T>.Class0();
			@class.gclass2_0 = this;
			return @class;
		}

		private sealed class Class0 : IEnumerator<T>, IDisposable, IEnumerator
		{
			public CircularBuffer<T> gclass2_0;

			private int index_ = -1;

			public T Current => gclass2_0[index_];

			object IEnumerator.Current => Current;

			public bool MoveNext()
			{
				index_++;
				return index_ < gclass2_0.Count;
			}

			public void Reset()
			{
				index_ = -1;
			}

			public void Dispose()
			{
			}
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x0006FAA0 File Offset: 0x0006DCA0
		public int IndexOf(T item)
		{
			for (int i = 0; i < this.Count; i++)
			{
				T t = this.gparam_0[(this.int_0 - this.Count + i + this.Capacity) % this.Capacity];
				if (item == null && t == null)
				{
					return i;
				}
				if (item != null && item.Equals(t))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x0006FB1C File Offset: 0x0006DD1C
		public void Insert(int index, T item)
		{
			if (index < 0 || index > this.Count)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == this.Count)
			{
				this.Add(item);
				return;
			}
			int num = Math.Min(this.Count, this.Capacity - 1) - index;
			int num2 = (this.int_0 - this.Count + index + this.Capacity) % this.Capacity;
			for (int i = num2 + num; i > num2; i--)
			{
				int num3 = i % this.Capacity;
				int num4 = (i - 1 + this.Capacity) % this.Capacity;
				this.gparam_0[num3] = this.gparam_0[num4];
			}
			this.gparam_0[num2] = item;
			if (this.Count < this.Capacity)
			{
				this.Count++;
				this.int_0++;
			}
			this.long_0 += 1L;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x0006FC1C File Offset: 0x0006DE1C
		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num == -1)
			{
				return false;
			}
			this.RemoveAt(num);
			return true;
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0006FC40 File Offset: 0x0006DE40
		public void RemoveAt(int index)
		{
			if (index >= 0 && index < this.Count)
			{
				for (int i = index; i < this.Count - 1; i++)
				{
					int num = (this.int_0 - this.Count + i + this.Capacity) % this.Capacity;
					int num2 = (this.int_0 - this.Count + i + 1 + this.Capacity) % this.Capacity;
					this.gparam_0[num] = this.gparam_0[num2];
				}
				int num3 = (this.int_0 - 1 + this.Capacity) % this.Capacity;
				this.gparam_0[num3] = default(T);
				this.int_0--;
				this.Count--;
				this.long_0 += 1L;
				return;
			}
			throw new IndexOutOfRangeException();
		}

		// Token: 0x04000C29 RID: 3113
		private T[] gparam_0;

		// Token: 0x04000C2A RID: 3114
		private int int_0;

		// Token: 0x04000C2B RID: 3115
		private long long_0;

		// Token: 0x04000C2C RID: 3116
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000C2D RID: 3117
		[CompilerGenerated]
		private int int_2;
	}
}
