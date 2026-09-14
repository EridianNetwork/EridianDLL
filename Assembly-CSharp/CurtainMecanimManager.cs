using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class CurtainMecanimManager : MonoBehaviour
{
	// Token: 0x060002AF RID: 687 RVA: 0x00042188 File Offset: 0x00040388
	private void Start()
	{
		this.m_curtainAnimator = base.GetComponent<Animator>();
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			if (transform.name.ToLower().Contains("cube"))
			{
				CurtainTriggerHelper curtainTriggerHelper = transform.gameObject.AddComponent<CurtainTriggerHelper>();
				curtainTriggerHelper.m_curtainManager = this;
				break;
			}
		}
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00042214 File Offset: 0x00040414
	private void Update()
	{
		if (this.m_foundNPC)
		{
			this.method_0();
		}
		if (this.m_liftStarted)
		{
			this.m_enableLift = false;
			this.m_needUpdate = true;
		}
		this.m_liftStarted = this.m_enableLift;
		if (this.m_curtainAnimator != null && this.m_needUpdate)
		{
			this.m_curtainAnimator.SetBool("IsLifting", this.m_enableLift);
			this.m_needUpdate = false;
		}
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00004932 File Offset: 0x00002B32
	public void OnTriggerEnter(Collider intruder)
	{
		if (this.m_enableLift)
		{
			return;
		}
		this.m_npcAnimManger = intruder.gameObject.GetComponentInParent<NPCAnimationManagerFSM>();
		if (this.m_npcAnimManger != null)
		{
			this.m_foundNPC = true;
		}
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00042284 File Offset: 0x00040484
	private void method_0()
	{
		if (this.m_foundNPC && this.m_npcAnimManger != null && this.m_curtainAnimator != null)
		{
			float sqrMagnitude = (base.transform.position - this.m_npcAnimManger.transform.position).sqrMagnitude;
			if (this.m_npcAnimManger.method_13(AnimationStateFSM.CombatSpawn))
			{
				float num = 3f;
				if (sqrMagnitude < num)
				{
					this.m_curtainAnimator.SetTrigger("tCombatLift");
					this.m_foundNPC = false;
				}
			}
			else if (this.m_npcAnimManger.method_13(AnimationStateFSM.AdvanceSpawn))
			{
				float num2 = 0.5f;
				if (sqrMagnitude < num2)
				{
					this.m_curtainAnimator.SetTrigger("tAdvanceLift");
					this.m_npcAnimManger.OnTriggerAdvanceSpawn();
					this.m_foundNPC = false;
				}
			}
		}
	}

	// Token: 0x0400028A RID: 650
	public bool m_enableLift;

	// Token: 0x0400028B RID: 651
	private bool m_needUpdate;

	// Token: 0x0400028C RID: 652
	public bool m_liftStarted;

	// Token: 0x0400028D RID: 653
	public Animator m_curtainAnimator;

	// Token: 0x0400028E RID: 654
	private bool m_foundNPC;

	// Token: 0x0400028F RID: 655
	private NPCAnimationManagerFSM m_npcAnimManger;
}
