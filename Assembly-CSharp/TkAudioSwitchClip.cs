using System;
using Core;
using UnityEngine;

// Token: 0x02000124 RID: 292
[AddComponentMenu("TkAudio/TkAudio Switch Clip")]
public class TkAudioSwitchClip : TkIAudioClip
{
	// Token: 0x06000694 RID: 1684 RVA: 0x000541B0 File Offset: 0x000523B0
	public override TkAudioSingleClip vmethod_0(bool bool_0)
	{
		if (this.m_switch == null)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Switch is null in TkAudioSwitchClip " + base.name);
			return null;
		}
		if (this.m_switch.cases == null)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Switch.cases is null in TkAudioSwitchClip " + base.name);
			return null;
		}
		TkAudioSource component = base.GetComponent<TkAudioSource>();
		if (!component)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TkAudioSource is missing in TkAudioSwitchClip " + base.name);
			return null;
		}
		string text = null;
		if (bool_0)
		{
			if (this.m_previewCaseInEditor < 0 || this.m_previewCaseInEditor >= this.m_switch.cases.Length)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "invalid previewCaseInEditor in TkAudioSwitchClip " + component.method_7());
				return null;
			}
			text = this.m_switch.cases[this.m_previewCaseInEditor];
		}
		else
		{
			if (component.host)
			{
				TkRTPC_ObjectInput component2 = component.host.GetComponent<TkRTPC_ObjectInput>();
				if (component2)
				{
					TkRTPC_ObjectInput.SwitchOverride switchOverride = component2.method_3(this.m_switch);
					if (switchOverride != null)
					{
						text = switchOverride.value;
						goto IL_0166;
					}
				}
				AudioParameterValues component3 = component.host.GetComponent<AudioParameterValues>();
				if (null != component3 && component3.method_14(this.m_switch, out text))
				{
					goto IL_0166;
				}
			}
			if (TkAudioSystem.s_onSwitch != null)
			{
				text = TkAudioSystem.s_onSwitch(this, this.m_switch.name);
				if (!string.IsNullOrEmpty(text))
				{
					goto IL_0166;
				}
			}
			if (this.m_switch.method_1())
			{
				text = this.m_switch.String_0;
			}
		}
		IL_0166:
		if (string.IsNullOrEmpty(text))
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TkAudioSwitch is not solved [" + component.method_7() + "] GameObject " + Tk.smethod_27(base.gameObject));
			return null;
		}
		GameObject gameObject = Tk.smethod_33(base.gameObject, text, true, true);
		if (gameObject == null)
		{
			DebugUtils.LogWarning(LogCategory.Audio, string.Concat(new string[]
			{
				"TkAudioSwitch is doesn't have [",
				text,
				"] in [",
				component.method_7(),
				"] GameObject ",
				Tk.smethod_27(base.gameObject)
			}));
			return null;
		}
		TkIAudioClip component4 = gameObject.GetComponent<TkIAudioClip>();
		if (!component4)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TkIAudioClip Component is missing in " + gameObject.name);
			return null;
		}
		return component4.vmethod_0(bool_0);
	}

	// Token: 0x04000617 RID: 1559
	public TkSwitch m_switch;

	// Token: 0x04000618 RID: 1560
	[HideInInspector]
	public int m_previewCaseInEditor;
}
