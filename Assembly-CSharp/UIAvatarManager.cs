using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ns0;
using UnityEngine;
using XsdSettings;

using System.Runtime.CompilerServices;
// Token: 0x0200069F RID: 1695
public class UIAvatarManager : MonoBehaviour
{
	private static System.Collections.Generic.Dictionary<string, int> f__switch_map2;
	// Token: 0x06002BF5 RID: 11253 RVA: 0x000CF1E8 File Offset: 0x000CD3E8
	public UIAvatarManager()
	{
		this._mapClassInfo = new Dictionary<AvatarType, FE_ClassInfo>
		{
			{
				AvatarType.SIREN,
				new FE_ClassInfo(AvatarType.SIREN)
			},
			{
				AvatarType.SOLDIER,
				new FE_ClassInfo(AvatarType.SOLDIER)
			},
			{
				AvatarType.BERSERKER,
				new FE_ClassInfo(AvatarType.BERSERKER)
			},
			{
				AvatarType.HUNTER,
				new FE_ClassInfo(AvatarType.HUNTER)
			}
		};
	}

	// Token: 0x06002BF6 RID: 11254 RVA: 0x0001CEED File Offset: 0x0001B0ED
	public void method_0(Animator animator_0)
	{
		this.m_playerAnimator = animator_0;
	}

	// Token: 0x06002BF7 RID: 11255 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06002BF8 RID: 11256 RVA: 0x0001CEF6 File Offset: 0x0001B0F6
	public FE_ClassInfo method_1(AvatarType avatarType_0)
	{
		return this._mapClassInfo[avatarType_0];
	}

	// Token: 0x06002BF9 RID: 11257 RVA: 0x0001CF04 File Offset: 0x0001B104
	private SkinnedMeshRenderer method_2(GameObject gameObject_0)
	{
		return gameObject_0.GetComponentInChildren<SkinnedMeshRenderer>();
	}

	// Token: 0x06002BFA RID: 11258 RVA: 0x000CF298 File Offset: 0x000CD498
	public void method_3()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
		if (componentsInChildren == null)
		{
			return;
		}
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			string text = componentsInChildren[i].gameObject.name;
			if (text != null)
			{
				if (f__switch_map2 == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
					dictionary.Add("CHR_Berserker_Skeleton_01", 0);
					dictionary.Add("CHR_Soldier_Skeleton_01", 0);
					dictionary.Add("CHR_Siren_Skeleton_01", 0);
					dictionary.Add("CHR_Hunter_Skeleton_01", 0);
					f__switch_map2 = dictionary;
				}
				if (f__switch_map2.TryGetValue(text, out var value) && value == 0)
				{
					componentsInChildren[i].gameObject.SetActive(value: false);
				}
			}
		}
	}
	// Token: 0x06002BFB RID: 11259 RVA: 0x000CF33C File Offset: 0x000CD53C
	private void method_4(BuildingKitRender buildingKitRender_0, AvatarType avatarType_0)
	{
		ItemGeneratorService component = MonoSingleton<AppManager>.Instance.GetComponent<ItemGeneratorService>();
		for (int i = 0; i < 7; i++)
		{
			BuildingPart buildingPart = component.method_9(avatarType_0, (AvatarSubPart)i);
			if (buildingPart != null)
			{
				buildingKitRender_0.method_11(i, (int)buildingPart.mFBX);
				buildingKitRender_0.method_13(i, (int)buildingPart.mMat);
			}
		}
	}

	// Token: 0x06002BFC RID: 11260 RVA: 0x000CF388 File Offset: 0x000CD588
	public IEnumerator method_5()
	{
		AvatarGeneratorService avatarGeneratorService = ns0.MonoSingleton<AppManager>.Instance.GetComponent<AvatarGeneratorService>();
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.gameObject.name)
			{
			case "CHR_Berserker_Skeleton_01":
			{
				if (_mapClassInfo[AvatarType.BERSERKER].buildingKitRender != null)
				{
					continue;
				}
				BuildingKitRender kitRender = new BuildingKitRender("CHR", "Berserker");
				method_4(kitRender, AvatarType.BERSERKER);
				_mapClassInfo[AvatarType.BERSERKER].buildingKitRender = kitRender;
				yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(kitRender.method_17()));
				transform.gameObject.SetActive(value: true);
				GameObject kitObj4 = kitRender.method_6();
				if (kitObj4 == null)
				{
					transform.gameObject.SetActive(value: false);
					continue;
				}
				kitObj4.AddComponent<Skeleton>();
				string controllerPath4 = "Entities/Player_Mecanim/Berserker_3rd_Controller_UI";
				m_playerAnimator = kitObj4.GetComponent<Animator>();
				if (m_playerAnimator != null)
				{
					m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)UnityEngine.Object.Instantiate(Resources.Load(controllerPath4));
				}
				kitObj4.transform.parent = transform;
				kitObj4.transform.localPosition = Vector3.zero;
				kitObj4.transform.localRotation = Quaternion.identity;
				Rigidbody[] rigs4 = kitObj4.GetComponentsInChildren<Rigidbody>();
				for (int l = 0; l < rigs4.Length; l++)
				{
					rigs4[l].isKinematic = true;
				}
				yield return StartCoroutine(avatarGeneratorService.method_0(weaponDNA_0: ns0.MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>().method_10(method_7(AvatarType.BERSERKER)), gameObject_0: kitObj4.gameObject, byte_0: 3));
				transform.gameObject.GetComponent<ModelFadeIn>().method_0();
				transform.gameObject.SetActive(value: false);
				_mapClassInfo[AvatarType.BERSERKER].classModel = transform.gameObject;
				break;
			}
			case "CHR_Soldier_Skeleton_01":
			{
				if (_mapClassInfo[AvatarType.SOLDIER].buildingKitRender != null)
				{
					continue;
				}
				BuildingKitRender kitRender = new BuildingKitRender("CHR", "Soldier");
				method_4(kitRender, AvatarType.SOLDIER);
				_mapClassInfo[AvatarType.SOLDIER].buildingKitRender = kitRender;
				yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(kitRender.method_17()));
				transform.gameObject.SetActive(value: true);
				GameObject kitObj3 = kitRender.method_6();
				if (kitObj3 == null)
				{
					transform.gameObject.SetActive(value: false);
					continue;
				}
				kitObj3.AddComponent<Skeleton>();
				string controllerPath3 = "Entities/Player_Mecanim/Soldier_3rd_Controller_UI";
				m_playerAnimator = kitObj3.GetComponent<Animator>();
				if (m_playerAnimator != null)
				{
					m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)UnityEngine.Object.Instantiate(Resources.Load(controllerPath3));
				}
				kitObj3.transform.parent = transform;
				kitObj3.transform.localPosition = Vector3.zero;
				kitObj3.transform.localRotation = Quaternion.identity;
				Rigidbody[] rigs3 = kitObj3.GetComponentsInChildren<Rigidbody>();
				for (int k = 0; k < rigs3.Length; k++)
				{
					rigs3[k].isKinematic = true;
				}
				yield return StartCoroutine(avatarGeneratorService.method_0(weaponDNA_0: ns0.MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>().method_10(method_7(AvatarType.SOLDIER)), gameObject_0: kitObj3.gameObject, byte_0: 3));
				transform.gameObject.GetComponent<ModelFadeIn>().method_0();
				transform.gameObject.SetActive(value: false);
				_mapClassInfo[AvatarType.SOLDIER].classModel = transform.gameObject;
				break;
			}
			case "CHR_Siren_Skeleton_01":
			{
				if (_mapClassInfo[AvatarType.SIREN].buildingKitRender != null)
				{
					continue;
				}
				BuildingKitRender kitRender = new BuildingKitRender("CHR", "Siren");
				method_4(kitRender, AvatarType.SIREN);
				_mapClassInfo[AvatarType.SIREN].buildingKitRender = kitRender;
				yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(kitRender.method_17()));
				transform.gameObject.SetActive(value: true);
				GameObject kitObj2 = kitRender.method_6();
				if (kitObj2 == null)
				{
					transform.gameObject.SetActive(value: false);
					continue;
				}
				kitObj2.AddComponent<Skeleton>();
				string controllerPath2 = "Entities/Player_Mecanim/Siren_3rd_Controller_UI";
				m_playerAnimator = kitObj2.GetComponent<Animator>();
				if (m_playerAnimator != null)
				{
					m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)UnityEngine.Object.Instantiate(Resources.Load(controllerPath2));
				}
				kitObj2.transform.parent = transform;
				kitObj2.transform.localPosition = Vector3.zero;
				kitObj2.transform.localRotation = Quaternion.identity;
				Rigidbody[] rigs2 = kitObj2.GetComponentsInChildren<Rigidbody>();
				for (int j = 0; j < rigs2.Length; j++)
				{
					rigs2[j].isKinematic = true;
				}
				yield return StartCoroutine(avatarGeneratorService.method_0(weaponDNA_0: ns0.MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>().method_10(method_7(AvatarType.SIREN)), gameObject_0: kitObj2.gameObject));
				transform.gameObject.GetComponent<ModelFadeIn>().method_0();
				transform.gameObject.SetActive(value: false);
				_mapClassInfo[AvatarType.SIREN].classModel = transform.gameObject;
				break;
			}
			case "CHR_Hunter_Skeleton_01":
			{
				if (_mapClassInfo[AvatarType.HUNTER].buildingKitRender != null)
				{
					continue;
				}
				BuildingKitRender kitRender = new BuildingKitRender("CHR", "Hunter");
				method_4(kitRender, AvatarType.HUNTER);
				_mapClassInfo[AvatarType.HUNTER].buildingKitRender = kitRender;
				yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(kitRender.method_17()));
				transform.gameObject.SetActive(value: true);
				GameObject kitObj = kitRender.method_6();
				if (kitObj == null)
				{
					transform.gameObject.SetActive(value: false);
					continue;
				}
				kitObj.AddComponent<Skeleton>();
				string controllerPath = "Entities/Player_Mecanim/Hunter_3rd_Controller_UI";
				m_playerAnimator = kitObj.GetComponent<Animator>();
				if (m_playerAnimator != null)
				{
					m_playerAnimator.runtimeAnimatorController = (RuntimeAnimatorController)UnityEngine.Object.Instantiate(Resources.Load(controllerPath));
				}
				kitObj.transform.parent = transform;
				kitObj.transform.localPosition = Vector3.zero;
				kitObj.transform.localRotation = Quaternion.identity;
				Rigidbody[] rigs = kitObj.GetComponentsInChildren<Rigidbody>();
				for (int i = 0; i < rigs.Length; i++)
				{
					rigs[i].isKinematic = true;
				}
				yield return StartCoroutine(avatarGeneratorService.method_0(weaponDNA_0: ns0.MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>().method_10(method_7(AvatarType.HUNTER)), gameObject_0: kitObj.gameObject));
				transform.gameObject.GetComponent<ModelFadeIn>().method_0();
				transform.gameObject.SetActive(value: false);
				_mapClassInfo[AvatarType.HUNTER].classModel = transform.gameObject;
				break;
			}
			}
			if (m_playerAnimator != null)
			{
				m_playerAnimator.applyRootMotion = false;
				m_playerAnimator.updateMode = AnimatorUpdateMode.Normal;
				m_playerAnimator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
			}
		}
	}
	// Token: 0x06002BFD RID: 11261 RVA: 0x000CF3A4 File Offset: 0x000CD5A4
	private void Update()
	{
		DNACreateBehaviour dnacreateBehaviour = MonoSingleton<AppManager>.Instance.method_15();
		if (dnacreateBehaviour != null)
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().StepState_0 != FrontEndStepManager.StepState.ClassSelect)
		{
			return;
		}
		this.method_6("tExtraIdle", this.ClassSelectIdle_Min, this.ClassSelectIdle_Max);
	}

	// Token: 0x06002BFE RID: 11262 RVA: 0x000CF3F0 File Offset: 0x000CD5F0
	public void method_6(string string_0, int int_0, int int_1)
	{
		if (this.m_playerAnimator == null)
		{
			return;
		}
		if (!this.m_playerAnimator.isActiveAndEnabled)
		{
			return;
		}
		if (this.m_waitToPlayExtraIdle <= 0)
		{
			this.m_playerAnimator.SetTrigger(string_0);
			this.m_waitToPlayExtraIdle = global::UnityEngine.Random.Range(int_0, int_1);
		}
		else
		{
			this.m_waitToPlayExtraIdle--;
		}
	}

	// Token: 0x06002BFF RID: 11263 RVA: 0x000CF44C File Offset: 0x000CD64C
	public int method_7(AvatarType avatarType_0)
	{
		switch (avatarType_0)
		{
		case AvatarType.SIREN:
			return this.SirenWeaponID;
		case AvatarType.SOLDIER:
			return this.SoldierWeaponID;
		case AvatarType.BERSERKER:
			return this.BerserkerWeaponID;
		case AvatarType.HUNTER:
			return this.HunterWeaponID;
		default:
			return 1;
		}
	}

	// Token: 0x04001EE5 RID: 7909
	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	// Token: 0x04001EE6 RID: 7910
	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	// Token: 0x04001EE7 RID: 7911
	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	// Token: 0x04001EE8 RID: 7912
	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	// Token: 0x04001EE9 RID: 7913
	private int m_waitToPlayExtraIdle = -1;

	// Token: 0x04001EEA RID: 7914
	private Animator m_playerAnimator;

	// Token: 0x04001EEB RID: 7915
	public int BerserkerWeaponID = 2;

	// Token: 0x04001EEC RID: 7916
	public int HunterWeaponID = 3;

	// Token: 0x04001EED RID: 7917
	public int SirenWeaponID = 4;

	// Token: 0x04001EEE RID: 7918
	public int SoldierWeaponID = 5;

	// Token: 0x04001EEF RID: 7919
	public int ClassSelectIdle_Min = 100;

	// Token: 0x04001EF0 RID: 7920
	public int ClassSelectIdle_Max = 300;

	// Token: 0x04001EF1 RID: 7921
	public int CustomizeBodyIdle_Min = 100;

	// Token: 0x04001EF2 RID: 7922
	public int CustomizeBodyIdle_Max = 200;

	// Token: 0x04001EF3 RID: 7923
	public int CustomizeHeadIdle_Min = 50;

	// Token: 0x04001EF4 RID: 7924
	public int CustomizeHeadIdle_Max = 100;

	// Token: 0x04001EF5 RID: 7925
	protected Dictionary<AvatarType, FE_ClassInfo> _mapClassInfo;
}
