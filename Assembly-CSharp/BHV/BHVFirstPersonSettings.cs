using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x02000978 RID: 2424
	public class BHVFirstPersonSettings : BHVTaskSettings
	{
		// Token: 0x060043D8 RID: 17368 RVA: 0x0012F3B4 File Offset: 0x0012D5B4
		public BHVFirstPersonSettings()
		{
			this.m_gravityAcceleration = 0f;
			this.m_jumpHeight = 0f;
			this.m_crippleWalkSpeed = 1f;
			this.m_crouchWalkSpeed = 1.5f;
			this.m_standWalkSpeed = 2f;
			this.m_standRunSpeed = 4.5f;
			this.m_standSprintSpeed = 5.8f;
			this.m_velocityChangeGroundMax = 0f;
			this.m_velocityChangeAirMax = 0f;
			this.m_velocityFallMax = 0f;
			this.m_standHeight = 0f;
			this.m_crouchHeight = 0f;
			this.m_crouchDownSpeed = 0f;
			this.m_standUpSpeed = 0f;
			this.m_cameraAngularSpeedYaw = 0f;
			this.m_cameraAngularSpeedPitch = 0f;
			this.m_cameraAngleMaxPitch = 0f;
			this.m_cameraAngleMinPitch = 0f;
			this.m_FOVDefault = 0f;
			this.m_FOVSprintMultiplier = 0f;
			this.m_FOVDefaultToSprintTransitionSpeed = 0f;
			this.m_FOVSprintToDefaultTransitionSpeed = 0f;
			this.m_handsAngularSpeedMultiplierYaw = 0f;
			this.m_handsAngularSpeedEnterSpeedFactorYaw = 0f;
			this.m_handsAngularSpeedExitSpeedFactorYaw = 0f;
			this.m_handsAngularSpeedMultiplierPitch = 0f;
			this.m_handsAngularSpeedEnterSpeedFactorPitch = 0f;
			this.m_handsAngularSpeedExitSpeedFactorPitch = 0f;
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x060043D9 RID: 17369 RVA: 0x0002D180 File Offset: 0x0002B380
		// (set) Token: 0x060043DA RID: 17370 RVA: 0x0002D188 File Offset: 0x0002B388
		[DefaultValue(typeof(float), "0")]
		public float m_gravityAcceleration { get; set; }

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x060043DB RID: 17371 RVA: 0x0002D191 File Offset: 0x0002B391
		// (set) Token: 0x060043DC RID: 17372 RVA: 0x0002D199 File Offset: 0x0002B399
		[DefaultValue(typeof(float), "0")]
		public float m_jumpHeight { get; set; }

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x060043DD RID: 17373 RVA: 0x0002D1A2 File Offset: 0x0002B3A2
		// (set) Token: 0x060043DE RID: 17374 RVA: 0x0002D1AA File Offset: 0x0002B3AA
		[DefaultValue(typeof(float), "1")]
		public float m_crippleWalkSpeed { get; set; }

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x060043DF RID: 17375 RVA: 0x0002D1B3 File Offset: 0x0002B3B3
		// (set) Token: 0x060043E0 RID: 17376 RVA: 0x0002D1BB File Offset: 0x0002B3BB
		[DefaultValue(typeof(float), "1.5")]
		public float m_crouchWalkSpeed { get; set; }

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x060043E1 RID: 17377 RVA: 0x0002D1C4 File Offset: 0x0002B3C4
		// (set) Token: 0x060043E2 RID: 17378 RVA: 0x0002D1CC File Offset: 0x0002B3CC
		[DefaultValue(typeof(float), "2")]
		public float m_standWalkSpeed { get; set; }

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x060043E3 RID: 17379 RVA: 0x0002D1D5 File Offset: 0x0002B3D5
		// (set) Token: 0x060043E4 RID: 17380 RVA: 0x0002D1DD File Offset: 0x0002B3DD
		[DefaultValue(typeof(float), "4.5")]
		public float m_standRunSpeed { get; set; }

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x060043E5 RID: 17381 RVA: 0x0002D1E6 File Offset: 0x0002B3E6
		// (set) Token: 0x060043E6 RID: 17382 RVA: 0x0002D1EE File Offset: 0x0002B3EE
		[DefaultValue(typeof(float), "5.8")]
		public float m_standSprintSpeed { get; set; }

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x060043E7 RID: 17383 RVA: 0x0002D1F7 File Offset: 0x0002B3F7
		// (set) Token: 0x060043E8 RID: 17384 RVA: 0x0002D1FF File Offset: 0x0002B3FF
		[DefaultValue(typeof(float), "0")]
		public float m_velocityChangeGroundMax { get; set; }

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x060043E9 RID: 17385 RVA: 0x0002D208 File Offset: 0x0002B408
		// (set) Token: 0x060043EA RID: 17386 RVA: 0x0002D210 File Offset: 0x0002B410
		[DefaultValue(typeof(float), "0")]
		public float m_velocityChangeAirMax { get; set; }

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x060043EB RID: 17387 RVA: 0x0002D219 File Offset: 0x0002B419
		// (set) Token: 0x060043EC RID: 17388 RVA: 0x0002D221 File Offset: 0x0002B421
		[DefaultValue(typeof(float), "0")]
		public float m_velocityFallMax { get; set; }

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x060043ED RID: 17389 RVA: 0x0002D22A File Offset: 0x0002B42A
		// (set) Token: 0x060043EE RID: 17390 RVA: 0x0002D232 File Offset: 0x0002B432
		[DefaultValue(typeof(float), "0")]
		public float m_standHeight { get; set; }

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x060043EF RID: 17391 RVA: 0x0002D23B File Offset: 0x0002B43B
		// (set) Token: 0x060043F0 RID: 17392 RVA: 0x0002D243 File Offset: 0x0002B443
		[DefaultValue(typeof(float), "0")]
		public float m_crouchHeight { get; set; }

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x060043F1 RID: 17393 RVA: 0x0002D24C File Offset: 0x0002B44C
		// (set) Token: 0x060043F2 RID: 17394 RVA: 0x0002D254 File Offset: 0x0002B454
		[DefaultValue(typeof(float), "0")]
		public float m_crouchDownSpeed { get; set; }

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x060043F3 RID: 17395 RVA: 0x0002D25D File Offset: 0x0002B45D
		// (set) Token: 0x060043F4 RID: 17396 RVA: 0x0002D265 File Offset: 0x0002B465
		[DefaultValue(typeof(float), "0")]
		public float m_standUpSpeed { get; set; }

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x060043F5 RID: 17397 RVA: 0x0002D26E File Offset: 0x0002B46E
		// (set) Token: 0x060043F6 RID: 17398 RVA: 0x0002D276 File Offset: 0x0002B476
		[DefaultValue(typeof(float), "0")]
		public float m_cameraAngularSpeedYaw { get; set; }

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x060043F7 RID: 17399 RVA: 0x0002D27F File Offset: 0x0002B47F
		// (set) Token: 0x060043F8 RID: 17400 RVA: 0x0002D287 File Offset: 0x0002B487
		[DefaultValue(typeof(float), "0")]
		public float m_cameraAngularSpeedPitch { get; set; }

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x060043F9 RID: 17401 RVA: 0x0002D290 File Offset: 0x0002B490
		// (set) Token: 0x060043FA RID: 17402 RVA: 0x0002D298 File Offset: 0x0002B498
		[DefaultValue(typeof(float), "0")]
		public float m_cameraAngleMaxPitch { get; set; }

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x060043FB RID: 17403 RVA: 0x0002D2A1 File Offset: 0x0002B4A1
		// (set) Token: 0x060043FC RID: 17404 RVA: 0x0002D2A9 File Offset: 0x0002B4A9
		[DefaultValue(typeof(float), "0")]
		public float m_cameraAngleMinPitch { get; set; }

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x060043FD RID: 17405 RVA: 0x0002D2B2 File Offset: 0x0002B4B2
		// (set) Token: 0x060043FE RID: 17406 RVA: 0x0002D2BA File Offset: 0x0002B4BA
		[DefaultValue(typeof(float), "0")]
		public float m_FOVDefault { get; set; }

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x060043FF RID: 17407 RVA: 0x0002D2C3 File Offset: 0x0002B4C3
		// (set) Token: 0x06004400 RID: 17408 RVA: 0x0002D2CB File Offset: 0x0002B4CB
		[DefaultValue(typeof(float), "0")]
		public float m_FOVSprintMultiplier { get; set; }

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06004401 RID: 17409 RVA: 0x0002D2D4 File Offset: 0x0002B4D4
		// (set) Token: 0x06004402 RID: 17410 RVA: 0x0002D2DC File Offset: 0x0002B4DC
		[DefaultValue(typeof(float), "0")]
		public float m_FOVDefaultToSprintTransitionSpeed { get; set; }

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06004403 RID: 17411 RVA: 0x0002D2E5 File Offset: 0x0002B4E5
		// (set) Token: 0x06004404 RID: 17412 RVA: 0x0002D2ED File Offset: 0x0002B4ED
		[DefaultValue(typeof(float), "0")]
		public float m_FOVSprintToDefaultTransitionSpeed { get; set; }

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06004405 RID: 17413 RVA: 0x0002D2F6 File Offset: 0x0002B4F6
		// (set) Token: 0x06004406 RID: 17414 RVA: 0x0002D2FE File Offset: 0x0002B4FE
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedMultiplierYaw { get; set; }

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06004407 RID: 17415 RVA: 0x0002D307 File Offset: 0x0002B507
		// (set) Token: 0x06004408 RID: 17416 RVA: 0x0002D30F File Offset: 0x0002B50F
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedEnterSpeedFactorYaw { get; set; }

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06004409 RID: 17417 RVA: 0x0002D318 File Offset: 0x0002B518
		// (set) Token: 0x0600440A RID: 17418 RVA: 0x0002D320 File Offset: 0x0002B520
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedExitSpeedFactorYaw { get; set; }

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x0600440B RID: 17419 RVA: 0x0002D329 File Offset: 0x0002B529
		// (set) Token: 0x0600440C RID: 17420 RVA: 0x0002D331 File Offset: 0x0002B531
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedMultiplierPitch { get; set; }

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x0600440D RID: 17421 RVA: 0x0002D33A File Offset: 0x0002B53A
		// (set) Token: 0x0600440E RID: 17422 RVA: 0x0002D342 File Offset: 0x0002B542
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedEnterSpeedFactorPitch { get; set; }

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x0600440F RID: 17423 RVA: 0x0002D34B File Offset: 0x0002B54B
		// (set) Token: 0x06004410 RID: 17424 RVA: 0x0002D353 File Offset: 0x0002B553
		[DefaultValue(typeof(float), "0")]
		public float m_handsAngularSpeedExitSpeedFactorPitch { get; set; }

		// Token: 0x04002EE5 RID: 12005
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002EE6 RID: 12006
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002EE7 RID: 12007
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002EE8 RID: 12008
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002EE9 RID: 12009
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002EEA RID: 12010
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002EEB RID: 12011
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002EEC RID: 12012
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002EED RID: 12013
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002EEE RID: 12014
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002EEF RID: 12015
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002EF0 RID: 12016
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002EF1 RID: 12017
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002EF2 RID: 12018
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002EF3 RID: 12019
		[CompilerGenerated]
		private float float_14;

		// Token: 0x04002EF4 RID: 12020
		[CompilerGenerated]
		private float float_15;

		// Token: 0x04002EF5 RID: 12021
		[CompilerGenerated]
		private float float_16;

		// Token: 0x04002EF6 RID: 12022
		[CompilerGenerated]
		private float float_17;

		// Token: 0x04002EF7 RID: 12023
		[CompilerGenerated]
		private float float_18;

		// Token: 0x04002EF8 RID: 12024
		[CompilerGenerated]
		private float float_19;

		// Token: 0x04002EF9 RID: 12025
		[CompilerGenerated]
		private float float_20;

		// Token: 0x04002EFA RID: 12026
		[CompilerGenerated]
		private float float_21;

		// Token: 0x04002EFB RID: 12027
		[CompilerGenerated]
		private float float_22;

		// Token: 0x04002EFC RID: 12028
		[CompilerGenerated]
		private float float_23;

		// Token: 0x04002EFD RID: 12029
		[CompilerGenerated]
		private float float_24;

		// Token: 0x04002EFE RID: 12030
		[CompilerGenerated]
		private float float_25;

		// Token: 0x04002EFF RID: 12031
		[CompilerGenerated]
		private float float_26;

		// Token: 0x04002F00 RID: 12032
		[CompilerGenerated]
		private float float_27;
	}
}
