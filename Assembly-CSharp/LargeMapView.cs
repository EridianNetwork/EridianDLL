using System;
using ns0;
using UnityEngine;

// Token: 0x02000713 RID: 1811
public class LargeMapView : BaseView
{
	// Token: 0x06003009 RID: 12297 RVA: 0x0001F7A4 File Offset: 0x0001D9A4
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "UIMap");
	}

	// Token: 0x0600300A RID: 12298 RVA: 0x000DB824 File Offset: 0x000D9A24
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._bInited = false;
		this._tex = null;
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
	}

	// Token: 0x0600300B RID: 12299 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x04002163 RID: 8547
	protected bool _bInited;

	// Token: 0x04002164 RID: 8548
	protected Texture2D _tex;

	// Token: 0x04002165 RID: 8549
	protected Vector2 _v2MapTextureSize = new Vector2(0f, 0f);
}
