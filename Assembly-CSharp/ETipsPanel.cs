using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x02000812 RID: 2066
public class ETipsPanel : GClass51
{
	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060037D9 RID: 14297 RVA: 0x00025130 File Offset: 0x00023330
	// (set) Token: 0x060037D8 RID: 14296 RVA: 0x00025122 File Offset: 0x00023322
	public virtual bool Boolean_0
	{
		get
		{
			return this.mcOnlyChild.visible;
		}
		set
		{
			this.mcOnlyChild.visible = value;
		}
	}

	// Token: 0x060037DA RID: 14298 RVA: 0x0002513D File Offset: 0x0002333D
	public virtual void vmethod_2(int int_0)
	{
		if (int_0 >= 0 && int_0 <= this.TYPE_FRAME_MAP.Length)
		{
			this.mcOnlyChild.gotoAndStop(this.TYPE_FRAME_MAP[int_0]);
			return;
		}
	}

	// Token: 0x060037DB RID: 14299 RVA: 0x00102064 File Offset: 0x00100264
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcSelf = this.displayObjectContainer_0 as MovieClip;
		if (this.mcSelf == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
		}
		this.mcOnlyChild = this.mcSelf.getChildByName<MovieClip>("mcETips");
		if (this.mcOnlyChild != null)
		{
			this.mcOnlyChild.stop();
		}
	}

	// Token: 0x060037DC RID: 14300 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_3(CEvent cevent_0)
	{
	}

	// Token: 0x040026EB RID: 9963
	protected MovieClip mcSelf;

	// Token: 0x040026EC RID: 9964
	protected MovieClip mcOnlyChild;

	// Token: 0x040026ED RID: 9965
	protected string[] TYPE_FRAME_MAP = new string[]
	{
		"none", "full", "open", "smash", "picked up", "reload", "talk", "outOfAmmo", "sucide", "revive",
		"enter"
	};
}
