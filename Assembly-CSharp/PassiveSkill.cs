using System;

// Token: 0x02000450 RID: 1104
[Serializable]
public class PassiveSkill
{
	// Token: 0x06001B7A RID: 7034 RVA: 0x00013CE0 File Offset: 0x00011EE0
	public PassiveSkill()
	{
		this.m_probability = 0;
		this.m_passiveSkillType = PassiveSkillType.None;
		this.m_skillID = 0;
	}

	// Token: 0x040011FE RID: 4606
	public int m_probability;

	// Token: 0x040011FF RID: 4607
	public PassiveSkillType m_passiveSkillType;

	// Token: 0x04001200 RID: 4608
	public int m_skillID;
}
