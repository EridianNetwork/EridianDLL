using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Core;
using UnityEngine;

// Token: 0x020005F7 RID: 1527
public class LocalizedStringManager : IContentManager
{
	// Token: 0x060026CD RID: 9933 RVA: 0x000BB464 File Offset: 0x000B9664
	public override void OnLanguageChange(string language)
	{
		this._strConfigFileName = "Localization/LocalizedString_" + language;
		this._dicLocalizedStringDB.Clear();
		string text = null;
		try
		{
			string text2 = Path.Combine(Application.dataPath, "../overrides/LocalizedString_" + language + "_override.xml");
			if (File.Exists(text2))
			{
				text = File.ReadAllText(text2);
				DebugUtils.Log(LogCategory.Framework, "LocalizedStringManager: using external override " + text2);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Framework, "LocalizedStringManager: override load failed: " + ex.Message);
			text = null;
		}
		string text3;
		if (text != null)
		{
			text3 = text;
		}
		else
		{
			TextAsset textAsset = (TextAsset)Resources.Load(this._strConfigFileName, typeof(TextAsset));
			if (textAsset == null)
			{
				DebugUtils.LogWarning(LogCategory.Framework, "Could not load localization string config: " + this._strConfigFileName);
				return;
			}
			text3 = textAsset.text;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text3);
		foreach (object obj in xmlDocument.GetElementsByTagName("localizedString"))
		{
			XmlNode xmlNode = (XmlNode)obj;
			XmlNode namedItem = xmlNode.Attributes.GetNamedItem("KeyName");
			XmlNode namedItem2 = xmlNode.Attributes.GetNamedItem("Words");
			if (namedItem2 != null)
			{
				if (this._dicLocalizedStringDB.ContainsKey(namedItem.Value))
				{
					this._dicLocalizedStringDB[namedItem.Value] = namedItem2.Value;
				}
				else
				{
					this._dicLocalizedStringDB.Add(namedItem.Value, namedItem2.Value);
				}
			}
		}
	}

	// Token: 0x060026CE RID: 9934 RVA: 0x0001A1DA File Offset: 0x000183DA
	public override void OnContentAdded(ILocalizedContent newContent)
	{
		this.vmethod_0(newContent as LocalizedString);
	}

	// Token: 0x060026CF RID: 9935 RVA: 0x000BB60C File Offset: 0x000B980C
	protected virtual void vmethod_0(LocalizedString localizedString_0)
	{
		if (localizedString_0 != null)
		{
			string string_ = localizedString_0.String_0;
			if (this._dicLocalizedStringDB.ContainsKey(string_))
			{
				localizedString_0.method_0(this._dicLocalizedStringDB[string_]);
			}
			else
			{
				this._dicLocalizedStringDB.Add(string_, LocalizedString.smethod_0(localizedString_0));
			}
		}
	}

	// Token: 0x060026D0 RID: 9936 RVA: 0x000BB658 File Offset: 0x000B9858
	public virtual void vmethod_1()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = xmlDocument.CreateElement("localization");
		foreach (KeyValuePair<string, string> keyValuePair in this._dicLocalizedStringDB)
		{
			XmlElement xmlElement2 = xmlDocument.CreateElement("localizedString");
			xmlElement2.SetAttribute("KeyName", keyValuePair.Key);
			xmlElement2.SetAttribute("Words", keyValuePair.Value);
			xmlElement.AppendChild(xmlElement2);
		}
		xmlDocument.AppendChild(xmlElement);
		xmlDocument.Save(this._strConfigFileName + ".xml");
	}

	// Token: 0x060026D1 RID: 9937 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_0(string string_0)
	{
	}

	// Token: 0x04001C37 RID: 7223
	private const string CONFIG_FILE_PREFIX_NAME = "LocalizedString_";

	// Token: 0x04001C38 RID: 7224
	private const string CONFIG_FILE_URL = "Localization/";

	// Token: 0x04001C39 RID: 7225
	protected Dictionary<string, string> _dicLocalizedStringDB = new Dictionary<string, string>();

	// Token: 0x04001C3A RID: 7226
	private string _strConfigFileName = string.Empty;
}
