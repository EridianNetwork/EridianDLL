using System;

// Token: 0x020005F0 RID: 1520
public class GUIDGenerator
{
	// Token: 0x0600268B RID: 9867 RVA: 0x00019F47 File Offset: 0x00018147
	public int method_0()
	{
		GUIDGenerator.s_guid++;
		return GUIDGenerator.s_guid;
	}

	// Token: 0x0600268C RID: 9868 RVA: 0x000BA5AC File Offset: 0x000B87AC
	public string method_1(bool bool_0 = false)
	{
		if (bool_0)
		{
			return (this.method_0() + 10000).ToString();
		}
		return this.method_0().ToString();
	}

	// Token: 0x04001C1E RID: 7198
	private static int s_guid;
}
