using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class RakkAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600014F RID: 335 RVA: 0x00003A59 File Offset: 0x00001C59
	public override void Start()
	{
		base.Start();
		this.m_isHumanoid = false;
		this.m_canUseFacingLogic = false;
		this.m_deathLayer = 2;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0000375F File Offset: 0x0000195F
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0003BC94 File Offset: 0x00039E94
	public override void LateUpdate()
	{
		if (this.m_animationHost == null)
		{
			return;
		}
		if (this.m_animationStateMachine.m_curState != null)
		{
			((AnimationManagerState)this.m_animationStateMachine.m_curState).FixedUpdate();
			Vector3 vector = this.m_animationHost.transform.localPosition * this.m_modelScale;
			Vector3 vector2 = base.transform.position + base.transform.rotation * vector;
			if (this.m_validateNextMovePosition && this.m_entity != null && this.m_entity.vmethod_11() != null)
			{
				AIServicePathfinding.AIServicePathfinding_0.method_10(this.m_entity.vmethod_11(), vector2, out vector2);
			}
			base.transform.position = vector2;
			this.m_animationHost.transform.localPosition = Vector3.zero;
			base.transform.forward = this.m_animationHost.transform.forward;
			this.m_animationHost.transform.localRotation = Quaternion.identity;
		}
	}
}
