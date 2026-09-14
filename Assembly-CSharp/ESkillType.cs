using System;

// Token: 0x0200054C RID: 1356
public enum ESkillType
{
	// Token: 0x0400173F RID: 5951
	None,
	// Token: 0x04001740 RID: 5952
	FirebirdFirstAction,
	// Token: 0x04001741 RID: 5953
	FirebirdSecondAction,
	// Token: 0x04001742 RID: 5954
	FireHeart,
	// Token: 0x04001743 RID: 5955
	FireEater,
	// Token: 0x04001744 RID: 5956
	Ignition,
	// Token: 0x04001745 RID: 5957
	Detonation,
	// Token: 0x04001746 RID: 5958
	Absorption,
	// Token: 0x04001747 RID: 5959
	UndyingFlames,
	// Token: 0x04001748 RID: 5960
	FireWings,
	// Token: 0x04001749 RID: 5961
	Sparkle,
	// Token: 0x0400174A RID: 5962
	DazzlingShots,
	// Token: 0x0400174B RID: 5963
	Resurrection,
	// Token: 0x0400174C RID: 5964
	Glare,
	// Token: 0x0400174D RID: 5965
	Retaliation,
	// Token: 0x0400174E RID: 5966
	Gifted,
	// Token: 0x0400174F RID: 5967
	Ablaze,
	// Token: 0x04001750 RID: 5968
	Energize,
	// Token: 0x04001751 RID: 5969
	Ethereal,
	// Token: 0x04001752 RID: 5970
	Astute,
	// Token: 0x04001753 RID: 5971
	Deception,
	// Token: 0x04001754 RID: 5972
	Inert,
	// Token: 0x04001755 RID: 5973
	Repress,
	// Token: 0x04001756 RID: 5974
	Combustion,
	// Token: 0x04001757 RID: 5975
	Temperamental,
	// Token: 0x04001758 RID: 5976
	Clingy,
	// Token: 0x04001759 RID: 5977
	Blackout,
	// Token: 0x0400175A RID: 5978
	BerserkFirstAction = 51,
	// Token: 0x0400175B RID: 5979
	BerserkSecondAction,
	// Token: 0x0400175C RID: 5980
	BigPockets,
	// Token: 0x0400175D RID: 5981
	CombatReload,
	// Token: 0x0400175E RID: 5982
	RedFury,
	// Token: 0x0400175F RID: 5983
	BerserkOverweight,
	// Token: 0x04001760 RID: 5984
	Bloodlust,
	// Token: 0x04001761 RID: 5985
	BURP,
	// Token: 0x04001762 RID: 5986
	BadTemper,
	// Token: 0x04001763 RID: 5987
	BamBam,
	// Token: 0x04001764 RID: 5988
	Boxer,
	// Token: 0x04001765 RID: 5989
	PhantomShot,
	// Token: 0x04001766 RID: 5990
	MagicBullet,
	// Token: 0x04001767 RID: 5991
	Retribution,
	// Token: 0x04001768 RID: 5992
	Discharge,
	// Token: 0x04001769 RID: 5993
	Adrenaline,
	// Token: 0x0400176A RID: 5994
	Desperation,
	// Token: 0x0400176B RID: 5995
	Tenacity,
	// Token: 0x0400176C RID: 5996
	Relentless,
	// Token: 0x0400176D RID: 5997
	Fortitude,
	// Token: 0x0400176E RID: 5998
	Snappy,
	// Token: 0x0400176F RID: 5999
	Grit,
	// Token: 0x04001770 RID: 6000
	Gutsy,
	// Token: 0x04001771 RID: 6001
	Raging,
	// Token: 0x04001772 RID: 6002
	Pummel,
	// Token: 0x04001773 RID: 6003
	Knockout,
	// Token: 0x04001774 RID: 6004
	TurretFirstAction = 101,
	// Token: 0x04001775 RID: 6005
	TurretSecondAction,
	// Token: 0x04001776 RID: 6006
	SpeedyHands,
	// Token: 0x04001777 RID: 6007
	SecretPouch,
	// Token: 0x04001778 RID: 6008
	ShotPut,
	// Token: 0x04001779 RID: 6009
	ShortCircuit,
	// Token: 0x0400177A RID: 6010
	BionicLink,
	// Token: 0x0400177B RID: 6011
	SupplyPack,
	// Token: 0x0400177C RID: 6012
	Bunker,
	// Token: 0x0400177D RID: 6013
	Rocker,
	// Token: 0x0400177E RID: 6014
	Unison,
	// Token: 0x0400177F RID: 6015
	Conservation,
	// Token: 0x04001780 RID: 6016
	Decompress,
	// Token: 0x04001781 RID: 6017
	Aftershock,
	// Token: 0x04001782 RID: 6018
	FirePowder,
	// Token: 0x04001783 RID: 6019
	ShieldBomb,
	// Token: 0x04001784 RID: 6020
	Battery,
	// Token: 0x04001785 RID: 6021
	Repulsor,
	// Token: 0x04001786 RID: 6022
	Electrocute,
	// Token: 0x04001787 RID: 6023
	Readiness,
	// Token: 0x04001788 RID: 6024
	Overload,
	// Token: 0x04001789 RID: 6025
	SniperTurret,
	// Token: 0x0400178A RID: 6026
	LinkedHealth,
	// Token: 0x0400178B RID: 6027
	GraviField,
	// Token: 0x0400178C RID: 6028
	BlastSuit,
	// Token: 0x0400178D RID: 6029
	MineLayer,
	// Token: 0x0400178E RID: 6030
	Seasoned,
	// Token: 0x0400178F RID: 6031
	HunterFirstAction = 151,
	// Token: 0x04001790 RID: 6032
	HunterSecondAction,
	// Token: 0x04001791 RID: 6033
	Swift,
	// Token: 0x04001792 RID: 6034
	Intangible,
	// Token: 0x04001793 RID: 6035
	Shift,
	// Token: 0x04001794 RID: 6036
	Siphon,
	// Token: 0x04001795 RID: 6037
	VitalPoint,
	// Token: 0x04001796 RID: 6038
	Exploit,
	// Token: 0x04001797 RID: 6039
	Volatile,
	// Token: 0x04001798 RID: 6040
	Bounty,
	// Token: 0x04001799 RID: 6041
	Precision,
	// Token: 0x0400179A RID: 6042
	Balanced,
	// Token: 0x0400179B RID: 6043
	Booster,
	// Token: 0x0400179C RID: 6044
	Disorientate,
	// Token: 0x0400179D RID: 6045
	Continuity,
	// Token: 0x0400179E RID: 6046
	ChargedShot,
	// Token: 0x0400179F RID: 6047
	Redirect,
	// Token: 0x040017A0 RID: 6048
	Vigilance,
	// Token: 0x040017A1 RID: 6049
	Impedance,
	// Token: 0x040017A2 RID: 6050
	Scan,
	// Token: 0x040017A3 RID: 6051
	Reactive,
	// Token: 0x040017A4 RID: 6052
	Conceal,
	// Token: 0x040017A5 RID: 6053
	FinalBlow,
	// Token: 0x040017A6 RID: 6054
	Obliteration,
	// Token: 0x040017A7 RID: 6055
	Payback,
	// Token: 0x040017A8 RID: 6056
	JoltShot,
	// Token: 0x040017A9 RID: 6057
	Max = 201
}
