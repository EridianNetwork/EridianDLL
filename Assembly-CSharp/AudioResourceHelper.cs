using System;
using System.Xml;
using Core;
using UnityEngine;

// Token: 0x0200012D RID: 301
internal class AudioResourceHelper
{
	// Token: 0x060006F0 RID: 1776 RVA: 0x00007984 File Offset: 0x00005B84
	public static string smethod_0(string string_0)
	{
		return "Audio/" + string_0;
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x00007991 File Offset: 0x00005B91
	public static string smethod_1(string string_0)
	{
		return "Assets/Resources/Audio/" + string_0 + ".xml";
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x000555F8 File Offset: 0x000537F8
	public static XmlDocument smethod_2(string string_0)
	{
		XmlDocument xmlDocument = null;
		try
		{
			xmlDocument = new XmlDocument();
			TextAsset textAsset = ResourcesLoader.smethod_0(AudioResourceHelper.smethod_0(string_0)) as TextAsset;
			if (null == textAsset)
			{
				DebugUtils.LogError(LogCategory.Audio, "Loading error: " + AudioResourceHelper.smethod_0(string_0) + " missing");
				xmlDocument = null;
			}
			else
			{
				xmlDocument.LoadXml(textAsset.text);
			}
		}
		catch
		{
			DebugUtils.Log(LogCategory.Audio, "Error loading Xml doc from resource: " + string_0);
			xmlDocument = null;
		}
		return xmlDocument;
	}
}
