using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using XsdSettings;

// Token: 0x020008F9 RID: 2297
public class SubPartWeaponStore
{
	// Token: 0x06003F6A RID: 16234 RVA: 0x0002AA7B File Offset: 0x00028C7B
	public static string smethod_0(WeaponType weaponType_0)
	{
		return "Assets/Resources/WeaponEditor/SubParts_" + weaponType_0.ToString() + ".xml";
	}

	// Token: 0x06003F6B RID: 16235 RVA: 0x0002AA97 File Offset: 0x00028C97
	public static string smethod_1(WeaponType weaponType_0)
	{
		return "WeaponEditor/SubParts_" + weaponType_0.ToString();
	}

	// Token: 0x06003F6C RID: 16236 RVA: 0x0002AAAE File Offset: 0x00028CAE
	public SubPartStoreSetup method_0(WeaponType weaponType_0)
	{
		if (weaponType_0 < WeaponType.SMG)
		{
			return null;
		}
		if (weaponType_0 >= WeaponType.TOTAL)
		{
			return null;
		}
		return this.m_setups[(int)weaponType_0];
	}

	// Token: 0x06003F6D RID: 16237 RVA: 0x0012BE34 File Offset: 0x0012A034
	public SubPartWpn method_1(int int_0)
	{
		WeaponType weaponType = SubPartWpn.smethod_0(int_0);
		SubPartStoreSetup subPartStoreSetup = this.method_0(weaponType);
		if (subPartStoreSetup == null)
		{
			return null;
		}
		return subPartStoreSetup.method_1(int_0);
	}

	// Token: 0x06003F6E RID: 16238 RVA: 0x0002AAC4 File Offset: 0x00028CC4
	public SubPartWpn method_2(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0, int int_0)
	{
		return this.method_1(SubPartWpn.smethod_1(weaponType_0, weaponSubPart_0, int_0));
	}

	// Token: 0x06003F6F RID: 16239 RVA: 0x0012BE5C File Offset: 0x0012A05C
	public List<SubPartWpn> method_3(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0)
	{
		SubPartStoreSetup subPartStoreSetup = this.method_0(weaponType_0);
		if (subPartStoreSetup == null)
		{
			return null;
		}
		return subPartStoreSetup.method_2(weaponSubPart_0);
	}

	// Token: 0x06003F70 RID: 16240 RVA: 0x0002AAD4 File Offset: 0x00028CD4
	public bool method_4(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0)
	{
		return (weaponSubPart_0 == WeaponSubPart.STOCK && weaponType_0 == WeaponType.RepeaterPistol) || (weaponSubPart_0 == WeaponSubPart.ACTION && weaponType_0 != WeaponType.RepeaterPistol);
	}

	// Token: 0x06003F71 RID: 16241 RVA: 0x0012BE80 File Offset: 0x0012A080
	public byte method_5(WeaponType weaponType_0, WeaponSubPart weaponSubPart_0)
	{
		byte b = 0;
		for (int i = 0; i < (int)weaponSubPart_0; i++)
		{
			if (!this.method_4(weaponType_0, (WeaponSubPart)i))
			{
				b += 1;
			}
		}
		return b;
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06003F72 RID: 16242 RVA: 0x0002AAEB File Offset: 0x00028CEB
	// (set) Token: 0x06003F73 RID: 16243 RVA: 0x0002AAFE File Offset: 0x00028CFE
	public static SubPartWeaponStore SubPartWeaponStore_0
	{
		get
		{
			if (SubPartWeaponStore.s_subPartStore == null)
			{
				SubPartWeaponStore.smethod_5();
			}
			return SubPartWeaponStore.s_subPartStore;
		}
		protected set
		{
			SubPartWeaponStore.s_subPartStore = value;
		}
	}

	// Token: 0x06003F74 RID: 16244 RVA: 0x0012BEAC File Offset: 0x0012A0AC
	public static void smethod_2()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubPartStoreSetup));
		for (int i = 0; i < 5; i++)
		{
			if (SubPartWeaponStore.s_subPartStore.m_setups[i] != null)
			{
				using (TextWriter textWriter = new StreamWriter(SubPartWeaponStore.smethod_0((WeaponType)i)))
				{
					xmlSerializer.Serialize(textWriter, SubPartWeaponStore.s_subPartStore.m_setups[i]);
					textWriter.Close();
				}
			}
		}
	}

	// Token: 0x06003F75 RID: 16245 RVA: 0x0012BF24 File Offset: 0x0012A124
	private static void smethod_3()
	{
		SubPartWeaponStore.s_subPartStore = new SubPartWeaponStore();
		if (SubPartWeaponStore.s_subPartStore == null)
		{
			return;
		}
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubPartStoreSetup));
		for (int i = 0; i < 5; i++)
		{
			string text = SubPartWeaponStore.smethod_0((WeaponType)i);
			if (!File.Exists(text))
			{
				SubPartWeaponStore.s_subPartStore.m_setups[i] = new SubPartStoreSetup();
			}
			else
			{
				using (FileStream fileStream = File.OpenRead(text))
				{
					SubPartWeaponStore.s_subPartStore.m_setups[i] = (SubPartStoreSetup)xmlSerializer.Deserialize(fileStream);
					SubPartWeaponStore.s_subPartStore.m_setups[i].method_0();
					fileStream.Close();
				}
			}
		}
	}

	// Token: 0x06003F76 RID: 16246 RVA: 0x0002AB06 File Offset: 0x00028D06
	public static void smethod_4()
	{
		new BinaryLotGenerator(BinaryType.SubPartsBinaryGenerator).method_1();
	}

	// Token: 0x06003F77 RID: 16247 RVA: 0x0012BFD4 File Offset: 0x0012A1D4
	private static void smethod_5()
	{
		SubPartWeaponStore.s_subPartStore = new SubPartWeaponStore();
		if (SubPartWeaponStore.s_subPartStore == null)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/Bin/SubParts_" + (WeaponType)i) as TextAsset;
			Stream stream = new MemoryStream(textAsset.bytes);
			using (BinaryReader binaryReader = new BinaryReader(stream))
			{
				SubPartWeaponStore.s_subPartStore.m_setups[i] = new SubPartStoreSetup();
				int num = binaryReader.ReadInt32();
				SubPartWpn[] array = new SubPartWpn[num];
				for (int j = 0; j < num; j++)
				{
					array[j] = new SubPartWpn();
					array[j].m_Index = binaryReader.ReadInt32();
					array[j].m_weaponType = (WeaponType)binaryReader.ReadByte();
					array[j].m_partType = (WeaponSubPart)binaryReader.ReadByte();
					BuildingPart buildingPart = new BuildingPart();
					buildingPart.bkID = binaryReader.ReadUInt32();
					buildingPart.mPart = binaryReader.ReadByte();
					buildingPart.mFBX = binaryReader.ReadByte();
					buildingPart.mMat = binaryReader.ReadByte();
					array[j].m_BuildingPart = buildingPart;
					array[j].m_partName = binaryReader.ReadString();
					array[j].m_namePriority = binaryReader.ReadInt32();
					int num2 = binaryReader.ReadInt32();
					BOLAttribute[] array2 = new BOLAttribute[num2];
					for (int k = 0; k < num2; k++)
					{
						array2[k] = new BOLAttribute();
						array2[k].m_attributeType = (AttributeType)binaryReader.ReadByte();
						AttributeValueType attributeValueType = (AttributeValueType)binaryReader.ReadByte();
						Type type = Type.GetType("XsdSettings." + attributeValueType.ToString(), true);
						array2[k].m_attributeValue = (AttributeValue)Activator.CreateInstance(type);
						array2[k].m_attributeValue.m_type = attributeValueType;
						array2[k].m_attributeValue.m_affectType = (AffectType)binaryReader.ReadByte();
						array2[k].m_attributeValue.vmethod_3(binaryReader.ReadSingle());
					}
					array[j].m_Attributes = array2;
				}
				SubPartWeaponStore.s_subPartStore.m_setups[i].m_subParts = array;
				SubPartWeaponStore.s_subPartStore.m_setups[i].method_0();
				stream.Dispose();
				binaryReader.Close();
			}
			Resources.UnloadAsset(textAsset);
		}
	}

	// Token: 0x04002C88 RID: 11400
	public const string AssetPath = "Assets/Resources/WeaponEditor/SubParts_";

	// Token: 0x04002C89 RID: 11401
	public const string ResourcesAssetPath = "WeaponEditor/SubParts_";

	// Token: 0x04002C8A RID: 11402
	public SubPartStoreSetup[] m_setups = new SubPartStoreSetup[5];

	// Token: 0x04002C8B RID: 11403
	private static SubPartWeaponStore s_subPartStore;
}
