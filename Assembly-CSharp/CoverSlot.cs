using System;
using Core;
using UnityEngine;

// Token: 0x02000441 RID: 1089
[Serializable]
public class CoverSlot : Slot
{
	// Token: 0x06001AE4 RID: 6884 RVA: 0x0001388D File Offset: 0x00011A8D
	public CoverSlot()
	{
		this.m_coverHeight = CoverSlot.CoverHeight.LOW;
		this.m_coverDepth = CoverSlot.CoverDepth.LARGE;
		this.m_coverDirections = CoverSlot.CoverDirections.CENTER;
		this.m_coverRadius = this.method_5(CoverSlot.CoverDirectionMask.CENTER);
		this.m_isLocked = false;
	}

	// Token: 0x06001AE5 RID: 6885 RVA: 0x000138BE File Offset: 0x00011ABE
	public override SlotContainer vmethod_0()
	{
		return this.m_container;
	}

	// Token: 0x06001AE6 RID: 6886 RVA: 0x000138C6 File Offset: 0x00011AC6
	public override void vmethod_1(SlotContainer slotContainer_0)
	{
		this.m_container = (CoverContainer)slotContainer_0;
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x00088F54 File Offset: 0x00087154
	public float method_5(CoverSlot.CoverDirectionMask coverDirectionMask_0)
	{
		switch (coverDirectionMask_0)
		{
		case CoverSlot.CoverDirectionMask.LEFT:
		case CoverSlot.CoverDirectionMask.RIGHT:
			return 0.7f;
		case CoverSlot.CoverDirectionMask.CENTER:
			return 0.6f;
		}
		DebugUtils.LogError(LogCategory.AI, "Invalid Cover Direction");
		return 0f;
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x00088F9C File Offset: 0x0008719C
	public float method_6()
	{
		CoverSlot.CoverHeight coverHeight = this.m_coverHeight;
		if (coverHeight == CoverSlot.CoverHeight.LOW)
		{
			return 1f;
		}
		if (coverHeight != CoverSlot.CoverHeight.HIGH)
		{
			DebugUtils.LogError(LogCategory.AI, "Invalid Cover Height");
			return 0f;
		}
		return 2f;
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x00088FD4 File Offset: 0x000871D4
	public float method_7()
	{
		CoverSlot.CoverDepth coverDepth = this.m_coverDepth;
		switch (coverDepth + 1)
		{
		case CoverSlot.CoverDepth.NARROW:
			return -1f;
		case CoverSlot.CoverDepth.LARGE:
			return 0.5f;
		case (CoverSlot.CoverDepth)2:
			return 1.15f;
		default:
			DebugUtils.LogError(LogCategory.AI, "Invalid Cover Depth");
			return 0f;
		}
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x000138D4 File Offset: 0x00011AD4
	public void method_8()
	{
		this.m_isLocked = true;
	}

	// Token: 0x06001AEB RID: 6891 RVA: 0x000138DD File Offset: 0x00011ADD
	public void method_9()
	{
		this.m_isLocked = false;
	}

	// Token: 0x06001AEC RID: 6892 RVA: 0x000138E6 File Offset: 0x00011AE6
	public bool method_10(CoverSlot.CoverDirectionMask coverDirectionMask_0)
	{
		return (this.m_coverDirections & (CoverSlot.CoverDirections)coverDirectionMask_0) != CoverSlot.CoverDirections.NONE;
	}

	// Token: 0x06001AED RID: 6893 RVA: 0x00003C2E File Offset: 0x00001E2E
	public bool method_11(Vector3 vector3_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06001AEE RID: 6894 RVA: 0x00089020 File Offset: 0x00087220
	public override object Clone()
	{
		return (CoverSlot)base.MemberwiseClone();
	}

	// Token: 0x040011B0 RID: 4528
	public CoverSlot.CoverHeight m_coverHeight;

	// Token: 0x040011B1 RID: 4529
	public CoverSlot.CoverDepth m_coverDepth;

	// Token: 0x040011B2 RID: 4530
	public CoverSlot.CoverDirections m_coverDirections;

	// Token: 0x040011B3 RID: 4531
	public float m_coverRadius;

	// Token: 0x040011B4 RID: 4532
	public bool m_isLocked;

	// Token: 0x040011B5 RID: 4533
	[HideInInspector]
	public CoverContainer m_container;

	// Token: 0x02000442 RID: 1090
	public enum CoverHeight
	{
		// Token: 0x040011B7 RID: 4535
		INVALID = -1,
		// Token: 0x040011B8 RID: 4536
		LOW,
		// Token: 0x040011B9 RID: 4537
		HIGH
	}

	// Token: 0x02000443 RID: 1091
	public enum CoverDirectionMask
	{
		// Token: 0x040011BB RID: 4539
		LEFT = 1,
		// Token: 0x040011BC RID: 4540
		CENTER,
		// Token: 0x040011BD RID: 4541
		RIGHT = 4
	}

	// Token: 0x02000444 RID: 1092
	public enum CoverDirections
	{
		// Token: 0x040011BF RID: 4543
		INVALID = -1,
		// Token: 0x040011C0 RID: 4544
		NONE,
		// Token: 0x040011C1 RID: 4545
		LEFT,
		// Token: 0x040011C2 RID: 4546
		CENTER,
		// Token: 0x040011C3 RID: 4547
		RIGHT = 4,
		// Token: 0x040011C4 RID: 4548
		LEFT_CENTER = 3,
		// Token: 0x040011C5 RID: 4549
		LEFT_RIGHT = 5,
		// Token: 0x040011C6 RID: 4550
		RIGHT_CENTER,
		// Token: 0x040011C7 RID: 4551
		ALL
	}

	// Token: 0x02000445 RID: 1093
	public enum CoverDepth
	{
		// Token: 0x040011C9 RID: 4553
		INVALID = -1,
		// Token: 0x040011CA RID: 4554
		NARROW,
		// Token: 0x040011CB RID: 4555
		LARGE
	}
}
