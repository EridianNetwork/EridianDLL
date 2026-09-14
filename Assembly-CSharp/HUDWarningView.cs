using System;
using ns0;

// Token: 0x02000706 RID: 1798
public class HUDWarningView : BaseView
{
	// Token: 0x06002F79 RID: 12153 RVA: 0x0001F345 File Offset: 0x0001D545
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x06002F7A RID: 12154 RVA: 0x0001F35D File Offset: 0x0001D55D
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x06002F7B RID: 12155 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(string string_0, string string_1)
	{
	}

	// Token: 0x06002F7C RID: 12156 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6()
	{
	}

	// Token: 0x06002F7D RID: 12157 RVA: 0x0001F375 File Offset: 0x0001D575
	public virtual void vmethod_7(string string_0 = "", Delegate_EventProc delegate_EventProc_0 = null, Delegate_EventProc delegate_EventProc_1 = null)
	{
		if (this._bVisible && this._CancelProc != null)
		{
			this._CancelProc();
		}
		this.Boolean_1 = true;
		this.m_strWarningText = string_0;
		this._ConfirmProc = delegate_EventProc_0;
		this._CancelProc = delegate_EventProc_1;
	}

	// Token: 0x06002F7E RID: 12158 RVA: 0x000D9F48 File Offset: 0x000D8148
	public virtual void vmethod_8(bool bool_0 = true)
	{
		if (bool_0)
		{
			if (this._CancelProc != null)
			{
				this._CancelProc();
			}
		}
		else if (this._ConfirmProc != null)
		{
			this._ConfirmProc();
		}
		this.Boolean_1 = false;
		this._ConfirmProc = null;
		this._CancelProc = null;
		this.m_strWarningText = string.Empty;
	}

	// Token: 0x06002F7F RID: 12159 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_9(string string_0 = "")
	{
	}

	// Token: 0x06002F80 RID: 12160 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_10()
	{
	}

	// Token: 0x04002123 RID: 8483
	protected Delegate_EventProc _ConfirmProc;

	// Token: 0x04002124 RID: 8484
	protected Delegate_EventProc _CancelProc;

	// Token: 0x04002125 RID: 8485
	protected string m_strWarningText = string.Empty;
}
