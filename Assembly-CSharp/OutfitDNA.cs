using System;
using System.Collections;
using Core;
using XsdSettings;

// Token: 0x020008D8 RID: 2264
public class OutfitDNA : ICloneable
{
	// Token: 0x06003E7B RID: 15995 RVA: 0x00129B0C File Offset: 0x00127D0C
	public OutfitDNA()
	{
		this.m_id = 0;
		this.m_avatarType = AvatarType.TOTAL;
		this.m_name = null;
		this.m_avatarSubpart = AvatarSubPart.TOTAL;
		this.m_expirationType = OutfitExpirationType.Permanent;
		this.m_expirationTime = 0f;
		this.m_itemDescription = null;
		this.m_rarity = ItemRarity.TOTAL;
		this.m_level = 1;
		this.m_index = 0;
	}

	// Token: 0x06003E7C RID: 15996 RVA: 0x00129B6C File Offset: 0x00127D6C
	public object Clone()
	{
		return (OutfitDNA)base.MemberwiseClone();
	}

	// Token: 0x06003E7D RID: 15997 RVA: 0x00129B88 File Offset: 0x00127D88
	public override int GetHashCode()
	{
		return this.m_avatarSubpart.ToString().GetHashCode();
	}

	// Token: 0x06003E7E RID: 15998 RVA: 0x00129BAC File Offset: 0x00127DAC
	public bool method_0(ref string string_0, ref string string_1)
	{
		SubPartOutfit subPartOutfit = OutfitStore.OutfitStore_0.method_1(this.m_avatarType, this.m_avatarSubpart, this.m_index);
		if (subPartOutfit != null)
		{
			BuildingKit buildingKit = BuildingKitManager.smethod_0(subPartOutfit.m_bkID);
			string_0 = buildingKit.method_8((int)subPartOutfit.m_partIndex, (int)subPartOutfit.m_FBXIndex);
			string_1 = buildingKit.method_13((int)subPartOutfit.m_partIndex, (int)subPartOutfit.m_FBXIndex, (int)subPartOutfit.m_MatIndex);
			return true;
		}
		DebugUtils.LogWarning(LogCategory.Gamelogic, "Can't find this outfit in the outfit.xml,please find designer to fix");
		return false;
	}

	// Token: 0x06003E7F RID: 15999 RVA: 0x00129C24 File Offset: 0x00127E24
	public int method_1()
	{
		SubPartOutfit subPartOutfit = OutfitStore.OutfitStore_0.method_1(this.m_avatarType, this.m_avatarSubpart, this.m_index);
		if (subPartOutfit != null)
		{
			return (int)subPartOutfit.m_FBXIndex;
		}
		return -1;
	}

	// Token: 0x06003E80 RID: 16000 RVA: 0x00129C5C File Offset: 0x00127E5C
	public int method_2()
	{
		SubPartOutfit subPartOutfit = OutfitStore.OutfitStore_0.method_1(this.m_avatarType, this.m_avatarSubpart, this.m_index);
		if (subPartOutfit != null)
		{
			return (int)subPartOutfit.m_MatIndex;
		}
		return -1;
	}

	// Token: 0x06003E81 RID: 16001 RVA: 0x00129C94 File Offset: 0x00127E94
	public BuildingPart method_3()
	{
		SubPartOutfit subPartOutfit = OutfitStore.OutfitStore_0.method_1(this.m_avatarType, this.m_avatarSubpart, this.m_index);
		if (subPartOutfit != null)
		{
			return new BuildingPart(subPartOutfit.m_bkID, subPartOutfit.m_partIndex, subPartOutfit.m_FBXIndex, subPartOutfit.m_MatIndex);
		}
		return null;
	}

	// Token: 0x06003E82 RID: 16002 RVA: 0x00129CE0 File Offset: 0x00127EE0
	public static OutfitDNA smethod_0(Hashtable hashtable_0, int int_0)
	{
		OutfitDNA outfitDNA2;
		try
		{
			if (hashtable_0 == null)
			{
				throw new Exception("data is NULL.");
			}
			OutfitDNA outfitDNA = new OutfitDNA();
			outfitDNA.m_level = (int)hashtable_0[1];
			outfitDNA.m_rarity = (ItemRarity)((int)hashtable_0[2]);
			outfitDNA.m_id = (int)hashtable_0[4];
			int num = (int)hashtable_0[5];
			if (num != 0)
			{
				outfitDNA.m_expirationType = OutfitExpirationType.Expiring;
				outfitDNA.m_expirationTime = (float)(DateTime.Now.Subtract(AppManager.EPOCH).TotalSeconds - (double)num);
			}
			outfitDNA.m_name = (string)hashtable_0[int_0 + 1];
			outfitDNA.m_itemDescription = (string)hashtable_0[int_0 + 2];
			outfitDNA.m_avatarType = (AvatarType)((int)hashtable_0[int_0 + 3]);
			outfitDNA.m_avatarSubpart = (AvatarSubPart)((int)hashtable_0[int_0 + 4]);
			outfitDNA.m_index = (int)hashtable_0[int_0 + 5];
			outfitDNA2 = outfitDNA;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("Invalid Outfit Data: {0}", ex.Message));
			outfitDNA2 = null;
		}
		return outfitDNA2;
	}

	// Token: 0x06003E83 RID: 16003 RVA: 0x0002A2D2 File Offset: 0x000284D2
	public string method_4()
	{
		return ItemDNA.smethod_11(this.m_name);
	}

	// Token: 0x04002BE4 RID: 11236
	public int m_id;

	// Token: 0x04002BE5 RID: 11237
	public AvatarType m_avatarType;

	// Token: 0x04002BE6 RID: 11238
	public string m_name;

	// Token: 0x04002BE7 RID: 11239
	public AvatarSubPart m_avatarSubpart;

	// Token: 0x04002BE8 RID: 11240
	public OutfitExpirationType m_expirationType;

	// Token: 0x04002BE9 RID: 11241
	public float m_expirationTime;

	// Token: 0x04002BEA RID: 11242
	public string m_itemDescription;

	// Token: 0x04002BEB RID: 11243
	public ItemRarity m_rarity;

	// Token: 0x04002BEC RID: 11244
	public int m_level;

	// Token: 0x04002BED RID: 11245
	public int m_index;
}
