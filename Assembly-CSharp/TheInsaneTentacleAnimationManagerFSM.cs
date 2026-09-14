using System;

// Token: 0x02000039 RID: 57
public class TheInsaneTentacleAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000176 RID: 374 RVA: 0x00003BCF File Offset: 0x00001DCF
	public override void Start()
	{
		base.Start();
		this.m_deathLayer = 1;
		this.m_isHumanoid = false;
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
	}
}
