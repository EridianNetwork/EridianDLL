using System;

// Token: 0x0200010A RID: 266
public abstract class TkRTPC_Output_BaseAttribute : Attribute
{
	// Token: 0x06000617 RID: 1559 RVA: 0x0000724A File Offset: 0x0000544A
	public TkRTPC_Output_BaseAttribute(TkRTPC_Output_BaseAttribute.Op op_0, float float_0, float float_1, float float_2)
	{
		this.op = op_0;
		this.scalarDefault = float_0;
		this.max = float_2;
		this.min = float_1;
	}

	// Token: 0x04000596 RID: 1430
	public TkRTPC_Output_BaseAttribute.Op op;

	// Token: 0x04000597 RID: 1431
	public float scalarDefault = 1f;

	// Token: 0x04000598 RID: 1432
	public float min;

	// Token: 0x04000599 RID: 1433
	public float max = 1f;

	// Token: 0x0200010B RID: 267
	public enum Op
	{
		// Token: 0x0400059B RID: 1435
		Add,
		// Token: 0x0400059C RID: 1436
		Mul
	}
}
