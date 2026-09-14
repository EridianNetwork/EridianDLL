using System;
using System.Collections.Generic;
using System.Reflection;
using Core;
using UnityEngine;

// Token: 0x0200010E RID: 270
public class TkRTPC_OutputComponent : MonoBehaviour
{
	// Token: 0x0600061C RID: 1564 RVA: 0x00052460 File Offset: 0x00050660
	public TkRTPC_ParameterAction method_0(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		for (int i = 0; i < this.m_actions.Count; i++)
		{
			TkRTPC_ParameterAction tkRTPC_ParameterAction = this.m_actions[i];
			if (tkRTPC_ParameterAction.m_parameter == tkRTPC_Parameter_0)
			{
				return tkRTPC_ParameterAction;
			}
		}
		return null;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x000524A4 File Offset: 0x000506A4
	public TkRTPC_ParameterAction method_1(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		TkRTPC_ParameterAction tkRTPC_ParameterAction = this.method_0(tkRTPC_Parameter_0);
		if (tkRTPC_ParameterAction != null)
		{
			return tkRTPC_ParameterAction;
		}
		tkRTPC_ParameterAction = new TkRTPC_ParameterAction();
		tkRTPC_ParameterAction.m_parameter = tkRTPC_Parameter_0;
		this.m_actions.Add(tkRTPC_ParameterAction);
		this.method_4();
		return tkRTPC_ParameterAction;
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x000524E0 File Offset: 0x000506E0
	public void method_2(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		for (int i = 0; i < this.m_actions.Count; i++)
		{
			if (this.m_actions[i].m_parameter == tkRTPC_Parameter_0)
			{
				this.method_4();
				this.m_actions.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x00052534 File Offset: 0x00050734
	public void method_3()
	{
		for (int i = 0; i < this.m_actions.Count; i++)
		{
			TkRTPC_ParameterAction tkRTPC_ParameterAction = this.m_actions[i];
			if (tkRTPC_ParameterAction == null || tkRTPC_ParameterAction.m_parameter == null)
			{
				this.m_actions.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x00052588 File Offset: 0x00050788
	private static TkRTPC_OutputComponent.ComponentOutputTable smethod_0(Type type_0)
	{
		TkRTPC_OutputComponent.ComponentOutputTable componentOutputTable = null;
		if (TkRTPC_OutputComponent.staticCompOutputTable.TryGetValue(type_0, out componentOutputTable))
		{
			return componentOutputTable;
		}
		componentOutputTable = new TkRTPC_OutputComponent.ComponentOutputTable();
		componentOutputTable.method_0(type_0);
		return componentOutputTable;
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x000072BC File Offset: 0x000054BC
	public void method_4()
	{
		this.m_runtimeValues = null;
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x000525B8 File Offset: 0x000507B8
	private void method_5()
	{
		if (this.m_runtimeValues != null)
		{
			return;
		}
		this.m_runtimeValues = new Dictionary<string, TkRTPC_OutputComponent.RunTimeValue>();
		TkRTPC_OutputComponent.ComponentOutputTable componentOutputTable = TkRTPC_OutputComponent.smethod_0(base.GetType());
		for (int i = 0; i < this.m_actions.Count; i++)
		{
			TkRTPC_ParameterAction tkRTPC_ParameterAction = this.m_actions[i];
			if (this.m_host)
			{
				TkRTPC_ObjectInput tkRTPC_ObjectInput = Tk.smethod_48<TkRTPC_ObjectInput>(this.m_host);
				tkRTPC_ParameterAction.m_inputOverride = tkRTPC_ObjectInput.method_0(tkRTPC_ParameterAction.m_parameter);
				if (tkRTPC_ParameterAction.m_inputOverride == null)
				{
					tkRTPC_ParameterAction.m_inputFunc = tkRTPC_ObjectInput.method_6(tkRTPC_ParameterAction.m_parameter.name);
					if (tkRTPC_ParameterAction.m_inputOverride == null)
					{
						AudioParameterValues component = this.m_host.GetComponent<AudioParameterValues>();
						if (!(null == component))
						{
							tkRTPC_ParameterAction.m_inputParameterValue = component.method_2(tkRTPC_ParameterAction.m_parameter);
						}
					}
				}
			}
			int j = 0;
			while (j < tkRTPC_ParameterAction.m_outputs.Count)
			{
				TkRTPC_ParameterAction.Output output = tkRTPC_ParameterAction.m_outputs[j];
				TkRTPC_OutputComponent.RunTimeValue runTimeValue = null;
				if (this.m_runtimeValues.TryGetValue(output.m_funcName, out runTimeValue))
				{
					goto IL_013E;
				}
				runTimeValue = new TkRTPC_OutputComponent.RunTimeValue();
				if (componentOutputTable.outputs.TryGetValue(output.m_funcName, out runTimeValue.compOutput))
				{
					runTimeValue.func = (TkRTPC_OutputComponent.OutputFunc)Delegate.CreateDelegate(typeof(TkRTPC_OutputComponent.OutputFunc), this, runTimeValue.compOutput.methodInfo);
					this.m_runtimeValues.Add(output.m_funcName, runTimeValue);
					goto IL_013E;
				}
				IL_0154:
				j++;
				continue;
				IL_013E:
				output.m_action = tkRTPC_ParameterAction;
				runTimeValue.outputs.Add(output);
				goto IL_0154;
			}
		}
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x000072C5 File Offset: 0x000054C5
	public void Update()
	{
		this.method_6(false);
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x00052748 File Offset: 0x00050948
	public void method_6(bool bool_0)
	{
		this.method_5();
		for (int i = 0; i < this.m_actions.Count; i++)
		{
			TkRTPC_ParameterAction tkRTPC_ParameterAction = this.m_actions[i];
			if (bool_0)
			{
				if (!this.m_host)
				{
					tkRTPC_ParameterAction.m_inputValue = tkRTPC_ParameterAction.m_parameter.m_previewValue;
				}
			}
			else
			{
				if (tkRTPC_ParameterAction.m_parameter)
				{
					tkRTPC_ParameterAction.m_inputValue = tkRTPC_ParameterAction.m_parameter.m_defaultValue;
				}
				if (this.m_host)
				{
					if (tkRTPC_ParameterAction.m_inputOverride != null)
					{
						tkRTPC_ParameterAction.m_inputValue = tkRTPC_ParameterAction.m_inputOverride.m_value;
					}
					else if (tkRTPC_ParameterAction.m_inputFunc != null)
					{
						tkRTPC_ParameterAction.m_inputValue = tkRTPC_ParameterAction.m_inputFunc();
					}
					else if (tkRTPC_ParameterAction.m_inputParameterValue != null)
					{
						tkRTPC_ParameterAction.m_inputValue = tkRTPC_ParameterAction.m_inputParameterValue.method_2();
					}
				}
			}
		}
		foreach (KeyValuePair<string, TkRTPC_OutputComponent.RunTimeValue> keyValuePair in this.m_runtimeValues)
		{
			TkRTPC_OutputComponent.RunTimeValue value = keyValuePair.Value;
			value.firstValue = true;
			for (int j = 0; j < value.outputs.Count; j++)
			{
				TkRTPC_ParameterAction.Output output = value.outputs[j];
				float num = output.m_curve.Evaluate(output.m_action.m_inputValue) * output.m_scalar;
				if (value.firstValue)
				{
					value.firstValue = false;
					value.value = num;
				}
				else
				{
					TkRTPC_Output_BaseAttribute.Op op = value.compOutput.attr.op;
					if (op != TkRTPC_Output_BaseAttribute.Op.Add)
					{
						if (op == TkRTPC_Output_BaseAttribute.Op.Mul)
						{
							value.value *= num;
						}
					}
					else
					{
						value.value += num;
					}
				}
			}
			TkRTPC_Output_BaseAttribute attr = value.compOutput.attr;
			value.func(Mathf.Clamp(value.value, attr.min, attr.max));
		}
	}

	// Token: 0x0400059D RID: 1437
	public const BindingFlags funcBindingFlag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	// Token: 0x0400059E RID: 1438
	[NonSerialized]
	public GameObject m_host;

	// Token: 0x0400059F RID: 1439
	[HideInInspector]
	public List<TkRTPC_ParameterAction> m_actions = new List<TkRTPC_ParameterAction>();

	// Token: 0x040005A0 RID: 1440
	private static Dictionary<Type, TkRTPC_OutputComponent.ComponentOutputTable> staticCompOutputTable = new Dictionary<Type, TkRTPC_OutputComponent.ComponentOutputTable>();

	// Token: 0x040005A1 RID: 1441
	[NonSerialized]
	private Dictionary<string, TkRTPC_OutputComponent.RunTimeValue> m_runtimeValues;

	// Token: 0x0200010F RID: 271
	public class ComponentOutput
	{
		// Token: 0x040005A2 RID: 1442
		public MethodInfo methodInfo;

		// Token: 0x040005A3 RID: 1443
		public TkRTPC_Output_BaseAttribute attr;
	}

	// Token: 0x02000110 RID: 272
	public class ComponentOutputTable
	{
		// Token: 0x06000627 RID: 1575 RVA: 0x00052934 File Offset: 0x00050B34
		public void method_0(Type type_0)
		{
			foreach (MethodInfo methodInfo in type_0.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				object[] customAttributes = methodInfo.GetCustomAttributes(typeof(TkRTPC_Output_BaseAttribute), true);
				if (customAttributes.Length == 1)
				{
					TkRTPC_Output_BaseAttribute tkRTPC_Output_BaseAttribute = customAttributes[0] as TkRTPC_Output_BaseAttribute;
					if (tkRTPC_Output_BaseAttribute != null)
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters.Length == 1 && parameters[0].ParameterType == typeof(float))
						{
							if (methodInfo.ReturnType == typeof(void))
							{
								TkRTPC_OutputComponent.ComponentOutput componentOutput;
								if (!this.outputs.TryGetValue(methodInfo.Name, out componentOutput))
								{
									componentOutput = new TkRTPC_OutputComponent.ComponentOutput();
									componentOutput.attr = tkRTPC_Output_BaseAttribute;
									componentOutput.methodInfo = methodInfo;
									this.outputs.Add(methodInfo.Name, componentOutput);
									goto IL_00F7;
								}
								goto IL_00F7;
							}
						}
						DebugUtils.LogError(LogCategory.Default, string.Concat(new string[] { "Invalid RTPC Output method ", type_0.Name, ".", methodInfo.Name, "(), void func(float v) is expected" }));
					}
				}
				IL_00F7:;
			}
		}

		// Token: 0x040005A4 RID: 1444
		public Dictionary<string, TkRTPC_OutputComponent.ComponentOutput> outputs = new Dictionary<string, TkRTPC_OutputComponent.ComponentOutput>();
	}

	// Token: 0x02000111 RID: 273
	private class RunTimeValue
	{
		// Token: 0x040005A5 RID: 1445
		public TkRTPC_OutputComponent.ComponentOutput compOutput;

		// Token: 0x040005A6 RID: 1446
		public TkRTPC_OutputComponent.OutputFunc func;

		// Token: 0x040005A7 RID: 1447
		public float value;

		// Token: 0x040005A8 RID: 1448
		public bool firstValue = true;

		// Token: 0x040005A9 RID: 1449
		public List<TkRTPC_ParameterAction.Output> outputs = new List<TkRTPC_ParameterAction.Output>();
	}

	// Token: 0x02000112 RID: 274
	// (Invoke) Token: 0x0600062A RID: 1578
	public delegate void OutputFunc(float v);
}
