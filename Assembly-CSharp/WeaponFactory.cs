using System;
using System.Collections;
using System.Diagnostics;
using ns0;
using UnityEngine;
using XsdSettings;

using System.Collections.Generic;
// Token: 0x02000903 RID: 2307
public class WeaponFactory : MonoSingleton<WeaponFactory>
{
	// Token: 0x06003F9C RID: 16284 RVA: 0x0002AB98 File Offset: 0x00028D98
	protected override void Awake()
	{
		base.Awake();
	}

	// Token: 0x06003F9D RID: 16285 RVA: 0x0002ABA0 File Offset: 0x00028DA0
	private void Start()
	{
		this.weaponElementalObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/WeaponElementalManager"));
		this.weaponElementalObject.transform.parent = base.gameObject.transform;
	}

	// Token: 0x06003F9E RID: 16286 RVA: 0x0002ABD7 File Offset: 0x00028DD7
	public GameObject method_0()
	{
		return this.weaponElementalObject;
	}

	// Token: 0x06003F9F RID: 16287 RVA: 0x0002ABDF File Offset: 0x00028DDF
	public void method_1(WeaponDNA weaponDNA_0, WeaponFactory.WeaponCreatedCallBack weaponCreatedCallBack_0)
	{
		if (weaponCreatedCallBack_0 == null)
		{
			return;
		}
		base.StartCoroutine(this.method_2(weaponDNA_0, weaponCreatedCallBack_0));
	}

	// Token: 0x06003FA0 RID: 16288 RVA: 0x0012D40C File Offset: 0x0012B60C
	private IEnumerator method_2(WeaponDNA weaponDNA_0, WeaponCreatedCallBack weaponCreatedCallBack_0)
	{
		CoroutineParam param = new CoroutineParam();
		yield return StartCoroutine(method_3(weaponDNA_0, param));
		weaponCreatedCallBack_0(ref param.model, weaponDNA_0);
	}
	// Token: 0x06003FA1 RID: 16289 RVA: 0x0012D444 File Offset: 0x0012B644
	private IEnumerator method_3(WeaponDNA weaponDNA_0, CoroutineParam coroutineParam_0)
	{
		BuildingPart[] buidingParts = new BuildingPart[weaponDNA_0.m_subPartsCode.Length];
		for (int j = 0; j < weaponDNA_0.m_subPartsCode.Length; j++)
		{
			buidingParts[j] = new BuildingPart(SubPartWeaponStore.SubPartWeaponStore_0.method_1(weaponDNA_0.m_subPartsCode[j]));
		}
		BuildingKitRender buildingUnitRender = new BuildingKitRender(new BuildingUnit(buidingParts));
		BuildingKit kit = BuildingKitManager.smethod_0(buildingUnitRender.BuildingUnit_0.bkID);
		byte matIndex = buildingUnitRender.BuildingUnit_0.mMats[buildingUnitRender.BuildingUnit_0.mMats.Count - 1];
		for (int i = 0; i < kit.method_5(); i++)
		{
			buildingUnitRender.BuildingUnit_0.mMats[i] = matIndex;
		}
		if (!ns0.MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			List<string> resources = buildingUnitRender.method_17();
			if (resources.Count > 0)
			{
				yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(resources, OnAssetBundleLoaded, buildingUnitRender));
				while (buildingUnitRender.Boolean_0)
				{
					yield return null;
				}
			}
		}
		coroutineParam_0.model = buildingUnitRender.method_6();
	}
	// Token: 0x06003FA2 RID: 16290 RVA: 0x0012D47C File Offset: 0x0012B67C
	public IEnumerator method_4(WeaponDNA weaponDNA_0, GameObject gameObject_0)
	{
		CoroutineParam param = new CoroutineParam();
		yield return StartCoroutine(method_3(weaponDNA_0, param));
		if (param.model != null)
		{
			param.model.transform.parent = gameObject_0.transform;
			param.model.transform.localPosition = Vector3.zero;
			param.model.transform.localRotation = Quaternion.identity;
		}
	}
	// Token: 0x06003FA3 RID: 16291 RVA: 0x0012D4B4 File Offset: 0x0012B6B4
	public GameObject method_5(ItemDNA itemDNA_0, GameObject gameObject_0)
	{
		WeaponFactory.CoroutineParam coroutineParam = new WeaponFactory.CoroutineParam();
		string text = ItemGeneratorService.smethod_0(itemDNA_0);
		coroutineParam.model = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), Vector3.zero, Quaternion.identity);
		if (coroutineParam.model != null)
		{
			coroutineParam.model.transform.parent = gameObject_0.transform;
			coroutineParam.model.transform.localPosition = Vector3.zero;
			coroutineParam.model.transform.localRotation = Quaternion.identity;
			global::UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<Pickable>());
			global::UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<EntityShield>());
		}
		return coroutineParam.model;
	}

	// Token: 0x06003FA4 RID: 16292 RVA: 0x0012D564 File Offset: 0x0012B764
	public GameObject method_6(ItemDNA itemDNA_0, GameObject gameObject_0)
	{
		WeaponFactory.CoroutineParam coroutineParam = new WeaponFactory.CoroutineParam();
		string text = ItemGeneratorService.smethod_0(itemDNA_0);
		coroutineParam.model = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text), Vector3.zero, Quaternion.identity);
		if (coroutineParam.model != null)
		{
			coroutineParam.model.transform.parent = gameObject_0.transform;
			coroutineParam.model.transform.localPosition = Vector3.zero;
			coroutineParam.model.transform.localRotation = Quaternion.identity;
			global::UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<Pickable>());
			global::UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<EntityClassMode>());
		}
		return coroutineParam.model;
	}

	// Token: 0x06003FA5 RID: 16293 RVA: 0x0012D614 File Offset: 0x0012B814
	private void OnAssetBundleLoaded(object param = null)
	{
		if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			BuildingKitRender buildingKitRender = (BuildingKitRender)param;
			buildingKitRender.method_4(true);
		}
	}

	// Token: 0x06003FA6 RID: 16294 RVA: 0x0012D63C File Offset: 0x0012B83C
	public void method_7(EntityWeapon entityWeapon_0)
	{
		if (entityWeapon_0.method_99() == WeaponType.ShotGun)
		{
			string text = "WPN_SHN_mag" + entityWeapon_0.method_18(WeaponSubPart.MAG) + "_1";
			foreach (object obj in entityWeapon_0.transform)
			{
				Transform transform = (Transform)obj;
				if (transform.name == text)
				{
					global::UnityEngine.Object.DestroyImmediate(transform.gameObject);
					break;
				}
			}
		}
	}

	// Token: 0x04002CBE RID: 11454
	private GameObject weaponElementalObject;

	// Token: 0x02000904 RID: 2308
	private class CoroutineParam
	{
		// Token: 0x04002CBF RID: 11455
		public GameObject model;
	}

	// Token: 0x02000905 RID: 2309
	// (Invoke) Token: 0x06003FA9 RID: 16297
	public delegate void WeaponCreatedCallBack(ref GameObject model, WeaponDNA dna);
}
