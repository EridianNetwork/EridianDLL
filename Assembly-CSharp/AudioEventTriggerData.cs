using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Core;
using UnityEngine;

// Token: 0x020000E8 RID: 232
[ExecuteInEditMode]
public class AudioEventTriggerData : EventTriggerData
{
	// Token: 0x06000598 RID: 1432 RVA: 0x00006DA2 File Offset: 0x00004FA2
	public static bool smethod_0(AudioEventTriggerData.ResourceStrategy resourceStrategy_0)
	{
		return resourceStrategy_0 == AudioEventTriggerData.ResourceStrategy.Player || AudioEventTriggerData.ResourceStrategy.Player_Town == resourceStrategy_0;
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00050DEC File Offset: 0x0004EFEC
	public static AudioEventTriggerData.ResourceStrategy smethod_1(string string_0)
	{
		AudioEventTriggerData.ResourceStrategy resourceStrategy = AudioEventTriggerData.ResourceStrategy.Automatic;
		try
		{
			resourceStrategy = (AudioEventTriggerData.ResourceStrategy)((int)Enum.Parse(typeof(AudioEventTriggerData.ResourceStrategy), string_0));
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Unknown resource strategy: " + string_0 + " - from: " + ex.ToString());
		}
		return resourceStrategy;
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00050E44 File Offset: 0x0004F044
	public static AudioEventTriggerData.ResourceStrategy smethod_2(XmlDocument xmlDocument_0)
	{
		AudioEventTriggerData.ResourceStrategy resourceStrategy = AudioEventTriggerData.ResourceStrategy.Automatic;
		if (xmlDocument_0.DocumentElement.HasAttribute(AudioEventTriggerData.RESOURCESTRATEGY_ATTR_NAME))
		{
			resourceStrategy = AudioEventTriggerData.smethod_1(xmlDocument_0.DocumentElement.GetAttribute(AudioEventTriggerData.RESOURCESTRATEGY_ATTR_NAME));
		}
		return resourceStrategy;
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x0600059B RID: 1435 RVA: 0x00006DAF File Offset: 0x00004FAF
	private static string String_0
	{
		get
		{
			return "Assets/Resources/" + AudioEventTriggerData.String_1;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x00006DC0 File Offset: 0x00004FC0
	private static string String_1
	{
		get
		{
			return "Audio/EventLists/";
		}
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x00006DC7 File Offset: 0x00004FC7
	private static string smethod_3(string string_0)
	{
		return Path.GetFileNameWithoutExtension(string_0) + ".xml";
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x00006DD9 File Offset: 0x00004FD9
	public static string smethod_4(string string_0)
	{
		return Path.Combine(AudioEventTriggerData.String_0, AudioEventTriggerData.smethod_3(string_0));
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x00050E7C File Offset: 0x0004F07C
	private void method_3(SoundActionInfo soundActionInfo_0, XmlNode xmlNode_0)
	{
		if (xmlNode_0.Attributes[AudioEventTriggerData.AUDIOPREFABNAME_TAG_NAME] != null)
		{
			soundActionInfo_0.m_sAudioPrefabName = xmlNode_0.Attributes[AudioEventTriggerData.AUDIOPREFABNAME_TAG_NAME].Value;
		}
		if (xmlNode_0.Attributes["Interval"] != null)
		{
			soundActionInfo_0.m_fInterval = Convert.ToSingle(xmlNode_0.Attributes["Interval"].Value);
		}
		if (xmlNode_0.Attributes["Delay"] != null)
		{
			soundActionInfo_0.m_fDelay = Convert.ToSingle(xmlNode_0.Attributes["Delay"].Value);
		}
		if (xmlNode_0.Attributes["DistanceToTrigger"] != null)
		{
			soundActionInfo_0.m_fDistanceToTrigger = Convert.ToSingle(xmlNode_0.Attributes["DistanceToTrigger"].Value);
		}
		if (xmlNode_0.Attributes["Behaviour"] != null)
		{
			try
			{
				soundActionInfo_0.m_eAction = (AudioEventAction)((int)Enum.Parse(typeof(AudioEventAction), xmlNode_0.Attributes["Behaviour"].Value));
			}
			catch
			{
				soundActionInfo_0.m_eAction = AudioEventAction.Play;
			}
		}
		if (xmlNode_0.Attributes["FadeTime"] != null)
		{
			soundActionInfo_0.m_fFadeTime = Convert.ToSingle(xmlNode_0.Attributes["FadeTime"].Value);
		}
		if (xmlNode_0.Attributes[AudioEventTriggerData.CLASSSPECIFIC_ATTRNAME] != null)
		{
			soundActionInfo_0.m_isClassSpecific = Convert.ToBoolean(xmlNode_0.Attributes[AudioEventTriggerData.CLASSSPECIFIC_ATTRNAME].Value);
		}
		if (xmlNode_0.Attributes[AudioEventTriggerData.LOCALPLAYERONLY_ATTRNAME] != null)
		{
			soundActionInfo_0.m_isLocalPlayerOnly = Convert.ToBoolean(xmlNode_0.Attributes[AudioEventTriggerData.LOCALPLAYERONLY_ATTRNAME].Value);
		}
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00051040 File Offset: 0x0004F240
	public bool method_4(string string_0, List<string> list_0 = null)
	{
		base.method_1();
		this.m_fileName = string_0;
		XmlDocument xmlDocument = new XmlDocument();
		bool flag;
		try
		{
			string text = AudioEventTriggerData.String_1 + Path.GetFileNameWithoutExtension(string_0);
			TextAsset textAsset = ResourcesLoader.smethod_0(text) as TextAsset;
			if (textAsset == null)
			{
				throw new ArgumentException("Could not load resource from: " + text);
			}
			xmlDocument.LoadXml(textAsset.text);
			ResourcesLoader.smethod_6(textAsset);
			goto IL_0078;
		}
		catch
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Audio Event Trigger Control file doesn't exist @: " + string_0);
			flag = false;
		}
		return flag;
		IL_0078:
		this.m_resourceStrategy = AudioEventTriggerData.smethod_2(xmlDocument);
		if (!this.method_6(xmlDocument.DocumentElement, list_0))
		{
			return false;
		}
		XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(AudioEventTriggerData.AUDIOEVENT_TAG_NAME);
		for (int i = 0; i < xmlNodeList.Count; i++)
		{
			XmlNode xmlNode = xmlNodeList[i];
			AudioEventHandler audioEventHandler = new AudioEventHandler();
			if (xmlNode.Attributes[AudioEventTriggerData.AUDIOEVENTNAME_TAG_NAME] != null)
			{
				audioEventHandler.m_eventName = xmlNode.Attributes[AudioEventTriggerData.AUDIOEVENTNAME_TAG_NAME].Value;
			}
			if (xmlNode.Attributes["Type"] != null)
			{
				audioEventHandler.m_type = (EventTriggerType)((int)Enum.Parse(typeof(EventTriggerType), xmlNode.Attributes["Type"].Value));
			}
			if (xmlNode.Attributes["MyltiPrefab"] == null)
			{
				audioEventHandler.method_2();
				audioEventHandler.m_distanceToTrigger = Convert.ToSingle(xmlNode.Attributes["DistanceToTrigger"].Value);
				this.method_3(audioEventHandler.m_soundList[0], xmlNode);
				base.method_0(audioEventHandler.m_eventName, audioEventHandler, true);
			}
			else
			{
				int num = Convert.ToInt32(xmlNode.Attributes["MyltiPrefab"].Value);
				for (int j = 0; j < num; j++)
				{
					audioEventHandler.method_2();
					XmlNode xmlNode2 = xmlNode.ChildNodes[j];
					this.method_3(audioEventHandler.m_soundList[j], xmlNode2);
				}
				base.method_0(audioEventHandler.m_eventName, audioEventHandler, true);
			}
		}
		xmlNodeList = xmlDocument.GetElementsByTagName("RandomEventTrigger");
		for (int k = 0; k < xmlNodeList.Count; k++)
		{
			XmlNode xmlNode3 = xmlNodeList[k];
			EventRandomTrigger eventRandomTrigger = new EventRandomTrigger();
			if (xmlNode3.Attributes[AudioEventTriggerData.AUDIOEVENTNAME_TAG_NAME] != null)
			{
				eventRandomTrigger.m_eventName = xmlNode3.Attributes[AudioEventTriggerData.AUDIOEVENTNAME_TAG_NAME].Value;
			}
			if (xmlNode3.Attributes["RangeMin"] != null)
			{
				eventRandomTrigger.m_rangeMin = Convert.ToSingle(xmlNode3.Attributes["RangeMin"].Value);
			}
			if (xmlNode3.Attributes["RangeMax"] != null)
			{
				eventRandomTrigger.m_rangeMax = Convert.ToSingle(xmlNode3.Attributes["RangeMax"].Value);
			}
			this.m_randomTriggers.Add(eventRandomTrigger);
		}
		return true;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00051350 File Offset: 0x0004F550
	private void method_5(XmlElement xmlElement_0)
	{
		XmlDocument ownerDocument = xmlElement_0.OwnerDocument;
		XmlNodeList elementsByTagName = ownerDocument.GetElementsByTagName("Module");
		if (elementsByTagName.Count > 0)
		{
			this.m_moduleFileNames = new string[elementsByTagName.Count];
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlElement xmlElement = elementsByTagName[i] as XmlElement;
				this.m_moduleFileNames[i] = xmlElement.GetAttribute("Filename");
			}
		}
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x000513BC File Offset: 0x0004F5BC
	private bool method_6(XmlElement xmlElement_0, List<string> list_0)
	{
		bool flag = true;
		this.method_5(xmlElement_0);
		if (base.method_2())
		{
			if (list_0 == null)
			{
				list_0 = new List<string>();
			}
			int count = list_0.Count;
			if (count >= 10)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "Suspiciously high AudioEventData dependency depth for module: " + this.m_fileName + " in AudioEventData hierarchy: " + string.Join(", ", list_0.ToArray()));
			}
			list_0.Add(this.m_fileName);
			AudioEventTriggerData audioEventTriggerData = new AudioEventTriggerData();
			for (int i = 0; i < this.m_moduleFileNames.Length; i++)
			{
				string text = this.m_moduleFileNames[i];
				if (list_0.Contains(text))
				{
					DebugUtils.LogWarning(LogCategory.Audio, "Cyclic AudioEventTriggerData module dependency for module: " + text + " in AudioEventData hierarchy: " + string.Join(", ", list_0.ToArray()));
					flag = false;
				}
				else if (!audioEventTriggerData.method_4(text, list_0))
				{
					flag = false;
				}
				else
				{
					foreach (KeyValuePair<string, BaseEventHandler> keyValuePair in audioEventTriggerData.Dictionary_0)
					{
						base.method_0(keyValuePair.Key, keyValuePair.Value, true);
					}
					int count2 = audioEventTriggerData.List_0.Count;
					for (int j = 0; j < count2; j++)
					{
						this.m_randomTriggers.Add(audioEventTriggerData.List_0[j]);
					}
				}
			}
			foreach (KeyValuePair<string, BaseEventHandler> keyValuePair2 in this.m_eventHandlers)
			{
				BaseEventHandler value = keyValuePair2.Value;
				value.method_1(false);
			}
			for (int k = 0; k < this.m_randomTriggers.Count; k++)
			{
				this.m_randomTriggers[k].method_2(false);
			}
			if (list_0.Count > count)
			{
				list_0.RemoveRange(count, list_0.Count - count);
			}
		}
		return flag;
	}

	// Token: 0x040004F5 RID: 1269
	private const string MODULES_NODE_NAME = "Modules";

	// Token: 0x040004F6 RID: 1270
	private const string MODULE_NODE_NAME = "Module";

	// Token: 0x040004F7 RID: 1271
	private const string MODULE_FILE_ATTR_NAME = "Filename";

	// Token: 0x040004F8 RID: 1272
	private const string XML_FILE_EXTENSION = ".xml";

	// Token: 0x040004F9 RID: 1273
	private const int MAX_MODULE_DEPTH = 10;

	// Token: 0x040004FA RID: 1274
	public AudioEventTriggerData.ResourceStrategy m_resourceStrategy;

	// Token: 0x040004FB RID: 1275
	public static readonly string AUDIOEVENTLIST_TAG_NAME = "AudioEventList";

	// Token: 0x040004FC RID: 1276
	public static readonly string RESOURCESTRATEGY_ATTR_NAME = "ResourceStrategy";

	// Token: 0x040004FD RID: 1277
	public static readonly string AUDIOEVENT_TAG_NAME = "AudioEvent";

	// Token: 0x040004FE RID: 1278
	public static readonly string AUDIOEVENTNAME_TAG_NAME = "EventName";

	// Token: 0x040004FF RID: 1279
	public static readonly string AUDIOPREFABNAME_TAG_NAME = "AudioPrefabName";

	// Token: 0x04000500 RID: 1280
	public static readonly string CLASSSPECIFIC_ATTRNAME = "ClassSpecific";

	// Token: 0x04000501 RID: 1281
	public static readonly string LOCALPLAYERONLY_ATTRNAME = "LocalPlayer";

	// Token: 0x020000E9 RID: 233
	public enum ResourceStrategy
	{
		// Token: 0x04000503 RID: 1283
		Automatic,
		// Token: 0x04000504 RID: 1284
		Manual,
		// Token: 0x04000505 RID: 1285
		Player,
		// Token: 0x04000506 RID: 1286
		Player_Town
	}

	// Token: 0x020000EA RID: 234
	private enum ResourceStrategyUtil
	{
		// Token: 0x04000508 RID: 1288
		END = 4
	}
}
