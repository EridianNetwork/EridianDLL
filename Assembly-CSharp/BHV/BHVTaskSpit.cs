using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200020D RID: 525
	public class BHVTaskSpit : BHVTask
	{
		// Token: 0x06000AFA RID: 2810 RVA: 0x0000AD39 File Offset: 0x00008F39
		public BHVTaskSpit()
		{
			base.m_Type = BHVTaskType.Spit;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000AD49 File Offset: 0x00008F49
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSpit_0 = bhvtaskParam_0 as BHVTaskParamSpit;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0000AD5E File Offset: 0x00008F5E
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSpit_0;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00064994 File Offset: 0x00062B94
		public override void Start()
		{
			base.Start();
			this.gameObject_0 = null;
			this.float_0 = 0f;
			this.animationSpitState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Spit") as AnimationSpitState;
			if (this.animationSpitState_0 != null)
			{
				this.animationSpitState_0.m_spitAttackIndex = this.bhvtaskParamSpit_0.int_3;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Spit);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00064A10 File Offset: 0x00062C10
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			this.method_0();
			Vector3 vector = this.bhvtaskParamSpit_0.gameObject_0.transform.position + Vector3.up * 1.4f;
			if (this.gameObject_0 == null)
			{
				this.gameObject_0 = this.bhvtaskManager_0.m_animationManagerFSM.vmethod_9();
				if (this.gameObject_0 != null)
				{
					this.curve_0 = AIServiceCurve.AIServiceCurve_0.method_1(AIServiceCurve.ECurveType.ESpitCurve, this.gameObject_0.transform.position, vector, 1.5f);
				}
				if (this.animationSpitState_0.m_bSpitAttackAnimFinished && this.gameObject_0 == null)
				{
					this.float_0 += deltaTime;
					if (this.float_0 > 2f)
					{
						base.m_Status = BHVTaskStatus.SUCCESS;
					}
				}
			}
			else
			{
				bool flag = this.curve_0.Update(deltaTime, 18f, out this.vector3_0);
				this.gameObject_0.transform.forward = (this.vector3_0 - this.gameObject_0.transform.position).normalized;
				if ((this.gameObject_0.transform.position - vector).sqrMagnitude < 0.64f)
				{
					this.method_1();
					return;
				}
				this.gameObject_0.transform.position = this.vector3_0;
				if (flag)
				{
					this.method_1();
				}
			}
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0000AD66 File Offset: 0x00008F66
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.animationSpitState_0.method_4(false);
			if (this.gameObject_0 != null)
			{
				global::UnityEngine.Object.Destroy(this.gameObject_0);
			}
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00064B9C File Offset: 0x00062D9C
		private void method_0()
		{
			Vector3 normalized = (this.bhvtaskParamSpit_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00064C28 File Offset: 0x00062E28
		private void method_1()
		{
			this.bhvtaskManager_0.m_animationManagerFSM.method_18(ENPCParticleType.E_DamageSpitAtTouchedObject, this.gameObject_0.transform);
			VFXforNPC[] particleList = this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.m_particleList;
			for (int i = 0; i < particleList.Length; i++)
			{
				if (!(particleList[i].m_particleGameObject == null) && particleList[i].m_type == ENPCParticleType.E_DamageSpitAtTouchedObject)
				{
					particleList[i].m_particleGameObject.GetComponent<BaseEventTriggerCtl>().TriggerEventByName("Corrosive_Blast_Small_Rnd");
				}
			}
			global::UnityEngine.Object.Destroy(this.gameObject_0);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x040009F5 RID: 2549
		private BHVTaskParamSpit bhvtaskParamSpit_0;

		// Token: 0x040009F6 RID: 2550
		private AnimationSpitState animationSpitState_0;

		// Token: 0x040009F7 RID: 2551
		private GameObject gameObject_0;

		// Token: 0x040009F8 RID: 2552
		private AIServiceCurve.Curve curve_0;

		// Token: 0x040009F9 RID: 2553
		private Vector3 vector3_0;

		// Token: 0x040009FA RID: 2554
		private float float_0;
	}
}
