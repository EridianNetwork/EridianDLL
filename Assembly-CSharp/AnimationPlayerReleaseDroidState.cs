using System;
using System.Collections.Generic;

// Token: 0x020000B6 RID: 182
public class AnimationPlayerReleaseDroidState : PlayerAnimationState
{
	// Token: 0x06000441 RID: 1089 RVA: 0x0004A614 File Offset: 0x00048814
	public AnimationPlayerReleaseDroidState()
	{
		this.StateName = "PlayerReleaseDroid";
		this.m_animDataDict.Add(AnimationPlayerReleaseDroidState.EPosture.FullBody, new PlayerAnimationState.AnimData(0, "ReleaseDroidFull", MecanimAnimationID.ID_1st_ReleaseDroid, "bReleaseDroidFull"));
		this.m_animDataDict.Add(AnimationPlayerReleaseDroidState.EPosture.UpperBody, new PlayerAnimationState.AnimData(1, "ReleaseDroidUpper", MecanimAnimationID.ID_1st_ReleaseDroid, "bReleaseDroidUpper"));
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0004A67C File Offset: 0x0004887C
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_animInfoMgr.Reset(this.m_netLatency);
		if (base.Boolean_0)
		{
			base.method_7(this.m_animDataDict[this.m_posture].m_param_1st);
		}
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, true);
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0004A6F0 File Offset: 0x000488F0
	public override void vmethod_1()
	{
		PlayerAnimationState.AnimData animData = this.m_animDataDict[this.m_posture];
		float num = this.m_animInfoMgr.method_0(animData.m_tag, animData.m_layer);
		if (num >= 0.97f)
		{
			this.method_23();
		}
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x00005DDA File Offset: 0x00003FDA
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.method_23();
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x00005DE8 File Offset: 0x00003FE8
	public void method_22(bool bool_1)
	{
		this.m_posture = ((!bool_1) ? AnimationPlayerReleaseDroidState.EPosture.UpperBody : AnimationPlayerReleaseDroidState.EPosture.FullBody);
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0004A738 File Offset: 0x00048938
	private void method_23()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, false);
	}

	// Token: 0x04000416 RID: 1046
	public float m_netLatency;

	// Token: 0x04000417 RID: 1047
	private AnimationPlayerReleaseDroidState.EPosture m_posture;

	// Token: 0x04000418 RID: 1048
	private Dictionary<AnimationPlayerReleaseDroidState.EPosture, PlayerAnimationState.AnimData> m_animDataDict = new Dictionary<AnimationPlayerReleaseDroidState.EPosture, PlayerAnimationState.AnimData>();

	// Token: 0x020000B7 RID: 183
	public enum EPosture
	{
		// Token: 0x0400041A RID: 1050
		FullBody,
		// Token: 0x0400041B RID: 1051
		UpperBody
	}
}
