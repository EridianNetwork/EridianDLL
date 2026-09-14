using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x02000971 RID: 2417
	public class BHVMortarAttackSettings : BHVTaskSettings
	{
		// Token: 0x06004393 RID: 17299 RVA: 0x0002CE99 File Offset: 0x0002B099
		public BHVMortarAttackSettings()
		{
			this.m_shellDamage = 30;
			this.m_shellAmount = 3;
			this.m_shellDamageRadius = 1.5f;
			this.m_shellFlyingSpeed = 15f;
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06004394 RID: 17300 RVA: 0x0002CEC6 File Offset: 0x0002B0C6
		// (set) Token: 0x06004395 RID: 17301 RVA: 0x0002CECE File Offset: 0x0002B0CE
		[DefaultValue(30)]
		public int m_shellDamage { get; set; }

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06004396 RID: 17302 RVA: 0x0002CED7 File Offset: 0x0002B0D7
		// (set) Token: 0x06004397 RID: 17303 RVA: 0x0002CEDF File Offset: 0x0002B0DF
		[DefaultValue(3)]
		public int m_shellAmount { get; set; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06004398 RID: 17304 RVA: 0x0002CEE8 File Offset: 0x0002B0E8
		// (set) Token: 0x06004399 RID: 17305 RVA: 0x0002CEF0 File Offset: 0x0002B0F0
		[DefaultValue(typeof(float), "1.5")]
		public float m_shellDamageRadius { get; set; }

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x0600439A RID: 17306 RVA: 0x0002CEF9 File Offset: 0x0002B0F9
		// (set) Token: 0x0600439B RID: 17307 RVA: 0x0002CF01 File Offset: 0x0002B101
		[DefaultValue(typeof(float), "15")]
		public float m_shellFlyingSpeed { get; set; }

		// Token: 0x04002EC5 RID: 11973
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002EC6 RID: 11974
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002EC7 RID: 11975
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002EC8 RID: 11976
		[CompilerGenerated]
		private float float_1;
	}
}
