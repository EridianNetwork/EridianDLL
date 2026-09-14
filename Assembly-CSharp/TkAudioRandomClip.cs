using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x0200011F RID: 287
[AddComponentMenu("TkAudio/TkAudio Random Clip")]
public class TkAudioRandomClip : TkIAudioClip
{
	// Token: 0x06000668 RID: 1640 RVA: 0x000533C4 File Offset: 0x000515C4
	public void method_0()
	{
		this.m_list = new List<TkIAudioClip>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			TkIAudioClip component = child.GetComponent<TkIAudioClip>();
			if (component)
			{
				this.m_list.Add(component);
			}
		}
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x0005341C File Offset: 0x0005161C
	public override TkAudioSingleClip vmethod_0(bool bool_0)
	{
		method_0();
		if (m_list.Count <= 0)
		{
			return null;
		}
		List<string> value = null;
		TkAudioSource component = GetComponent<TkAudioSource>();
		if (!component)
		{
			return null;
		}
		string key = component.method_7();
		if (!lastPlayListDict.TryGetValue(key, out value))
		{
			value = new List<string>();
			lastPlayListDict.Add(key, value);
		}
		int num = TkMath.smethod_10(m_noRepeatLastCount, m_list.Count - 1);
		while (value.Count > num)
		{
			value.RemoveAt(0);
		}
		float num2 = m_playNothingRate;
		for (int i = 0; i < m_list.Count; i++)
		{
			TkIAudioClip tkIAudioClip = m_list[i];
			tkIAudioClip.m_tmpRandomRate = tkIAudioClip.m_randomRate;
			for (int j = 0; j < value.Count; j++)
			{
				string text = value[j];
				if (text == tkIAudioClip.name)
				{
					tkIAudioClip.m_tmpRandomRate = 0f;
					break;
				}
			}
			num2 += tkIAudioClip.m_tmpRandomRate;
		}
		float num3 = UnityEngine.Random.Range(0f, num2);
		float num4 = m_playNothingRate;
		if (num4 >= num3)
		{
			value.Add("<NullClip>");
			return null;
		}
		TkIAudioClip tkIAudioClip2 = null;
		for (int k = 0; k < m_list.Count; k++)
		{
			TkIAudioClip tkIAudioClip3 = m_list[k];
			num4 += tkIAudioClip3.m_tmpRandomRate;
			if (!(num4 < num3))
			{
				tkIAudioClip2 = tkIAudioClip3;
				break;
			}
		}
		if (tkIAudioClip2 == null)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TkAudioRandomClip error when random clip");
			return null;
		}
		value.Add(tkIAudioClip2.name);
		return tkIAudioClip2.vmethod_0(bool_0);
	}
	// Token: 0x040005DD RID: 1501
	[TkInspectorSlider(0f, 10f)]
	public int m_noRepeatLastCount;

	// Token: 0x040005DE RID: 1502
	[NonSerialized]
	public List<TkIAudioClip> m_list;

	// Token: 0x040005DF RID: 1503
	[HideInInspector]
	public float m_playNothingRate;

	// Token: 0x040005E0 RID: 1504
	public static Dictionary<string, List<string>> lastPlayListDict = new Dictionary<string, List<string>>();
}
