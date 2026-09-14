using System;
using System.Text;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000087 RID: 135
public class PlayerFirstPersonInventoryManager : MonoBehaviour
{
	// Token: 0x060002D3 RID: 723 RVA: 0x00042B80 File Offset: 0x00040D80
	private string method_0(GameObject gameObject_0)
	{
		if (gameObject_0 == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (gameObject_0.transform.parent != null)
		{
			stringBuilder.AppendLine(gameObject_0.transform.parent.name);
			stringBuilder.AppendLine(gameObject_0.transform.parent.localPosition.ToString());
			stringBuilder.AppendLine(gameObject_0.transform.parent.localRotation.ToString());
		}
		stringBuilder.AppendLine(gameObject_0.transform.name);
		stringBuilder.AppendLine(gameObject_0.transform.localPosition.ToString());
		stringBuilder.AppendLine(gameObject_0.transform.localRotation.ToString());
		foreach (object obj in gameObject_0.transform)
		{
			Transform transform = (Transform)obj;
			stringBuilder.AppendLine(transform.name);
			stringBuilder.AppendLine(transform.localPosition.ToString());
			stringBuilder.AppendLine(transform.localRotation.ToString());
		}
		return stringBuilder.ToString();
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x060002D4 RID: 724 RVA: 0x00004AE4 File Offset: 0x00002CE4
	// (set) Token: 0x060002D5 RID: 725 RVA: 0x00004B1C File Offset: 0x00002D1C
	public Skeleton Skeleton_0
	{
		get
		{
			this.m_inventoryPlayerSkeleton = base.gameObject.GetComponent<Skeleton>();
			if (this.m_inventoryPlayerSkeleton == null)
			{
				this.m_inventoryPlayerSkeleton = base.gameObject.AddComponent<Skeleton>();
			}
			return this.m_inventoryPlayerSkeleton;
		}
		set
		{
			this.m_inventoryPlayerSkeleton = value;
		}
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00042CD8 File Offset: 0x00040ED8
	public EntityPlayer method_1()
	{
		if (this.m_entityPlayer == null)
		{
			if (MonoSingleton<Session>.Instance == null)
			{
				return null;
			}
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer == null)
			{
				return null;
			}
			if (localPlayer.GetEntity() != null)
			{
				this.m_entityPlayer = localPlayer.GetEntity() as EntityPlayer;
			}
		}
		return this.m_entityPlayer;
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00042D40 File Offset: 0x00040F40
	public bool method_2()
	{
		if (this.m_equipedClassmode != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_equipedClassmode);
		}
		EntityPlayer entityPlayer = this.method_1();
		if (entityPlayer == null)
		{
			return false;
		}
		if (this.Skeleton_0 == null)
		{
			return false;
		}
		EntityClassMode entityClassMode = entityPlayer.method_38();
		if (entityClassMode == null)
		{
			return false;
		}
		ClassModeDNA classModeDNA = entityClassMode.method_17();
		if (classModeDNA == null)
		{
			return false;
		}
		this.m_equipedClassmode = this.method_4(entityClassMode);
		if (this.m_equipedClassmode != null)
		{
			Transform transform = this.Skeleton_0.method_6(classModeDNA.m_cmType);
			if (transform == null)
			{
				return false;
			}
			this.m_equipedClassmode.transform.parent = transform;
			this.m_equipedClassmode.transform.localPosition = Vector3.zero;
			this.m_equipedClassmode.transform.localRotation = Quaternion.identity;
			this.m_equipedClassmode.transform.localScale = Vector3.one;
			this.m_equipedClassmode.SetActive(true);
			Component component = this.m_equipedClassmode.GetComponent<Animator>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			this.m_equipedClassmode.layer = MonoSingleton<GraphicsMgr>.Instance.method_22().method_6();
			SkinnedMeshRenderer componentInChildren = this.m_equipedClassmode.GetComponentInChildren<SkinnedMeshRenderer>();
			if (componentInChildren != null)
			{
				componentInChildren.gameObject.layer = MonoSingleton<GraphicsMgr>.Instance.method_22().method_6();
			}
		}
		return true;
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x00042EA8 File Offset: 0x000410A8
	public bool method_3()
	{
		if (this.m_equipedWeapon != null)
		{
			global::UnityEngine.Object.Destroy(this.m_equipedWeapon.GetComponentInChildren<SkinnedMeshRenderer>().material);
			global::UnityEngine.Object.DestroyImmediate(this.m_equipedWeapon);
		}
		if (this.m_backWeapon != null)
		{
			global::UnityEngine.Object.Destroy(this.m_backWeapon.GetComponentInChildren<SkinnedMeshRenderer>().material);
			global::UnityEngine.Object.DestroyImmediate(this.m_backWeapon);
		}
		if (this.m_thighWeapon != null)
		{
			global::UnityEngine.Object.Destroy(this.m_thighWeapon.GetComponentInChildren<SkinnedMeshRenderer>().material);
			global::UnityEngine.Object.DestroyImmediate(this.m_thighWeapon);
		}
		EntityPlayer entityPlayer = this.method_1();
		if (entityPlayer == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG weapon_attach: entityPlayer null");
			return false;
		}
		if (this.Skeleton_0 == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG weapon_attach: Skeleton_0 null");
			return false;
		}
		EntityWeapon entityWeapon = entityPlayer.method_27();
		if (!(entityWeapon != null))
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG weapon_attach: method_27 active-weapon-entity null");
			return false;
		}
		this.m_equipedWeapon = this.method_5(entityWeapon);
		if (this.m_equipedWeapon != null)
		{
			this.method_6(this.m_equipedWeapon, this.Skeleton_0.method_4(entityWeapon.method_99()));
			WeaponType weaponType = entityWeapon.method_99();
			if (this.m_inventoryAnimator != null)
			{
				this.m_inventoryAnimator.SetInteger("iWeaponType", (int)weaponType);
			}
			if (this.m_playerIkController != null)
			{
				this.m_playerIkController.m_currentWeaponType = weaponType;
			}
			entityWeapon = entityPlayer.method_25();
			if (entityWeapon != null)
			{
				this.m_backWeapon = this.method_5(entityWeapon);
				if (this.m_backWeapon != null)
				{
					this.method_6(this.m_backWeapon, this.Skeleton_0.method_5(entityWeapon.method_99()));
				}
			}
			entityWeapon = entityPlayer.method_26();
			if (entityWeapon != null)
			{
				this.m_thighWeapon = this.method_5(entityWeapon);
				if (this.m_thighWeapon != null)
				{
					this.method_6(this.m_thighWeapon, this.Skeleton_0.method_5(entityWeapon.method_99()));
				}
			}
			return true;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "BOL_DIAG weapon_attach: method_5 model build returned null");
		return false;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x000430B0 File Offset: 0x000412B0
	private GameObject method_4(EntityClassMode entityClassMode_0)
	{
		if (entityClassMode_0 == null)
		{
			return null;
		}
		GameObject gameObject = entityClassMode_0.gameObject;
		if (gameObject == null)
		{
			return null;
		}
		GameObject gameObject2 = null;
		bool activeInHierarchy = gameObject.activeInHierarchy;
		gameObject.SetActive(true);
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		if (componentInChildren != null)
		{
			gameObject2 = global::UnityEngine.Object.Instantiate(componentInChildren.gameObject) as GameObject;
			if (!(gameObject2 != null))
			{
			}
		}
		gameObject.SetActive(activeInHierarchy);
		return gameObject2;
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0004311C File Offset: 0x0004131C
	private GameObject method_5(EntityWeapon entityWeapon_0)
	{
		if (entityWeapon_0 == null)
		{
			return null;
		}
		if (MonoSingleton<DNAPortrait>.Instance == null)
		{
			return null;
		}
		DNAPortraitData dnaportraitData = MonoSingleton<DNAPortrait>.Instance.method_2(entityWeapon_0.method_13());
		if (dnaportraitData == null)
		{
			return null;
		}
		GameObject model = dnaportraitData.model;
		if (model == null)
		{
			return null;
		}
		GameObject gameObject = null;
		bool activeInHierarchy = model.activeInHierarchy;
		model.SetActive(true);
		Animator componentInChildren = model.GetComponentInChildren<Animator>();
		if (componentInChildren != null)
		{
			gameObject = global::UnityEngine.Object.Instantiate(componentInChildren.gameObject) as GameObject;
			if (gameObject != null)
			{
				foreach (object obj in gameObject.transform)
				{
					Transform transform = (Transform)obj;
					if (transform.name.ToLower() == "b_body")
					{
						transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
						break;
					}
				}
			}
		}
		model.SetActive(activeInHierarchy);
		return gameObject;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00043238 File Offset: 0x00041438
	private void method_6(GameObject gameObject_0, Transform transform_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		if (transform_0 == null)
		{
			transform_0 = this.method_1().transform;
		}
		gameObject_0.transform.parent = transform_0;
		gameObject_0.transform.localPosition = Vector3.zero;
		gameObject_0.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		gameObject_0.transform.localScale = Vector3.one;
		gameObject_0.SetActive(true);
		Component component = gameObject_0.GetComponent<MecanimEventEmitter>();
		if (component != null)
		{
			global::UnityEngine.Object.Destroy(component);
		}
		component = gameObject_0.GetComponent<BaseEventTriggerCtl>();
		if (component != null)
		{
			global::UnityEngine.Object.Destroy(component);
		}
		component = gameObject_0.GetComponent<Animator>();
		if (component != null)
		{
			global::UnityEngine.Object.Destroy(component);
		}
		gameObject_0.layer = MonoSingleton<GraphicsMgr>.Instance.method_22().method_6();
		SkinnedMeshRenderer componentInChildren = gameObject_0.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.material.shader = Shader.Find("Custom/BOL_Wpn_MaskReflect");
			componentInChildren.gameObject.layer = MonoSingleton<GraphicsMgr>.Instance.method_22().method_6();
		}
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00004B25 File Offset: 0x00002D25
	private void Start()
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance != null)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_0(new InventoryServiceWrapper.InventoryUpdateCallback(this.OnInventoryUpdate));
		}
		base.transform.parent = MonoSingleton<AppManager>.Instance.transform;
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00043350 File Offset: 0x00041550
	public void OnInventoryUpdate(InventoryServiceWrapper.InventoryUpdateType updateType)
	{
		if (!(this.m_inventoryAnimator == null) && !(this.m_inventoryAnimator.gameObject == null) && this.m_inventoryAnimator.gameObject.activeInHierarchy)
		{
			if (updateType != InventoryServiceWrapper.InventoryUpdateType.ItemUpdate)
			{
				if (updateType != InventoryServiceWrapper.InventoryUpdateType.FullUpdate)
				{
					if (updateType == InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
					{
						this.m_weaponResetPending = true;
						return;
					}
					if (updateType == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod)
					{
						this.m_classmodeResetPending = true;
						return;
					}
					return;
				}
			}
			this.m_weaponResetPending = true;
			this.m_classmodeResetPending = true;
			return;
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00004B59 File Offset: 0x00002D59
	public void OnShowInventoryView()
	{
		this.m_weaponResetPending = true;
		this.m_classmodeResetPending = true;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x000433C4 File Offset: 0x000415C4
	private void Update()
	{
		if (this.m_inventoryAnimator == null)
		{
			this.m_inventoryAnimator = base.gameObject.GetComponent<Animator>();
		}
		if (this.m_playerIkController == null)
		{
			this.m_playerIkController = base.gameObject.GetComponent<PlayerAnimationIkController>();
		}
		if (this.m_weaponResetPending)
		{
			this.m_weaponResetPending = !this.method_3();
		}
		if (this.m_classmodeResetPending)
		{
			this.m_classmodeResetPending = !this.method_2();
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00004B69 File Offset: 0x00002D69
	private void OnDestroy()
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance != null)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_1(new InventoryServiceWrapper.InventoryUpdateCallback(this.OnInventoryUpdate));
		}
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00043440 File Offset: 0x00041640
	private void OnEnable()
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null && localPlayer.m_avatarDna != null)
		{
			AvatarType avatarType = localPlayer.m_avatarDna.method_5();
			if (this.m_inventoryAnimator != null)
			{
				this.m_inventoryAnimator.SetFloat("fDefaultPose", (float)avatarType);
			}
		}
	}

	// Token: 0x040002B5 RID: 693
	private Animator m_inventoryAnimator;

	// Token: 0x040002B6 RID: 694
	private EntityPlayer m_entityPlayer;

	// Token: 0x040002B7 RID: 695
	private GameObject m_equipedWeapon;

	// Token: 0x040002B8 RID: 696
	private GameObject m_backWeapon;

	// Token: 0x040002B9 RID: 697
	private GameObject m_thighWeapon;

	// Token: 0x040002BA RID: 698
	private Skeleton m_inventoryPlayerSkeleton;

	// Token: 0x040002BB RID: 699
	private bool m_weaponResetPending;

	// Token: 0x040002BC RID: 700
	private GameObject m_equipedClassmode;

	// Token: 0x040002BD RID: 701
	private bool m_classmodeResetPending;

	// Token: 0x040002BE RID: 702
	private PlayerAnimationIkController m_playerIkController;
}
