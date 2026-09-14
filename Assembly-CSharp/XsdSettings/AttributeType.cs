using System;

namespace XsdSettings
{
	// Token: 0x02000A6D RID: 2669
	public enum AttributeType
	{
		// Token: 0x040034A0 RID: 13472
		None,
		// Token: 0x040034A1 RID: 13473
		AccuracyMin,
		// Token: 0x040034A2 RID: 13474
		AccuracyMax,
		// Token: 0x040034A3 RID: 13475
		AccuracyDecrease,
		// Token: 0x040034A4 RID: 13476
		AccuracyRegenerationRateOnIdle,
		// Token: 0x040034A5 RID: 13477
		AccuracyRegenerationDelayOnIdle,
		// Token: 0x040034A6 RID: 13478
		AccuracyRegenerationRateActive,
		// Token: 0x040034A7 RID: 13479
		AccuracyMinZoom,
		// Token: 0x040034A8 RID: 13480
		AccuracyMaxZoom,
		// Token: 0x040034A9 RID: 13481
		AccuracyDecreaseZoom,
		// Token: 0x040034AA RID: 13482
		AccuracyRegenerationRateOnIdleZoom,
		// Token: 0x040034AB RID: 13483
		AccuracyRegenerationDelayOnIdleZoom,
		// Token: 0x040034AC RID: 13484
		AccuracyRegenerationRateActiveZoom,
		// Token: 0x040034AD RID: 13485
		InnerAccuracyMin,
		// Token: 0x040034AE RID: 13486
		InnerAccuracyMax,
		// Token: 0x040034AF RID: 13487
		InnerAccuracyDecrease,
		// Token: 0x040034B0 RID: 13488
		InnerAccuracyRegenerationRateActive,
		// Token: 0x040034B1 RID: 13489
		InnerAccuracyRatio,
		// Token: 0x040034B2 RID: 13490
		RecoilPitchRandomOffsetMin,
		// Token: 0x040034B3 RID: 13491
		RecoilPitchRandomOffsetMax,
		// Token: 0x040034B4 RID: 13492
		RecoilPitchOffsetMin,
		// Token: 0x040034B5 RID: 13493
		RecoilPitchOffsetMax,
		// Token: 0x040034B6 RID: 13494
		RecoilPitchReducingRateActive,
		// Token: 0x040034B7 RID: 13495
		RecoilPitchReducingRateOnIdle,
		// Token: 0x040034B8 RID: 13496
		RecoilYawRandomOffsetMin,
		// Token: 0x040034B9 RID: 13497
		RecoilYawRandomOffsetMax,
		// Token: 0x040034BA RID: 13498
		RecoilYawOffsetMin,
		// Token: 0x040034BB RID: 13499
		RecoilYawOffsetMax,
		// Token: 0x040034BC RID: 13500
		RecoilYawReducingRateActive,
		// Token: 0x040034BD RID: 13501
		RecoilYawReducingRateOnIdle,
		// Token: 0x040034BE RID: 13502
		RecoilKickBackRandomOffsetMin,
		// Token: 0x040034BF RID: 13503
		RecoilKickBackRandomOffsetMax,
		// Token: 0x040034C0 RID: 13504
		RecoilKickBackOffsetMin,
		// Token: 0x040034C1 RID: 13505
		RecoilKickBackOffsetMax,
		// Token: 0x040034C2 RID: 13506
		RecoilKickBackReducingRateActive,
		// Token: 0x040034C3 RID: 13507
		RecoilKickBackReducingRateOnIdle,
		// Token: 0x040034C4 RID: 13508
		RecoilZoomPitchRandomOffsetMin,
		// Token: 0x040034C5 RID: 13509
		RecoilZoomPitchRandomOffsetMax,
		// Token: 0x040034C6 RID: 13510
		RecoilZoomPitchOffsetMin,
		// Token: 0x040034C7 RID: 13511
		RecoilZoomPitchOffsetMax,
		// Token: 0x040034C8 RID: 13512
		RecoilZoomPitchReducingRateActive,
		// Token: 0x040034C9 RID: 13513
		RecoilZoomPitchReducingRateOnIdle,
		// Token: 0x040034CA RID: 13514
		RecoilZoomYawRandomOffsetMin,
		// Token: 0x040034CB RID: 13515
		RecoilZoomYawRandomOffsetMax,
		// Token: 0x040034CC RID: 13516
		RecoilZoomYawOffsetMin,
		// Token: 0x040034CD RID: 13517
		RecoilZoomYawOffsetMax,
		// Token: 0x040034CE RID: 13518
		RecoilZoomYawReducingRateActive,
		// Token: 0x040034CF RID: 13519
		RecoilZoomYawReducingRateOnIdle,
		// Token: 0x040034D0 RID: 13520
		RecoilZoomKickBackRandomOffsetMin,
		// Token: 0x040034D1 RID: 13521
		RecoilZoomKickBackRandomOffsetMax,
		// Token: 0x040034D2 RID: 13522
		RecoilZoomKickBackOffsetMin,
		// Token: 0x040034D3 RID: 13523
		RecoilZoomKickBackOffsetMax,
		// Token: 0x040034D4 RID: 13524
		RecoilZoomKickBackReducingRateActive,
		// Token: 0x040034D5 RID: 13525
		RecoilZoomKickBackReducingRateOnIdle,
		// Token: 0x040034D6 RID: 13526
		RecoilPitchMulMin,
		// Token: 0x040034D7 RID: 13527
		RecoilPitchMulMax,
		// Token: 0x040034D8 RID: 13528
		AmmoRegenerationRate,
		// Token: 0x040034D9 RID: 13529
		ClipSize,
		// Token: 0x040034DA RID: 13530
		MaxStoredAmmo,
		// Token: 0x040034DB RID: 13531
		ShotCost,
		// Token: 0x040034DC RID: 13532
		StartingAmmoCount,
		// Token: 0x040034DD RID: 13533
		CurrentAmmoCount,
		// Token: 0x040034DE RID: 13534
		WeaponProjectilesPerShot,
		// Token: 0x040034DF RID: 13535
		FireRate,
		// Token: 0x040034E0 RID: 13536
		FireForceFeedback,
		// Token: 0x040034E1 RID: 13537
		FiringBurst,
		// Token: 0x040034E2 RID: 13538
		ReloadTime,
		// Token: 0x040034E3 RID: 13539
		ReloadPercentage,
		// Token: 0x040034E4 RID: 13540
		ReloadType,
		// Token: 0x040034E5 RID: 13541
		CanEjectBulletShells,
		// Token: 0x040034E6 RID: 13542
		BobDamping,
		// Token: 0x040034E7 RID: 13543
		FirstPersonMeshFOV,
		// Token: 0x040034E8 RID: 13544
		LeadingSpeed,
		// Token: 0x040034E9 RID: 13545
		MaxPitchLead,
		// Token: 0x040034EA RID: 13546
		MaxYawLead,
		// Token: 0x040034EB RID: 13547
		ViewModelTranslationAmt,
		// Token: 0x040034EC RID: 13548
		PlayerViewOffset,
		// Token: 0x040034ED RID: 13549
		ScopeMuzzleFlashOffset,
		// Token: 0x040034EE RID: 13550
		ThirdPersonMeshScale,
		// Token: 0x040034EF RID: 13551
		ViewModelRotationAmt,
		// Token: 0x040034F0 RID: 13552
		ViewModelRotationOriginOffset,
		// Token: 0x040034F1 RID: 13553
		WeaponKickDownTime,
		// Token: 0x040034F2 RID: 13554
		WeaponKickUpSpeed,
		// Token: 0x040034F3 RID: 13555
		WeaponKickZoomMultiplier,
		// Token: 0x040034F4 RID: 13556
		ZoomEndFOV,
		// Token: 0x040034F5 RID: 13557
		ZoomRotation,
		// Token: 0x040034F6 RID: 13558
		ZoomTime,
		// Token: 0x040034F7 RID: 13559
		ZoomTranslation,
		// Token: 0x040034F8 RID: 13560
		ZoomCameraAngularSpeedYaw,
		// Token: 0x040034F9 RID: 13561
		ZoomCameraAngularSpeedPitch,
		// Token: 0x040034FA RID: 13562
		ZoomWanderPitchAmplitude,
		// Token: 0x040034FB RID: 13563
		ZoomWanderPitchFrequency,
		// Token: 0x040034FC RID: 13564
		ZoomWanderSmoothingSpeed,
		// Token: 0x040034FD RID: 13565
		ZoomWanderYawAmplitude,
		// Token: 0x040034FE RID: 13566
		ZoomWanderYawFrequency,
		// Token: 0x040034FF RID: 13567
		EquipTime,
		// Token: 0x04003500 RID: 13568
		GrabTime,
		// Token: 0x04003501 RID: 13569
		PutDownTime,
		// Token: 0x04003502 RID: 13570
		TechLevel,
		// Token: 0x04003503 RID: 13571
		WeaponDamage,
		// Token: 0x04003504 RID: 13572
		WeaponElementalDamage,
		// Token: 0x04003505 RID: 13573
		ElementalType,
		// Token: 0x04003506 RID: 13574
		ElementalProcCoef,
		// Token: 0x04003507 RID: 13575
		ManufactureType,
		// Token: 0x04003508 RID: 13576
		HideMe,
		// Token: 0x04003509 RID: 13577
		ZoomWanderRadius,
		// Token: 0x0400350A RID: 13578
		ZoomWanderSpeed,
		// Token: 0x0400350B RID: 13579
		ZoomWanderAccel,
		// Token: 0x0400350C RID: 13580
		ZoomWanderDecel,
		// Token: 0x0400350D RID: 13581
		ZoomWanderAccelDistance,
		// Token: 0x0400350E RID: 13582
		ZoomWanderDecelDistance,
		// Token: 0x0400350F RID: 13583
		InnerAccuracyNormal,
		// Token: 0x04003510 RID: 13584
		InnerAccuracyZoom,
		// Token: 0x04003511 RID: 13585
		InnerAccuracyRatioNormal,
		// Token: 0x04003512 RID: 13586
		InnerAccuracyRatioZoom,
		// Token: 0x04003513 RID: 13587
		ScopeMaskType,
		// Token: 0x04003514 RID: 13588
		ScopeHudType,
		// Token: 0x04003515 RID: 13589
		RecoverTime,
		// Token: 0x04003516 RID: 13590
		ZoomRecoverTime,
		// Token: 0x04003517 RID: 13591
		CriticalHitScale,
		// Token: 0x04003518 RID: 13592
		WeaponDPS,
		// Token: 0x04003519 RID: 13593
		FireRateIncrease,
		// Token: 0x0400351A RID: 13594
		FireRateMax,
		// Token: 0x0400351B RID: 13595
		ZoomFiringBurst,
		// Token: 0x0400351C RID: 13596
		BurstFireRate,
		// Token: 0x0400351D RID: 13597
		DelayTimeAfterBurst,
		// Token: 0x0400351E RID: 13598
		MinDamageScale,
		// Token: 0x0400351F RID: 13599
		FireRange,
		// Token: 0x04003520 RID: 13600
		FireMaxRange,
		// Token: 0x04003521 RID: 13601
		RunSpeedModifier,
		// Token: 0x04003522 RID: 13602
		StandWalkSpeedModifier,
		// Token: 0x04003523 RID: 13603
		SprintSpeedModifier,
		// Token: 0x04003524 RID: 13604
		CrouchWalkSpeedModifier
	}
}
