using System;
using System.Collections.Generic;

// Token: 0x020000BB RID: 187
public class AnimationPlayerRetrieveTurretState : PlayerAnimationState
{
	// Token: 0x06000453 RID: 1107 RVA: 0x0004AA9C File Offset: 0x00048C9C
	public AnimationPlayerRetrieveTurretState()
	{
		this.StateName = "PlayerRetrieveTurret";
		this.m_animDataDict.Add(AnimationPlayerRetrieveTurretState.EPosture.FullBody, new PlayerAnimationState.AnimData(0, "RetrieveTurretFull", MecanimAnimationID.ID_1st_RetrieveTurret, "bRetrieveTurretFull"));
		this.m_animDataDict.Add(AnimationPlayerRetrieveTurretState.EPosture.UpperBody, new PlayerAnimationState.AnimData(1, "RetrieveTurretUpper", MecanimAnimationID.ID_1st_RetrieveTurret, "bRetrieveTurretUpper"));
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0004AB08 File Offset: 0x00048D08
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

	// Token: 0x06000455 RID: 1109 RVA: 0x0004AB7C File Offset: 0x00048D7C
	public override void vmethod_1()
	{
		PlayerAnimationState.AnimData animData = this.m_animDataDict[this.m_posture];
		float num = this.m_animInfoMgr.method_0(animData.m_tag, animData.m_layer);
		if (num >= 0.97f)
		{
			this.method_23();
		}
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x00005EA8 File Offset: 0x000040A8
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.method_23();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x00005EB6 File Offset: 0x000040B6
	public void method_22(bool bool_1)
	{
		this.m_posture = ((!bool_1) ? AnimationPlayerRetrieveTurretState.EPosture.UpperBody : AnimationPlayerRetrieveTurretState.EPosture.FullBody);
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0004ABC4 File Offset: 0x00048DC4
	private void method_23()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, false);
	}

	// Token: 0x0400042A RID: 1066
	public float m_netLatency;

	// Token: 0x0400042B RID: 1067
	private AnimationPlayerRetrieveTurretState.EPosture m_posture = AnimationPlayerRetrieveTurretState.EPosture.UpperBody;

	// Token: 0x0400042C RID: 1068
	private Dictionary<AnimationPlayerRetrieveTurretState.EPosture, PlayerAnimationState.AnimData> m_animDataDict = new Dictionary<AnimationPlayerRetrieveTurretState.EPosture, PlayerAnimationState.AnimData>();

	// Token: 0x020000BC RID: 188
	public enum EPosture
	{
		// Token: 0x0400042E RID: 1070
		FullBody,
		// Token: 0x0400042F RID: 1071
		UpperBody
	}
}
