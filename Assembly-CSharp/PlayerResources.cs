using System;
using System.Xml.Serialization;

// Token: 0x02000132 RID: 306
[Serializable]
public class PlayerResources
{
	// Token: 0x04000658 RID: 1624
	[XmlElement(ElementName = "Common")]
	public PlayerResources.BundleSet m_commonBundleSet;

	// Token: 0x04000659 RID: 1625
	[XmlElement(ElementName = "ClassSpecific")]
	public PlayerResources.BundleSet[] m_classSpecificBundleSets = new PlayerResources.BundleSet[4];

	// Token: 0x0400065A RID: 1626
	[XmlElement(ElementName = "LocalPlayer")]
	public PlayerResources.BundleSet[] m_localPlayerBundleSets = new PlayerResources.BundleSet[4];

	// Token: 0x0400065B RID: 1627
	[XmlElement(ElementName = "CommonTown")]
	public PlayerResources.BundleSet m_commonTownBundleSet;

	// Token: 0x0400065C RID: 1628
	[XmlElement(ElementName = "PlayerTown")]
	public PlayerResources.BundleSet[] m_playerTownBundleSets = new PlayerResources.BundleSet[4];

	// Token: 0x02000133 RID: 307
	[Serializable]
	public class BundleSet
	{
		// Token: 0x0400065D RID: 1629
		[XmlAttribute(AttributeName = "Type")]
		public string m_type;

		// Token: 0x0400065E RID: 1630
		[XmlElement(ElementName = "Bundle")]
		public string[] m_bundles;
	}
}
