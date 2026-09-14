using System;

// Token: 0x02000302 RID: 770
public class InvestedSkill
{
	// Token: 0x060011F2 RID: 4594 RVA: 0x0000E21E File Offset: 0x0000C41E
	public InvestedSkill(int int_0, int int_1)
	{
		this.mId = int_0;
		this.mGrade = int_1;
	}

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0000E234 File Offset: 0x0000C434
	public int Int32_0
	{
		get
		{
			return this.mId;
		}
	}

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x060011F5 RID: 4597 RVA: 0x0000E245 File Offset: 0x0000C445
	// (set) Token: 0x060011F4 RID: 4596 RVA: 0x0000E23C File Offset: 0x0000C43C
	public int Int32_1
	{
		get
		{
			return this.mGrade;
		}
		set
		{
			this.mGrade = value;
		}
	}

	// Token: 0x04000E0D RID: 3597
	private int mId;

	// Token: 0x04000E0E RID: 3598
	private int mGrade;
}
