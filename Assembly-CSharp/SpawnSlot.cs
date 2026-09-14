using System;
using UnityEngine;

// Token: 0x0200055B RID: 1371
[Serializable]
public class SpawnSlot : Slot
{
	// Token: 0x0600232D RID: 9005 RVA: 0x00018291 File Offset: 0x00016491
	public override SlotContainer vmethod_0()
	{
		return this.m_container;
	}

	// Token: 0x0600232E RID: 9006 RVA: 0x00018299 File Offset: 0x00016499
	public override void vmethod_1(SlotContainer slotContainer_0)
	{
		this.m_container = (SpawnSlotContainer)slotContainer_0;
	}

	// Token: 0x0600232F RID: 9007 RVA: 0x000A6584 File Offset: 0x000A4784
	public override object Clone()
	{
		return (SpawnSlot)base.MemberwiseClone();
	}

	// Token: 0x040017CA RID: 6090
	[HideInInspector]
	public SpawnSlotContainer m_container;

	// Token: 0x040017CB RID: 6091
	public NpcSpawningSettings.InitialState m_initialState;

	// Token: 0x040017CC RID: 6092
	public bool m_bDefenseMode = true;

	// Token: 0x040017CD RID: 6093
	public bool m_bCombatSlot = true;

	// Token: 0x040017CE RID: 6094
	public float m_spawnDistance = 2f;
}
