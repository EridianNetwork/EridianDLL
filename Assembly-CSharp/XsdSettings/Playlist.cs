using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009F9 RID: 2553
	public class Playlist
	{
		// Token: 0x0600463C RID: 17980 RVA: 0x0012F5AC File Offset: 0x0012D7AC
		public Playlist()
		{
			this.m_maxPlayerCount = 4;
			this.m_minPlayerCountToStart = 1;
			this.m_bossName = string.Empty;
			this.m_normal_LevelMin = 1;
			this.m_normal_LevelMax = 10;
			this.m_hard_LevelMin = 10;
			this.m_hard_LevelMax = 20;
			this.m_hell_LevelMin = 20;
			this.m_hell_LevelMax = 25;
			this.m_normal_Exp = 0;
			this.m_hard_Exp = 0;
			this.m_hell_Exp = 0;
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x0600463D RID: 17981 RVA: 0x0002E5A5 File Offset: 0x0002C7A5
		// (set) Token: 0x0600463E RID: 17982 RVA: 0x0002E5AD File Offset: 0x0002C7AD
		public int m_id { get; set; }

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x0600463F RID: 17983 RVA: 0x0002E5B6 File Offset: 0x0002C7B6
		// (set) Token: 0x06004640 RID: 17984 RVA: 0x0002E5BE File Offset: 0x0002C7BE
		public string m_name { get; set; }

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06004641 RID: 17985 RVA: 0x0002E5C7 File Offset: 0x0002C7C7
		// (set) Token: 0x06004642 RID: 17986 RVA: 0x0002E5CF File Offset: 0x0002C7CF
		public string m_gameMode { get; set; }

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06004643 RID: 17987 RVA: 0x0002E5D8 File Offset: 0x0002C7D8
		// (set) Token: 0x06004644 RID: 17988 RVA: 0x0002E5E0 File Offset: 0x0002C7E0
		public int m_maxPlayerCount { get; set; }

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06004645 RID: 17989 RVA: 0x0002E5E9 File Offset: 0x0002C7E9
		// (set) Token: 0x06004646 RID: 17990 RVA: 0x0002E5F1 File Offset: 0x0002C7F1
		public int m_minPlayerCountToStart { get; set; }

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06004647 RID: 17991 RVA: 0x0002E5FA File Offset: 0x0002C7FA
		// (set) Token: 0x06004648 RID: 17992 RVA: 0x0002E602 File Offset: 0x0002C802
		[XmlArrayItem("m_scene", IsNullable = false)]
		public string[] m_sceneToPlay { get; set; }

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06004649 RID: 17993 RVA: 0x0002E60B File Offset: 0x0002C80B
		// (set) Token: 0x0600464A RID: 17994 RVA: 0x0002E613 File Offset: 0x0002C813
		public string m_bossName { get; set; }

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x0600464B RID: 17995 RVA: 0x0002E61C File Offset: 0x0002C81C
		// (set) Token: 0x0600464C RID: 17996 RVA: 0x0002E624 File Offset: 0x0002C824
		public int m_normal_LevelMin { get; set; }

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x0600464D RID: 17997 RVA: 0x0002E62D File Offset: 0x0002C82D
		// (set) Token: 0x0600464E RID: 17998 RVA: 0x0002E635 File Offset: 0x0002C835
		public int m_normal_LevelMax { get; set; }

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x0600464F RID: 17999 RVA: 0x0002E63E File Offset: 0x0002C83E
		// (set) Token: 0x06004650 RID: 18000 RVA: 0x0002E646 File Offset: 0x0002C846
		public int m_hard_LevelMin { get; set; }

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06004651 RID: 18001 RVA: 0x0002E64F File Offset: 0x0002C84F
		// (set) Token: 0x06004652 RID: 18002 RVA: 0x0002E657 File Offset: 0x0002C857
		public int m_hard_LevelMax { get; set; }

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06004653 RID: 18003 RVA: 0x0002E660 File Offset: 0x0002C860
		// (set) Token: 0x06004654 RID: 18004 RVA: 0x0002E668 File Offset: 0x0002C868
		public int m_hell_LevelMin { get; set; }

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06004655 RID: 18005 RVA: 0x0002E671 File Offset: 0x0002C871
		// (set) Token: 0x06004656 RID: 18006 RVA: 0x0002E679 File Offset: 0x0002C879
		public int m_hell_LevelMax { get; set; }

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06004657 RID: 18007 RVA: 0x0002E682 File Offset: 0x0002C882
		// (set) Token: 0x06004658 RID: 18008 RVA: 0x0002E68A File Offset: 0x0002C88A
		public int m_normal_Exp { get; set; }

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06004659 RID: 18009 RVA: 0x0002E693 File Offset: 0x0002C893
		// (set) Token: 0x0600465A RID: 18010 RVA: 0x0002E69B File Offset: 0x0002C89B
		public int m_hard_Exp { get; set; }

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x0600465B RID: 18011 RVA: 0x0002E6A4 File Offset: 0x0002C8A4
		// (set) Token: 0x0600465C RID: 18012 RVA: 0x0002E6AC File Offset: 0x0002C8AC
		public int m_hell_Exp { get; set; }

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x0600465D RID: 18013 RVA: 0x0002E6B5 File Offset: 0x0002C8B5
		// (set) Token: 0x0600465E RID: 18014 RVA: 0x0002E6BD File Offset: 0x0002C8BD
		[XmlArrayItem("m_gradeScore", IsNullable = false)]
		public TargetScoreGrade[] m_normal_targetScore { get; set; }

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x0600465F RID: 18015 RVA: 0x0002E6C6 File Offset: 0x0002C8C6
		// (set) Token: 0x06004660 RID: 18016 RVA: 0x0002E6CE File Offset: 0x0002C8CE
		[XmlArrayItem("m_gradeScore", IsNullable = false)]
		public TargetScoreGrade[] m_hard_targetScore { get; set; }

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06004661 RID: 18017 RVA: 0x0002E6D7 File Offset: 0x0002C8D7
		// (set) Token: 0x06004662 RID: 18018 RVA: 0x0002E6DF File Offset: 0x0002C8DF
		[XmlArrayItem("m_gradeScore", IsNullable = false)]
		public TargetScoreGrade[] m_hell_targetScore { get; set; }

		// Token: 0x040031EF RID: 12783
		private TargetScoreGrade[] m_normal_targetScoreField;

		// Token: 0x040031F0 RID: 12784
		private TargetScoreGrade[] m_hard_targetScoreField;

		// Token: 0x040031F1 RID: 12785
		private TargetScoreGrade[] m_hell_targetScoreField;
	}
}
