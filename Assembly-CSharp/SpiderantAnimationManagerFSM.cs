using System;

// Token: 0x02000035 RID: 53
public class SpiderantAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000165 RID: 357 RVA: 0x00003B34 File Offset: 0x00001D34
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		this.m_bCanMoveTurn = true;
	}
}
