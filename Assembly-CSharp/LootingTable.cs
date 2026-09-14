using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020004A1 RID: 1185
public class LootingTable : MonoBehaviour
{
	// Token: 0x06001FB0 RID: 8112 RVA: 0x0009B448 File Offset: 0x00099648
	public void Start()
	{
		this.m_treasureBoxTrigger = base.gameObject.GetComponent<TreasureBoxTrigger>();
		if (this.m_attach && this.m_treasureBoxTrigger != null)
		{
			this.m_weaponSlots = new List<GameObject[]>(0);
			this.m_itemSlots = new List<GameObject[]>(0);
			foreach (LootingSlot lootingSlot in base.gameObject.GetComponentsInChildren<LootingSlot>())
			{
				if (lootingSlot.m_slotType == LootingSlot.LootingSlotType.Item)
				{
					this.method_0(lootingSlot.gameObject, this.m_itemSlots, lootingSlot.m_lootNumber, lootingSlot.m_lootIndex - 1);
				}
				else if (lootingSlot.m_slotType == LootingSlot.LootingSlotType.Weapon)
				{
					this.method_0(lootingSlot.gameObject, this.m_weaponSlots, lootingSlot.m_lootNumber, lootingSlot.m_lootIndex - 1);
				}
			}
		}
	}

	// Token: 0x06001FB1 RID: 8113 RVA: 0x0009B50C File Offset: 0x0009970C
	private void method_0(GameObject gameObject_0, List<GameObject[]> list_0, int int_0, int int_1)
	{
		if (int_0 > 0)
		{
			for (int i = list_0.Count; i < int_0; i++)
			{
				list_0.Add(null);
			}
			if (list_0[int_0 - 1] == null)
			{
				list_0[int_0 - 1] = new GameObject[int_0];
			}
			list_0[int_0 - 1][int_1] = gameObject_0;
		}
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x0009B55C File Offset: 0x0009975C
	public GameObject method_1(ItemType itemType_0, int int_0, int int_1)
	{
		GameObject[] array;
		if (itemType_0 == ItemType.Weapon)
		{
			array = this.method_2(this.m_weaponSlots, int_0);
		}
		else
		{
			array = this.method_2(this.m_itemSlots, int_1);
		}
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.childCount == 0)
				{
					return array[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x0009B5B4 File Offset: 0x000997B4
	private GameObject[] method_2(List<GameObject[]> list_0, int int_0)
	{
		GameObject[] array = null;
		if (list_0 != null)
		{
			int num = int_0 - 1;
			while (num < list_0.Count && array == null)
			{
				if (list_0[num] != null)
				{
					array = list_0[num];
				}
				num++;
			}
			if (array == null)
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"Loot: No suitable slots found to attach ",
					int_0,
					" weapons/items on ",
					base.gameObject.name
				}));
			}
		}
		return array;
	}

	// Token: 0x04001470 RID: 5232
	public ELootingType m_lootingType;

	// Token: 0x04001471 RID: 5233
	public ELootingSubType m_lootingSubType;

	// Token: 0x04001472 RID: 5234
	public int m_levelOverride;

	// Token: 0x04001473 RID: 5235
	public Vector3 m_lootDropOffset;

	// Token: 0x04001474 RID: 5236
	public Vector3 m_lootDropVelocity;

	// Token: 0x04001475 RID: 5237
	public Vector3 m_lootScatterOffset;

	// Token: 0x04001476 RID: 5238
	public bool m_circularScatter;

	// Token: 0x04001477 RID: 5239
	public bool m_attach;

	// Token: 0x04001478 RID: 5240
	private TreasureBoxTrigger m_treasureBoxTrigger;

	// Token: 0x04001479 RID: 5241
	private List<GameObject[]> m_weaponSlots;

	// Token: 0x0400147A RID: 5242
	private List<GameObject[]> m_itemSlots;
}
