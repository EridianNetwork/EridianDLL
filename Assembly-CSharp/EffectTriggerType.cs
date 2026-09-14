using System;

// Token: 0x02000B4C RID: 2892
[Flags]
public enum EffectTriggerType
{
	// Token: 0x04003AEB RID: 15083
	Start = 1,
	// Token: 0x04003AEC RID: 15084
	Destroy = 2,
	// Token: 0x04003AED RID: 15085
	Update = 4,
	// Token: 0x04003AEE RID: 15086
	Enable = 8,
	// Token: 0x04003AEF RID: 15087
	Disable = 16,
	// Token: 0x04003AF0 RID: 15088
	TriggerEnter = 32,
	// Token: 0x04003AF1 RID: 15089
	TriggerExit = 64,
	// Token: 0x04003AF2 RID: 15090
	CollisionEnter = 128,
	// Token: 0x04003AF3 RID: 15091
	CollisionExit = 256,
	// Token: 0x04003AF4 RID: 15092
	MouseUp = 512,
	// Token: 0x04003AF5 RID: 15093
	MouseDown = 1024,
	// Token: 0x04003AF6 RID: 15094
	TriggerOnUpdate = 2048,
	// Token: 0x04003AF7 RID: 15095
	KeyDown = 4096
}
