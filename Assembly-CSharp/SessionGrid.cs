using System;
using UnityEngine;

// Token: 0x02000AB1 RID: 2737
public class SessionGrid : Grid
{
	// Token: 0x06004A4D RID: 19021 RVA: 0x000309B6 File Offset: 0x0002EBB6
	public SessionGrid(byte byte_0)
		: base(byte_0, Vector3.zero, Vector3.zero, false)
	{
	}

	// Token: 0x06004A4E RID: 19022 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_7(Entity entity_0)
	{
		return true;
	}

	// Token: 0x06004A4F RID: 19023 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_8(Grid grid_0)
	{
		return false;
	}
}
