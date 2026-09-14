using System;
using System.Collections.Generic;

// Token: 0x020000B9 RID: 185
public class AnimationPlayerRetrieveDroidState : PlayerAnimationState
{
	// Token: 0x0600044D RID: 1101 RVA: 0x0004A940 File Offset: 0x00048B40
	public AnimationPlayerRetrieveDroidState()
	{
		this.StateName = "PlayerRetrieveDroid";
		this.m_animDataDict.Add(AnimationPlayerRetrieveDroidState.EPosture.FullBody, new PlayerAnimationState.AnimData(0, "RetrieveDroidFull", MecanimAnimationID.ID_1st_RetrieveDroid, "bRetrieveDroidFull"));
		this.m_animDataDict.Add(AnimationPlayerRetrieveDroidState.EPosture.UpperBody, new PlayerAnimationState.AnimData(1, "RetrieveDroidUpper", MecanimAnimationID.ID_1st_RetrieveDroid, "bRetrieveDroidUpper"));
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x0004A9A8 File Offset: 0x00048BA8
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

	// Token: 0x0600044F RID: 1103 RVA: 0x0004AA1C File Offset: 0x00048C1C
	public override void vmethod_1()
	{
		PlayerAnimationState.AnimData animData = this.m_animDataDict[this.m_posture];
		float num = this.m_animInfoMgr.method_0(animData.m_tag, animData.m_layer);
		if (num >= 0.97f)
		{
			this.method_23();
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x00005E8B File Offset: 0x0000408B
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.method_23();
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x00005E99 File Offset: 0x00004099
	public void method_22(bool bool_1)
	{
		this.m_posture = ((!bool_1) ? AnimationPlayerRetrieveDroidState.EPosture.UpperBody : AnimationPlayerRetrieveDroidState.EPosture.FullBody);
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0004AA64 File Offset: 0x00048C64
	private void method_23()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, false);
	}

	// Token: 0x04000424 RID: 1060
	public float m_netLatency;

	// Token: 0x04000425 RID: 1061
	private AnimationPlayerRetrieveDroidState.EPosture m_posture;

	// Token: 0x04000426 RID: 1062
	private Dictionary<AnimationPlayerRetrieveDroidState.EPosture, PlayerAnimationState.AnimData> m_animDataDict = new Dictionary<AnimationPlayerRetrieveDroidState.EPosture, PlayerAnimationState.AnimData>();

	// Token: 0x020000BA RID: 186
	public enum EPosture
	{
		// Token: 0x04000428 RID: 1064
		FullBody,
		// Token: 0x04000429 RID: 1065
		UpperBody
	}
}
