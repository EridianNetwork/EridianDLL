using System;
using Core;
using UnityEngine;

// Token: 0x02000100 RID: 256
[Serializable]
public class ValueHolder<T>
{
	// Token: 0x060005E6 RID: 1510 RVA: 0x00051BF4 File Offset: 0x0004FDF4
	private bool method_0()
	{
		if (!(null == this.m_target) && !string.IsNullOrEmpty(this.m_method))
		{
			this.m_resolvedMethod = DynamicValueHelper<T>.smethod_0(this.m_target, this.m_method);
		}
		else
		{
			this.m_resolvedMethod = null;
		}
		return null != this.m_resolvedMethod;
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000715D File Offset: 0x0000535D
	// (set) Token: 0x060005E8 RID: 1512 RVA: 0x00007165 File Offset: 0x00005365
	public global::UnityEngine.Object DynamicTarget
	{
		get
		{
			return this.m_target;
		}
		set
		{
			this.m_target = value;
			this.method_0();
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00007175 File Offset: 0x00005375
	// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000717D File Offset: 0x0000537D
	public string DynamicMethodName
	{
		get
		{
			return this.m_method;
		}
		set
		{
			this.m_method = value;
			this.method_0();
		}
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x0000718D File Offset: 0x0000538D
	public void method_1()
	{
		if (this.m_type == EParameterValueType.Dynamic && !this.method_0())
		{
			DebugUtils.LogWarning(LogCategory.Audio, "failed resolving dynamic parameter value accessor");
			this.m_type = EParameterValueType.Static;
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00051C48 File Offset: 0x0004FE48
	public T method_2()
	{
		EParameterValueType type = this.m_type;
		if (type == EParameterValueType.Static)
		{
			return this.m_value;
		}
		if (type != EParameterValueType.Dynamic)
		{
			throw new NotImplementedException();
		}
		return this.m_resolvedMethod();
	}

	// Token: 0x04000581 RID: 1409
	public EParameterValueType m_type;

	// Token: 0x04000582 RID: 1410
	public T m_value = default(T);

	// Token: 0x04000583 RID: 1411
	[SerializeField]
	private global::UnityEngine.Object m_target;

	// Token: 0x04000584 RID: 1412
	[SerializeField]
	private string m_method;

	// Token: 0x04000585 RID: 1413
	protected Func<T> m_resolvedMethod;
}
