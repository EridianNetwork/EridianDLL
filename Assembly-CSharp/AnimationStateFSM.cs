using System;

// Token: 0x0200000F RID: 15
public enum AnimationStateFSM
{
	// Token: 0x04000045 RID: 69
	Invalid = -1,
	// Token: 0x04000046 RID: 70
	Idle,
	// Token: 0x04000047 RID: 71
	Move,
	// Token: 0x04000048 RID: 72
	MoveWithFacing,
	// Token: 0x04000049 RID: 73
	HoverPatrol,
	// Token: 0x0400004A RID: 74
	FlyMeleeAttack,
	// Token: 0x0400004B RID: 75
	FlyGather,
	// Token: 0x0400004C RID: 76
	Die,
	// Token: 0x0400004D RID: 77
	Dead,
	// Token: 0x0400004E RID: 78
	MeleeAttack,
	// Token: 0x0400004F RID: 79
	JumpAttack,
	// Token: 0x04000050 RID: 80
	JumpAttackCrash,
	// Token: 0x04000051 RID: 81
	Warcry,
	// Token: 0x04000052 RID: 82
	Charge,
	// Token: 0x04000053 RID: 83
	ChargeHit,
	// Token: 0x04000054 RID: 84
	Spawn,
	// Token: 0x04000055 RID: 85
	AdvanceSpawn,
	// Token: 0x04000056 RID: 86
	Stun,
	// Token: 0x04000057 RID: 87
	JumpOnSpot,
	// Token: 0x04000058 RID: 88
	Fire,
	// Token: 0x04000059 RID: 89
	FireFullBody,
	// Token: 0x0400005A RID: 90
	DeployAidStation,
	// Token: 0x0400005B RID: 91
	Reload,
	// Token: 0x0400005C RID: 92
	CoverFire,
	// Token: 0x0400005D RID: 93
	CoverIdleBeforeFire,
	// Token: 0x0400005E RID: 94
	CoverIdle,
	// Token: 0x0400005F RID: 95
	CoverLookAround,
	// Token: 0x04000060 RID: 96
	CoverPeakIn,
	// Token: 0x04000061 RID: 97
	CoverPeakOut,
	// Token: 0x04000062 RID: 98
	CoverReload,
	// Token: 0x04000063 RID: 99
	Hurt,
	// Token: 0x04000064 RID: 100
	LightHurt,
	// Token: 0x04000065 RID: 101
	SuicideBomb,
	// Token: 0x04000066 RID: 102
	RadiusAttack,
	// Token: 0x04000067 RID: 103
	Burrow,
	// Token: 0x04000068 RID: 104
	Alert,
	// Token: 0x04000069 RID: 105
	Roll,
	// Token: 0x0400006A RID: 106
	SideStep,
	// Token: 0x0400006B RID: 107
	Spit,
	// Token: 0x0400006C RID: 108
	Spacing,
	// Token: 0x0400006D RID: 109
	Critical,
	// Token: 0x0400006E RID: 110
	SlideMove,
	// Token: 0x0400006F RID: 111
	ThrowWeapon,
	// Token: 0x04000070 RID: 112
	ShowWeapon,
	// Token: 0x04000071 RID: 113
	IceEarthquakeAttack,
	// Token: 0x04000072 RID: 114
	IceMeteorAttack,
	// Token: 0x04000073 RID: 115
	SummonExtraNPC,
	// Token: 0x04000074 RID: 116
	Warning,
	// Token: 0x04000075 RID: 117
	CombatSpawn,
	// Token: 0x04000076 RID: 118
	RailgunAttack,
	// Token: 0x04000077 RID: 119
	MortarAttack,
	// Token: 0x04000078 RID: 120
	TurnTo,
	// Token: 0x04000079 RID: 121
	TurnOnSpot,
	// Token: 0x0400007A RID: 122
	LaserSweep,
	// Token: 0x0400007B RID: 123
	Empty,
	// Token: 0x0400007C RID: 124
	PlayerIdle,
	// Token: 0x0400007D RID: 125
	PlayerMove,
	// Token: 0x0400007E RID: 126
	PlayerCrouchIdle,
	// Token: 0x0400007F RID: 127
	PlayerCrouchMove,
	// Token: 0x04000080 RID: 128
	PlayerFire,
	// Token: 0x04000081 RID: 129
	PlayerReload,
	// Token: 0x04000082 RID: 130
	PlayerSwitchDown,
	// Token: 0x04000083 RID: 131
	PlayerSwitchUp,
	// Token: 0x04000084 RID: 132
	PlayerAim,
	// Token: 0x04000085 RID: 133
	PlayerJump,
	// Token: 0x04000086 RID: 134
	PlayerPickupWeapon,
	// Token: 0x04000087 RID: 135
	PlayerMelee,
	// Token: 0x04000088 RID: 136
	PlayerMeleeSkill,
	// Token: 0x04000089 RID: 137
	PlayerThrowGrenade,
	// Token: 0x0400008A RID: 138
	PlayerFireBird,
	// Token: 0x0400008B RID: 139
	PlayerCallback,
	// Token: 0x0400008C RID: 140
	PlayerDie,
	// Token: 0x0400008D RID: 141
	PlayerBerserkCharge,
	// Token: 0x0400008E RID: 142
	PlayerBerserkDash,
	// Token: 0x0400008F RID: 143
	PlayerBerserkPunch,
	// Token: 0x04000090 RID: 144
	PlayerThrowTurret,
	// Token: 0x04000091 RID: 145
	PlayerRetrieveTurret,
	// Token: 0x04000092 RID: 146
	LavaStrike,
	// Token: 0x04000093 RID: 147
	PlayerReleaseDroid,
	// Token: 0x04000094 RID: 148
	PlayerRetrieveDroid,
	// Token: 0x04000095 RID: 149
	WebTrap,
	// Token: 0x04000096 RID: 150
	TutorialLesson,
	// Token: 0x04000097 RID: 151
	TutorialAction,
	// Token: 0x04000098 RID: 152
	CircleMove,
	// Token: 0x04000099 RID: 153
	PlayerJumpStart,
	// Token: 0x0400009A RID: 154
	PlayerJumpIdle,
	// Token: 0x0400009B RID: 155
	PlayerJumpLand,
	// Token: 0x0400009C RID: 156
	AttachBomb,
	// Token: 0x0400009D RID: 157
	DropBomb
}
