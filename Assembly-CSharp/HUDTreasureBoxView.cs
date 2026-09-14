using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000705 RID: 1797
public class HUDTreasureBoxView : BaseView
{
	// Token: 0x06002F71 RID: 12145 RVA: 0x0001F2CB File Offset: 0x0001D4CB
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (LuckyBoxManager.smethod_0() != null)
		{
			LuckyBoxManager.smethod_0().method_0();
		}
	}

	// Token: 0x06002F72 RID: 12146 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (LuckyBoxManager.smethod_0() != null)
		{
			LuckyBoxManager.smethod_0().method_0();
		}
	}

	// Token: 0x06002F73 RID: 12147 RVA: 0x0001F2FD File Offset: 0x0001D4FD
	public int method_3()
	{
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().Dictionary_1.ContainsKey(LuckyBoxRank.Diamond))
		{
			return ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().Dictionary_1[LuckyBoxRank.Diamond].Count;
		}
		return 0;
	}

	// Token: 0x06002F74 RID: 12148 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002F75 RID: 12149 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(Texture texture_0)
	{
	}

	// Token: 0x06002F76 RID: 12150 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(bool bool_0 = false)
	{
	}

	// Token: 0x06002F77 RID: 12151 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}
}
