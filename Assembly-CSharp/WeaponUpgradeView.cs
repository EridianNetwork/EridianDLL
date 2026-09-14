using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000762 RID: 1890
public class WeaponUpgradeView : BaseView
{
	// Token: 0x06003212 RID: 12818 RVA: 0x000209D6 File Offset: 0x0001EBD6
	public virtual void vmethod_5()
	{
		if (this.weaponContainer == null)
		{
			this.method_4();
		}
	}

	// Token: 0x06003213 RID: 12819 RVA: 0x000E29FC File Offset: 0x000E0BFC
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			this.vmethod_5();
		}
		else
		{
			if (this.defaultParticle != null)
			{
				this.defaultParticle.SetActive(false);
			}
			if (this.successParticle != null)
			{
				this.successParticle.SetActive(false);
			}
			if (this.failureParticle != null)
			{
				this.failureParticle.SetActive(false);
			}
			if (this.weaponModel != null)
			{
				global::UnityEngine.Object.Destroy(this.weaponModel);
				this.weaponModel = null;
			}
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		}
	}

	// Token: 0x06003214 RID: 12820 RVA: 0x000E2AA0 File Offset: 0x000E0CA0
	protected virtual void vmethod_6()
	{
		WeaponDNA weaponDNA = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(weaponIndex).method_6();
		ConsumedMaterial[] array = StarLevelAttributeStore.StarLevelAttributeStore_0.method_2(weaponDNA.method_1());
		bool flag = true;
		for (int i = 0; i < array.Length; i++)
		{
			if (ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(array[i].m_consumedMaterialType) < array[i].m_consumedMaterialNums)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			vmethod_8();
		}
		else
		{
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Material")), OnDailogTaped);
		}
	}
	// Token: 0x06003215 RID: 12821 RVA: 0x000E2B40 File Offset: 0x000E0D40
	protected virtual void vmethod_7()
	{
		WeaponDNA weaponDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(this.weaponIndex).method_6();
		ItemConsume itemConsume = StarLevelAttributeStore.StarLevelAttributeStore_0.method_3(weaponDNA.method_1(), weaponDNA.m_starLevel);
		if (itemConsume == null)
		{
			return;
		}
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(itemConsume.m_materialType) < itemConsume.m_materialNums)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Material")), new Delegate_EventProc(this.OnDailogTaped), null);
			return;
		}
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12() != null && ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().BondCurrency >= itemConsume.m_itemNums)
		{
			this.vmethod_9();
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Currency")), new Delegate_EventProc(this.OnDailogTaped), null);
		}
	}

	// Token: 0x06003216 RID: 12822 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void OnDailogTaped()
	{
	}

	// Token: 0x06003217 RID: 12823 RVA: 0x000209EC File Offset: 0x0001EBEC
	protected virtual void vmethod_8()
	{
		this.vmethod_11();
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.Prop_0.imethod_3(new OnUpgradeStarExperience(this.OnExperienceUpdate), this.weaponIndex);
	}

	// Token: 0x06003218 RID: 12824 RVA: 0x00020A11 File Offset: 0x0001EC11
	protected virtual void vmethod_9()
	{
		this.vmethod_11();
		OnAccessSingleton<ICraftingService, CraftingService, CraftingServiceOffline>.Prop_0.imethod_4(new OnUpgradeStarLevel(this.OnLevelUpdate), this.weaponIndex);
		MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_upgrade");
	}

	// Token: 0x06003219 RID: 12825 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_10()
	{
	}

	// Token: 0x0600321A RID: 12826 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_11()
	{
	}

	// Token: 0x0600321B RID: 12827 RVA: 0x00020A45 File Offset: 0x0001EC45
	protected virtual void vmethod_12()
	{
		this.successParticle.SetActive(true);
		this.successParticle.GetComponent<ParticleSystem>().Play();
	}

	// Token: 0x0600321C RID: 12828 RVA: 0x00020A63 File Offset: 0x0001EC63
	protected virtual void vmethod_13()
	{
		this.failureParticle.SetActive(true);
		this.failureParticle.GetComponent<ParticleSystem>().Play();
	}

	// Token: 0x0600321D RID: 12829 RVA: 0x000E2C24 File Offset: 0x000E0E24
	public virtual void OnLevelUpdate(bool success, ItemDNA newWeapon)
	{
		this.vmethod_10();
		if (success)
		{
			this.vmethod_14(newWeapon, false, false);
			this.vmethod_12();
		}
		else
		{
			this.vmethod_14(newWeapon, false, true);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Failed")), new Delegate_EventProc(this.OnDailogTaped), null);
			this.vmethod_13();
		}
	}

	// Token: 0x0600321E RID: 12830 RVA: 0x000E2C8C File Offset: 0x000E0E8C
	public virtual void OnExperienceUpdate(ItemDNA newWeapon)
	{
		this.vmethod_10();
		if (newWeapon != null)
		{
			this.vmethod_14(newWeapon, false, true);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Failed")), new Delegate_EventProc(this.OnDailogTaped), null);
		}
	}

	// Token: 0x0600321F RID: 12831 RVA: 0x000E2CE0 File Offset: 0x000E0EE0
	public virtual void vmethod_14(ItemDNA itemDNA_0, bool bool_0 = true, bool bool_1 = true)
	{
		if (!bool_0)
		{
			return;
		}
		if (itemDNA_0 == null)
		{
			return;
		}
		if (this.weaponModel != null)
		{
			global::UnityEngine.Object.Destroy(this.weaponModel);
		}
		this.defaultParticle.SetActive(false);
		if (this.weaponContainer == null)
		{
			this.method_4();
		}
		MonoSingleton<WeaponFactory>.Instance.method_1(itemDNA_0.method_6(), new WeaponFactory.WeaponCreatedCallBack(this.method_3));
	}

	// Token: 0x06003220 RID: 12832 RVA: 0x000E2D4C File Offset: 0x000E0F4C
	public void method_3(ref GameObject gameObject_0, WeaponDNA weaponDNA_0)
	{
		if (this.weaponContainer != null)
		{
			gameObject_0.transform.parent = this.weaponContainer.transform;
			gameObject_0.transform.localRotation = this.weaponPosition[weaponDNA_0.m_type].localRotation;
			gameObject_0.transform.localPosition = this.weaponPosition[weaponDNA_0.m_type].localPosition;
			gameObject_0.transform.localScale = this.weaponPosition[weaponDNA_0.m_type].localScale;
			this.weaponModel = gameObject_0;
		}
		this.defaultParticle.SetActive(true);
		this.defaultParticle.GetComponent<ParticleSystem>().Play();
	}

	// Token: 0x06003221 RID: 12833 RVA: 0x000E2E0C File Offset: 0x000E100C
	private void method_4()
	{
		this.weaponPosition = new Dictionary<WeaponType, Transform>();
		GameObject upgradeCamera = NPC_UIFlowController.smethod_0().method_0().UpgradeCamera;
		if (upgradeCamera == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "weapon upgrade Container is null!!! ");
			return;
		}
		Transform transform = upgradeCamera.transform;
		int num = 0;
		while (transform != null && num < 10 && !(transform.name == "PRO_WeaponUpgrade"))
		{
			transform = transform.parent;
			num++;
		}
		if (transform == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "weapon upgrade Container is null!!! ");
			return;
		}
		this.weaponContainer = transform.gameObject;
		if (this.weaponContainer != null)
		{
			Transform[] componentsInChildren = this.weaponContainer.GetComponentsInChildren<Transform>(true);
			if (componentsInChildren != null)
			{
				foreach (Transform transform2 in componentsInChildren)
				{
					string name = transform2.name;
					if (name != null)
					{
						int length = name.Length;
						if (length != 14)
						{
							if (length == 26)
							{
								char c = name[19];
								if (c != 'D')
								{
									if (c != 'F')
									{
										if (c == 'S')
										{
											if (name == "PTL_Weapon_Upgrade_Success")
											{
												this.successParticle = transform2.gameObject;
											}
										}
									}
									else if (name == "PTL_Weapon_Upgrade_Failure")
									{
										this.failureParticle = transform2.gameObject;
									}
								}
								else if (name == "PTL_Weapon_Upgrade_Default")
								{
									this.defaultParticle = transform2.gameObject;
								}
							}
						}
						else
						{
							char c = name[5];
							if (c != 'H')
							{
								switch (c)
								{
								case 'M':
									if (name == "WPN_SMG_ground")
									{
										this.weaponPosition[WeaponType.SMG] = transform2;
									}
									break;
								case 'N':
									if (name == "WPN_SNR_ground")
									{
										this.weaponPosition[WeaponType.SniperRifle] = transform2;
									}
									break;
								case 'O':
									if (name == "WPN_COR_ground")
									{
										this.weaponPosition[WeaponType.CombatRifle] = transform2;
									}
									break;
								}
							}
							else if (name == "WPN_SHN_ground")
							{
								this.weaponPosition[WeaponType.ShotGun] = transform2;
								this.weaponPosition[WeaponType.RepeaterPistol] = transform2;
							}
						}
					}
				}
				return;
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.GUI, "weapon upgrade Container is null!!! ");
		}
	}

	// Token: 0x06003222 RID: 12834 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x04002293 RID: 8851
	protected int weaponIndex;

	// Token: 0x04002294 RID: 8852
	protected GameObject weaponModel;

	// Token: 0x04002295 RID: 8853
	protected GameObject weaponContainer;

	// Token: 0x04002296 RID: 8854
	protected GameObject defaultParticle;

	// Token: 0x04002297 RID: 8855
	protected GameObject successParticle;

	// Token: 0x04002298 RID: 8856
	protected GameObject failureParticle;

	// Token: 0x04002299 RID: 8857
	protected Dictionary<WeaponType, Transform> weaponPosition;
}
