using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006C4 RID: 1732
public class PauseMenuView : BaseView
{
	// Token: 0x06002DB3 RID: 11699 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002DB4 RID: 11700 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnTestGUI()
	{
	}

	// Token: 0x06002DB5 RID: 11701 RVA: 0x000D5D84 File Offset: 0x000D3F84
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (MonoSingleton<AppManager>.Instance.method_0())
		{
			MonoSingleton<AppManager>.Instance.method_0().method_6(this);
			MonoSingleton<AppManager>.Instance.method_0().method_8(this);
			MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_5), false);
		}
		if (MonoSingleton<GameSettingMgr>.Instance != null)
		{
			this._dicSettingsByCategory = MonoSingleton<GameSettingMgr>.Instance.method_1();
		}
		this._bEnable = true;
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		this._bRespawnEnable = !MonoSingleton<Session>.Instance.method_16() && !MonoSingleton<Session>.Instance.method_12();
		this._bLeaveInstanceEnable = !MonoSingleton<Session>.Instance.method_16() && (!MonoSingleton<Session>.Instance.method_13() || (MonoSingleton<GameSettingMgr>.Instance != null && MonoSingleton<GameSettingMgr>.Instance.method_15(GameSettingMgr.UserData.PlayedTutorial.ToString()) == 1));
		this._bReplayTutorialEnable = MonoSingleton<Session>.Instance.method_16();
	}

	// Token: 0x06002DB6 RID: 11702 RVA: 0x000D5E98 File Offset: 0x000D4098
	public void method_3(string string_0)
	{
		List<GameSettingMgr.SettingItemData> list = this._dicSettingsByCategory[SettingCategory.Control];
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = 0; j < list[i].children.Count; j++)
			{
				if (list[i].children[j].controlAction.ToString() == string_0)
				{
					list[i].children[j].newValue.keyBinding = MonoSingleton<InputManager>.Instance.method_16(string_0);
					list[i].children[j].bDirty = true;
				}
			}
		}
	}

	// Token: 0x06002DB7 RID: 11703 RVA: 0x000D5F50 File Offset: 0x000D4150
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_5));
		this._dicSettingsByCategory = null;
		this._bEnable = false;
	}

	// Token: 0x06002DB8 RID: 11704 RVA: 0x000D5FAC File Offset: 0x000D41AC
	public override bool vmethod_4()
	{
		if (!this._bEnable)
		{
			return false;
		}
		if (this.Boolean_1 && !MonoSingleton<GameSettingMgr>.Instance.method_3())
		{
			this.method_18();
			return true;
		}
		if (this.Boolean_1 && MonoSingleton<GameSettingMgr>.Instance.method_4())
		{
			this.method_19();
			return true;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06002DBA RID: 11706 RVA: 0x0001E563 File Offset: 0x0001C763
	// (set) Token: 0x06002DB9 RID: 11705 RVA: 0x0001E54B File Offset: 0x0001C74B
	public new bool Boolean_0
	{
		get
		{
			return this._bEnable;
		}
		set
		{
			if (this.Boolean_1)
			{
				this.Boolean_1 = false;
			}
			this._bEnable = value;
		}
	}

	// Token: 0x06002DBB RID: 11707 RVA: 0x0001E56B File Offset: 0x0001C76B
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<GameSettingMgr>.Instance.method_8();
			this.vmethod_5(PauseMenuView.EscMenuState.Root, false);
		}
		else
		{
			MonoSingleton<GameSettingMgr>.Instance.method_18();
		}
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = !bool_0;
	}

	// Token: 0x06002DBC RID: 11708 RVA: 0x000D600C File Offset: 0x000D420C
	protected void method_4()
	{
		InputManager.InputKeyBinding keyBinding = this._onProcessingData.newValue.keyBinding;
		if (this._bIsPrimaryKey)
		{
			keyBinding.primaryKey = this._onPressingKeyCode;
		}
		else
		{
			keyBinding.seconderyKey = this._onPressingKeyCode;
		}
		MonoSingleton<InputManager>.Instance.method_22(this._onProcessingData.controlAction.ToString(), keyBinding.primaryKey, keyBinding.seconderyKey, ControlGroup.Common);
		List<string> list = MonoSingleton<InputManager>.Instance.method_17(this._onProcessingData.controlAction.ToString(), this._onPressingKeyCode);
		for (int i = 0; i < list.Count; i++)
		{
			MonoSingleton<InputManager>.Instance.method_20(list[i], this._onPressingKeyCode);
			this.method_3(list[i]);
		}
		this._onProcessingData.bDirty = true;
		this._bWaitingForInput = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
		this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
	}

	// Token: 0x06002DBD RID: 11709 RVA: 0x000D6104 File Offset: 0x000D4304
	protected void method_5()
	{
		if (this._bWaitingForInput)
		{
			this._onPressingKeyCode = MonoSingleton<InputManager>.Instance.method_15();
			InputManager.InputKeyBinding keyBinding = this._onProcessingData.newValue.keyBinding;
			if (this._onPressingKeyCode != KeyCode.None)
			{
				if (MonoSingleton<InputManager>.Instance.method_4("Delete"))
				{
					if (this._bIsPrimaryKey)
					{
						keyBinding.primaryKey = KeyCode.None;
					}
					else
					{
						keyBinding.seconderyKey = KeyCode.None;
					}
				}
				else
				{
					if (MonoSingleton<InputManager>.Instance.method_18(this._onProcessingData.controlAction.ToString(), this._onPressingKeyCode))
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_ConflictKeys")), new Delegate_EventProc(this.method_4), new Delegate_EventProc(this.method_14));
						this._bWaitingForInput = false;
						return;
					}
					if (this._bIsPrimaryKey)
					{
						keyBinding.primaryKey = this._onPressingKeyCode;
					}
					else
					{
						keyBinding.seconderyKey = this._onPressingKeyCode;
					}
				}
				MonoSingleton<InputManager>.Instance.method_22(this._onProcessingData.controlAction.ToString(), keyBinding.primaryKey, keyBinding.seconderyKey, ControlGroup.Common);
				this._onProcessingData.bDirty = true;
				this._bWaitingForInput = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
				this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
			}
		}
	}

	// Token: 0x06002DBE RID: 11710 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5(PauseMenuView.EscMenuState escMenuState_0, bool bool_0 = false)
	{
	}

	// Token: 0x06002DBF RID: 11711 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected virtual void vmethod_6()
	{
		this.Boolean_1 = false;
	}

	// Token: 0x06002DC0 RID: 11712 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_6()
	{
	}

	// Token: 0x06002DC1 RID: 11713 RVA: 0x000D6278 File Offset: 0x000D4478
	protected void method_7()
	{
		this.Boolean_1 = false;
		if (MonoSingleton<Session>.Instance && !MonoSingleton<Session>.Instance.method_16())
		{
			if (GroupManager.smethod_0().method_18())
			{
				GroupManager.smethod_0().method_27();
			}
			if (LobbyManager.smethod_0().method_0())
			{
				LobbyManager.smethod_0().method_24();
			}
			GroupManager.smethod_0().method_25(null);
			MonoSingleton<global::EchoMessageManager>.Instance.method_1();
			MonoSingleton<GameFlowManager>.Instance.method_11();
		}
	}

	// Token: 0x06002DC2 RID: 11714 RVA: 0x0001E5B2 File Offset: 0x0001C7B2
	protected void method_8()
	{
		if (MonoSingleton<Session>.Instance && !MonoSingleton<Session>.Instance.method_16())
		{
			SessionInfo.SessionInfo_0.method_1();
		}
		this.Boolean_1 = false;
	}

	// Token: 0x06002DC3 RID: 11715 RVA: 0x0001E5DD File Offset: 0x0001C7DD
	protected void method_9()
	{
		this.Boolean_1 = false;
		MonoSingleton<GameFlowManager>.Instance.method_5();
	}

	// Token: 0x06002DC4 RID: 11716 RVA: 0x0001E5F0 File Offset: 0x0001C7F0
	protected void method_10()
	{
		this.Boolean_1 = false;
		MonoSingleton<AppManager>.Instance.method_8();
	}

	// Token: 0x06002DC5 RID: 11717 RVA: 0x000D62F0 File Offset: 0x000D44F0
	protected void method_11()
	{
		this.Boolean_1 = false;
		if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.method_16())
		{
			if (GroupManager.smethod_0() != null && GroupManager.smethod_0().method_18())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7("you can't leave the game while in a party", null, null);
				return;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7("Are you sure you want to go to character selection?", delegate
			{
				if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_25() != null)
				{
					MonoSingleton<Session>.Instance.method_25().imethod_0();
				}
				MatchmakingService.LeaveRoomAsyncTask leaveRoomAsyncTask = new MatchmakingService.LeaveRoomAsyncTask();
				leaveRoomAsyncTask.method_4();
				MonoSingleton<AsyncTaskManager>.Instance.method_1(leaveRoomAsyncTask, delegate(AsyncTaskBase leaveTask, AsyncTaskStatus leaveResult)
				{
					Application.LoadLevel("Lobby_01");
					if (MonoSingleton<LevelLoadingManager>.Instance.method_3())
					{
						MonoSingleton<LevelLoadingManager>.Instance.method_5();
					}
					CharacterService.GetCharacterListAsyncTask getCharacterListAsyncTask = new CharacterService.GetCharacterListAsyncTask();
					getCharacterListAsyncTask.method_4();
					MonoSingleton<AsyncTaskManager>.Instance.method_1(getCharacterListAsyncTask, delegate(AsyncTaskBase listTask, AsyncTaskStatus listResult)
					{
						List<Character> characters = (listTask as CharacterService.GetCharacterListAsyncTask).m_characters;
						OnlineService.s_characterId = 0;
						MonoSingleton<AppManager>.Instance.method_0().method_15(true, "CharacterSelect");
						Screen.lockCursor = false;
						Screen.showCursor = true;
						MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().Boolean_0 = true;
						MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.CharacterSelect, characters);
					});
				});
			}, delegate
			{
			});
		}
	}

	// Token: 0x06002DC6 RID: 11718 RVA: 0x0001E603 File Offset: 0x0001C803
	protected void method_12()
	{
		this._bWaitingForInput = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Message_PressNewKey")), null, new Delegate_EventProc(this.method_14));
	}

	// Token: 0x06002DC7 RID: 11719 RVA: 0x0001E63C File Offset: 0x0001C83C
	protected void method_13()
	{
		this._bWaitingForInput = false;
	}

	// Token: 0x06002DC8 RID: 11720 RVA: 0x0001E63C File Offset: 0x0001C83C
	protected void method_14()
	{
		this._bWaitingForInput = false;
	}

	// Token: 0x06002DC9 RID: 11721 RVA: 0x0001E645 File Offset: 0x0001C845
	protected void method_15()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_ResetAllKeys")), new Delegate_EventProc(this.method_16), new Delegate_EventProc(this.method_14));
	}

	// Token: 0x06002DCA RID: 11722 RVA: 0x0001E682 File Offset: 0x0001C882
	protected void method_16()
	{
		MonoSingleton<InputManager>.Instance.method_23();
		this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
	}

	// Token: 0x06002DCB RID: 11723 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_17()
	{
	}

	// Token: 0x06002DCC RID: 11724 RVA: 0x000D63A8 File Offset: 0x000D45A8
	protected void method_18()
	{
		string text = LocalizedString.smethod_0(new LocalizedString("Warning_BlankKeys"));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(text, null, new Delegate_EventProc(this.method_17));
	}

	// Token: 0x06002DCD RID: 11725 RVA: 0x000D63E8 File Offset: 0x000D45E8
	protected void method_19()
	{
		string text = LocalizedString.smethod_0(new LocalizedString("OPTION_CONFIRMATION"));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(text, new Delegate_EventProc(this.method_21), new Delegate_EventProc(this.method_22));
	}

	// Token: 0x06002DCE RID: 11726 RVA: 0x000D6434 File Offset: 0x000D4634
	protected void method_20()
	{
		string text = LocalizedString.smethod_0(new LocalizedString("Reset_Confirmation"));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(text, new Delegate_EventProc(this.method_23), new Delegate_EventProc(this.method_24));
	}

	// Token: 0x06002DCF RID: 11727 RVA: 0x0001E696 File Offset: 0x0001C896
	protected void method_21()
	{
		MonoSingleton<GameSettingMgr>.Instance.method_5();
		this.vmethod_5(PauseMenuView.EscMenuState.Root, false);
	}

	// Token: 0x06002DD0 RID: 11728 RVA: 0x0001E6AA File Offset: 0x0001C8AA
	protected void method_22()
	{
		MonoSingleton<GameSettingMgr>.Instance.method_6();
		MonoSingleton<GameSettingMgr>.Instance.method_8();
		this.vmethod_5(PauseMenuView.EscMenuState.Root, false);
	}

	// Token: 0x06002DD1 RID: 11729 RVA: 0x0001E6C8 File Offset: 0x0001C8C8
	protected void method_23()
	{
		this.vmethod_7();
		this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
	}

	// Token: 0x06002DD2 RID: 11730 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x06002DD3 RID: 11731 RVA: 0x0001E6D8 File Offset: 0x0001C8D8
	protected void method_24()
	{
		this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
	}

	// Token: 0x06002DD4 RID: 11732 RVA: 0x000D6480 File Offset: 0x000D4680
	protected void method_25(GameSettingMgr.SettingItemData settingItemData_0)
	{
		if (settingItemData_0 == null)
		{
			return;
		}
		if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.ConfigItem && settingItemData_0.config != null)
		{
			SettingFunctionType mFunctionType = settingItemData_0.config.mFunctionType;
			if (mFunctionType == SettingFunctionType.ReplayTutorial)
			{
				MonoSingleton<GameFlowManager>.Instance.method_5();
			}
		}
	}

	// Token: 0x06002DD5 RID: 11733 RVA: 0x0001E6E2 File Offset: 0x0001C8E2
	protected void method_26()
	{
		if (!MonoSingleton<GameSettingMgr>.Instance.method_3())
		{
			this.method_18();
			return;
		}
		MonoSingleton<GameSettingMgr>.Instance.method_5();
		MonoSingleton<GameSettingMgr>.Instance.method_8();
	}

	// Token: 0x06002DD6 RID: 11734 RVA: 0x0001E70B File Offset: 0x0001C90B
	protected void method_27(SettingCategory settingCategory_0)
	{
		MonoSingleton<GameSettingMgr>.Instance.method_2(settingCategory_0);
		MonoSingleton<GameSettingMgr>.Instance.method_8();
		this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
	}

	// Token: 0x04002003 RID: 8195
	protected PauseMenuView.EscMenuState _curState;

	// Token: 0x04002004 RID: 8196
	protected GameSettingMgr.SettingItemData _onProcessingData;

	// Token: 0x04002005 RID: 8197
	protected Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> _dicSettingsByCategory = new Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>>();

	// Token: 0x04002006 RID: 8198
	protected bool _bWaitingForInput;

	// Token: 0x04002007 RID: 8199
	protected bool _bIsPrimaryKey;

	// Token: 0x04002008 RID: 8200
	protected bool _bEnable = true;

	// Token: 0x04002009 RID: 8201
	protected bool _bRespawnEnable = true;

	// Token: 0x0400200A RID: 8202
	protected bool _bLeaveInstanceEnable = true;

	// Token: 0x0400200B RID: 8203
	protected bool _bReplayTutorialEnable = true;

	// Token: 0x0400200C RID: 8204
	protected KeyCode _onPressingKeyCode;

	// Token: 0x020006C5 RID: 1733
	public enum EscMenuFunction
	{
		// Token: 0x0400200E RID: 8206
		BackToGame,
		// Token: 0x0400200F RID: 8207
		ReplayTutorial,
		// Token: 0x04002010 RID: 8208
		GameOptions,
		// Token: 0x04002011 RID: 8209
		QuitInstance,
		// Token: 0x04002012 RID: 8210
		Respawn,
		// Token: 0x04002013 RID: 8211
		CharacterSelection,
		// Token: 0x04002014 RID: 8212
		ExitGame
	}

	// Token: 0x020006C6 RID: 1734
	public enum EscMenuState
	{
		// Token: 0x04002016 RID: 8214
		Root,
		// Token: 0x04002017 RID: 8215
		Options
	}
}
