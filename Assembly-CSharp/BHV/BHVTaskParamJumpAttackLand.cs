using System;

namespace BHV
{
	// Token: 0x020001E4 RID: 484
	public sealed class BHVTaskParamJumpAttackLand : BHVTaskParam
	{
		// Token: 0x06000A57 RID: 2647 RVA: 0x0000A3A1 File Offset: 0x000085A1
		public BHVTaskParamJumpAttackLand()
		{
			base.m_Type = BHVTaskType.JumpAttackLand;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0000A3B8 File Offset: 0x000085B8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
		}
	}
}
