using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AD9 RID: 2777
public static class MecanimEventManager
{
	// Token: 0x17000794 RID: 1940
	// (get) Token: 0x06004B55 RID: 19285 RVA: 0x00031274 File Offset: 0x0002F474
	public static Dictionary<string, int> Dictionary_0
	{
		get
		{
			return MecanimEventManager.animatorControllerIdData;
		}
	}

	// Token: 0x06004B56 RID: 19286 RVA: 0x0003127B File Offset: 0x0002F47B
	public static void smethod_0(MecanimEventData mecanimEventData_0)
	{
		if (mecanimEventData_0 != null)
		{
			MecanimEventManager.eventDataSources = new MecanimEventData[1];
			MecanimEventManager.eventDataSources[0] = mecanimEventData_0;
			MecanimEventManager.smethod_5();
		}
	}

	// Token: 0x06004B57 RID: 19287 RVA: 0x0003129E File Offset: 0x0002F49E
	public static void smethod_1(MecanimEventData[] mecanimEventData_0)
	{
		if (mecanimEventData_0 != null)
		{
			MecanimEventManager.eventDataSources = mecanimEventData_0;
			MecanimEventManager.smethod_5();
		}
	}

	// Token: 0x06004B58 RID: 19288 RVA: 0x000312AE File Offset: 0x0002F4AE
	public static void OnLevelLoaded()
	{
		MecanimEventManager.globalLastStates.Clear();
	}

	// Token: 0x06004B59 RID: 19289 RVA: 0x000312BA File Offset: 0x0002F4BA
	public static void smethod_2(ref List<MecanimEvent> list_0, int int_0, Animator animator_0)
	{
		MecanimEventManager.smethod_3(ref list_0, MecanimEventManager.globalLoadedData, MecanimEventManager.globalLastStates, int_0, animator_0);
	}

	// Token: 0x06004B5A RID: 19290 RVA: 0x00138F50 File Offset: 0x00137150
	public static void smethod_3(ref List<MecanimEvent> list_0, Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> dictionary_0, Dictionary<int, Dictionary<int, AnimatorStateInfo>> dictionary_1, int int_0, Animator animator_0)
	{
		int hashCode = animator_0.GetHashCode();
		if (!dictionary_1.ContainsKey(hashCode))
		{
			dictionary_1[hashCode] = new Dictionary<int, AnimatorStateInfo>();
		}
		int layerCount = animator_0.layerCount;
		Dictionary<int, AnimatorStateInfo> dictionary = dictionary_1[hashCode];
		for (int i = 0; i < layerCount; i++)
		{
			if (!dictionary.ContainsKey(i))
			{
				dictionary[i] = default(AnimatorStateInfo);
			}
			AnimatorStateInfo currentAnimatorStateInfo = animator_0.GetCurrentAnimatorStateInfo(i);
			int num = (int)dictionary[i].normalizedTime;
			int num2 = (int)currentAnimatorStateInfo.normalizedTime;
			float num3 = dictionary[i].normalizedTime - (float)num;
			float num4 = currentAnimatorStateInfo.normalizedTime - (float)num2;
			if (dictionary[i].nameHash == currentAnimatorStateInfo.nameHash)
			{
				if (currentAnimatorStateInfo.loop)
				{
					if (num == num2)
					{
						MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, num3, num4, false);
					}
					else
					{
						MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, num3, 1.00001f, false);
						MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, num4, false);
					}
				}
				else
				{
					float num5 = Mathf.Clamp01(dictionary[i].normalizedTime);
					float num6 = Mathf.Clamp01(currentAnimatorStateInfo.normalizedTime);
					if (num == 0 && num2 == 0)
					{
						if (num5 != num6)
						{
							MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, num5, num6, false);
						}
					}
					else if (num == 0 && num2 > 0)
					{
						MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, dictionary[i].nameHash, dictionary[i].tagHash, num5, 1.00001f, false);
					}
				}
			}
			else
			{
				MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, currentAnimatorStateInfo.nameHash, currentAnimatorStateInfo.tagHash, 0f, num4, false);
				if (!dictionary[i].loop)
				{
					MecanimEventManager.smethod_4(ref list_0, dictionary_0, animator_0, int_0, i, dictionary[i].nameHash, dictionary[i].tagHash, num3, 1.00001f, true);
				}
			}
			dictionary[i] = currentAnimatorStateInfo;
		}
	}

	// Token: 0x06004B5B RID: 19291 RVA: 0x001391A4 File Offset: 0x001373A4
	private static void smethod_4(ref List<MecanimEvent> list_0, Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> dictionary_0, Animator animator_0, int int_0, int int_1, int int_2, int int_3, float float_0, float float_1, bool bool_0 = false)
	{
		if (dictionary_0.ContainsKey(int_0) && dictionary_0[int_0].ContainsKey(int_1) && dictionary_0[int_0][int_1].ContainsKey(int_2))
		{
			List<MecanimEvent> list = dictionary_0[int_0][int_1][int_2];
			for (int i = 0; i < list.Count; i++)
			{
				MecanimEvent mecanimEvent = list[i];
				if (mecanimEvent.isEnable && mecanimEvent.normalizedTime >= float_0 && mecanimEvent.normalizedTime < float_1 && mecanimEvent.condition.method_0(animator_0) && (!bool_0 || mecanimEvent.critical))
				{
					MecanimEvent mecanimEvent2 = new MecanimEvent(mecanimEvent);
					mecanimEvent2.method_2(new EventContext
					{
						controllerId = int_0,
						layer = int_1,
						stateHash = int_2,
						tagHash = int_3
					});
					list_0.Add(mecanimEvent2);
				}
			}
			return;
		}
	}

	// Token: 0x06004B5C RID: 19292 RVA: 0x00139298 File Offset: 0x00137498
	private static void smethod_5()
	{
		if (MecanimEventManager.eventDataSources == null)
		{
			return;
		}
		MecanimEventManager.globalLoadedData = new Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		MecanimEventManager.animatorControllerIdData = new Dictionary<string, int>();
		foreach (MecanimEventData mecanimEventData in MecanimEventManager.eventDataSources)
		{
			if (!(mecanimEventData == null))
			{
				MecanimEventDataEntry[] data = mecanimEventData.data;
				foreach (MecanimEventDataEntry mecanimEventDataEntry in data)
				{
					int hashCode = mecanimEventDataEntry.animatorControllerName.GetHashCode();
					if (!MecanimEventManager.animatorControllerIdData.ContainsKey(mecanimEventDataEntry.animatorControllerName))
					{
						MecanimEventManager.animatorControllerIdData[mecanimEventDataEntry.animatorControllerName] = hashCode;
					}
					if (!MecanimEventManager.globalLoadedData.ContainsKey(hashCode))
					{
						MecanimEventManager.globalLoadedData[hashCode] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
					}
					if (!MecanimEventManager.globalLoadedData[hashCode].ContainsKey(mecanimEventDataEntry.layer))
					{
						MecanimEventManager.globalLoadedData[hashCode][mecanimEventDataEntry.layer] = new Dictionary<int, List<MecanimEvent>>();
					}
					MecanimEventManager.globalLoadedData[hashCode][mecanimEventDataEntry.layer][mecanimEventDataEntry.stateNameHash] = new List<MecanimEvent>(mecanimEventDataEntry.events);
				}
			}
		}
	}

	// Token: 0x06004B5D RID: 19293 RVA: 0x001393D0 File Offset: 0x001375D0
	public static Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> smethod_6(MecanimEventData mecanimEventData_0)
	{
		Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> dictionary = new Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>>();
		MecanimEventDataEntry[] data = mecanimEventData_0.data;
		foreach (MecanimEventDataEntry mecanimEventDataEntry in data)
		{
			int instanceID = mecanimEventDataEntry.animatorController.GetInstanceID();
			if (!dictionary.ContainsKey(instanceID))
			{
				dictionary[instanceID] = new Dictionary<int, Dictionary<int, List<MecanimEvent>>>();
			}
			if (!dictionary[instanceID].ContainsKey(mecanimEventDataEntry.layer))
			{
				dictionary[instanceID][mecanimEventDataEntry.layer] = new Dictionary<int, List<MecanimEvent>>();
			}
			dictionary[instanceID][mecanimEventDataEntry.layer][mecanimEventDataEntry.stateNameHash] = new List<MecanimEvent>(mecanimEventDataEntry.events);
		}
		return dictionary;
	}

	// Token: 0x040036DD RID: 14045
	private static MecanimEventData[] eventDataSources;

	// Token: 0x040036DE RID: 14046
	private static Dictionary<int, Dictionary<int, Dictionary<int, List<MecanimEvent>>>> globalLoadedData;

	// Token: 0x040036DF RID: 14047
	private static Dictionary<int, Dictionary<int, AnimatorStateInfo>> globalLastStates = new Dictionary<int, Dictionary<int, AnimatorStateInfo>>();

	// Token: 0x040036E0 RID: 14048
	private static Dictionary<string, int> animatorControllerIdData;
}
