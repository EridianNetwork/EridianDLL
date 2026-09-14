using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008E7 RID: 2279
	public class ShieldRarityStore
	{
		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06003ECA RID: 16074 RVA: 0x0002A4D7 File Offset: 0x000286D7
		// (set) Token: 0x06003ECB RID: 16075 RVA: 0x0002A4EA File Offset: 0x000286EA
		public static ShieldRarityStore ShieldRarityStore_0
		{
			get
			{
				if (ShieldRarityStore.s_shieldRarityStore == null)
				{
					ShieldRarityStore.smethod_0();
				}
				return ShieldRarityStore.s_shieldRarityStore;
			}
			protected set
			{
				ShieldRarityStore.s_shieldRarityStore = value;
			}
		}

		// Token: 0x06003ECC RID: 16076 RVA: 0x0012B1A8 File Offset: 0x001293A8
		private static void smethod_0()
		{
			ShieldRarityStore.s_shieldRarityStore = new ShieldRarityStore();
			TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/ShieldRarity") as TextAsset;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ShieldRaritySetup));
			using (Stream stream = new MemoryStream(textAsset.bytes))
			{
				ShieldRarityStore.s_shieldRarityStore.m_shieldRaritySetup = (ShieldRaritySetup)xmlSerializer.Deserialize(stream);
				stream.Close();
			}
			Resources.UnloadAsset(textAsset);
			DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}

		// Token: 0x06003ECD RID: 16077 RVA: 0x0012B23C File Offset: 0x0012943C
		public int method_0(ItemRarity itemRarity_0, ShieldSubPart shieldSubPart_0)
		{
			if (itemRarity_0 < (ItemRarity)this.m_shieldRaritySetup.m_shieldRarities.Length && shieldSubPart_0 < (ShieldSubPart)this.m_shieldRaritySetup.m_shieldRarities[(int)itemRarity_0].m_subparts.Length)
			{
				for (int i = 0; i < this.m_shieldRaritySetup.m_shieldRarities.Length; i++)
				{
					if (this.m_shieldRaritySetup.m_shieldRarities[i].m_rarity == (ShieldRarity)itemRarity_0)
					{
						for (int j = 0; j < this.m_shieldRaritySetup.m_shieldRarities[i].m_subparts.Length; j++)
						{
							if (this.m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_shieldSubpart == shieldSubPart_0)
							{
								float num = 0f;
								foreach (ShieldSubpartChoice shieldSubpartChoice in this.m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_subpartChoices)
								{
									num += shieldSubpartChoice.m_probability;
								}
								float num2 = global::UnityEngine.Random.Range(0f, num);
								float num3 = 0f;
								foreach (ShieldSubpartChoice shieldSubpartChoice2 in this.m_shieldRaritySetup.m_shieldRarities[i].m_subparts[j].m_subpartChoices)
								{
									if (num2 >= num3 && num2 < num3 + shieldSubpartChoice2.m_probability)
									{
										return shieldSubpartChoice2.m_subpartIndex;
									}
									num3 += shieldSubpartChoice2.m_probability;
								}
							}
						}
					}
				}
			}
			DebugUtils.LogWarning(LogCategory.Gamelogic, "Theare are not possibile rarity subpart setup for this shield, will use subpart 0. rarity:" + itemRarity_0.ToString() + ", subpart:" + shieldSubPart_0.ToString());
			return 0;
		}

		// Token: 0x04002C2C RID: 11308
		public const string AssetPath = "Assets/Resources/WeaponEditor/ShieldRarity.XML";

		// Token: 0x04002C2D RID: 11309
		public const string ResourcesAssetPath = "WeaponEditor/ShieldRarity";

		// Token: 0x04002C2E RID: 11310
		public ShieldRaritySetup m_shieldRaritySetup = new ShieldRaritySetup();

		// Token: 0x04002C2F RID: 11311
		private static ShieldRarityStore s_shieldRarityStore;
	}
}
