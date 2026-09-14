using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020003F2 RID: 1010
public class SkillTreeServiceWrapper : ServiceWrapper<ISkillTreeServiceWrapper, SkillTreeServiceWrapper>, ISkillTreeServiceNotificationListerner
{
	// Token: 0x0600195F RID: 6495 RVA: 0x00084300 File Offset: 0x00082500
	public override void vmethod_1()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/SkillTree");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SkillTreeSetup));
			this.m_skillTreeSetup = xmlSerializer.Deserialize(stringReader) as SkillTreeSetup;
		}
		Resources.UnloadAsset(textAsset);
		textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/SkillNode");
		using (StringReader stringReader2 = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(SkillSetup));
			this.m_skillSetup = xmlSerializer2.Deserialize(stringReader2) as SkillSetup;
		}
		Resources.UnloadAsset(textAsset);
		if (!this.m_bInited)
		{
			OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.Prop_0.imethod_4(new SkillPointEarnedCallback(this.OnSkillPtEarned));
			this.m_bInited = true;
		}
		base.vmethod_1();
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x00012EEC File Offset: 0x000110EC
	public SkillSetup method_0()
	{
		return this.m_skillSetup;
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x00012EF4 File Offset: 0x000110F4
	public void method_1(ISkillTreeServiceNotificationListerner iskillTreeServiceNotificationListerner_0)
	{
		this.m_skillTreeListeners.Add(iskillTreeServiceNotificationListerner_0);
	}

	// Token: 0x06001962 RID: 6498 RVA: 0x00012F02 File Offset: 0x00011102
	public void method_2(ISkillTreeServiceNotificationListerner iskillTreeServiceNotificationListerner_0)
	{
		this.m_skillTreeListeners.Remove(iskillTreeServiceNotificationListerner_0);
	}

	// Token: 0x06001963 RID: 6499 RVA: 0x000843F8 File Offset: 0x000825F8
	public global::XsdSettings.SkillTree method_3(AvatarType avatarType_0)
	{
		for (int i = 0; i < this.m_skillTreeSetup.m_trees.Length; i++)
		{
			if (this.m_skillTreeSetup.m_trees[i].m_avatarType == avatarType_0)
			{
				return this.m_skillTreeSetup.m_trees[i];
			}
		}
		return null;
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x00084444 File Offset: 0x00082644
	public Skill method_4(int int_0)
	{
		for (int i = 0; i < this.m_skillSetup.m_skills.Length; i++)
		{
			if (this.m_skillSetup.m_skills[i].m_id == int_0)
			{
				return this.m_skillSetup.m_skills[i];
			}
		}
		return null;
	}

	// Token: 0x06001965 RID: 6501 RVA: 0x00084490 File Offset: 0x00082690
	public int method_5(int int_0)
	{
		int num = 0;
		foreach (InvestedSkill investedSkill in this.m_investedSkillPoints)
		{
			if (investedSkill.Int32_0 == int_0)
			{
				num = investedSkill.Int32_1;
				break;
			}
		}
		return num;
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_2()
	{
		return true;
	}

	// Token: 0x06001967 RID: 6503 RVA: 0x00012F11 File Offset: 0x00011111
	public List<InvestedSkill> method_6()
	{
		return this.m_investedSkillPoints;
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x06001968 RID: 6504 RVA: 0x00012F19 File Offset: 0x00011119
	public int Int32_0
	{
		get
		{
			return this.m_iUnspentSkillPt;
		}
	}

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x06001969 RID: 6505 RVA: 0x00012F21 File Offset: 0x00011121
	public int Int32_1
	{
		get
		{
			return this.m_iEarnedSkillPt;
		}
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x000844F4 File Offset: 0x000826F4
	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		if (investedSkillPoints != null)
		{
			this.m_investedSkillPoints = investedSkillPoints;
		}
		foreach (ISkillTreeServiceNotificationListerner skillTreeServiceNotificationListerner in this.m_skillTreeListeners)
		{
			skillTreeServiceNotificationListerner.OnGetInvestedSkillPt(characterId, investedSkillPoints);
		}
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x00084554 File Offset: 0x00082754
	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		this.m_iEarnedSkillPt = earned;
		this.m_iUnspentSkillPt = unspent;
		foreach (ISkillTreeServiceNotificationListerner skillTreeServiceNotificationListerner in this.m_skillTreeListeners)
		{
			skillTreeServiceNotificationListerner.OnGetPlayerSkillPt(characterId, earned, unspent, investedSkillPoints);
		}
		this.OnGetInvestedSkillPt(characterId, investedSkillPoints);
	}

	// Token: 0x0600196C RID: 6508 RVA: 0x000845C4 File Offset: 0x000827C4
	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		if (wasSuccessful)
		{
			foreach (InvestedSkill investedSkill in this.m_investedSkillPoints)
			{
				if (investedSkill.Int32_0 == skillId)
				{
					investedSkill.Int32_1++;
					break;
				}
			}
			ServiceWrapperBase<QuestServiceWrapper>.Instance.method_14();
			this.m_iUnspentSkillPt--;
		}
		foreach (ISkillTreeServiceNotificationListerner skillTreeServiceNotificationListerner in this.m_skillTreeListeners)
		{
			skillTreeServiceNotificationListerner.OnInvestedSkillPt(characterId, skillId, wasSuccessful);
		}
		int num = this.Int32_1 - this.Int32_0;
		if (num >= 1)
		{
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_use_skillpoint");
		}
		if (num >= 2)
		{
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_use_secondary");
		}
		MonoSingleton<GuidanceTipsManager>.Instance.OnSpentSkillPoint(this.m_investedSkillPoints.Count);
	}

	// Token: 0x0600196D RID: 6509 RVA: 0x000846D4 File Offset: 0x000828D4
	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		if (wasSuccessful)
		{
			foreach (InvestedSkill investedSkill in this.m_investedSkillPoints)
			{
				investedSkill.Int32_1 = 0;
			}
			this.m_iUnspentSkillPt = this.m_iEarnedSkillPt;
		}
		foreach (ISkillTreeServiceNotificationListerner skillTreeServiceNotificationListerner in this.m_skillTreeListeners)
		{
			skillTreeServiceNotificationListerner.OnResetSkillPt(characterId, wasSuccessful);
		}
	}

	// Token: 0x0600196E RID: 6510 RVA: 0x00084778 File Offset: 0x00082978
	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		this.m_iUnspentSkillPt += numEarned;
		this.m_iEarnedSkillPt += numEarned;
		foreach (ISkillTreeServiceNotificationListerner skillTreeServiceNotificationListerner in this.m_skillTreeListeners)
		{
			skillTreeServiceNotificationListerner.OnSkillPtEarned(characterId, numEarned);
		}
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x00012F29 File Offset: 0x00011129
	public void method_7()
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.Prop_0.imethod_0(new GetSkillPointsCallback(this.OnGetPlayerSkillPt));
	}

	// Token: 0x06001970 RID: 6512 RVA: 0x00012F42 File Offset: 0x00011142
	public void method_8(int int_0)
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.Prop_0.imethod_1(int_0, new InvestSkillPointCallback(this.OnInvestedSkillPt));
	}

	// Token: 0x06001971 RID: 6513 RVA: 0x00012F5C File Offset: 0x0001115C
	public void method_9(List<InvestedSkill> list_0, InvestMultipleSkillPointsCallback investMultipleSkillPointsCallback_0)
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.Prop_0.imethod_2(list_0, investMultipleSkillPointsCallback_0);
	}

	// Token: 0x06001972 RID: 6514 RVA: 0x00012F6A File Offset: 0x0001116A
	public void method_10()
	{
		OnAccessSingleton<ISkillTreeService, SkillTreeService, SkillTreeServiceOffline>.Prop_0.imethod_3(new ResetSkillPointsCallback(this.OnResetSkillPt));
	}

	// Token: 0x0400112C RID: 4396
	private SkillTreeSetup m_skillTreeSetup;

	// Token: 0x0400112D RID: 4397
	private SkillSetup m_skillSetup;

	// Token: 0x0400112E RID: 4398
	private bool m_bInited;

	// Token: 0x0400112F RID: 4399
	private List<InvestedSkill> m_investedSkillPoints = new List<InvestedSkill>();

	// Token: 0x04001130 RID: 4400
	private int m_iUnspentSkillPt;

	// Token: 0x04001131 RID: 4401
	private int m_iEarnedSkillPt;

	// Token: 0x04001132 RID: 4402
	private List<ISkillTreeServiceNotificationListerner> m_skillTreeListeners = new List<ISkillTreeServiceNotificationListerner>();
}
