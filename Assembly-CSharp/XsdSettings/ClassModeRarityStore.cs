using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008C9 RID: 2249
	public class ClassModeRarityStore
	{
		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06003E3B RID: 15931 RVA: 0x0002A0A9 File Offset: 0x000282A9
		// (set) Token: 0x06003E3C RID: 15932 RVA: 0x0002A0BC File Offset: 0x000282BC
		public static ClassModeRarityStore ClassModeRarityStore_0
		{
			get
			{
				if (ClassModeRarityStore.s_classModeRarityStore == null)
				{
					ClassModeRarityStore.smethod_0();
				}
				return ClassModeRarityStore.s_classModeRarityStore;
			}
			protected set
			{
				ClassModeRarityStore.s_classModeRarityStore = value;
			}
		}

		// Token: 0x06003E3D RID: 15933 RVA: 0x00128870 File Offset: 0x00126A70
		private static void smethod_0()
		{
			ClassModeRarityStore.s_classModeRarityStore = new ClassModeRarityStore();
			TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/ClassModeRarity") as TextAsset;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ClassModeRaritySetup));
			using (Stream stream = new MemoryStream(textAsset.bytes))
			{
				ClassModeRarityStore.s_classModeRarityStore.m_classModeRaritySetup = (ClassModeRaritySetup)xmlSerializer.Deserialize(stream);
				stream.Close();
			}
			Resources.UnloadAsset(textAsset);
			DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}

		// Token: 0x06003E3E RID: 15934 RVA: 0x00128904 File Offset: 0x00126B04
		public int method_0(ClassModeType classModeType_0, ItemRarity itemRarity_0, ClassModeSubPart classModeSubPart_0)
		{
			if (classModeType_0 < (ClassModeType)this.m_classModeRaritySetup.m_classModeRarities.Length && itemRarity_0 < (ItemRarity)this.m_classModeRaritySetup.m_classModeRarities[(int)classModeType_0].m_raritiyTypes.Length && classModeSubPart_0 < (ClassModeSubPart)this.m_classModeRaritySetup.m_classModeRarities[(int)classModeType_0].m_raritiyTypes[(int)itemRarity_0].m_subparts.Length)
			{
				for (int i = 0; i < this.m_classModeRaritySetup.m_classModeRarities.Length; i++)
				{
					if (this.m_classModeRaritySetup.m_classModeRarities[i].m_classModeType == classModeType_0)
					{
						for (int j = 0; j < this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes.Length; j++)
						{
							if (this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_rarity == itemRarity_0)
							{
								for (int k = 0; k < this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts.Length; k++)
								{
									if (this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_classModeSubpart == classModeSubPart_0)
									{
										float num = 0f;
										foreach (ClassModeSubpartChoice classModeSubpartChoice in this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_subpartChoices)
										{
											num += classModeSubpartChoice.m_probability;
										}
										float num2 = global::UnityEngine.Random.Range(0f, num);
										float num3 = 0f;
										foreach (ClassModeSubpartChoice classModeSubpartChoice2 in this.m_classModeRaritySetup.m_classModeRarities[i].m_raritiyTypes[j].m_subparts[k].m_subpartChoices)
										{
											if (num2 >= num3 && num2 < num3 + classModeSubpartChoice2.m_probability)
											{
												return classModeSubpartChoice2.m_subpartIndex;
											}
											num3 += classModeSubpartChoice2.m_probability;
										}
									}
								}
							}
						}
					}
				}
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "Theare are not possibile rarity subpart setup for this classMode, will use subpart 0. rarity:" + itemRarity_0.ToString() + ", subpart:" + classModeSubPart_0.ToString());
			return 0;
		}

		// Token: 0x04002BC4 RID: 11204
		public const string AssetPath = "Assets/Resources/WeaponEditor/ClassModeRarity.XML";

		// Token: 0x04002BC5 RID: 11205
		public const string ResourcesAssetPath = "WeaponEditor/ClassModeRarity";

		// Token: 0x04002BC6 RID: 11206
		public ClassModeRaritySetup m_classModeRaritySetup = new ClassModeRaritySetup();

		// Token: 0x04002BC7 RID: 11207
		private static ClassModeRarityStore s_classModeRarityStore;
	}
}
