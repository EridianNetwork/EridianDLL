using System.Collections.Generic;
using XsdSettings;

public static class MaterialRarityOverride
{
	private static readonly Dictionary<MaterialType, ItemRarity> _rarities = new Dictionary<MaterialType, ItemRarity>
	{
		{ MaterialType.MT_Titanium, ItemRarity.Common },
		{ MaterialType.MT_Ceramic, ItemRarity.Common },
		{ MaterialType.MT_Chitin, ItemRarity.Uncommon },
		{ MaterialType.MT_Tongue, ItemRarity.Rare },
		{ MaterialType.MT_Gland, ItemRarity.Common },
		{ MaterialType.MT_Sheet, ItemRarity.VeryRare },
		{ MaterialType.MT_Spider_Fang, ItemRarity.Rare },
		{ MaterialType.MT_Diamond_Shell, ItemRarity.Uncommon },
		{ MaterialType.MT_Purple_Crystal, ItemRarity.VeryRare },
		{ MaterialType.MT_PolyesterPlastic, ItemRarity.Common },
		{ MaterialType.MT_TitaniumAxiscore, ItemRarity.Uncommon },
		{ MaterialType.MT_PulseBrass, ItemRarity.Rare },
		{ MaterialType.MT_MetalCoil, ItemRarity.Common }
	};

	public static ItemRarity RarityFor(MaterialType materialType)
	{
		ItemRarity rarity;
		if (_rarities.TryGetValue(materialType, out rarity))
		{
			return rarity;
		}
		return ItemRarity.Common;
	}
}
