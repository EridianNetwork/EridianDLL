using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020005CB RID: 1483
public class NpcTitleMgr
{
	// Token: 0x06002578 RID: 9592 RVA: 0x000B4248 File Offset: 0x000B2448
	public void method_0()
	{
		GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
		NPCTitleEffectData component = gameObject.GetComponent<NPCTitleEffectData>();
		this.mMatTypeDic = new Dictionary<int, Material>();
		this.mNpcNameMaterial = component.mNameMaterial;
		this.mIconDoneMaterial = component.mIconDoneMaterial;
		this.mIconProgressMaterial = component.mIconProgressMaterial;
		this.mIconNewMaterial = component.mIconNewMaterial;
		this.mIconDummyMaterial = component.mIconDummyMaterial;
		this.mIconSkillMaterial = component.mIconArrawMaterial;
		this.mIconDailyQuestNew = component.mDailyNewMaterial;
		this.mIconDailyQuestDone = component.mDailyDoneMaterial;
		this.mIconSpecialQuestNew = component.mSpecialNewMaterial;
		this.mIconSpecialQuestDone = component.mSpecialDoneMaterial;
		this.mIconCraft = component.mIconCraft;
		this.mIconDoc = component.mIconDoc;
		this.mIconGuild = component.mIconGuild;
		this.mIconMail = component.mIconMail;
		this.mIconMailNew = component.mIconMailNew;
		this.mIconShop = component.mIconShop;
		this.mIconUpgrade = component.mIconUpgrade;
		this.mIconPvP = component.mIconPvP;
		this.mMatTypeDic.Add(1, this.mIconDoneMaterial);
		this.mMatTypeDic.Add(2, this.mIconProgressMaterial);
		this.mMatTypeDic.Add(3, this.mIconNewMaterial);
		this.mMatTypeDic.Add(4, this.mIconDailyQuestNew);
		this.mMatTypeDic.Add(5, this.mIconDailyQuestDone);
		this.mMatTypeDic.Add(6, this.mIconSpecialQuestNew);
		this.mMatTypeDic.Add(7, this.mIconSpecialQuestDone);
		this.mMatTypeDic.Add(8, this.mIconCraft);
		this.mMatTypeDic.Add(9, this.mIconDoc);
		this.mMatTypeDic.Add(10, this.mIconGuild);
		this.mMatTypeDic.Add(11, this.mIconMail);
		this.mMatTypeDic.Add(12, this.mIconMailNew);
		this.mMatTypeDic.Add(14, this.mIconShop);
		this.mMatTypeDic.Add(15, this.mIconUpgrade);
		this.mMatTypeDic.Add(16, this.mIconDummyMaterial);
		this.mMatTypeDic.Add(17, this.mIconSkillMaterial);
		this.mMatTypeDic.Add(18, this.mIconPvP);
		this.mSizeChanger = gameObject.GetComponent<BillboardSizeChanger>();
		this.mBillboardAnimator = gameObject.GetComponent<BillboardAnimator>();
		foreach (Material material in component.mNumIconMaterial)
		{
			this.mNumListMaterials.Add(material);
		}
		GameObject gameObject2 = Resources.Load("UI_uniSWF/Fonts/UnityFontManager") as GameObject;
		this.mRefMsyhObj = global::UnityEngine.Object.Instantiate(gameObject2.transform.FindChild("MSYH").gameObject) as GameObject;
		this.mRefTextMesh = this.mRefMsyhObj.GetComponent<TextMesh>();
		this.mRefTextMesh.color = Color.green;
		MeshRenderer component2 = this.mRefMsyhObj.GetComponent<MeshRenderer>();
		Texture texture = component2.material.GetTexture("_MainTex");
		this.mNpcNameMaterial.SetTexture("_MainTex", texture);
		this.mMeshIcon = this.method_1(new Vector3(0f, 0f, 0f));
		this.mMeshNumAboveIcon = this.method_1(new Vector3(0f, 2f, 0f));
		this.method_12();
		this.method_23();
	}

	// Token: 0x06002579 RID: 9593 RVA: 0x000B45A4 File Offset: 0x000B27A4
	private Mesh method_1(Vector3 vector3_0)
	{
		Mesh mesh = new Mesh();
		float num = 1f;
		float num2 = 0.01f;
		mesh.vertices = new Vector3[]
		{
			new Vector3(-1f, -1f, num2) + vector3_0,
			new Vector3(num, -1f, num2) + vector3_0,
			new Vector3(num, num, num2) + vector3_0,
			new Vector3(-1f, num, num2) + vector3_0
		};
		mesh.uv = new Vector2[]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f)
		};
		mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
		return mesh;
	}

	// Token: 0x0600257A RID: 9594 RVA: 0x000B46D8 File Offset: 0x000B28D8
	public void method_2(GameObject gameObject_0, NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE_0)
	{
		TextMesh[] componentsInChildren = gameObject_0.GetComponentsInChildren<TextMesh>(true);
		TextMesh textMesh = null;
		if (componentsInChildren.Length > 0)
		{
			textMesh = componentsInChildren[0];
		}
		if (textMesh)
		{
			GameObject gameObject = textMesh.gameObject.transform.FindChild("Icon").gameObject;
			gameObject.SetActive(true);
			if (gameObject != null)
			{
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					component.gameObject.SetActive(true);
					if (npc_ICON_TYPE_0 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE)
					{
						gameObject.SetActive(false);
					}
					else
					{
						Material material = null;
						if (this.mMatTypeDic.TryGetValue((int)npc_ICON_TYPE_0, out material))
						{
							component.sharedMaterial = material;
						}
						else
						{
							component.gameObject.SetActive(false);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600257B RID: 9595 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_3(GameObject gameObject_0)
	{
	}

	// Token: 0x0600257C RID: 9596 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_4()
	{
	}

	// Token: 0x0600257D RID: 9597 RVA: 0x000B4780 File Offset: 0x000B2980
	public void method_5(GameObject gameObject_0, string string_0)
	{
		TextMesh componentInChildren = gameObject_0.GetComponentInChildren<TextMesh>();
		if (componentInChildren != null)
		{
			componentInChildren.text = string_0;
		}
	}

	// Token: 0x0600257E RID: 9598 RVA: 0x000B47A4 File Offset: 0x000B29A4
	public void method_6(GameObject gameObject_0)
	{
		BassBillboard componentInChildren = gameObject_0.GetComponentInChildren<BassBillboard>();
		if (componentInChildren != null)
		{
			global::UnityEngine.Object.Destroy(componentInChildren.gameObject);
		}
	}

	// Token: 0x0600257F RID: 9599 RVA: 0x000B47CC File Offset: 0x000B29CC
	public void method_7(GameObject gameObject_0, int int_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		if (this.mNumListMaterials == null)
		{
			return;
		}
		if (int_0 < 0 || int_0 > this.mNumListMaterials.Count)
		{
			return;
		}
		TextMesh componentInChildren = gameObject_0.GetComponentInChildren<TextMesh>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren.gameObject == null)
		{
			return;
		}
		Transform transform = componentInChildren.gameObject.transform.FindChild("NumAboveIcon");
		if (transform == null)
		{
			return;
		}
		GameObject gameObject = transform.gameObject;
		if (gameObject == null)
		{
			return;
		}
		gameObject.SetActive(true);
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		if (component == null)
		{
			return;
		}
		if (int_0 == 0)
		{
			gameObject.SetActive(false);
		}
		else
		{
			GameObject gameObject2 = component.gameObject;
			if (gameObject2 == null)
			{
				return;
			}
			gameObject2.SetActive(true);
			component.sharedMaterial = this.mNumListMaterials[int_0 - 1];
		}
	}

	// Token: 0x06002580 RID: 9600 RVA: 0x000B48AC File Offset: 0x000B2AAC
	public void method_8(GameObject gameObject_0, NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE_0, bool bool_0)
	{
		TextMesh componentInChildren = gameObject_0.GetComponentInChildren<TextMesh>();
		if (componentInChildren == null)
		{
			return;
		}
		Transform transform = componentInChildren.gameObject.transform.FindChild("Icon");
		if (transform == null)
		{
			return;
		}
		GameObject gameObject = transform.gameObject;
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		Material material = null;
		this.mMatTypeDic.TryGetValue((int)npc_ICON_TYPE_0, out material);
		if (component.sharedMaterial == material)
		{
			if (bool_0)
			{
				gameObject.GetComponent<BillboardAnimator>().method_0();
			}
			else
			{
				gameObject.GetComponent<BillboardAnimator>().method_1();
			}
		}
		if (component.sharedMaterial == this.mIconSkillMaterial && npc_ICON_TYPE_0 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SKILL)
		{
			GameObject gameObject2 = componentInChildren.gameObject.transform.FindChild("NumAboveIcon").gameObject;
			if (bool_0)
			{
				gameObject2.GetComponent<BillboardAnimator>().method_0();
			}
			else
			{
				gameObject2.GetComponent<BillboardAnimator>().method_1();
			}
		}
	}

	// Token: 0x06002581 RID: 9601 RVA: 0x000B4988 File Offset: 0x000B2B88
	public GameObject method_9(GameObject gameObject_0, Vector3 vector3_0, string string_0, NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE_0)
	{
		GameObject gameObject = new GameObject(string_0 + "_" + npc_ICON_TYPE_0.ToString());
		int num = LayerMask.NameToLayer("diegeticUI");
		gameObject.layer = num;
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = this.mNpcNameMaterial;
		TextMesh textMesh = gameObject.AddComponent<TextMesh>();
		textMesh.font = MonoSingleton<UFont2uniSWFGenerator>.Instance.method_2("MSYH");
		textMesh.fontSize = 24;
		textMesh.text = string_0;
		textMesh.anchor = TextAnchor.MiddleCenter;
		BassBillboard bassBillboard = gameObject.AddComponent<BassBillboard>();
		bassBillboard.m_isVertical = false;
		gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
		gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
		gameObject.transform.parent = gameObject_0.transform;
		gameObject.transform.localPosition = vector3_0;
		GameObject gameObject2 = new GameObject("Icon");
		gameObject2.layer = num;
		gameObject2.AddComponent<MeshRenderer>();
		gameObject2.AddComponent<MeshFilter>();
		gameObject2.GetComponent<MeshFilter>().mesh = this.mMeshIcon;
		gameObject2.AddComponent<BillboardSizeChanger>();
		gameObject2.GetComponent<BillboardSizeChanger>().mFarthestDistance = this.mSizeChanger.mFarthestDistance;
		gameObject2.AddComponent<BillboardAnimator>();
		gameObject2.GetComponent<BillboardAnimator>().SpeedDirection = this.mBillboardAnimator.SpeedDirection;
		gameObject2.GetComponent<BillboardAnimator>().Amplitude = this.mBillboardAnimator.Amplitude;
		gameObject2.GetComponent<BillboardAnimator>().Velocity = this.mBillboardAnimator.Velocity;
		gameObject2.GetComponent<BillboardAnimator>().TotalTime = this.mBillboardAnimator.TotalTime;
		if (npc_ICON_TYPE_0 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE)
		{
			gameObject2.SetActive(false);
		}
		else
		{
			Material material = null;
			if (this.mMatTypeDic.TryGetValue((int)npc_ICON_TYPE_0, out material))
			{
				gameObject2.GetComponent<MeshRenderer>().sharedMaterial = material;
			}
			else
			{
				DebugUtils.LogError(LogCategory.Graphics, "Miss icon type! : " + npc_ICON_TYPE_0);
			}
		}
		gameObject2.transform.parent = gameObject.transform;
		gameObject2.transform.localPosition = vector3_0 + new Vector3(0f, 6f, 0f);
		float num2 = 4f;
		gameObject2.transform.localScale = new Vector3(num2, num2, 1f);
		if (npc_ICON_TYPE_0 == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SKILL)
		{
			GameObject gameObject3 = new GameObject("NumAboveIcon");
			gameObject3.AddComponent<MeshRenderer>();
			gameObject3.AddComponent<MeshFilter>();
			gameObject3.GetComponent<MeshFilter>().mesh = this.mMeshNumAboveIcon;
			gameObject3.AddComponent<BillboardSizeChanger>();
			gameObject3.GetComponent<BillboardSizeChanger>().mFarthestDistance = this.mSizeChanger.mFarthestDistance;
			gameObject3.AddComponent<BillboardAnimator>();
			gameObject3.GetComponent<BillboardAnimator>().SpeedDirection = this.mBillboardAnimator.SpeedDirection;
			gameObject3.GetComponent<BillboardAnimator>().Amplitude = this.mBillboardAnimator.Amplitude;
			gameObject3.GetComponent<BillboardAnimator>().Velocity = this.mBillboardAnimator.Velocity;
			gameObject3.GetComponent<BillboardAnimator>().TotalTime = this.mBillboardAnimator.TotalTime;
			gameObject3.transform.parent = gameObject.transform;
			gameObject3.transform.localPosition = vector3_0 + new Vector3(0f, 6f, 0f);
			gameObject3.transform.localScale = new Vector3(num2, num2, 1f);
			if (this.mNumListMaterials.Count >= 1)
			{
				gameObject3.GetComponent<MeshRenderer>().sharedMaterial = this.mNumListMaterials[0];
			}
		}
		return gameObject;
	}

	// Token: 0x06002582 RID: 9602 RVA: 0x000B4D04 File Offset: 0x000B2F04
	public bool method_10(GameObject gameObject_0)
	{
		BassBillboard componentInChildren = gameObject_0.GetComponentInChildren<BassBillboard>();
		if (componentInChildren != null)
		{
			componentInChildren.gameObject.SetActive(false);
			return true;
		}
		return false;
	}

	// Token: 0x06002583 RID: 9603 RVA: 0x000B4D30 File Offset: 0x000B2F30
	public void method_11(GameObject gameObject_0)
	{
		BassBillboard[] componentsInChildren = gameObject_0.GetComponentsInChildren<BassBillboard>(true);
		if (componentsInChildren.Length > 0)
		{
			BassBillboard bassBillboard = componentsInChildren[0];
			bassBillboard.gameObject.SetActive(true);
		}
	}

	// Token: 0x06002584 RID: 9604 RVA: 0x000197A6 File Offset: 0x000179A6
	public void OnDestroyPerMapResources()
	{
		this.method_13();
		this.method_24();
	}

	// Token: 0x06002585 RID: 9605 RVA: 0x000B4D5C File Offset: 0x000B2F5C
	private void method_12()
	{
		GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
		TPCVFXMarkers component = gameObject.GetComponent<TPCVFXMarkers>();
		this.templateSecondWindVFXObj = component.SecondWindVFXMarkers;
	}

	// Token: 0x06002586 RID: 9606 RVA: 0x000B4D8C File Offset: 0x000B2F8C
	private void method_13()
	{
		foreach (KeyValuePair<GameObject, Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>> keyValuePair in this.dictVFXTitleCache)
		{
			keyValuePair.Value.Clear();
		}
		this.dictVFXTitleCache.Clear();
		this.lstVFXGroupPool.Clear();
		for (int i = 0; i < this.lstSecondWindVFXObjPool.Count; i++)
		{
			global::UnityEngine.Object.DestroyImmediate(this.lstSecondWindVFXObjPool[i]);
		}
		this.lstSecondWindVFXObjPool.Clear();
	}

	// Token: 0x06002587 RID: 9607 RVA: 0x000B4E2C File Offset: 0x000B302C
	private GameObject method_14(NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0)
	{
		GameObject gameObject = null;
		if (tpc_VFX_MARKER_GROUP_0 == NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND)
		{
			if (this.lstSecondWindVFXObjPool.Count <= 0)
			{
				gameObject = global::UnityEngine.Object.Instantiate(this.templateSecondWindVFXObj) as GameObject;
			}
			else
			{
				gameObject = this.lstSecondWindVFXObjPool[0];
				this.lstSecondWindVFXObjPool.Remove(gameObject);
			}
		}
		return gameObject;
	}

	// Token: 0x06002588 RID: 9608 RVA: 0x000197B4 File Offset: 0x000179B4
	private void method_15(NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0, GameObject gameObject_0)
	{
		if (tpc_VFX_MARKER_GROUP_0 == NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND)
		{
			this.lstSecondWindVFXObjPool.Add(gameObject_0);
		}
	}

	// Token: 0x06002589 RID: 9609 RVA: 0x000B4E7C File Offset: 0x000B307C
	private Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> method_16()
	{
		Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> dictionary;
		if (this.lstVFXGroupPool.Count <= 0)
		{
			dictionary = new Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>();
		}
		else
		{
			dictionary = this.lstVFXGroupPool[0];
			this.lstVFXGroupPool.Remove(dictionary);
		}
		return dictionary;
	}

	// Token: 0x0600258A RID: 9610 RVA: 0x000197C6 File Offset: 0x000179C6
	private string method_17(NpcTitleMgr.TPC_VFX_MARKER_TYPE tpc_VFX_MARKER_TYPE_0)
	{
		if (tpc_VFX_MARKER_TYPE_0 == NpcTitleMgr.TPC_VFX_MARKER_TYPE.TPC_VFX_MARKER_REVIVE)
		{
			return "PTL_NPC_SecondWind_BeingRevived";
		}
		if (tpc_VFX_MARKER_TYPE_0 == NpcTitleMgr.TPC_VFX_MARKER_TYPE.TPC_VFX_MARKER_CRIPPLE)
		{
			return "PTL_NPC_SecondWind_Cripeled";
		}
		if (tpc_VFX_MARKER_TYPE_0 == NpcTitleMgr.TPC_VFX_MARKER_TYPE.TPC_VFX_MARKER_DOWN)
		{
			return "PTL_NPC_SecondWind_Down";
		}
		return string.Empty;
	}

	// Token: 0x0600258B RID: 9611 RVA: 0x000B4EBC File Offset: 0x000B30BC
	private GameObject method_18(NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0, NpcTitleMgr.TPC_VFX_MARKER_TYPE tpc_VFX_MARKER_TYPE_0)
	{
		GameObject gameObject = this.method_14(tpc_VFX_MARKER_GROUP_0);
		gameObject.SetActive(true);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
		}
		string text = this.method_17(tpc_VFX_MARKER_TYPE_0);
		Transform transform = gameObject.transform.FindChild(text);
		if (transform)
		{
			transform.gameObject.SetActive(true);
		}
		return gameObject;
	}

	// Token: 0x0600258C RID: 9612 RVA: 0x000B4F30 File Offset: 0x000B3130
	private void method_19(GameObject gameObject_0, Vector3 vector3_0, string string_0, NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0, NpcTitleMgr.TPC_VFX_MARKER_TYPE tpc_VFX_MARKER_TYPE_0)
	{
		GameObject gameObject = this.dictVFXTitleCache[gameObject_0][tpc_VFX_MARKER_GROUP_0];
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
		}
		string text = this.method_17(tpc_VFX_MARKER_TYPE_0);
		Transform transform = gameObject.transform.FindChild(text);
		if (transform)
		{
			transform.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600258D RID: 9613 RVA: 0x000B4FA8 File Offset: 0x000B31A8
	public GameObject method_20(GameObject gameObject_0, Vector3 vector3_0, string string_0, NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0, NpcTitleMgr.TPC_VFX_MARKER_TYPE tpc_VFX_MARKER_TYPE_0, bool bool_0, GameObject gameObject_1)
	{
		Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> dictionary;
		if (!this.dictVFXTitleCache.ContainsKey(gameObject_0))
		{
			dictionary = this.method_16();
			this.dictVFXTitleCache.Add(gameObject_0, dictionary);
		}
		if (bool_0)
		{
			this.method_10(gameObject_1);
		}
		dictionary = this.dictVFXTitleCache[gameObject_0];
		GameObject gameObject;
		if (!dictionary.ContainsKey(tpc_VFX_MARKER_GROUP_0))
		{
			gameObject = this.method_18(tpc_VFX_MARKER_GROUP_0, tpc_VFX_MARKER_TYPE_0);
			if (gameObject)
			{
				gameObject.name = string_0 + "_" + tpc_VFX_MARKER_TYPE_0.ToString();
				gameObject.transform.parent = gameObject_0.transform;
				gameObject.transform.localPosition = vector3_0;
				dictionary.Add(tpc_VFX_MARKER_GROUP_0, gameObject);
			}
		}
		else
		{
			this.method_19(gameObject_0, vector3_0, string_0, tpc_VFX_MARKER_GROUP_0, tpc_VFX_MARKER_TYPE_0);
			gameObject = this.dictVFXTitleCache[gameObject_0][tpc_VFX_MARKER_GROUP_0];
		}
		return gameObject;
	}

	// Token: 0x0600258E RID: 9614 RVA: 0x000B507C File Offset: 0x000B327C
	public void method_21(GameObject gameObject_0, NpcTitleMgr.TPC_VFX_MARKER_GROUP tpc_VFX_MARKER_GROUP_0, GameObject gameObject_1)
	{
		if (this.dictVFXTitleCache.ContainsKey(gameObject_0))
		{
			Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> dictionary = this.dictVFXTitleCache[gameObject_0];
			if (dictionary.ContainsKey(tpc_VFX_MARKER_GROUP_0))
			{
				GameObject gameObject = dictionary[tpc_VFX_MARKER_GROUP_0];
				gameObject.SetActive(false);
				gameObject.transform.parent = null;
				this.method_15(tpc_VFX_MARKER_GROUP_0, gameObject);
				dictionary.Remove(tpc_VFX_MARKER_GROUP_0);
				if (dictionary.Count == 0)
				{
					this.lstVFXGroupPool.Add(dictionary);
					this.dictVFXTitleCache.Remove(gameObject_0);
				}
			}
			this.method_11(gameObject_1);
		}
	}

	// Token: 0x0600258F RID: 9615 RVA: 0x000B5100 File Offset: 0x000B3300
	public void method_22(GameObject gameObject_0)
	{
		if (this.dictVFXTitleCache.ContainsKey(gameObject_0))
		{
			Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> dictionary = this.dictVFXTitleCache[gameObject_0];
			foreach (KeyValuePair<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject> keyValuePair in dictionary)
			{
				GameObject value = keyValuePair.Value;
				value.SetActive(false);
				value.transform.parent = null;
				this.method_15(keyValuePair.Key, value);
			}
			this.lstVFXGroupPool.Add(dictionary);
			this.dictVFXTitleCache.Remove(gameObject_0);
			this.method_11(gameObject_0);
		}
	}

	// Token: 0x06002590 RID: 9616 RVA: 0x000B51B0 File Offset: 0x000B33B0
	private void method_23()
	{
		GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
		TPCProgressBar component = gameObject.GetComponent<TPCProgressBar>();
		this.progressBarBGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_CRIPPLE, component.TPCProgressBarCrippleBackgroundMat);
		this.progressBarBGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_DOWN, component.TPCProgressBarDownBackgroundMat);
		this.progressBarBGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_REVIVE, component.TPCProgressBarReviveBackgroundMat);
		this.progressBarFGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_CRIPPLE, component.TPCProgressBarCrippleForegroundMat);
		this.progressBarFGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_DOWN, component.TPCProgressBarDownForegroundMat);
		this.progressBarFGMatTemplate.Add(NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_REVIVE, component.TPCProgressBarReviveForegroundMat);
		this.progressBarWidth = component.ProgressBarWidth;
		this.progressBarHeight = component.ProgressBarHeight;
	}

	// Token: 0x06002591 RID: 9617 RVA: 0x000B5258 File Offset: 0x000B3458
	private void method_24()
	{
		for (int i = 0; i < this.lstProgressBarObjPool.Count; i++)
		{
			global::UnityEngine.Object.DestroyImmediate(this.lstProgressBarObjPool[i]);
		}
		this.lstProgressBarObjPool.Clear();
	}

	// Token: 0x06002592 RID: 9618 RVA: 0x000B5298 File Offset: 0x000B3498
	private Mesh method_25(float float_0, float float_1, float float_2)
	{
		Mesh mesh = new Mesh();
		float num = float_0 / 2f;
		float num2 = float_1 / 2f;
		mesh.vertices = new Vector3[]
		{
			new Vector3(-num, num2, float_2),
			new Vector3(num, num2, float_2),
			new Vector3(num, -num2, float_2),
			new Vector3(-num, -num2, float_2)
		};
		mesh.uv = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f)
		};
		mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
		return mesh;
	}

	// Token: 0x06002593 RID: 9619 RVA: 0x000B53AC File Offset: 0x000B35AC
	private GameObject method_26()
	{
		GameObject gameObject;
		if (this.lstSecondWindVFXObjPool.Count <= 0)
		{
			gameObject = new GameObject();
			int num = LayerMask.NameToLayer("diegeticUI");
			gameObject.layer = num;
			EntityPlayer entityPlayer = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
			GameObject gameObject2 = new GameObject("ProgressBarBG");
			gameObject2.layer = num;
			gameObject2.AddComponent<MeshRenderer>();
			MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
			meshFilter.mesh = this.method_25(this.progressBarWidth, this.progressBarHeight, 0.001f);
			BillboardSizeChanger billboardSizeChanger = gameObject2.AddComponent<BillboardSizeChanger>();
			billboardSizeChanger.mFarthestDistance = this.mSizeChanger.mFarthestDistance;
			BassBillboard bassBillboard = gameObject2.AddComponent<BassBillboard>();
			bassBillboard.m_isVertical = false;
			if (entityPlayer)
			{
				bassBillboard.m_camera = entityPlayer.method_45().camera;
			}
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
			GameObject gameObject3 = new GameObject("ProgressBarFG");
			gameObject3.layer = num;
			gameObject3.AddComponent<MeshRenderer>();
			meshFilter = gameObject3.AddComponent<MeshFilter>();
			meshFilter.mesh = this.method_25(this.progressBarWidth, this.progressBarHeight, -0.001f);
			billboardSizeChanger = gameObject3.AddComponent<BillboardSizeChanger>();
			billboardSizeChanger.mFarthestDistance = this.mSizeChanger.mFarthestDistance;
			bassBillboard = gameObject3.AddComponent<BassBillboard>();
			bassBillboard.m_isVertical = false;
			if (entityPlayer)
			{
				bassBillboard.m_camera = entityPlayer.method_45().camera;
			}
			gameObject3.transform.parent = gameObject.transform;
			gameObject3.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
		else
		{
			gameObject = this.lstProgressBarObjPool[0];
			this.lstProgressBarObjPool.Remove(gameObject);
		}
		return gameObject;
	}

	// Token: 0x06002594 RID: 9620 RVA: 0x000197EB File Offset: 0x000179EB
	private void method_27(GameObject gameObject_0)
	{
		this.lstProgressBarObjPool.Add(gameObject_0);
	}

	// Token: 0x06002595 RID: 9621 RVA: 0x000B5584 File Offset: 0x000B3784
	private void method_28(GameObject gameObject_0, NpcTitleMgr.TPC_PROGRESSBAR_TYPE tpc_PROGRESSBAR_TYPE_0)
	{
		Transform transform = gameObject_0.transform.FindChild("ProgressBarBG");
		if (transform)
		{
			MeshRenderer component = transform.gameObject.GetComponent<MeshRenderer>();
			if (component)
			{
				component.material = this.progressBarBGMatTemplate[tpc_PROGRESSBAR_TYPE_0];
			}
		}
		transform = gameObject_0.transform.FindChild("ProgressBarFG");
		if (transform)
		{
			MeshRenderer component2 = transform.gameObject.GetComponent<MeshRenderer>();
			if (component2)
			{
				component2.material = this.progressBarFGMatTemplate[tpc_PROGRESSBAR_TYPE_0];
			}
		}
	}

	// Token: 0x06002596 RID: 9622 RVA: 0x000B5610 File Offset: 0x000B3810
	public GameObject method_29(GameObject gameObject_0, Vector3 vector3_0, string string_0, NpcTitleMgr.TPC_PROGRESSBAR_TYPE tpc_PROGRESSBAR_TYPE_0)
	{
		GameObject gameObject;
		if (!this.dictProgressBarCache.ContainsKey(gameObject_0))
		{
			gameObject = this.method_26();
			gameObject.SetActive(true);
			this.dictProgressBarCache.Add(gameObject_0, gameObject);
		}
		else
		{
			gameObject = this.dictProgressBarCache[gameObject_0];
		}
		if (gameObject)
		{
			gameObject.name = string_0 + "_" + tpc_PROGRESSBAR_TYPE_0.ToString();
			gameObject.transform.parent = gameObject_0.transform;
			gameObject.transform.localPosition = vector3_0;
			this.method_28(gameObject, tpc_PROGRESSBAR_TYPE_0);
		}
		return gameObject;
	}

	// Token: 0x06002597 RID: 9623 RVA: 0x000B56A4 File Offset: 0x000B38A4
	public void method_30(GameObject gameObject_0, float float_0)
	{
		if (this.dictProgressBarCache.ContainsKey(gameObject_0))
		{
			GameObject gameObject = this.dictProgressBarCache[gameObject_0];
			Transform transform = gameObject.transform.FindChild("ProgressBarFG");
			if (transform)
			{
				MeshFilter component = transform.gameObject.GetComponent<MeshFilter>();
				if (component)
				{
					float num = this.progressBarWidth / 2f;
					float num2 = this.progressBarHeight / 2f;
					float num3 = this.progressBarWidth * float_0 - num;
					float z = component.mesh.vertices[0].z;
					component.mesh.vertices = new Vector3[]
					{
						new Vector3(-num, num2, z),
						new Vector3(num3, num2, z),
						new Vector3(num3, -num2, z),
						new Vector3(-num, -num2, z)
					};
				}
			}
		}
	}

	// Token: 0x06002598 RID: 9624 RVA: 0x000B57B0 File Offset: 0x000B39B0
	public void method_31(GameObject gameObject_0)
	{
		if (this.dictProgressBarCache.ContainsKey(gameObject_0))
		{
			GameObject gameObject = this.dictProgressBarCache[gameObject_0];
			gameObject.SetActive(false);
			gameObject.transform.parent = null;
			this.method_27(gameObject);
			this.dictProgressBarCache.Remove(gameObject_0);
		}
	}

	// Token: 0x04001ADB RID: 6875
	private const string MESH_ICON_GAMEOBJECT_NAME = "Icon";

	// Token: 0x04001ADC RID: 6876
	private const string MESH_NUM_ABOVE_ICON_GAMEOBJECT_NAME = "NumAboveIcon";

	// Token: 0x04001ADD RID: 6877
	private const string MESH_PROGRESS_BAR_BG_NAME = "ProgressBarBG";

	// Token: 0x04001ADE RID: 6878
	private const string MESH_PROGRESS_BAR_FG_NAME = "ProgressBarFG";

	// Token: 0x04001ADF RID: 6879
	private Material mNpcNameMaterial;

	// Token: 0x04001AE0 RID: 6880
	private Material mIconNewMaterial;

	// Token: 0x04001AE1 RID: 6881
	private Material mIconProgressMaterial;

	// Token: 0x04001AE2 RID: 6882
	private Material mIconDoneMaterial;

	// Token: 0x04001AE3 RID: 6883
	private Material mIconSkillMaterial;

	// Token: 0x04001AE4 RID: 6884
	private Material mIconDummyMaterial;

	// Token: 0x04001AE5 RID: 6885
	private Material mIconDailyQuestNew;

	// Token: 0x04001AE6 RID: 6886
	private Material mIconDailyQuestDone;

	// Token: 0x04001AE7 RID: 6887
	private Material mIconSpecialQuestNew;

	// Token: 0x04001AE8 RID: 6888
	private Material mIconSpecialQuestDone;

	// Token: 0x04001AE9 RID: 6889
	private Material mIconCraft;

	// Token: 0x04001AEA RID: 6890
	private Material mIconDoc;

	// Token: 0x04001AEB RID: 6891
	private Material mIconGuild;

	// Token: 0x04001AEC RID: 6892
	private Material mIconMail;

	// Token: 0x04001AED RID: 6893
	private Material mIconMailNew;

	// Token: 0x04001AEE RID: 6894
	private Material mIconShop;

	// Token: 0x04001AEF RID: 6895
	private Material mIconUpgrade;

	// Token: 0x04001AF0 RID: 6896
	private Material mIconPvP;

	// Token: 0x04001AF1 RID: 6897
	private BillboardSizeChanger mSizeChanger;

	// Token: 0x04001AF2 RID: 6898
	private BillboardAnimator mBillboardAnimator;

	// Token: 0x04001AF3 RID: 6899
	private List<Material> mNumListMaterials = new List<Material>();

	// Token: 0x04001AF4 RID: 6900
	private Dictionary<int, Material> mMatTypeDic = new Dictionary<int, Material>();

	// Token: 0x04001AF5 RID: 6901
	private GameObject mRefMsyhObj;

	// Token: 0x04001AF6 RID: 6902
	private TextMesh mRefTextMesh;

	// Token: 0x04001AF7 RID: 6903
	private Texture mRefMsyhTex;

	// Token: 0x04001AF8 RID: 6904
	private Mesh mMeshIcon;

	// Token: 0x04001AF9 RID: 6905
	private Mesh mMeshNumAboveIcon;

	// Token: 0x04001AFA RID: 6906
	private GameObject mCurNpcObj;

	// Token: 0x04001AFB RID: 6907
	private NpcTitleMgr.NPC_ICON_TYPE mPreHideIconType;

	// Token: 0x04001AFC RID: 6908
	private List<Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>> lstVFXGroupPool = new List<Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>>();

	// Token: 0x04001AFD RID: 6909
	private Dictionary<GameObject, Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>> dictVFXTitleCache = new Dictionary<GameObject, Dictionary<NpcTitleMgr.TPC_VFX_MARKER_GROUP, GameObject>>();

	// Token: 0x04001AFE RID: 6910
	private GameObject templateSecondWindVFXObj;

	// Token: 0x04001AFF RID: 6911
	private List<GameObject> lstSecondWindVFXObjPool = new List<GameObject>();

	// Token: 0x04001B00 RID: 6912
	private Dictionary<GameObject, GameObject> dictProgressBarCache = new Dictionary<GameObject, GameObject>();

	// Token: 0x04001B01 RID: 6913
	private List<GameObject> lstProgressBarObjPool = new List<GameObject>();

	// Token: 0x04001B02 RID: 6914
	private float progressBarWidth = 0.2f;

	// Token: 0x04001B03 RID: 6915
	private float progressBarHeight = 0.05f;

	// Token: 0x04001B04 RID: 6916
	private Dictionary<NpcTitleMgr.TPC_PROGRESSBAR_TYPE, Material> progressBarBGMatTemplate = new Dictionary<NpcTitleMgr.TPC_PROGRESSBAR_TYPE, Material>();

	// Token: 0x04001B05 RID: 6917
	private Dictionary<NpcTitleMgr.TPC_PROGRESSBAR_TYPE, Material> progressBarFGMatTemplate = new Dictionary<NpcTitleMgr.TPC_PROGRESSBAR_TYPE, Material>();

	// Token: 0x020005CC RID: 1484
	public enum NPC_ICON_TYPE
	{
		// Token: 0x04001B07 RID: 6919
		NPC_ICON_NONE,
		// Token: 0x04001B08 RID: 6920
		NPC_ICON_DONE,
		// Token: 0x04001B09 RID: 6921
		NPC_ICON_PROGRESS,
		// Token: 0x04001B0A RID: 6922
		NPC_ICON_NEW,
		// Token: 0x04001B0B RID: 6923
		NPC_ICON_DAILY_NEW,
		// Token: 0x04001B0C RID: 6924
		NPC_ICON_DAILY_DONE,
		// Token: 0x04001B0D RID: 6925
		NPC_ICON_SPECIAL_NEW,
		// Token: 0x04001B0E RID: 6926
		NPC_ICON_SPECIAL_DONE,
		// Token: 0x04001B0F RID: 6927
		NPC_ICON_CRAFT,
		// Token: 0x04001B10 RID: 6928
		NPC_ICON_DOC,
		// Token: 0x04001B11 RID: 6929
		NPC_ICON_GUILD,
		// Token: 0x04001B12 RID: 6930
		NPC_ICON_MAIL,
		// Token: 0x04001B13 RID: 6931
		NPC_ICON_MAIL_NEW,
		// Token: 0x04001B14 RID: 6932
		NPC_ICON_WAREHOUSE,
		// Token: 0x04001B15 RID: 6933
		NPC_ICON_SHOP,
		// Token: 0x04001B16 RID: 6934
		NPC_ICON_UPGRADE,
		// Token: 0x04001B17 RID: 6935
		NPC_ICON_DUMMY,
		// Token: 0x04001B18 RID: 6936
		NPC_ICON_SKILL,
		// Token: 0x04001B19 RID: 6937
		NPC_ICON_PVP,
		// Token: 0x04001B1A RID: 6938
		NPC_ICON_NUM
	}

	// Token: 0x020005CD RID: 1485
	public enum TPC_VFX_MARKER_GROUP
	{
		// Token: 0x04001B1C RID: 6940
		GROUP_NONE,
		// Token: 0x04001B1D RID: 6941
		GROUP_SECOND_WIND
	}

	// Token: 0x020005CE RID: 1486
	public enum TPC_VFX_MARKER_TYPE
	{
		// Token: 0x04001B1F RID: 6943
		TPC_VFX_MARKER_NONE,
		// Token: 0x04001B20 RID: 6944
		TPC_VFX_MARKER_REVIVE,
		// Token: 0x04001B21 RID: 6945
		TPC_VFX_MARKER_CRIPPLE,
		// Token: 0x04001B22 RID: 6946
		TPC_VFX_MARKER_DOWN,
		// Token: 0x04001B23 RID: 6947
		TPC_VFX_MARKER_NUM
	}

	// Token: 0x020005CF RID: 1487
	public enum TPC_PROGRESSBAR_TYPE
	{
		// Token: 0x04001B25 RID: 6949
		TPC_PROGRESSBAR_NONE,
		// Token: 0x04001B26 RID: 6950
		TPC_PROGRESSBAR_CRIPPLE,
		// Token: 0x04001B27 RID: 6951
		TPC_PROGRESSBAR_DOWN,
		// Token: 0x04001B28 RID: 6952
		TPC_PROGRESSBAR_REVIVE,
		// Token: 0x04001B29 RID: 6953
		TPC_PROGRESSBAR_NUM
	}
}
