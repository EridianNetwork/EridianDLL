using System;

// Token: 0x02000709 RID: 1801
public class InstanceInfoView : BaseView
{
	// Token: 0x06002F8B RID: 12171 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06002F8C RID: 12172 RVA: 0x0001D78C File Offset: 0x0001B98C
	public override void vmethod_3()
	{
		base.vmethod_3();
	}

	// Token: 0x06002F8D RID: 12173 RVA: 0x0001F3F2 File Offset: 0x0001D5F2
	public void method_3(int int_0)
	{
		this.m_nInstanceId = int_0;
	}

	// Token: 0x06002F8E RID: 12174 RVA: 0x0001F3FB File Offset: 0x0001D5FB
	public int method_4()
	{
		return this.m_nInstanceId;
	}

	// Token: 0x06002F8F RID: 12175 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002F90 RID: 12176 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x04002131 RID: 8497
	protected int m_nInstanceId = 6;
}
