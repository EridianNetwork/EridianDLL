using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A04 RID: 2564
	public class QuestTask
	{
		// Token: 0x060046AC RID: 18092 RVA: 0x0012F670 File Offset: 0x0012D870
		public QuestTask()
		{
			this.mTaskId = 0;
			this.mType = QuestTaskType.Instance;
			this.mTarget = 0;
			this.mTimeLimit = 0;
			this.mTargetId = QuestEnemyType.AnyBandit;
			this.mAttackId = QuestAttackType.Any;
			this.mMaterialType = MaterialType.MT_Titanium;
			this.mMaterialCount = 1;
			this.mItemType = ItemType.NA;
			this.mItemID = 0;
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x060046AD RID: 18093 RVA: 0x0002E953 File Offset: 0x0002CB53
		// (set) Token: 0x060046AE RID: 18094 RVA: 0x0002E95B File Offset: 0x0002CB5B
		public int mTaskId { get; set; }

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x060046AF RID: 18095 RVA: 0x0002E964 File Offset: 0x0002CB64
		// (set) Token: 0x060046B0 RID: 18096 RVA: 0x0002E96C File Offset: 0x0002CB6C
		public string mDescription { get; set; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x060046B1 RID: 18097 RVA: 0x0002E975 File Offset: 0x0002CB75
		// (set) Token: 0x060046B2 RID: 18098 RVA: 0x0002E97D File Offset: 0x0002CB7D
		public QuestTaskType mType { get; set; }

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060046B3 RID: 18099 RVA: 0x0002E986 File Offset: 0x0002CB86
		// (set) Token: 0x060046B4 RID: 18100 RVA: 0x0002E98E File Offset: 0x0002CB8E
		public int mTarget { get; set; }

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060046B5 RID: 18101 RVA: 0x0002E997 File Offset: 0x0002CB97
		// (set) Token: 0x060046B6 RID: 18102 RVA: 0x0002E99F File Offset: 0x0002CB9F
		public int mTimeLimit { get; set; }

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060046B7 RID: 18103 RVA: 0x0002E9A8 File Offset: 0x0002CBA8
		// (set) Token: 0x060046B8 RID: 18104 RVA: 0x0002E9B0 File Offset: 0x0002CBB0
		[DefaultValue(QuestEnemyType.AnyBandit)]
		public QuestEnemyType mTargetId { get; set; }

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060046B9 RID: 18105 RVA: 0x0002E9B9 File Offset: 0x0002CBB9
		// (set) Token: 0x060046BA RID: 18106 RVA: 0x0002E9C1 File Offset: 0x0002CBC1
		[DefaultValue(QuestAttackType.Any)]
		public QuestAttackType mAttackId { get; set; }

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060046BB RID: 18107 RVA: 0x0002E9CA File Offset: 0x0002CBCA
		// (set) Token: 0x060046BC RID: 18108 RVA: 0x0002E9D2 File Offset: 0x0002CBD2
		[DefaultValue(MaterialType.MT_Titanium)]
		public MaterialType mMaterialType { get; set; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060046BD RID: 18109 RVA: 0x0002E9DB File Offset: 0x0002CBDB
		// (set) Token: 0x060046BE RID: 18110 RVA: 0x0002E9E3 File Offset: 0x0002CBE3
		[DefaultValue(1)]
		public int mMaterialCount { get; set; }

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060046BF RID: 18111 RVA: 0x0002E9EC File Offset: 0x0002CBEC
		// (set) Token: 0x060046C0 RID: 18112 RVA: 0x0002E9F4 File Offset: 0x0002CBF4
		[DefaultValue(ItemType.NA)]
		public ItemType mItemType { get; set; }

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060046C1 RID: 18113 RVA: 0x0002E9FD File Offset: 0x0002CBFD
		// (set) Token: 0x060046C2 RID: 18114 RVA: 0x0002EA05 File Offset: 0x0002CC05
		[DefaultValue(0)]
		public int mItemID { get; set; }

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060046C3 RID: 18115 RVA: 0x0002EA0E File Offset: 0x0002CC0E
		// (set) Token: 0x060046C4 RID: 18116 RVA: 0x0002EA16 File Offset: 0x0002CC16
		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mTaskEchoIDList { get; set; }

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060046C5 RID: 18117 RVA: 0x0002EA1F File Offset: 0x0002CC1F
		// (set) Token: 0x060046C6 RID: 18118 RVA: 0x0002EA27 File Offset: 0x0002CC27
		[XmlArrayItem("m_modeType", IsNullable = false)]
		public QuestPVPModeType[] mPVPModeList { get; set; }

		// Token: 0x04003245 RID: 12869
		private QuestPVPModeType[] mPVPModeListField;
	}
}
