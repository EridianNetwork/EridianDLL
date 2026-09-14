using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000909 RID: 2313
[Serializable]
public class WeaponStore
{
	// Token: 0x06003FBE RID: 16318 RVA: 0x0012DA34 File Offset: 0x0012BC34
	public WeaponStore()
	{
	}

	// Token: 0x06003FBF RID: 16319 RVA: 0x0012DAD0 File Offset: 0x0012BCD0
	public WeaponStore(bool bool_0)
	{
		if (bool_0)
		{
			this.m_weaponDic.Clear();
			foreach (object obj in Enum.GetValues(typeof(WeaponType)))
			{
				WeaponType weaponType = (WeaponType)((int)obj);
				this.m_weaponDic.Add(new WeaponAttribute(true, weaponType));
			}
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x06003FC0 RID: 16320 RVA: 0x0002AC27 File Offset: 0x00028E27
	public AttributeType[] AttributePriority
	{
		get
		{
			return this.m_attributePriority;
		}
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x06003FC1 RID: 16321 RVA: 0x0002AC2F File Offset: 0x00028E2F
	public WeaponSubPart[] SubpartPriority
	{
		get
		{
			return this.m_subpartPriority;
		}
	}

	// Token: 0x06003FC2 RID: 16322 RVA: 0x0012DBDC File Offset: 0x0012BDDC
	public void method_0()
	{
		List<WeaponAttribute> list = new List<WeaponAttribute>();
		WeaponType weaponType;
		foreach (int value in Enum.GetValues(typeof(WeaponType)))
		{
			weaponType = (WeaponType)value;
			int num = m_weaponDic.FindIndex((WeaponAttribute weaponAttribute_0) => weaponAttribute_0.m_weaponType == weaponType);
			if (num >= 0)
			{
				list.Add(m_weaponDic[num]);
			}
			else
			{
				list.Add(new WeaponAttribute(bool_0: true, weaponType));
			}
		}
		m_weaponDic = list;
		foreach (WeaponAttribute item in m_weaponDic)
		{
			item.method_0();
		}
	}
	// Token: 0x17000391 RID: 913
	// (get) Token: 0x06003FC3 RID: 16323 RVA: 0x0002AC37 File Offset: 0x00028E37
	// (set) Token: 0x06003FC4 RID: 16324 RVA: 0x0002AC54 File Offset: 0x00028E54
	public static WeaponStore weaponStore
	{
		get
		{
			if (WeaponStore.s_weaponStore == null)
			{
				WeaponStore.smethod_3();
				WeaponStore.s_weaponStore.method_0();
			}
			return WeaponStore.s_weaponStore;
		}
		protected set
		{
			WeaponStore.s_weaponStore = value;
		}
	}

	// Token: 0x06003FC5 RID: 16325 RVA: 0x0012DCDC File Offset: 0x0012BEDC
	public static void smethod_0()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponStore));
		using (TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Weapon.XML"))
		{
			xmlSerializer.Serialize(textWriter, WeaponStore.s_weaponStore);
			textWriter.Close();
		}
	}

	// Token: 0x06003FC6 RID: 16326 RVA: 0x0012DD34 File Offset: 0x0012BF34
	private static void smethod_1()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponStore));
		if (!File.Exists("Assets/Resources/WeaponEditor/Weapon.XML"))
		{
			WeaponStore.s_weaponStore = new WeaponStore(true);
			WeaponStore.smethod_0();
		}
		else
		{
			using (FileStream fileStream = File.OpenRead("Assets/Resources/WeaponEditor/Weapon.XML"))
			{
				WeaponStore.s_weaponStore = (WeaponStore)xmlSerializer.Deserialize(fileStream);
				fileStream.Close();
			}
		}
	}

	// Token: 0x06003FC7 RID: 16327 RVA: 0x0002AC5C File Offset: 0x00028E5C
	public static void smethod_2()
	{
		new BinaryLotGenerator(BinaryType.WeaponBinaryGenerator).method_1();
	}

	// Token: 0x06003FC8 RID: 16328 RVA: 0x0012DDB0 File Offset: 0x0012BFB0
	private static void smethod_3()
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("WeaponEditor/Bin/Weapon") as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			WeaponStore.s_weaponStore = new WeaponStore(true);
			for (int i = 0; i <= 5; i++)
			{
				int count = WeaponStore.s_weaponStore.m_weaponDic[i].m_weaponAttribute.Count;
				for (int j = 0; j < count; j++)
				{
					WeaponStore.s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeType = (AttributeType)binaryReader.ReadByte();
					WeaponStore.s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_type = (AttributeValueType)binaryReader.ReadByte();
					WeaponStore.s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_affectType = (AffectType)binaryReader.ReadByte();
					if (binaryReader.ReadBoolean())
					{
						WeaponStore.s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.vmethod_3(binaryReader.ReadSingle());
					}
				}
			}
			stream.Dispose();
			binaryReader.Close();
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06003FC9 RID: 16329 RVA: 0x0012DF20 File Offset: 0x0012C120
	public void method_1()
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			EntityPlayer entityPlayer = (EntityPlayer)localPlayer.GetEntity();
			EntityWeapon entityWeapon = entityPlayer.vmethod_16();
			entityWeapon.method_17().method_5();
			entityWeapon.method_17().method_13();
			entityWeapon.method_24(entityWeapon.method_17());
			entityWeapon.method_86();
		}
	}

	// Token: 0x04002CDE RID: 11486
	public const string AssetPath = "Assets/Resources/WeaponEditor/Weapon.XML";

	// Token: 0x04002CDF RID: 11487
	public const string ResourcesAssetPath = "WeaponEditor/Bin/Weapon";

	// Token: 0x04002CE0 RID: 11488
	[SerializeField]
	public List<WeaponAttribute> m_weaponDic = new List<WeaponAttribute>();

	// Token: 0x04002CE1 RID: 11489
	private AttributeType[] m_attributePriority = new AttributeType[]
	{
		AttributeType.AccuracyDecrease,
		AttributeType.AmmoRegenerationRate,
		AttributeType.ShotCost,
		AttributeType.WeaponProjectilesPerShot,
		AttributeType.ZoomEndFOV,
		AttributeType.EquipTime,
		AttributeType.CriticalHitScale,
		AttributeType.WeaponDamage,
		AttributeType.AccuracyMax,
		AttributeType.FireRate,
		AttributeType.ReloadTime,
		AttributeType.ClipSize,
		AttributeType.WeaponElementalDamage,
		AttributeType.ElementalProcCoef
	};

	// Token: 0x04002CE2 RID: 11490
	private WeaponSubPart[] m_subpartPriority = new WeaponSubPart[]
	{
		WeaponSubPart.MATERIAL,
		WeaponSubPart.ACC,
		WeaponSubPart.ACTION,
		WeaponSubPart.BODY,
		WeaponSubPart.BARREL,
		WeaponSubPart.MAG,
		WeaponSubPart.STOCK,
		WeaponSubPart.GRIP
	};

	// Token: 0x04002CE3 RID: 11491
	private static WeaponStore s_weaponStore;
}
