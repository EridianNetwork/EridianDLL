using System;
using System.Collections.Generic;
using System.IO;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000721 RID: 1825
public class NPC_UIFlowController
{
	// Token: 0x06003082 RID: 12418 RVA: 0x000DD75C File Offset: 0x000DB95C
	protected NPC_UIFlowController()
	{
		this._context = new NPC_UIFlowController.NPC_UI_Context();
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.None, new NPC_UIFlowController.NPCFlow_None());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.FunctionList, new NPC_UIFlowController.NPCFlow_ShowFunctionList());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.NpcDialog, new NPC_UIFlowController.NPCFlow_ShowDialog());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.Quest, new NPC_UIFlowController.NPCFlow_ShowQuestDetail());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.Crafting, new NPC_UIFlowController.NPCFlow_ShowCraftMenu());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.Melting, new NPC_UIFlowController.NPCFlow_Melting());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.Mail, new NPC_UIFlowController.NPCFlow_Mail());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.CreateGuild, new NPC_UIFlowController.NPCFlow_CreateGuild());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.DismissGuild, new NPC_UIFlowController.NPCFlow_None());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.QuitGuild, new NPC_UIFlowController.NPCFlow_None());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.WeaponShop, new NPC_UIFlowController.NPCFlow_WeaponShop());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.CoinShieldShop, new NPC_UIFlowController.NPCFlow_CoinShieldShop());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.ClassModeShop, new NPC_UIFlowController.NPCFlow_ClassModeShop());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.Warehouse, new NPC_UIFlowController.NPCFlow_Warehouse());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.WeaponUpgrade, new NPC_UIFlowController.NPCFlow_WeaponUpgrade());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.PvP, new NPC_UIFlowController.NPCFlow_PVP());
		this._UIFlowAcureClass.Add(NPC_UIFlowController.NPC_UIFlowState.OutfitShop, new NPC_UIFlowController.NPCFlow_OutfitShop());
	}

	// Token: 0x06003083 RID: 12419 RVA: 0x0001FABE File Offset: 0x0001DCBE
	public NPC_UIFlowController.NPC_UI_Context method_0()
	{
		return this._context;
	}

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06003084 RID: 12420 RVA: 0x0001FAC6 File Offset: 0x0001DCC6
	public bool Boolean_0
	{
		get
		{
			return this._bUIOnShow;
		}
	}

	// Token: 0x06003085 RID: 12421 RVA: 0x0001FACE File Offset: 0x0001DCCE
	public static NPC_UIFlowController smethod_0()
	{
		if (NPC_UIFlowController._instance == null)
		{
			NPC_UIFlowController._instance = new NPC_UIFlowController();
		}
		return NPC_UIFlowController._instance;
	}

	// Token: 0x06003086 RID: 12422 RVA: 0x000DD8B0 File Offset: 0x000DBAB0
	public void method_1(NPC_UIFlowController.NPCCameraAnimtion npccameraAnimtion_0)
	{
		string text = null;
		bool flag = false;
		switch (npccameraAnimtion_0)
		{
		case NPC_UIFlowController.NPCCameraAnimtion.None:
			return;
		case NPC_UIFlowController.NPCCameraAnimtion.Aside:
			text = "ANI_NPCCameraMotionFloasm";
			break;
		case NPC_UIFlowController.NPCCameraAnimtion.SideToMiddle:
			text = "ANI_NPCCameraMotionToMiddle";
			break;
		case NPC_UIFlowController.NPCCameraAnimtion.MiddleToSide:
			text = "ANI_NPCCameraMotionToMiddle";
			flag = true;
			break;
		}
		if (this._context.CurNPCCamera != null)
		{
			Animation component = this._context.CurNPCCamera.GetComponent<Animation>();
			if (component != null)
			{
				component[text].speed = ((!flag) ? 0.5f : (-0.5f));
				component[text].time = ((!flag) ? 0f : component[text].length);
				component[text].wrapMode = WrapMode.Once;
				component.Play(text);
			}
		}
	}

	// Token: 0x06003087 RID: 12423 RVA: 0x000DD974 File Offset: 0x000DBB74
	protected NPC_UIFlowController.NPC_FlowBase method_2(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
	{
		NPC_UIFlowController.NPC_FlowBase npc_FlowBase = null;
		this._UIFlowAcureClass.TryGetValue(npc_UIFlowState_0, out npc_FlowBase);
		return npc_FlowBase;
	}

	// Token: 0x06003088 RID: 12424 RVA: 0x000DD994 File Offset: 0x000DBB94
	public void method_3(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
	{
		try
		{
			if (this._curState != npc_UIFlowState_0)
			{
				if (this._curState == NPC_UIFlowController.NPC_UIFlowState.None && npc_UIFlowState_0 != NPC_UIFlowController.NPC_UIFlowState.None)
				{
					this.method_4();
				}
				if (this._curState != NPC_UIFlowController.NPC_UIFlowState.None && npc_UIFlowState_0 == NPC_UIFlowController.NPC_UIFlowState.None)
				{
					this.method_5();
				}
				this.method_2(npc_UIFlowState_0).vmethod_0(this._curState);
				this.method_2(this._curState).vmethod_1();
				this._curState = npc_UIFlowState_0;
			}
		}
		catch (Exception ex)
		{
			try
			{
				File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "borderlands_crash_log.txt"), string.Concat(new string[]
				{
					DateTime.Now.ToString(),
					" method_3(",
					npc_UIFlowState_0.ToString(),
					") from ",
					this._curState.ToString(),
					" failed:\n",
					ex.ToString(),
					"\n\n"
				}));
			}
			catch
			{
			}
		}
	}

	// Token: 0x06003089 RID: 12425 RVA: 0x000DDA9C File Offset: 0x000DBC9C
	private void method_4()
	{
		if (this._context.CurNPCCamera != null)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().Camera_0 != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().Camera_0.gameObject.SetActive(false);
			}
			this._context.CurNPCCamera.SetActive(true);
		}
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (entityPlayer)
		{
			entityPlayer.method_59(true);
		}
		this._bUIOnShow = true;
		this._callbackOnUIShowOff(true);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
		MonoSingleton<AppManager>.Instance.method_0().method_15(true, "NPC_UIFlowController");
	}

	// Token: 0x0600308A RID: 12426 RVA: 0x000DDB5C File Offset: 0x000DBD5C
	private void method_5()
	{
		GameUIManager gameUIManager = MonoSingleton<AppManager>.Instance.method_0();
		if (this._context.CurNPCCamera != null)
		{
			this._context.CurNPCCamera.SetActive(false);
			if (gameUIManager != null && gameUIManager.Camera_0 != null)
			{
				gameUIManager.Camera_0.gameObject.SetActive(true);
			}
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			EntityPlayer entityPlayer = localPlayer.GetEntity() as EntityPlayer;
			if (entityPlayer)
			{
				entityPlayer.method_59(false);
			}
		}
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_27();
		}
		if (gameUIManager != null)
		{
			gameUIManager.method_15(false, "NPC_UIFlowController");
		}
		this._bUIOnShow = false;
		if (this._callbackOnUIShowOff != null)
		{
			this._callbackOnUIShowOff(false);
		}
		if (gameUIManager != null)
		{
			gameUIManager.Boolean_2 = true;
		}
	}

	// Token: 0x0600308B RID: 12427 RVA: 0x000DDC48 File Offset: 0x000DBE48
	public void method_6(bool bool_0 = true)
	{
		WeaponStationShim.EnsureCreated();
		GameObject gameObject = GameObject.Find("WeaponcraftingCameraRoot");
		if (gameObject == null)
		{
			return;
		}
		string text = ((!bool_0) ? "Base Layer.ANI_WeaponMeltingCameraMotion" : "Base Layer.ANI_WeaponcraftingCameraMotion");
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		if (componentInChildren == null)
		{
			return;
		}
		componentInChildren.enabled = true;
		if (gameObject != null)
		{
			Camera[] componentsInChildren = gameObject.GetComponentsInChildren<Camera>(true);
			if (componentsInChildren != null)
			{
				foreach (Camera camera in componentsInChildren)
				{
					if (camera.name == "WeaponcraftingCamera")
					{
						this._context.CraftCamera = camera.gameObject;
					}
				}
			}
		}
		if (this._context.CraftCamera != null)
		{
			this._context.CraftCamera.SetActive(true);
			componentInChildren.CrossFade(text, 1f);
		}
	}

	// Token: 0x0600308C RID: 12428 RVA: 0x000DDD20 File Offset: 0x000DBF20
	public void method_7(bool bool_0 = true)
	{
		if (this._context.CraftCamera != null)
		{
			GameObject gameObject = GameObject.Find("WeaponcraftingCameraRoot");
			if (gameObject == null)
			{
				return;
			}
			Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
			if (componentInChildren == null)
			{
				return;
			}
			componentInChildren.CrossFade("Base Layer.Idle", 0f);
			this._context.CraftCamera.SetActive(false);
		}
	}

	// Token: 0x0600308D RID: 12429 RVA: 0x000DDD88 File Offset: 0x000DBF88
	public void method_8()
	{
		WeaponStationShim.EnsureCreated();
		Camera[] array = Resources.FindObjectsOfTypeAll(typeof(Camera)) as Camera[];
		if (array != null)
		{
			foreach (Camera camera in array)
			{
				if (camera.name == "WeaponupgradeCamera")
				{
					this._context.UpgradeCamera = camera.gameObject;
				}
			}
		}
		if (this._context.UpgradeCamera != null)
		{
			this._context.UpgradeCamera.SetActive(true);
		}
	}

	// Token: 0x0600308E RID: 12430 RVA: 0x0001FAE6 File Offset: 0x0001DCE6
	public void method_9()
	{
		if (this._context.UpgradeCamera != null)
		{
			this._context.UpgradeCamera.SetActive(false);
		}
	}

	// Token: 0x0600308F RID: 12431 RVA: 0x0001FB0C File Offset: 0x0001DD0C
	public void method_10(NPC_UIFlowController.onUIShowOff onUIShowOff_0)
	{
		this._callbackOnUIShowOff = (NPC_UIFlowController.onUIShowOff)Delegate.Combine(this._callbackOnUIShowOff, onUIShowOff_0);
	}

	// Token: 0x06003090 RID: 12432 RVA: 0x0001FB25 File Offset: 0x0001DD25
	public void method_11(NPC_UIFlowController.onUIShowOff onUIShowOff_0)
	{
		this._callbackOnUIShowOff = (NPC_UIFlowController.onUIShowOff)Delegate.Remove(this._callbackOnUIShowOff, onUIShowOff_0);
	}

	// Token: 0x040021B7 RID: 8631
	protected const string NPC_CAMERA_ANIMATION_ASIDE = "ANI_NPCCameraMotionFloasm";

	// Token: 0x040021B8 RID: 8632
	protected const string NPC_CAMERA_ANIMATION_TOMIDDLE = "ANI_NPCCameraMotionToMiddle";

	// Token: 0x040021B9 RID: 8633
	protected NPC_UIFlowController.NPC_UI_Context _context;

	// Token: 0x040021BA RID: 8634
	private static NPC_UIFlowController _instance;

	// Token: 0x040021BB RID: 8635
	protected Dictionary<NPC_UIFlowController.NPC_UIFlowState, NPC_UIFlowController.NPC_FlowBase> _UIFlowAcureClass = new Dictionary<NPC_UIFlowController.NPC_UIFlowState, NPC_UIFlowController.NPC_FlowBase>();

	// Token: 0x040021BC RID: 8636
	protected NPC_UIFlowController.NPC_UIFlowState _curState;

	// Token: 0x040021BD RID: 8637
	protected bool _bUIOnShow;

	// Token: 0x040021BE RID: 8638
	protected NPC_UIFlowController.onUIShowOff _callbackOnUIShowOff;

	// Token: 0x040021BF RID: 8639
	protected int _iRefCount;

	// Token: 0x02000722 RID: 1826
	public enum NPC_UIFlowState
	{
		// Token: 0x040021C1 RID: 8641
		None,
		// Token: 0x040021C2 RID: 8642
		FunctionList,
		// Token: 0x040021C3 RID: 8643
		NpcDialog,
		// Token: 0x040021C4 RID: 8644
		Quest,
		// Token: 0x040021C5 RID: 8645
		Crafting,
		// Token: 0x040021C6 RID: 8646
		Melting,
		// Token: 0x040021C7 RID: 8647
		Mail,
		// Token: 0x040021C8 RID: 8648
		WeaponShop,
		// Token: 0x040021C9 RID: 8649
		CoinShieldShop,
		// Token: 0x040021CA RID: 8650
		ClassModeShop,
		// Token: 0x040021CB RID: 8651
		Warehouse,
		// Token: 0x040021CC RID: 8652
		CreateGuild,
		// Token: 0x040021CD RID: 8653
		DismissGuild,
		// Token: 0x040021CE RID: 8654
		QuitGuild,
		// Token: 0x040021CF RID: 8655
		WeaponUpgrade,
		// Token: 0x040021D0 RID: 8656
		PvP,
		// Token: 0x040021D1 RID: 8657
		OutfitShop
	}

	// Token: 0x02000723 RID: 1827
	public enum NPCCameraAnimtion
	{
		// Token: 0x040021D3 RID: 8659
		None,
		// Token: 0x040021D4 RID: 8660
		Aside,
		// Token: 0x040021D5 RID: 8661
		SideToMiddle,
		// Token: 0x040021D6 RID: 8662
		MiddleToSide
	}

	// Token: 0x02000724 RID: 1828
	public class NPC_UI_Context
	{
		// Token: 0x040021D7 RID: 8663
		public GameObject CurNPCCamera;

		// Token: 0x040021D8 RID: 8664
		public GameObject CraftCamera;

		// Token: 0x040021D9 RID: 8665
		public GameObject UpgradeCamera;

		// Token: 0x040021DA RID: 8666
		public TownNPCAnimationManagerFSM CurNPCAnimaMgr;

		// Token: 0x040021DB RID: 8667
		public global::XsdSettings.TownNpc CurNPCSetting;

		// Token: 0x040021DC RID: 8668
		public Quest onShowQuest;

		// Token: 0x040021DD RID: 8669
		public QuestProgress onShowQuestProgress;
	}

	// Token: 0x02000725 RID: 1829
	public class NPC_FlowBase
	{
		// Token: 0x06003093 RID: 12435 RVA: 0x0001FB3E File Offset: 0x0001DD3E
		public virtual void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			if (npc_UIFlowState_0 == NPC_UIFlowController.NPC_UIFlowState.None)
			{
				NPC_UIFlowController.smethod_0().method_1(NPC_UIFlowController.NPCCameraAnimtion.Aside);
			}
			this._previousStep = npc_UIFlowState_0;
		}

		// Token: 0x06003094 RID: 12436 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_1()
		{
		}

		// Token: 0x040021DE RID: 8670
		protected NPC_UIFlowController.NPC_UIFlowState _previousStep;
	}

	// Token: 0x02000726 RID: 1830
	public class NPCFlow_None : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x06003096 RID: 12438 RVA: 0x0001FB5D File Offset: 0x0001DD5D
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
		}
	}

	// Token: 0x02000727 RID: 1831
	public class NPCFlow_ShowFunctionList : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x06003098 RID: 12440 RVA: 0x000DDE10 File Offset: 0x000DC010
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			if (npc_UIFlowState_0 == NPC_UIFlowController.NPC_UIFlowState.NpcDialog)
			{
				NPC_UIFlowController.smethod_0().method_1(NPC_UIFlowController.NPCCameraAnimtion.MiddleToSide);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCInteractiveView>().vmethod_5(NPC_UIFlowController.smethod_0().method_0().CurNPCSetting);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCInteractiveView>().Boolean_1 = true;
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x0001FB66 File Offset: 0x0001DD66
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCInteractiveView>().Boolean_1 = false;
		}
	}

	// Token: 0x02000728 RID: 1832
	public class NPCFlow_ShowDialog : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x0600309B RID: 12443 RVA: 0x000DDE6C File Offset: 0x000DC06C
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			Quest onShowQuest = NPC_UIFlowController.smethod_0().method_0().onShowQuest;
			QuestProgress onShowQuestProgress = NPC_UIFlowController.smethod_0().method_0().onShowQuestProgress;
			if (onShowQuest != null && onShowQuestProgress != null)
			{
				string[] array = null;
				switch (onShowQuestProgress.mStatus)
				{
				case QuestState.Available:
					array = onShowQuest.mAvailableDialog;
					break;
				case QuestState.InProgress:
					array = onShowQuest.mInProgressDialog;
					break;
				case QuestState.Completed:
					array = onShowQuest.mCompletedDialog;
					break;
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCDialogView>().Boolean_1 = true;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCDialogView>().vmethod_6(array);
				NPC_UIFlowController.smethod_0().method_1(NPC_UIFlowController.NPCCameraAnimtion.SideToMiddle);
				return;
			}
		}

		// Token: 0x0600309C RID: 12444 RVA: 0x0001FB83 File Offset: 0x0001DD83
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NPCDialogView>().Boolean_1 = false;
		}
	}

	// Token: 0x02000729 RID: 1833
	public class NPCFlow_ShowQuestDetail : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x0600309E RID: 12446 RVA: 0x000DDF14 File Offset: 0x000DC114
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			Quest onShowQuest = NPC_UIFlowController.smethod_0().method_0().onShowQuest;
			QuestProgress onShowQuestProgress = NPC_UIFlowController.smethod_0().method_0().onShowQuestProgress;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestDetailView>().vmethod_5(onShowQuest, onShowQuestProgress);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestDetailView>().Boolean_1 = true;
			if (npc_UIFlowState_0 != NPC_UIFlowController.NPC_UIFlowState.FunctionList)
			{
				NPC_UIFlowController.smethod_0().method_1(NPC_UIFlowController.NPCCameraAnimtion.MiddleToSide);
			}
		}

		// Token: 0x0600309F RID: 12447 RVA: 0x0001FBA0 File Offset: 0x0001DDA0
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestDetailView>().Boolean_1 = false;
		}
	}

	// Token: 0x0200072A RID: 1834
	public class NPCFlow_ShowCraftMenu : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030A1 RID: 12449 RVA: 0x000DDF84 File Offset: 0x000DC184
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			NPC_UIFlowController.smethod_0().method_6(true);
			if (NPC_UIFlowController.smethod_0()._context.CurNPCCamera != null)
			{
				NPC_UIFlowController.smethod_0()._context.CurNPCCamera.SetActive(false);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponCraftView>().Boolean_1 = true;
		}

		// Token: 0x060030A2 RID: 12450 RVA: 0x0001FBBD File Offset: 0x0001DDBD
		public override void vmethod_1()
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponCraftView>().Boolean_1 = false;
			NPC_UIFlowController.smethod_0().method_7(true);
			base.vmethod_1();
		}
	}

	// Token: 0x0200072B RID: 1835
	public class NPCFlow_Melting : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030A4 RID: 12452 RVA: 0x000DDFE4 File Offset: 0x000DC1E4
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			NPC_UIFlowController.smethod_0().method_6(false);
			if (NPC_UIFlowController.smethod_0()._context.CurNPCCamera != null)
			{
				NPC_UIFlowController.smethod_0()._context.CurNPCCamera.SetActive(false);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponMeltView>().Boolean_1 = true;
		}

		// Token: 0x060030A5 RID: 12453 RVA: 0x0001FBE5 File Offset: 0x0001DDE5
		public override void vmethod_1()
		{
			base.vmethod_1();
			NPC_UIFlowController.smethod_0().method_7(false);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponMeltView>().Boolean_1 = false;
		}
	}

	// Token: 0x0200072C RID: 1836
	public class NPCFlow_CreateGuild : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030A7 RID: 12455 RVA: 0x0001FC0D File Offset: 0x0001DE0D
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildCreateView>().Boolean_1 = true;
		}

		// Token: 0x060030A8 RID: 12456 RVA: 0x0001FC2B File Offset: 0x0001DE2B
		public override void vmethod_1()
		{
			base.vmethod_1();
		}
	}

	// Token: 0x0200072D RID: 1837
	public class NPCFlow_PVP : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030AA RID: 12458 RVA: 0x0001FC33 File Offset: 0x0001DE33
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = true;
		}

		// Token: 0x060030AB RID: 12459 RVA: 0x0001FC2B File Offset: 0x0001DE2B
		public override void vmethod_1()
		{
			base.vmethod_1();
		}
	}

	// Token: 0x0200072E RID: 1838
	public class NPCFlow_WeaponUpgrade : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030AD RID: 12461 RVA: 0x000DE044 File Offset: 0x000DC244
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			NPC_UIFlowController.smethod_0().method_8();
			if (NPC_UIFlowController.smethod_0()._context.CurNPCCamera != null)
			{
				NPC_UIFlowController.smethod_0()._context.CurNPCCamera.SetActive(false);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponUpgradeView>().Boolean_1 = true;
		}

		// Token: 0x060030AE RID: 12462 RVA: 0x0001FC51 File Offset: 0x0001DE51
		public override void vmethod_1()
		{
			base.vmethod_1();
			NPC_UIFlowController.smethod_0().method_9();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponUpgradeView>().Boolean_1 = false;
		}
	}

	// Token: 0x0200072F RID: 1839
	public class NPCFlow_WeaponShop : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030B0 RID: 12464 RVA: 0x000DE0A4 File Offset: 0x000DC2A4
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = true;
			global::XsdSettings.TownNpc curNPCSetting = NPC_UIFlowController.smethod_0()._context.CurNPCSetting;
			if (curNPCSetting != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().method_3(curNPCSetting.m_WeaponShopID);
			}
		}

		// Token: 0x060030B1 RID: 12465 RVA: 0x0001FC78 File Offset: 0x0001DE78
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = false;
		}
	}

	// Token: 0x02000730 RID: 1840
	public class NPCFlow_CoinShieldShop : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030B3 RID: 12467 RVA: 0x000DE0FC File Offset: 0x000DC2FC
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = true;
			global::XsdSettings.TownNpc curNPCSetting = NPC_UIFlowController.smethod_0()._context.CurNPCSetting;
			if (curNPCSetting != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().method_3(curNPCSetting.m_CoinShieldShopID);
			}
		}

		// Token: 0x060030B4 RID: 12468 RVA: 0x0001FC78 File Offset: 0x0001DE78
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = false;
		}
	}

	// Token: 0x02000731 RID: 1841
	public class NPCFlow_ClassModeShop : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030B6 RID: 12470 RVA: 0x000DE154 File Offset: 0x000DC354
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = true;
			global::XsdSettings.TownNpc curNPCSetting = NPC_UIFlowController.smethod_0()._context.CurNPCSetting;
			if (curNPCSetting != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().method_3(curNPCSetting.m_ClassModeShopID);
			}
		}

		// Token: 0x060030B7 RID: 12471 RVA: 0x0001FC78 File Offset: 0x0001DE78
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = false;
		}
	}

	// Token: 0x02000732 RID: 1842
	public class NPCFlow_Warehouse : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030B9 RID: 12473 RVA: 0x0001FC95 File Offset: 0x0001DE95
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WareHouseView>().Boolean_1 = true;
		}

		// Token: 0x060030BA RID: 12474 RVA: 0x0001FC2B File Offset: 0x0001DE2B
		public override void vmethod_1()
		{
			base.vmethod_1();
		}
	}

	// Token: 0x02000733 RID: 1843
	public class NPCFlow_Mail : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030BC RID: 12476 RVA: 0x0001FCB3 File Offset: 0x0001DEB3
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MailView>().Boolean_1 = true;
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x0001FC2B File Offset: 0x0001DE2B
		public override void vmethod_1()
		{
			base.vmethod_1();
		}
	}

	// Token: 0x02000734 RID: 1844
	// (Invoke) Token: 0x060030BF RID: 12479
	public delegate void onUIShowOff(bool bShow);

	// Token: 0x02000735 RID: 1845
	public class NPCFlow_OutfitShop : NPC_UIFlowController.NPC_FlowBase
	{
		// Token: 0x060030C2 RID: 12482 RVA: 0x000DE1AC File Offset: 0x000DC3AC
		public override void vmethod_0(NPC_UIFlowController.NPC_UIFlowState npc_UIFlowState_0)
		{
			base.vmethod_0(npc_UIFlowState_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = true;
			global::XsdSettings.TownNpc curNPCSetting = NPC_UIFlowController.smethod_0()._context.CurNPCSetting;
			if (curNPCSetting != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().method_3(curNPCSetting.m_OutfitShopID);
			}
		}

		// Token: 0x060030C3 RID: 12483 RVA: 0x0001FC78 File Offset: 0x0001DE78
		public override void vmethod_1()
		{
			base.vmethod_1();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ShopView>().Boolean_1 = false;
		}
	}
}
