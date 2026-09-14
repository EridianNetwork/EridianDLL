using System;

// Token: 0x020006A9 RID: 1705
public class BaseView
{
	// Token: 0x06002C67 RID: 11367 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002C68 RID: 11368 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnTestGUI()
	{
	}

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06002C69 RID: 11369 RVA: 0x0001D506 File Offset: 0x0001B706
	public virtual bool Boolean_0
	{
		get
		{
			return this._bActive;
		}
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06002C6A RID: 11370 RVA: 0x0001D50E File Offset: 0x0001B70E
	// (set) Token: 0x06002C6B RID: 11371 RVA: 0x0001D516 File Offset: 0x0001B716
	public virtual bool Boolean_1
	{
		get
		{
			return this._bVisible;
		}
		set
		{
			if (this.Boolean_0 && this._bVisible != value)
			{
				this.vmethod_1(value, false);
			}
		}
	}

	// Token: 0x06002C6C RID: 11372 RVA: 0x0001D531 File Offset: 0x0001B731
	protected virtual void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this._bVisible != bool_0)
		{
			this._bVisible = bool_0;
			if (this._funcVisibleChange != null)
			{
				this._funcVisibleChange(this, this._bVisible, bool_1);
			}
		}
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06002C6D RID: 11373 RVA: 0x0001D55E File Offset: 0x0001B75E
	public string String_0
	{
		get
		{
			if (this._sName == null)
			{
				this._sName = this.ToString();
			}
			return this._sName;
		}
	}

	// Token: 0x06002C6E RID: 11374 RVA: 0x0001D57A File Offset: 0x0001B77A
	public void method_0(bool bool_0)
	{
		this.vmethod_1(bool_0, true);
	}

	// Token: 0x06002C6F RID: 11375 RVA: 0x0001D584 File Offset: 0x0001B784
	public void method_1(ViewVisbleChangeFunc viewVisbleChangeFunc_0)
	{
		this._funcVisibleChange = (ViewVisbleChangeFunc)Delegate.Combine(this._funcVisibleChange, viewVisbleChangeFunc_0);
	}

	// Token: 0x06002C70 RID: 11376 RVA: 0x0001D59D File Offset: 0x0001B79D
	public void method_2(ViewVisbleChangeFunc viewVisbleChangeFunc_0)
	{
		this._funcVisibleChange = (ViewVisbleChangeFunc)Delegate.Remove(this._funcVisibleChange, viewVisbleChangeFunc_0);
	}

	// Token: 0x06002C71 RID: 11377 RVA: 0x0001D5B6 File Offset: 0x0001B7B6
	public virtual void vmethod_2()
	{
		this._bActive = true;
	}

	// Token: 0x06002C72 RID: 11378 RVA: 0x0001D5BF File Offset: 0x0001B7BF
	public virtual void vmethod_3()
	{
		if (this._bVisible)
		{
			this.method_0(false);
		}
		this._bActive = false;
	}

	// Token: 0x06002C73 RID: 11379 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool OnScreenResized()
	{
		return false;
	}

	// Token: 0x06002C74 RID: 11380 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_4()
	{
		return false;
	}

	// Token: 0x06002C75 RID: 11381 RVA: 0x0001D5D7 File Offset: 0x0001B7D7
	public virtual bool OnShortCutCMD(string command)
	{
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x04001F53 RID: 8019
	protected bool _bActive;

	// Token: 0x04001F54 RID: 8020
	protected bool _bVisible;

	// Token: 0x04001F55 RID: 8021
	protected string _sName;

	// Token: 0x04001F56 RID: 8022
	private ViewVisbleChangeFunc _funcVisibleChange;
}
