using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x02000753 RID: 1875
public class SkillTreeView : BaseView, ISkillTreeServiceNotificationListerner
{
	// Token: 0x06003190 RID: 12688 RVA: 0x000E172C File Offset: 0x000DF92C
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_1(this);
		AvatarType avatarType = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13().method_5();
		global::XsdSettings.SkillTree skillTree = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_3(avatarType);
		if (skillTree == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "Can not get the skill tree data in SkillTreeView!  AvatarType " + avatarType.ToString());
		}
		else
		{
			this._skillTreeData = new SkillTreeView.SkillTreeDataRoot();
			this._skillTreeData.method_0(skillTree);
		}
		if (ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1 > 0)
		{
			this.method_3(true);
		}
	}

	// Token: 0x06003191 RID: 12689 RVA: 0x00020398 File Offset: 0x0001E598
	public void method_3(bool bool_0)
	{
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_16(this, "UISkillTree");
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
		}
	}

	// Token: 0x06003192 RID: 12690 RVA: 0x000E17D4 File Offset: 0x000DF9D4
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
		this.method_3(false);
		ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_2(this);
		this._skillTreeData = null;
		this._bWaittingForResponse = false;
	}

	// Token: 0x06003193 RID: 12691 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003194 RID: 12692 RVA: 0x000203C9 File Offset: 0x0001E5C9
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_8(false);
			if (this._bNeedInformHost)
			{
				this._bNeedInformHost = false;
				this.method_4();
			}
		}
	}

	// Token: 0x06003195 RID: 12693 RVA: 0x000E1828 File Offset: 0x000DFA28
	protected void method_4()
	{
		if (MonoSingleton<Session>.Instance != null)
		{
			PlayerSkillTreeManage component = MonoSingleton<Session>.Instance.GetComponent<PlayerSkillTreeManage>();
			if (component != null)
			{
				component.OnLocalSkillUpgrade();
			}
		}
	}

	// Token: 0x06003196 RID: 12694 RVA: 0x00020400 File Offset: 0x0001E600
	protected virtual void vmethod_5(List<InvestedSkill> list_0)
	{
		this._skillTreeData.method_1(list_0, ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1, ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0);
	}

	// Token: 0x06003197 RID: 12695 RVA: 0x00020422 File Offset: 0x0001E622
	protected virtual void vmethod_6(int int_0, int int_1)
	{
		this._skillTreeData.method_1(ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_6(), ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1, ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0);
	}

	// Token: 0x06003198 RID: 12696 RVA: 0x0002044D File Offset: 0x0001E64D
	protected virtual void vmethod_7()
	{
		if (!this._bWaittingForResponse)
		{
			ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_10();
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Skills_Reset");
		}
		this._bWaittingForResponse = true;
		this._bNeedInformHost = true;
	}

	// Token: 0x06003199 RID: 12697 RVA: 0x000E185C File Offset: 0x000DFA5C
	protected virtual void vmethod_8(int int_0)
	{
		if (ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0 > 0)
		{
			if (!this._bWaittingForResponse)
			{
				ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_8(int_0);
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Skills_Buy");
			}
			this._bWaittingForResponse = true;
			this._bNeedInformHost = true;
		}
	}

	// Token: 0x0600319A RID: 12698 RVA: 0x00020488 File Offset: 0x0001E688
	public void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints)
	{
		this.method_5();
	}

	// Token: 0x0600319B RID: 12699 RVA: 0x00020488 File Offset: 0x0001E688
	public void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints)
	{
		this.method_5();
	}

	// Token: 0x0600319C RID: 12700 RVA: 0x00020490 File Offset: 0x0001E690
	public void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful)
	{
		this._bWaittingForResponse = false;
		this.method_5();
	}

	// Token: 0x0600319D RID: 12701 RVA: 0x00020490 File Offset: 0x0001E690
	public void OnResetSkillPt(int characterId, bool wasSuccessful)
	{
		this._bWaittingForResponse = false;
		this.method_5();
	}

	// Token: 0x0600319E RID: 12702 RVA: 0x0002049F File Offset: 0x0001E69F
	public void OnSkillPtEarned(int characterId, int numEarned)
	{
		this.method_3(true);
		this.method_5();
	}

	// Token: 0x0600319F RID: 12703 RVA: 0x000204AE File Offset: 0x0001E6AE
	protected void method_5()
	{
		this.vmethod_5(ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_6());
		this.vmethod_6(ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_1, ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.Int32_0);
	}

	// Token: 0x0400224A RID: 8778
	protected int _iCharacterID;

	// Token: 0x0400224B RID: 8779
	protected int _iEarnedPt;

	// Token: 0x0400224C RID: 8780
	protected int _iUnspentPt;

	// Token: 0x0400224D RID: 8781
	protected SkillTreeView.SkillTreeDataRoot _skillTreeData = new SkillTreeView.SkillTreeDataRoot();

	// Token: 0x0400224E RID: 8782
	private bool _bWaittingForResponse;

	// Token: 0x0400224F RID: 8783
	private bool _bNeedInformHost;

	// Token: 0x02000754 RID: 1876
	public class SkillTreeDataRoot
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060031A1 RID: 12705 RVA: 0x00020503 File Offset: 0x0001E703
		public AvatarType AvatarType_0
		{
			get
			{
				return this._curAvatarType;
			}
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x000E18B0 File Offset: 0x000DFAB0
		public void method_0(global::XsdSettings.SkillTree skillTree_0)
		{
			if (skillTree_0 == null)
			{
				return;
			}
			this._skillBranchDic.Clear();
			this._skillNodeDic.Clear();
			this._curAvatarType = skillTree_0.m_avatarType;
			foreach (SkillTreeTier skillTreeTier in skillTree_0.m_tierList)
			{
				SkillTreeView.SkillNodeGroup skillNodeGroup = null;
				foreach (NodeGroup nodeGroup in skillTreeTier.m_nodeGroupList)
				{
					if (!this._skillBranchDic.TryGetValue(nodeGroup.m_id, out skillNodeGroup))
					{
						skillNodeGroup = new SkillTreeView.SkillNodeGroup(nodeGroup.m_id);
						this._skillBranchDic.Add(nodeGroup.m_id, skillNodeGroup);
						if (nodeGroup.m_id > 0 && nodeGroup.m_id <= skillTree_0.m_groupNameList.Length)
						{
							skillNodeGroup.String_0 = skillTree_0.m_groupNameList[nodeGroup.m_id - 1];
						}
						this._skillBranchList.Add(skillNodeGroup);
					}
					SkillTreeView.SkillTierSegment skillTierSegment = new SkillTreeView.SkillTierSegment(nodeGroup, skillTreeTier.m_id, skillTreeTier.m_pointToUnlockNextTier);
					skillNodeGroup.method_0(skillTierSegment);
					foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in skillTierSegment.method_1())
					{
						if (!this._skillNodeDic.ContainsKey(skillNodeContainer.Int32_0))
						{
							this._skillNodeDic.Add(skillNodeContainer.Int32_0, skillNodeContainer);
						}
					}
				}
			}
			this._skillBranchList.Sort(new Comparison<SkillTreeView.SkillNodeGroup>(this.method_3));
		}

		// Token: 0x060031A3 RID: 12707 RVA: 0x000E1A40 File Offset: 0x000DFC40
		public void method_1(List<InvestedSkill> list_0, int int_0, int int_1)
		{
			foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in this._skillNodeDic.Values)
			{
				skillNodeContainer.method_1();
			}
			foreach (InvestedSkill investedSkill in list_0)
			{
				SkillTreeView.SkillNodeContainer skillNodeContainer2 = null;
				if (this._skillNodeDic.TryGetValue(investedSkill.Int32_0, out skillNodeContainer2))
				{
					skillNodeContainer2.method_0(investedSkill);
				}
			}
			foreach (SkillTreeView.SkillNodeGroup skillNodeGroup in this._skillBranchDic.Values)
			{
				skillNodeGroup.method_1(int_0, int_1);
			}
		}

		// Token: 0x060031A4 RID: 12708 RVA: 0x0002050B File Offset: 0x0001E70B
		public List<SkillTreeView.SkillNodeGroup> method_2()
		{
			return this._skillBranchList;
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x00020513 File Offset: 0x0001E713
		private int method_3(SkillTreeView.SkillNodeGroup skillNodeGroup_0, SkillTreeView.SkillNodeGroup skillNodeGroup_1)
		{
			return skillNodeGroup_0.Int32_0 - skillNodeGroup_1.Int32_0;
		}

		// Token: 0x04002250 RID: 8784
		private Dictionary<int, SkillTreeView.SkillNodeGroup> _skillBranchDic = new Dictionary<int, SkillTreeView.SkillNodeGroup>();

		// Token: 0x04002251 RID: 8785
		private Dictionary<int, SkillTreeView.SkillNodeContainer> _skillNodeDic = new Dictionary<int, SkillTreeView.SkillNodeContainer>();

		// Token: 0x04002252 RID: 8786
		private List<SkillTreeView.SkillNodeGroup> _skillBranchList = new List<SkillTreeView.SkillNodeGroup>();

		// Token: 0x04002253 RID: 8787
		private AvatarType _curAvatarType;
	}

	// Token: 0x02000755 RID: 1877
	public class SkillNodeGroup
	{
		// Token: 0x060031A6 RID: 12710 RVA: 0x000E1B38 File Offset: 0x000DFD38
		public SkillNodeGroup(int int_0)
		{
			this._iGroupID = int_0;
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060031A7 RID: 12711 RVA: 0x00020522 File Offset: 0x0001E722
		public int Int32_0
		{
			get
			{
				return this._iGroupID;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060031A8 RID: 12712 RVA: 0x0002052A File Offset: 0x0001E72A
		public int Int32_1
		{
			get
			{
				return this._iCurInprogressTierID;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060031AA RID: 12714 RVA: 0x0002053B File Offset: 0x0001E73B
		// (set) Token: 0x060031A9 RID: 12713 RVA: 0x00020532 File Offset: 0x0001E732
		public string String_0
		{
			get
			{
				return this._strBranchName;
			}
			set
			{
				this._strBranchName = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060031AB RID: 12715 RVA: 0x000E1B88 File Offset: 0x000DFD88
		public float Single_0
		{
			get
			{
				float num = 0f;
				int num2 = 0;
				for (int i = 0; i < this._iCurInprogressTierID; i++)
				{
					if (this._requiredPtToUnlockNextTier.ContainsKey(i))
					{
						num2 += this._requiredPtToUnlockNextTier[i];
					}
				}
				int num3 = this._iTotalInvestedSkillPt - num2;
				if (this._requiredPtToUnlockNextTier.ContainsKey(this._iCurInprogressTierID))
				{
					num = (float)num3 / (float)this._requiredPtToUnlockNextTier[this._iCurInprogressTierID];
				}
				return (num <= 1f) ? num : 1f;
			}
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x000E1C10 File Offset: 0x000DFE10
		public void method_0(SkillTreeView.SkillTierSegment skillTierSegment_0)
		{
			if (!this._requiredPtToUnlockNextTier.ContainsKey(skillTierSegment_0.Int32_0))
			{
				this._requiredPtToUnlockNextTier.Add(skillTierSegment_0.Int32_0, skillTierSegment_0.Int32_1);
			}
			this._iMaxTierID = 0;
			if (!this._skillTierDic.ContainsKey(skillTierSegment_0.Int32_0))
			{
				this._skillTierDic.Add(skillTierSegment_0.Int32_0, skillTierSegment_0);
				this._sortedSkillTierList.Add(skillTierSegment_0);
				this._iMaxTierID = ((this._iMaxTierID >= skillTierSegment_0.Int32_0) ? this._iMaxTierID : skillTierSegment_0.Int32_0);
			}
			this._sortedSkillTierList.Sort(new Comparison<SkillTreeView.SkillTierSegment>(this.method_3));
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x000E1CB8 File Offset: 0x000DFEB8
		public void method_1(int int_0, int int_1)
		{
			this._iCurInprogressTierID = 0;
			this._iTotalInvestedSkillPt = 0;
			foreach (SkillTreeView.SkillTierSegment skillTierSegment in this._skillTierDic.Values)
			{
				skillTierSegment.method_2();
				this._iTotalInvestedSkillPt += skillTierSegment.Int32_2;
			}
			foreach (SkillTreeView.SkillTierSegment skillTierSegment2 in this._sortedSkillTierList)
			{
				bool flag;
				if (skillTierSegment2.Int32_0 <= 3)
				{
					int num = int_0 - int_1;
					flag = num >= skillTierSegment2.Int32_0 - 1 && int_0 > 0;
				}
				else
				{
					int num2 = 0;
					for (int i = 3; i < skillTierSegment2.Int32_0; i++)
					{
						if (this._requiredPtToUnlockNextTier.ContainsKey(i))
						{
							num2 += this._requiredPtToUnlockNextTier[i];
						}
					}
					flag = this._iTotalInvestedSkillPt >= num2;
				}
				skillTierSegment2.method_3(flag);
				if (skillTierSegment2.Boolean_0)
				{
					this._iCurInprogressTierID = ((this._iCurInprogressTierID <= skillTierSegment2.Int32_0) ? skillTierSegment2.Int32_0 : this._iCurInprogressTierID);
				}
			}
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x00020543 File Offset: 0x0001E743
		public List<SkillTreeView.SkillTierSegment> method_2()
		{
			return this._sortedSkillTierList;
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x0002054B File Offset: 0x0001E74B
		private int method_3(SkillTreeView.SkillTierSegment skillTierSegment_0, SkillTreeView.SkillTierSegment skillTierSegment_1)
		{
			return skillTierSegment_0.Int32_0 - skillTierSegment_1.Int32_0;
		}

		// Token: 0x04002254 RID: 8788
		private Dictionary<int, SkillTreeView.SkillTierSegment> _skillTierDic = new Dictionary<int, SkillTreeView.SkillTierSegment>();

		// Token: 0x04002255 RID: 8789
		private List<SkillTreeView.SkillTierSegment> _sortedSkillTierList = new List<SkillTreeView.SkillTierSegment>();

		// Token: 0x04002256 RID: 8790
		private int _iGroupID = -1;

		// Token: 0x04002257 RID: 8791
		private int _iMaxTierID;

		// Token: 0x04002258 RID: 8792
		private int _iCurInprogressTierID;

		// Token: 0x04002259 RID: 8793
		private int _iTotalInvestedSkillPt;

		// Token: 0x0400225A RID: 8794
		private string _strBranchName = string.Empty;

		// Token: 0x0400225B RID: 8795
		private Dictionary<int, int> _requiredPtToUnlockNextTier = new Dictionary<int, int>();
	}

	// Token: 0x02000756 RID: 1878
	public class SkillTierSegment
	{
		// Token: 0x060031B0 RID: 12720 RVA: 0x000E1E14 File Offset: 0x000E0014
		public SkillTierSegment(NodeGroup nodeGroup_0, int int_0, int int_1)
		{
			this._iTierID = int_0;
			this._iRequiredPtToUnlockNextIter = int_1;
			if (nodeGroup_0 != null && nodeGroup_0.m_nodeList != null)
			{
				foreach (SkillNode skillNode in nodeGroup_0.m_nodeList)
				{
					SkillTreeView.SkillNodeContainer skillNodeContainer = new SkillTreeView.SkillNodeContainer(skillNode);
					if (!this._skillNodeDic.ContainsKey(skillNodeContainer.Int32_0))
					{
						this._skillNodeDic.Add(skillNodeContainer.Int32_0, skillNodeContainer);
					}
				}
				this._sortedNodeList = new List<SkillTreeView.SkillNodeContainer>(this._skillNodeDic.Values);
				this._sortedNodeList.Sort(new Comparison<SkillTreeView.SkillNodeContainer>(this.method_0));
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060031B1 RID: 12721 RVA: 0x0002055A File Offset: 0x0001E75A
		public int Int32_0
		{
			get
			{
				return this._iTierID;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060031B2 RID: 12722 RVA: 0x00020562 File Offset: 0x0001E762
		public bool Boolean_0
		{
			get
			{
				return this._bUnlocked;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060031B3 RID: 12723 RVA: 0x0002056A File Offset: 0x0001E76A
		public int Int32_1
		{
			get
			{
				return this._iRequiredPtToUnlockNextIter;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060031B4 RID: 12724 RVA: 0x00020572 File Offset: 0x0001E772
		public int Int32_2
		{
			get
			{
				return this._iTotalInvestedSkillPt;
			}
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x0002057A File Offset: 0x0001E77A
		private int method_0(SkillTreeView.SkillNodeContainer skillNodeContainer_0, SkillTreeView.SkillNodeContainer skillNodeContainer_1)
		{
			return skillNodeContainer_0.Int32_0 - skillNodeContainer_1.Int32_0;
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x00020589 File Offset: 0x0001E789
		public List<SkillTreeView.SkillNodeContainer> method_1()
		{
			return this._sortedNodeList;
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x000E1ED8 File Offset: 0x000E00D8
		public void method_2()
		{
			this._iTotalInvestedSkillPt = 0;
			foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in this._skillNodeDic.Values)
			{
				this._iTotalInvestedSkillPt += skillNodeContainer.Int32_1;
			}
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x000E1F44 File Offset: 0x000E0144
		public void method_3(bool bool_0)
		{
			this._bUnlocked = bool_0;
			foreach (SkillTreeView.SkillNodeContainer skillNodeContainer in this._skillNodeDic.Values)
			{
				skillNodeContainer.bUnlocked = bool_0;
			}
		}

		// Token: 0x0400225C RID: 8796
		protected Dictionary<int, SkillTreeView.SkillNodeContainer> _skillNodeDic = new Dictionary<int, SkillTreeView.SkillNodeContainer>();

		// Token: 0x0400225D RID: 8797
		protected List<SkillTreeView.SkillNodeContainer> _sortedNodeList = new List<SkillTreeView.SkillNodeContainer>();

		// Token: 0x0400225E RID: 8798
		protected int _iTierID = -1;

		// Token: 0x0400225F RID: 8799
		protected int _iTotalInvestedSkillPt;

		// Token: 0x04002260 RID: 8800
		protected int _iRequiredPtToUnlockNextIter = 1;

		// Token: 0x04002261 RID: 8801
		protected bool _bUnlocked;
	}

	// Token: 0x02000757 RID: 1879
	public class SkillNodeContainer
	{
		// Token: 0x060031B9 RID: 12729 RVA: 0x00020591 File Offset: 0x0001E791
		public SkillNodeContainer(SkillNode skillNode_0)
		{
			this._iSKillID = Convert.ToInt32(skillNode_0.m_id);
			this._skill = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_4(this._iSKillID);
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060031BA RID: 12730 RVA: 0x000205C7 File Offset: 0x0001E7C7
		public int Int32_0
		{
			get
			{
				return this._iSKillID;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x060031BB RID: 12731 RVA: 0x000205CF File Offset: 0x0001E7CF
		public int Int32_1
		{
			get
			{
				return this._iCurGrade;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x060031BC RID: 12732 RVA: 0x000205D7 File Offset: 0x0001E7D7
		public Skill Skill_0
		{
			get
			{
				return this._skill;
			}
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x000205DF File Offset: 0x0001E7DF
		public void method_0(InvestedSkill investedSkill_0)
		{
			if (investedSkill_0 == null)
			{
				return;
			}
			this._iCurGrade = investedSkill_0.Int32_1;
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x000205F1 File Offset: 0x0001E7F1
		public void method_1()
		{
			this._iCurGrade = 0;
		}

		// Token: 0x04002262 RID: 8802
		private int _iSKillID = -1;

		// Token: 0x04002263 RID: 8803
		private int _iCurGrade;

		// Token: 0x04002264 RID: 8804
		private Skill _skill;

		// Token: 0x04002265 RID: 8805
		public bool bUnlocked;
	}
}
