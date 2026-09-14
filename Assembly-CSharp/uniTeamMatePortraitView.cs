using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x020008AD RID: 2221
public class uniTeamMatePortraitView : HUDTeamMatePortraitView
{
	// Token: 0x06003CFE RID: 15614 RVA: 0x0002923E File Offset: 0x0002743E
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Team_mate_protrait.swf", "TeamMateInfo", new FuncLoad(this.method_3));
	}

	// Token: 0x06003CFF RID: 15615 RVA: 0x00121360 File Offset: 0x0011F560
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._TeamMatePanel);
		this._TeamMatePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Team_mate_protrait.swf");
	}

	// Token: 0x06003D00 RID: 15616 RVA: 0x00029270 File Offset: 0x00027470
	private void method_3(MovieClip movieClip_0)
	{
		this._TeamMatePanel = new uniTeamMatePortraitView.TeamMatePortraitPanel();
		this._TeamMatePanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._TeamMatePanel);
	}

	// Token: 0x06003D01 RID: 15617 RVA: 0x000292A5 File Offset: 0x000274A5
	public override void vmethod_6(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
	{
		base.vmethod_6(playerInfoSync_0, int_0, int_1);
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_8(playerInfoSync_0, int_0, int_1);
		}
	}

	// Token: 0x06003D02 RID: 15618 RVA: 0x000292C6 File Offset: 0x000274C6
	public override void vmethod_7(Presence presence_0, int int_0, int int_1)
	{
		base.vmethod_7(presence_0, int_0, int_1);
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_6(presence_0, int_0, int_1);
		}
	}

	// Token: 0x06003D03 RID: 15619 RVA: 0x000292E7 File Offset: 0x000274E7
	public override void vmethod_5(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
	{
		base.vmethod_5(playerInfoSync_0, int_0, int_1);
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_7(playerInfoSync_0, int_0, int_1);
		}
	}

	// Token: 0x06003D04 RID: 15620 RVA: 0x00029308 File Offset: 0x00027508
	public override void vmethod_8()
	{
		base.vmethod_8();
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_5();
		}
	}

	// Token: 0x06003D05 RID: 15621 RVA: 0x00029323 File Offset: 0x00027523
	public override void vmethod_9()
	{
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_9();
		}
	}

	// Token: 0x06003D06 RID: 15622 RVA: 0x00029338 File Offset: 0x00027538
	public override void vmethod_10()
	{
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.method_10();
		}
	}

	// Token: 0x06003D07 RID: 15623 RVA: 0x0002934D File Offset: 0x0002754D
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._TeamMatePanel != null)
		{
			this._TeamMatePanel.Boolean_0 = this._bVisible;
		}
	}

	// Token: 0x04002AFC RID: 11004
	private uniTeamMatePortraitView.TeamMatePortraitPanel _TeamMatePanel;

	// Token: 0x020008AE RID: 2222
	private class SecondWindInfo : GClass51
	{
		// Token: 0x06003D09 RID: 15625 RVA: 0x001213B0 File Offset: 0x0011F5B0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_SecondInfo = this.displayObjectContainer_0 as MovieClip;
			this.mcDyingIcon = this.mc_SecondInfo.getChildByName<MovieClip>("mcCrippleIcon");
			this.mcRevivedIcon = this.mc_SecondInfo.getChildByName<MovieClip>("mcRevivedIcon");
			this.mcDeadIcon = this.mc_SecondInfo.getChildByName<MovieClip>("mcDeadIcon");
			this.mcHealthBar = this.mc_SecondInfo.getChildByName<MovieClip>("mcHealth");
			this.mcBar = this.mcHealthBar.getChildByName<MovieClip>("mc_hpbar");
			this.mcDyingIcon.stop();
			this.mcHealthBar.stop();
			Rectangle bounds = this.mcHealthBar.getBounds(this.mcHealthBar.getChildByName<MovieClip>("mcProgressMask"));
			this.mcHealthBar.clipRect = bounds.rect;
			this.mc_SecondInfo.visible = false;
		}

		// Token: 0x06003D0A RID: 15626 RVA: 0x00121494 File Offset: 0x0011F694
		public void Update(PlayerInfoSync playerInfo)
		{
			if (this.mc_SecondInfo == null)
			{
				return;
			}
			this.mc_SecondInfo.visible = true;
			DisplayObject displayObject = this.mcDyingIcon;
			this.mcRevivedIcon.visible = false;
			this.mcDeadIcon.visible = false;
			displayObject.visible = false;
			EntityPlayer entityPlayer = playerInfo.GetEntity() as EntityPlayer;
			if (entityPlayer != null)
			{
				EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = playerInfo.GetEntity().vmethod_19() as EquipmentInventoryEntityPlayer;
				this.mcHealthBar.visible = entityPlayer.method_67() || entityPlayer.method_65() || entityPlayer.method_149();
				this.mcRevivedIcon.visible = entityPlayer.method_149();
				this.mcDyingIcon.visible = !this.mcRevivedIcon.visible && entityPlayer.method_67();
				this.mcDeadIcon.visible = !this.mcRevivedIcon.visible && entityPlayer.method_65();
				if (entityPlayer.method_67())
				{
					this.mcBar.gotoAndStop("RED");
					float num = (float)equipmentInventoryEntityPlayer.method_3() / (float)equipmentInventoryEntityPlayer.method_4();
					this.mcHealthBar.gotoAndStop((int)(100f * (1f - num)));
				}
				if (entityPlayer.method_149())
				{
					this.mcBar.gotoAndStop("GREEN");
					float num2 = (float)equipmentInventoryEntityPlayer.method_7() / (float)equipmentInventoryEntityPlayer.method_8();
					this.mcHealthBar.gotoAndStop((int)(100f * (1f - num2)));
				}
				if (entityPlayer.method_65())
				{
					this.mcBar.gotoAndStop("YELLOW");
					float num3 = entityPlayer.method_66();
					this.mcHealthBar.gotoAndStop((int)(100f * (1f - num3)));
				}
				if (this.mcDyingIcon.visible && !this.mcDyingIcon.isPlaying)
				{
					this.mcDyingIcon.gotoAndPlay(1);
				}
				else if (!this.mcDyingIcon.visible)
				{
					this.mcDyingIcon.stop();
				}
			}
		}

		// Token: 0x04002AFD RID: 11005
		public MovieClip mc_SecondInfo;

		// Token: 0x04002AFE RID: 11006
		private MovieClip mcDyingIcon;

		// Token: 0x04002AFF RID: 11007
		private MovieClip mcDeadIcon;

		// Token: 0x04002B00 RID: 11008
		private MovieClip mcRevivedIcon;

		// Token: 0x04002B01 RID: 11009
		private MovieClip mcHealthBar;

		// Token: 0x04002B02 RID: 11010
		private MovieClip mcBar;
	}

	// Token: 0x020008AF RID: 2223
	private class TeamMateInfo : GClass51
	{
		// Token: 0x06003D0C RID: 15628 RVA: 0x0012168C File Offset: 0x0011F88C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_MateInfo = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_MateInfo == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TeamMateInfo onInit() 'mc_MateInfo' is null! TeamMateInfo won't work!!!");
				return;
			}
			this.mc_Status = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus");
			this.m_NameField = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("playername");
			this.m_LevelField = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("level");
			this.mc_Icon = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon");
			this.mc_Sheild = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield");
			this.mc_Health = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health");
			this.mc_Captain = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("mc_captain");
			if (this.mc_Health != null)
			{
				this.mc_Shark = this.mc_Health.getChildByName<MovieClip>("mc_Shark");
			}
			this.mc_MateInfo.visible = false;
			this.mc_Captain.visible = false;
			this.mc_MateInfo.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_8));
			this.mc_MateInfo.addFrameScript("off", new EventDispatcher.EventCallback(this.method_12));
			this.m_bInited = true;
			this.displayObjectContainer_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x00121874 File Offset: 0x0011FA74
		private void method_5(int int_0, int int_1)
		{
			if (this.mc_Sheild == null)
			{
				return;
			}
			if (!this.mc_Sheild.visible)
			{
				this.mc_Sheild.visible = true;
			}
			if (int_0 == 0)
			{
				this.mc_Sheild.gotoAndStop(100);
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				if (num == this.m_LastSheild)
				{
					if (this.mc_Sheild.currentFrame != 101 - num)
					{
						this.mc_Sheild.gotoAndStop(101 - num);
					}
					return;
				}
				this.mc_Sheild.gotoAndStop(101 - num);
				this.m_LastSheild = num;
			}
		}

		// Token: 0x06003D0E RID: 15630 RVA: 0x0012191C File Offset: 0x0011FB1C
		private void method_6(int int_0, int int_1)
		{
			if (this.mc_Health == null)
			{
				return;
			}
			if (int_0 == 0)
			{
				if (this.mc_Health.getCurrentFrame() <= 100)
				{
					this.mc_Health.gotoAndPlay(101);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				if (num == this.m_LastHP)
				{
					if (this.mc_Health.currentFrame != 101 - num)
					{
						this.mc_Health.gotoAndStop(101 - num);
					}
					return;
				}
				this.mc_Health.gotoAndStop(101 - num);
				if (this.m_LastHP > 40 && num <= 40)
				{
					if (this.mc_Shark == null)
					{
						this.mc_Shark = this.mc_Health.getChildByName<MovieClip>("mc_shark");
						this.mc_Shark.play();
					}
					else if (!this.mc_Shark.isPlaying)
					{
						this.mc_Shark.play();
					}
				}
				this.m_LastHP = num;
			}
		}

		// Token: 0x06003D0F RID: 15631 RVA: 0x00029395 File Offset: 0x00027595
		private void method_7(CEvent cevent_0)
		{
			GroupManager.smethod_0().method_22(this.m_nCharacterId);
		}

		// Token: 0x06003D10 RID: 15632 RVA: 0x00121A10 File Offset: 0x0011FC10
		private void method_8(CEvent cevent_0)
		{
			try
			{
				this.m_NameField = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("playername");
				this.m_LevelField = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<TextField>("level");
				this.mc_Icon = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon");
				this.mc_Sheild = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield");
				this.mc_Health = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health");
				this.mc_Captain = this.mc_MateInfo.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("mc_captain");
			}
			catch
			{
			}
		}

		// Token: 0x06003D11 RID: 15633 RVA: 0x00121B30 File Offset: 0x0011FD30
		public void Update(PlayerInfoSync playerInfo)
		{
			if (!this.m_bInited)
			{
				return;
			}
			if (playerInfo == null)
			{
				this.mc_MateInfo.visible = false;
				return;
			}
			this.m_nCharacterId = playerInfo.m_characterId;
			if (!this.mc_MateInfo.visible)
			{
				this.mc_MateInfo.visible = true;
				this.method_10(playerInfo);
				this.mc_MateInfo.gotoAndPlay("IN");
				this.mc_MateInfo.addFrameScript("off", new EventDispatcher.EventCallback(this.method_12));
			}
			if (!this.mc_MateInfo.isPlaying)
			{
				this.method_10(playerInfo);
			}
		}

		// Token: 0x06003D12 RID: 15634 RVA: 0x00121BCC File Offset: 0x0011FDCC
		public void Update(Presence presence)
		{
			if (!this.m_bInited)
			{
				return;
			}
			if (presence == null)
			{
				this.mc_MateInfo.visible = false;
				return;
			}
			this.m_nCharacterId = presence.mCharacterId;
			if (!this.mc_MateInfo.visible)
			{
				this.mc_MateInfo.visible = true;
				this.method_9(presence);
				this.mc_MateInfo.gotoAndPlay("IN");
				this.mc_MateInfo.addFrameScript("off", new EventDispatcher.EventCallback(this.method_12));
			}
			if (!this.mc_MateInfo.isPlaying)
			{
				this.method_9(presence);
			}
		}

		// Token: 0x06003D13 RID: 15635 RVA: 0x00121C60 File Offset: 0x0011FE60
		private void method_9(Presence presence_0)
		{
			try
			{
				if (presence_0.mIsOnline)
				{
					if (this.mc_Status.currentLabel == "death")
					{
						this.mc_Status.gotoAndStop("normal");
						this.m_NameField.textFormat.color = Color.white;
						this.m_LevelField.textFormat.color = Color.white;
					}
				}
				else if (this.mc_Status.currentLabel == "normal")
				{
					this.mc_Status.gotoAndStop("death");
					this.m_NameField.textFormat.color = Color.gray;
					this.m_LevelField.textFormat.color = Color.gray;
				}
				if (GroupManager.smethod_0().m_nLeaderId == presence_0.mCharacterId)
				{
					this.mc_Captain.visible = true;
				}
				else
				{
					this.mc_Captain.visible = false;
				}
				if (this.m_NameField.text != presence_0.mCharacterName)
				{
					this.m_NameField.text = presence_0.mCharacterName;
				}
				string text = Utility.smethod_5("LV:", Utility.smethod_8(presence_0.mCharacterLevel));
				if (this.m_LevelField.text != text)
				{
					this.m_LevelField.text = text;
				}
				AvatarType mAvatarType = presence_0.mAvatarType;
				if (this.mc_Icon.getFrameLabel(mAvatarType.ToString()) != this.mc_Icon.currentFrame)
				{
					this.mc_Icon.gotoAndStop(mAvatarType.ToString());
				}
				PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncByCharId(presence_0.mCharacterId);
				if (playerInfoSync != null)
				{
					EntityShield entityShield = playerInfoSync.GetEntity().vmethod_18();
					if (entityShield != null)
					{
						this.method_5(100, 100);
					}
					else
					{
						this.method_5(0, 100);
					}
					if (!this.mc_Sheild.visible)
					{
						this.mc_Sheild.visible = true;
					}
					if (!this.mc_Health.visible)
					{
						this.mc_Health.visible = true;
					}
					this.method_6(100, 100);
				}
				else
				{
					this.mc_Sheild.visible = false;
					this.mc_Health.visible = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06003D14 RID: 15636 RVA: 0x00121EA4 File Offset: 0x001200A4
		private void method_10(PlayerInfoSync playerInfoSync_0)
		{
			try
			{
				if (GroupManager.smethod_0().m_nLeaderId == playerInfoSync_0.m_characterId)
				{
					this.mc_Captain.visible = true;
				}
				else
				{
					this.mc_Captain.visible = false;
				}
				if (this.m_NameField.text != playerInfoSync_0.m_name)
				{
					this.m_NameField.text = playerInfoSync_0.m_name;
				}
				EquipmentInventoryEntity equipmentInventoryEntity = playerInfoSync_0.GetEntity().vmethod_19();
				if (equipmentInventoryEntity != null)
				{
					AvatarType avatarType = playerInfoSync_0.m_avatarDna.method_5();
					if (this.m_LevelField.text != "LV:" + MonoSingleton<LevelingManager>.Instance.method_3(avatarType, playerInfoSync_0.m_exp))
					{
						this.m_LevelField.text = "LV:" + MonoSingleton<LevelingManager>.Instance.method_3(avatarType, playerInfoSync_0.m_exp);
					}
					if (this.mc_Icon.getFrameLabel(playerInfoSync_0.m_avatarDna.method_5().ToString()) != this.mc_Icon.currentFrame)
					{
						this.mc_Icon.gotoAndStop(playerInfoSync_0.m_avatarDna.method_5().ToString());
					}
					this.method_5(equipmentInventoryEntity.vmethod_6(), equipmentInventoryEntity.vmethod_7());
					this.method_6(equipmentInventoryEntity.vmethod_4(), equipmentInventoryEntity.vmethod_0());
				}
			}
			catch
			{
				if (playerInfoSync_0 == null)
				{
					this.method_11();
				}
			}
		}

		// Token: 0x06003D15 RID: 15637 RVA: 0x00122028 File Offset: 0x00120228
		public void method_11()
		{
			if (!this.m_bInited)
			{
				return;
			}
			if (this.mc_MateInfo.visible && !this.mc_MateInfo.isPlaying)
			{
				this.mc_MateInfo.gotoAndPlay("out");
				this.mc_MateInfo.addFrameScript("off", new EventDispatcher.EventCallback(this.method_12));
			}
		}

		// Token: 0x06003D16 RID: 15638 RVA: 0x000293A7 File Offset: 0x000275A7
		public void method_12(CEvent cevent_0)
		{
			this.mc_MateInfo.visible = false;
			this.mc_MateInfo.removeFrameScript("off", new EventDispatcher.EventCallback(this.method_12));
		}

		// Token: 0x04002B03 RID: 11011
		public MovieClip mc_MateInfo;

		// Token: 0x04002B04 RID: 11012
		private TextField m_NameField;

		// Token: 0x04002B05 RID: 11013
		private TextField m_LevelField;

		// Token: 0x04002B06 RID: 11014
		private MovieClip mc_Icon;

		// Token: 0x04002B07 RID: 11015
		private MovieClip mc_Sheild;

		// Token: 0x04002B08 RID: 11016
		private MovieClip mc_Health;

		// Token: 0x04002B09 RID: 11017
		private MovieClip mc_Shark;

		// Token: 0x04002B0A RID: 11018
		private MovieClip mc_Captain;

		// Token: 0x04002B0B RID: 11019
		private MovieClip mc_Status;

		// Token: 0x04002B0C RID: 11020
		private int m_LastSheild = 1000;

		// Token: 0x04002B0D RID: 11021
		private int m_LastHP = 1000;

		// Token: 0x04002B0E RID: 11022
		private bool m_bInited;

		// Token: 0x04002B0F RID: 11023
		private int m_nCharacterId = -1;
	}

	// Token: 0x020008B0 RID: 2224
	private class TeamMatePortraitPanel : GClass51
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06003D19 RID: 15641 RVA: 0x00029406 File Offset: 0x00027606
		// (set) Token: 0x06003D18 RID: 15640 RVA: 0x000293F0 File Offset: 0x000275F0
		public virtual bool Boolean_0
		{
			get
			{
				return this.mcSelf != null && this.mcSelf.visible;
			}
			set
			{
				if (this.mcSelf != null)
				{
					this.mcSelf.visible = value;
				}
			}
		}

		// Token: 0x06003D1A RID: 15642 RVA: 0x00122088 File Offset: 0x00120288
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TeamMatePortraitPanel onInit() 'mcSelf' is null! TeamMatePortraitPanel won't work!!!");
				return;
			}
			uniTeamMatePortraitView.TeamMateInfo teamMateInfo = new uniTeamMatePortraitView.TeamMateInfo();
			teamMateInfo.method_0(this.mcSelf.getChildByName<MovieClip>("MateInfo1"));
			uniTeamMatePortraitView.TeamMateInfo teamMateInfo2 = new uniTeamMatePortraitView.TeamMateInfo();
			teamMateInfo2.method_0(this.mcSelf.getChildByName<MovieClip>("MateInfo2"));
			uniTeamMatePortraitView.TeamMateInfo teamMateInfo3 = new uniTeamMatePortraitView.TeamMateInfo();
			teamMateInfo3.method_0(this.mcSelf.getChildByName<MovieClip>("MateInfo3"));
			this.m_TeamInfoList.Add(teamMateInfo);
			this.m_TeamInfoList.Add(teamMateInfo2);
			this.m_TeamInfoList.Add(teamMateInfo3);
			uniTeamMatePortraitView.SecondWindInfo secondWindInfo = new uniTeamMatePortraitView.SecondWindInfo();
			secondWindInfo.method_0(this.mcSelf.getChildByName<MovieClip>("SecondWindInfo1"));
			uniTeamMatePortraitView.SecondWindInfo secondWindInfo2 = new uniTeamMatePortraitView.SecondWindInfo();
			secondWindInfo2.method_0(this.mcSelf.getChildByName<MovieClip>("SecondWindInfo2"));
			uniTeamMatePortraitView.SecondWindInfo secondWindInfo3 = new uniTeamMatePortraitView.SecondWindInfo();
			secondWindInfo3.method_0(this.mcSelf.getChildByName<MovieClip>("SecondWindInfo3"));
			this.m_SecondWindInfoList.Add(secondWindInfo);
			this.m_SecondWindInfoList.Add(secondWindInfo2);
			this.m_SecondWindInfoList.Add(secondWindInfo3);
			this.m_bInitilized = true;
		}

		// Token: 0x06003D1B RID: 15643 RVA: 0x001221C4 File Offset: 0x001203C4
		public void method_5()
		{
			if (this.m_bInitilized)
			{
				for (int i = 0; i < this.m_TeamInfoList.Count; i++)
				{
					if (this.m_TeamInfoList[i].mc_MateInfo.visible)
					{
						this.m_TeamInfoList[i].method_11();
					}
				}
				for (int j = 0; j < this.m_SecondWindInfoList.Count; j++)
				{
					this.m_SecondWindInfoList[j].mc_SecondInfo.visible = false;
				}
			}
		}

		// Token: 0x06003D1C RID: 15644 RVA: 0x00122248 File Offset: 0x00120448
		public void method_6(Presence presence_0, int int_0, int int_1)
		{
			if (!this.m_bInitilized)
			{
				return;
			}
			if (presence_0 != null && int_0 <= this.m_TeamInfoList.Count - 1)
			{
				this.m_TeamInfoList[int_0].Update(presence_0);
				if (int_0 == int_1 - 1 && int_1 != this.m_TeamInfoList.Count)
				{
					for (int i = int_1; i < this.m_TeamInfoList.Count; i++)
					{
						this.m_TeamInfoList[i].method_11();
					}
				}
				return;
			}
		}

		// Token: 0x06003D1D RID: 15645 RVA: 0x001222C0 File Offset: 0x001204C0
		public void method_7(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
		{
			if (this.m_SecondWindInfoList.Count > 0)
			{
				for (int i = 0; i < this.m_SecondWindInfoList.Count; i++)
				{
					this.m_SecondWindInfoList[i].mc_SecondInfo.visible = false;
				}
			}
			if (!this.m_bInitilized)
			{
				return;
			}
			if (playerInfoSync_0 == null || int_0 > this.m_TeamInfoList.Count - 1)
			{
				return;
			}
			if (playerInfoSync_0.GetEntity() == null)
			{
				return;
			}
			if (playerInfoSync_0.GetEntity().vmethod_19() == null)
			{
				return;
			}
			this.m_SecondWindInfoList[int_0].Update(playerInfoSync_0);
		}

		// Token: 0x06003D1E RID: 15646 RVA: 0x00122360 File Offset: 0x00120560
		public void method_8(PlayerInfoSync playerInfoSync_0, int int_0, int int_1)
		{
			if (!this.m_bInitilized)
			{
				return;
			}
			if (playerInfoSync_0 == null || int_0 > this.m_TeamInfoList.Count - 1)
			{
				return;
			}
			if (playerInfoSync_0.GetEntity() == null)
			{
				return;
			}
			if (playerInfoSync_0.GetEntity().vmethod_19() == null)
			{
				return;
			}
			this.m_TeamInfoList[int_0].Update(playerInfoSync_0);
			if (int_0 == int_1 - 1 && int_1 != this.m_TeamInfoList.Count)
			{
				for (int i = int_1; i < this.m_TeamInfoList.Count; i++)
				{
					this.m_TeamInfoList[i].method_11();
				}
			}
		}

		// Token: 0x06003D1F RID: 15647 RVA: 0x00122404 File Offset: 0x00120604
		public void method_9()
		{
			for (int i = 0; i < this.m_TeamInfoList.Count; i++)
			{
				this.m_TeamInfoList[i].mc_MateInfo.y += 40f;
			}
		}

		// Token: 0x06003D20 RID: 15648 RVA: 0x0012244C File Offset: 0x0012064C
		public void method_10()
		{
			for (int i = 0; i < this.m_TeamInfoList.Count; i++)
			{
				this.m_TeamInfoList[i].mc_MateInfo.y -= 40f;
			}
		}

		// Token: 0x04002B10 RID: 11024
		protected MovieClip mcSelf;

		// Token: 0x04002B11 RID: 11025
		private bool m_bInitilized;

		// Token: 0x04002B12 RID: 11026
		private List<uniTeamMatePortraitView.TeamMateInfo> m_TeamInfoList = new List<uniTeamMatePortraitView.TeamMateInfo>();

		// Token: 0x04002B13 RID: 11027
		private List<uniTeamMatePortraitView.SecondWindInfo> m_SecondWindInfoList = new List<uniTeamMatePortraitView.SecondWindInfo>();
	}
}
