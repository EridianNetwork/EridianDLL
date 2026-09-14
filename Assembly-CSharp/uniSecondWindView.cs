using System;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x0200089B RID: 2203
public class uniSecondWindView : SecondWindView
{
	// Token: 0x06003C75 RID: 15477 RVA: 0x0011DB4C File Offset: 0x0011BD4C
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_SecondWind.swf", "Panel_SecondWind", new FuncLoad(this.method_3));
		this._state = default(SecondWindState);
	}

	// Token: 0x06003C76 RID: 15478 RVA: 0x0011DB98 File Offset: 0x0011BD98
	private void method_3(MovieClip movieClip_0)
	{
		this._panel = new uniSecondWindView.SecondWindStatusPanel();
		this._panel.method_0(movieClip_0.getChildByName<MovieClip>("mcStatus"));
		this._panel.DisplayObjectContainer_0.visible = this._bVisible;
		this._panel.DisplayObjectContainer_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_4));
		this._secondWindEffect = new GClass51();
		this._secondWindEffect.method_0(movieClip_0.getChildByName<MovieClip>("mcSecondWind"));
		this._secondWindEffectMC = this._secondWindEffect.DisplayObjectContainer_0 as MovieClip;
		this._revivedEffect = new GClass51();
		this._revivedEffect.method_0(movieClip_0.getChildByName<MovieClip>("mcRevived"));
		this._revivedEffectMC = this._revivedEffect.DisplayObjectContainer_0 as MovieClip;
		this._secondWindEffectMC.stop();
		this._revivedEffectMC.stop();
		this._secondWindEffectMC.addFrameScript("end", new EventDispatcher.EventCallback(this.OnRevivedEffectPlayed));
		this._revivedEffectMC.addFrameScript("end", new EventDispatcher.EventCallback(this.OnSecondWindEffectPlayed));
		this._deathCountDown = new uniSecondWindView.CountDownPanel();
		this._deathCountDown.method_0(movieClip_0.getChildByName<MovieClip>("mcCountDown"));
		this._deathCountDown.DisplayObjectContainer_0.visible = this._bVisible;
	}

	// Token: 0x06003C77 RID: 15479 RVA: 0x00028C55 File Offset: 0x00026E55
	private void method_4(CEvent cevent_0)
	{
		this.currentTick++;
		if (this.currentTick > this.threhold)
		{
			this.vmethod_1(false, false);
		}
	}

	// Token: 0x06003C78 RID: 15480 RVA: 0x0011DCF8 File Offset: 0x0011BEF8
	public override void OnRevivedSelf()
	{
		base.OnRevivedSelf();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._secondWindEffect);
		if (this._secondWindEffect.DisplayObjectContainer_0 != null)
		{
			this._secondWindEffect.DisplayObjectContainer_0.visible = true;
			this._secondWindEffectMC.gotoAndPlay("start");
			this._panel.rewind = true;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_HUD_NearDeath_Cripple_SecondWind");
		}
	}

	// Token: 0x06003C79 RID: 15481 RVA: 0x0011DD7C File Offset: 0x0011BF7C
	public override void OnRevivedTeamMate()
	{
		base.OnRevivedTeamMate();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._revivedEffect);
		if (this._revivedEffect.DisplayObjectContainer_0 != null)
		{
			this._revivedEffect.DisplayObjectContainer_0.visible = true;
			this._revivedEffectMC.gotoAndPlay("start");
			this._panel.rewind = true;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_HUD_NearDeath_Down_Revive");
		}
	}

	// Token: 0x06003C7A RID: 15482 RVA: 0x0011DE00 File Offset: 0x0011C000
	public override void vmethod_6(bool bool_0, float float_0, float float_1, string string_0)
	{
		this._state.inRevived = bool_0;
		this._state.bleedPercent = float_0;
		this._state.revivedPercent = float_1;
		this._state.revivedTarget = string_0;
		this._state.inDeath = false;
		this._state.deathPercent = -1f;
		this.vmethod_5(ref this._state);
	}

	// Token: 0x06003C7B RID: 15483 RVA: 0x0011DE68 File Offset: 0x0011C068
	public override void vmethod_5(ref SecondWindState secondWindState_0)
	{
		base.vmethod_5(ref secondWindState_0);
		this.currentTick = 0;
		if (this._panel != null)
		{
			this._panel.DisplayObjectContainer_0.visible = !this._secondWindEffectMC.isPlaying && !this._revivedEffectMC.isPlaying;
			this._panel.method_8(ref secondWindState_0);
		}
		if (this._deathCountDown != null)
		{
			this._deathCountDown.DisplayObjectContainer_0.visible = !this._secondWindEffectMC.isPlaying && !this._revivedEffectMC.isPlaying;
			this._deathCountDown.method_6(ref secondWindState_0);
		}
	}

	// Token: 0x06003C7C RID: 15484 RVA: 0x00028C7B File Offset: 0x00026E7B
	private void OnSecondWindEffectPlayed(CEvent e)
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._secondWindEffect);
		this._secondWindEffectMC.stop();
	}

	// Token: 0x06003C7D RID: 15485 RVA: 0x00028CA2 File Offset: 0x00026EA2
	private void OnRevivedEffectPlayed(CEvent e)
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._revivedEffect);
		this._revivedEffectMC.stop();
	}

	// Token: 0x06003C7E RID: 15486 RVA: 0x0011DF08 File Offset: 0x0011C108
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._panel != null)
		{
			this._panel.DisplayObjectContainer_0.visible = this._bVisible;
			if (this._bVisible)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panel);
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
			}
		}
		if (this._deathCountDown != null)
		{
			this._deathCountDown.DisplayObjectContainer_0.visible = false;
			if (this._bVisible)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._deathCountDown);
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._deathCountDown);
			}
		}
	}

	// Token: 0x04002A81 RID: 10881
	private uniSecondWindView.SecondWindStatusPanel _panel;

	// Token: 0x04002A82 RID: 10882
	private GClass51 _secondWindEffect;

	// Token: 0x04002A83 RID: 10883
	private GClass51 _revivedEffect;

	// Token: 0x04002A84 RID: 10884
	private uniSecondWindView.CountDownPanel _deathCountDown;

	// Token: 0x04002A85 RID: 10885
	private MovieClip _secondWindEffectMC;

	// Token: 0x04002A86 RID: 10886
	private MovieClip _revivedEffectMC;

	// Token: 0x04002A87 RID: 10887
	private SecondWindState _state;

	// Token: 0x04002A88 RID: 10888
	private int threhold = 20;

	// Token: 0x04002A89 RID: 10889
	private int currentTick;

	// Token: 0x0200089C RID: 2204
	public class CountDownPanel : GClass51
	{
		// Token: 0x06003C80 RID: 15488 RVA: 0x0011DFD4 File Offset: 0x0011C1D4
		protected override void vmethod_0()
		{
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._deathStr = LocalizedString.smethod_0(new LocalizedString("WaitingForHelp"));
			this._rootMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x0011E024 File Offset: 0x0011C224
		private void method_5(CEvent cevent_0)
		{
			if (this._status.deathPercent < 0f)
			{
				return;
			}
			this._txtHint = this._rootMC.getChildByName<UnityTextField>("waitingRieveText");
			if (this._txtHint != null)
			{
				this._txtHint.text = this._deathStr;
			}
			int num = (int)Mathf.Ceil(this._status.deathPercent);
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("effect");
			if (childByName != null)
			{
				childByName.getChildByName<UnityTextField>("eridiumText").text = num.ToString();
			}
			MovieClip childByName2 = this._rootMC.getChildByName<MovieClip>("digits");
			if (childByName2 != null && this._LastTime != num)
			{
				childByName2.getChildByName<UnityTextField>("eridiumText").text = num.ToString();
				if (num == 0)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_HUD_NearDeath_Down_RespawnTimer_Zero");
				}
				else
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_HUD_NearDeath_Down_RespawnTimer_Display");
				}
			}
			this._LastTime = num;
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x0011E124 File Offset: 0x0011C324
		public void method_6(ref SecondWindState secondWindState_0)
		{
			this._status = secondWindState_0;
			this._rootMC.visible = secondWindState_0.inDeath;
			if (!this._rootMC.visible)
			{
				this._LastTime = 0;
				this._rootMC.gotoAndStop(1);
				return;
			}
			if (!this._rootMC.isPlaying)
			{
				this._LastTime = 0;
				this._rootMC.gotoAndPlay("start");
			}
		}

		// Token: 0x04002A8A RID: 10890
		private UnityTextField _txtHint;

		// Token: 0x04002A8B RID: 10891
		private MovieClip _rootMC;

		// Token: 0x04002A8C RID: 10892
		private string _deathStr;

		// Token: 0x04002A8D RID: 10893
		private SecondWindState _status;

		// Token: 0x04002A8E RID: 10894
		private int _LastTime;
	}

	// Token: 0x0200089D RID: 2205
	public class SecondWindStatusPanel : GClass51
	{
		// Token: 0x06003C84 RID: 15492 RVA: 0x0011E198 File Offset: 0x0011C398
		protected override void vmethod_0()
		{
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.addFrameScript("fight", new EventDispatcher.EventCallback(this.method_5));
			this._rootMC.addFrameScript("revive", new EventDispatcher.EventCallback(this.method_6));
			this._rootMC.gotoAndStop("off");
			this._crippleStr = LocalizedString.smethod_0(new LocalizedString("FightForYourLife"));
			this._reviveStr = LocalizedString.smethod_0(new LocalizedString("YouRevived"));
			this._fightHintStr = LocalizedString.smethod_0(new LocalizedString("OneKillRevive"));
			this._giveUpHintStr = LocalizedString.smethod_0(new LocalizedString("HoldERefuse"));
		}

		// Token: 0x06003C85 RID: 15493 RVA: 0x0011E254 File Offset: 0x0011C454
		private void method_5(CEvent cevent_0)
		{
			this._bleedProgressBar = this._rootMC.getChildByName<MovieClip>("bleedout");
			this._txtState = this._rootMC.getChildByName<UnityTextField>("textState");
			this._txtHint = this._rootMC.getChildByName<UnityTextField>("suicide");
			this._txtHint.text = this._fightHintStr;
			MaskManager.smethod_0().method_0(this._bleedProgressBar.getChildByName<MovieClip>("progressMasker"), new MovieClip[] { this._bleedProgressBar.getChildByName<MovieClip>("progressBar") });
			this.method_7();
		}

		// Token: 0x06003C86 RID: 15494 RVA: 0x0011E2F0 File Offset: 0x0011C4F0
		private void method_6(CEvent cevent_0)
		{
			this._bleedProgressBar = this._rootMC.getChildByName<MovieClip>("bleedout");
			this._txtState = this._rootMC.getChildByName<UnityTextField>("textState");
			this._revivedProgressBar = this._rootMC.getChildByName<MovieClip>("revivedProgressBar");
			this._txtHint = this._rootMC.getChildByName<MovieClip>("killRevive").getChildByName<MovieClip>("inner").getChildByName<UnityTextField>("killReviveText");
			this._txtHint.text = this._giveUpHintStr;
			MaskManager.smethod_0().method_0(this._bleedProgressBar.getChildByName<MovieClip>("progressMasker"), new MovieClip[] { this._bleedProgressBar.getChildByName<MovieClip>("progressBar") });
			MaskManager.smethod_0().method_0(this._revivedProgressBar.getChildByName<MovieClip>("progressMasker"), new MovieClip[] { this._revivedProgressBar.getChildByName<MovieClip>("progressBar") });
			this.method_7();
		}

		// Token: 0x06003C87 RID: 15495 RVA: 0x0011E3E8 File Offset: 0x0011C5E8
		private void method_7()
		{
			if (this._bleedProgressBar != null)
			{
				MaskManager.smethod_0().Update(this._bleedProgressBar.getChildByName<MovieClip>("progressMasker"));
			}
			if (this._revivedProgressBar != null)
			{
				MaskManager.smethod_0().Update(this._revivedProgressBar.getChildByName<MovieClip>("progressMasker"));
			}
		}

		// Token: 0x06003C88 RID: 15496 RVA: 0x0011E43C File Offset: 0x0011C63C
		public void method_8(ref SecondWindState secondWindState_0)
		{
			this._status = secondWindState_0;
			this._rootMC.visible = !this._status.inDeath;
			if (!this._rootMC.visible)
			{
				return;
			}
			if (this._rootMC != null)
			{
				if (this._status.inRevived)
				{
					this.rewind = true;
					this._rootMC.gotoAndStop("revive");
				}
				else
				{
					this._rootMC.gotoAndStop("fight");
					if (this.rewind)
					{
						this.rewind = false;
					}
				}
			}
			int num = Math.Max((int)(this._status.bleedPercent * 100f), 1);
			if (this._bleedProgressBar != null)
			{
				this._bleedProgressBar.gotoAndStop(num);
			}
			num = Math.Max((int)((1f - this._status.revivedPercent) * 100f), 1);
			if (this._revivedProgressBar != null)
			{
				this._revivedProgressBar.gotoAndStop(num);
			}
			this.method_7();
			if (this._txtState != null)
			{
				if (this._status.inRevived)
				{
					if (this._status.revivedTarget != null)
					{
						this._txtState.text = LocalizedString.smethod_0(new LocalizedString("YouReviving")) + " " + this._status.revivedTarget;
						if (this._txtHint != null)
						{
							this._txtHint.visible = false;
						}
					}
					else
					{
						this._txtState.text = this._reviveStr;
						if (this._txtHint != null)
						{
							this._txtHint.visible = true;
						}
					}
				}
				else
				{
					this._txtState.text = this._crippleStr;
				}
			}
		}

		// Token: 0x04002A8F RID: 10895
		private MovieClip _rootMC;

		// Token: 0x04002A90 RID: 10896
		private SecondWindState _status;

		// Token: 0x04002A91 RID: 10897
		private MovieClip _bleedProgressBar;

		// Token: 0x04002A92 RID: 10898
		private MovieClip _revivedProgressBar;

		// Token: 0x04002A93 RID: 10899
		private UnityTextField _txtState;

		// Token: 0x04002A94 RID: 10900
		private UnityTextField _txtHint;

		// Token: 0x04002A95 RID: 10901
		private string _crippleStr;

		// Token: 0x04002A96 RID: 10902
		private string _reviveStr;

		// Token: 0x04002A97 RID: 10903
		private string _fightHintStr;

		// Token: 0x04002A98 RID: 10904
		private string _giveUpHintStr;

		// Token: 0x04002A99 RID: 10905
		public bool rewind;
	}
}
