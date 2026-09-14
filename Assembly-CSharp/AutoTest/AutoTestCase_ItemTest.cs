using System;
using ns0;

namespace AutoTest
{
	// Token: 0x0200062F RID: 1583
	internal class AutoTestCase_ItemTest : AutoTestCase
	{
		// Token: 0x06002837 RID: 10295 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void RequestResource()
		{
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x000BD654 File Offset: 0x000BB854
		protected override void OpenAutoTestCase()
		{
			this.m_localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (this.m_localPlayer == null)
			{
				base.Close(false, "Local Player is null");
			}
			this.m_equipPlayer = this.m_localPlayer.vmethod_19() as EquipmentInventoryEntityPlayer;
		}

		// Token: 0x06002839 RID: 10297 RVA: 0x0000311B File Offset: 0x0000131B
		protected override void UpdateAutoTestCase()
		{
		}

		// Token: 0x04001C87 RID: 7303
		protected EntityPlayer m_localPlayer;

		// Token: 0x04001C88 RID: 7304
		protected EquipmentInventoryEntityPlayer m_equipPlayer;

		// Token: 0x04001C89 RID: 7305
		protected bool m_isEquiped;
	}
}
