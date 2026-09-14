using System;
using UnityEngine;

// Token: 0x0200049E RID: 1182
public class LootingSlot : MonoBehaviour
{
	// Token: 0x0400145F RID: 5215
	public LootingSlot.LootingSlotType m_slotType;

	// Token: 0x04001460 RID: 5216
	public int m_lootNumber;

	// Token: 0x04001461 RID: 5217
	public int m_lootIndex;

	// Token: 0x04001462 RID: 5218
	public float m_lootLightPillarDelay;

	// Token: 0x04001463 RID: 5219
	public float m_lootPickableDelay;

	// Token: 0x0200049F RID: 1183
	public enum LootingSlotType
	{
		// Token: 0x04001465 RID: 5221
		Item,
		// Token: 0x04001466 RID: 5222
		Weapon
	}
}
