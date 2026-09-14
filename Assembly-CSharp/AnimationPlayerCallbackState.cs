using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class AnimationPlayerCallbackState : PlayerAnimationState
{
	// Token: 0x060003E4 RID: 996 RVA: 0x0000578B File Offset: 0x0000398B
	public AnimationPlayerCallbackState()
	{
		this.StateName = "PlayerCallback";
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0000579E File Offset: 0x0000399E
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_bFirstTickInTag = false;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_Callback);
		}
		base.method_16("bCallback", true);
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x000057D1 File Offset: 0x000039D1
	public override void vmethod_1()
	{
		this.method_22();
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x000490EC File Offset: 0x000472EC
	private void method_22()
	{
		this.m_animatorInfo = base.method_15(false, 1);
		if (!this.m_animatorInfo.IsTag("Callback"))
		{
			return;
		}
		if (!this.m_bFirstTickInTag)
		{
			this.m_bFirstTickInTag = true;
			this.m_startTime = Time.time;
			this.m_length_anim = this.m_animatorInfo.length;
		}
		if (this.method_23(0.97f))
		{
			base.m_status = AnimationStatus.SUCCESS;
			base.method_16("bCallback", false);
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x000057D9 File Offset: 0x000039D9
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bCallback", false);
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x000057F5 File Offset: 0x000039F5
	private bool method_23(float float_2)
	{
		return Time.time - this.m_startTime > this.m_length_anim * float_2;
	}

	// Token: 0x040003C8 RID: 968
	private const string m_tag = "Callback";

	// Token: 0x040003C9 RID: 969
	public float m_netLantency;

	// Token: 0x040003CA RID: 970
	private bool m_bFirstTickInTag;

	// Token: 0x040003CB RID: 971
	private float m_startTime;

	// Token: 0x040003CC RID: 972
	private float m_length_anim;
}
