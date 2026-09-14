using System;

// Token: 0x02000554 RID: 1364
public class SlotContainer<T> : SlotContainer where T : Slot, new()
{
	// Token: 0x040017BD RID: 6077
	public T[] m_slots = new T[0];
}
