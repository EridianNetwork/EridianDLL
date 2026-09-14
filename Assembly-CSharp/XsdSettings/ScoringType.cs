using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A13 RID: 2579
	[XmlInclude(typeof(ScoringSetupPVE))]
	[XmlInclude(typeof(ScoringBase))]
	[XmlInclude(typeof(ScoringSetupPVP))]
	public class ScoringType
	{
	}
}
