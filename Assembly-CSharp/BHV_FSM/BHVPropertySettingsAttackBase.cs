using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	// Token: 0x02000158 RID: 344
	[XmlInclude(typeof(BHVFSMSettingsEnergyBlast))]
	[XmlInclude(typeof(BHVFSMSettingsDeathStruggle))]
	[XmlInclude(typeof(BHVFSMSettingsEnergyMissile))]
	[XmlInclude(typeof(BHVFSMSettingsWebTrap))]
	[XmlInclude(typeof(BHVFSMSettingsPoisonSpit))]
	[XmlInclude(typeof(BHVFSMSettingsSwordSlash))]
	[XmlInclude(typeof(BHVFSMSettingsEarthPikeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsEyeLaserPlus))]
	[XmlInclude(typeof(BHVFSMSettingsCrystalDeathStruggle))]
	[XmlInclude(typeof(BHVFSMSettingsPlayerTeleport))]
	[XmlInclude(typeof(BHVFSMSettingsEyeLaser))]
	[XmlInclude(typeof(BHVFSMSettingsTentacleSpawn))]
	[XmlInclude(typeof(BHVFSMSettingsTentacleSweep))]
	[XmlInclude(typeof(BHVFSMSettingsPoisonDash))]
	[XmlInclude(typeof(BHVFSMSettingsLaserSweep))]
	[XmlInclude(typeof(BHVFSMSettingsJumpAttack))]
	[XmlInclude(typeof(BHVFSMSettingsSpitAttack))]
	[XmlInclude(typeof(BHVFSMSettingsChargeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsPoisonCrush))]
	[XmlInclude(typeof(BHVFSMSettingsJetAttack))]
	[XmlInclude(typeof(BHVFSMSettingsSuicide))]
	[XmlInclude(typeof(BHVFSMSettingsBurrowAttack))]
	[XmlInclude(typeof(BHVFSMSettingsMortarAttack))]
	[XmlInclude(typeof(BHVFSMSettingsRailGunAttack))]
	[XmlInclude(typeof(BHVFSMSettingsIceMeteorRandomAttack))]
	[XmlInclude(typeof(BHVFSMSettingsMeleeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsMinionSummon))]
	[XmlInclude(typeof(BHVFSMSettingsIceMeteorRowAttack))]
	[XmlInclude(typeof(BHVFSMSettingsIceEarthquakeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsRadiusAttack))]
	[XmlInclude(typeof(BHVFSMSettingsRoundMeleeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsThrowDaggerAttack))]
	public class BHVPropertySettingsAttackBase : BHVPropertySettings
	{
		// Token: 0x060007F7 RID: 2039 RVA: 0x000082B4 File Offset: 0x000064B4
		public BHVPropertySettingsAttackBase()
		{
			this.m_attackMode = ENpcAttackMode.NAM_None;
			this.m_attackChanceWeight = 1f;
			this.m_coolDownTime = 0f;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x000082E0 File Offset: 0x000064E0
		// (set) Token: 0x060007F9 RID: 2041 RVA: 0x000082E8 File Offset: 0x000064E8
		public ENpcAttackMode m_attackMode { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x000082F1 File Offset: 0x000064F1
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x000082F9 File Offset: 0x000064F9
		[DefaultValue(typeof(float), "1")]
		public float m_attackChanceWeight { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x00008302 File Offset: 0x00006502
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0000830A File Offset: 0x0000650A
		[DefaultValue(typeof(float), "0")]
		public float m_coolDownTime { get; set; }

		// Token: 0x040006EF RID: 1775
		public float float_0;

		// Token: 0x040006F0 RID: 1776
		public bool bool_0 = true;

		// Token: 0x040006F1 RID: 1777
		[CompilerGenerated]
		private ENpcAttackMode enpcAttackMode_0;

		// Token: 0x040006F2 RID: 1778
		[CompilerGenerated]
		private float float_1;

		// Token: 0x040006F3 RID: 1779
		[CompilerGenerated]
		private float float_2;
	}
}
