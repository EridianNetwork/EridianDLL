using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000117 RID: 279
[Serializable]
public class TkRTPC_ParameterAction
{
	// Token: 0x0600063E RID: 1598 RVA: 0x00052A70 File Offset: 0x00050C70
	public TkRTPC_ParameterAction method_0()
	{
		TkRTPC_ParameterAction tkRTPC_ParameterAction = new TkRTPC_ParameterAction();
		tkRTPC_ParameterAction.m_parameter = this.m_parameter;
		tkRTPC_ParameterAction.m_outputs = new List<TkRTPC_ParameterAction.Output>();
		for (int i = 0; i < this.m_outputs.Count; i++)
		{
			TkRTPC_ParameterAction.Output output = this.m_outputs[i].method_1();
			tkRTPC_ParameterAction.m_outputs.Add(output);
		}
		return tkRTPC_ParameterAction;
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x00052AD0 File Offset: 0x00050CD0
	public TkRTPC_ParameterAction.Output method_1(string string_0)
	{
		for (int i = 0; i < this.m_outputs.Count; i++)
		{
			TkRTPC_ParameterAction.Output output = this.m_outputs[i];
			if (output.m_funcName == string_0)
			{
				return output;
			}
		}
		return null;
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x00052B14 File Offset: 0x00050D14
	public TkRTPC_ParameterAction.Output method_2(string string_0, float float_0)
	{
		TkRTPC_ParameterAction.Output output = this.method_1(string_0);
		if (output == null)
		{
			output = new TkRTPC_ParameterAction.Output();
			output.m_funcName = string_0;
			output.m_scalar = float_0;
			this.m_outputs.Add(output);
		}
		return output;
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x00052B50 File Offset: 0x00050D50
	public void method_3(TkRTPC_ParameterAction tkRTPC_ParameterAction_0)
	{
		TkRTPC_ParameterAction tkRTPC_ParameterAction = tkRTPC_ParameterAction_0.method_0();
		this.m_outputs.Clear();
		for (int i = 0; i < tkRTPC_ParameterAction.m_outputs.Count; i++)
		{
			this.m_outputs.Add(tkRTPC_ParameterAction.m_outputs[i].method_1());
		}
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x00052BA4 File Offset: 0x00050DA4
	public void method_4(string string_0)
	{
		for (int i = 0; i < this.m_outputs.Count; i++)
		{
			if (this.m_outputs[i].m_funcName == string_0)
			{
				this.m_outputs.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x040005B1 RID: 1457
	public TkRTPC_Parameter m_parameter;

	// Token: 0x040005B2 RID: 1458
	[NonSerialized]
	public float m_inputValue;

	// Token: 0x040005B3 RID: 1459
	[NonSerialized]
	public TkRTPC_ParameterOverride m_inputOverride;

	// Token: 0x040005B4 RID: 1460
	[NonSerialized]
	public TkRTPC_ObjectInput.InputFunc m_inputFunc;

	// Token: 0x040005B5 RID: 1461
	[NonSerialized]
	public RTPCValue m_inputParameterValue;

	// Token: 0x040005B6 RID: 1462
	public List<TkRTPC_ParameterAction.Output> m_outputs = new List<TkRTPC_ParameterAction.Output>();

	// Token: 0x02000118 RID: 280
	[Serializable]
	public class Output
	{
		// Token: 0x06000644 RID: 1604 RVA: 0x00052BF0 File Offset: 0x00050DF0
		public bool method_0(TkRTPC_ParameterAction.Output output_0)
		{
			if (this.m_curve == null)
			{
				if (output_0.m_curve != null)
				{
					return false;
				}
			}
			else
			{
				if (output_0.m_curve == null)
				{
					return false;
				}
				Keyframe[] keys = this.m_curve.keys;
				Keyframe[] keys2 = output_0.m_curve.keys;
				if (keys.Length != keys2.Length)
				{
					return false;
				}
				for (int i = 0; i < keys.Length; i++)
				{
					if (!keys[i].Equals(keys2[i]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00052C78 File Offset: 0x00050E78
		public TkRTPC_ParameterAction.Output method_1()
		{
			TkRTPC_ParameterAction.Output output = new TkRTPC_ParameterAction.Output();
			output.m_funcName = this.m_funcName;
			output.method_2(this);
			return output;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00007481 File Offset: 0x00005681
		public void method_2(TkRTPC_ParameterAction.Output output_0)
		{
			this.m_curve.keys = output_0.m_curve.keys;
			this.m_scalar = output_0.m_scalar;
		}

		// Token: 0x040005B7 RID: 1463
		[NonSerialized]
		public TkRTPC_ParameterAction m_action;

		// Token: 0x040005B8 RID: 1464
		public float m_scalar = 1f;

		// Token: 0x040005B9 RID: 1465
		public AnimationCurve m_curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		// Token: 0x040005BA RID: 1466
		public string m_funcName;
	}
}
