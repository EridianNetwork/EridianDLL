using System;

// Token: 0x02000033 RID: 51
public class SkagZillaAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600015C RID: 348 RVA: 0x0003BF40 File Offset: 0x0003A140
	public override void Start()
	{
		base.Start();
		this.m_isHumanoid = false;
		this.m_canUseFacingLogic = false;
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_animEventHandlerList.Add("JumpOnSpotHit", new AnimationManagerFSM.OnAnimEventHandler(this.method_31));
		this.m_deathLayer = 1;
		this.m_bCanMoveTurn = true;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0003BFA8 File Offset: 0x0003A1A8
	public void method_31()
	{
		AnimationJumpOnSpotState animationJumpOnSpotState = base.method_16(AnimationStateFSM.JumpOnSpot.ToString()) as AnimationJumpOnSpotState;
		if (animationJumpOnSpotState != null)
		{
			animationJumpOnSpotState.m_jumpOnSpotHit = true;
		}
	}
}
