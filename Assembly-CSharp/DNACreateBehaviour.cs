using System;
using System.Collections;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200068C RID: 1676
public class DNACreateBehaviour : StepBehaviour
{
	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06002B59 RID: 11097 RVA: 0x0001CB93 File Offset: 0x0001AD93
	// (set) Token: 0x06002B5A RID: 11098 RVA: 0x0001CB9B File Offset: 0x0001AD9B
	public AvatarSubPart AvatarSubPart_0
	{
		get
		{
			return this.focusPart;
		}
		private set
		{
			this.focusPart = value;
		}
	}

	// Token: 0x06002B5B RID: 11099 RVA: 0x0001CBA4 File Offset: 0x0001ADA4
	private void Awake()
	{
		this._CustomPlayerDNA = new AvatarDNA();
		this.cameraObj = GameObject.Find("Class_selection_Camera");
		MonoSingleton<AppManager>.Instance.method_16(this);
	}

	// Token: 0x06002B5C RID: 11100 RVA: 0x0001CBCC File Offset: 0x0001ADCC
	private void OnDestroy()
	{
		MonoSingleton<AppManager>.Instance.method_17();
	}

	// Token: 0x06002B5D RID: 11101 RVA: 0x0001CBD8 File Offset: 0x0001ADD8
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		this.method_0();
		this.method_1();
	}

	// Token: 0x06002B5E RID: 11102 RVA: 0x000CA0DC File Offset: 0x000C82DC
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		if (stepState_0 == FrontEndStepManager.StepState.ClassSelect && this._modelCtrl != null)
		{
			this._modelCtrl.method_1();
			global::UnityEngine.Object.Destroy(this._modelCtrl);
			this._modelCtrl = null;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<ClassCustomView>();
	}

	// Token: 0x06002B5F RID: 11103 RVA: 0x000CA128 File Offset: 0x000C8328
	protected void method_0()
	{
		this._modelGroup = GameObject.Find("Model_Group");
		if (this._modelGroup != null)
		{
			this._avatarManager = this._modelGroup.GetComponent<UIAvatarManager>();
			if (this._avatarManager == null)
			{
				DebugUtils.LogError(LogCategory.GUI, "----------initAvatarModel---------");
			}
			foreach (Transform transform in this._modelGroup.GetComponentsInChildren<Transform>(true))
			{
				string name = transform.gameObject.name;
				switch (name)
				{
				case "CHR_Soldier_Skeleton_01":
					transform.gameObject.SetActive(false);
					if (MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0 == AvatarType.SOLDIER)
					{
						this._avatar = transform.gameObject;
						this._avatar.SetActive(true);
					}
					break;
				case "CHR_Siren_Skeleton_01":
					transform.gameObject.SetActive(false);
					if (MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0 == AvatarType.SIREN)
					{
						this._avatar = transform.gameObject;
						this._avatar.SetActive(true);
					}
					break;
				case "CHR_Berserker_Skeleton_01":
					transform.gameObject.SetActive(false);
					if (MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0 == AvatarType.BERSERKER)
					{
						this._avatar = transform.gameObject;
						this._avatar.SetActive(true);
					}
					break;
				case "CHR_Hunter_Skeleton_01":
					transform.gameObject.SetActive(false);
					if (MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0 == AvatarType.HUNTER)
					{
						this._avatar = transform.gameObject;
						this._avatar.SetActive(true);
					}
					break;
				}
			}
		}
		this._CustomPlayerDNA.m_type = MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0;
		this.generator = this._avatarManager.method_1(this._CustomPlayerDNA.m_type).buildingKitRender;
		this._CustomPlayerDNA.m_buildingUnit = this._avatarManager.method_1(this._CustomPlayerDNA.m_type).buildingKitRender.BuildingUnit_0;
		this._modelCtrl = this._avatar.GetComponent<UIModelController>();
		if (this._modelCtrl == null)
		{
			this._modelCtrl = this._avatar.AddComponent<UIModelController>();
		}
	}

	// Token: 0x06002B60 RID: 11104 RVA: 0x000CA3AC File Offset: 0x000C85AC
	protected void method_1()
	{
		ClassCustomView classCustomView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ClassCustomView>();
		classCustomView.vmethod_5();
		classCustomView.vmethod_2();
		classCustomView._logicBehaviour = this;
	}

	// Token: 0x06002B61 RID: 11105 RVA: 0x000CA3DC File Offset: 0x000C85DC
	private IEnumerator method_2(GameObject gameObject_0, AvatarDNA avatarDNA_0, string string_0)
	{
		yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_5(generator.method_16()));
		gameObject_0 = generator.method_7();
		Renderer[] componentsInChildren = gameObject_0.GetComponentsInChildren<Renderer>();
		foreach (Renderer iter in componentsInChildren)
		{
			iter.enabled = true;
		}
	}
	// Token: 0x06002B62 RID: 11106 RVA: 0x000CA408 File Offset: 0x000C8608
	private void method_3(AvatarDNA avatarDNA_0, byte byte_0, byte byte_1, bool bool_0 = true)
	{
		switch (byte_0)
		{
		case 0:
			avatarDNA_0.method_2(0, byte_1);
			if (bool_0)
			{
				this.focusPart = AvatarSubPart.HAIR;
			}
			break;
		case 1:
			avatarDNA_0.method_2(1, byte_1);
			if (bool_0)
			{
				this.focusPart = AvatarSubPart.HEAD;
			}
			break;
		case 2:
			avatarDNA_0.method_4(3, byte_1);
			if (bool_0)
			{
				this.focusPart = AvatarSubPart.BODY;
			}
			break;
		case 3:
			avatarDNA_0.method_4(4, byte_1);
			if (bool_0)
			{
				this.focusPart = AvatarSubPart.PANTS;
			}
			break;
		case 4:
			avatarDNA_0.method_4(5, byte_1);
			if (bool_0)
			{
				this.focusPart = AvatarSubPart.SHOE;
			}
			break;
		default:
			DebugUtils.LogError(LogCategory.GUI, "Wrong Parameter in customization part mapping");
			break;
		}
	}

	// Token: 0x06002B63 RID: 11107 RVA: 0x000CA4A8 File Offset: 0x000C86A8
	private void Update()
	{
		if (Input.mousePosition.x > (float)Screen.width || Input.mousePosition.y > (float)Screen.height || Input.mousePosition.x < 0f || Input.mousePosition.y < 0f)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ClassCustomView>().method_8(true);
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

	// Token: 0x06002B64 RID: 11108 RVA: 0x000CA560 File Offset: 0x000C8760
	public void method_4(byte byte_0)
	{
		Animation component = this.cameraObj.GetComponent<Animation>();
		if (byte_0 != (byte)this.focusPart)
		{
			if (this.focusPart == AvatarSubPart.BODY)
			{
				if (byte_0 == 0 || byte_0 == 1)
				{
					component["ANI_Looby_CustemerZoomBodytoHead"].speed = 1f;
					component.Play("ANI_Looby_CustemerZoomBodytoHead");
				}
				if (byte_0 == 5 || byte_0 == 4)
				{
					component["ANI_Looby_CustemerZoomBodytoFeet"].speed = 1f;
					component.Play("ANI_Looby_CustemerZoomBodytoFeet");
				}
			}
			if (this.focusPart == AvatarSubPart.HAIR || this.focusPart == AvatarSubPart.HEAD)
			{
				if (byte_0 == 3)
				{
					component["ANI_Looby_CustemerZoomBodytoHead"].time = component["ANI_Looby_CustemerZoomBodytoHead"].length;
					component["ANI_Looby_CustemerZoomBodytoHead"].speed = -1f;
					component.Play("ANI_Looby_CustemerZoomBodytoHead");
				}
				if (byte_0 == 4 || byte_0 == 5)
				{
					component["ANI_Looby_CustemerZoomHeadtoFeet"].speed = 1f;
					component.Play("ANI_Looby_CustemerZoomHeadtoFeet");
				}
			}
			if (this.focusPart == AvatarSubPart.PANTS || this.focusPart == AvatarSubPart.SHOE)
			{
				if (byte_0 == 3)
				{
					component["ANI_Looby_CustemerZoomBodytoFeet"].time = component["ANI_Looby_CustemerZoomBodytoFeet"].length;
					component["ANI_Looby_CustemerZoomBodytoFeet"].speed = -1f;
					component.Play("ANI_Looby_CustemerZoomBodytoFeet");
				}
				if (byte_0 == 0 || byte_0 == 1)
				{
					component["ANI_Looby_CustemerZoomHeadtoFeet"].time = component["ANI_Looby_CustemerZoomHeadtoFeet"].length;
					component["ANI_Looby_CustemerZoomHeadtoFeet"].speed = -1f;
					component.Play("ANI_Looby_CustemerZoomHeadtoFeet");
				}
			}
		}
	}

	// Token: 0x06002B65 RID: 11109 RVA: 0x0001CBE6 File Offset: 0x0001ADE6
	public void method_5(byte byte_0, byte byte_1, bool bool_0 = true)
	{
		if (bool_0)
		{
			this.method_4(DNACreateBehaviour.INDEX_PART_MAP[(int)byte_0]);
		}
		this.method_3(this._CustomPlayerDNA, byte_0, byte_1, bool_0);
	}

	// Token: 0x06002B66 RID: 11110 RVA: 0x0001CC07 File Offset: 0x0001AE07
	public void method_6(string string_0)
	{
		base.StartCoroutine(this.method_2(this._avatar, this._CustomPlayerDNA, string_0));
	}

	// Token: 0x06002B67 RID: 11111 RVA: 0x0001CC23 File Offset: 0x0001AE23
	public void method_7(string string_0)
	{
		this._characterName = string_0;
	}

	// Token: 0x06002B68 RID: 11112 RVA: 0x000CA704 File Offset: 0x000C8904
	public void method_8()
	{
		if (!MonoSingleton<AsyncTaskManager>.Instance.HasTaskOfType<CharacterService.CreateCharacterAsyncTask>())
		{
			CharacterService.CreateCharacterAsyncTask createCharacterAsyncTask = new CharacterService.CreateCharacterAsyncTask();
			createCharacterAsyncTask.method_4(this._characterName, this._CustomPlayerDNA);
			MonoSingleton<AsyncTaskManager>.Instance.method_1(createCharacterAsyncTask, new TaskCompletedDelegate(this.OnAvatarCreated));
		}
	}

	// Token: 0x06002B69 RID: 11113 RVA: 0x000CA74C File Offset: 0x000C894C
	private void OnAvatarCreated(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (result != AsyncTaskStatus.Success)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ClassCustomView>().vmethod_6(result);
			return;
		}
		Character character = (task as CharacterService.CreateCharacterAsyncTask).m_character;
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_id = character.Id;
		playerProperties.m_name = character.Name;
		playerProperties.m_exp = character.Experience;
		playerProperties.m_level = character.Level;
		AvatarDNA avatarDNA = new AvatarDNA();
		avatarDNA.method_8(character.AvatarType, character.AvatarParts, character.AvatarMaterials, character.AvatarId);
		playerProperties.m_avatarDna = avatarDNA;
		MonoSingleton<PlayerManager>.Instance.method_0(playerProperties, true);
		if (MonoSingleton<AppManager>.Instance.m_skipTutorial)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
			MonoSingleton<GameFlowManager>.Instance.method_11();
			return;
		}
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
		MonoSingleton<GameFlowManager>.Instance.method_8(MatchmakingService.MatchmakingService_0.method_3("lvl_Floasm_Small").m_id);
	}

	// Token: 0x04001E82 RID: 7810
	private const string MODEL_SOLDIER_NAME = "CHR_Soldier_Skeleton_01";

	// Token: 0x04001E83 RID: 7811
	private const string MODEL_SIREN_NAME = "CHR_Siren_Skeleton_01";

	// Token: 0x04001E84 RID: 7812
	private const string MODEL_BERSERKER_NAME = "CHR_Berserker_Skeleton_01";

	// Token: 0x04001E85 RID: 7813
	private const string MODEL_HUNTER_NAME = "CHR_Hunter_Skeleton_01";

	// Token: 0x04001E86 RID: 7814
	private BuildingKitRender generator;

	// Token: 0x04001E87 RID: 7815
	protected UIAvatarManager _avatarManager;

	// Token: 0x04001E88 RID: 7816
	private AvatarDNA _CustomPlayerDNA;

	// Token: 0x04001E89 RID: 7817
	private string _characterName;

	// Token: 0x04001E8A RID: 7818
	private GameObject _avatar;

	// Token: 0x04001E8B RID: 7819
	private GameObject _modelGroup;

	// Token: 0x04001E8C RID: 7820
	private static byte[] INDEX_PART_MAP = new byte[] { 0, 1, 3, 4, 5 };

	// Token: 0x04001E8D RID: 7821
	private GameObject cameraObj;

	// Token: 0x04001E8E RID: 7822
	private AvatarSubPart focusPart = AvatarSubPart.BODY;

	// Token: 0x04001E8F RID: 7823
	private UIModelController _modelCtrl;

	// Token: 0x04001E90 RID: 7824
	private Vector3 _v3RotateSpeed = new Vector3(-0.5f, 0f, 0f);
}
