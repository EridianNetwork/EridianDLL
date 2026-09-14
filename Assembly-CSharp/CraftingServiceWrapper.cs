using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020002D3 RID: 723
public class CraftingServiceWrapper : ServiceWrapper<IServiceWrapper, CraftingServiceWrapper>
{
	// Token: 0x06000FFC RID: 4092 RVA: 0x00075760 File Offset: 0x00073960
	public override void vmethod_1()
	{
		base.vmethod_1();
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/WeaponMelting");
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeaponMeltManager));
		this.m_meltMgr = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as WeaponMeltManager;
		Resources.UnloadAsset(textAsset);
		textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/WeaponCrafting");
		xmlSerializer = new XmlSerializer(typeof(WeaponCraftManager));
		this.m_craftMgr = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as WeaponCraftManager;
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06000FFD RID: 4093 RVA: 0x000757F8 File Offset: 0x000739F8
	public int method_0(WeaponDNA weaponDNA_0, out AcquiredMaterial[] acquiredMaterial_0)
	{
		acquiredMaterial_0 = null;
		if (weaponDNA_0 != null)
		{
			if (this.m_meltMgr != null && this.m_meltMgr.m_WeaponMeltConfigs != null)
			{
				for (int i = 0; i < this.m_meltMgr.m_WeaponMeltConfigs.Length; i++)
				{
					if (weaponDNA_0.m_level >= this.m_meltMgr.m_WeaponMeltConfigs[i].m_MinWeaponLevel && weaponDNA_0.m_level <= this.m_meltMgr.m_WeaponMeltConfigs[i].m_MaxWeaponLevel && weaponDNA_0.m_rarity == this.m_meltMgr.m_WeaponMeltConfigs[i].m_WeaponRarity && weaponDNA_0.m_type == this.m_meltMgr.m_WeaponMeltConfigs[i].m_WeaponType)
					{
						acquiredMaterial_0 = this.m_meltMgr.m_WeaponMeltConfigs[i].m_AcquiredMaterials;
						return this.m_meltMgr.m_WeaponMeltConfigs[i].m_cost;
					}
				}
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "the melted weapon is not exist or it dosen't have DNA");
		}
		return 0;
	}

	// Token: 0x06000FFE RID: 4094 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_2()
	{
		return true;
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x0000DA30 File Offset: 0x0000BC30
	public void method_1(OnSmeltWeapon onSmeltWeapon_0, int int_0)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.Prop_0.imethod_0(onSmeltWeapon_0, int_0);
	}

	// Token: 0x06001000 RID: 4096 RVA: 0x0000DA3E File Offset: 0x0000BC3E
	public void method_2(OnCraftWeapon onCraftWeapon_0, WeaponType weaponType_0)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.Prop_0.imethod_1(onCraftWeapon_0, weaponType_0);
	}

	// Token: 0x06001001 RID: 4097 RVA: 0x0000DA4C File Offset: 0x0000BC4C
	public void method_3(OnGetMyCraftedWeapons onGetMyCraftedWeapons_0)
	{
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.Prop_0.imethod_2(onGetMyCraftedWeapons_0);
	}

	// Token: 0x04000DB9 RID: 3513
	public WeaponMeltManager m_meltMgr;

	// Token: 0x04000DBA RID: 3514
	public WeaponCraftManager m_craftMgr;
}
