using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200066E RID: 1646
public class GameUIManager : MonoBehaviour
{
	// Token: 0x06002992 RID: 10642 RVA: 0x000C3DE8 File Offset: 0x000C1FE8
	public GameUIManager()
	{
		this._InputReader = new GameUIManager.EngineUIInputReader(this);
	}

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06002993 RID: 10643 RVA: 0x0001B456 File Offset: 0x00019656
	// (set) Token: 0x06002994 RID: 10644 RVA: 0x0001B45E File Offset: 0x0001965E
	public bool Boolean_0
	{
		get
		{
			return this.m_bIsMatchMaking;
		}
		set
		{
			this.m_bIsMatchMaking = value;
		}
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06002995 RID: 10645 RVA: 0x0001B467 File Offset: 0x00019667
	// (set) Token: 0x06002996 RID: 10646 RVA: 0x0001B46F File Offset: 0x0001966F
	public Camera Camera_0
	{
		get
		{
			return this._gameCamera;
		}
		set
		{
			this._gameCamera = value;
		}
	}

	// Token: 0x06002997 RID: 10647 RVA: 0x000C3E88 File Offset: 0x000C2088
	public virtual void vmethod_0()
	{
		this.method_2();
		if (this._UIRootObject == null)
		{
			this._UIRootObject = new GameObject("UIRootObject");
			global::UnityEngine.Object.DontDestroyOnLoad(this._UIRootObject);
		}
		MonoSingleton<InputManager>.Instance.method_0(this._InputReader);
	}

	// Token: 0x06002998 RID: 10648 RVA: 0x0001B478 File Offset: 0x00019678
	public virtual void vmethod_1()
	{
		this.vmethod_2();
		if (this._UIRootObject != null)
		{
			global::UnityEngine.Object.DestroyObject(this._UIRootObject);
		}
	}

	// Token: 0x06002999 RID: 10649 RVA: 0x000C3ED4 File Offset: 0x000C20D4
	public virtual void vmethod_2()
	{
		foreach (KeyValuePair<Type, BaseView> keyValuePair in this._viewCreator.method_0())
		{
			keyValuePair.Value.vmethod_3();
		}
		this._viewCreator.method_0().Clear();
	}

	// Token: 0x0600299A RID: 10650 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_3()
	{
	}

	// Token: 0x0600299B RID: 10651 RVA: 0x000C3F40 File Offset: 0x000C2140
	public virtual void OnScreenResized(int width, int height)
	{
		foreach (KeyValuePair<Type, BaseView> keyValuePair in this._viewCreator.method_0())
		{
			if (keyValuePair.Value.Boolean_0)
			{
				keyValuePair.Value.OnScreenResized();
			}
		}
	}

	// Token: 0x0600299C RID: 10652 RVA: 0x0001B499 File Offset: 0x00019699
	public virtual void OnLevelLoadingFinish()
	{
		this._bLevelLoading = false;
		this.method_15(this._bLevelLoading, "UIManager");
		this._arrMouseFree.Clear();
	}

	// Token: 0x0600299D RID: 10653 RVA: 0x0001B4BE File Offset: 0x000196BE
	public virtual void OnLevelLoadingStart()
	{
		this._bLevelLoading = true;
		this.method_15(this._bLevelLoading, "UIManager");
	}

	// Token: 0x0600299E RID: 10654 RVA: 0x0001B4D8 File Offset: 0x000196D8
	public virtual void vmethod_4(GameObject gameObject_0)
	{
		if (gameObject_0 != null)
		{
			gameObject_0.transform.parent = this._UIRootObject.transform;
		}
	}

	// Token: 0x0600299F RID: 10655 RVA: 0x0001B4F9 File Offset: 0x000196F9
	public virtual T vmethod_5<T>() where T : BaseView
	{
		return this._viewCreator.vmethod_0(typeof(T)) as T;
	}

	// Token: 0x060029A0 RID: 10656 RVA: 0x000C3FAC File Offset: 0x000C21AC
	public virtual T vmethod_6<T>() where T : BaseView
	{
		T t = this._viewCreator.vmethod_0(typeof(T)) as T;
		if (t != (T)((object)null))
		{
			t.vmethod_2();
			t.method_1(new ViewVisbleChangeFunc(this.OnViewVisibleChange));
		}
		return t;
	}

	// Token: 0x060029A1 RID: 10657 RVA: 0x000C4014 File Offset: 0x000C2214
	public virtual T vmethod_7<T>() where T : BaseView
	{
		T t = this._viewCreator.vmethod_0(typeof(T)) as T;
		if (t != (T)((object)null))
		{
			t.vmethod_3();
			t.method_2(new ViewVisbleChangeFunc(this.OnViewVisibleChange));
		}
		return t;
	}

	// Token: 0x060029A2 RID: 10658 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8()
	{
	}

	// Token: 0x060029A3 RID: 10659 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_9()
	{
		return false;
	}

	// Token: 0x060029A4 RID: 10660 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_10(bool bool_0)
	{
	}

	// Token: 0x060029A5 RID: 10661 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_11()
	{
		return false;
	}

	// Token: 0x060029A6 RID: 10662 RVA: 0x0001B51A File Offset: 0x0001971A
	public void method_0(GameUIManager.ViewUpdateCB viewUpdateCB_0, bool bool_0 = false)
	{
		if (bool_0)
		{
			this._arrNextUpdate.Add(viewUpdateCB_0);
		}
		else
		{
			this._funcUpdateList = (GameUIManager.ViewUpdateCB)Delegate.Combine(this._funcUpdateList, viewUpdateCB_0);
		}
	}

	// Token: 0x060029A7 RID: 10663 RVA: 0x0001B544 File Offset: 0x00019744
	public void method_1(GameUIManager.ViewUpdateCB viewUpdateCB_0)
	{
		this._funcUpdateList = (GameUIManager.ViewUpdateCB)Delegate.Remove(this._funcUpdateList, viewUpdateCB_0);
	}

	// Token: 0x060029A8 RID: 10664 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_12(bool bool_0)
	{
	}

	// Token: 0x060029A9 RID: 10665 RVA: 0x000C407C File Offset: 0x000C227C
	private void method_2()
	{
		this._viewCreator.method_1(typeof(PauseMenuView), typeof(PauseMenuView));
		this._viewCreator.method_1(typeof(LoginView), typeof(LoginView));
		this._viewCreator.method_1(typeof(CharacterSelectView), typeof(CharacterSelectView));
		this._viewCreator.method_1(typeof(ClassSelectView), typeof(ClassSelectView));
		this._viewCreator.method_1(typeof(InstanceSelectView), typeof(InstanceSelectView));
		this._viewCreator.method_1(typeof(ClassCustomView), typeof(ClassCustomView));
		this._viewCreator.method_1(typeof(LoadingInGameView), typeof(LoadingInGameView));
		this._viewCreator.method_1(typeof(HUDAimTargetView), typeof(HUDAimTargetView));
		this._viewCreator.method_1(typeof(HUDPlayerInfoView), typeof(HUDPlayerInfoView));
		this._viewCreator.method_1(typeof(HUDFeedbackView), typeof(HUDFeedbackView));
		this._viewCreator.method_1(typeof(HUDWorldTipsView), typeof(HUDWorldTipsView));
		this._viewCreator.method_1(typeof(EchoMessageView), typeof(EchoMessageView));
		this._viewCreator.method_1(typeof(HUDPvPInfoView), typeof(HUDPvPInfoView));
		this._viewCreator.method_1(typeof(HUDVictoryCondition), typeof(HUDVictoryCondition));
		this._viewCreator.method_1(typeof(HUDSkillStatusView), typeof(HUDSkillStatusView));
		this._viewCreator.method_1(typeof(InventoryView), typeof(InventoryView));
		this._viewCreator.method_1(typeof(CharInfoView), typeof(CharInfoView));
		this._viewCreator.method_1(typeof(NPCDialogView), typeof(NPCDialogView));
		this._viewCreator.method_1(typeof(QuestListView), typeof(QuestListView));
		this._viewCreator.method_1(typeof(QuestTrackView), typeof(QuestTrackView));
		this._viewCreator.method_1(typeof(SkillTreeView), typeof(SkillTreeView));
		this._viewCreator.method_1(typeof(CurrencyUpdateView), typeof(CurrencyUpdateView));
		this._viewCreator.method_1(typeof(WeaponCraftView), typeof(WeaponCraftView));
		this._viewCreator.method_1(typeof(ShopView), typeof(ShopView));
		this._viewCreator.method_1(typeof(HUDTeamMatePortraitView), typeof(HUDTeamMatePortraitView));
		this._viewCreator.method_1(typeof(QuestDetailView), typeof(QuestDetailView));
		this._viewCreator.method_1(typeof(HUDWarningView), typeof(HUDWarningView));
		this._viewCreator.method_1(typeof(HUDWrapupView), typeof(HUDWrapupView));
		this._viewCreator.method_1(typeof(HUDCountDownView), typeof(HUDCountDownView));
		this._viewCreator.method_1(typeof(SecondWindView), typeof(SecondWindView));
		this._viewCreator.method_1(typeof(NPCInteractiveView), typeof(NPCInteractiveView));
		this._viewCreator.method_1(typeof(MatchMakingView), typeof(MatchMakingView));
		this._viewCreator.method_1(typeof(TownHUDView), typeof(TownHUDView));
		this._viewCreator.method_1(typeof(PopupMenuView), typeof(PopupMenuView));
		this._viewCreator.method_1(typeof(GroupView), typeof(GroupView));
		this._viewCreator.method_1(typeof(FriendView), typeof(FriendView));
		this._viewCreator.method_1(typeof(WeaponMeltView), typeof(WeaponMeltView));
		this._viewCreator.method_1(typeof(WeaponPreviewView), typeof(WeaponPreviewView));
		this._viewCreator.method_1(typeof(MiniMapView), typeof(MiniMapView));
		this._viewCreator.method_1(typeof(LargeMapView), typeof(LargeMapView));
		this._viewCreator.method_1(typeof(ChatView), typeof(ChatView));
		this._viewCreator.method_1(typeof(PvPRoomListView), typeof(PvPRoomListView));
		this._viewCreator.method_1(typeof(PvPModeSelectView), typeof(PvPModeSelectView));
		this._viewCreator.method_1(typeof(PvPCancelView), typeof(PvPCancelView));
		this._viewCreator.method_1(typeof(GuildCreateView), typeof(GuildCreateView));
		this._viewCreator.method_1(typeof(GuildSearchView), typeof(GuildSearchView));
		this._viewCreator.method_1(typeof(GuildOptionView), typeof(GuildOptionView));
		this._viewCreator.method_1(typeof(PvPFlowView), typeof(PvPFlowView));
		this._viewCreator.method_1(typeof(PvPTipsView), typeof(PvPTipsView));
		this._viewCreator.method_1(typeof(WareHouseView), typeof(WareHouseView));
		this._viewCreator.method_1(typeof(MailView), typeof(MailView));
		this._viewCreator.method_1(typeof(PlayerListView), typeof(PlayerListView));
		this._viewCreator.method_1(typeof(HUDPvPKillStampView), typeof(HUDPvPKillStampView));
		this._viewCreator.method_1(typeof(HUDTreasureBoxView), typeof(HUDTreasureBoxView));
		this._viewCreator.method_1(typeof(WeaponUpgradeView), typeof(WeaponUpgradeView));
		this._viewCreator.method_1(typeof(NewInstanceSelectView), typeof(NewInstanceSelectView));
		this._viewCreator.method_1(typeof(InstanceInfoView), typeof(InstanceInfoView));
		this._viewCreator.method_1(typeof(TeamMateHpView), typeof(TeamMateHpView));
		this._viewCreator.method_1(typeof(AchievementBoardView), typeof(AchievementBoardView));
		this._viewCreator.method_1(typeof(AchievementPopUpView), typeof(AchievementPopUpView));
		this.vmethod_13();
	}

	// Token: 0x060029AA RID: 10666 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_13()
	{
	}

	// Token: 0x060029AB RID: 10667 RVA: 0x000C47D4 File Offset: 0x000C29D4
	public virtual IEnumerator vmethod_14()
	{
		yield return null;
	}
	// Token: 0x060029AC RID: 10668 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15()
	{
	}

	// Token: 0x060029AD RID: 10669 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x060029AE RID: 10670 RVA: 0x0000311B File Offset: 0x0000131B
	private void FixedUpdate()
	{
	}

	// Token: 0x060029AF RID: 10671 RVA: 0x0001B55D File Offset: 0x0001975D
	private void Update()
	{
		if (this.Boolean_1)
		{
			this.vmethod_24();
			this.vmethod_16();
		}
	}

	// Token: 0x060029B0 RID: 10672 RVA: 0x000C47E8 File Offset: 0x000C29E8
	protected virtual void vmethod_16()
	{
		if (this._funcUpdateList != null)
		{
			try
			{
				this._funcUpdateList();
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.GUI, "GameUIManager.vmethod_16 _funcUpdateList caught: " + ex.ToString());
			}
		}
		for (int i = 0; i < this._arrNextUpdate.Count; i++)
		{
			this._funcUpdateList = (GameUIManager.ViewUpdateCB)Delegate.Combine(this._funcUpdateList, this._arrNextUpdate[i]);
		}
		this._arrNextUpdate.Clear();
	}

	// Token: 0x060029B1 RID: 10673 RVA: 0x0001B573 File Offset: 0x00019773
	public void method_3(BaseView baseView_0, Vector2 vector2_0)
	{
		if (this._dicInventoryBind.ContainsKey(baseView_0))
		{
			this._dicInventoryBind[baseView_0] = vector2_0;
		}
		else
		{
			this._dicInventoryBind.Add(baseView_0, vector2_0);
		}
	}

	// Token: 0x060029B2 RID: 10674 RVA: 0x0001B59F File Offset: 0x0001979F
	public void method_4(BaseView baseView_0)
	{
		if (!this._arrFPSHideList.Contains(baseView_0))
		{
			this._arrFPSHideList.Add(baseView_0);
		}
	}

	// Token: 0x060029B3 RID: 10675 RVA: 0x0001B5BB File Offset: 0x000197BB
	public void method_5(BaseView baseView_0)
	{
		if (this._arrFPSHideList.Contains(baseView_0))
		{
			this._arrFPSHideList.Remove(baseView_0);
		}
	}

	// Token: 0x060029B4 RID: 10676 RVA: 0x0001B5D8 File Offset: 0x000197D8
	public void method_6(BaseView baseView_0)
	{
		if (!this._arrOccupyMenuList.Contains(baseView_0))
		{
			this._arrOccupyMenuList.Add(baseView_0);
		}
	}

	// Token: 0x060029B5 RID: 10677 RVA: 0x0001B5F4 File Offset: 0x000197F4
	public void method_7(BaseView baseView_0)
	{
		if (this._arrOccupyMenuList.Contains(baseView_0))
		{
			this._arrOccupyMenuList.Remove(baseView_0);
		}
	}

	// Token: 0x060029B6 RID: 10678 RVA: 0x0001B611 File Offset: 0x00019811
	public void method_8(BaseView baseView_0)
	{
		if (!this._arrConflictMenuList.Contains(baseView_0))
		{
			this._arrConflictMenuList.Add(baseView_0);
		}
	}

	// Token: 0x060029B7 RID: 10679 RVA: 0x0001B62D File Offset: 0x0001982D
	public void method_9(BaseView baseView_0)
	{
		if (this._arrConflictMenuList.Contains(baseView_0))
		{
			this._arrConflictMenuList.Remove(baseView_0);
		}
	}

	// Token: 0x060029B8 RID: 10680 RVA: 0x0001B64A File Offset: 0x0001984A
	public void OnViewVisibleChange(BaseView view, bool visible, bool bInner = false)
	{
		this.method_10(view, visible);
		if (!bInner)
		{
			if (visible)
			{
				this.method_11(view);
			}
			this.method_12();
		}
	}

	// Token: 0x060029B9 RID: 10681 RVA: 0x000C4878 File Offset: 0x000C2A78
	protected void method_10(BaseView baseView_0, bool bool_0)
	{
		if (baseView_0 is InventoryView)
		{
			if (bool_0)
			{
				return;
			}
			using (Dictionary<BaseView, Vector2>.KeyCollection.Enumerator enumerator = this._dicInventoryBind.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BaseView baseView = enumerator.Current;
					if (baseView.Boolean_1)
					{
						baseView.method_0(false);
					}
				}
				return;
			}
		}
		if (this._dicInventoryBind.ContainsKey(baseView_0) && this.vmethod_5<InventoryView>().Boolean_0)
		{
			if (bool_0)
			{
				this.vmethod_5<InventoryView>().vmethod_5(this._dicInventoryBind[baseView_0]);
			}
			this.vmethod_5<InventoryView>().Boolean_1 = bool_0;
		}
	}

	// Token: 0x060029BA RID: 10682 RVA: 0x000C4928 File Offset: 0x000C2B28
	protected void method_11(BaseView baseView_0)
	{
		if (this._arrConflictMenuList.Contains(baseView_0))
		{
			foreach (BaseView baseView in this._arrConflictMenuList)
			{
				if (baseView != baseView_0 && baseView.Boolean_1)
				{
					baseView.method_0(false);
				}
			}
		}
	}

	// Token: 0x060029BB RID: 10683 RVA: 0x000C4994 File Offset: 0x000C2B94
	protected void method_12()
	{
		bool flag = this.method_13();
		FrontEndStepManager.StepState stepState = MonoSingleton<AppManager>.Instance.method_14();
		this.method_15(flag || (stepState != FrontEndStepManager.StepState.PVP && stepState != FrontEndStepManager.StepState.Town && stepState != FrontEndStepManager.StepState.Gaming && stepState != FrontEndStepManager.StepState.RV), "UIManager");
		this.vmethod_20(!flag);
	}

	// Token: 0x060029BC RID: 10684 RVA: 0x000C49E4 File Offset: 0x000C2BE4
	protected bool method_13()
	{
		bool flag = false;
		foreach (BaseView baseView in this._arrOccupyMenuList)
		{
			flag = flag || baseView.Boolean_1;
		}
		return flag;
	}

	// Token: 0x060029BD RID: 10685 RVA: 0x000C4A40 File Offset: 0x000C2C40
	protected virtual void vmethod_17(bool bool_0)
	{
		foreach (BaseView baseView in this._arrFPSHideList)
		{
			baseView.method_0(bool_0);
		}
	}

	// Token: 0x060029BE RID: 10686 RVA: 0x000C4A94 File Offset: 0x000C2C94
	protected void method_14()
	{
		if (this._arrMouseFree.Count > 0)
		{
			if (MonoSingleton<GameFlowManager>.Instance != null)
			{
				MonoSingleton<GameFlowManager>.Instance.method_1();
			}
			MonoSingleton<InputManager>.Instance.method_1(false);
		}
		else
		{
			if (MonoSingleton<GameFlowManager>.Instance != null)
			{
				MonoSingleton<GameFlowManager>.Instance.method_0();
			}
			MonoSingleton<InputManager>.Instance.method_2(false);
		}
	}

	// Token: 0x060029BF RID: 10687 RVA: 0x0001B667 File Offset: 0x00019867
	public void method_15(bool bool_0, string string_0)
	{
		if (bool_0)
		{
			this._arrMouseFree.Add(string_0);
		}
		else
		{
			this._arrMouseFree.Remove(string_0);
		}
		this.method_14();
	}

	// Token: 0x060029C0 RID: 10688 RVA: 0x0001B68E File Offset: 0x0001988E
	public virtual void vmethod_18(bool bool_0)
	{
		if (MonoSingleton<GraphicsMgr>.Instance == null)
		{
			return;
		}
		MonoSingleton<GraphicsMgr>.Instance.method_18().method_8(!bool_0);
	}

	// Token: 0x060029C1 RID: 10689 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_19(bool bool_0)
	{
	}

	// Token: 0x060029C2 RID: 10690 RVA: 0x0001B6B1 File Offset: 0x000198B1
	public virtual void vmethod_20(bool bool_0)
	{
		this.vmethod_17(bool_0);
		this.vmethod_18(!bool_0);
	}

	// Token: 0x060029C3 RID: 10691 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_21(bool bool_0)
	{
	}

	// Token: 0x060029C4 RID: 10692 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_0(string string_0)
	{
	}

	// Token: 0x060029C5 RID: 10693 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_22(string string_0, float float_0)
	{
	}

	// Token: 0x060029C6 RID: 10694 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_23(object object_0)
	{
	}

	// Token: 0x060029C7 RID: 10695 RVA: 0x000C4AF8 File Offset: 0x000C2CF8
	public void method_16(BaseView baseView_0, string string_0)
	{
		if (this._mapShortCutCMD.ContainsKey(string_0))
		{
			if (this._mapShortCutCMD[string_0].Contains(baseView_0))
			{
				return;
			}
		}
		else
		{
			this._mapShortCutCMD.Add(string_0, new List<BaseView>());
		}
		this._mapShortCutCMD[string_0].Add(baseView_0);
	}

	// Token: 0x060029C8 RID: 10696 RVA: 0x0001B6C4 File Offset: 0x000198C4
	public void method_17(BaseView baseView_0, string string_0 = "")
	{
		if (this._mapShortCutCMD.ContainsKey(string_0) && this._mapShortCutCMD[string_0].Contains(baseView_0))
		{
			this._mapShortCutCMD[string_0].Remove(baseView_0);
		}
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x060029C9 RID: 10697 RVA: 0x0001B6FB File Offset: 0x000198FB
	// (set) Token: 0x060029CA RID: 10698 RVA: 0x0001B703 File Offset: 0x00019903
	public virtual bool Boolean_1
	{
		get
		{
			return this._updateEnabled;
		}
		set
		{
			this._updateEnabled = value;
		}
	}

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x060029CB RID: 10699 RVA: 0x0001B70C File Offset: 0x0001990C
	// (set) Token: 0x060029CC RID: 10700 RVA: 0x0001B714 File Offset: 0x00019914
	public virtual bool Boolean_2
	{
		get
		{
			return this._shortCutEnabled;
		}
		set
		{
			this._shortCutEnabled = value;
		}
	}

	// Token: 0x060029CD RID: 10701 RVA: 0x000C4B4C File Offset: 0x000C2D4C
	private void method_18()
	{
		Dictionary<string, List<BaseView>>.Enumerator enumerator = this._mapShortCutCMD.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (this.Boolean_2)
			{
				InputManager prop_ = MonoSingleton<InputManager>.Instance;
				KeyValuePair<string, List<BaseView>> keyValuePair = enumerator.Current;
				if (prop_.method_9(keyValuePair.Key))
				{
					KeyValuePair<string, List<BaseView>> keyValuePair2 = enumerator.Current;
					List<BaseView> value = keyValuePair2.Value;
					for (int i = 0; i < value.Count; i++)
					{
						BaseView baseView = value[i];
						KeyValuePair<string, List<BaseView>> keyValuePair3 = enumerator.Current;
						if (baseView.OnShortCutCMD(keyValuePair3.Key))
						{
							return;
						}
					}
				}
			}
		}
	}

	// Token: 0x060029CE RID: 10702 RVA: 0x000C4BD4 File Offset: 0x000C2DD4
	protected virtual void vmethod_24()
	{
		try
		{
			this.method_18();
			if (MonoSingleton<InputManager>.Instance.method_9("Escape"))
			{
				this.vmethod_25();
			}
			if (MonoSingleton<InputManager>.Instance.method_9("HideHUD") && this.Boolean_2)
			{
				this._bHudVisible = !this._bHudVisible;
				this.vmethod_10(this._bHudVisible);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.GUI, "GameUIManager.vmethod_24 caught: " + ex.ToString());
		}
	}

	// Token: 0x060029CF RID: 10703 RVA: 0x000C4C60 File Offset: 0x000C2E60
	protected virtual bool vmethod_25()
	{
		if (this.vmethod_5<HUDWarningView>().Boolean_1)
		{
			this.vmethod_5<HUDWarningView>().vmethod_8(true);
			return true;
		}
		if (this.vmethod_5<PlayerListView>().vmethod_4())
		{
			return true;
		}
		if (this.vmethod_5<PopupMenuView>().Boolean_0 && this.vmethod_5<PopupMenuView>().Boolean_1)
		{
			this.vmethod_5<PopupMenuView>().method_6();
			return true;
		}
		foreach (KeyValuePair<Type, BaseView> keyValuePair in this._viewCreator.method_0())
		{
			if (!(keyValuePair.Value is PauseMenuView) && keyValuePair.Value.Boolean_0 && keyValuePair.Value.vmethod_4())
			{
				return true;
			}
		}
		return this.vmethod_5<PauseMenuView>().Boolean_0 && this.vmethod_5<PauseMenuView>().vmethod_4();
	}

	// Token: 0x060029D0 RID: 10704 RVA: 0x0001B71D File Offset: 0x0001991D
	public virtual void vmethod_26(GameUIManager.CursorManager.CursorType cursorType_0)
	{
		this._cursorManager.method_0(cursorType_0);
	}

	// Token: 0x04001DB7 RID: 7607
	private bool m_bIsMatchMaking;

	// Token: 0x04001DB8 RID: 7608
	protected GameObject _UIRootObject;

	// Token: 0x04001DB9 RID: 7609
	protected GameUIManager.UIViewCreator _viewCreator = new GameUIManager.UIViewCreator();

	// Token: 0x04001DBA RID: 7610
	protected GameUIManager.CursorManager _cursorManager = new GameUIManager.CursorManager();

	// Token: 0x04001DBB RID: 7611
	protected GameUIManager.EngineUIInputReader _InputReader;

	// Token: 0x04001DBC RID: 7612
	protected GameUIManager.ViewUpdateCB _funcUpdateList;

	// Token: 0x04001DBD RID: 7613
	protected List<GameUIManager.ViewUpdateCB> _arrNextUpdate = new List<GameUIManager.ViewUpdateCB>();

	// Token: 0x04001DBE RID: 7614
	protected Camera _gameCamera;

	// Token: 0x04001DBF RID: 7615
	protected bool _bLevelLoading;

	// Token: 0x04001DC0 RID: 7616
	protected bool _bHudVisible = true;

	// Token: 0x04001DC1 RID: 7617
	private List<BaseView> _arrOccupyMenuList = new List<BaseView>();

	// Token: 0x04001DC2 RID: 7618
	private List<BaseView> _arrConflictMenuList = new List<BaseView>();

	// Token: 0x04001DC3 RID: 7619
	private List<BaseView> _arrFPSHideList = new List<BaseView>();

	// Token: 0x04001DC4 RID: 7620
	protected Dictionary<BaseView, Vector2> _dicInventoryBind = new Dictionary<BaseView, Vector2>();

	// Token: 0x04001DC5 RID: 7621
	private HashSet<object> _arrMouseFree = new HashSet<object>();

	// Token: 0x04001DC6 RID: 7622
	private Dictionary<string, List<BaseView>> _mapShortCutCMD = new Dictionary<string, List<BaseView>>();

	// Token: 0x04001DC7 RID: 7623
	protected bool _updateEnabled = true;

	// Token: 0x04001DC8 RID: 7624
	protected bool _shortCutEnabled = true;

	// Token: 0x04001DC9 RID: 7625
	public bool USING_TEST_GUI = true;

	// Token: 0x0200066F RID: 1647
	public class UIViewCreator
	{
		// Token: 0x060029D2 RID: 10706 RVA: 0x0001B749 File Offset: 0x00019949
		public Dictionary<Type, BaseView> method_0()
		{
			return this._mapViewPool;
		}

		// Token: 0x060029D3 RID: 10707 RVA: 0x000C4D50 File Offset: 0x000C2F50
		public virtual BaseView vmethod_0(Type type_0)
		{
			if (this._mapViewPool.ContainsKey(type_0))
			{
				return this._mapViewPool[type_0];
			}
			if (this._mapClasses.ContainsKey(type_0))
			{
				BaseView baseView = Activator.CreateInstance(this._mapClasses[type_0]) as BaseView;
				if (baseView != null)
				{
					this._mapViewPool.Add(type_0, baseView);
				}
				return baseView;
			}
			return null;
		}

		// Token: 0x060029D4 RID: 10708 RVA: 0x0001B751 File Offset: 0x00019951
		public void method_1(Type type_0, Type type_1)
		{
			if (this._mapClasses.ContainsKey(type_0))
			{
				this._mapClasses[type_0] = type_1;
			}
			else
			{
				this._mapClasses.Add(type_0, type_1);
			}
		}

		// Token: 0x04001DCA RID: 7626
		protected Dictionary<Type, Type> _mapClasses = new Dictionary<Type, Type>();

		// Token: 0x04001DCB RID: 7627
		protected Dictionary<Type, BaseView> _mapViewPool = new Dictionary<Type, BaseView>();
	}

	// Token: 0x02000670 RID: 1648
	public class CursorManager
	{
		// Token: 0x060029D5 RID: 10709 RVA: 0x000C4DB0 File Offset: 0x000C2FB0
		public CursorManager()
		{
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HandSelected] = "UI_uniSWF/Effects/Cursors/Cursor_Select";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HandClosed] = "UI_uniSWF/Effects/Cursors/Cursor_HandClosed";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HammerLift] = "UI_uniSWF/Effects/Cursors/Harmmer_1";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HammerKnock] = "UI_uniSWF/Effects/Cursors/Harmmer_2";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HammerForbid] = "UI_uniSWF/Effects/Cursors/Harmmer_3";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HandOpen] = "UI_uniSWF/Effects/Cursors/Hand_1";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.HandClose] = "UI_uniSWF/Effects/Cursors/Hand_2";
			this._mapTexturePath[GameUIManager.CursorManager.CursorType.Money] = "UI_uniSWF/Effects/Cursors/money";
			this._mapTexture.Add(GameUIManager.CursorManager.CursorType.DefaultCursor, null);
		}

		// Token: 0x060029D6 RID: 10710 RVA: 0x000C4E78 File Offset: 0x000C3078
		public void method_0(GameUIManager.CursorManager.CursorType cursorType_0)
		{
			if (cursorType_0 == this._currentCursorType)
			{
				return;
			}
			this._currentCursorType = cursorType_0;
			CursorMode cursorMode = CursorMode.Auto;
			Vector2 vector = new Vector2(0f, 0f);
			if (!this._mapTexture.ContainsKey(cursorType_0))
			{
				Texture2D texture2D = (Texture2D)ResourcesLoader.smethod_0(this._mapTexturePath[cursorType_0]);
				this._mapTexture.Add(cursorType_0, texture2D);
			}
			Cursor.SetCursor(this._mapTexture[cursorType_0], vector, cursorMode);
		}

		// Token: 0x04001DCC RID: 7628
		protected GameUIManager.CursorManager.CursorType _currentCursorType = GameUIManager.CursorManager.CursorType.DefaultCursor;

		// Token: 0x04001DCD RID: 7629
		protected Dictionary<GameUIManager.CursorManager.CursorType, string> _mapTexturePath = new Dictionary<GameUIManager.CursorManager.CursorType, string>();

		// Token: 0x04001DCE RID: 7630
		protected Dictionary<GameUIManager.CursorManager.CursorType, Texture2D> _mapTexture = new Dictionary<GameUIManager.CursorManager.CursorType, Texture2D>();

		// Token: 0x02000671 RID: 1649
		public enum CursorType
		{
			// Token: 0x04001DD0 RID: 7632
			DefaultCursor = 1,
			// Token: 0x04001DD1 RID: 7633
			HandSelected,
			// Token: 0x04001DD2 RID: 7634
			HandClosed,
			// Token: 0x04001DD3 RID: 7635
			HammerLift,
			// Token: 0x04001DD4 RID: 7636
			HammerKnock,
			// Token: 0x04001DD5 RID: 7637
			HammerForbid,
			// Token: 0x04001DD6 RID: 7638
			HandOpen,
			// Token: 0x04001DD7 RID: 7639
			HandClose,
			// Token: 0x04001DD8 RID: 7640
			Money
		}
	}

	// Token: 0x02000672 RID: 1650
	public class EngineUIInputReader : RegularInputReader
	{
		// Token: 0x060029D7 RID: 10711 RVA: 0x0001B77D File Offset: 0x0001997D
		public EngineUIInputReader(GameUIManager gameUIManager_0)
		{
			this._UIManager = gameUIManager_0;
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x0001B78C File Offset: 0x0001998C
		public override bool GetMouseButton(int button, bool bCareUI = false)
		{
			return (!bCareUI || !this._UIManager.vmethod_11()) && Input.GetMouseButton(button);
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x0001B7A6 File Offset: 0x000199A6
		public override bool GetMouseButtonDown(int button, bool bCareUI = false)
		{
			return (!bCareUI || !this._UIManager.vmethod_11()) && Input.GetMouseButtonDown(button);
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x0001B7C0 File Offset: 0x000199C0
		public override bool GetMouseButtonUp(int button, bool bCareUI = false)
		{
			return (!bCareUI || !this._UIManager.vmethod_11()) && Input.GetMouseButtonUp(button);
		}

		// Token: 0x04001DD9 RID: 7641
		private GameUIManager _UIManager;
	}

	// Token: 0x02000673 RID: 1651
	// (Invoke) Token: 0x060029DC RID: 10716
	public delegate void ViewUpdateCB();
}
