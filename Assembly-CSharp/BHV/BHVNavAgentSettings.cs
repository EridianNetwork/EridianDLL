using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200015C RID: 348
	public class BHVNavAgentSettings : BHVTaskSettings
	{
		// Token: 0x06000801 RID: 2049 RVA: 0x0005A70C File Offset: 0x0005890C
		public BHVNavAgentSettings()
		{
			this.m_walkSpeed = 0.01f;
			this.m_walkCombatSpeed = 0.01f;
			this.m_runSpeed = 0.01f;
			this.m_sprintSpeed = 0.01f;
			this.m_jumpSpeed = 0.01f;
			this.m_chargeSpeed = 0.01f;
			this.m_canUseFacingLogic = true;
			this.m_stopDistance = 0.1f;
			this.m_combatSpawnDuration = 0.3f;
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0000833C File Offset: 0x0000653C
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x00008344 File Offset: 0x00006544
		[DefaultValue(typeof(float), "0.01")]
		public float m_walkSpeed { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0000834D File Offset: 0x0000654D
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x00008355 File Offset: 0x00006555
		[DefaultValue(typeof(float), "0.01")]
		public float m_walkCombatSpeed { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0000835E File Offset: 0x0000655E
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x00008366 File Offset: 0x00006566
		[DefaultValue(typeof(float), "0.01")]
		public float m_runSpeed { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0000836F File Offset: 0x0000656F
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x00008377 File Offset: 0x00006577
		[DefaultValue(typeof(float), "0.01")]
		public float m_sprintSpeed { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x00008380 File Offset: 0x00006580
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x00008388 File Offset: 0x00006588
		[DefaultValue(typeof(float), "0.01")]
		public float m_jumpSpeed { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x00008391 File Offset: 0x00006591
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x00008399 File Offset: 0x00006599
		[DefaultValue(typeof(float), "0.01")]
		public float m_chargeSpeed { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x000083A2 File Offset: 0x000065A2
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x000083AA File Offset: 0x000065AA
		[DefaultValue(true)]
		public bool m_canUseFacingLogic { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x000083B3 File Offset: 0x000065B3
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x000083BB File Offset: 0x000065BB
		[DefaultValue(typeof(float), "0.1")]
		public float m_stopDistance { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x000083C4 File Offset: 0x000065C4
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x000083CC File Offset: 0x000065CC
		[DefaultValue(typeof(float), "0.3")]
		public float m_combatSpawnDuration { get; set; }

		// Token: 0x04000700 RID: 1792
		public float float_0 = 0.5f;

		// Token: 0x04000701 RID: 1793
		[XmlIgnore]
		public float float_1 = 1f;

		// Token: 0x04000702 RID: 1794
		[XmlIgnore]
		public float float_2 = 8f;

		// Token: 0x04000703 RID: 1795
		[XmlIgnore]
		public float float_3 = 360f;

		// Token: 0x04000704 RID: 1796
		[XmlIgnore]
		public float float_4;

		// Token: 0x04000705 RID: 1797
		[XmlIgnore]
		public ObstacleAvoidanceType obstacleAvoidanceType_0;

		// Token: 0x04000706 RID: 1798
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04000707 RID: 1799
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04000708 RID: 1800
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04000709 RID: 1801
		[CompilerGenerated]
		private float float_8;

		// Token: 0x0400070A RID: 1802
		[CompilerGenerated]
		private float float_9;

		// Token: 0x0400070B RID: 1803
		[CompilerGenerated]
		private float float_10;

		// Token: 0x0400070C RID: 1804
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400070D RID: 1805
		[CompilerGenerated]
		private float float_11;

		// Token: 0x0400070E RID: 1806
		[CompilerGenerated]
		private float float_12;
	}
}
