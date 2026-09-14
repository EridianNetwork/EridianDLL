using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using XsdSettings;

// Token: 0x02000644 RID: 1604
public class BinaryLotGenerator
{
	// Token: 0x060028A3 RID: 10403 RVA: 0x000BFE5C File Offset: 0x000BE05C
	public BinaryLotGenerator(BinaryType binaryType_0)
	{
		switch (binaryType_0)
		{
		case BinaryType.BktBinaryGenerator:
			this.binaryGenerator = new BinaryLotGenerator.BktBinaryGenerator();
			break;
		case BinaryType.PresetWpnBinaryGenerator:
			this.binaryGenerator = new BinaryLotGenerator.PresetWpnBinaryGenerator();
			break;
		case BinaryType.SubPartsBinaryGenerator:
			this.binaryGenerator = new BinaryLotGenerator.SubPartsBinaryGenerator();
			break;
		case BinaryType.RarityBinaryGenerator:
			this.binaryGenerator = new BinaryLotGenerator.RarityBinaryGenerator();
			break;
		case BinaryType.WeaponBinaryGenerator:
			this.binaryGenerator = new BinaryLotGenerator.WeaponBinaryGenerator();
			break;
		}
	}

	// Token: 0x060028A4 RID: 10404 RVA: 0x000BFECC File Offset: 0x000BE0CC
	public void method_0(string string_0)
	{
		string currentDirectory = Environment.CurrentDirectory;
		string text = string_0.Substring(currentDirectory.Length + 1);
		string[] array = this.binaryGenerator.method_1();
		for (int i = 0; i < array.Length; i++)
		{
			if (text == array[i] && this.binaryGenerator.method_0(array[i]))
			{
				this.binaryGenerator.vmethod_1();
				return;
			}
		}
	}

	// Token: 0x060028A5 RID: 10405 RVA: 0x000BFF30 File Offset: 0x000BE130
	public void method_1()
	{
		string[] array = this.binaryGenerator.method_1();
		for (int i = 0; i < array.Length; i++)
		{
			if (this.binaryGenerator.method_0(array[i]))
			{
				this.binaryGenerator.vmethod_1();
			}
		}
	}

	// Token: 0x04001D11 RID: 7441
	private BinaryLotGenerator.BinaryGenerator binaryGenerator;

	// Token: 0x02000645 RID: 1605
	internal abstract class BinaryGenerator
	{
		// Token: 0x060028A7 RID: 10407 RVA: 0x0001AAFB File Offset: 0x00018CFB
		public bool method_0(string string_0)
		{
			this.textAsset = Resources.LoadAssetAtPath(string_0, typeof(TextAsset)) as TextAsset;
			return this.vmethod_0();
		}

		// Token: 0x060028A8 RID: 10408 RVA: 0x0001AB1E File Offset: 0x00018D1E
		public string[] method_1()
		{
			return Directory.GetFiles(this.input, this.filter);
		}

		// Token: 0x060028A9 RID: 10409 RVA: 0x000BFF74 File Offset: 0x000BE174
		protected FileStream method_2(string string_0)
		{
			string text = string_0 + this.textAsset.name + ".bytes";
			if (File.Exists(text))
			{
				File.SetAttributes(text, FileAttributes.Normal);
				File.Delete(text);
			}
			return File.Open(text, FileMode.Create);
		}

		// Token: 0x060028AA RID: 10410
		protected abstract bool vmethod_0();

		// Token: 0x060028AB RID: 10411
		public abstract void vmethod_1();

		// Token: 0x04001D12 RID: 7442
		protected TextAsset textAsset;

		// Token: 0x04001D13 RID: 7443
		protected string input;

		// Token: 0x04001D14 RID: 7444
		protected string output;

		// Token: 0x04001D15 RID: 7445
		protected string filter;
	}

	// Token: 0x02000646 RID: 1606
	internal class BktBinaryGenerator : BinaryLotGenerator.BinaryGenerator
	{
		// Token: 0x060028AC RID: 10412 RVA: 0x0001AB31 File Offset: 0x00018D31
		public BktBinaryGenerator()
		{
			this.input = "Assets/Resources/BuildingKit/Xml/";
			this.output = "Assets/Resources/BuildingKit/";
			this.filter = "BKT_*.xml";
		}

		// Token: 0x060028AD RID: 10413 RVA: 0x000BFFB8 File Offset: 0x000BE1B8
		protected override bool vmethod_0()
		{
			bool flag = false;
			using (MemoryStream memoryStream = new MemoryStream(this.textAsset.bytes))
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(ComposableCharacter));
					this.m_character = (ComposableCharacter)xmlSerializer.Deserialize(memoryStream);
					flag = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(this.textAsset);
				}
			}
			return flag;
		}

		// Token: 0x060028AE RID: 10414 RVA: 0x000C0048 File Offset: 0x000BE248
		public override void vmethod_1()
		{
			Stream stream = base.method_2(this.output);
			using (BinaryWriter binaryWriter = new BinaryWriter(stream))
			{
				binaryWriter.Write(this.m_character.bkID);
				binaryWriter.Write(this.m_character.m_sTypeName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(this.m_character.m_sTypeName));
				binaryWriter.Write(this.m_character.m_sCharacterName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(this.m_character.m_sCharacterName));
				binaryWriter.Write(this.m_character.m_sSkeletonName.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(this.m_character.m_sSkeletonName));
				this.method_3(binaryWriter, this.m_character.m_aParts.ToArray());
				stream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x060028AF RID: 10415 RVA: 0x000C014C File Offset: 0x000BE34C
		private void method_3(BinaryWriter binaryWriter_0, ComposablePart[] composablePart_0)
		{
			binaryWriter_0.Write(composablePart_0.Length);
			for (int i = 0; i < composablePart_0.Length; i++)
			{
				binaryWriter_0.Write(composablePart_0[i].m_sPartName.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(composablePart_0[i].m_sPartName));
				this.method_4(binaryWriter_0, composablePart_0[i].m_aFbxs.ToArray());
			}
		}

		// Token: 0x060028B0 RID: 10416 RVA: 0x000C01B0 File Offset: 0x000BE3B0
		private void method_4(BinaryWriter binaryWriter_0, ComposableFBX[] composableFBX_0)
		{
			binaryWriter_0.Write(composableFBX_0.Length);
			for (int i = 0; i < composableFBX_0.Length; i++)
			{
				binaryWriter_0.Write(composableFBX_0[i].m_sFileName.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(composableFBX_0[i].m_sFileName));
				this.method_5(binaryWriter_0, composableFBX_0[i].m_aMaterials.ToArray());
			}
		}

		// Token: 0x060028B1 RID: 10417 RVA: 0x000C0214 File Offset: 0x000BE414
		private void method_5(BinaryWriter binaryWriter_0, ComposableMaterial[] composableMaterial_0)
		{
			binaryWriter_0.Write(composableMaterial_0.Length);
			for (int i = 0; i < composableMaterial_0.Length; i++)
			{
				binaryWriter_0.Write(composableMaterial_0[i].m_sMaterial.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(composableMaterial_0[i].m_sMaterial));
				binaryWriter_0.Write(composableMaterial_0[i].m_sShader.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(composableMaterial_0[i].m_sShader));
				binaryWriter_0.Write(composableMaterial_0[i].m_sTexName.Count);
				for (int j = 0; j < composableMaterial_0[i].m_sTexName.Count; j++)
				{
					binaryWriter_0.Write(composableMaterial_0[i].m_sTexName[j].Length);
					binaryWriter_0.Write(Encoding.Unicode.GetBytes(composableMaterial_0[i].m_sTexName[j]));
				}
				binaryWriter_0.Write(composableMaterial_0[i].m_sTexFileName.Count);
				for (int k = 0; k < composableMaterial_0[i].m_sTexFileName.Count; k++)
				{
					binaryWriter_0.Write(composableMaterial_0[i].m_sTexFileName[k].Length);
					binaryWriter_0.Write(Encoding.Unicode.GetBytes(composableMaterial_0[i].m_sTexFileName[k]));
				}
				this.method_6(binaryWriter_0, composableMaterial_0[i].m_sShaderProperties.ToArray());
			}
		}

		// Token: 0x060028B2 RID: 10418 RVA: 0x000C036C File Offset: 0x000BE56C
		private void method_6(BinaryWriter binaryWriter_0, ShaderProperty[] shaderProperty_0)
		{
			binaryWriter_0.Write(shaderProperty_0.Length);
			for (int i = 0; i < shaderProperty_0.Length; i++)
			{
				binaryWriter_0.Write((byte)shaderProperty_0[i].mType);
				binaryWriter_0.Write(shaderProperty_0[i].mName.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(shaderProperty_0[i].mName));
				binaryWriter_0.Write(shaderProperty_0[i].mDesc.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(shaderProperty_0[i].mDesc));
				binaryWriter_0.Write(shaderProperty_0[i].mValue.Length);
				binaryWriter_0.Write(Encoding.Unicode.GetBytes(shaderProperty_0[i].mValue));
			}
		}

		// Token: 0x04001D16 RID: 7446
		private ComposableCharacter m_character;
	}

	// Token: 0x02000647 RID: 1607
	internal class PresetWpnBinaryGenerator : BinaryLotGenerator.BinaryGenerator
	{
		// Token: 0x060028B3 RID: 10419 RVA: 0x0001AB5A File Offset: 0x00018D5A
		public PresetWpnBinaryGenerator()
		{
			this.input = "Assets/Resources/WeaponEditor/";
			this.output = "Assets/Resources/WeaponEditor/Bin/";
			this.filter = "Preset_Weapons*.xml";
		}

		// Token: 0x060028B4 RID: 10420 RVA: 0x000C0428 File Offset: 0x000BE628
		protected override bool vmethod_0()
		{
			bool flag = false;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(this.textAsset.text);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Weapon");
			try
			{
				this.m_weapons = new WeaponDNA[elementsByTagName.Count];
				int num = 0;
				foreach (object obj in elementsByTagName)
				{
					XmlNode xmlNode = (XmlNode)obj;
					WeaponType weaponType = (WeaponType)((int)Enum.Parse(typeof(WeaponType), xmlNode.Attributes["type"].Value));
					WeaponDNA weaponDNA = new WeaponDNA();
					weaponDNA.m_name = xmlNode.Attributes["name"].Value;
					weaponDNA.m_id = Convert.ToInt32(xmlNode.Attributes["id"].Value);
					weaponDNA.m_type = weaponType;
					weaponDNA.m_rarity = (WeaponRarity)((int)Enum.Parse(typeof(WeaponRarity), xmlNode.Attributes["raritytype"].Value));
					weaponDNA.m_level = Convert.ToInt32(xmlNode.Attributes["level"].Value);
					int[] array = new int[9];
					if (xmlNode.Attributes["ExtraSlot"] != null && xmlNode.Attributes["ExtraSlot"].Value != null)
					{
						weaponDNA.m_extraEffectCount = Convert.ToInt32(xmlNode.Attributes["ExtraSlot"].Value);
						if (weaponDNA.m_extraEffectCount > 0)
						{
							WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.method_1(weaponDNA.m_extraEffectCount, xmlNode, weaponDNA.method_2(), weaponDNA.m_level, ref weaponDNA.m_extraEffect, ref weaponDNA.m_extraEffectIndex);
						}
					}
					foreach (object obj2 in Enum.GetValues(typeof(WeaponSubPart)))
					{
						WeaponSubPart weaponSubPart = (WeaponSubPart)((int)obj2);
						if (weaponSubPart != WeaponSubPart.MAX)
						{
							array[(int)weaponSubPart] = new SubPartWpn(weaponType, weaponSubPart)
							{
								m_Index = Convert.ToInt32(xmlNode.Attributes[Enum.GetName(typeof(WeaponSubPart), weaponSubPart)].Value)
							}.GetHashCode();
						}
					}
					weaponDNA.m_subPartsCode = array;
					this.m_weapons[num] = weaponDNA;
					num++;
				}
				flag = true;
			}
			catch
			{
			}
			finally
			{
				Resources.UnloadAsset(this.textAsset);
			}
			return flag;
		}

		// Token: 0x060028B5 RID: 10421 RVA: 0x000C0734 File Offset: 0x000BE934
		public override void vmethod_1()
		{
			Stream stream = base.method_2(this.output);
			using (BinaryWriter binaryWriter = new BinaryWriter(stream))
			{
				binaryWriter.Write(this.m_weapons.Length);
				for (int i = 0; i < this.m_weapons.Length; i++)
				{
					binaryWriter.Write(this.m_weapons[i].m_name);
					binaryWriter.Write(this.m_weapons[i].m_id);
					binaryWriter.Write((byte)this.m_weapons[i].m_type);
					binaryWriter.Write((byte)this.m_weapons[i].m_rarity);
					binaryWriter.Write(this.m_weapons[i].m_level);
					binaryWriter.Write(this.m_weapons[i].m_extraEffectCount);
					for (int j = 0; j < ItemDNA.m_extraEffectNums; j++)
					{
						binaryWriter.Write(this.m_weapons[i].m_extraEffect[j]);
					}
					for (int k = 0; k < ItemDNA.m_extraEffectNums; k++)
					{
						binaryWriter.Write(this.m_weapons[i].m_extraEffectIndex[k]);
					}
					for (int l = 0; l < this.m_weapons[i].m_subPartsCode.Length; l++)
					{
						binaryWriter.Write(this.m_weapons[i].m_subPartsCode[l]);
					}
				}
				stream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x04001D17 RID: 7447
		private WeaponDNA[] m_weapons;
	}

	// Token: 0x02000648 RID: 1608
	internal class SubPartsBinaryGenerator : BinaryLotGenerator.BinaryGenerator
	{
		// Token: 0x060028B6 RID: 10422 RVA: 0x0001AB83 File Offset: 0x00018D83
		public SubPartsBinaryGenerator()
		{
			this.input = "Assets/Resources/WeaponEditor/";
			this.output = "Assets/Resources/WeaponEditor/Bin/";
			this.filter = "SubParts_*.xml";
		}

		// Token: 0x060028B7 RID: 10423 RVA: 0x000C08A8 File Offset: 0x000BEAA8
		protected override bool vmethod_0()
		{
			bool flag = false;
			using (Stream stream = new MemoryStream(this.textAsset.bytes))
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(SubPartStoreSetup));
					this.m_setup = (SubPartStoreSetup)xmlSerializer.Deserialize(stream);
					flag = true;
				}
				catch
				{
				}
				finally
				{
					stream.Close();
					Resources.UnloadAsset(this.textAsset);
				}
			}
			return flag;
		}

		// Token: 0x060028B8 RID: 10424 RVA: 0x000C0938 File Offset: 0x000BEB38
		public override void vmethod_1()
		{
			Stream stream = base.method_2(this.output);
			using (BinaryWriter binaryWriter = new BinaryWriter(stream))
			{
				binaryWriter.Write(this.m_setup.m_subParts.Length);
				for (int i = 0; i < this.m_setup.m_subParts.Length; i++)
				{
					binaryWriter.Write(this.m_setup.m_subParts[i].m_Index);
					binaryWriter.Write((byte)this.m_setup.m_subParts[i].m_weaponType);
					binaryWriter.Write((byte)this.m_setup.m_subParts[i].m_partType);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_BuildingPart.bkID);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_BuildingPart.mPart);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_BuildingPart.mFBX);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_BuildingPart.mMat);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_partName);
					binaryWriter.Write(this.m_setup.m_subParts[i].m_namePriority);
					this.method_3(binaryWriter, this.m_setup.m_subParts[i].m_Attributes);
				}
				stream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x060028B9 RID: 10425 RVA: 0x000C0AC8 File Offset: 0x000BECC8
		private void method_3(BinaryWriter binaryWriter_0, BOLAttribute[] bolattribute_0)
		{
			if (bolattribute_0 == null)
			{
				binaryWriter_0.Write(0);
			}
			else
			{
				binaryWriter_0.Write(bolattribute_0.Length);
				for (int i = 0; i < bolattribute_0.Length; i++)
				{
					binaryWriter_0.Write((byte)bolattribute_0[i].m_attributeType);
					binaryWriter_0.Write((byte)bolattribute_0[i].m_attributeValue.m_type);
					binaryWriter_0.Write((byte)bolattribute_0[i].m_attributeValue.m_affectType);
					binaryWriter_0.Write(bolattribute_0[i].m_attributeValue.vmethod_4());
				}
			}
		}

		// Token: 0x04001D18 RID: 7448
		private SubPartStoreSetup m_setup;
	}

	// Token: 0x02000649 RID: 1609
	internal class RarityBinaryGenerator : BinaryLotGenerator.BinaryGenerator
	{
		// Token: 0x060028BA RID: 10426 RVA: 0x0001ABAC File Offset: 0x00018DAC
		public RarityBinaryGenerator()
		{
			this.input = "Assets/Resources/WeaponEditor/";
			this.output = "Assets/Resources/WeaponEditor/Bin/";
			this.filter = "Rarity.xml";
		}

		// Token: 0x060028BB RID: 10427 RVA: 0x000C0B44 File Offset: 0x000BED44
		protected override bool vmethod_0()
		{
			bool flag = false;
			using (MemoryStream memoryStream = new MemoryStream(this.textAsset.bytes))
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(RarityStore));
					this.m_rarity = (RarityStore)xmlSerializer.Deserialize(memoryStream);
					flag = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(this.textAsset);
				}
			}
			return flag;
		}

		// Token: 0x060028BC RID: 10428 RVA: 0x000C0BD4 File Offset: 0x000BEDD4
		public override void vmethod_1()
		{
			Stream stream = base.method_2(this.output);
			using (BinaryWriter binaryWriter = new BinaryWriter(stream))
			{
				for (int i = 0; i < 5; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						for (int k = 0; k < 9; k++)
						{
							int count = this.m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts.Count;
							binaryWriter.Write(count);
							for (int l = 0; l < count; l++)
							{
								binaryWriter.Write(this.m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_subpartIndex);
								binaryWriter.Write(this.m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_probability);
								binaryWriter.Write((byte)this.m_rarity.m_weaponRarityAttr[i].m_weaponRarityType[j].m_subPartTypes[k].m_subParts[l].m_modifier);
							}
						}
					}
				}
				stream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x04001D19 RID: 7449
		private RarityStore m_rarity;
	}

	// Token: 0x0200064A RID: 1610
	internal class WeaponBinaryGenerator : BinaryLotGenerator.BinaryGenerator
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0001ABD5 File Offset: 0x00018DD5
		public WeaponBinaryGenerator()
		{
			this.input = "Assets/Resources/WeaponEditor/";
			this.output = "Assets/Resources/WeaponEditor/Bin/";
			this.filter = "Weapon.xml";
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x000C0D74 File Offset: 0x000BEF74
		protected override bool vmethod_0()
		{
			bool flag = false;
			using (MemoryStream memoryStream = new MemoryStream(this.textAsset.bytes))
			{
				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponStore));
					this.m_weapon = (WeaponStore)xmlSerializer.Deserialize(memoryStream);
					flag = true;
				}
				catch
				{
				}
				finally
				{
					memoryStream.Close();
					Resources.UnloadAsset(this.textAsset);
				}
			}
			return flag;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x000C0E04 File Offset: 0x000BF004
		public override void vmethod_1()
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(base.method_2(this.output)))
			{
				for (int i = 0; i <= 5; i++)
				{
					int count = this.m_weapon.m_weaponDic[i].m_weaponAttribute.Count;
					int j = 0;
					while (j < count)
					{
						bool flag = false;
						float num = 0f;
						try
						{
							num = this.m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.vmethod_4();
							flag = true;
							goto IL_008B;
						}
						catch
						{
							goto IL_008B;
						}
						goto IL_0077;
						IL_007F:
						j++;
						continue;
						IL_0077:
						binaryWriter.Write(num);
						goto IL_007F;
						IL_008B:
						binaryWriter.Write((byte)this.m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeType);
						binaryWriter.Write((byte)this.m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_type);
						binaryWriter.Write((byte)this.m_weapon.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_affectType);
						binaryWriter.Write(flag);
						if (flag)
						{
							goto IL_0077;
						}
						goto IL_007F;
					}
				}
				binaryWriter.BaseStream.Dispose();
				binaryWriter.Close();
			}
		}

		// Token: 0x04001D1A RID: 7450
		private WeaponStore m_weapon;
	}
}
