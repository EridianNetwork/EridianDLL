using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020004AA RID: 1194
public class PlayerAssembly : MonoBehaviour, InstantiateManager.InstanciationClient
{
	// Token: 0x06001FF4 RID: 8180 RVA: 0x000162F0 File Offset: 0x000144F0
	private void Awake()
	{
		if (this.mManuals.Count == 0)
		{
			this.method_21(base.GetComponent<EntityPlayer>().m_AssemblyConfig);
		}
	}

	// Token: 0x06001FF5 RID: 8181 RVA: 0x0009C0FC File Offset: 0x0009A2FC
	public void method_0(bool bool_0, AvatarType avatarType_0)
	{
		this.method_16(bool_0, avatarType_0);
		InstantiateManager.SpawnRequest spawnRequest = default(InstantiateManager.SpawnRequest);
		string[] array = this.mManual.mResources.Select<PlayerAssembly.ResourceInfo, string>(new Func<PlayerAssembly.ResourceInfo, string>(PlayerAssembly.smethod_1)).ToArray<string>();
		DebugUtils.Log(LogCategory.Framework, "Ready to start assembling player character with resources: \n" + string.Join("\n", array));
		foreach (PlayerAssembly.ResourceInfo resourceInfo in this.mManual.mResources)
		{
			PlayerAssembly.ResourceGenerateType mFrom = resourceInfo.mFrom;
			if (mFrom != PlayerAssembly.ResourceGenerateType.BuildingKit)
			{
				if (mFrom == PlayerAssembly.ResourceGenerateType.Prefab)
				{
					spawnRequest.m_prefabName = resourceInfo.mPath;
					spawnRequest.m_position = Vector3.zero;
					spawnRequest.m_rotation = Quaternion.identity;
					spawnRequest.m_group = InstantiateManager.NetworkReplicationGroup.InGame;
					spawnRequest.m_spawnData = new object[1];
					spawnRequest.m_spawnData[0] = NetworkManager.GetActorId();
					spawnRequest.m_callbackData = null;
					spawnRequest.m_isNetworkInstanciate = false;
					spawnRequest.m_caller = this;
					MonoSingleton<AppManager>.Instance.GetComponent<InstantiateManager>().method_0(spawnRequest);
				}
			}
			else
			{
				this.method_13(resourceInfo.mPath);
			}
		}
	}

	// Token: 0x06001FF6 RID: 8182 RVA: 0x00016310 File Offset: 0x00014510
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		this.mInstantiatedObjects[request.m_prefabName] = instance;
		this.method_8();
	}

	// Token: 0x06001FF7 RID: 8183 RVA: 0x0009C250 File Offset: 0x0009A450
	public bool method_1()
	{
		if (this.m_generator == null)
		{
			return false;
		}
		EntityPlayer component = base.GetComponent<EntityPlayer>();
		if (component.method_125() == null && this.mNetPeer == PlayerAssembly.PlayerNetworkPeerType.Local)
		{
			BuildingKitRender buildingKitRender = new BuildingKitRender(this.m_generator.BuildingUnit_0);
			component.method_124(buildingKitRender);
		}
		component.method_116(this.method_19(PlayerAssembly.InstallType.Animator_3rd).transform.Find("displayObj"));
		this.method_4();
		return true;
	}

	// Token: 0x06001FF8 RID: 8184 RVA: 0x0009C2C0 File Offset: 0x0009A4C0
	private void method_2(GameObject gameObject_0)
	{
		PlayerAnimationManagerFSM playerAnimationManagerFSM = null;
		try
		{
			playerAnimationManagerFSM = base.transform.GetComponent<PlayerAnimationManagerFSM>();
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, "PlaterAssembly.Install_3rd_Animator [" + ex + "]");
		}
		if (playerAnimationManagerFSM == null)
		{
			return;
		}
		playerAnimationManagerFSM.vmethod_4(gameObject_0);
		gameObject_0.AddComponent<RootMotionController>();
		if (this.mNetPeer != PlayerAssembly.PlayerNetworkPeerType.Local)
		{
			base.GetComponent<EntityPlayer>().m_skeleton = gameObject_0.AddComponent<Skeleton>();
			this.method_3();
		}
		if (this.mNetPeer == PlayerAssembly.PlayerNetworkPeerType.Remote)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				TownPlayerAnimationEventController townPlayerAnimationEventController = gameObject_0.AddComponent<TownPlayerAnimationEventController>();
				playerAnimationManagerFSM.m_animationEventController = townPlayerAnimationEventController;
				townPlayerAnimationEventController.method_3();
			}
			else
			{
				AnimationEventController animationEventController = gameObject_0.AddComponent<AnimationEventController>();
				playerAnimationManagerFSM.m_animationEventController = animationEventController;
				animationEventController.method_3();
			}
		}
		base.GetComponent<CollisionManager>().method_0(!MonoSingleton<Session>.Instance.method_16());
		Rigidbody[] componentsInChildren = gameObject_0.GetComponentsInChildren<Rigidbody>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].useGravity = false;
		}
	}

	// Token: 0x06001FF9 RID: 8185 RVA: 0x0001632B File Offset: 0x0001452B
	private void method_3()
	{
		base.StartCoroutine(base.GetComponent<EntityPlayer>().method_24());
	}

	// Token: 0x06001FFA RID: 8186 RVA: 0x0009C3C8 File Offset: 0x0009A5C8
	private void method_4()
	{
		GameObject gameObject = this.method_19(PlayerAssembly.InstallType.Animator_3rd);
		if (gameObject != null)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
			{
				skinnedMeshRenderer.enabled = false;
			}
			VFXManager componentInChildren = gameObject.GetComponentInChildren<VFXManager>();
			if (componentInChildren != null)
			{
				global::UnityEngine.Object.Destroy(componentInChildren);
			}
		}
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x0009C420 File Offset: 0x0009A620
	private void method_5(GameObject gameObject_0)
	{
		PlayerAnimationManagerFSM playerAnimationManagerFSM = null;
		try
		{
			playerAnimationManagerFSM = base.GetComponent<PlayerAnimationManagerFSM>();
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, "PlaterAssembly.Install_1st_Animator [" + ex + "]");
		}
		if (playerAnimationManagerFSM == null)
		{
			return;
		}
		playerAnimationManagerFSM.method_25(gameObject_0.GetComponent<Animator>());
		this.method_4();
		base.GetComponent<EntityPlayer>().m_skeleton = gameObject_0.AddComponent<Skeleton>();
		EntityPlayer component = base.GetComponent<EntityPlayer>();
		Skeleton component2 = gameObject_0.GetComponent<Skeleton>();
		BadAssFPSCamera component3 = this.method_19(PlayerAssembly.InstallType.FPSCamera).GetComponent<BadAssFPSCamera>();
		component3.method_0(component, component2.method_8());
		component.method_44(component3);
		if (ComponentMonoSingleton<AudioSystem>.Instance != null)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.method_2(component3.transform);
		}
		this.method_20(gameObject_0, component3);
		base.GetComponent<PlayerControllerLocal>().method_10(component2.method_9(), component2.method_10(), component2.method_11());
		component3.GetComponent<Camera>().enabled = true;
		this.method_3();
		if (MonoSingleton<Session>.Instance.method_16())
		{
			base.GetComponent<CollisionManager>().method_20();
		}
	}

	// Token: 0x06001FFC RID: 8188 RVA: 0x0009C528 File Offset: 0x0009A728
	private void method_6(GameObject gameObject_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		MonoSingleton<GameFlowManager>.Instance.method_18();
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_18().method_3(gameObject_0);
			MonoSingleton<GraphicsMgr>.Instance.method_18().method_4();
		}
		MonoSingleton<GameFlowManager>.Instance.method_0();
	}

	// Token: 0x06001FFD RID: 8189 RVA: 0x0009C584 File Offset: 0x0009A784
	private void method_7(string string_0, GameObject gameObject_0)
	{
		Transform transform = this.method_14(string_0);
		gameObject_0.transform.parent = transform;
		gameObject_0.transform.localPosition = Vector3.zero;
		gameObject_0.transform.localRotation = Quaternion.identity;
	}

	// Token: 0x06001FFE RID: 8190 RVA: 0x0009C5C8 File Offset: 0x0009A7C8
	private void method_8()
	{
		DebugUtils.Log(LogCategory.Framework, "Start to assembly player");
		if (MonoSingleton<Session>.Instance == null)
		{
			MonoSingleton<GameFlowManager>.Instance.method_18();
			DebugUtils.LogError(LogCategory.Framework, "Session is null");
			return;
		}
		string text;
		if (!this.method_18(out text))
		{
			DebugUtils.LogError(LogCategory.Framework, "Object [" + text + "] is not instantiated yet");
			return;
		}
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.mInstantiatedObjects)
		{
			string key = keyValuePair.Key;
			GameObject value = keyValuePair.Value;
			switch (this.mManual.method_0(key))
			{
			case PlayerAssembly.InstallType.Animator_3rd:
				this.method_7(key, value);
				this.method_2(value);
				break;
			case PlayerAssembly.InstallType.Animator_1st_Siren:
				this.method_5(value);
				this.method_7(key, value);
				break;
			case PlayerAssembly.InstallType.Animator_1st_Soldier:
				this.method_5(value);
				this.method_7(key, value);
				break;
			case PlayerAssembly.InstallType.Animator_1st_Berserker:
				this.method_5(value);
				this.method_7(key, value);
				break;
			case PlayerAssembly.InstallType.Animator_1st_Hunter:
				this.method_5(value);
				this.method_7(key, value);
				break;
			case PlayerAssembly.InstallType.FPSCamera:
				this.method_6(value);
				break;
			default:
				this.method_7(key, value);
				break;
			}
		}
		this.method_10();
	}

	// Token: 0x06001FFF RID: 8191 RVA: 0x0009C724 File Offset: 0x0009A924
	public void method_9(int int_0, int int_1, int int_2)
	{
		if (this.m_generatorInventoryView == null)
		{
			return;
		}
		EntityPlayer component = base.GetComponent<EntityPlayer>();
		if (this.mNetPeer == PlayerAssembly.PlayerNetworkPeerType.Local)
		{
			component.method_123(int_0, int_1, int_2);
		}
	}

	// Token: 0x06002000 RID: 8192 RVA: 0x0009C754 File Offset: 0x0009A954
	private void method_10()
	{
		bool flag = this.mNetPeer != PlayerAssembly.PlayerNetworkPeerType.Remote;
		PlayerAnimationManagerFSM playerAnimationManagerFSM = null;
		try
		{
			playerAnimationManagerFSM = base.GetComponent<PlayerAnimationManagerFSM>();
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, "PlaterAssembly.PostAssembling [" + ex + "]");
		}
		if (playerAnimationManagerFSM == null)
		{
			return;
		}
		EntityPlayer component = base.GetComponent<EntityPlayer>();
		if (this.mNetPeer == PlayerAssembly.PlayerNetworkPeerType.Local)
		{
			this.m_generatorInventoryView = new BuildingKitRender(this.m_generator.BuildingUnit_0);
			component.method_124(this.m_generatorInventoryView);
			component.method_122();
		}
		playerAnimationManagerFSM.vmethod_6(flag);
		playerAnimationManagerFSM.vmethod_29();
		component.PlayerSkillManage_0.OnPostAssembly();
		component.method_113(this.method_19(PlayerAssembly.InstallType.TitleObj));
		if (!component.vmethod_26())
		{
			component.method_21();
		}
		component.method_116(this.method_19(PlayerAssembly.InstallType.Animator_3rd).transform.Find("displayObj"));
		if (MonoSingleton<Session>.Instance.method_16() && NPC_UIFlowController.smethod_0().Boolean_0)
		{
			component.method_117(true);
		}
		if (component.vmethod_25() == null)
		{
			global::UnityEngine.Object.DestroyImmediate(component.gameObject);
		}
	}

	// Token: 0x06002001 RID: 8193 RVA: 0x0001633F File Offset: 0x0001453F
	public BuildingKitRender method_11()
	{
		return this.m_generatorInventoryView;
	}

	// Token: 0x06002002 RID: 8194 RVA: 0x00016347 File Offset: 0x00014547
	public BuildingKitRender method_12()
	{
		return this.m_generator;
	}

	// Token: 0x06002003 RID: 8195 RVA: 0x0009C86C File Offset: 0x0009AA6C
	private void method_13(string string_0)
	{
		AvatarDNA avatarDna = base.GetComponent<EntityPlayer>().vmethod_25().m_avatarDna;
		uint num = avatarDna.m_buildingUnit.bkID;
		if (num == 0U)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "bkID is 0 in InstantiatedByBuildingKit");
			num = BuildingKitManager.smethod_1("CHR", "Siren");
		}
		BuildingKitRender buildingKitRender = new BuildingKitRender(num);
		if (!BuildingKitManager.OnlineHostMinResMode)
		{
			buildingKitRender.BuildingUnit_0 = avatarDna.m_buildingUnit;
		}
		this.m_generator = buildingKitRender;
		GameObject gameObject = buildingKitRender.method_6();
		this.mInstantiatedObjects[string_0] = gameObject;
	}

	// Token: 0x06002004 RID: 8196 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnAssetBundleLoaded(object param = null)
	{
	}

	// Token: 0x06002005 RID: 8197 RVA: 0x0009C8EC File Offset: 0x0009AAEC
	private Transform method_14(string string_0)
	{
		string text = string.Empty;
		foreach (ResourceInfo mResource in mManual.mResources)
		{
			if (mResource.mPath == string_0)
			{
				text = mResource.mParentPath;
				break;
			}
		}
		try
		{
			if (text == sName_Root)
			{
				return base.gameObject.transform;
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, string.Concat("Can't get gameObject for[", sName_Root, "][", ex, "]"));
		}
		Dictionary<string, GameObject>.Enumerator enumerator2 = mInstantiatedObjects.GetEnumerator();
		do
		{
			if (!enumerator2.MoveNext())
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "GetParent() error");
				return null;
			}
		}
		while (!(enumerator2.Current.Key == text) || !(enumerator2.Current.Value != null));
		return enumerator2.Current.Value.transform;
	}
	// Token: 0x06002006 RID: 8198 RVA: 0x0009CA30 File Offset: 0x0009AC30
	private void method_15(PlayerAssembly.PlayerNetworkPeerType playerNetworkPeerType_0, AvatarType avatarType_0)
	{
		if (playerNetworkPeerType_0 == PlayerAssembly.PlayerNetworkPeerType.Local)
		{
			this.mManual = new PlayerAssembly.AssemblyManual();
			using (List<PlayerAssembly.ResourceInfo>.Enumerator enumerator = this.mManuals[playerNetworkPeerType_0].mResources.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PlayerAssembly.ResourceInfo resourceInfo = enumerator.Current;
					if (resourceInfo.mInstallType == PlayerAssembly.InstallType.Animator_1st_Siren)
					{
						if (avatarType_0 == AvatarType.SIREN)
						{
							this.mManual.mResources.Add(resourceInfo);
						}
					}
					else if (resourceInfo.mInstallType == PlayerAssembly.InstallType.Animator_1st_Soldier)
					{
						if (avatarType_0 == AvatarType.SOLDIER)
						{
							this.mManual.mResources.Add(resourceInfo);
						}
					}
					else if (resourceInfo.mInstallType == PlayerAssembly.InstallType.Animator_1st_Berserker)
					{
						if (avatarType_0 == AvatarType.BERSERKER)
						{
							this.mManual.mResources.Add(resourceInfo);
						}
					}
					else if (resourceInfo.mInstallType == PlayerAssembly.InstallType.Animator_1st_Hunter)
					{
						if (avatarType_0 == AvatarType.HUNTER)
						{
							this.mManual.mResources.Add(resourceInfo);
						}
					}
					else
					{
						this.mManual.mResources.Add(resourceInfo);
					}
				}
				return;
			}
		}
		this.mManual = this.mManuals[playerNetworkPeerType_0];
	}

	// Token: 0x06002007 RID: 8199 RVA: 0x0009CB48 File Offset: 0x0009AD48
	private void OnDestroy()
	{
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.mInstantiatedObjects)
		{
			if (keyValuePair.Value != null)
			{
				global::UnityEngine.Object.Destroy(keyValuePair.Value);
			}
		}
	}

	// Token: 0x06002008 RID: 8200 RVA: 0x0009CBB0 File Offset: 0x0009ADB0
	private void method_16(bool bool_0, AvatarType avatarType_0)
	{
		this.mNetPeer = this.method_17(bool_0);
		this.method_15(this.mNetPeer, avatarType_0);
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.mInstantiatedObjects)
		{
			if (keyValuePair.Value != null)
			{
				global::UnityEngine.Object.Destroy(keyValuePair.Value);
			}
		}
		this.mInstantiatedObjects.Clear();
		foreach (PlayerAssembly.ResourceInfo resourceInfo in this.mManual.mResources)
		{
			this.mInstantiatedObjects.Add(resourceInfo.mPath, null);
		}
	}

	// Token: 0x06002009 RID: 8201 RVA: 0x0001634F File Offset: 0x0001454F
	private PlayerAssembly.PlayerNetworkPeerType method_17(bool bool_0)
	{
		if (bool_0)
		{
			return PlayerAssembly.PlayerNetworkPeerType.Local;
		}
		return PlayerAssembly.PlayerNetworkPeerType.Remote;
	}

	// Token: 0x0600200A RID: 8202 RVA: 0x0009CC90 File Offset: 0x0009AE90
	private bool method_18(out string string_0)
	{
		string_0 = null;
		foreach (KeyValuePair<string, GameObject> keyValuePair in this.mInstantiatedObjects)
		{
			if (keyValuePair.Value == null)
			{
				string_0 = keyValuePair.Key;
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600200B RID: 8203 RVA: 0x0009CD00 File Offset: 0x0009AF00
	private GameObject method_19(PlayerAssembly.InstallType installType_0)
	{
		foreach (PlayerAssembly.ResourceInfo resourceInfo in this.mManual.mResources)
		{
			if (resourceInfo.mInstallType == installType_0)
			{
				return this.mInstantiatedObjects[resourceInfo.mPath];
			}
		}
		return null;
	}

	// Token: 0x0600200C RID: 8204 RVA: 0x0009CD74 File Offset: 0x0009AF74
	private void method_20(GameObject gameObject_0, BadAssFPSCamera badAssFPSCamera_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		Shader shader = Shader.Find("Custom/BOL_Charactor_BRDF_FOV");
		if (shader == null)
		{
			return;
		}
		if (badAssFPSCamera_0 == null)
		{
			return;
		}
		WeaponCameraControl componentInChildren = badAssFPSCamera_0.GetComponentInChildren<WeaponCameraControl>();
		if (componentInChildren == null)
		{
			return;
		}
		SkinnedMeshRenderer componentInChildren2 = gameObject_0.GetComponentInChildren<SkinnedMeshRenderer>();
		EntityPlayer component = base.GetComponent<EntityPlayer>();
		if (component != null)
		{
			component.m_fpHandMaterial = global::UnityEngine.Object.Instantiate(componentInChildren2.material) as Material;
			component.method_59(true);
		}
		componentInChildren2.material.shader = shader;
		componentInChildren2.material.CopyPropertiesFromMaterial(component.m_fpHandMaterial);
		componentInChildren2.material.SetMatrix("_ProjMat", componentInChildren.method_0());
		componentInChildren2.materials = new Material[]
		{
			new Material(Shader.Find("Custom/BOL_ClearZFov")),
			componentInChildren2.material
		};
		componentInChildren2.materials[0].SetMatrix("_ProjMat", componentInChildren.method_0());
	}

	// Token: 0x0600200D RID: 8205 RVA: 0x0009CE64 File Offset: 0x0009B064
	private void method_21(TextAsset textAsset_0)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset_0.text);
		foreach (string text in Enum.GetNames(typeof(PlayerAssembly.PlayerNetworkPeerType)))
		{
			PlayerAssembly.PlayerNetworkPeerType playerNetworkPeerType = (PlayerAssembly.PlayerNetworkPeerType)((int)Enum.Parse(typeof(PlayerAssembly.PlayerNetworkPeerType), text));
			PlayerAssembly.AssemblyManual assemblyManual = new PlayerAssembly.AssemblyManual();
			XmlNode xmlNode = xmlDocument.GetElementsByTagName(text)[0];
			PlayerAssembly.smethod_0(xmlNode.FirstChild, assemblyManual);
			this.mManuals.Add(playerNetworkPeerType, assemblyManual);
		}
	}

	// Token: 0x0600200E RID: 8206 RVA: 0x0009CEF0 File Offset: 0x0009B0F0
	private static void smethod_0(XmlNode xmlNode_0, PlayerAssembly.AssemblyManual assemblyManual_0)
	{
		foreach (object obj in xmlNode_0.ChildNodes)
		{
			XmlNode xmlNode = (XmlNode)obj;
			string value = xmlNode.Attributes["Path"].Value;
			string value2 = xmlNode_0.Attributes["Path"].Value;
			string value3 = xmlNode.Attributes["GenerateType"].Value;
			string value4 = xmlNode.Attributes["InstallType"].Value;
			assemblyManual_0.mResources.Add(new PlayerAssembly.ResourceInfo(value, value2, (PlayerAssembly.ResourceGenerateType)((int)Enum.Parse(typeof(PlayerAssembly.ResourceGenerateType), value3)), (PlayerAssembly.InstallType)((int)Enum.Parse(typeof(PlayerAssembly.InstallType), value4))));
			PlayerAssembly.smethod_0(xmlNode, assemblyManual_0);
		}
	}

	// Token: 0x0600200F RID: 8207 RVA: 0x00016357 File Offset: 0x00014557
	[CompilerGenerated]
	private static string smethod_1(PlayerAssembly.ResourceInfo resourceInfo_0)
	{
		return resourceInfo_0.mPath;
	}

	// Token: 0x040014A3 RID: 5283
	private string sName_Root = "Root";

	// Token: 0x040014A4 RID: 5284
	private PlayerAssembly.PlayerNetworkPeerType mNetPeer;

	// Token: 0x040014A5 RID: 5285
	private PlayerAssembly.AssemblyManual mManual;

	// Token: 0x040014A6 RID: 5286
	private Dictionary<PlayerAssembly.PlayerNetworkPeerType, PlayerAssembly.AssemblyManual> mManuals = new Dictionary<PlayerAssembly.PlayerNetworkPeerType, PlayerAssembly.AssemblyManual>();

	// Token: 0x040014A7 RID: 5287
	private Dictionary<string, GameObject> mInstantiatedObjects = new Dictionary<string, GameObject>();

	// Token: 0x040014A8 RID: 5288
	private BuildingKitRender m_generatorInventoryView;

	// Token: 0x040014A9 RID: 5289
	private BuildingKitRender m_generator;

	// Token: 0x020004AB RID: 1195
	private enum PlayerNetworkPeerType
	{
		// Token: 0x040014AC RID: 5292
		Host,
		// Token: 0x040014AD RID: 5293
		Local,
		// Token: 0x040014AE RID: 5294
		Remote
	}

	// Token: 0x020004AC RID: 1196
	public enum ResourceGenerateType
	{
		// Token: 0x040014B0 RID: 5296
		BuildingKit,
		// Token: 0x040014B1 RID: 5297
		Prefab
	}

	// Token: 0x020004AD RID: 1197
	public enum InstallType
	{
		// Token: 0x040014B3 RID: 5299
		Animator_3rd,
		// Token: 0x040014B4 RID: 5300
		Animator_1st_Siren,
		// Token: 0x040014B5 RID: 5301
		Animator_1st_Soldier,
		// Token: 0x040014B6 RID: 5302
		Animator_1st_Berserker,
		// Token: 0x040014B7 RID: 5303
		Animator_1st_Hunter,
		// Token: 0x040014B8 RID: 5304
		FPSCamera,
		// Token: 0x040014B9 RID: 5305
		TitleObj,
		// Token: 0x040014BA RID: 5306
		Default
	}

	// Token: 0x020004AE RID: 1198
	public struct ResourceInfo
	{
		// Token: 0x06002010 RID: 8208 RVA: 0x00016360 File Offset: 0x00014560
		public ResourceInfo(string string_0, string string_1, PlayerAssembly.ResourceGenerateType resourceGenerateType_0, PlayerAssembly.InstallType installType_0)
		{
			this.mPath = string_0;
			this.mParentPath = string_1;
			this.mFrom = resourceGenerateType_0;
			this.mInstallType = installType_0;
		}

		// Token: 0x040014BB RID: 5307
		public string mPath;

		// Token: 0x040014BC RID: 5308
		public string mParentPath;

		// Token: 0x040014BD RID: 5309
		public PlayerAssembly.ResourceGenerateType mFrom;

		// Token: 0x040014BE RID: 5310
		public PlayerAssembly.InstallType mInstallType;
	}

	// Token: 0x020004AF RID: 1199
	public class AssemblyManual
	{
		// Token: 0x06002012 RID: 8210 RVA: 0x0009CFEC File Offset: 0x0009B1EC
		public PlayerAssembly.InstallType method_0(string string_0)
		{
			foreach (PlayerAssembly.ResourceInfo resourceInfo in this.mResources)
			{
				if (string_0 == resourceInfo.mPath)
				{
					return resourceInfo.mInstallType;
				}
			}
			return PlayerAssembly.InstallType.Default;
		}

		// Token: 0x040014BF RID: 5311
		public List<PlayerAssembly.ResourceInfo> mResources = new List<PlayerAssembly.ResourceInfo>();
	}
}
