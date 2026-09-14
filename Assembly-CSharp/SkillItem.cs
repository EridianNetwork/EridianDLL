using System;
using ns0;
using XsdSettings;

// Token: 0x02000767 RID: 1895
public class SkillItem
{
	// Token: 0x06003236 RID: 12854 RVA: 0x00020B42 File Offset: 0x0001ED42
	public SkillItem(ESkillType eskillType_0, int int_0 = 5)
	{
		this.m_type = eskillType_0;
		this.m_maxGrade = int_0;
	}

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06003237 RID: 12855 RVA: 0x00020B58 File Offset: 0x0001ED58
	public int Int32_0
	{
		get
		{
			if (this.m_localPlayer == null)
			{
				this.m_localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			}
			return this.m_localPlayer.SkillTreeStatus_0.method_2(this.m_type);
		}
	}

	// Token: 0x06003238 RID: 12856 RVA: 0x00020B98 File Offset: 0x0001ED98
	public void OnClick()
	{
		this.m_expect_grade = (this.Int32_0 + 1) % (this.m_maxGrade + 1);
	}

	// Token: 0x06003239 RID: 12857 RVA: 0x000E3670 File Offset: 0x000E1870
	public string method_0()
	{
		string text = string.Empty;
		Skill skill = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_4((int)this.m_type);
		if (skill.m_effectList[0].m_type == EffectType.Invalid)
		{
			text = this.m_type.ToString();
		}
		else
		{
			text = skill.m_effectList[0].m_type.ToString();
		}
		return text;
	}

	// Token: 0x040022B1 RID: 8881
	public ESkillType m_type;

	// Token: 0x040022B2 RID: 8882
	private int m_maxGrade;

	// Token: 0x040022B3 RID: 8883
	public int m_expect_grade;

	// Token: 0x040022B4 RID: 8884
	private EntityPlayer m_localPlayer;
}
