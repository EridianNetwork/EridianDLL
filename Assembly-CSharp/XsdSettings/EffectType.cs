using System;

namespace XsdSettings
{
	// Token: 0x02000A4B RID: 2635
	public enum EffectType
	{
		// Token: 0x040033B2 RID: 13234
		Invalid,
		// Token: 0x040033B3 RID: 13235
		EnlargeMaxShield,
		// Token: 0x040033B4 RID: 13236
		RefillShield,
		// Token: 0x040033B5 RID: 13237
		FlexibleTimeRegenHealthSpeed,
		// Token: 0x040033B6 RID: 13238
		FirebirdExplosionDamage,
		// Token: 0x040033B7 RID: 13239
		FirebirdExplodeCooldown,
		// Token: 0x040033B8 RID: 13240
		FirebirdExplodeChainNum,
		// Token: 0x040033B9 RID: 13241
		FirebirdRadius,
		// Token: 0x040033BA RID: 13242
		FirebirdDuration,
		// Token: 0x040033BB RID: 13243
		ClipSize,
		// Token: 0x040033BC RID: 13244
		ReloadChance,
		// Token: 0x040033BD RID: 13245
		DazeDuration,
		// Token: 0x040033BE RID: 13246
		IgniteEnemyChance,
		// Token: 0x040033BF RID: 13247
		DazeEnemyChance,
		// Token: 0x040033C0 RID: 13248
		ReviveChance,
		// Token: 0x040033C1 RID: 13249
		ReviveHealthPoint,
		// Token: 0x040033C2 RID: 13250
		BerserkRageDuration,
		// Token: 0x040033C3 RID: 13251
		EnlargeMaxHP,
		// Token: 0x040033C4 RID: 13252
		FixedTimeRegenHealthSpeed,
		// Token: 0x040033C5 RID: 13253
		BerserkStompRadius,
		// Token: 0x040033C6 RID: 13254
		BerserkStompDamage,
		// Token: 0x040033C7 RID: 13255
		BerserkCoolDownDuration,
		// Token: 0x040033C8 RID: 13256
		RegenAmmoSpeed,
		// Token: 0x040033C9 RID: 13257
		WeaponSwitchSpeed,
		// Token: 0x040033CA RID: 13258
		WeaponReloadSpeed,
		// Token: 0x040033CB RID: 13259
		GrenadeCapacity,
		// Token: 0x040033CC RID: 13260
		ConsumeNoAmmo,
		// Token: 0x040033CD RID: 13261
		BulletPerShot,
		// Token: 0x040033CE RID: 13262
		ReflectDamage,
		// Token: 0x040033CF RID: 13263
		DamageAsExplosion,
		// Token: 0x040033D0 RID: 13264
		TurretDeployFar,
		// Token: 0x040033D1 RID: 13265
		ElementDamage,
		// Token: 0x040033D2 RID: 13266
		HealthRegenAOE,
		// Token: 0x040033D3 RID: 13267
		AmmoRegenAOE,
		// Token: 0x040033D4 RID: 13268
		TurretShield,
		// Token: 0x040033D5 RID: 13269
		TurretRocket,
		// Token: 0x040033D6 RID: 13270
		WeaponDamage,
		// Token: 0x040033D7 RID: 13271
		TurretCooldown,
		// Token: 0x040033D8 RID: 13272
		TurretDeployExplode,
		// Token: 0x040033D9 RID: 13273
		TurretDestroyGrenade,
		// Token: 0x040033DA RID: 13274
		MarkingSpeed,
		// Token: 0x040033DB RID: 13275
		EvadeChance,
		// Token: 0x040033DC RID: 13276
		TransferDamageToMarked,
		// Token: 0x040033DD RID: 13277
		DrainMarkedLife,
		// Token: 0x040033DE RID: 13278
		CriticalHitDamage,
		// Token: 0x040033DF RID: 13279
		DamamgeBonusToMarked,
		// Token: 0x040033E0 RID: 13280
		ElementalChanceToMarked,
		// Token: 0x040033E1 RID: 13281
		MarkedExplodeOnKill,
		// Token: 0x040033E2 RID: 13282
		ZoomAccuracy,
		// Token: 0x040033E3 RID: 13283
		WeaponRecoil,
		// Token: 0x040033E4 RID: 13284
		WeaponSway,
		// Token: 0x040033E5 RID: 13285
		DroidCooldown,
		// Token: 0x040033E6 RID: 13286
		DroidBlastDamage,
		// Token: 0x040033E7 RID: 13287
		DroidBlastDazeChance,
		// Token: 0x040033E8 RID: 13288
		DropHealthPack,
		// Token: 0x040033E9 RID: 13289
		RegenHealthOnHit,
		// Token: 0x040033EA RID: 13290
		ExplodeOnHit,
		// Token: 0x040033EB RID: 13291
		MeleeIgnite,
		// Token: 0x040033EC RID: 13292
		ShieldRechargeRate,
		// Token: 0x040033ED RID: 13293
		EvadeDuration,
		// Token: 0x040033EE RID: 13294
		WpnElementalProc,
		// Token: 0x040033EF RID: 13295
		ConfuseChance,
		// Token: 0x040033F0 RID: 13296
		BerserkFireRate,
		// Token: 0x040033F1 RID: 13297
		DespHealthPercent,
		// Token: 0x040033F2 RID: 13298
		TriggerDownFireRateBoost,
		// Token: 0x040033F3 RID: 13299
		SkillExitRefillHP,
		// Token: 0x040033F4 RID: 13300
		SkillExitRefillShield,
		// Token: 0x040033F5 RID: 13301
		LowHealthDmgResist,
		// Token: 0x040033F6 RID: 13302
		BerserkPunchCount,
		// Token: 0x040033F7 RID: 13303
		GrenadeDmg,
		// Token: 0x040033F8 RID: 13304
		ShieldDepleteGrenadeDmg,
		// Token: 0x040033F9 RID: 13305
		ShieldDepleteGrenadeCount,
		// Token: 0x040033FA RID: 13306
		TurretHP,
		// Token: 0x040033FB RID: 13307
		TurretRepulseStr,
		// Token: 0x040033FC RID: 13308
		TurretElectroStr,
		// Token: 0x040033FD RID: 13309
		WpnSwapFireRate,
		// Token: 0x040033FE RID: 13310
		OnKillDroidDuration,
		// Token: 0x040033FF RID: 13311
		ChargeShotDmg,
		// Token: 0x04003400 RID: 13312
		ChargeShotSpeed,
		// Token: 0x04003401 RID: 13313
		OnEvadeReflectDmgPercent,
		// Token: 0x04003402 RID: 13314
		AutoMarkAttackerChance,
		// Token: 0x04003403 RID: 13315
		MarkingSlowRate,
		// Token: 0x04003404 RID: 13316
		MultiMarkCount,
		// Token: 0x04003405 RID: 13317
		ResistElemental,
		// Token: 0x04003406 RID: 13318
		DecreaseElementalDuration,
		// Token: 0x04003407 RID: 13319
		IgniteWhenFirebird,
		// Token: 0x04003408 RID: 13320
		ChanceElementalExplode,
		// Token: 0x04003409 RID: 13321
		ExtendElementalDOT,
		// Token: 0x0400340A RID: 13322
		ChanceDazeWhenDOT,
		// Token: 0x0400340B RID: 13323
		AccelCooldownWhenHurt,
		// Token: 0x0400340C RID: 13324
		ChanceAddBulletWhenHurt,
		// Token: 0x0400340D RID: 13325
		RegenHealthFromEnemy,
		// Token: 0x0400340E RID: 13326
		ExtendRangeDuration,
		// Token: 0x0400340F RID: 13327
		AddMeleeDamage,
		// Token: 0x04003410 RID: 13328
		ChanceMeleeDaze,
		// Token: 0x04003411 RID: 13329
		ChanceLoadMoreBullet,
		// Token: 0x04003412 RID: 13330
		TurretWithSniper,
		// Token: 0x04003413 RID: 13331
		TransferDamageToTurret,
		// Token: 0x04003414 RID: 13332
		SlowdownNearTurret,
		// Token: 0x04003415 RID: 13333
		ResistExplode,
		// Token: 0x04003416 RID: 13334
		ThrowMine,
		// Token: 0x04003417 RID: 13335
		Invisible,
		// Token: 0x04003418 RID: 13336
		MoreDamageToLowHealth,
		// Token: 0x04003419 RID: 13337
		ExplodeOnCriticalHit,
		// Token: 0x0400341A RID: 13338
		DecreaseHunterCooldown,
		// Token: 0x0400341B RID: 13339
		ChanceDazeOnCriticalHit,
		// Token: 0x0400341C RID: 13340
		RevealEnemy,
		// Token: 0x0400341D RID: 13341
		AmmoCapacity,
		// Token: 0x0400341E RID: 13342
		WeaponAccuracy,
		// Token: 0x0400341F RID: 13343
		LootProbability,
		// Token: 0x04003420 RID: 13344
		GoldBonus,
		// Token: 0x04003421 RID: 13345
		XPBonus,
		// Token: 0x04003422 RID: 13346
		ShieldRechargeDelay,
		// Token: 0x04003423 RID: 13347
		BulletDamagePostAdd,
		// Token: 0x04003424 RID: 13348
		BulletDamageScale,
		// Token: 0x04003425 RID: 13349
		WeaponMaxHPPostAdd,
		// Token: 0x04003426 RID: 13350
		WeaponMaxHPScale,
		// Token: 0x04003427 RID: 13351
		WeaponMaxShieldPostAdd,
		// Token: 0x04003428 RID: 13352
		WeaponMaxShieldScale,
		// Token: 0x04003429 RID: 13353
		CriticalChance,
		// Token: 0x0400342A RID: 13354
		MeleeDamageBonus,
		// Token: 0x0400342B RID: 13355
		MeleeDamageResistance,
		// Token: 0x0400342C RID: 13356
		ShieldRechargeOnKill,
		// Token: 0x0400342D RID: 13357
		BadassDamageBonus,
		// Token: 0x0400342E RID: 13358
		HealthPackBonus,
		// Token: 0x0400342F RID: 13359
		AmmoPackBonus,
		// Token: 0x04003430 RID: 13360
		ZoomTransitionSpeed,
		// Token: 0x04003431 RID: 13361
		FireResistance,
		// Token: 0x04003432 RID: 13362
		FireEnhance,
		// Token: 0x04003433 RID: 13363
		ShockResistance,
		// Token: 0x04003434 RID: 13364
		ShockEnhance,
		// Token: 0x04003435 RID: 13365
		CorrosiveResistance,
		// Token: 0x04003436 RID: 13366
		CorrosiveEnhance,
		// Token: 0x04003437 RID: 13367
		AllResistance,
		// Token: 0x04003438 RID: 13368
		DefensePoint,
		// Token: 0x04003439 RID: 13369
		DefensePenetration,
		// Token: 0x0400343A RID: 13370
		DamageReflectGeneral,
		// Token: 0x0400343B RID: 13371
		HealthRegenGeneral,
		// Token: 0x0400343C RID: 13372
		AmmoRegenGeneral,
		// Token: 0x0400343D RID: 13373
		BulletDamageResistance,
		// Token: 0x0400343E RID: 13374
		ExplosiveDamageResistance,
		// Token: 0x0400343F RID: 13375
		Max
	}
}
