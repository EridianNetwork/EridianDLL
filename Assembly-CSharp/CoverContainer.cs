using System;

// Token: 0x02000440 RID: 1088
public class CoverContainer : SlotContainer
{
	// Token: 0x06001AE3 RID: 6883 RVA: 0x00088EF4 File Offset: 0x000870F4
	public void method_0()
	{
		if (this.m_coverSlots != null)
		{
			this.m_slots = new CoverSlot[this.m_coverSlots.Length];
			for (int i = 0; i < this.m_coverSlots.Length; i++)
			{
				this.m_slots[i] = this.m_coverSlots[i];
				this.m_slots[i].vmethod_1(this);
			}
			this.m_coverSlots = null;
		}
	}

	// Token: 0x040011AE RID: 4526
	public CoverSlot[] m_coverSlots = new CoverSlot[0];

	// Token: 0x040011AF RID: 4527
	public CoverSlot[] m_slots = new CoverSlot[0];
}
