using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

// Token: 0x02000135 RID: 309
[Serializable]
public class AudioPackageList
{
	// Token: 0x06000720 RID: 1824 RVA: 0x00003197 File Offset: 0x00001397
	public AudioPackageList()
	{
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x00007B25 File Offset: 0x00005D25
	public AudioPackageList(IEnumerable<string> ienumerable_0)
	{
		this.m_packages = ienumerable_0.ToArray<string>();
	}

	// Token: 0x04000663 RID: 1635
	public const string AUDIO_PACKAGE_ELEMENT_NAME = "AudioPackage";

	// Token: 0x04000664 RID: 1636
	public const string AUDIO_PACKAGE_NAME_ATTR_NAME = "name";

	// Token: 0x04000665 RID: 1637
	[XmlElement(ElementName = "AudioPackage")]
	public string[] m_packages;
}
