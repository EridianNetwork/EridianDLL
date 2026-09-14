using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x0200049D RID: 1181
public class LootingManager : MonoSingleton<LootingManager>, Arbitrator.ArbitratorClient
{
	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06001F8C RID: 8076 RVA: 0x00015E10 File Offset: 0x00014010
	// (set) Token: 0x06001F8D RID: 8077 RVA: 0x00015E18 File Offset: 0x00014018
	public LootSetup m_lootSetup { get; private set; }

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06001F8E RID: 8078 RVA: 0x00015E21 File Offset: 0x00014021
	// (set) Token: 0x06001F8F RID: 8079 RVA: 0x00015E29 File Offset: 0x00014029
	public int[] m_lootingTypesIndexInSetup { get; private set; }

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06001F90 RID: 8080 RVA: 0x00015E32 File Offset: 0x00014032
	// (set) Token: 0x06001F91 RID: 8081 RVA: 0x00015E3A File Offset: 0x0001403A
	public int[] m_lootDefaultQuantityPerItemType { get; private set; }

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06001F92 RID: 8082 RVA: 0x00015E43 File Offset: 0x00014043
	// (set) Token: 0x06001F93 RID: 8083 RVA: 0x00015E4B File Offset: 0x0001404B
	public int[] m_lootDefaultQuantityPerAmmoType { get; private set; }

	// Token: 0x06001F94 RID: 8084 RVA: 0x00015E54 File Offset: 0x00014054
	public void method_0(ILootListener ilootListener_0)
	{
		this.m_lootListeners.Add(ilootListener_0);
	}

	// Token: 0x06001F95 RID: 8085 RVA: 0x00015E62 File Offset: 0x00014062
	public void method_1(ILootListener ilootListener_0)
	{
		this.m_lootListeners.Remove(ilootListener_0);
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnArbitrated(Arbitrator.ArbitrableData data)
	{
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x00015E71 File Offset: 0x00014071
	public int method_2(ItemType itemType_0, AmmoType ammoType_0 = AmmoType.SMG)
	{
		if (itemType_0 == ItemType.Ammo)
		{
			return this.m_lootDefaultQuantityPerAmmoType[(int)ammoType_0];
		}
		return this.m_lootDefaultQuantityPerItemType[(int)itemType_0];
	}

	// Token: 0x04001459 RID: 5209
	private List<ILootListener> m_lootListeners = new List<ILootListener>();

	// Token: 0x0400145A RID: 5210
	public ItemGeneratorService m_itemGeneratorService;
}
