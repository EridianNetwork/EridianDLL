using System;

namespace XsdSettings
{
	// Token: 0x020008EF RID: 2287
	public class SubPartOutfit
	{
		// Token: 0x06003EF0 RID: 16112 RVA: 0x0002A62F File Offset: 0x0002882F
		public override int GetHashCode()
		{
			return SubPartOutfit.smethod_0(this.m_class, this.m_avatarSubpart, this.m_index);
		}

		// Token: 0x06003EF1 RID: 16113 RVA: 0x0012B920 File Offset: 0x00129B20
		public static int smethod_0(AvatarType avatarType_0, AvatarSubPart avatarSubPart_0, int int_0)
		{
			int num = (int)((AvatarType)255 & avatarType_0);
			num <<= 8;
			num |= (int)((AvatarSubPart)255 & avatarSubPart_0);
			num <<= 16;
			return num | (65535 & (int)((short)int_0));
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06003EF2 RID: 16114 RVA: 0x0002A648 File Offset: 0x00028848
		// (set) Token: 0x06003EF3 RID: 16115 RVA: 0x0002A650 File Offset: 0x00028850
		public AvatarType m_class { get; set; }

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06003EF4 RID: 16116 RVA: 0x0002A659 File Offset: 0x00028859
		// (set) Token: 0x06003EF5 RID: 16117 RVA: 0x0002A661 File Offset: 0x00028861
		public AvatarSubPart m_avatarSubpart { get; set; }

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06003EF6 RID: 16118 RVA: 0x0002A66A File Offset: 0x0002886A
		// (set) Token: 0x06003EF7 RID: 16119 RVA: 0x0002A672 File Offset: 0x00028872
		public int m_index { get; set; }

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06003EF8 RID: 16120 RVA: 0x0002A67B File Offset: 0x0002887B
		// (set) Token: 0x06003EF9 RID: 16121 RVA: 0x0002A683 File Offset: 0x00028883
		public OutfitExpirationType m_expirationType { get; set; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06003EFA RID: 16122 RVA: 0x0002A68C File Offset: 0x0002888C
		// (set) Token: 0x06003EFB RID: 16123 RVA: 0x0002A694 File Offset: 0x00028894
		public float m_expirationTime { get; set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06003EFC RID: 16124 RVA: 0x0002A69D File Offset: 0x0002889D
		// (set) Token: 0x06003EFD RID: 16125 RVA: 0x0002A6A5 File Offset: 0x000288A5
		public string m_itemDescription { get; set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06003EFE RID: 16126 RVA: 0x0002A6AE File Offset: 0x000288AE
		// (set) Token: 0x06003EFF RID: 16127 RVA: 0x0002A6B6 File Offset: 0x000288B6
		public uint m_bkID { get; set; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06003F00 RID: 16128 RVA: 0x0002A6BF File Offset: 0x000288BF
		// (set) Token: 0x06003F01 RID: 16129 RVA: 0x0002A6C7 File Offset: 0x000288C7
		public byte m_partIndex { get; set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06003F02 RID: 16130 RVA: 0x0002A6D0 File Offset: 0x000288D0
		// (set) Token: 0x06003F03 RID: 16131 RVA: 0x0002A6D8 File Offset: 0x000288D8
		public byte m_FBXIndex { get; set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06003F04 RID: 16132 RVA: 0x0002A6E1 File Offset: 0x000288E1
		// (set) Token: 0x06003F05 RID: 16133 RVA: 0x0002A6E9 File Offset: 0x000288E9
		public byte m_MatIndex { get; set; }

		// Token: 0x04002C48 RID: 11336
		private AvatarType m_classField;

		// Token: 0x04002C49 RID: 11337
		private AvatarSubPart m_avatarSubpartField;

		// Token: 0x04002C4A RID: 11338
		private OutfitExpirationType m_expirationTypeField;

		// Token: 0x04002C4B RID: 11339
		private uint m_bkIDField;
	}
}
