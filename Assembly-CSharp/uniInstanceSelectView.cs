using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x020006AD RID: 1709
public class uniInstanceSelectView : InstanceSelectView
{
	// Token: 0x06002C99 RID: 11417 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002C9A RID: 11418 RVA: 0x0001D85C File Offset: 0x0001BA5C
	public override void OnTestGUI()
	{
		if (GUI.Button(new Rect(0f, 0f, 300f, 80f), "Goto Class Selection"))
		{
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.ClassSelect, null);
		}
	}

	// Token: 0x06002C9B RID: 11419 RVA: 0x000D208C File Offset: 0x000D028C
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("InstanceSelect.swf", "InstanceSelectPannel", new FuncLoad(this.method_18));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PlayerInfoBar.swf", "ScreenPanel", new FuncLoad(this.method_20));
	}

	// Token: 0x06002C9C RID: 11420 RVA: 0x000D20F4 File Offset: 0x000D02F4
	private void method_18(MovieClip movieClip_0)
	{
		this._panel = new GClass51();
		this._panel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._panel);
		this.vmethod_5(MonoSingleton<InputManager>.Instance.method_14());
		base.method_3();
		this.method_19();
		if (this.mcInventoryBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("hint") != null)
		{
			this.mcInventoryBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("hint").visible = false;
		}
	}

	// Token: 0x06002C9D RID: 11421 RVA: 0x000D2190 File Offset: 0x000D0390
	private void method_19()
	{
		this.mcPVPBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("hint").visible = false;
		if (ServiceWrapperBase<QuestServiceWrapper>.Instance.method_21())
		{
			this.mcPVPBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("quest").visible = true;
		}
		else
		{
			this.mcPVPBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("quest").visible = false;
		}
	}

	// Token: 0x06002C9E RID: 11422 RVA: 0x000D21FC File Offset: 0x000D03FC
	private void method_20(MovieClip movieClip_0)
	{
		this._charInfoPanel = new GClass51();
		this._charInfoPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._charInfoPanel);
	}

	// Token: 0x06002C9F RID: 11423 RVA: 0x000D2248 File Offset: 0x000D0448
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._charInfoPanel);
		this._panel = null;
		this._charInfoPanel = null;
		this.mcPlayerInfo = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("InstanceSelect.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PlayerInfoBar.swf");
	}

	// Token: 0x06002CA0 RID: 11424 RVA: 0x000D22D8 File Offset: 0x000D04D8
	public override void vmethod_8(bool bool_0)
	{
		base.vmethod_8(bool_0);
		if (this.mcSkillBtn != null && this._bSkillBtnEnable)
		{
			MovieClip movieClip = this.mcSkillBtn.DisplayObjectContainer_0 as MovieClip;
			if (movieClip != null)
			{
				if (bool_0)
				{
					movieClip.gotoAndPlay("actived");
				}
				else
				{
					movieClip.gotoAndPlay("up");
				}
			}
			return;
		}
	}

	// Token: 0x06002CA1 RID: 11425 RVA: 0x0001D894 File Offset: 0x0001BA94
	public override void vmethod_9(bool bool_0)
	{
		base.vmethod_9(bool_0);
		if (this.mcSkillBtn != null)
		{
			this.mcSkillBtn.Boolean_6 = bool_0;
		}
	}

	// Token: 0x06002CA2 RID: 11426 RVA: 0x000D232C File Offset: 0x000D052C
	public override void vmethod_5(Dictionary<string, InputManager.InputKeyBinding> dictionary_0)
	{
		foreach (KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair in dictionary_0)
		{
			if (keyValuePair.Key == ControlAction.UIQuest.ToString())
			{
				this.mcQuestBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.UIInventory.ToString())
			{
				this.mcInventoryBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.Friend.ToString())
			{
				this.mcFriendBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.UISkillTree.ToString())
			{
				this.mcSkillBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.PVP.ToString())
			{
				this.mcPVPBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.Guild.ToString())
			{
				this.mcGuildBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
			else if (keyValuePair.Key == ControlAction.Group.ToString())
			{
				this.mcGroupBtn.DisplayObjectContainer_0.getChildByName<MovieClip>("textLabel").getChildByName<UnityTextField>("Iconname").text = keyValuePair.Value.primaryKey.ToString();
			}
		}
	}

	// Token: 0x06002CA3 RID: 11427 RVA: 0x000D25EC File Offset: 0x000D07EC
	public override void vmethod_7(PlayerProperties playerProperties_0)
	{
		base.vmethod_7(playerProperties_0);
		AvatarType avatarType = this._playerInfo.m_avatarDna.method_5();
		int num = MonoSingleton<LevelingManager>.Instance.method_5(avatarType, this._playerInfo.m_level);
		int num2 = MonoSingleton<LevelingManager>.Instance.method_4(avatarType, this._playerInfo.m_level);
		int num3 = MonoSingleton<LevelingManager>.Instance.method_4(avatarType, this._playerInfo.m_level + 1);
		int num4 = 120;
		if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (entityPlayer)
			{
				EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.vmethod_19();
				if (equipmentInventoryEntity != null)
				{
					num = equipmentInventoryEntity.vmethod_0();
					num4 = equipmentInventoryEntity.vmethod_7();
				}
			}
		}
		if (this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_5(num, num);
			this.mcPlayerInfo.method_6(num4, num4);
			this.mcPlayerInfo.method_7(this._playerInfo.m_avatarDna.method_5());
		}
		if (this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_7(this._playerInfo.m_exp - num2, num3 - num2);
			this.mcLevelInfo.method_8(this._playerInfo.m_level, this._playerInfo.m_name);
		}
	}

	// Token: 0x06002CA4 RID: 11428 RVA: 0x0001D8B1 File Offset: 0x0001BAB1
	public override void vmethod_6(int int_0)
	{
		base.vmethod_6(int_0);
		if (this._bActive && this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_10(this._iLevel);
		}
	}

	// Token: 0x06002CA5 RID: 11429 RVA: 0x0001D8DB File Offset: 0x0001BADB
	public override void vmethod_11(bool bool_0)
	{
		base.vmethod_11(bool_0);
		if (this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_8(bool_0);
		}
	}

	// Token: 0x06002CA6 RID: 11430 RVA: 0x000D2740 File Offset: 0x000D0940
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcPlayerInfo":
			this.mcPlayerInfo = new ShieldHealthPanel();
			this.mcPlayerInfo.method_0(movieClip);
			if (this.mcPlayerInfo != null && this._playerInfo != null)
			{
				AvatarType avatarType = this._playerInfo.m_avatarDna.method_5();
				this.mcPlayerInfo.method_6(120, 120);
				int num2 = MonoSingleton<LevelingManager>.Instance.method_5(avatarType, MonoSingleton<LevelingManager>.Instance.method_3(avatarType, this._playerInfo.m_level));
				this.mcPlayerInfo.method_5(num2, num2);
				this.mcPlayerInfo.method_7(this._playerInfo.m_avatarDna.method_5());
			}
			flag = true;
			break;
		case "mcExp":
			this.mcLevelInfo = new ExpLevelPanel();
			this.mcLevelInfo.method_0(movieClip);
			this.mcLevelInfo.method_7(0, 0);
			this.mcLevelInfo.method_8(0, string.Empty);
			flag = true;
			break;
		case "mcPVPBtn":
			this.mcPvP = movieClip;
			this.mcPvP.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_37));
			this.mcPvP.stopAll();
			this.mcPVPBtn = new GClass25();
			this.mcPVPBtn.method_0(movieClip);
			this.mcPVPBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.vmethod_25();
			flag = true;
			break;
		case "mcSurviveBtn":
			this.mcSurviveBtn = new GClass25();
			this.mcSurviveBtn.method_0(movieClip);
			this.mcSurviveBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_22));
			flag = true;
			break;
		case "mcQuestBtn":
			this.mcQuestBtn = new GClass25();
			this.mcQuestBtn.method_0(movieClip);
			this.mcQuestBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_24));
			flag = true;
			break;
		case "mcInventoryBtn":
		{
			this.mcInventoryBtn = new GClass25();
			this.mcInventoryBtn.method_0(movieClip);
			this.mcInventoryBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_23));
			MovieClip childByName = movieClip.getChildByName<MovieClip>("hint");
			if (childByName != null)
			{
				childByName.visible = false;
			}
			movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
			flag = true;
			break;
		}
		case "mcSocialBtn":
			this.mcSocialBtn = new GClass25();
			this.mcSocialBtn.method_0(movieClip);
			this.mcSocialBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_25));
			this.mcSocialBtn.Boolean_6 = true;
			flag = true;
			break;
		case "mcSkillBtn":
			this.mcSkillBtn = new GClass25();
			this.mcSkillBtn.method_0(movieClip);
			this.mcSkillBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
			this.mcSkillBtn.Boolean_6 = this._bSkillBtnEnable;
			movieClip.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_32));
			movieClip.addFrameScript("up", new EventDispatcher.EventCallback(this.method_32));
			this.vmethod_8(this._bSkillIconBlink);
			flag = true;
			break;
		case "mcFriendBtn":
			this.mcFriend = movieClip;
			this.mcFriend.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_36));
			this.mcFriendBtn = new GClass25();
			this.mcFriendBtn.method_0(movieClip);
			this.mcFriendBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_27));
			this.mcFriendBtn.Boolean_6 = true;
			flag = true;
			break;
		case "mcGroupBtn":
			this.mcGroup = movieClip;
			this.mcGroup.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_33));
			this.mcGroupBtn = new GClass25();
			this.mcGroupBtn.method_0(movieClip);
			this.mcGroupBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_28));
			this.mcGroupBtn.Boolean_6 = true;
			flag = true;
			break;
		case "mcGuildBtn":
			this.mcGuild = movieClip;
			this.mcGuild.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_35));
			this.mcGuildBtn = new GClass25();
			this.mcGuildBtn.method_0(movieClip);
			this.mcGuildBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_29));
			this.vmethod_24();
			flag = true;
			break;
		case "mcCashShopBtn":
			this.mcCashShopBtn = new GClass25();
			this.mcCashShopBtn.method_0(movieClip);
			this.mcCashShopBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_30));
			flag = true;
			break;
		case "mcAchievement":
			this.mcAchievement = movieClip;
			this.mcAchievement.addFrameScript("blinkEnd", new EventDispatcher.EventCallback(this.method_34));
			this.mcAchievementBtn = new GClass25();
			this.mcAchievementBtn.method_0(movieClip);
			this.mcAchievementBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_31));
			flag = true;
			break;
		}
		return flag;
	}

	// Token: 0x06002CA7 RID: 11431 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
	protected void method_21(CEvent cevent_0)
	{
		base.method_7();
	}

	// Token: 0x06002CA8 RID: 11432 RVA: 0x0001D900 File Offset: 0x0001BB00
	protected void method_22(CEvent cevent_0)
	{
		base.method_8();
	}

	// Token: 0x06002CA9 RID: 11433 RVA: 0x0001D908 File Offset: 0x0001BB08
	protected void method_23(CEvent cevent_0)
	{
		base.method_9();
	}

	// Token: 0x06002CAA RID: 11434 RVA: 0x0001D910 File Offset: 0x0001BB10
	protected void method_24(CEvent cevent_0)
	{
		base.method_10();
	}

	// Token: 0x06002CAB RID: 11435 RVA: 0x0001D918 File Offset: 0x0001BB18
	protected void method_25(CEvent cevent_0)
	{
		base.method_12();
	}

	// Token: 0x06002CAC RID: 11436 RVA: 0x0001D920 File Offset: 0x0001BB20
	protected void method_26(CEvent cevent_0)
	{
		base.method_11();
	}

	// Token: 0x06002CAD RID: 11437 RVA: 0x0001D928 File Offset: 0x0001BB28
	protected void method_27(CEvent cevent_0)
	{
		base.method_13();
	}

	// Token: 0x06002CAE RID: 11438 RVA: 0x0001D930 File Offset: 0x0001BB30
	protected void method_28(CEvent cevent_0)
	{
		base.method_14();
	}

	// Token: 0x06002CAF RID: 11439 RVA: 0x0001D938 File Offset: 0x0001BB38
	protected void method_29(CEvent cevent_0)
	{
		base.method_15();
	}

	// Token: 0x06002CB0 RID: 11440 RVA: 0x0001D940 File Offset: 0x0001BB40
	protected void method_30(CEvent cevent_0)
	{
		base.method_16();
	}

	// Token: 0x06002CB1 RID: 11441 RVA: 0x0001D948 File Offset: 0x0001BB48
	protected void method_31(CEvent cevent_0)
	{
		base.method_17();
	}

	// Token: 0x06002CB2 RID: 11442 RVA: 0x000D2D58 File Offset: 0x000D0F58
	protected void method_32(CEvent cevent_0)
	{
		MovieClip movieClip = this.mcSkillBtn.DisplayObjectContainer_0 as MovieClip;
		if (movieClip != null)
		{
			if (this._bSkillIconBlink)
			{
				movieClip.gotoAndPlay("actived");
			}
			else
			{
				movieClip.gotoAndPlay("up");
			}
		}
	}

	// Token: 0x06002CB3 RID: 11443 RVA: 0x000D2D9C File Offset: 0x000D0F9C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._panel != null && this._charInfoPanel != null)
		{
			base.vmethod_1(bool_0, bool_1);
			this._panel.DisplayObjectContainer_0.visible = this._bVisible;
			this._charInfoPanel.DisplayObjectContainer_0.visible = this._bVisible;
			return;
		}
	}

	// Token: 0x06002CB4 RID: 11444 RVA: 0x0001D950 File Offset: 0x0001BB50
	public override void vmethod_17()
	{
		if (this.mcGroup != null)
		{
			this.mcGroup.gotoAndPlay("up");
		}
	}

	// Token: 0x06002CB5 RID: 11445 RVA: 0x0001D96A File Offset: 0x0001BB6A
	public override void vmethod_18()
	{
		if (this.mcFriend != null)
		{
			this.mcFriend.gotoAndPlay("up");
		}
	}

	// Token: 0x06002CB6 RID: 11446 RVA: 0x0001D984 File Offset: 0x0001BB84
	public override void vmethod_12()
	{
		if (this.mcGroup != null)
		{
			this.mcGroup.gotoAndPlay("actived");
		}
	}

	// Token: 0x06002CB7 RID: 11447 RVA: 0x0001D99E File Offset: 0x0001BB9E
	public override void vmethod_20()
	{
		if (this.mcGuild != null)
		{
			this.mcGuild.gotoAndPlay("up");
		}
	}

	// Token: 0x06002CB8 RID: 11448 RVA: 0x0001D9B8 File Offset: 0x0001BBB8
	public override void vmethod_21()
	{
		if (this.mcAchievement != null)
		{
			AchievementManager.AchievementManager_0.bNewAchievementUnread = false;
			this.mcAchievement.stopAll();
			this.mcAchievement.gotoAndPlay("up");
		}
	}

	// Token: 0x06002CB9 RID: 11449 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
	protected void method_33(CEvent cevent_0)
	{
		this.vmethod_12();
	}

	// Token: 0x06002CBA RID: 11450 RVA: 0x0001D9F0 File Offset: 0x0001BBF0
	protected void method_34(CEvent cevent_0)
	{
		this.vmethod_16();
	}

	// Token: 0x06002CBB RID: 11451 RVA: 0x0001D9F8 File Offset: 0x0001BBF8
	public override void vmethod_13()
	{
		if (this.mcFriend != null)
		{
			this.mcFriend.gotoAndPlay("actived");
		}
	}

	// Token: 0x06002CBC RID: 11452 RVA: 0x0001DA12 File Offset: 0x0001BC12
	public override void vmethod_14()
	{
		if (this.mcPvP != null)
		{
			this.mcPvP.visible = true;
			this.mcPvP.gotoAndPlay("actived");
		}
	}

	// Token: 0x06002CBD RID: 11453 RVA: 0x0001DA38 File Offset: 0x0001BC38
	public override void vmethod_15()
	{
		if (this.mcGuild != null)
		{
			this.mcGuild.gotoAndPlay("actived");
		}
	}

	// Token: 0x06002CBE RID: 11454 RVA: 0x0001DA52 File Offset: 0x0001BC52
	public override void vmethod_16()
	{
		if (this.mcAchievement != null)
		{
			this.mcAchievement.stopAll();
			this.mcAchievement.gotoAndPlay("actived");
		}
	}

	// Token: 0x06002CBF RID: 11455 RVA: 0x0001DA77 File Offset: 0x0001BC77
	protected void method_35(CEvent cevent_0)
	{
		this.vmethod_15();
	}

	// Token: 0x06002CC0 RID: 11456 RVA: 0x0001DA7F File Offset: 0x0001BC7F
	public override void vmethod_19()
	{
		if (this.mcPvP != null)
		{
			FriendManager.smethod_0().m_bNewMessageUnread = false;
			this.mcPvP.stopAll();
			this.mcPvP.visible = false;
		}
	}

	// Token: 0x06002CC1 RID: 11457 RVA: 0x0001DAAB File Offset: 0x0001BCAB
	protected void method_36(CEvent cevent_0)
	{
		this.vmethod_13();
	}

	// Token: 0x06002CC2 RID: 11458 RVA: 0x0001DAB3 File Offset: 0x0001BCB3
	protected void method_37(CEvent cevent_0)
	{
		this.vmethod_14();
	}

	// Token: 0x06002CC3 RID: 11459 RVA: 0x0001DABB File Offset: 0x0001BCBB
	public override bool vmethod_22()
	{
		base.vmethod_22();
		return this.mcFriend.currentFrame >= this.mcFriend.getFrameLabel("actived");
	}

	// Token: 0x06002CC4 RID: 11460 RVA: 0x0001DAE4 File Offset: 0x0001BCE4
	public override bool vmethod_23()
	{
		base.vmethod_23();
		return this.mcPvP.visible && this.mcPvP.isPlaying;
	}

	// Token: 0x06002CC5 RID: 11461 RVA: 0x0001DB08 File Offset: 0x0001BD08
	public override void vmethod_24()
	{
		this.mcGuildBtn.Boolean_6 = true;
	}

	// Token: 0x06002CC6 RID: 11462 RVA: 0x000D2DF0 File Offset: 0x000D0FF0
	public override void vmethod_25()
	{
		if (this.mcPVPBtn == null)
		{
			return;
		}
		if (!this.mcPVPBtn.Boolean_1)
		{
			this.mcPVPBtn.Boolean_1 = true;
		}
		if (LobbyManager.smethod_0() != null && !LobbyManager.smethod_0().method_0())
		{
			if (GroupManager.smethod_0() != null && GroupManager.smethod_0().method_18() && !GroupManager.smethod_0().method_19())
			{
				if (this.mcPVPBtn.Boolean_6)
				{
					this.mcPVPBtn.Boolean_6 = false;
				}
			}
			else if (!this.mcPVPBtn.Boolean_6)
			{
				this.mcPVPBtn.Boolean_6 = true;
			}
		}
		else if (!this.mcPVPBtn.Boolean_6)
		{
			this.mcPVPBtn.Boolean_6 = true;
			if (GroupManager.smethod_0() != null && GroupManager.smethod_0().method_18() && !GroupManager.smethod_0().method_19())
			{
				this.vmethod_14();
			}
		}
	}

	// Token: 0x04001F67 RID: 8039
	private ShieldHealthPanel mcPlayerInfo;

	// Token: 0x04001F68 RID: 8040
	private ExpLevelPanel mcLevelInfo;

	// Token: 0x04001F69 RID: 8041
	private GClass25 mcQuestBtn;

	// Token: 0x04001F6A RID: 8042
	private GClass25 mcInventoryBtn;

	// Token: 0x04001F6B RID: 8043
	private GClass25 mcSocialBtn;

	// Token: 0x04001F6C RID: 8044
	private GClass25 mcSkillBtn;

	// Token: 0x04001F6D RID: 8045
	private GClass25 mcPVPBtn;

	// Token: 0x04001F6E RID: 8046
	private GClass25 mcSurviveBtn;

	// Token: 0x04001F6F RID: 8047
	private GClass25 mcFriendBtn;

	// Token: 0x04001F70 RID: 8048
	private GClass25 mcGroupBtn;

	// Token: 0x04001F71 RID: 8049
	private GClass25 mcGuildBtn;

	// Token: 0x04001F72 RID: 8050
	private GClass25 mcCashShopBtn;

	// Token: 0x04001F73 RID: 8051
	private GClass25 mcAchievementBtn;

	// Token: 0x04001F74 RID: 8052
	private MovieClip mcFriend;

	// Token: 0x04001F75 RID: 8053
	private MovieClip mcGroup;

	// Token: 0x04001F76 RID: 8054
	private MovieClip mcPvP;

	// Token: 0x04001F77 RID: 8055
	private MovieClip mcGuild;

	// Token: 0x04001F78 RID: 8056
	private MovieClip mcAchievement;

	// Token: 0x04001F79 RID: 8057
	private GClass51 _panel;

	// Token: 0x04001F7A RID: 8058
	private GClass51 _charInfoPanel;
}
