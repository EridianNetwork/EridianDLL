using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Shops whose item type has no server roll script (Materials, Override) take their
// vending list from overrides/ShopStock_override.xml instead.
public static class ShopStockOverride
{
	private const string StockFileName = "ShopStock_override.xml";

	private static bool _loaded;

	private static bool _shopsXmlFound;

	private static Dictionary<int, List<ShopItem>> _itemsByShop = new Dictionary<int, List<ShopItem>>();

	private static Dictionary<int, string> _shopTypes = new Dictionary<int, string>();

	private static EconomicSettings _serverPrices;

	public static Shop Apply(int shopId, Shop serverShop, ShopSetup setup, EconomicSettings prices)
	{
		EnsureLoaded();
		List<ShopItem> items;
		if (!ShouldUseFile(shopId) || !_itemsByShop.TryGetValue(shopId, out items))
		{
			return serverShop;
		}
		Shop shop = serverShop;
		if (shop == null)
		{
			int refreshTime = 86400;
			double sellRatio = setup != null ? setup.m_soldRatio : 0.2;
			if (setup != null && setup.m_shops != null)
			{
				for (int i = 0; i < setup.m_shops.Length; i++)
				{
					if (setup.m_shops[i] != null && setup.m_shops[i].m_id == shopId)
					{
						refreshTime = setup.m_shops[i].m_refreshTime;
						break;
					}
				}
			}
			shop = new Shop(shopId, refreshTime, sellRatio);
		}
		EconomicSettings priceSettings = ServerPrices(prices);
		Dictionary<int, ShopItem> inventory = new Dictionary<int, ShopItem>();
		for (int j = 0; j < items.Count; j++)
		{
			ShopItem shopItem = items[j];
			int price = PriceFor(shopItem.Item, priceSettings);
			shopItem.Price = price;
			if (shopItem.Item != null)
			{
				shopItem.Item.method_2(price);
			}
			inventory[j] = shopItem;
		}
		shop.SetInventory(inventory);
		return shop;
	}

	private static bool ShouldUseFile(int shopId)
	{
		if (!_itemsByShop.ContainsKey(shopId))
		{
			return false;
		}
		if (!_shopsXmlFound)
		{
			return true;
		}
		string itemType;
		if (!_shopTypes.TryGetValue(shopId, out itemType))
		{
			return false;
		}
		return IsFileBackedType(itemType);
	}

	private static bool IsFileBackedType(string itemType)
	{
		return itemType == "Materials" || itemType == "Material" || itemType == "Override";
	}

	private static void EnsureLoaded()
	{
		if (_loaded)
		{
			return;
		}
		_loaded = true;
		_itemsByShop = new Dictionary<int, List<ShopItem>>();
		_shopTypes = new Dictionary<int, string>();
		string shopsPath = Path.GetFullPath(Path.Combine(Application.dataPath, "../OfflineServer/data/shop/Shops.xml"));
		_shopsXmlFound = File.Exists(shopsPath);
		if (_shopsXmlFound)
		{
			ReadShopTypes(shopsPath);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: Shops.xml not found at " + shopsPath);
		}
		string stockPath = Path.GetFullPath(Path.Combine(Application.dataPath, "../overrides/" + StockFileName));
		if (!File.Exists(stockPath))
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: missing " + stockPath);
			return;
		}
		ReadStock(stockPath);
	}

	private static void ReadShopTypes(string path)
	{
		try
		{
			XmlDocument document = new XmlDocument();
			document.Load(path);
			XmlNodeList shops = document.GetElementsByTagName("m_shop");
			for (int i = 0; i < shops.Count; i++)
			{
				XmlNode shopNode = shops[i];
				int shopId;
				if (!int.TryParse(ChildText(shopNode, "m_id"), out shopId))
				{
					continue;
				}
				string itemType = FirstItemType(shopNode);
				if (!string.IsNullOrEmpty(itemType))
				{
					_shopTypes[shopId] = itemType;
				}
			}
		}
		catch (Exception ex)
		{
			_shopsXmlFound = false;
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: failed to read Shops.xml: " + ex.Message);
		}
	}

	private static void ReadStock(string path)
	{
		try
		{
			XmlDocument document = new XmlDocument();
			document.Load(path);
			XmlNodeList shops = document.GetElementsByTagName("m_shop");
			int loadedShops = 0;
			int loadedItems = 0;
			for (int i = 0; i < shops.Count; i++)
			{
				XmlNode shopNode = shops[i];
				int shopId;
				if (!int.TryParse(ChildText(shopNode, "m_id"), out shopId))
				{
					continue;
				}
				XmlNode itemsNode = shopNode["m_items"];
				if (itemsNode == null)
				{
					continue;
				}
				List<ShopItem> items = new List<ShopItem>();
				foreach (XmlNode itemNode in itemsNode.ChildNodes)
				{
					if (itemNode.NodeType != XmlNodeType.Element || itemNode.Name != "m_item")
					{
						continue;
					}
					ShopItem shopItem = BuildItem(itemNode, shopId);
					if (shopItem != null)
					{
						items.Add(shopItem);
						loadedItems++;
					}
				}
				_itemsByShop[shopId] = items;
				loadedShops++;
			}
			DebugUtils.Log(LogCategory.Gamelogic, "ShopStockOverride: loaded " + loadedItems + " items across " + loadedShops + " shops from " + path);
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: failed to read stock file: " + ex.Message);
		}
	}

	private static ShopItem BuildItem(XmlNode itemNode, int shopId)
	{
		string itemType = ChildText(itemNode, "m_itemType");
		if (string.IsNullOrEmpty(itemType))
		{
			itemType = "Material";
		}
		if (itemType != "Material" && itemType != "Materials")
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: shop " + shopId + " skipped unsupported item type " + itemType);
			return null;
		}
		string materialName = ChildText(itemNode, "m_materialType");
		MaterialType materialType;
		if (!TryParseEnum<MaterialType>(materialName, out materialType) || materialType == MaterialType.TOTAL)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: shop " + shopId + " skipped unknown material " + materialName);
			return null;
		}
		int stack = 1;
		string valueText = ChildText(itemNode, "m_value");
		if (!string.IsNullOrEmpty(valueText))
		{
			int.TryParse(valueText, out stack);
		}
		if (stack < 1)
		{
			stack = 1;
		}
		int quantity = 1;
		string quantityText = ChildText(itemNode, "m_quantity");
		if (!string.IsNullOrEmpty(quantityText))
		{
			int.TryParse(quantityText, out quantity);
		}
		if (quantity < 1)
		{
			quantity = 1;
		}
		ItemDNA item = ItemDNA.smethod_3(materialType, stack);
		return new ShopItem
		{
			Item = item,
			Quantity = quantity
		};
	}

	private static EconomicSettings ServerPrices(EconomicSettings fallback)
	{
		if (_serverPrices != null)
		{
			return _serverPrices;
		}
		string path = Path.GetFullPath(Path.Combine(Application.dataPath, "../OfflineServer/data/shop/EconomicSettings.xml"));
		if (!File.Exists(path))
		{
			return fallback;
		}
		try
		{
			XmlSerializer serializer = new XmlSerializer(typeof(EconomicSettings));
			using (StringReader reader = new StringReader(File.ReadAllText(path)))
			{
				_serverPrices = serializer.Deserialize(reader) as EconomicSettings;
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "ShopStockOverride: failed to read EconomicSettings.xml: " + ex.Message);
			return fallback;
		}
		return _serverPrices ?? fallback;
	}

	private static int PriceFor(ItemDNA item, EconomicSettings prices)
	{
		if (item == null || prices == null || prices.m_priceSettings == null)
		{
			return 0;
		}
		for (int i = 0; i < prices.m_priceSettings.Length; i++)
		{
			ItemPriceSetting setting = prices.m_priceSettings[i];
			if (setting == null || setting.m_itemType != item.m_type)
			{
				continue;
			}
			int price = setting.m_basicValue;
			if (setting.m_adjustements != null)
			{
				for (int j = 0; j < setting.m_adjustements.Length; j++)
				{
					if (setting.m_adjustements[j].m_rarety == (WeaponRarity)item.ItemRarity_0)
					{
						return price * (int)((double)setting.m_adjustements[j].m_adjustValue * (double)item.method_0());
					}
				}
			}
			return price;
		}
		return 0;
	}

	private static string FirstItemType(XmlNode shopNode)
	{
		foreach (XmlNode node in shopNode.SelectNodes(".//m_itemType"))
		{
			if (node != null && !string.IsNullOrEmpty(node.InnerText))
			{
				return node.InnerText.Trim();
			}
		}
		return null;
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
