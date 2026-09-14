using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020004A9 RID: 1193
public class ObjectiveManager : ServiceWrapperBase<ObjectiveManager>
{
	// Token: 0x06001FF0 RID: 8176 RVA: 0x0009BFE4 File Offset: 0x0009A1E4
	public void method_0(string string_0, string string_1, string string_2)
	{
		string text = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestTrackView>().method_7(LocalizedString.smethod_0(new LocalizedString(string_1)), LocalizedString.smethod_0(new LocalizedString(string_2)));
		this.m_objectives.Add(string_0, text);
	}

	// Token: 0x06001FF1 RID: 8177 RVA: 0x0009C02C File Offset: 0x0009A22C
	public void method_1(string string_0, bool bool_1)
	{
		string text;
		if (this.m_objectives.TryGetValue(string_0, out text))
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestTrackView>().method_8(text);
			this.m_objectives.Remove(string_0);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new string[]
			{
				"You are trying to remove Objective [",
				string_0,
				"] which has never been given on map[",
				Application.loadedLevelName,
				"]"
			}));
		}
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x0009C0A4 File Offset: 0x0009A2A4
	public void method_2()
	{
		QuestTrackView questTrackView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestTrackView>();
		if (questTrackView == null)
		{
			return;
		}
		Dictionary<string, string>.Enumerator enumerator = this.m_objectives.GetEnumerator();
		while (enumerator.MoveNext())
		{
			QuestTrackView questTrackView2 = questTrackView;
			KeyValuePair<string, string> keyValuePair = enumerator.Current;
			questTrackView2.method_8(keyValuePair.Value);
		}
		this.m_objectives.Clear();
	}

	// Token: 0x040014A2 RID: 5282
	private Dictionary<string, string> m_objectives = new Dictionary<string, string>();
}
