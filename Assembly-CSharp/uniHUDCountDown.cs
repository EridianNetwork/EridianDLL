using System;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x02000813 RID: 2067
public class uniHUDCountDown : HUDCountDownView
{
	// Token: 0x060037DE RID: 14302 RVA: 0x0002519E File Offset: 0x0002339E
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HUD_CountDown.swf", "Panel_CountDown", new FuncLoad(this.method_3));
	}

	// Token: 0x060037DF RID: 14303 RVA: 0x001020C4 File Offset: 0x001002C4
	private void method_3(MovieClip movieClip_0)
	{
		this._panel = new GClass51();
		this._panel.method_0(movieClip_0);
		this._panel.DisplayObjectContainer_0.visible = this._bVisible;
		this._timer = movieClip_0.getChildByName<MovieClip>("mcTime");
		this._extend = movieClip_0.getChildByName<MovieClip>("mcAddTime");
		this._failedEffect = movieClip_0.getChildByName<MovieClip>("mcFailed");
		this._textField = this._timer.getChildByName<UnityTextField>("textField");
		this._timer.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.OnEnterFrame));
		this._extendField = this._extend.getChildByName<MovieClip>("mcExtendTime").getChildByName<UnityTextField>("textField");
		this._currentLabel = this._labels[0];
		this._extend.stop();
		this._extend.visible = false;
		this._failedEffect.stop();
		this._failedEffect.visible = false;
		this._extend.addFrameScript("end", new EventDispatcher.EventCallback(this.OnMovieClipPlayed));
		this._failedEffect.addFrameScript("end", new EventDispatcher.EventCallback(this.OnMovieClipPlayed));
	}

	// Token: 0x060037E0 RID: 14304 RVA: 0x001021FC File Offset: 0x001003FC
	private void OnEnterFrame(CEvent e)
	{
		UnityTextField childByName = this._timer.getChildByName<UnityTextField>("textField");
		if (childByName != this._textField)
		{
			childByName.text = this._textField.text;
			this._textField = childByName;
		}
	}

	// Token: 0x060037E1 RID: 14305 RVA: 0x0010223C File Offset: 0x0010043C
	private void OnMovieClipPlayed(CEvent e)
	{
		MovieClip movieClip = e.currentTarget as MovieClip;
		movieClip.visible = false;
		movieClip.gotoAndStop(1);
	}

	// Token: 0x060037E2 RID: 14306 RVA: 0x00102268 File Offset: 0x00100468
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._panel != null)
		{
			base.vmethod_1(bool_0, bool_1);
			if (this._bVisible)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._panel);
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
			}
			this._panel.DisplayObjectContainer_0.visible = this._bVisible;
		}
	}

	// Token: 0x060037E3 RID: 14307 RVA: 0x001022DC File Offset: 0x001004DC
	public override void vmethod_6()
	{
		if (this._timer != null && this._currentLabel != this._labels[4])
		{
			this._currentLabel = this._labels[4];
			this._timer.gotoAndPlay(this._labels[4]);
			this._timer.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.OnEnterFrame));
		}
	}

	// Token: 0x060037E4 RID: 14308 RVA: 0x000251D0 File Offset: 0x000233D0
	public override void vmethod_8(int int_0)
	{
		this._extend.visible = true;
		this._extendField.text = Utility.smethod_6("+", Utility.smethod_8(int_0), "''");
		this._extend.gotoAndPlay(1);
	}

	// Token: 0x060037E5 RID: 14309 RVA: 0x0002520F File Offset: 0x0002340F
	public override void vmethod_7()
	{
		this._failedEffect.visible = true;
		this._failedEffect.gotoAndPlay(1);
	}

	// Token: 0x060037E6 RID: 14310 RVA: 0x00102344 File Offset: 0x00100544
	public override void vmethod_5(int int_0)
	{
		base.vmethod_5(int_0);
		if (this._textField != null)
		{
			if (!this._timer.hasEventListener(CEvent.ENTER_FRAME))
			{
				this._timer.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.OnEnterFrame));
			}
			int num = 0;
			if (int_0 >= 60)
			{
				num = 0;
			}
			else if (int_0 < 60 && int_0 > 30)
			{
				num = 1;
			}
			else if (int_0 <= 30 && int_0 > 0)
			{
				num = 2;
			}
			else if (int_0 == 0)
			{
				num = 3;
			}
			if (this._currentLabel != this._labels[num])
			{
				this._currentLabel = this._labels[num];
				this._timer.gotoAndPlay(this._labels[num]);
				if (num == 1)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("TimeRunLow_Warning_Core");
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).vmethod_22("TimeRunLow_Warning_1st", 3f);
				}
				else if (num == 2)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("TimeRunLow_Warning_Core");
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).vmethod_22("TimeRunLow_Warning_2nd", 3f);
				}
				else if (num == 3)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("TimeRunLow_Warning_Core");
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).vmethod_22("TimeRunLow_Over", 3f);
				}
			}
			int num2 = int_0 / 60;
			int num3 = int_0 % 60;
			string text = ((num2 >= 10) ? Utility.smethod_8(num2) : Utility.smethod_5("0", Utility.smethod_8(num2)));
			string text2 = ((num3 >= 10) ? Utility.smethod_8(num3) : Utility.smethod_5("0", Utility.smethod_8(num3)));
			string text3 = ((num > 1) ? Utility.smethod_5(text2, "''") : Utility.smethod_7(text, "'", text2, "''"));
			if (text3 != this._textField.text)
			{
				this._textField.text = text3;
				if (int_0 <= 10)
				{
					if ((num3 & 1) != 0)
					{
						(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Generic_Countdown_02");
					}
					else
					{
						(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Generic_Countdown_01");
					}
				}
			}
		}
	}

	// Token: 0x060037E7 RID: 14311 RVA: 0x00102578 File Offset: 0x00100778
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._timer != null)
		{
			this._timer.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.OnEnterFrame));
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		this._panel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("HUD_CountDown.swf");
	}

	// Token: 0x040026EE RID: 9966
	private GClass51 _panel;

	// Token: 0x040026EF RID: 9967
	private UnityTextField _textField;

	// Token: 0x040026F0 RID: 9968
	private UnityTextField _extendField;

	// Token: 0x040026F1 RID: 9969
	private MovieClip _timer;

	// Token: 0x040026F2 RID: 9970
	private MovieClip _extend;

	// Token: 0x040026F3 RID: 9971
	private MovieClip _failedEffect;

	// Token: 0x040026F4 RID: 9972
	private string[] _labels = new string[] { "3min", "1min", "last30sec", "over", "pause" };

	// Token: 0x040026F5 RID: 9973
	private string _currentLabel;
}
