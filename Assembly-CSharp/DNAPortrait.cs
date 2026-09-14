using System;
using System.Collections;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000710 RID: 1808
public class DNAPortrait : MonoSingleton<DNAPortrait>
{
	// Token: 0x06002FF7 RID: 12279 RVA: 0x0001F722 File Offset: 0x0001D922
	private DNAPortrait()
	{
		this._mapPortraitDataCache = new Dictionary<int, DNAPortraitData>();
	}

	// Token: 0x06002FF8 RID: 12280 RVA: 0x000DB124 File Offset: 0x000D9324
	public void method_0()
	{
		foreach (KeyValuePair<int, DNAPortraitData> keyValuePair in this._mapPortraitDataCache)
		{
			global::UnityEngine.Object.Destroy(keyValuePair.Value.model);
			global::UnityEngine.Object.Destroy(keyValuePair.Value.tex);
		}
		this._mapPortraitDataCache.Clear();
		this.snapData = null;
	}

	// Token: 0x06002FF9 RID: 12281 RVA: 0x000DB1A4 File Offset: 0x000D93A4
	public bool method_1(ItemDNA itemDNA_0)
	{
		if (itemDNA_0.m_type == ItemType.Material)
		{
			return true;
		}
		int hashCode = itemDNA_0.GetHashCode();
		DNAPortraitData dnaportraitData = null;
		return this._mapPortraitDataCache.TryGetValue(hashCode, out dnaportraitData) && dnaportraitData.model != null;
	}

	// Token: 0x06002FFA RID: 12282 RVA: 0x000DB1E4 File Offset: 0x000D93E4
	public DNAPortraitData method_2(ItemDNA itemDNA_0)
	{
		int hashCode = itemDNA_0.GetHashCode();
		DNAPortraitData dnaportraitData = null;
		this._mapPortraitDataCache.TryGetValue(hashCode, out dnaportraitData);
		return dnaportraitData;
	}

	// Token: 0x06002FFB RID: 12283 RVA: 0x000DB20C File Offset: 0x000D940C
	public Texture2D method_3(ItemDNA itemDNA_0, int int_0 = 0, int int_1 = 0, TexPostEffectMgr.POST_EFFECT_TYPE post_EFFECT_TYPE_0 = TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI)
	{
		Texture2D texture2D = null;
		if (itemDNA_0.m_type == ItemType.Material)
		{
			return texture2D;
		}
		int hashCode = itemDNA_0.GetHashCode();
		DNAPortraitData dnaportraitData = null;
		this._mapPortraitDataCache.TryGetValue(hashCode, out dnaportraitData);
		bool flag = false;
		if (dnaportraitData == null)
		{
			if (int_0 > 0 && int_1 > 0)
			{
				dnaportraitData = new DNAPortraitData(int_0, int_1);
			}
			else
			{
				dnaportraitData = new DNAPortraitData();
			}
			dnaportraitData.dna = itemDNA_0;
			dnaportraitData.boundPostEffect = post_EFFECT_TYPE_0;
			this._mapPortraitDataCache.Add(hashCode, dnaportraitData);
			flag = true;
		}
		else if (dnaportraitData.boundPostEffect != post_EFFECT_TYPE_0)
		{
			dnaportraitData.boundPostEffect = post_EFFECT_TYPE_0;
			flag = true;
		}
		texture2D = dnaportraitData.tex;
		if (flag)
		{
			if (itemDNA_0.m_type == ItemType.Weapon)
			{
				WeaponDNA weaponDNA = itemDNA_0.method_6();
				base.StartCoroutine(this.method_4(weaponDNA, texture2D, this._mapPortraitDataCache[hashCode]));
			}
			else if (itemDNA_0.m_type == ItemType.Shield)
			{
				this.method_6(itemDNA_0, texture2D, this._mapPortraitDataCache[hashCode]);
			}
			else if (itemDNA_0.m_type == ItemType.ClassMode)
			{
				this.method_8(itemDNA_0, texture2D, this._mapPortraitDataCache[hashCode]);
			}
		}
		return texture2D;
	}

	// Token: 0x06002FFC RID: 12284 RVA: 0x000DB308 File Offset: 0x000D9508
	private IEnumerator method_4(WeaponDNA weaponDNA_0, Texture2D texture2D_0, DNAPortraitData dnaportraitData_0)
	{
		GameObject model = null;
		if (dnaportraitData_0.model == null)
		{
			model = new GameObject(weaponDNA_0.m_name);
			model.transform.parent = base.gameObject.transform;
			model.transform.localPosition = Vector3.zero;
			model.transform.localRotation = Quaternion.identity;
			yield return StartCoroutine(ns0.MonoSingleton<WeaponFactory>.Instance.method_4(weaponDNA_0, model));
		}
		model.layer = LayerMask.NameToLayer("UI");
		model.SetActive(value: true);
		Matrix4x4 toWorldMat = Matrix4x4.identity;
		toWorldMat.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, -90f, 0f)), Vector3.one * 0.5f);
		SkinnedMeshRenderer mesh = model.GetComponentInChildren<SkinnedMeshRenderer>();
		if (mesh != null)
		{
			ns0.MonoSingleton<GraphicsMgr>.Instance.method_19().method_2(mesh, ref toWorldMat, texture2D_0, dnaportraitData_0.boundPostEffect);
		}
		model.SetActive(value: false);
		dnaportraitData_0.model = model;
	}
	// Token: 0x06002FFD RID: 12285 RVA: 0x0001F735 File Offset: 0x0001D935
	private void method_5()
	{
		this.snapData = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<UISnapData>();
	}

	// Token: 0x06002FFE RID: 12286 RVA: 0x000DB350 File Offset: 0x000D9550
	private void method_6(ItemDNA itemDNA_0, Texture2D texture2D_0, DNAPortraitData dnaportraitData_0)
	{
		if (this.snapData == null)
		{
			this.method_5();
		}
		GameObject gameObject = dnaportraitData_0.model;
		if (gameObject == null)
		{
			gameObject = new GameObject(itemDNA_0.method_7().m_shieldManufacturer.ToString());
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			MonoSingleton<WeaponFactory>.Instance.method_5(itemDNA_0, gameObject);
		}
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.SetActive(true);
		float shield_Scale = this.snapData.m_Shield_Scale;
		Vector3 shield_Rot = this.snapData.m_Shield_Rot;
		Matrix4x4 identity = Matrix4x4.identity;
		identity.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(shield_Rot), Vector3.one * shield_Scale);
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_19().method_2(componentInChildren, ref identity, texture2D_0, dnaportraitData_0.boundPostEffect);
		}
		gameObject.SetActive(false);
		dnaportraitData_0.model = gameObject;
	}

	// Token: 0x06002FFF RID: 12287 RVA: 0x000DB47C File Offset: 0x000D967C
	private void method_7(ItemDNA itemDNA_0, out Matrix4x4 matrix4x4_0)
	{
		matrix4x4_0 = Matrix4x4.identity;
		float num = 1f;
		Vector3 vector = new Vector3(0f, 180f, 0f);
		switch (itemDNA_0.m_classMode.m_cmType)
		{
		case ClassModeType.SoldierDemoMan:
		case ClassModeType.SoldierMachinist:
			num = this.snapData.m_ClassMode_SOLDIER_Scale;
			vector = this.snapData.m_ClassMode_SOLDIER_Rot;
			break;
		case ClassModeType.SirenEnchanter:
		case ClassModeType.SirenSorcerer:
			num = this.snapData.m_ClassMode_SIREN_Scale;
			vector = this.snapData.m_ClassMode_SIREN_Rot;
			break;
		case ClassModeType.BerserkerGuardian:
		case ClassModeType.BerserkerButcher:
			num = this.snapData.m_ClassMode_BERSERKER_Scale;
			vector = this.snapData.m_ClassMode_BERSERKER_Rot;
			break;
		case ClassModeType.HunterAgent:
		case ClassModeType.HunterMarksman:
			num = this.snapData.m_ClassMode_HUNTER_Scale;
			vector = this.snapData.m_ClassMode_HUNTER_Rot;
			break;
		}
		matrix4x4_0.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(vector), Vector3.one * num);
	}

	// Token: 0x06003000 RID: 12288 RVA: 0x000DB578 File Offset: 0x000D9778
	private void method_8(ItemDNA itemDNA_0, Texture2D texture2D_0, DNAPortraitData dnaportraitData_0)
	{
		if (this.snapData == null)
		{
			this.method_5();
		}
		GameObject gameObject = dnaportraitData_0.model;
		if (gameObject == null)
		{
			gameObject = new GameObject(itemDNA_0.method_8().m_cmType.ToString());
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			MonoSingleton<WeaponFactory>.Instance.method_6(itemDNA_0, gameObject);
		}
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.SetActive(true);
		Matrix4x4 identity = Matrix4x4.identity;
		this.method_7(itemDNA_0, out identity);
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_19().method_2(componentInChildren, ref identity, texture2D_0, dnaportraitData_0.boundPostEffect);
		}
		gameObject.SetActive(false);
		dnaportraitData_0.model = gameObject;
	}

	// Token: 0x04002151 RID: 8529
	private Dictionary<int, DNAPortraitData> _mapPortraitDataCache;

	// Token: 0x04002152 RID: 8530
	private UISnapData snapData;
}
