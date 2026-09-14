using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092F RID: 2351
	public class BHVFSMSettingsThrowGrenade : BHVPropertySettings
	{
		// Token: 0x06004121 RID: 16673 RVA: 0x0002B713 File Offset: 0x00029913
		public BHVFSMSettingsThrowGrenade()
		{
			this.m_throwGrenadeChance = 0.2f;
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06004122 RID: 16674 RVA: 0x0002B726 File Offset: 0x00029926
		// (set) Token: 0x06004123 RID: 16675 RVA: 0x0002B72E File Offset: 0x0002992E
		[DefaultValue(typeof(float), "0.2")]
		public float m_throwGrenadeChance { get; set; }

		// Token: 0x04002D81 RID: 11649
		[CompilerGenerated]
		private float float_0;
	}
}
