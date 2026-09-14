using System;

// Token: 0x0200008E RID: 142
public enum ENPCParticleType
{
	// Token: 0x040002E0 RID: 736
	E_Spawn,
	// Token: 0x040002E1 RID: 737
	E_RadiusAttack,
	// Token: 0x040002E2 RID: 738
	E_Burrow,
	// Token: 0x040002E3 RID: 739
	E_Stun,
	// Token: 0x040002E4 RID: 740
	E_JumpOnSpot,
	// Token: 0x040002E5 RID: 741
	E_DamagedBulletNone,
	// Token: 0x040002E6 RID: 742
	E_DamageHeadShot,
	// Token: 0x040002E7 RID: 743
	E_DamageSpitAtMouth,
	// Token: 0x040002E8 RID: 744
	E_DamageSpitAtTouchedObject,
	// Token: 0x040002E9 RID: 745
	E_DamagedBulletFire,
	// Token: 0x040002EA RID: 746
	E_DamagedBulletShock,
	// Token: 0x040002EB RID: 747
	E_DamagedBulletCorrosive,
	// Token: 0x040002EC RID: 748
	E_DamagedBulletExplosive,
	// Token: 0x040002ED RID: 749
	E_DamageOverTimeFire,
	// Token: 0x040002EE RID: 750
	E_DamageOverTimeShock,
	// Token: 0x040002EF RID: 751
	E_DamageOverTimeCorrosive,
	// Token: 0x040002F0 RID: 752
	E_Player_HandFire,
	// Token: 0x040002F1 RID: 753
	E_FireBird_Burst,
	// Token: 0x040002F2 RID: 754
	E_FireBird_Tailing,
	// Token: 0x040002F3 RID: 755
	E_FireBird_WingTips_L,
	// Token: 0x040002F4 RID: 756
	E_FireBird_Absorb,
	// Token: 0x040002F5 RID: 757
	E_Player_AbsorbFirebird,
	// Token: 0x040002F6 RID: 758
	E_IceBroken,
	// Token: 0x040002F7 RID: 759
	E_Player_BerserkStomp,
	// Token: 0x040002F8 RID: 760
	E_Player_BerserkDust,
	// Token: 0x040002F9 RID: 761
	E_Player_BerserkPunch,
	// Token: 0x040002FA RID: 762
	E_WeaponAppear,
	// Token: 0x040002FB RID: 763
	E_MoveDust,
	// Token: 0x040002FC RID: 764
	E_IceThorn,
	// Token: 0x040002FD RID: 765
	E_Player_BerserkStatus,
	// Token: 0x040002FE RID: 766
	E_Player_BerserkAirflow,
	// Token: 0x040002FF RID: 767
	E_FireBird_WingTips_R,
	// Token: 0x04000300 RID: 768
	E_DamageOnArmor,
	// Token: 0x04000301 RID: 769
	E_PlasmaBallCharge,
	// Token: 0x04000302 RID: 770
	E_PlasmaBallFly,
	// Token: 0x04000303 RID: 771
	E_PlasmaBallBurst,
	// Token: 0x04000304 RID: 772
	E_KnoxxMissileFlying,
	// Token: 0x04000305 RID: 773
	E_KnoxxMissileBurst,
	// Token: 0x04000306 RID: 774
	E_FireBird_Flash,
	// Token: 0x04000307 RID: 775
	E_Berserk_CureHeart,
	// Token: 0x04000308 RID: 776
	E_Explode,
	// Token: 0x04000309 RID: 777
	E_Fuse,
	// Token: 0x0400030A RID: 778
	E_Berserk_StompShock_1st,
	// Token: 0x0400030B RID: 779
	E_Berserk_MeteorFist_1st,
	// Token: 0x0400030C RID: 780
	E_TurretRocket,
	// Token: 0x0400030D RID: 781
	E_KnoxxLaserGuns,
	// Token: 0x0400030E RID: 782
	E_TurretShield,
	// Token: 0x0400030F RID: 783
	E_TurretSpawn,
	// Token: 0x04000310 RID: 784
	E_TurretOff,
	// Token: 0x04000311 RID: 785
	E_NPC_Heal,
	// Token: 0x04000312 RID: 786
	E_DamageShieldHit,
	// Token: 0x04000313 RID: 787
	E_DamageShieldBroken,
	// Token: 0x04000314 RID: 788
	E_DamageShieldFull,
	// Token: 0x04000315 RID: 789
	E_DamageElectricity,
	// Token: 0x04000316 RID: 790
	E_DamageVenom,
	// Token: 0x04000317 RID: 791
	E_DamageFire,
	// Token: 0x04000318 RID: 792
	E_HammerHitVFX,
	// Token: 0x04000319 RID: 793
	E_HunterDroid_Spawn,
	// Token: 0x0400031A RID: 794
	E_HunterDroid_Marking,
	// Token: 0x0400031B RID: 795
	E_HunterDroid_SecondAction,
	// Token: 0x0400031C RID: 796
	E_HunterDroid_Disappear,
	// Token: 0x0400031D RID: 797
	E_Marked_Slag,
	// Token: 0x0400031E RID: 798
	E_BerserkAura_Start,
	// Token: 0x0400031F RID: 799
	E_BerserkAura_Continue,
	// Token: 0x04000320 RID: 800
	E_Hunter_FullScreen,
	// Token: 0x04000321 RID: 801
	E_ArchangelOpenFace,
	// Token: 0x04000322 RID: 802
	E_ArchangelEnergyExplosive,
	// Token: 0x04000323 RID: 803
	E_archangelEnergyMissile,
	// Token: 0x04000324 RID: 804
	E_archangelTeleport,
	// Token: 0x04000325 RID: 805
	E_archangelDeathStruggle,
	// Token: 0x04000326 RID: 806
	E_TurretRegenAmmo,
	// Token: 0x04000327 RID: 807
	E_TurretRegenHealth,
	// Token: 0x04000328 RID: 808
	E_TurretRegenAmmoHealth,
	// Token: 0x04000329 RID: 809
	E_FirstPersonLockOn,
	// Token: 0x0400032A RID: 810
	E_PlayerTeleportAbsorb,
	// Token: 0x0400032B RID: 811
	E_PlayerTeleportRelease,
	// Token: 0x0400032C RID: 812
	E_TheInsaneEyeDestroy,
	// Token: 0x0400032D RID: 813
	E_JumpAttack,
	// Token: 0x0400032E RID: 814
	E_DeadEffect,
	// Token: 0x0400032F RID: 815
	E_CrystalDeathStruggle,
	// Token: 0x04000330 RID: 816
	E_PoisonSpit,
	// Token: 0x04000331 RID: 817
	E_DashBeam,
	// Token: 0x04000332 RID: 818
	E_Invisible,
	// Token: 0x04000333 RID: 819
	E_SwordSlash,
	// Token: 0x04000334 RID: 820
	E_DefenseField,
	// Token: 0x04000335 RID: 821
	E_PlayerRevive
}
