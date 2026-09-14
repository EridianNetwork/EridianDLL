using System;
using System.Collections.Generic;
using System.Reflection;
using Core;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class TkRTPC_ObjectInput : MonoBehaviour
{
	// Token: 0x06000605 RID: 1541 RVA: 0x00052108 File Offset: 0x00050308
	public TkRTPC_ParameterOverride method_0(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		for (int i = 0; i < this.m_paramOverrides.Count; i++)
		{
			if (this.m_paramOverrides[i].m_parameter == tkRTPC_Parameter_0)
			{
				return this.m_paramOverrides[i];
			}
		}
		return null;
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x00052154 File Offset: 0x00050354
	public TkRTPC_ParameterOverride method_1(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		TkRTPC_ParameterOverride tkRTPC_ParameterOverride = this.method_0(tkRTPC_Parameter_0);
		if (tkRTPC_ParameterOverride != null)
		{
			return tkRTPC_ParameterOverride;
		}
		tkRTPC_ParameterOverride = new TkRTPC_ParameterOverride();
		tkRTPC_ParameterOverride.m_parameter = tkRTPC_Parameter_0;
		this.m_paramOverrides.Add(tkRTPC_ParameterOverride);
		return tkRTPC_ParameterOverride;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00052188 File Offset: 0x00050388
	public void method_2(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		for (int i = 0; i < this.m_paramOverrides.Count; i++)
		{
			if (this.m_paramOverrides[i].m_parameter == tkRTPC_Parameter_0)
			{
				this.m_paramOverrides.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x000521D4 File Offset: 0x000503D4
	public TkRTPC_ObjectInput.SwitchOverride method_3(TkSwitch tkSwitch_0)
	{
		for (int i = 0; i < this.m_switchOverrides.Count; i++)
		{
			if (this.m_switchOverrides[i].sw == tkSwitch_0)
			{
				return this.m_switchOverrides[i];
			}
		}
		return null;
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x00052220 File Offset: 0x00050420
	public TkRTPC_ObjectInput.SwitchOverride method_4(TkSwitch tkSwitch_0)
	{
		TkRTPC_ObjectInput.SwitchOverride switchOverride = this.method_3(tkSwitch_0);
		if (switchOverride != null)
		{
			return switchOverride;
		}
		switchOverride = new TkRTPC_ObjectInput.SwitchOverride();
		switchOverride.sw = tkSwitch_0;
		switchOverride.value = tkSwitch_0.String_0;
		this.m_switchOverrides.Add(switchOverride);
		return switchOverride;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x00052260 File Offset: 0x00050460
	public void method_5(TkSwitch tkSwitch_0)
	{
		for (int i = 0; i < this.m_switchOverrides.Count; i++)
		{
			if (this.m_switchOverrides[i].sw == tkSwitch_0)
			{
				this.m_switchOverrides.RemoveAt(i);
				i--;
			}
		}
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x000522AC File Offset: 0x000504AC
	private static TkRTPC_ObjectInput.ComponentInputTable smethod_0(Type type_0)
	{
		TkRTPC_ObjectInput.ComponentInputTable componentInputTable = null;
		if (TkRTPC_ObjectInput.staticCompInputTable.TryGetValue(type_0, out componentInputTable))
		{
			return componentInputTable;
		}
		componentInputTable = new TkRTPC_ObjectInput.ComponentInputTable();
		componentInputTable.method_0(type_0);
		return componentInputTable;
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x000522DC File Offset: 0x000504DC
	public TkRTPC_ObjectInput.InputFunc method_6(string string_0)
	{
		foreach (MonoBehaviour monoBehaviour in base.gameObject.GetComponents<MonoBehaviour>())
		{
			TkRTPC_ObjectInput.ComponentInputTable componentInputTable = TkRTPC_ObjectInput.smethod_0(monoBehaviour.GetType());
			TkRTPC_ObjectInput.ComponentInput componentInput;
			if (componentInputTable.inputs.TryGetValue(string_0, out componentInput))
			{
				return (TkRTPC_ObjectInput.InputFunc)Delegate.CreateDelegate(typeof(TkRTPC_ObjectInput.InputFunc), monoBehaviour, componentInput.methodInfo);
			}
		}
		return null;
	}

	// Token: 0x0400058F RID: 1423
	[HideInInspector]
	public List<TkRTPC_ParameterOverride> m_paramOverrides = new List<TkRTPC_ParameterOverride>();

	// Token: 0x04000590 RID: 1424
	[HideInInspector]
	public List<TkRTPC_ObjectInput.SwitchOverride> m_switchOverrides = new List<TkRTPC_ObjectInput.SwitchOverride>();

	// Token: 0x04000591 RID: 1425
	private static Dictionary<Type, TkRTPC_ObjectInput.ComponentInputTable> staticCompInputTable = new Dictionary<Type, TkRTPC_ObjectInput.ComponentInputTable>();

	// Token: 0x02000106 RID: 262
	[Serializable]
	public class SwitchOverride
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x00052344 File Offset: 0x00050544
		public TkRTPC_ObjectInput.SwitchOverride method_0()
		{
			TkRTPC_ObjectInput.SwitchOverride switchOverride = new TkRTPC_ObjectInput.SwitchOverride();
			switchOverride.sw = this.sw;
			switchOverride.method_1(this);
			return switchOverride;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00007229 File Offset: 0x00005429
		public void method_1(TkRTPC_ObjectInput.SwitchOverride switchOverride_0)
		{
			this.value = switchOverride_0.value;
		}

		// Token: 0x04000592 RID: 1426
		public TkSwitch sw;

		// Token: 0x04000593 RID: 1427
		public string value;
	}

	// Token: 0x02000107 RID: 263
	public class ComponentInput
	{
		// Token: 0x04000594 RID: 1428
		public MethodInfo methodInfo;
	}

	// Token: 0x02000108 RID: 264
	public class ComponentInputTable
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x0005236C File Offset: 0x0005056C
		public void method_0(Type type_0)
		{
			foreach (MethodInfo methodInfo in type_0.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				object[] customAttributes = methodInfo.GetCustomAttributes(typeof(TkRTPC_InputAttribute), true);
				if (customAttributes.Length == 1)
				{
					TkRTPC_InputAttribute tkRTPC_InputAttribute = customAttributes[0] as TkRTPC_InputAttribute;
					if (tkRTPC_InputAttribute != null)
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters.Length == 0)
						{
							if (methodInfo.ReturnType == typeof(float))
							{
								TkRTPC_ObjectInput.ComponentInput componentInput;
								if (!this.inputs.TryGetValue(methodInfo.Name, out componentInput))
								{
									componentInput = new TkRTPC_ObjectInput.ComponentInput();
									componentInput.methodInfo = methodInfo;
									this.inputs.Add(tkRTPC_InputAttribute.m_paramName, componentInput);
									goto IL_00D9;
								}
								goto IL_00D9;
							}
						}
						DebugUtils.LogError(LogCategory.Default, string.Concat(new string[] { "Invalid RTPC Input method ", type_0.Name, ".", methodInfo.Name, "(), float func() is expected" }));
					}
				}
				IL_00D9:;
			}
		}

		// Token: 0x04000595 RID: 1429
		public Dictionary<string, TkRTPC_ObjectInput.ComponentInput> inputs = new Dictionary<string, TkRTPC_ObjectInput.ComponentInput>();
	}

	// Token: 0x02000109 RID: 265
	// (Invoke) Token: 0x06000614 RID: 1556
	public delegate float InputFunc();
}
