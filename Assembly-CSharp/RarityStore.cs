using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020008DE RID: 2270
[Serializable]
public class RarityStore
{
	// Token: 0x06003EAC RID: 16044 RVA: 0x0002A3D3 File Offset: 0x000285D3
	public RarityStore()
	{
	}

	// Token: 0x06003EAD RID: 16045 RVA: 0x0012A930 File Offset: 0x00128B30
	public RarityStore(bool bool_0)
	{
		if (bool_0)
		{
			this.m_weaponRarityAttr.Clear();
			for (int i = 0; i < 5; i++)
			{
				this.m_weaponRarityAttr.Add(new WeaponRarityAttr(true, (WeaponType)i));
			}
		}
	}

	// Token: 0x06003EAE RID: 16046 RVA: 0x0012A97C File Offset: 0x00128B7C
	public void method_0()
	{
		List<WeaponRarityAttr> list = new List<WeaponRarityAttr>();
		for (int i = 0; i < 5; i++)
		{
			WeaponType weaponType = (WeaponType)i;
			int num = m_weaponRarityAttr.FindIndex((WeaponRarityAttr weaponRarityAttr_0) => weaponRarityAttr_0.m_weaponType == weaponType);
			if (num >= 0)
			{
				list.Add(m_weaponRarityAttr[num]);
			}
			else
			{
				list.Add(new WeaponRarityAttr(bool_0: true, weaponType));
			}
		}
		m_weaponRarityAttr = list;
		for (int j = 0; j < m_weaponRarityAttr.Count; j++)
		{
			m_weaponRarityAttr[j].method_0();
		}
	}
	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06003EAF RID: 16047 RVA: 0x0002A3E6 File Offset: 0x000285E6
	// (set) Token: 0x06003EB0 RID: 16048 RVA: 0x0002A403 File Offset: 0x00028603
	public static RarityStore rarityStore
	{
		get
		{
			if (RarityStore.s_rarityStore == null)
			{
				RarityStore.smethod_3();
				RarityStore.s_rarityStore.method_0();
			}
			return RarityStore.s_rarityStore;
		}
		protected set
		{
			RarityStore.s_rarityStore = value;
		}
	}

	// Token: 0x06003EB1 RID: 16049 RVA: 0x0012AA1C File Offset: 0x00128C1C
	public static void smethod_0()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(RarityStore));
		using (TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Rarity.XML"))
		{
			xmlSerializer.Serialize(textWriter, RarityStore.s_rarityStore);
			textWriter.Close();
		}
	}

	// Token: 0x06003EB2 RID: 16050 RVA: 0x0012AA74 File Offset: 0x00128C74
	private static void smethod_1()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(RarityStore));
		if (!File.Exists("Assets/Resources/WeaponEditor/Rarity.XML"))
		{
			RarityStore.s_rarityStore = new RarityStore(true);
			RarityStore.smethod_0();
		}
		else
		{
			using (FileStream fileStream = File.OpenRead("Assets/Resources/WeaponEditor/Rarity.XML"))
			{
				RarityStore.s_rarityStore = (RarityStore)xmlSerializer.Deserialize(fileStream);
				fileStream.Close();
			}
		}
	}

	// Token: 0x06003EB3 RID: 16051 RVA: 0x0002A40B File Offset: 0x0002860B
	public static void smethod_2()
	{
		new BinaryLotGenerator(BinaryType.RarityBinaryGenerator).method_1();
	}

	// Token: 0x06003EB4 RID: 16052 RVA: 0x0012AAF0 File Offset: 0x00128CF0
	private static void smethod_3()
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/Bin/Rarity") as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			RarityStore.s_rarityStore = new RarityStore(true);
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					for (int k = 0; k < 9; k++)
					{
						int num = binaryReader.ReadInt32();
						for (int l = 0; l < num; l++)
						{
							RarityStore.s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts.Add(new SubpartChoice());
							RarityStore.s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_subpartIndex = binaryReader.ReadInt32();
							RarityStore.s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_probability = binaryReader.ReadSingle();
							RarityStore.s_rarityStore.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_modifier = (ProbabilityModifier)binaryReader.ReadByte();
						}
					}
				}
			}
			stream.Dispose();
			binaryReader.Close();
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06003EB5 RID: 16053 RVA: 0x0012ACB8 File Offset: 0x00128EB8
	public int method_1(WeaponType weaponType_0, WeaponRarity weaponRarity_0, WeaponSubPart weaponSubPart_0)
	{
		if (weaponType_0 < (WeaponType)this.m_weaponRarityAttr.Count && weaponRarity_0 < (WeaponRarity)this.m_weaponRarityAttr[(int)weaponType_0].m_weaponRarityType.Count && weaponSubPart_0 < (WeaponSubPart)this.m_weaponRarityAttr[(int)weaponType_0].m_weaponRarityType[(int)weaponRarity_0].m_subPartTypes.Count)
		{
			List<SubpartChoice> list = new List<SubpartChoice>();
			for (int i = 0; i < this.m_weaponRarityAttr[(int)weaponType_0].m_weaponRarityType[(int)weaponRarity_0].m_subPartTypes[(int)weaponSubPart_0].m_subParts.Count; i++)
			{
				SubpartChoice subpartChoice = (SubpartChoice)this.m_weaponRarityAttr[(int)weaponType_0].m_weaponRarityType[(int)weaponRarity_0].m_subPartTypes[(int)weaponSubPart_0].m_subParts[i].Clone();
				list.Add(subpartChoice);
			}
			if (list.Count == 0)
			{
				return 0;
			}
			int num = 1;
			if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
				if (entityPlayer != null)
				{
					num = entityPlayer.m_awesomeLevel;
				}
			}
			float num2 = 0f;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].m_modifier == ProbabilityModifier.Square)
				{
					list[j].m_probability *= Mathf.Pow(1.05f, (float)(num - 1));
				}
				else if (list[j].m_modifier == ProbabilityModifier.MultipleLevel)
				{
					list[j].m_probability *= (float)num;
				}
				num2 += list[j].m_probability;
			}
			float num3 = global::UnityEngine.Random.Range(0f, num2);
			float num4 = 0f;
			for (int k = 0; k < list.Count; k++)
			{
				if (num3 >= num4 && num3 < num4 + list[k].m_probability)
				{
					return list[k].m_subpartIndex;
				}
				num4 += list[k].m_probability;
			}
		}
		return 0;
	}

	// Token: 0x04002C18 RID: 11288
	public const string AssetPath = "Assets/Resources/WeaponEditor/Rarity.XML";

	// Token: 0x04002C19 RID: 11289
	public const string ResourcesAssetPath = "WeaponEditor/Bin/Rarity";

	// Token: 0x04002C1A RID: 11290
	[SerializeField]
	public List<WeaponRarityAttr> m_weaponRarityAttr = new List<WeaponRarityAttr>();

	// Token: 0x04002C1B RID: 11291
	private static RarityStore s_rarityStore;
}
