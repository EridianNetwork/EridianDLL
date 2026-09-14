using System;

// Token: 0x02000116 RID: 278
[Serializable]
public class TkRTPC_ParameterOverride
{
	// Token: 0x0600063B RID: 1595 RVA: 0x00052A48 File Offset: 0x00050C48
	public TkRTPC_ParameterOverride method_0()
	{
		TkRTPC_ParameterOverride tkRTPC_ParameterOverride = new TkRTPC_ParameterOverride();
		tkRTPC_ParameterOverride.m_parameter = this.m_parameter;
		tkRTPC_ParameterOverride.method_1(this);
		return tkRTPC_ParameterOverride;
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0000742E File Offset: 0x0000562E
	public void method_1(TkRTPC_ParameterOverride tkRTPC_ParameterOverride_0)
	{
		this.m_value = tkRTPC_ParameterOverride_0.m_value;
	}

	// Token: 0x040005AF RID: 1455
	public TkRTPC_Parameter m_parameter;

	// Token: 0x040005B0 RID: 1456
	public float m_value;
}
