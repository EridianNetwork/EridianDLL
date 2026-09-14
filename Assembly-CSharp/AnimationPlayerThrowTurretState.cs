using System;
using System.Collections.Generic;

// Token: 0x020000C2 RID: 194
public class AnimationPlayerThrowTurretState : PlayerAnimationState
{
	// Token: 0x06000475 RID: 1141 RVA: 0x0004AE24 File Offset: 0x00049024
	public AnimationPlayerThrowTurretState()
	{
		this.StateName = "PlayerThrowTurret";
		this.m_animDataDict.Add(AnimationPlayerThrowTurretState.EPosture.FullBodyLong, new PlayerAnimationState.AnimData(0, "ThrowTurretLongFull", MecanimAnimationID.ID_1st_ThrowTurretLong, "bThrowTurretLongFull"));
		this.m_animDataDict.Add(AnimationPlayerThrowTurretState.EPosture.FullBodyNear, new PlayerAnimationState.AnimData(0, "ThrowTurretNearFull", MecanimAnimationID.ID_1st_ThrowTurretNear, "bThrowTurretNearFull"));
		this.m_animDataDict.Add(AnimationPlayerThrowTurretState.EPosture.UpperBodyLong, new PlayerAnimationState.AnimData(1, "ThrowTurretLongUpper", MecanimAnimationID.ID_1st_ThrowTurretLong, "bThrowTurretLongUpper"));
		this.m_animDataDict.Add(AnimationPlayerThrowTurretState.EPosture.UpperBodyNear, new PlayerAnimationState.AnimData(1, "ThrowTurretNearUpper", MecanimAnimationID.ID_1st_ThrowTurretNear, "bThrowTurretNearUpper"));
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0004AECC File Offset: 0x000490CC
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_stateTag = this.m_animDataDict[this.m_posture].m_tag;
		this.m_layer = this.m_animDataDict[this.m_posture].m_layer;
		if (base.Boolean_0)
		{
			base.method_7(this.m_animDataDict[this.m_posture].m_param_1st);
		}
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, true);
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0000613F File Offset: 0x0000433F
	public override void vmethod_4()
	{
		base.vmethod_4();
		this.m_networkCompensationPer = this.m_netLatency;
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x00006153 File Offset: 0x00004353
	public void method_22(bool bool_1, bool bool_2)
	{
		if (bool_1 && bool_2)
		{
			this.m_posture = AnimationPlayerThrowTurretState.EPosture.FullBodyLong;
		}
		else if (bool_1 && !bool_2)
		{
			this.m_posture = AnimationPlayerThrowTurretState.EPosture.FullBodyNear;
		}
		else if (!bool_1 && bool_2)
		{
			this.m_posture = AnimationPlayerThrowTurretState.EPosture.UpperBodyLong;
		}
		else if (!bool_1 && !bool_2)
		{
			this.m_posture = AnimationPlayerThrowTurretState.EPosture.UpperBodyNear;
		}
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0004AF6C File Offset: 0x0004916C
	protected override void OnAnimationTimeElapsed(string state)
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16(this.m_animDataDict[this.m_posture].m_param_3rd, false);
	}

	// Token: 0x04000448 RID: 1096
	public float m_netLatency;

	// Token: 0x04000449 RID: 1097
	private AnimationPlayerThrowTurretState.EPosture m_posture = AnimationPlayerThrowTurretState.EPosture.UpperBodyNear;

	// Token: 0x0400044A RID: 1098
	private Dictionary<AnimationPlayerThrowTurretState.EPosture, PlayerAnimationState.AnimData> m_animDataDict = new Dictionary<AnimationPlayerThrowTurretState.EPosture, PlayerAnimationState.AnimData>();

	// Token: 0x020000C3 RID: 195
	public enum EPosture
	{
		// Token: 0x0400044C RID: 1100
		FullBodyLong,
		// Token: 0x0400044D RID: 1101
		UpperBodyLong,
		// Token: 0x0400044E RID: 1102
		FullBodyNear,
		// Token: 0x0400044F RID: 1103
		UpperBodyNear
	}
}
