using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Core;
using UnityEngine;
using XsdSettings;

public static class MaterialRarityOverride
{
	private const string FileName = "MaterialRarity_override.xml";

	private static bool _loaded;

	private static Dictionary<MaterialType, ItemRarity> _rarities = new Dictionary<MaterialType, ItemRarity>();

	public static ItemRarity RarityFor(MaterialType materialType)
	{
		EnsureLoaded();
		ItemRarity rarity;
		if (_rarities.TryGetValue(materialType, out rarity))
		{
			return rarity;
		}
		return ItemRarity.Common;
	}

	private static void EnsureLoaded()
	{
		if (_loaded)
		{
			return;
		}
		_loaded = true;
		_rarities = new Dictionary<MaterialType, ItemRarity>();
		string path = Path.GetFullPath(Path.Combine(Application.dataPath, "../overrides/" + FileName));
		if (!File.Exists(path))
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "MaterialRarityOverride: missing " + path);
			return;
		}
		try
		{
			XmlDocument document = new XmlDocument();
			document.Load(path);
			XmlNodeList nodes = document.GetElementsByTagName("m_material");
			int loaded = 0;
			for (int i = 0; i < nodes.Count; i++)
			{
				XmlNode node = nodes[i];
				MaterialType materialType;
				ItemRarity rarity;
				if (!TryParseEnum<MaterialType>(ChildText(node, "m_materialType"), out materialType) || materialType == MaterialType.TOTAL)
				{
					DebugUtils.LogWarning(LogCategory.Gamelogic, "MaterialRarityOverride: skipped unknown material " + ChildText(node, "m_materialType"));
					continue;
				}
				if (!TryParseEnum<ItemRarity>(ChildText(node, "m_rarity"), out rarity) || rarity == ItemRarity.TOTAL)
				{
					DebugUtils.LogWarning(LogCategory.Gamelogic, "MaterialRarityOverride: skipped unknown rarity for " + materialType);
					continue;
				}
				_rarities[materialType] = rarity;
				loaded++;
			}
			DebugUtils.Log(LogCategory.Gamelogic, "MaterialRarityOverride: loaded " + loaded + " rarities from " + path);
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "MaterialRarityOverride: failed to read " + path + ": " + ex.Message);
		}
	}

	private static string ChildText(XmlNode node, string name)
	{
		if (node == null)
		{
			return null;
		}
		XmlNode child = node[name];
		if (child == null || child.InnerText == null)
		{
			return null;
		}
		return child.InnerText.Trim();
	}

	private static bool TryParseEnum<T>(string name, out T value)
	{
		value = default(T);
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		string[] names = Enum.GetNames(typeof(T));
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i] == name)
			{
				value = (T)Enum.Parse(typeof(T), names[i]);
				return true;
			}
		}
		return false;
	}
}
