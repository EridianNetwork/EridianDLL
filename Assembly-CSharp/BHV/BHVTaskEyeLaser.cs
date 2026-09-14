using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C7 RID: 455
	public class BHVTaskEyeLaser : BHVTask
	{
		// Token: 0x060009C6 RID: 2502 RVA: 0x00009CBD File Offset: 0x00007EBD
		public BHVTaskEyeLaser()
		{
			base.m_Type = BHVTaskType.EyeLaser;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00009CE3 File Offset: 0x00007EE3
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamEyeLaser_0 = bhvtaskParam_0 as BHVTaskParamEyeLaser;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00009CF8 File Offset: 0x00007EF8
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamEyeLaser_0;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0005F4B0 File Offset: 0x0005D6B0
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamEyeLaser_0.float_1;
			this.float_1 = this.bhvtaskParamEyeLaser_0.float_0;
			this.bool_1 = false;
			this.bool_2 = false;
			this.transform_0 = null;
			this.transform_1 = null;
			this.theInsaneAnimationManagerFSM_0 = this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneAnimationManagerFSM;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEyeLaserWarning", true);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0005F534 File Offset: 0x0005D734
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.transform_0 != null && this.bhvtaskParamEyeLaser_0.gameObject_0 != null && this.transform_1 != null)
			{
				this.transform_0.position = this.transform_1.position;
				Vector3 normalized = (this.bhvtaskParamEyeLaser_0.gameObject_0.transform.position - this.transform_0.position).normalized;
				float num = Vector3.Angle(this.transform_0.transform.forward, normalized);
				if (num > 0.1f)
				{
					this.transform_0.transform.forward = Vector3.Lerp(this.transform_0.transform.forward, normalized, this.bhvtaskParamEyeLaser_0.float_2 * Time.deltaTime);
				}
			}
			if (this.float_1 > 0f && !this.bool_1)
			{
				this.float_1 -= Time.deltaTime;
				if (this.float_1 < 1.2f && !this.bool_2)
				{
					this.bool_2 = true;
					if (this.theInsaneAnimationManagerFSM_0 != null)
					{
						this.transform_0 = this.theInsaneAnimationManagerFSM_0.method_31(true);
						if (this.transform_0 != null)
						{
							this.transform_1 = this.transform_0.parent;
							this.transform_0.parent = null;
						}
					}
				}
				if (this.float_1 > 0f)
				{
					return;
				}
				this.bool_1 = true;
			}
			this.float_0 -= Time.deltaTime;
			if (this.float_0 < 0f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0005F6F4 File Offset: 0x0005D8F4
		public override void vmethod_3(bool bool_3)
		{
			base.vmethod_3(bool_3);
			if (this.theInsaneAnimationManagerFSM_0 != null)
			{
				this.theInsaneAnimationManagerFSM_0.method_31(false);
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bEyeLaserWarning", false);
			if (this.transform_0 != null)
			{
				this.transform_0.parent = this.transform_1;
			}
		}

		// Token: 0x040008DC RID: 2268
		private BHVTaskParamEyeLaser bhvtaskParamEyeLaser_0;

		// Token: 0x040008DD RID: 2269
		private TheInsaneAnimationManagerFSM theInsaneAnimationManagerFSM_0;

		// Token: 0x040008DE RID: 2270
		private Transform transform_0;

		// Token: 0x040008DF RID: 2271
		private Transform transform_1;

		// Token: 0x040008E0 RID: 2272
		private float float_0 = 1f;

		// Token: 0x040008E1 RID: 2273
		private float float_1 = 4f;

		// Token: 0x040008E2 RID: 2274
		private bool bool_1;

		// Token: 0x040008E3 RID: 2275
		private bool bool_2;
	}
}
