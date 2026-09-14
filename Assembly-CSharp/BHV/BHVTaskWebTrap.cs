using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200021D RID: 541
	public class BHVTaskWebTrap : BHVTask
	{
		// Token: 0x06000B3F RID: 2879 RVA: 0x0000B098 File Offset: 0x00009298
		public BHVTaskWebTrap()
		{
			base.m_Type = BHVTaskType.WebTrap;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0000B0AF File Offset: 0x000092AF
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamWebTrap_0 = bhvtaskParam_0 as BHVTaskParamWebTrap;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0000B0C4 File Offset: 0x000092C4
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamWebTrap_0;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00065A30 File Offset: 0x00063C30
		public override void Start()
		{
			base.Start();
			this.animationWebTrapState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("WebTrap") as AnimationWebTrapState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.WebTrap);
			if (this.object_0 == null)
			{
				this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/SpiderantWeb");
			}
			this.transform_0 = (this.bhvtaskManager_0.m_animationManagerFSM as WidowmakerAnimationManagerFSM).m_tailTransform;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00065AB0 File Offset: 0x00063CB0
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.animationWebTrapState_0.m_status == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			if (this.animationWebTrapState_0.m_bThrowWebTrap)
			{
				this.animationWebTrapState_0.m_bThrowWebTrap = false;
				this.method_0();
			}
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x00065B04 File Offset: 0x00063D04
		private void method_0()
		{
			if (!(this.object_0 == null) && !(this.transform_0 == null))
			{
				GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, this.transform_0.position, Quaternion.identity);
				if (gameObject != null)
				{
					gameObject.transform.position = this.transform_0.position;
					SpiderantWebTrap component = gameObject.GetComponent<SpiderantWebTrap>();
					if (component != null)
					{
						component.method_0(this.bhvtaskParamWebTrap_0.vector3_0);
					}
				}
				return;
			}
		}

		// Token: 0x04000A2B RID: 2603
		private BHVTaskParamWebTrap bhvtaskParamWebTrap_0;

		// Token: 0x04000A2C RID: 2604
		private AnimationWebTrapState animationWebTrapState_0;

		// Token: 0x04000A2D RID: 2605
		private global::UnityEngine.Object object_0;

		// Token: 0x04000A2E RID: 2606
		private Transform transform_0;
	}
}
