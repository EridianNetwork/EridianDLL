using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

using System.Runtime.CompilerServices;
// Token: 0x02000837 RID: 2103
public class uniHUDSkillStatusView : HUDSkillStatusView
{
	// Token: 0x060038DD RID: 14557 RVA: 0x00108C94 File Offset: 0x00106E94
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HUD.swf", "Skill", new FuncLoad(this.method_3));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HunterSkill.swf", "Panel_Whole", new FuncLoad(this.method_4));
	}

	// Token: 0x060038DE RID: 14558 RVA: 0x00025D01 File Offset: 0x00023F01
	private void method_3(MovieClip movieClip_0)
	{
		this._root = new GClass51();
		this._root.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._root);
		this.vmethod_13();
	}

	// Token: 0x060038DF RID: 14559 RVA: 0x00025D3C File Offset: 0x00023F3C
	private void method_4(MovieClip movieClip_0)
	{
		movieClip_0.visible = false;
		this._hunterSkillRoot = new uniHUDSkillStatusView.HunterSkillPanel();
		this._hunterSkillRoot.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._hunterSkillRoot);
	}

	// Token: 0x060038E0 RID: 14560 RVA: 0x00108CFC File Offset: 0x00106EFC
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		this._root = null;
		this.m_SkillPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._hunterSkillRoot);
		this._hunterSkillRoot = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("HUD.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("HunterSkill.swf");
	}

	// Token: 0x060038E1 RID: 14561 RVA: 0x00025D78 File Offset: 0x00023F78
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._root == null)
		{
			return;
		}
		base.vmethod_1(bool_0, bool_1);
		this._root.DisplayObjectContainer_0.visible = this._bVisible && this._iEarnedSkillPt > 0;
	}

	// Token: 0x060038E2 RID: 14562 RVA: 0x00025DAF File Offset: 0x00023FAF
	protected override void vmethod_5()
	{
		base.vmethod_5();
		if (this.m_SkillPanel == null)
		{
			return;
		}
		this.m_SkillPanel.method_10();
	}

	// Token: 0x060038E3 RID: 14563 RVA: 0x00025DCB File Offset: 0x00023FCB
	protected override void vmethod_6()
	{
		base.vmethod_6();
		if (this.m_SkillPanel != null)
		{
			this.m_SkillPanel.method_11();
		}
		if (this._curCharacterSkillID == SkillID.Hunter && this._hunterSkillRoot != null)
		{
			this._hunterSkillRoot.method_5();
		}
	}

	// Token: 0x060038E4 RID: 14564 RVA: 0x00025E02 File Offset: 0x00024002
	protected override void vmethod_7()
	{
		base.vmethod_7();
		if (this.m_SkillPanel == null)
		{
			return;
		}
		this.m_SkillPanel.method_14();
	}

	// Token: 0x060038E5 RID: 14565 RVA: 0x00025E1E File Offset: 0x0002401E
	protected override void vmethod_8()
	{
		base.vmethod_8();
		if (this.m_SkillPanel == null)
		{
			return;
		}
		this.m_SkillPanel.method_17();
	}

	// Token: 0x060038E6 RID: 14566 RVA: 0x00025E3A File Offset: 0x0002403A
	protected override void vmethod_9()
	{
		base.vmethod_9();
		if (this.m_SkillPanel != null)
		{
			this.m_SkillPanel.method_19();
		}
		if (this._curCharacterSkillID == SkillID.Hunter && this._hunterSkillRoot != null)
		{
			this._hunterSkillRoot.method_6();
		}
	}

	// Token: 0x060038E7 RID: 14567 RVA: 0x00025E71 File Offset: 0x00024071
	protected override void vmethod_10()
	{
		base.vmethod_10();
		if (this.m_SkillPanel == null)
		{
			return;
		}
		this.m_SkillPanel.method_22();
	}

	// Token: 0x060038E8 RID: 14568 RVA: 0x00025E8D File Offset: 0x0002408D
	protected override void vmethod_12()
	{
		base.vmethod_12();
		if (this.m_SkillPanel == null)
		{
			return;
		}
		this.m_SkillPanel.method_24();
	}

	// Token: 0x060038E9 RID: 14569 RVA: 0x00108D8C File Offset: 0x00106F8C
	public override void Update(SkillInfo CurSkillInfo)
	{
		base.Update(CurSkillInfo);
		if (!this._bInitialised && this.m_SkillPanel != null)
		{
			this.m_SkillPanel.SkillID_0 = CurSkillInfo.m_current_skillID;
			this.m_SkillPanel.method_10();
			this._bInitialised = true;
		}
		if (this.m_SkillPanel != null)
		{
			this.m_SkillPanel.SkillID_0 = CurSkillInfo.m_current_skillID;
			this.m_SkillPanel.ECurState_0 = this._curState;
			if (this._curState == HUDSkillStatusView.eCurState.Cooldown)
			{
				this.m_SkillPanel.Single_0 = CurSkillInfo.m_cooldownProgress;
			}
			else
			{
				this.m_SkillPanel.Single_0 = CurSkillInfo.m_skillProgress;
			}
		}
		if (this._curCharacterSkillID == SkillID.Hunter && this._hunterSkillRoot != null)
		{
			this._hunterSkillRoot.method_10(this._hunterMarkInfo);
		}
	}

	// Token: 0x060038EA RID: 14570 RVA: 0x00108E4C File Offset: 0x0010704C
	protected override void vmethod_13()
	{
		base.vmethod_13();
		if (this._root == null)
		{
			return;
		}
		MovieClip movieClip = this._root.DisplayObjectContainer_0 as MovieClip;
		bool flag = this._iEarnedSkillPt != 0;
		movieClip.visible = flag;
		if (this._iEarnedSkillPt > 0 && this._iEarnedSkillPt == this._iUnSpentSkillPt)
		{
			movieClip.gotoAndStop("SkillPtEarned");
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mcSkillPtAvailableIcon");
			if (childByName != null)
			{
				UnityTextField unityTextField = (UnityTextField)childByName.getChildByName<TextField>("SkillPoint");
				if (unityTextField != null)
				{
					string text = null;
					if (this._iUnSpentSkillPt > 0)
					{
						text = Utility.smethod_8(this._iUnSpentSkillPt);
					}
					unityTextField.text = text;
				}
			}
		}
		else
		{
			movieClip.gotoAndStop("SkillAvailable");
			if (this.m_SkillPanel == null)
			{
				this._skillStatusRootMC = movieClip.getChildByName<MovieClip>("mcSkill");
				if (this._skillStatusRootMC != null)
				{
					this._skillStatusRootMC.visible = true;
					this.m_SkillPanel = new uniHUDSkillStatusView.SkillRoot();
					this.m_SkillPanel.method_0(this._skillStatusRootMC);
					this.m_SkillPanel.method_10();
					this.m_SkillPanel.method_5(this._bSecActionUnlocked);
					this.m_SkillPanel.method_23(this._iEarnedSkillPt, this._iUnSpentSkillPt);
				}
			}
			else
			{
				this.m_SkillPanel.method_23(this._iEarnedSkillPt, this._iUnSpentSkillPt);
			}
		}
		if (this.m_SkillPanel != null)
		{
			this.m_SkillPanel.method_5(this._bSecActionUnlocked);
		}
	}

	// Token: 0x040027CB RID: 10187
	protected uniHUDSkillStatusView.SkillRoot m_SkillPanel;

	// Token: 0x040027CC RID: 10188
	protected GClass51 _root;

	// Token: 0x040027CD RID: 10189
	protected uniHUDSkillStatusView.HunterSkillPanel _hunterSkillRoot;

	// Token: 0x040027CE RID: 10190
	protected MovieClip _skillStatusRootMC;

	// Token: 0x02000838 RID: 2104
	public class SkillRoot : GClass51
	{
		// Token: 0x17000308 RID: 776
		// (set) Token: 0x060038EC RID: 14572 RVA: 0x00025EA9 File Offset: 0x000240A9
		public SkillID SkillID_0
		{
			set
			{
				this._curSKillID = value;
			}
		}

		// Token: 0x17000309 RID: 777
		// (set) Token: 0x060038ED RID: 14573 RVA: 0x00025EB2 File Offset: 0x000240B2
		public HUDSkillStatusView.eCurState ECurState_0
		{
			set
			{
				this._curSKillPhase = value;
			}
		}

		// Token: 0x1700030A RID: 778
		// (set) Token: 0x060038EE RID: 14574 RVA: 0x00025EBB File Offset: 0x000240BB
		public float Single_0
		{
			set
			{
				this._fCurProgressRate = value;
			}
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x00108FB8 File Offset: 0x001071B8
		protected override void vmethod_0()
		{
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			this._coolDownPhaseIcon = new uniHUDSkillStatusView.SmallSkillIconAnimation();
			this._onGoingPhaseIcon = new uniHUDSkillStatusView.SmallSkillIconAnimation();
			this._largeSkillIcon = new uniHUDSkillStatusView.LargeSkillIconAnimation();
			this._durationBar = new uniHUDSkillStatusView.DurationBar();
			this._upperBoomAnimation = new uniHUDSkillStatusView.BoomOutCombo();
			this._lowerBoomAnimation = new uniHUDSkillStatusView.BoomOutCombo();
			this._rootMC.addFrameScript("fade in", new EventDispatcher.EventCallback(this.method_21));
			this._rootMC.addFrameScript("BarFadeIn", new EventDispatcher.EventCallback(this.method_13));
			this._rootMC.addFrameScript("LoopEnd", new EventDispatcher.EventCallback(this.method_15));
			this._rootMC.addFrameScript("ActiveAnima", new EventDispatcher.EventCallback(this.method_6));
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x00025EC4 File Offset: 0x000240C4
		public void method_5(bool bool_0)
		{
			this._bSecondSkillUnlocked = bool_0;
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x0010908C File Offset: 0x0010728C
		protected void method_6(CEvent cevent_0)
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcSmallMask");
			MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			if (childByName != null && childByName2 != null)
			{
				childByName.visible = false;
				childByName2.removeAllEventListeners(CEvent.ENTER_FRAME);
				childByName2.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
			}
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x001090EC File Offset: 0x001072EC
		protected void method_7(CEvent cevent_0)
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcSmallMask");
			MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			if (childByName != null && childByName2 != null)
			{
				childByName2.clipRect = childByName.getBounds(childByName2).rect;
				childByName.visible = false;
			}
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x0010913C File Offset: 0x0010733C
		protected void method_8()
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcLargeMaskCover");
			if (childByName != null)
			{
				childByName.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
			}
			MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("mcLargeMask");
			if (childByName2 != null)
			{
				childByName2.visible = false;
			}
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x00109190 File Offset: 0x00107390
		protected void method_9(CEvent cevent_0)
		{
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcLargeMask");
			if (childByName != null)
			{
				childByName.visible = false;
				MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation");
				if (childByName2 != null)
				{
					childByName2.clipRect = childByName.getBounds(childByName2).rect;
				}
				MovieClip childByName3 = this._rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon");
				if (childByName3 != null)
				{
					childByName3.clipRect = childByName.getBounds(childByName3).rect;
				}
				MovieClip childByName4 = this._rootMC.getChildByName<MovieClip>("mcDurationBar");
				if (childByName4 != null)
				{
					childByName4.clipRect = childByName.getBounds(childByName4).rect;
				}
			}
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x0010922C File Offset: 0x0010742C
		public void method_10()
		{
			this._rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._rootMC.gotoAndPlay("normal");
			this._bSecondSkillUsed = false;
			this._f1stSkillRateWhenCallBack = 0f;
			this._coolDownPhaseIcon.method_0(this._rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon"));
			this._coolDownPhaseIcon.method_6(true);
			this._coolDownPhaseIcon.method_9(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			this._coolDownPhaseIcon.method_7(this._iUnSpentSkillPt);
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x001092B8 File Offset: 0x001074B8
		public void method_11()
		{
			this._rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._rootMC.gotoAndPlay("ActiveAnima");
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_12));
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			this._coolDownPhaseIcon.method_0(childByName);
			this._coolDownPhaseIcon.method_9(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			this._coolDownPhaseIcon.method_6(true);
			this._coolDownPhaseIcon.method_7(this._iUnSpentSkillPt);
			this._coolDownPhaseIcon.method_10(0f);
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x00025ECD File Offset: 0x000240CD
		protected void method_12(CEvent cevent_0)
		{
			this._onGoingPhaseIcon.method_8(this._bSecondSkillUnlocked);
			this._durationBar.method_6(100);
		}

		// Token: 0x060038F8 RID: 14584 RVA: 0x00109360 File Offset: 0x00107560
		protected void method_13(CEvent cevent_0)
		{
			this._largeSkillIcon.method_0(this._rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation"));
			this._largeSkillIcon.method_5(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			this._onGoingPhaseIcon.method_0(this._rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon"));
			this._onGoingPhaseIcon.method_6(true);
			this._onGoingPhaseIcon.method_9(HUDSkillStatusView.eCurState.SecondAction, this._curSKillID);
			this._onGoingPhaseIcon.method_8(this._bSecondSkillUnlocked);
			this._durationBar.method_0(this._rootMC.getChildByName<MovieClip>("mcDurationBar"));
			this._durationBar.method_6(0);
			this._durationBar.method_7(false);
			this.method_8();
		}

		// Token: 0x060038F9 RID: 14585 RVA: 0x00109420 File Offset: 0x00107620
		public void method_14()
		{
			this._rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_16));
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation");
			if (childByName != null)
			{
				this._largeSkillIcon.method_0(childByName);
				this._largeSkillIcon.method_5(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			}
			MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon");
			if (childByName2 != null)
			{
				this._onGoingPhaseIcon.method_0(this._rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon"));
				this._onGoingPhaseIcon.method_6(true);
				this._onGoingPhaseIcon.method_9(HUDSkillStatusView.eCurState.SecondAction, this._curSKillID);
			}
			MovieClip childByName3 = this._rootMC.getChildByName<MovieClip>("mcDurationBar");
			if (childByName3 != null)
			{
				this._durationBar.method_0(this._rootMC.getChildByName<MovieClip>("mcDurationBar"));
				this._durationBar.method_6(0);
				this._durationBar.method_7(false);
			}
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x00025EED File Offset: 0x000240ED
		protected void method_15(CEvent cevent_0)
		{
			this._rootMC.gotoAndPlay("LoopStart");
		}

		// Token: 0x060038FB RID: 14587 RVA: 0x00109524 File Offset: 0x00107724
		protected void method_16(CEvent cevent_0)
		{
			this._onGoingPhaseIcon.method_8(this._bSecondSkillUnlocked);
			int num = (int)(this._fCurProgressRate * 100f);
			if (this._fCurProgressRate != 0f && this._fCurProgressRate != 1f && this._f1stSkillRateWhenCallBack <= this._fCurProgressRate)
			{
				num = 100 - num;
				this._durationBar.method_6(num);
			}
		}

		// Token: 0x060038FC RID: 14588 RVA: 0x0010958C File Offset: 0x0010778C
		public void method_17()
		{
			this._rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_18));
			this._onGoingPhaseIcon.method_8(false);
			this._largeSkillIcon.method_6(this._curSKillID);
			this._bSecondSkillUsed = true;
			if (this._curSKillID == SkillID.Berserk)
			{
				this._durationBar.method_7(true);
			}
		}

		// Token: 0x060038FD RID: 14589 RVA: 0x00025EFF File Offset: 0x000240FF
		protected void method_18(CEvent cevent_0)
		{
			this._onGoingPhaseIcon.method_8(false);
		}

		// Token: 0x060038FE RID: 14590 RVA: 0x00109600 File Offset: 0x00107800
		public void method_19()
		{
			this._durationBar.method_6(0);
			this._rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_20));
			this._rootMC.gotoAndPlay("boom out");
			int num = 100 - (int)(this._fCurProgressRate * 100f);
			this._upperBoomAnimation.method_0(this._rootMC.getChildByName<MovieClip>("mcUpperBoomAni"));
			this._upperBoomAnimation.method_6(this._bSecondSkillUsed, this._curSKillID);
			this._upperBoomAnimation.method_5(num);
			this._upperBoomAnimation.Boolean_0 = !this._bSecondSkillUsed && this._bSecondSkillUnlocked;
			this._lowerBoomAnimation.method_0(this._rootMC.getChildByName<MovieClip>("mcLowerBoomAni"));
			this._lowerBoomAnimation.method_5(num);
			this._lowerBoomAnimation.method_6(this._bSecondSkillUsed, this._curSKillID);
			this._lowerBoomAnimation.Boolean_0 = !this._bSecondSkillUsed && this._bSecondSkillUnlocked;
			this._coolDownPhaseIcon.method_7(this._iUnSpentSkillPt);
		}

		// Token: 0x060038FF RID: 14591 RVA: 0x00025F0D File Offset: 0x0002410D
		protected void method_20(CEvent cevent_0)
		{
			this._coolDownPhaseIcon.method_10(this._fCurProgressRate);
			this._coolDownPhaseIcon.method_9(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			this._coolDownPhaseIcon.method_6(false);
		}

		// Token: 0x06003900 RID: 14592 RVA: 0x00109734 File Offset: 0x00107934
		protected void method_21(CEvent cevent_0)
		{
			this._coolDownPhaseIcon.method_0(this._rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon"));
			this._coolDownPhaseIcon.method_10(this._fCurProgressRate);
			this._coolDownPhaseIcon.method_9(HUDSkillStatusView.eCurState.FirstAction, this._curSKillID);
			this._coolDownPhaseIcon.method_6(false);
			this._coolDownPhaseIcon.method_7(this._iUnSpentSkillPt);
		}

		// Token: 0x06003901 RID: 14593 RVA: 0x00025F3E File Offset: 0x0002413E
		public void method_22()
		{
			this._durationBar.method_7(true);
		}

		// Token: 0x06003902 RID: 14594 RVA: 0x00025F4C File Offset: 0x0002414C
		public void method_23(int int_0, int int_1)
		{
			this._iUnSpentSkillPt = int_1;
			this._iEarnedSkillPt = int_0;
			if (this._coolDownPhaseIcon != null)
			{
				this._coolDownPhaseIcon.method_7(int_1);
			}
		}

		// Token: 0x06003903 RID: 14595 RVA: 0x00025F70 File Offset: 0x00024170
		public void method_24()
		{
			GClass61.GClass61_0.GInterface3_0.imethod_0(AudioEvents.smethod_0(AudioEventName.UI_Skill_Ready));
			this.method_10();
			this._coolDownPhaseIcon.method_11();
		}

		// Token: 0x040027CF RID: 10191
		protected uniHUDSkillStatusView.SmallSkillIconAnimation _coolDownPhaseIcon;

		// Token: 0x040027D0 RID: 10192
		protected uniHUDSkillStatusView.SmallSkillIconAnimation _onGoingPhaseIcon;

		// Token: 0x040027D1 RID: 10193
		protected uniHUDSkillStatusView.LargeSkillIconAnimation _largeSkillIcon;

		// Token: 0x040027D2 RID: 10194
		protected uniHUDSkillStatusView.DurationBar _durationBar;

		// Token: 0x040027D3 RID: 10195
		protected uniHUDSkillStatusView.BoomOutCombo _upperBoomAnimation;

		// Token: 0x040027D4 RID: 10196
		protected uniHUDSkillStatusView.BoomOutCombo _lowerBoomAnimation;

		// Token: 0x040027D5 RID: 10197
		protected SkillID _curSKillID;

		// Token: 0x040027D6 RID: 10198
		protected HUDSkillStatusView.eCurState _curSKillPhase;

		// Token: 0x040027D7 RID: 10199
		protected MovieClip _rootMC;

		// Token: 0x040027D8 RID: 10200
		protected float _f1stSkillRateWhenCallBack;

		// Token: 0x040027D9 RID: 10201
		protected float _fCurProgressRate;

		// Token: 0x040027DA RID: 10202
		protected int _iUnSpentSkillPt;

		// Token: 0x040027DB RID: 10203
		protected int _iEarnedSkillPt;

		// Token: 0x040027DC RID: 10204
		protected bool _bSecondSkillUnlocked;

		// Token: 0x040027DD RID: 10205
		protected bool _bSecondSkillUsed;
	}

	// Token: 0x02000839 RID: 2105
	public class SmallSkillIconAnimation : GClass51
	{
		protected TextField _textKeyTip;

		protected TextField _textSkillPont;

		protected SkillIcon _skillIcon;

		protected MovieClip _rootMC;

		protected int _iUnspentPt;

		protected eCurState _eCurState;

		protected SkillID _skillID;

		[CompilerGenerated]
		private static Dictionary<string, int> f__switch_map1B;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (f__switch_map1B == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcIcon", 0);
					f__switch_map1B = dictionary;
				}
				if (f__switch_map1B.TryGetValue(name, out var value) && value == 0)
				{
					_skillIcon = new SkillIcon();
					_skillIcon.method_0(movieClip);
					result = true;
				}
			}
			return result;
		}

		public void method_5(bool bool_0)
		{
			TextField childByName = _rootMC.getChildByName<TextField>("SkillPoint");
			if (childByName != null)
			{
				childByName.visible = bool_0;
			}
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			_rootMC = displayObjectContainer_0 as MovieClip;
			_rootMC.visible = false;
			_rootMC.addFrameScript("animaEnd", method_12);
			method_6(bool_0: false);
		}

		public void method_6(bool bool_0)
		{
			TextField childByName = _rootMC.getChildByName<TextField>("KeyTip");
			if (childByName != null)
			{
				childByName.visible = bool_0;
			}
		}

		public void method_7(int int_0)
		{
			_iUnspentPt = int_0;
			if (_rootMC == null)
			{
				return;
			}
			TextField childByName = _rootMC.getChildByName<TextField>("SkillPoint");
			if (childByName != null)
			{
				string text = null;
				if (int_0 > 0)
				{
					text = Convert.ToString(int_0);
				}
				childByName.text = text;
			}
		}

		public void method_8(bool bool_0)
		{
			if (_rootMC != null)
			{
				_rootMC.visible = bool_0;
			}
		}

		public void method_9(eCurState eCurState_0, SkillID skillID_0)
		{
			_eCurState = eCurState_0;
			_skillID = skillID_0;
			if (_skillIcon != null)
			{
				_skillIcon.method_5(eCurState_0, skillID_0);
			}
		}

		public void method_10(float float_0)
		{
			int num = (int)(float_0 * 50f);
			if (displayObjectContainer_0 is MovieClip)
			{
				(displayObjectContainer_0 as MovieClip).gotoAndStop(num + 3);
			}
		}

		public void method_11()
		{
			_rootMC.gotoAndPlay("coolDownEnd");
		}

		protected void method_12(CEvent cevent_0)
		{
			_rootMC.gotoAndStop("normal");
		}
	}
	// Token: 0x0200083A RID: 2106
	public class LargeSkillIconAnimation : GClass51
	{
		protected SkillIcon _skillIcon;

		protected SkillID _skillID;

		[CompilerGenerated]
		private static Dictionary<string, int> f__switch_map1C;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (f__switch_map1C == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcSkillIcon", 0);
					f__switch_map1C = dictionary;
				}
				if (f__switch_map1C.TryGetValue(name, out var value) && value == 0)
				{
					_skillIcon = new SkillIcon();
					_skillIcon.method_4(movieClip, "normal");
					_skillIcon.method_4(movieClip, "iconA");
					_skillIcon.method_4(movieClip, "iconAEnd");
					_skillIcon.method_4(movieClip, "iconB");
					_skillIcon.method_4(movieClip, "iconBEnd");
					result = true;
				}
			}
			return result;
		}

		public void method_5(eCurState eCurState_0, SkillID skillID_0)
		{
			if (_skillIcon != null)
			{
				_skillIcon.method_5(eCurState_0, skillID_0);
			}
		}

		public void method_6(SkillID skillID_0)
		{
			if (displayObjectContainer_0 is MovieClip movieClip)
			{
				movieClip.gotoAndPlay("iconA");
				movieClip.addFrameScript("iconB", method_7);
				_skillID = skillID_0;
			}
		}

		protected void method_7(CEvent cevent_0)
		{
			_skillIcon.method_5(eCurState.SecondAction, _skillID);
		}
	}
	// Token: 0x0200083B RID: 2107
	public class SkillIcon : GClass51
	{
		// Token: 0x06003915 RID: 14613 RVA: 0x00109A40 File Offset: 0x00107C40
		public void method_5(HUDSkillStatusView.eCurState eCurState_0, SkillID skillID_0)
		{
			MovieClip movieClip = this.displayObjectContainer_0 as MovieClip;
			string text = skillID_0.ToString() + eCurState_0.ToString();
			movieClip.gotoAndStop(text);
		}
	}

	// Token: 0x0200083C RID: 2108
	public class DurationBar : GClass51
	{
		protected MovieClip m_shakeEffect;

		protected MovieClip _rootMC;

		protected MovieClip _maskMC;

		protected MovieClip _slaveMC;

		[CompilerGenerated]
		private static Dictionary<string, int> f__switch_map1D;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (f__switch_map1D == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcShakeEffect", 0);
					f__switch_map1D = dictionary;
				}
				if (f__switch_map1D.TryGetValue(name, out var value) && value == 0)
				{
					m_shakeEffect = movieClip;
					result = true;
				}
			}
			return result;
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			_rootMC = displayObjectContainer_0 as MovieClip;
			_rootMC.addEventListener(CEvent.ENTER_FRAME, method_5);
			_rootMC.stopAll();
			_rootMC.gotoAndStop(1);
			_maskMC = _rootMC.getChildByName<MovieClip>("mcMask");
			_slaveMC = _rootMC.getChildByName<MovieClip>("mcSlave");
			if (_maskMC != null)
			{
				_maskMC.visible = false;
			}
		}

		protected void method_5(CEvent cevent_0)
		{
			if (_slaveMC == null)
			{
				_slaveMC = _rootMC.getChildByName<MovieClip>("mcSlave");
			}
			if (_maskMC == null)
			{
				_maskMC = _rootMC.getChildByName<MovieClip>("mcMask");
			}
			if (_maskMC != null && _slaveMC != null)
			{
				_slaveMC.clipRect = _maskMC.getBounds(_slaveMC).rect;
			}
		}

		public void method_6(int int_0)
		{
			if (_rootMC != null)
			{
				_rootMC.gotoAndStop(int_0 + 1);
			}
			if (_maskMC != null && _slaveMC != null)
			{
				_slaveMC.clipRect = _maskMC.getBounds(_slaveMC).rect;
			}
		}

		public void method_7(bool bool_0)
		{
			if (m_shakeEffect != null)
			{
				if (bool_0)
				{
					m_shakeEffect.gotoAndPlay("shake");
					m_shakeEffect.addFrameScript("shakeEnd", method_8);
				}
				else
				{
					m_shakeEffect.gotoAndPlay("normal");
				}
			}
		}

		protected void method_8(CEvent cevent_0)
		{
			m_shakeEffect.gotoAndPlay("shake");
		}
	}
	// Token: 0x0200083D RID: 2109
	public class BoomOutCombo : GClass51
	{
		// Token: 0x1700030B RID: 779
		// (set) Token: 0x0600391E RID: 14622 RVA: 0x00109CA4 File Offset: 0x00107EA4
		public bool Boolean_0
		{
			set
			{
				this._bSmallIconVisible = value;
				if (this._smallIcon != null)
				{
					MovieClip movieClip = this._smallIcon.DisplayObjectContainer_0 as MovieClip;
					if (movieClip != null)
					{
						movieClip.visible = this._bSmallIconVisible;
					}
				}
			}
		}

		// Token: 0x0600391F RID: 14623 RVA: 0x00109CE0 File Offset: 0x00107EE0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcLargeIcon":
				this._largeIcon = new uniHUDSkillStatusView.LargeSkillIconAnimation();
				this._largeIcon.method_0(movieClip);
				flag = true;
				break;
			case "mcDurationBar":
				this._durationBar = new uniHUDSkillStatusView.DurationBar();
				this._durationBar.method_0(movieClip);
				flag = true;
				break;
			case "mcSmallIcon":
				this._smallIcon = new uniHUDSkillStatusView.SmallSkillIconAnimation();
				this._smallIcon.method_0(movieClip);
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x06003920 RID: 14624 RVA: 0x00026034 File Offset: 0x00024234
		public void method_5(int int_0)
		{
			this._durationBar.method_6(int_0);
		}

		// Token: 0x06003921 RID: 14625 RVA: 0x00109DB0 File Offset: 0x00107FB0
		public void method_6(bool bool_0, SkillID skillID_0)
		{
			if (bool_0)
			{
				this._largeIcon.method_5(HUDSkillStatusView.eCurState.SecondAction, skillID_0);
				this._smallIcon.method_8(false);
			}
			else
			{
				this._largeIcon.method_5(HUDSkillStatusView.eCurState.FirstAction, skillID_0);
				this._smallIcon.method_8(true);
				this._smallIcon.method_9(HUDSkillStatusView.eCurState.SecondAction, skillID_0);
			}
		}

		// Token: 0x040027EE RID: 10222
		protected uniHUDSkillStatusView.LargeSkillIconAnimation _largeIcon;

		// Token: 0x040027EF RID: 10223
		protected uniHUDSkillStatusView.SmallSkillIconAnimation _smallIcon;

		// Token: 0x040027F0 RID: 10224
		protected uniHUDSkillStatusView.DurationBar _durationBar;

		// Token: 0x040027F1 RID: 10225
		protected bool _bSmallIconVisible;
	}

	// Token: 0x0200083E RID: 2110
	public class HunterSkillPanel : GClass51
	{
		// Token: 0x06003923 RID: 14627 RVA: 0x00109E04 File Offset: 0x00108004
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = this.displayObjectContainer_0 as MovieClip;
			if (this._rootMC != null)
			{
				this._aniRootMC = this._rootMC.getChildByName<MovieClip>("mcAniRoot");
				if (this._aniRootMC != null)
				{
					this._aniRootMC.addFrameScript("fadeinEnd", new EventDispatcher.EventCallback(this.method_7));
					this._aniRootMC.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_8));
					this._aniRootMC.addFrameScript("appear", new EventDispatcher.EventCallback(this.method_9));
					this._aniRootMC.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_9));
				}
			}
		}

		// Token: 0x06003924 RID: 14628 RVA: 0x00026060 File Offset: 0x00024260
		public void method_5()
		{
			if (this._rootMC != null)
			{
				this._rootMC.visible = true;
			}
			if (this._aniRootMC != null)
			{
				this._aniRootMC.gotoAndPlay(1);
				this._bOnAnimation = true;
			}
		}

		// Token: 0x06003925 RID: 14629 RVA: 0x00026096 File Offset: 0x00024296
		public void method_6()
		{
			if (this._rootMC != null)
			{
				this._rootMC.visible = true;
			}
			if (this._aniRootMC != null)
			{
				this._aniRootMC.gotoAndPlay("fadeout");
				this._bOnAnimation = true;
			}
		}

		// Token: 0x06003926 RID: 14630 RVA: 0x000260CB File Offset: 0x000242CB
		protected void method_7(CEvent cevent_0)
		{
			this._bOnAnimation = false;
		}

		// Token: 0x06003927 RID: 14631 RVA: 0x000260D4 File Offset: 0x000242D4
		protected void method_8(CEvent cevent_0)
		{
			this._rootMC.visible = false;
			this._bOnAnimation = false;
		}

		// Token: 0x06003928 RID: 14632 RVA: 0x00109EC8 File Offset: 0x001080C8
		protected void method_9(CEvent cevent_0)
		{
			if (this._aniRootMC != null)
			{
				MovieClip childByName = this._aniRootMC.getChildByName<MovieClip>("mcPowerFrame_Left");
				MovieClip childByName2 = this._aniRootMC.getChildByName<MovieClip>("mcPowerFrame_Right");
				if (childByName != null)
				{
					this._processBarLeft.method_0(childByName);
				}
				if (childByName2 != null)
				{
					this._processBarRight.method_0(childByName2);
				}
			}
		}

		// Token: 0x06003929 RID: 14633 RVA: 0x00109F20 File Offset: 0x00108120
		public void method_10(MarkManager.BroadcastMarkedInfo broadcastMarkedInfo_0)
		{
			if (this._aniRootMC != null && !this._bOnAnimation)
			{
				float num = MarkManager.MarkManager_0.method_2();
				this._processBarLeft.method_6(num);
				this._processBarRight.method_6(num);
				return;
			}
		}

		// Token: 0x040027F3 RID: 10227
		protected MovieClip _rootMC;

		// Token: 0x040027F4 RID: 10228
		protected MovieClip _aniRootMC;

		// Token: 0x040027F5 RID: 10229
		protected uniHUDSkillStatusView.HunterSkillPanel.BarMask _processBarLeft = new uniHUDSkillStatusView.HunterSkillPanel.BarMask();

		// Token: 0x040027F6 RID: 10230
		protected uniHUDSkillStatusView.HunterSkillPanel.BarMask _processBarRight = new uniHUDSkillStatusView.HunterSkillPanel.BarMask();

		// Token: 0x040027F7 RID: 10231
		protected bool _bOnAnimation;

		// Token: 0x0200083F RID: 2111
		protected class BarMask : GClass51
		{
			// Token: 0x0600392B RID: 14635 RVA: 0x00109F64 File Offset: 0x00108164
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this._mcMask = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcMask");
				this._mcSlave = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcSlave");
				if (this._mcSlave != null)
				{
					this._mcSlave.removeAllEventListeners(CEvent.ENTER_FRAME);
					this._mcSlave.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
				}
			}

			// Token: 0x0600392C RID: 14636 RVA: 0x000260E9 File Offset: 0x000242E9
			protected void method_5(CEvent cevent_0)
			{
				if (this._mcSlave != null && this._mcMask != null)
				{
					this._mcSlave.clipRect = this._mcMask.getBounds(this._mcSlave).rect;
					this._mcMask.visible = false;
				}
			}

			// Token: 0x0600392D RID: 14637 RVA: 0x00109FDC File Offset: 0x001081DC
			public void method_6(float float_0)
			{
				if (base.DisplayObjectContainer_0 != null)
				{
					MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
					if (movieClip != null)
					{
						int num = (int)(float_0 * 30f);
						movieClip.gotoAndStop(num);
					}
				}
			}

			// Token: 0x040027F8 RID: 10232
			protected MovieClip _mcMask;

			// Token: 0x040027F9 RID: 10233
			protected MovieClip _mcSlave;
		}
	}
}
