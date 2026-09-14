using System;
using ns0;
using UnityEngine;

// Token: 0x02000075 RID: 117
public class AnimationSuicideBombState : AnimationManagerState, InstantiateManager.InstanciationClient
{
	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000275 RID: 629 RVA: 0x00004699 File Offset: 0x00002899
	// (set) Token: 0x06000276 RID: 630 RVA: 0x000046A1 File Offset: 0x000028A1
	public float Single_0
	{
		get
		{
			return this.m_fuzeDuration;
		}
		set
		{
			this.m_fuzeDuration = value;
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00040CDC File Offset: 0x0003EEDC
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_entity = this.m_AnimationManagerFSM.gameObject.GetComponent<Entity>();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSuicideBomb", true);
		if (this.m_fuzeDuration < 0f)
		{
			this.m_fuzeDuration = 0f;
		}
		base.m_status = AnimationStatus.RUNNING;
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		this.m_bombStep = EAnimationSuicideBombStep.BombStart;
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00040D58 File Offset: 0x0003EF58
	private void method_4()
	{
		InstantiateManager.SpawnRequest spawnRequest = default(InstantiateManager.SpawnRequest);
		spawnRequest.m_prefabName = "Entities/Object/Weapon/WPN_Grenade_NPC";
		spawnRequest.m_position = this.m_AnimationManagerFSM.m_weaponHolder.position;
		spawnRequest.m_rotation = Quaternion.identity;
		spawnRequest.m_group = InstantiateManager.NetworkReplicationGroup.InGame;
		spawnRequest.m_spawnData = new object[1];
		spawnRequest.m_spawnData[0] = this.m_entity.vmethod_0();
		spawnRequest.m_callbackData = null;
		spawnRequest.m_isNetworkInstanciate = true;
		spawnRequest.m_caller = this;
		MonoSingleton<AppManager>.Instance.GetComponent<InstantiateManager>().method_0(spawnRequest);
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00040DF4 File Offset: 0x0003EFF4
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
		EntityObject component = instance.GetComponent<EntityObject>();
		if (component != null)
		{
			component.method_15(null);
		}
	}

	// Token: 0x0600027A RID: 634 RVA: 0x00040E18 File Offset: 0x0003F018
	public override void vmethod_1()
	{
		if (this.m_bombStep == EAnimationSuicideBombStep.BombStart)
		{
			if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("BombIdle"))
			{
				this.m_bombStep = EAnimationSuicideBombStep.BombIdle;
			}
		}
		else if (this.m_bombStep == EAnimationSuicideBombStep.BombIdle)
		{
			if (this.m_fuzeDuration > 0f)
			{
				this.m_fuzeDuration -= Time.deltaTime;
			}
			else
			{
				this.m_bombStep = EAnimationSuicideBombStep.BombExplode;
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsDying", true);
			}
		}
		else if (this.m_bombStep == EAnimationSuicideBombStep.BombExplode)
		{
			base.m_status = AnimationStatus.SUCCESS;
		}
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00040EB0 File Offset: 0x0003F0B0
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsDying", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSuicideBomb", false);
		this.m_AnimationManagerFSM.m_bPlayNormalDeathAnim = true;
	}

	// Token: 0x04000250 RID: 592
	private const string BOMBSTART_TAG = "BombStart";

	// Token: 0x04000251 RID: 593
	private const string BOMBIDLE_TAG = "BombIdle";

	// Token: 0x04000252 RID: 594
	public EAnimationSuicideBombStep m_bombStep;

	// Token: 0x04000253 RID: 595
	public float m_fuzeDuration;

	// Token: 0x04000254 RID: 596
	private Entity m_entity;
}
