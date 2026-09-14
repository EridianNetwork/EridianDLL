using System;
using System.Xml.Serialization;

// Token: 0x02000546 RID: 1350
public enum PassiveSkillType
{
	// Token: 0x0400172C RID: 5932
	None,
	// Token: 0x0400172D RID: 5933
	[XmlEnum(Name = "HPMultiplier")]
	HPMultiplier,
	// Token: 0x0400172E RID: 5934
	[XmlEnum(Name = "RangeDamageMultiplier")]
	RangeDamageMultiplier,
	// Token: 0x0400172F RID: 5935
	[XmlEnum(Name = "MeleeDamageMultiplier")]
	MeleeDamageMultiplier,
	// Token: 0x04001730 RID: 5936
	[XmlEnum(Name = "SpeedMultiplier")]
	SpeedMultiplier,
	// Token: 0x04001731 RID: 5937
	[XmlEnum(Name = "BerserkAura")]
	BerserkAura
}
