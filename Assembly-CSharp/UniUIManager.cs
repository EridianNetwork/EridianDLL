using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using UnityEngine;
using XsdSettings;

// Token: 0x020006A2 RID: 1698
public class UniUIManager : GameUIManager, GInterface3
{
	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06002C0E RID: 11278 RVA: 0x0001CFE8 File Offset: 0x0001B1E8
	public GClass41 GClass41_0
	{
		get
		{
			return this._dropArea;
		}
	}

	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06002C0F RID: 11279 RVA: 0x0001CFF0 File Offset: 0x0001B1F0
	public Stage Stage_0
	{
		get
		{
			return this._curStage;
		}
	}

	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06002C10 RID: 11280 RVA: 0x0001CFF8 File Offset: 0x0001B1F8
	// (set) Token: 0x06002C11 RID: 11281 RVA: 0x0001D012 File Offset: 0x0001B212
	public override bool Boolean_2
	{
		get
		{
			return this._shortCutEnabled && !GClass58.GClass58_0.Boolean_0;
		}
		set
		{
			base.Boolean_2 = value;
		}
	}

	// Token: 0x06002C12 RID: 11282 RVA: 0x0001D01B File Offset: 0x0001B21B
	private void Awake()
	{
		base.gameObject.AddComponent<UniResourceManager>();
	}

	// Token: 0x06002C13 RID: 11283 RVA: 0x000D014C File Offset: 0x000CE34C
	protected override void vmethod_13()
	{
		this._viewCreator.method_1(typeof(PauseMenuView), typeof(uniPauseMenuView));
		this._viewCreator.method_1(typeof(LoginView), typeof(uniLoginView));
		this._viewCreator.method_1(typeof(ClassSelectView), typeof(uniClassSelectView));
		this._viewCreator.method_1(typeof(CharacterSelectView), typeof(uniCharacterSelectView));
		this._viewCreator.method_1(typeof(InstanceSelectView), typeof(uniInstanceSelectView));
		this._viewCreator.method_1(typeof(ClassCustomView), typeof(uniClassCustomView));
		this._viewCreator.method_1(typeof(HUDAimTargetView), typeof(uniHUDAimTargetView));
		this._viewCreator.method_1(typeof(HUDPlayerInfoView), typeof(uniHUDPlayerInfoView));
		this._viewCreator.method_1(typeof(HUDFeedbackView), typeof(uniHUDFeedbackView));
		this._viewCreator.method_1(typeof(HUDWorldTipsView), typeof(uniHUDWorldTipsView));
		this._viewCreator.method_1(typeof(EchoMessageView), typeof(uniEchoMessageView));
		this._viewCreator.method_1(typeof(HUDPvPInfoView), typeof(uniHUDPvPInfoView));
		this._viewCreator.method_1(typeof(HUDVictoryCondition), typeof(uniHUDVictoryCondition));
		this._viewCreator.method_1(typeof(HUDSkillStatusView), typeof(uniHUDSkillStatusView));
		this._viewCreator.method_1(typeof(InventoryView), typeof(uniInventoryView));
		this._viewCreator.method_1(typeof(CharInfoView), typeof(uniCharInfoView));
		this._viewCreator.method_1(typeof(NPCDialogView), typeof(uniNPCDialogView));
		this._viewCreator.method_1(typeof(QuestListView), typeof(uniQuestListView));
		this._viewCreator.method_1(typeof(QuestTrackView), typeof(uniQuestTrackView));
		this._viewCreator.method_1(typeof(QuestDetailView), typeof(uniQuestDetailView));
		this._viewCreator.method_1(typeof(HUDTeamMatePortraitView), typeof(uniTeamMatePortraitView));
		this._viewCreator.method_1(typeof(HUDWarningView), typeof(uniHUDWarningView));
		this._viewCreator.method_1(typeof(HUDWrapupView), typeof(uniHUDWrapupView));
		this._viewCreator.method_1(typeof(NPCInteractiveView), typeof(uniNPCInteractiveView));
		this._viewCreator.method_1(typeof(MatchMakingView), typeof(uniMatchMakingView));
		this._viewCreator.method_1(typeof(SkillTreeView), typeof(uniSkillTreeView));
		this._viewCreator.method_1(typeof(TownHUDView), typeof(uniTownHUDView));
		this._viewCreator.method_1(typeof(PopupMenuView), typeof(uniPopupMenuView));
		this._viewCreator.method_1(typeof(InstanceView), typeof(uniInstanceView));
		this._viewCreator.method_1(typeof(GroupView), typeof(uniGroupView));
		this._viewCreator.method_1(typeof(FriendView), typeof(uniFriendView));
		this._viewCreator.method_1(typeof(CurrencyUpdateView), typeof(uniCurrencyUpdateView));
		this._viewCreator.method_1(typeof(WeaponCraftView), typeof(uniWeaponCraftView));
		this._viewCreator.method_1(typeof(WeaponMeltView), typeof(uniWeaponMeltView));
		this._viewCreator.method_1(typeof(WeaponPreviewView), typeof(uniWeaponPreviewView));
		this._viewCreator.method_1(typeof(WorldMapSelectView), typeof(uniWorldMapSelectView));
		this._viewCreator.method_1(typeof(MiniMapView), typeof(uniMiniMapView));
		this._viewCreator.method_1(typeof(LargeMapView), typeof(uniLargeMapView));
		this._viewCreator.method_1(typeof(PvPModeSelectView), typeof(uniPvPModeSelectView));
		this._viewCreator.method_1(typeof(PvPRoomListView), typeof(uniPvPRoomListView));
		this._viewCreator.method_1(typeof(PvPCancelView), typeof(uniPvPCancelView));
		this._viewCreator.method_1(typeof(ChatView), typeof(uniChatView));
		this._viewCreator.method_1(typeof(GuildCreateView), typeof(uniGuildCreateView));
		this._viewCreator.method_1(typeof(GuildSearchView), typeof(uniGuildSearchView));
		this._viewCreator.method_1(typeof(GuildOptionView), typeof(uniGuildOptionView));
		this._viewCreator.method_1(typeof(PvPFlowView), typeof(uniPvPFlowView));
		this._viewCreator.method_1(typeof(PvPTipsView), typeof(uniPvPTipsView));
		this._viewCreator.method_1(typeof(ShopView), typeof(uniShopView));
		this._viewCreator.method_1(typeof(WareHouseView), typeof(uniWareHouseView));
		this._viewCreator.method_1(typeof(PlayerListView), typeof(uniPlayerListView));
		this._viewCreator.method_1(typeof(MailView), typeof(uniMailView));
		this._viewCreator.method_1(typeof(HUDPvPKillStampView), typeof(uniHUDPvPKillStampView));
		this._viewCreator.method_1(typeof(HUDTreasureBoxView), typeof(uniHUDTreasureBoxView));
		this._viewCreator.method_1(typeof(WeaponUpgradeView), typeof(uniWeaponUpgradeView));
		this._viewCreator.method_1(typeof(NewInstanceSelectView), typeof(uniNewInstanceSelectView));
		this._viewCreator.method_1(typeof(InstanceInfoView), typeof(uniInstanceInfoView));
		this._viewCreator.method_1(typeof(HUDCountDownView), typeof(uniHUDCountDown));
		this._viewCreator.method_1(typeof(SecondWindView), typeof(uniSecondWindView));
		this._viewCreator.method_1(typeof(TeamMateHpView), typeof(uniTeamMateHpView));
		this._viewCreator.method_1(typeof(AchievementBoardView), typeof(uniAchievementBoardView));
		this._viewCreator.method_1(typeof(AchievementPopUpView), typeof(uniAchievementPopUpView));
	}

	// Token: 0x06002C14 RID: 11284 RVA: 0x000D08BC File Offset: 0x000CEABC
	public override void vmethod_0()
	{
		base.vmethod_0();
		GClass52.GClass52_0.method_2("Movie", typeof(MovieClip));
		GClass52.GClass52_0.method_2("Panel", typeof(GClass51));
		GClass52.GClass52_0.method_2("Button", typeof(GClass25));
		GClass52.GClass52_0.method_2("TextInput", typeof(GClass50));
		GClass52.GClass52_0.method_2("Radio", typeof(GClass40));
		GClass52.GClass52_0.method_2("StatusIndicator", typeof(GClass49));
		GClass52.GClass52_0.method_2("ItemSlot", typeof(GClass44));
		GClass52.GClass52_0.method_2("DragTarget", typeof(GClass42));
		GClass52.GClass52_0.method_2("ScrollBar", typeof(GClass46));
		GClass52.GClass52_0.method_2("ImageLoader", typeof(GClass43));
		GClass61.GClass61_0.method_0(this);
		this.method_19();
		this.method_21();
		this.method_22();
		this.method_20();
		this.method_25();
		GameObject gameObject = new GameObject("DNAPortrait");
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.AddComponent<DNAPortrait>();
		this.vmethod_4(gameObject);
		this._uiTasks = new List<UniUIManager.UITask>();
		this.vmethod_6<HUDWarningView>();
	}

	// Token: 0x06002C15 RID: 11285 RVA: 0x0001D029 File Offset: 0x0001B229
	public override void vmethod_21(bool bool_0)
	{
		base.vmethod_21(bool_0);
		if (this._2DCamera != null)
		{
			this._2DCamera.SetActive(bool_0);
		}
	}

	// Token: 0x06002C16 RID: 11286 RVA: 0x0001D04C File Offset: 0x0001B24C
	public override bool vmethod_11()
	{
		return this._curStage != null && this._curStage.mouseOver != null && this._curStage.mouseOver.name != "StageMC";
	}

	// Token: 0x06002C17 RID: 11287 RVA: 0x0001D082 File Offset: 0x0001B282
	public override void vmethod_12(bool bool_0)
	{
		if (this._curStage != null)
		{
			this._curStage.visible = bool_0;
		}
	}

	// Token: 0x06002C18 RID: 11288 RVA: 0x0001D098 File Offset: 0x0001B298
	private void method_19()
	{
		this.method_29();
		this.method_30();
		this.method_26();
		base.StartCoroutine(this.vmethod_14());
		this.method_27();
	}

	// Token: 0x06002C19 RID: 11289 RVA: 0x000D0A30 File Offset: 0x000CEC30
	protected void method_20()
	{
		MovieClip movieClip = new MovieClip("CommonLib.swf:Blank_Fill");
		movieClip.name = "StageMC";
		movieClip.getChildAt(0).name = "StageMC";
		GClass20.GClass20_0.method_4(movieClip, "fps");
		DisplayObject displayObject = movieClip;
		float num = 0f;
		movieClip.y = num;
		displayObject.x = num;
		DisplayObject displayObject2 = movieClip;
		num = 256f;
		movieClip.scaleY = num;
		displayObject2.scaleX = num;
		movieClip.alpha = 0f;
	}

	// Token: 0x06002C1A RID: 11290 RVA: 0x000D0AA8 File Offset: 0x000CECA8
	protected void method_21()
	{
		this._CoverMask = new MovieClip("CommonLib.swf:black_bg");
		DisplayObject coverMask = this._CoverMask;
		float num = 512f;
		this._CoverMask.scaleY = num;
		coverMask.scaleX = num;
		DisplayObject coverMask2 = this._CoverMask;
		num = -256f;
		this._CoverMask.y = num;
		coverMask2.x = num;
		this._CoverMask.visible = false;
		GClass20.GClass20_0.method_4(this._CoverMask, "cover");
	}

	// Token: 0x06002C1B RID: 11291 RVA: 0x0001D0BF File Offset: 0x0001B2BF
	public override void vmethod_19(bool bool_0)
	{
		if (this._CoverMask != null)
		{
			this._CoverMask.visible = bool_0;
		}
	}

	// Token: 0x06002C1C RID: 11292 RVA: 0x000D0B24 File Offset: 0x000CED24
	protected void method_22()
	{
		MovieClip movieClip = new MovieClip("CommonLib.swf:HUDMask");
		DisplayObject displayObject = movieClip;
		float num = 512f;
		movieClip.scaleY = num;
		displayObject.scaleX = num;
		DisplayObject displayObject2 = movieClip;
		num = 0f;
		movieClip.y = num;
		displayObject2.x = num;
		this._HUDMask = new UniUIManager.HUDMaskPanel();
		this._HUDMask.method_0(movieClip);
		this.method_36(this._HUDMask);
	}

	// Token: 0x06002C1D RID: 11293 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_23()
	{
	}

	// Token: 0x06002C1E RID: 11294 RVA: 0x0001D0D5 File Offset: 0x0001B2D5
	public override void vmethod_18(bool bool_0)
	{
		base.vmethod_18(bool_0);
		if (!NPC_UIFlowController.smethod_0().Boolean_0 && !this.vmethod_5<InstanceView>().Boolean_1 && !this.vmethod_5<WorldMapSelectView>().Boolean_1)
		{
			this._HUDMask.method_6(bool_0);
			return;
		}
	}

	// Token: 0x06002C1F RID: 11295 RVA: 0x000D0B8C File Offset: 0x000CED8C
	protected void method_24()
	{
		GClass63 gclass = new GClass63();
		GClass60.GClass60_0.method_1(gclass);
	}

	// Token: 0x06002C20 RID: 11296 RVA: 0x000D0BAC File Offset: 0x000CEDAC
	protected void method_25()
	{
		this._dropArea = new GClass41();
		MovieClip movieClip = new MovieClip("CommonLib.swf:Blank_Fill");
		this._dropArea.method_0(movieClip);
		this.method_36(this._dropArea);
		DisplayObject displayObject = movieClip;
		float num = 0f;
		movieClip.y = num;
		displayObject.x = num;
		DisplayObject displayObject2 = movieClip;
		num = 256f;
		movieClip.scaleY = num;
		displayObject2.scaleX = num;
		movieClip.alpha = 0f;
	}

	// Token: 0x06002C21 RID: 11297 RVA: 0x000D0C1C File Offset: 0x000CEE1C
	protected void method_26()
	{
		if (this._FontSwapManager != null)
		{
			global::UnityEngine.Object.Destroy(this._FontSwapManager);
			this._FontSwapManager = null;
		}
		this._FontSwapManager = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/fonts/UnityFontManager")) as GameObject;
		this._FontSwapManager.transform.position = new Vector3(-1000f, -1000f, -1000f);
		this.vmethod_4(this._FontSwapManager);
	}

	// Token: 0x06002C22 RID: 11298 RVA: 0x0001D111 File Offset: 0x0001B311
	public override bool vmethod_9()
	{
		return this._SoundResourcesLoaded;
	}

	// Token: 0x06002C23 RID: 11299 RVA: 0x000D0C94 File Offset: 0x000CEE94
	public void method_27()
	{
		List<string> list = new List<string>();
		list.Clear();
		base.StartCoroutine(MonoSingleton<AssetBundleManager>.Instance.method_5(list, new FuncBase(this.method_28), null, false, 0));
	}

	// Token: 0x06002C24 RID: 11300 RVA: 0x0001D119 File Offset: 0x0001B319
	private void method_28(object object_0 = null)
	{
		MonoSingleton<UniResourceManager>.Instance.method_5();
	}

	// Token: 0x06002C25 RID: 11301 RVA: 0x000D0CD0 File Offset: 0x000CEED0
	public override IEnumerator vmethod_14()
	{
		if (_UISoundTrigger == null)
		{
			_UISoundTrigger = UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/UISoundTrigger")) as GameObject;
			_AudioTrigger = _UISoundTrigger.GetComponent<AudioEventTriggerCtl>();
			UnityEngine.Object.DontDestroyOnLoad(_UISoundTrigger);
		}
		if (_AudioTrigger == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "UI_uniSWF--> 2D Audio load failed!!");
		}
		yield return null;
		if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			IEnumerator UIAudioResourceLoader = ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_5("UIAudioResources", bool_0: true, string.Empty);
			while (UIAudioResourceLoader.MoveNext())
			{
				yield return UIAudioResourceLoader.Current;
			}
			_SoundResourcesLoaded = true;
		}
	}
	// Token: 0x06002C26 RID: 11302 RVA: 0x0001D125 File Offset: 0x0001B325
	public override void vmethod_15()
	{
		if (this._AudioTrigger != null && ComponentMonoSingleton<AudioSystem>.Instance != null)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.method_2(this._AudioTrigger.transform);
		}
	}

	// Token: 0x06002C27 RID: 11303 RVA: 0x000D0CEC File Offset: 0x000CEEEC
	protected void method_29()
	{
		MovieClipPlayer.enableScale9 = true;
		MovieClipPlayer.rootResourceLoader = MonoSingleton<UniResourceManager>.Instance.BadAssSWFResourceLoader_0;
		if (this._UIPreLoader != null)
		{
			global::UnityEngine.Object.Destroy(this._UIPreLoader);
			this._UIPreLoader = null;
		}
		this._UIPreLoader = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/UIPreLoader")) as GameObject;
		global::UnityEngine.Object.DontDestroyOnLoad(this._UIPreLoader);
		MonoSingleton<UniResourceManager>.Instance.BadAssSWFResourceLoader_0.AllowSceneLoader();
	}

	// Token: 0x06002C28 RID: 11304 RVA: 0x000D0D64 File Offset: 0x000CEF64
	protected void method_30()
	{
		if (this._2DCamera != null)
		{
			global::UnityEngine.Object.Destroy(this._2DCamera);
			this._2DCamera = null;
		}
		if (this._curStage != null)
		{
			this._curStage.removeEventListener(CEvent.RESIZE, new EventDispatcher.EventCallback(this.method_38));
			this._curStage = null;
		}
		GameObject gameObject = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/2DUICamera")) as GameObject;
		if (gameObject == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "UI_uniSWF--> 2D Camera prefab load failed!!");
			return;
		}
		this._2DCamera = gameObject;
		this._uniSWFCameraBehaviour = this._2DCamera.GetComponent<BadAssUICameraBehaviour>();
		this._curStage = this._uniSWFCameraBehaviour.stage;
		GClass20.GClass20_0.Stage_0 = this._curStage;
		this._curStage.addEventListener(CEvent.RESIZE, new EventDispatcher.EventCallback(this.method_38));
		this._uniSWFCameraBehaviour.camera.depth = 100f;
		this.vmethod_4(gameObject);
		GClass20.GClass20_0.method_5("world3D");
		GClass20.GClass20_0.method_5("fps");
		GClass20.GClass20_0.method_5("background");
		GClass20.GClass20_0.method_5("normal");
		GClass20.GClass20_0.method_5("front");
		DragManagerLayer.Instance.method_12();
		GClass20.GClass20_0.method_5("cover");
		GClass20.GClass20_0.method_5("top");
		this.method_24();
		GClass20.GClass20_0.method_5("cursor");
	}

	// Token: 0x06002C29 RID: 11305 RVA: 0x0001D151 File Offset: 0x0001B351
	public bool method_31(WidgetContainer gclass23_0)
	{
		if (this._curStage == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "UniSwf UI stage is null!!!");
			return false;
		}
		GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "normal");
		return true;
	}

	// Token: 0x06002C2A RID: 11306 RVA: 0x0001D17F File Offset: 0x0001B37F
	public bool method_32(WidgetContainer gclass23_0)
	{
		if (this._curStage != null)
		{
			GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "front");
			return true;
		}
		return false;
	}

	// Token: 0x06002C2B RID: 11307 RVA: 0x0001D1A2 File Offset: 0x0001B3A2
	public bool method_33(WidgetContainer gclass23_0)
	{
		if (this._curStage != null)
		{
			GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "top");
			return true;
		}
		return false;
	}

	// Token: 0x06002C2C RID: 11308 RVA: 0x0001D1C5 File Offset: 0x0001B3C5
	public bool method_34(WidgetContainer gclass23_0)
	{
		if (this._curStage != null)
		{
			GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "world3D");
			return true;
		}
		return false;
	}

	// Token: 0x06002C2D RID: 11309 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
	public bool method_35(WidgetContainer gclass23_0)
	{
		if (this._curStage != null)
		{
			GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "fps");
			return true;
		}
		return false;
	}

	// Token: 0x06002C2E RID: 11310 RVA: 0x0001D20B File Offset: 0x0001B40B
	public bool method_36(WidgetContainer gclass23_0)
	{
		if (this._curStage != null)
		{
			GClass20.GClass20_0.method_4(gclass23_0.DisplayObjectContainer_0, "background");
			return true;
		}
		return false;
	}

	// Token: 0x06002C2F RID: 11311 RVA: 0x0001D22E File Offset: 0x0001B42E
	public void method_37(WidgetContainer gclass23_0)
	{
		if (gclass23_0 == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "panel is null!!!");
			return;
		}
		gclass23_0.OnRemovedFromStage();
		GClass20.GClass20_0.method_7(gclass23_0.DisplayObjectContainer_0);
	}

	// Token: 0x06002C30 RID: 11312 RVA: 0x000D0EEC File Offset: 0x000CF0EC
	private void method_38(CEvent cevent_0)
	{
		GClass20.GClass20_0.OnScreenResize((float)Screen.width, (float)Screen.height);
		this._uniSWFCameraBehaviour.method_1(new Vector2(GClass20.GClass20_0.Single_0, GClass20.GClass20_0.Single_0), false);
		this.OnScreenResized(Screen.width, Screen.height);
	}

	// Token: 0x06002C31 RID: 11313 RVA: 0x0001D255 File Offset: 0x0001B455
	public void method_39()
	{
		this._uniSWFCameraBehaviour.method_1(new Vector2(GClass20.GClass20_0.Single_0, GClass20.GClass20_0.Single_0), true);
	}

	// Token: 0x06002C32 RID: 11314 RVA: 0x0001D27C File Offset: 0x0001B47C
	public override void imethod_0(string string_0)
	{
		if (this._AudioTrigger != null && this._AudioTrigger.method_1(string_0))
		{
			this._AudioTrigger.TriggerEventByName(string_0);
		}
	}

	// Token: 0x06002C33 RID: 11315 RVA: 0x0001D2A6 File Offset: 0x0001B4A6
	public void method_40(UniUIManager.UITask uitask_0)
	{
		if (!this._uiTasks.Contains(uitask_0))
		{
			this._uiTasks.Add(uitask_0);
		}
	}

	// Token: 0x06002C34 RID: 11316 RVA: 0x0001D2C2 File Offset: 0x0001B4C2
	public void method_41(UniUIManager.UITask uitask_0)
	{
		if (this._uiTasks.Contains(uitask_0))
		{
			this._uiTasks.Remove(uitask_0);
		}
	}

	// Token: 0x06002C35 RID: 11317 RVA: 0x000D0F44 File Offset: 0x000CF144
	public override void vmethod_22(string string_0, float float_0)
	{
		UniUIManager.UITask uitask = new UniUIManager.UITask(float_0, new Action<object>(this.vmethod_23), string_0);
		this.method_40(uitask);
	}

	// Token: 0x06002C36 RID: 11318 RVA: 0x000D0F70 File Offset: 0x000CF170
	public override void vmethod_23(object object_0)
	{
		string text = (string)object_0;
		if (text != null)
		{
			this.imethod_0(text);
		}
	}

	// Token: 0x06002C37 RID: 11319 RVA: 0x000D0F90 File Offset: 0x000CF190
	public void method_42(out float float_0, out float float_1)
	{
		float_0 = 0f;
		float_1 = 0f;
		if (GClass20.GClass20_0.Single_0 != 0f)
		{
			float_0 = (float)Screen.width * 0.5f / GClass20.GClass20_0.Single_0;
			float_1 = (float)Screen.height * 0.5f / GClass20.GClass20_0.Single_0;
		}
	}

	// Token: 0x06002C38 RID: 11320 RVA: 0x0001D2DF File Offset: 0x0001B4DF
	public override void OnLevelLoadingFinish()
	{
		base.OnLevelLoadingFinish();
		this.method_43();
		GClass58.GClass58_0.method_2();
		this.vmethod_5<HUDWarningView>().vmethod_6();
	}

	// Token: 0x06002C39 RID: 11321 RVA: 0x000D0FF0 File Offset: 0x000CF1F0
	private void method_43()
	{
		while (this._queMovieLoadedList.Count > 0)
		{
			UniUIManager.MovieLoadedCaller movieLoadedCaller = this._queMovieLoadedList.Dequeue();
			movieLoadedCaller.func(movieLoadedCaller.movie);
		}
	}

	// Token: 0x06002C3A RID: 11322 RVA: 0x0001D302 File Offset: 0x0001B502
	public override void vmethod_10(bool bool_0)
	{
		this._curStage.visible = bool_0;
	}

	// Token: 0x06002C3B RID: 11323 RVA: 0x000D1030 File Offset: 0x000CF230
	protected IEnumerator method_44(string string_0, string string_1, FuncLoad funcLoad_0)
	{
		yield return StartCoroutine(ns0.MonoSingleton<UniResourceManager>.Instance.method_12(string_0 + ":" + string_1));
		MovieClip movieClip = ns0.MonoSingleton<UniResourceManager>.Instance.method_11(string_0 + ":" + string_1);
		if (movieClip != null)
		{
			method_46(movieClip, funcLoad_0);
		}
		else
		{
			DebugUtils.LogError(LogCategory.GUI, "Can't create movieclip----" + string_0 + ":" + string_1);
		}
	}
	// Token: 0x06002C3C RID: 11324 RVA: 0x0001D310 File Offset: 0x0001B510
	public void method_45(string string_0, string string_1, FuncLoad funcLoad_0)
	{
		base.StartCoroutine(this.method_44(string_0, string_1, funcLoad_0));
	}

	// Token: 0x06002C3D RID: 11325 RVA: 0x000D1078 File Offset: 0x000CF278
	private void method_46(MovieClip movieClip_0, FuncLoad funcLoad_0)
	{
		if (movieClip_0 != null && funcLoad_0 != null)
		{
			if (this._bLevelLoading)
			{
				UniUIManager.MovieLoadedCaller movieLoadedCaller;
				movieLoadedCaller.movie = movieClip_0;
				movieLoadedCaller.func = funcLoad_0;
				this._queMovieLoadedList.Enqueue(movieLoadedCaller);
			}
			else
			{
				funcLoad_0(movieClip_0);
			}
			return;
		}
	}

	// Token: 0x06002C3E RID: 11326 RVA: 0x000D10BC File Offset: 0x000CF2BC
	public MovieClip method_47(string string_0, string string_1)
	{
		return MonoSingleton<UniResourceManager>.Instance.method_11(string_0 + ":" + string_1);
	}

	// Token: 0x06002C3F RID: 11327 RVA: 0x0001D322 File Offset: 0x0001B522
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (MonoSingleton<UFont2uniSWFGenerator>.Instance != null)
		{
			MonoSingleton<UFont2uniSWFGenerator>.Instance.method_0();
		}
	}

	// Token: 0x06002C40 RID: 11328 RVA: 0x0001D341 File Offset: 0x0001B541
	public override void vmethod_3()
	{
		if (MonoSingleton<UFont2uniSWFGenerator>.Instance != null)
		{
			MonoSingleton<UFont2uniSWFGenerator>.Instance.method_0();
		}
		MonoSingleton<AppManager>.Instance.method_13(true);
	}

	// Token: 0x06002C41 RID: 11329 RVA: 0x0001D365 File Offset: 0x0001B565
	public void method_48(string string_0)
	{
		MonoSingleton<UniResourceManager>.Instance.method_13(string_0);
	}

	// Token: 0x06002C42 RID: 11330 RVA: 0x000D10E4 File Offset: 0x000CF2E4
	private void Update()
	{
		if (!this.Boolean_1)
		{
			return;
		}
		this.vmethod_24();
		if (Input.GetMouseButtonDown(1))
		{
			if (DragManagerLayer.Instance.Boolean_0)
			{
				DragManagerLayer.Instance.method_3();
			}
			else if (this._curStage.mouseOver != null)
			{
				MouseEvent mouseEvent = new MouseEvent(MouseEvent.MOUSE_DOWN, true, false);
				mouseEvent.buttonId = 1;
				this._curStage.mouseOver.fireEvent(mouseEvent);
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			if (this.lastClickTime < 0f)
			{
				this.lastClickObj = this._curStage.mouseOver;
				this.lastClickTime = Time.realtimeSinceStartup;
			}
			else if (this._curStage.mouseOver != null && this._curStage.mouseOver == this.lastClickObj)
			{
				if (Time.realtimeSinceStartup - this.lastClickTime < 0.5f)
				{
					GClass56 gclass = new GClass56(GClass56.string_1, true, false);
					this._curStage.mouseOver.fireEvent(gclass);
				}
				else
				{
					this.lastClickTime = Time.realtimeSinceStartup;
				}
			}
			else
			{
				this.lastClickTime = Time.realtimeSinceStartup;
				this.lastClickObj = this._curStage.mouseOver;
			}
		}
		if (Time.realtimeSinceStartup - this.lastClickTime > 2f)
		{
			this.lastClickTime = -1f;
			this.lastClickObj = null;
		}
		if (Input.GetMouseButtonUp(1) && this._curStage.mouseOver != null)
		{
			MouseEvent mouseEvent2 = new MouseEvent(MouseEvent.CLICK, true, false);
			mouseEvent2.buttonId = 1;
			this._curStage.mouseOver.fireEvent(mouseEvent2);
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if ((double)axis != 0.0 && this._curStage.mouseOver != null)
		{
			GClass56 gclass2 = new GClass56(GClass56.string_0, true, false);
			gclass2.float_0 = axis;
			this._curStage.mouseOver.fireEvent(gclass2);
		}
		this.method_49();
		this.vmethod_16();
	}

	// Token: 0x06002C43 RID: 11331 RVA: 0x000D12BC File Offset: 0x000CF4BC
	private void method_49()
	{
		if (this._uiTasks.Count > 0)
		{
			List<UniUIManager.UITask> list = null;
			foreach (UniUIManager.UITask uitask in this._uiTasks)
			{
				uitask.method_0();
				if (uitask.method_2())
				{
					list = ((list != null) ? list : new List<UniUIManager.UITask>());
					uitask.method_1();
					list.Add(uitask);
				}
			}
			if (list != null)
			{
				foreach (UniUIManager.UITask uitask2 in list)
				{
					this._uiTasks.Remove(uitask2);
				}
			}
		}
	}

	// Token: 0x06002C44 RID: 11332 RVA: 0x0001D372 File Offset: 0x0001B572
	protected override bool vmethod_25()
	{
		if (DragManagerLayer.Instance.Boolean_0)
		{
			DragManagerLayer.Instance.method_3();
			return true;
		}
		if (GClass58.GClass58_0.Boolean_0)
		{
			GClass58.GClass58_0.method_2();
			return true;
		}
		return base.vmethod_25();
	}

	// Token: 0x04001F1C RID: 7964
	public const string URL_PREFAB_2DCAMERA = "UI_uniSWF/2DUICamera";

	// Token: 0x04001F1D RID: 7965
	public const string URL_PREFAB_PRELOADER = "UI_uniSWF/UIPreLoader";

	// Token: 0x04001F1E RID: 7966
	public const string URL_PREFAB_UISOUND_TRIG = "UI_uniSWF/UISoundTrigger";

	// Token: 0x04001F1F RID: 7967
	public const string URL_PREFAB_FONT_SWAP_MANAGER = "UI_uniSWF/fonts/UnityFontManager";

	// Token: 0x04001F20 RID: 7968
	private const int CAMERA_DEPTH = 100;

	// Token: 0x04001F21 RID: 7969
	private const string WORLD3D_LAYER_NAME = "world3D";

	// Token: 0x04001F22 RID: 7970
	private const string FPS_LAYER_NAME = "fps";

	// Token: 0x04001F23 RID: 7971
	private const string BACKGROUND_LAYER_NAME = "background";

	// Token: 0x04001F24 RID: 7972
	private const string NORMAL_LAYER_NAME = "normal";

	// Token: 0x04001F25 RID: 7973
	private const string FRONT_LAYER_NAME = "front";

	// Token: 0x04001F26 RID: 7974
	private const string COVER_LAYER_NAME = "cover";

	// Token: 0x04001F27 RID: 7975
	private const string TOP_LAYER_NAME = "top";

	// Token: 0x04001F28 RID: 7976
	public const string CURSOR_LAYER_NAME = "cursor";

	// Token: 0x04001F29 RID: 7977
	private const string AUDIO_RESOURCES_LIST_NAME = "UIAudioResources";

	// Token: 0x04001F2A RID: 7978
	private Stage _curStage;

	// Token: 0x04001F2B RID: 7979
	private BadAssUICameraBehaviour _uniSWFCameraBehaviour;

	// Token: 0x04001F2C RID: 7980
	private GameObject _2DCamera;

	// Token: 0x04001F2D RID: 7981
	private GameObject _UIPreLoader;

	// Token: 0x04001F2E RID: 7982
	private GameObject _FontSwapManager;

	// Token: 0x04001F2F RID: 7983
	private UniUIManager.HUDMaskPanel _HUDMask;

	// Token: 0x04001F30 RID: 7984
	private MovieClip _CoverMask;

	// Token: 0x04001F31 RID: 7985
	private GameObject _UISoundTrigger;

	// Token: 0x04001F32 RID: 7986
	private AudioEventTriggerCtl _AudioTrigger;

	// Token: 0x04001F33 RID: 7987
	private bool _SoundResourcesLoaded;

	// Token: 0x04001F34 RID: 7988
	private float lastClickTime = -1f;

	// Token: 0x04001F35 RID: 7989
	private DisplayObject lastClickObj;

	// Token: 0x04001F36 RID: 7990
	private GClass41 _dropArea;

	// Token: 0x04001F37 RID: 7991
	private List<UniUIManager.UITask> _uiTasks;

	// Token: 0x04001F38 RID: 7992
	private Queue<UniUIManager.MovieLoadedCaller> _queMovieLoadedList = new Queue<UniUIManager.MovieLoadedCaller>();

	// Token: 0x020006A3 RID: 1699
	public class UITask
	{
		// Token: 0x06002C45 RID: 11333 RVA: 0x0001D3AA File Offset: 0x0001B5AA
		public UITask(float float_0, Action<object> action_0 = null, object object_0 = null)
		{
			this.current = 0f;
			this.time = float_0;
			this.param = object_0;
			this.callbackWithParams = action_0;
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x0001D3D2 File Offset: 0x0001B5D2
		public void method_0()
		{
			this.current += Time.deltaTime;
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x0001D3E6 File Offset: 0x0001B5E6
		public void method_1()
		{
			if (this.callbackWithParams != null)
			{
				this.callbackWithParams(this.param);
			}
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x0001D401 File Offset: 0x0001B601
		public bool method_2()
		{
			return this.current >= this.time;
		}

		// Token: 0x04001F39 RID: 7993
		public Action<object> callbackWithParams;

		// Token: 0x04001F3A RID: 7994
		private float time;

		// Token: 0x04001F3B RID: 7995
		private float current;

		// Token: 0x04001F3C RID: 7996
		private object param;
	}

	// Token: 0x020006A4 RID: 1700
	public class UniSWFToolClass
	{
		// Token: 0x06002C4B RID: 11339 RVA: 0x0001D414 File Offset: 0x0001B614
		public static string smethod_0(float float_0, float float_1, int int_0 = 10)
		{
			return UniUIManager.UniSWFToolClass.smethod_1(Mathf.FloorToInt(float_0 * (float)int_0), Mathf.FloorToInt(float_1 * (float)int_0));
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x000D1638 File Offset: 0x000CF838
		public static string smethod_1(int int_0, int int_1)
		{
			int num = int_0 - int_1;
			if (num > 0)
			{
				return "up";
			}
			if (num < 0)
			{
				return "down";
			}
			return "same";
		}

		// Token: 0x06002C4D RID: 11341 RVA: 0x000D1664 File Offset: 0x000CF864
		public static string smethod_2(ItemDNA itemDNA_0)
		{
			string text = string.Empty;
			switch (itemDNA_0.m_type)
			{
			case ItemType.Weapon:
				text = Utility.smethod_5("_", itemDNA_0.method_6().method_1().ToString());
				break;
			case ItemType.Ammo:
				text = Utility.smethod_5("_", itemDNA_0.m_ammoType.ToString());
				break;
			}
			return Utility.smethod_5(itemDNA_0.m_type.ToString(), text);
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x0001D42D File Offset: 0x0001B62D
		public static Color smethod_3(ItemRarity itemRarity_0)
		{
			return UniUIManager.UniSWFToolClass._RarityColorMap[itemRarity_0];
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x000D16E8 File Offset: 0x000CF8E8
		public static Color smethod_4(WeaponRarity weaponRarity_0)
		{
			return UniUIManager.UniSWFToolClass._RarityColorMap[(ItemRarity)weaponRarity_0];
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x0001D43A File Offset: 0x0001B63A
		public static Color smethod_5(int int_0, int int_1)
		{
			if (int_0 >= int_1)
			{
				return Color.white;
			}
			return Color.red;
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x000D1704 File Offset: 0x000CF904
		public static int smethod_6(string string_0, string string_1)
		{
			int num = -1;
			if (string_0.Length > string_1.Length)
			{
				string text = string_0.Substring(0, string_1.Length);
				if (text == string_1)
				{
					num = Convert.ToInt32(string_0.Substring(string_1.Length, string_0.Length - string_1.Length));
				}
			}
			return num;
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x0001D44B File Offset: 0x0001B64B
		public static Color smethod_7(AttackInfo.ElementalType elementalType_0)
		{
			return UniUIManager.UniSWFToolClass.smethod_8(elementalType_0.ToString());
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x0001D45D File Offset: 0x0001B65D
		public static Color smethod_8(string string_0)
		{
			if (UniUIManager.UniSWFToolClass._ElementColorMap.ContainsKey(string_0))
			{
				return UniUIManager.UniSWFToolClass._ElementColorMap[string_0];
			}
			return Color.white;
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x0001D47D File Offset: 0x0001B67D
		public static Color smethod_9(ItemCardDisplayType itemCardDisplayType_0)
		{
			if (UniUIManager.UniSWFToolClass._WeaponAddAttColorMap.ContainsKey(itemCardDisplayType_0))
			{
				return UniUIManager.UniSWFToolClass._WeaponAddAttColorMap[itemCardDisplayType_0];
			}
			return Color.white;
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x0001D49D File Offset: 0x0001B69D
		public static Rect smethod_10(Rect rect_0)
		{
			return new Rect(rect_0.x, 1f - rect_0.y - rect_0.height, rect_0.width, rect_0.height);
		}

		// Token: 0x04001F3D RID: 7997
		public static Dictionary<ItemCardDisplayType, Color> _WeaponAddAttColorMap = new Dictionary<ItemCardDisplayType, Color>
		{
			{
				ItemCardDisplayType.ManufacturerWord,
				Color.white
			},
			{
				ItemCardDisplayType.ZoomWord,
				Color.white
			},
			{
				ItemCardDisplayType.ExtraSlotWord,
				new Color(0f, 0.984314f, 0.913725f)
			},
			{
				ItemCardDisplayType.CorrosiveWord,
				new Color(0f, 1f, 0.090196f)
			},
			{
				ItemCardDisplayType.ShockWord,
				new Color(0f, 0.709804f, 1f)
			},
			{
				ItemCardDisplayType.FireWord,
				new Color(1f, 0.435294f, 0f)
			}
		};

		// Token: 0x04001F3E RID: 7998
		public static Dictionary<string, Color> _ElementColorMap = new Dictionary<string, Color>
		{
			{
				"Normal",
				new Color(0.843137f, 0.945098f, 1f)
			},
			{
				AttackInfo.ElementalType.Explosive.ToString(),
				new Color(0.756862f, 0.007843f, 0.007843f)
			},
			{
				AttackInfo.ElementalType.Fire.ToString(),
				new Color(1f, 0.6f, 0f)
			},
			{
				AttackInfo.ElementalType.Shock.ToString(),
				new Color(0.190697f, 0.482352f, 0.803921f)
			},
			{
				AttackInfo.ElementalType.Corrosive.ToString(),
				new Color(0.007843f, 241f, 0.007843f)
			},
			{
				"Red",
				new Color(0.756862f, 0.007843f, 0.007843f)
			}
		};

		// Token: 0x04001F3F RID: 7999
		public static Dictionary<AttackInfo.ElementalType, string> _ElementFrameMap = new Dictionary<AttackInfo.ElementalType, string>
		{
			{
				AttackInfo.ElementalType.None,
				string.Empty
			},
			{
				AttackInfo.ElementalType.Explosive,
				"exp"
			},
			{
				AttackInfo.ElementalType.Fire,
				"fire"
			},
			{
				AttackInfo.ElementalType.Shock,
				"shock"
			},
			{
				AttackInfo.ElementalType.Corrosive,
				"corr"
			},
			{
				AttackInfo.ElementalType.Max,
				string.Empty
			}
		};

		// Token: 0x04001F40 RID: 8000
		public static string[] _BrandStringMap = new string[] { "vladof", "dahl", "maliwan", "atlas", "hyperion" };

		// Token: 0x04001F41 RID: 8001
		public static Dictionary<ItemRarity, Color> _RarityColorMap = new Dictionary<ItemRarity, Color>
		{
			{
				ItemRarity.Common,
				Color.white
			},
			{
				ItemRarity.Uncommon,
				new Color(0.235294f, 0.690196f, 0.309803f)
			},
			{
				ItemRarity.Rare,
				new Color(0.031372f, 0.57647f, 1f)
			},
			{
				ItemRarity.VeryRare,
				new Color(0.509803f, 0.12549f, 1f)
			},
			{
				ItemRarity.Epic,
				new Color(0.905882f, 0.435294f, 0.90196f)
			},
			{
				ItemRarity.MetaEpic,
				new Color(1f, 0.533333f, 0.16862f)
			},
			{
				ItemRarity.TOTAL,
				Color.white
			}
		};
	}

	// Token: 0x020006A5 RID: 1701
	private struct MovieLoadedCaller
	{
		// Token: 0x04001F42 RID: 8002
		public MovieClip movie;

		// Token: 0x04001F43 RID: 8003
		public FuncLoad func;
	}

	// Token: 0x020006A6 RID: 1702
	public class HUDMaskPanel : GClass51
	{
		// Token: 0x06002C57 RID: 11351 RVA: 0x000D1758 File Offset: 0x000CF958
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.addFrameScript("last", new EventDispatcher.EventCallback(this.method_5));
			this._rootMC.visible = false;
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x0001D4D6 File Offset: 0x0001B6D6
		protected void method_5(CEvent cevent_0)
		{
			this._rootMC.visible = false;
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x000D17A8 File Offset: 0x000CF9A8
		public void method_6(bool bool_0)
		{
			if (bool_0)
			{
				if (!this._rootMC.visible)
				{
					this._rootMC.gotoAndPlay("start");
				}
				else
				{
					this._rootMC.gotoAndStop(6);
				}
				this._rootMC.visible = true;
			}
			else
			{
				this._rootMC.gotoAndPlay("end");
			}
		}

		// Token: 0x04001F44 RID: 8004
		protected MovieClip _rootMC;
	}
}
