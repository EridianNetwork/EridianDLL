using System;

// Token: 0x02000529 RID: 1321
[Serializable]
public class OldClusterCondition
{
	// Token: 0x06002202 RID: 8706 RVA: 0x0001770E File Offset: 0x0001590E
	public void method_0()
	{
		this.m_isValid = true;
	}

	// Token: 0x06002203 RID: 8707 RVA: 0x00017717 File Offset: 0x00015917
	public virtual bool vmethod_0()
	{
		return this.m_isValid;
	}

	// Token: 0x040016A5 RID: 5797
	protected bool m_isValid;
}
