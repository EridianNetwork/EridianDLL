using System;

// Token: 0x020004B3 RID: 1203
public enum PlayerAction
{
	// Token: 0x040014F5 RID: 5365
	Move = 1,
	// Token: 0x040014F6 RID: 5366
	Run,
	// Token: 0x040014F7 RID: 5367
	Jump = 4,
	// Token: 0x040014F8 RID: 5368
	Crouch = 8,
	// Token: 0x040014F9 RID: 5369
	Melee = 16,
	// Token: 0x040014FA RID: 5370
	Interact = 32,
	// Token: 0x040014FB RID: 5371
	SwitchWeapon = 64,
	// Token: 0x040014FC RID: 5372
	Fire = 128,
	// Token: 0x040014FD RID: 5373
	ReloadWeapon = 256,
	// Token: 0x040014FE RID: 5374
	Aim = 512,
	// Token: 0x040014FF RID: 5375
	LaunchSkill = 1024,
	// Token: 0x04001500 RID: 5376
	ThrowGrenade = 2048,
	// Token: 0x04001501 RID: 5377
	AccessInventory = 4096
}
