using System;

// Token: 0x0200002E RID: 46
public class MidgetShotgunnerAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x0600012F RID: 303 RVA: 0x0003B2A4 File Offset: 0x000394A4
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = true;
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
			this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00003816 File Offset: 0x00001A16
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x06000131 RID: 305 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x000398CC File Offset: 0x00037ACC
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = this.m_entity.vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
		}
	}

	// Token: 0x04000135 RID: 309
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x04000136 RID: 310
	public float m_lastShotSoundTime;
}
