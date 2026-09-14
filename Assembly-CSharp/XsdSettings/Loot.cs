using System;
using System.ComponentModel;

namespace XsdSettings
{
	// Token: 0x020004A0 RID: 1184
	public class Loot
	{
		// Token: 0x06001F99 RID: 8089 RVA: 0x00015E88 File Offset: 0x00014088
		public Loot()
		{
			this.m_lootProbability = 1;
			this.m_lootQuantity = 0;
			this.m_weaponID = 0;
			this.m_weaponType = WeaponType.TOTAL;
			this.m_materialType = MaterialType.TOTAL;
			this.m_ammoType = AmmoType.TOTAL;
			this.m_itemRarity = ItemRarity.TOTAL;
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06001F9A RID: 8090 RVA: 0x00015EC2 File Offset: 0x000140C2
		public bool Boolean_0
		{
			get
			{
				return WeaponType.TOTAL != this.m_weaponType;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06001F9B RID: 8091 RVA: 0x00015ED0 File Offset: 0x000140D0
		public bool Boolean_1
		{
			get
			{
				return MaterialType.TOTAL != this.m_materialType;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06001F9C RID: 8092 RVA: 0x00015EDF File Offset: 0x000140DF
		public bool Boolean_2
		{
			get
			{
				return AmmoType.TOTAL != this.m_ammoType;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06001F9D RID: 8093 RVA: 0x00015EED File Offset: 0x000140ED
		public bool Boolean_3
		{
			get
			{
				return ItemRarity.TOTAL != this.m_itemRarity;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06001F9E RID: 8094 RVA: 0x00015EFB File Offset: 0x000140FB
		public bool Boolean_4
		{
			get
			{
				return this.m_weaponID != 0;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x00015F09 File Offset: 0x00014109
		// (set) Token: 0x06001FA0 RID: 8096 RVA: 0x00015F11 File Offset: 0x00014111
		public ItemType m_lootType { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x00015F1A File Offset: 0x0001411A
		// (set) Token: 0x06001FA2 RID: 8098 RVA: 0x00015F22 File Offset: 0x00014122
		public int m_lootProbability { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06001FA3 RID: 8099 RVA: 0x00015F2B File Offset: 0x0001412B
		// (set) Token: 0x06001FA4 RID: 8100 RVA: 0x00015F33 File Offset: 0x00014133
		[DefaultValue(0)]
		public int m_lootQuantity { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x00015F3C File Offset: 0x0001413C
		// (set) Token: 0x06001FA6 RID: 8102 RVA: 0x00015F44 File Offset: 0x00014144
		[DefaultValue(0)]
		public int m_weaponID { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06001FA7 RID: 8103 RVA: 0x00015F4D File Offset: 0x0001414D
		// (set) Token: 0x06001FA8 RID: 8104 RVA: 0x00015F55 File Offset: 0x00014155
		[DefaultValue(WeaponType.TOTAL)]
		public WeaponType m_weaponType { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06001FA9 RID: 8105 RVA: 0x00015F5E File Offset: 0x0001415E
		// (set) Token: 0x06001FAA RID: 8106 RVA: 0x00015F66 File Offset: 0x00014166
		[DefaultValue(MaterialType.TOTAL)]
		public MaterialType m_materialType { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06001FAB RID: 8107 RVA: 0x00015F6F File Offset: 0x0001416F
		// (set) Token: 0x06001FAC RID: 8108 RVA: 0x00015F77 File Offset: 0x00014177
		[DefaultValue(AmmoType.TOTAL)]
		public AmmoType m_ammoType { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06001FAD RID: 8109 RVA: 0x00015F80 File Offset: 0x00014180
		// (set) Token: 0x06001FAE RID: 8110 RVA: 0x00015F88 File Offset: 0x00014188
		[DefaultValue(ItemRarity.TOTAL)]
		public ItemRarity m_itemRarity { get; set; }

		// Token: 0x04001467 RID: 5223
		private ItemType m_lootTypeField;
	}
}
