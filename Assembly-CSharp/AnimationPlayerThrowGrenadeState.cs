using System;

// Token: 0x020000C0 RID: 192
public class AnimationPlayerThrowGrenadeState : PlayerAnimationState
{
	// Token: 0x0600046B RID: 1131 RVA: 0x000060B0 File Offset: 0x000042B0
	public AnimationPlayerThrowGrenadeState()
	{
		this.StateName = "PlayerThrowGrenade";
		this.m_stateTag = "ThrowGrenade";
		this.m_layer = 1;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0004ADD4 File Offset: 0x00048FD4
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_ThrowGrenade);
		}
		base.method_16("bThrowGrenade", true);
		base.method_4(new PlayerAnimationState.AnimationStateEventCallBack(this.OnGrenadeOffHand), 0.4f);
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x000060D5 File Offset: 0x000042D5
	public override void vmethod_4()
	{
		base.vmethod_4();
		this.m_networkCompensationPer = this.NetworkLatency;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x000060E9 File Offset: 0x000042E9
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.method_5(new PlayerAnimationState.AnimationStateEventCallBack(this.OnGrenadeOffHand), 0.4f);
		base.method_16("bThrowGrenade", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0000611C File Offset: 0x0000431C
	private void OnGrenadeOffHand(string state)
	{
		this.m_spawnGrenadeDelegate();
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00006129 File Offset: 0x00004329
	protected override void OnAnimationTimeElapsed(string state)
	{
		base.method_16("bThrowGrenade", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000443 RID: 1091
	private const string THROWGRENADE_TAG = "ThrowGrenade";

	// Token: 0x04000444 RID: 1092
	public bool m_throwStartedFirst;

	// Token: 0x04000445 RID: 1093
	public bool m_throwStartedThird;

	// Token: 0x04000446 RID: 1094
	public float NetworkLatency;

	// Token: 0x04000447 RID: 1095
	public AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate m_spawnGrenadeDelegate;

	// Token: 0x020000C1 RID: 193
	// (Invoke) Token: 0x06000472 RID: 1138
	public delegate void SpawnGrenadeDelegate();
}
