using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000103 RID: 259
[AddComponentMenu("Audio/Audio ParameterValues")]
public class AudioParameterValues : MonoBehaviour
{
	// Token: 0x060005F0 RID: 1520 RVA: 0x00051C7C File Offset: 0x0004FE7C
	private void method_0()
	{
		this.m_rtpcValueMap.Clear();
		if (this.m_rtpcValues != null)
		{
			for (int i = 0; i < this.m_rtpcValues.Length; i++)
			{
				RTPCValue rtpcvalue = this.m_rtpcValues[i];
				this.m_rtpcValueMap.Add(rtpcvalue.m_rtpc, rtpcvalue);
			}
		}
		this.m_switchValueMap.Clear();
		if (this.m_switchValues != null)
		{
			for (int j = 0; j < this.m_switchValues.Length; j++)
			{
				SwitchValue switchValue = this.m_switchValues[j];
				if (switchValue != null)
				{
					this.m_switchValueMap.Add(switchValue.m_switch, switchValue);
				}
			}
		}
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00051D10 File Offset: 0x0004FF10
	private void method_1()
	{
		if (this.m_rtpcValues != null)
		{
			for (int i = 0; i < this.m_rtpcValues.Length; i++)
			{
				this.m_rtpcValues[i].method_1();
			}
		}
		if (this.m_switchValues != null)
		{
			for (int j = 0; j < this.m_switchValues.Length; j++)
			{
				this.m_switchValues[j].method_1();
			}
		}
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x000071E0 File Offset: 0x000053E0
	protected void Awake()
	{
		this.method_0();
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x000071E8 File Offset: 0x000053E8
	protected void Start()
	{
		this.method_1();
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00051D70 File Offset: 0x0004FF70
	public RTPCValue method_2(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		RTPCValue rtpcvalue = null;
		this.m_rtpcValueMap.TryGetValue(tkRTPC_Parameter_0, out rtpcvalue);
		return rtpcvalue;
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00051D90 File Offset: 0x0004FF90
	private RTPCValue method_3(TkRTPC_Parameter tkRTPC_Parameter_0)
	{
		RTPCValue rtpcvalue = this.method_2(tkRTPC_Parameter_0);
		if (null == rtpcvalue)
		{
			rtpcvalue = new RTPCValue();
			rtpcvalue.m_rtpc = tkRTPC_Parameter_0;
			this.method_4(rtpcvalue);
		}
		return rtpcvalue;
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00051DC4 File Offset: 0x0004FFC4
	private void method_4(RTPCValue rtpcvalue_0)
	{
		RTPCValue[] array = new RTPCValue[this.m_rtpcValues.Length + 1];
		Array.Copy(this.m_rtpcValues, array, this.m_rtpcValues.Length);
		this.m_rtpcValues = array;
		this.m_rtpcValueMap.Add(rtpcvalue_0.m_rtpc, rtpcvalue_0);
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00051E10 File Offset: 0x00050010
	public void method_5(TkRTPC_Parameter tkRTPC_Parameter_0, float float_0)
	{
		RTPCValue rtpcvalue = this.method_3(tkRTPC_Parameter_0);
		rtpcvalue.m_type = EParameterValueType.Static;
		rtpcvalue.m_value = float_0;
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00051E34 File Offset: 0x00050034
	public void method_6(TkRTPC_Parameter tkRTPC_Parameter_0, global::UnityEngine.Object object_0, string string_0)
	{
		RTPCValue rtpcvalue = this.method_3(tkRTPC_Parameter_0);
		rtpcvalue.m_type = EParameterValueType.Dynamic;
		rtpcvalue.DynamicTarget = object_0;
		rtpcvalue.DynamicMethodName = string_0;
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00051E60 File Offset: 0x00050060
	public bool method_7(TkRTPC_Parameter tkRTPC_Parameter_0, out float float_0)
	{
		bool flag = false;
		if (!this.m_resolveCycleGuard)
		{
			if (!(flag = this.method_8(tkRTPC_Parameter_0, out float_0)) && null != this.m_delegate)
			{
				this.m_resolveCycleGuard = true;
				flag = this.m_delegate.method_7(tkRTPC_Parameter_0, out float_0);
				this.m_resolveCycleGuard = false;
			}
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Resolve cycle when trying to get RTPC: " + tkRTPC_Parameter_0.name + " @: " + Utils.smethod_16(base.gameObject));
			float_0 = tkRTPC_Parameter_0.m_defaultValue;
		}
		return flag;
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00051EE0 File Offset: 0x000500E0
	private bool method_8(TkRTPC_Parameter tkRTPC_Parameter_0, out float float_0)
	{
		RTPCValue rtpcvalue = this.method_2(tkRTPC_Parameter_0);
		bool flag;
		if (flag = null != rtpcvalue)
		{
			float_0 = rtpcvalue.method_2();
		}
		else
		{
			float_0 = tkRTPC_Parameter_0.m_defaultValue;
		}
		return flag;
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00051F14 File Offset: 0x00050114
	public SwitchValue method_9(TkSwitch tkSwitch_0)
	{
		SwitchValue switchValue = null;
		this.m_switchValueMap.TryGetValue(tkSwitch_0, out switchValue);
		return switchValue;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00051F34 File Offset: 0x00050134
	private SwitchValue method_10(TkSwitch tkSwitch_0)
	{
		SwitchValue switchValue = this.method_9(tkSwitch_0);
		if (!(null != tkSwitch_0))
		{
			switchValue = new SwitchValue();
			switchValue.m_switch = tkSwitch_0;
			this.method_11(switchValue);
		}
		return switchValue;
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x00051F68 File Offset: 0x00050168
	private void method_11(SwitchValue switchValue_0)
	{
		if (this.m_switchValueMap.ContainsKey(switchValue_0.m_switch))
		{
			return;
		}
		int num = ((this.m_switchValues == null) ? 0 : this.m_switchValues.Length);
		SwitchValue[] array = new SwitchValue[num + 1];
		array[num] = switchValue_0;
		if (0 < num)
		{
			Array.Copy(this.m_switchValues, array, this.m_switchValues.Length);
		}
		this.m_switchValues = array;
		this.m_switchValueMap.Add(switchValue_0.m_switch, switchValue_0);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x00051FDC File Offset: 0x000501DC
	public void method_12(TkSwitch tkSwitch_0, string string_0)
	{
		SwitchValue switchValue = this.method_10(tkSwitch_0);
		switchValue.m_type = EParameterValueType.Static;
		switchValue.m_value = string_0;
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x00052000 File Offset: 0x00050200
	public void method_13(TkSwitch tkSwitch_0, global::UnityEngine.Object object_0, string string_0)
	{
		SwitchValue switchValue = this.method_10(tkSwitch_0);
		switchValue.m_type = EParameterValueType.Dynamic;
		switchValue.DynamicTarget = object_0;
		switchValue.DynamicMethodName = string_0;
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x0005202C File Offset: 0x0005022C
	public bool method_14(TkSwitch tkSwitch_0, out string string_0)
	{
		bool flag = false;
		if (!this.m_resolveCycleGuard)
		{
			if (!(flag = this.method_15(tkSwitch_0, out string_0)) && null != this.m_delegate)
			{
				this.m_resolveCycleGuard = true;
				flag = this.m_delegate.method_14(tkSwitch_0, out string_0);
				this.m_resolveCycleGuard = false;
			}
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Resolve cycle when trying to get Switch: " + tkSwitch_0.name + " @: " + Utils.smethod_16(base.gameObject));
			string_0 = null;
		}
		return flag;
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x000520A8 File Offset: 0x000502A8
	private bool method_15(TkSwitch tkSwitch_0, out string string_0)
	{
		bool flag = false;
		string_0 = string.Empty;
		SwitchValue switchValue = this.method_9(tkSwitch_0);
		if (null != switchValue)
		{
			string text = switchValue.method_2();
			if (text != null)
			{
				if (tkSwitch_0.method_0(text))
				{
					string_0 = text;
					flag = true;
				}
				else
				{
					DebugUtils.LogWarning(LogCategory.Audio, "Audio Switch: " + tkSwitch_0.name + " doesn't define a case for value: " + text);
				}
			}
		}
		return flag;
	}

	// Token: 0x04000588 RID: 1416
	public AudioParameterValues m_delegate;

	// Token: 0x04000589 RID: 1417
	private bool m_resolveCycleGuard;

	// Token: 0x0400058A RID: 1418
	public RTPCValue[] m_rtpcValues;

	// Token: 0x0400058B RID: 1419
	private Dictionary<TkRTPC_Parameter, RTPCValue> m_rtpcValueMap = new Dictionary<TkRTPC_Parameter, RTPCValue>();

	// Token: 0x0400058C RID: 1420
	public SwitchValue[] m_switchValues;

	// Token: 0x0400058D RID: 1421
	private Dictionary<TkSwitch, SwitchValue> m_switchValueMap = new Dictionary<TkSwitch, SwitchValue>();
}
