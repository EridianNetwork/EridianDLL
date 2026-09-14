using System;
using UnityEngine;

// Token: 0x02000AB2 RID: 2738
public class InstanceGrid : Grid
{
	// Token: 0x06004A50 RID: 19024 RVA: 0x000309CA File Offset: 0x0002EBCA
	public InstanceGrid(byte byte_0)
		: base(byte_0, Vector3.zero, Vector3.zero, true)
	{
	}

	// Token: 0x06004A51 RID: 19025 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_7(Entity entity_0)
	{
		return true;
	}

	// Token: 0x06004A52 RID: 19026 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_8(Grid grid_0)
	{
		return false;
	}
}
