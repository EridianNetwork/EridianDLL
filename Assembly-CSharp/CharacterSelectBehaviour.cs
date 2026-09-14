using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000681 RID: 1665
public class CharacterSelectBehaviour : StepBehaviour
{
	// Token: 0x06002B0A RID: 11018 RVA: 0x000C8A78 File Offset: 0x000C6C78
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		if (data != null)
		{
			CharacterSelectBehaviour.cachedCharacter = data as List<Character>;
		}
		this.characters = ((data != null) ? (data as List<Character>) : CharacterSelectBehaviour.cachedCharacter);
		this._mapCachedModels = new Dictionary<Character, GameObject>();
		for (int i = 0; i < this.characters.Count; i++)
		{
			this._mapCachedModels.Add(this.characters[i], null);
		}
		base.StartCoroutine(this.method_8(lastStep));
	}

	// Token: 0x06002B0B RID: 11019 RVA: 0x000C8AF0 File Offset: 0x000C6CF0
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		if (this._characterModel)
		{
			this._characterModel = null;
		}
		foreach (KeyValuePair<Character, GameObject> keyValuePair in this._mapCachedModels)
		{
			GameObject value = keyValuePair.Value;
			if (value != null)
			{
				global::UnityEngine.Object.Destroy(value);
			}
		}
		this._mapCachedModels.Clear();
		this._mapCachedModels = null;
		this.method_0();
	}

	// Token: 0x06002B0C RID: 11020 RVA: 0x0001C952 File Offset: 0x0001AB52
	private void method_0()
	{
		this._characterSelectView.vmethod_3();
		this._characterSelectView = null;
		this.characters = null;
	}

	// Token: 0x06002B0D RID: 11021 RVA: 0x000C8B60 File Offset: 0x000C6D60
	private void method_1()
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_1();
		this._camera = GameObject.Find("Class_selection_Camera").camera;
		this._camera.enabled = true;
		this._modelGroup = GameObject.Find("Model_Group");
		this._skeleton = GameObject.Find("Model_Group/CHR_Custom_Skeleton_01");
		this._skeleton.transform.localPosition = GameObject.Find("Model_Group/CHR_Temp_Position").transform.localPosition;
	}

	// Token: 0x06002B0E RID: 11022 RVA: 0x0001C96D File Offset: 0x0001AB6D
	private void method_2()
	{
		this._characterSelectView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharacterSelectView>();
		this._characterSelectView._logicBehaviour = this;
		this._characterSelectView.vmethod_2();
		this._characterSelectView.vmethod_10(this.characters);
	}

	// Token: 0x06002B0F RID: 11023 RVA: 0x000C8BE4 File Offset: 0x000C6DE4
	public virtual void vmethod_1(int int_0)
	{
		CharacterService.SelectCharacterAsyncTask selectCharacterAsyncTask = new CharacterService.SelectCharacterAsyncTask();
		selectCharacterAsyncTask.method_4(int_0);
		MonoSingleton<AsyncTaskManager>.Instance.method_1(selectCharacterAsyncTask, new TaskCompletedDelegate(this.OnSelecteCharacter));
	}

	// Token: 0x06002B10 RID: 11024 RVA: 0x000C8C18 File Offset: 0x000C6E18
	private Character method_3(int int_0)
	{
		foreach (Character character in this.characters)
		{
			if (character.Id == int_0)
			{
				return character;
			}
		}
		return null;
	}

	// Token: 0x06002B11 RID: 11025 RVA: 0x000C8C78 File Offset: 0x000C6E78
	public void method_4(int int_0)
	{
		CharacterService.DeleteCharacterAsyncTask deleteCharacterAsyncTask = new CharacterService.DeleteCharacterAsyncTask();
		deleteCharacterAsyncTask.method_4(int_0);
		MonoSingleton<AsyncTaskManager>.Instance.method_1(deleteCharacterAsyncTask, new TaskCompletedDelegate(this.OnDeleteCharacter));
	}

	// Token: 0x06002B12 RID: 11026 RVA: 0x000C8CAC File Offset: 0x000C6EAC
	public void method_5(int int_0)
	{
		this._curCharacter = this.method_3(int_0);
		if (this._curCharacter == null)
		{
			return;
		}
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_id = this._curCharacter.Id;
		playerProperties.m_name = this._curCharacter.Name;
		playerProperties.m_exp = this._curCharacter.Experience;
		playerProperties.m_level = this._curCharacter.Level;
		this._curDNA.method_8(this._curCharacter.AvatarType, this._curCharacter.AvatarParts, this._curCharacter.AvatarMaterials, this._curCharacter.AvatarId);
		playerProperties.m_avatarDna = this._curDNA;
		MonoSingleton<PlayerManager>.Instance.method_0(playerProperties, true);
		base.StartCoroutine(this.method_6());
	}

	// Token: 0x06002B13 RID: 11027 RVA: 0x0001C9AC File Offset: 0x0001ABAC
	public void OnDeleteCharacter(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (this._characterSelectView != null)
		{
			this._characterSelectView.OnDeleteCharacter(AsyncTaskStatus.Success == result);
		}
	}

	// Token: 0x06002B14 RID: 11028 RVA: 0x000C8D78 File Offset: 0x000C6F78
	public void OnSelecteCharacter(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (result == AsyncTaskStatus.Success)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_15(false, "CharacterSelect");
			MonoSingleton<GameFlowManager>.Instance.method_11();
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
			try
			{
				ServiceWrapperBase<QuestServiceWrapper>.Instance.RefreshPlayerQuests();
			}
			catch (Exception)
			{
			}
			return;
		}
		MonoSingleton<GameFlowManager>.Instance.method_10(true);
	}

	// Token: 0x06002B15 RID: 11029 RVA: 0x000C8DE8 File Offset: 0x000C6FE8
	private IEnumerator method_6()
	{
		if (inAnimation)
		{
			if (bNeedQuitCourotine)
			{
				yield break;
			}
			bNeedQuitCourotine = true;
		}
		while (bNeedQuitCourotine)
		{
			yield return null;
		}
		inAnimation = true;
		if (_characterModel != null)
		{
			_characterModel.SetActive(value: false);
		}
		if (_mapCachedModels.ContainsKey(_curCharacter))
		{
			GameObject curModel = _mapCachedModels[_curCharacter];
			if (curModel == null)
			{
				uint bkID = _curDNA.m_buildingUnit.bkID;
				if (bkID == 0)
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "bkID is 0 in Character Select Behaviour");
				}
				BuildingKitRender generator = new BuildingKitRender(bkID);
				if (!BuildingKitManager.OnlineHostMinResMode)
				{
					generator.BuildingUnit_0 = _curDNA.m_buildingUnit;
				}
				for (AvatarSubPart index = AvatarSubPart.HAIR; index < AvatarSubPart.TOTAL; index++)
				{
					ItemDNA outfit = _curCharacter.Inventory.method_31(index);
					if (outfit != null)
					{
						generator.method_11((int)outfit.method_9().m_avatarSubpart, outfit.method_9().method_1());
						generator.method_13((int)outfit.method_9().m_avatarSubpart, outfit.method_9().method_2());
					}
				}
				curModel = generator.method_6();
				curModel.transform.localPosition = Vector3.zero;
				curModel.transform.rotation = Quaternion.identity;
				_mapCachedModels[_curCharacter] = curModel;
				_modelCtrl = curModel.GetComponent<UIModelController>();
				if (_modelCtrl == null)
				{
					_modelCtrl = curModel.AddComponent<UIModelController>();
				}
				string controllerPath = string.Empty;
				Vector3 targetPosition = Vector3.zero;
				Quaternion targetRotation = Quaternion.identity;
				Transform[] componentsInChildren = _modelGroup.GetComponentsInChildren<Transform>(includeInactive: true);
				foreach (Transform transform in componentsInChildren)
				{
					switch (transform.gameObject.name)
					{
					case "CHR_Soldier_Skeleton_01":
						if (_curDNA.method_5() == AvatarType.SOLDIER)
						{
							controllerPath = "Entities/Player_Mecanim/Soldier_3rd_Controller_UI";
							targetPosition = transform.position;
							targetRotation = transform.rotation;
						}
						break;
					case "CHR_Siren_Skeleton_01":
						if (_curDNA.method_5() == AvatarType.SIREN)
						{
							controllerPath = "Entities/Player_Mecanim/Siren_3rd_Controller_UI";
							targetPosition = transform.position;
							targetRotation = transform.rotation;
						}
						break;
					case "CHR_Berserker_Skeleton_01":
						if (_curDNA.method_5() == AvatarType.BERSERKER)
						{
							controllerPath = "Entities/Player_Mecanim/Berserker_3rd_Controller_UI";
							targetPosition = transform.position;
							targetRotation = transform.rotation;
						}
						break;
					case "CHR_Hunter_Skeleton_01":
						if (_curDNA.method_5() == AvatarType.HUNTER)
						{
							controllerPath = "Entities/Player_Mecanim/Hunter_3rd_Controller_UI";
							targetPosition = transform.position;
							targetRotation = transform.rotation;
						}
						break;
					}
				}
				Animator animator = curModel.GetComponent<Animator>();
				if (animator != null && controllerPath != string.Empty)
				{
					animator.runtimeAnimatorController = (RuntimeAnimatorController)UnityEngine.Object.Instantiate(Resources.Load(controllerPath));
					animator.applyRootMotion = false;
				}
				Rigidbody[] rigs = curModel.GetComponentsInChildren<Rigidbody>();
				for (int i = 0; i < rigs.Length; i++)
				{
					rigs[i].isKinematic = true;
				}
				WeaponDNA weaponDNA = _curCharacter.Inventory.method_2().method_6();
				if (animator != null)
				{
					PlayerAnimationIkController playerIkController = animator.gameObject.AddComponent<PlayerAnimationIkController>();
					playerIkController.m_enableLeftHandIK = true;
					playerIkController.m_currentWeaponType = weaponDNA.method_1();
					int weaponType = (int)playerIkController.m_currentWeaponType;
					animator.SetInteger("iWeaponType", weaponType);
					GameObject cameraObj = GameObject.Find("Class_selection_Camera");
					if (cameraObj != null)
					{
						playerIkController.method_1(cameraObj);
						playerIkController.m_enableLookIK = true;
					}
				}
				AvatarGeneratorService avatarGeneratorService = ns0.MonoSingleton<AppManager>.Instance.GetComponent<AvatarGeneratorService>();
				yield return StartCoroutine(avatarGeneratorService.method_0(curModel, weaponDNA));
				curModel.transform.parent = _skeleton.transform;
				curModel.transform.position = targetPosition;
				curModel.transform.rotation = targetRotation;
				curModel.SetActive(value: false);
			}
			_characterModel = curModel;
			if (!bNeedQuitCourotine)
			{
				yield return StartCoroutine(method_7(curModel, bool_0: true));
			}
		}
		inAnimation = false;
		bNeedQuitCourotine = false;
	}
	// Token: 0x06002B16 RID: 11030 RVA: 0x000C8E04 File Offset: 0x000C7004
	private IEnumerator method_7(GameObject gameObject_0, bool bool_0)
	{
		if (!(gameObject_0 != null))
		{
			yield break;
		}
		gameObject_0.SetActive(value: true);
		if (!bool_0)
		{
			yield break;
		}
		Transform effectParent = _modelGroup.transform.FindChild("PTL_Resurrection");
		if (effectParent == null)
		{
			yield break;
		}
		ParticleSystem effct = effectParent.particleSystem;
		if (effct == null)
		{
			yield break;
		}
		effectParent.gameObject.SetActive(value: true);
		effct.Play();
		ModelFadeIn tempfadeInEff = _skeleton.GetComponentInChildren<ModelFadeIn>();
		tempfadeInEff.method_0();
		if (!(tempfadeInEff != null))
		{
			yield break;
		}
		tempfadeInEff.vmethod_0();
		while (true)
		{
			if (!tempfadeInEff.Boolean_0)
			{
				yield break;
			}
			if (bNeedQuitCourotine)
			{
				break;
			}
			yield return null;
		}
		effct.Stop();
		tempfadeInEff.vmethod_1();
		gameObject_0.SetActive(value: false);
		bNeedQuitCourotine = false;
	}
	// Token: 0x06002B17 RID: 11031 RVA: 0x000C8E3C File Offset: 0x000C703C
	private void Update()
	{
		if (Input.mousePosition.x > (float)Screen.width || Input.mousePosition.y > (float)Screen.height || Input.mousePosition.x < 0f || Input.mousePosition.y < 0f)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ClassCustomView>().method_8(true);
		}
		if (this._modelCtrl == null)
		{
			return;
		}
		if (!MonoSingleton<AppManager>.Instance.method_0().vmethod_11() && Input.GetMouseButtonDown(0))
		{
			this._modelCtrl.method_0(this._v3RotateSpeed);
		}
		if (Input.GetMouseButtonUp(0))
		{
			this._modelCtrl.method_0(Vector3.zero);
		}
	}

	// Token: 0x06002B18 RID: 11032 RVA: 0x000C8F04 File Offset: 0x000C7104
	private IEnumerator method_8(FrontEndStepManager.StepState stepState_0)
	{
		if ("Lobby_01" != Application.loadedLevelName)
		{
			yield return StartCoroutine(ns0.MonoSingleton<GameFlowManager>.Instance.method_16("Lobby_01"));
		}
		method_1();
		method_2();
	}
	// Token: 0x04001E26 RID: 7718
	private const string SCENE_NAME = "Lobby_01";

	// Token: 0x04001E27 RID: 7719
	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	// Token: 0x04001E28 RID: 7720
	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	// Token: 0x04001E29 RID: 7721
	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	// Token: 0x04001E2A RID: 7722
	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	// Token: 0x04001E2B RID: 7723
	private List<Character> characters;

	// Token: 0x04001E2C RID: 7724
	private Dictionary<Character, GameObject> _mapCachedModels;

	// Token: 0x04001E2D RID: 7725
	protected CharacterSelectView _characterSelectView;

	// Token: 0x04001E2E RID: 7726
	protected GameObject _characterModel;

	// Token: 0x04001E2F RID: 7727
	protected Character _curCharacter;

	// Token: 0x04001E30 RID: 7728
	protected AvatarDNA _curDNA = new AvatarDNA();

	// Token: 0x04001E31 RID: 7729
	protected GameObject _modelGroup;

	// Token: 0x04001E32 RID: 7730
	protected GameObject _skeleton;

	// Token: 0x04001E33 RID: 7731
	private Camera _camera;

	// Token: 0x04001E34 RID: 7732
	protected bool bNeedQuitCourotine;

	// Token: 0x04001E35 RID: 7733
	private UIModelController _modelCtrl;

	// Token: 0x04001E36 RID: 7734
	private Vector3 _v3RotateSpeed = new Vector3(-0.5f, 0f, 0f);

	// Token: 0x04001E37 RID: 7735
	private static List<Character> cachedCharacter;

	// Token: 0x04001E38 RID: 7736
	public bool inAnimation;
}
