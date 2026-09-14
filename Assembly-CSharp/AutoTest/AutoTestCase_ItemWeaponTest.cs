using System;
using ns0;

namespace AutoTest
{
	// Token: 0x02000630 RID: 1584
	internal class AutoTestCase_ItemWeaponTest : AutoTestCase_ItemTest
	{
		// Token: 0x0600283B RID: 10299 RVA: 0x0001A966 File Offset: 0x00018B66
		protected override void OpenAutoTestCase()
		{
			base.OpenAutoTestCase();
			this.m_weaponDna = this.m_localPlayer.vmethod_16().method_17();
		}

		// Token: 0x0600283C RID: 10300 RVA: 0x000BD6AC File Offset: 0x000BB8AC
		protected override void UpdateAutoTestCase()
		{
			base.UpdateAutoTestCase();
			if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2() && base.m_timeElapsed > 5f && !this.m_isEquiped)
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_13(0, 0);
				this.m_isEquiped = true;
			}
			if (this.m_weaponDna != this.m_localPlayer.vmethod_16().method_17() && base.m_timeElapsed > 15f)
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_14(1);
			}
			if (this.m_equipPlayer.vmethod_28(1) == null && base.m_timeElapsed > 25f)
			{
				base.Close(true, string.Empty);
			}
		}

		// Token: 0x04001C8A RID: 7306
		protected WeaponDNA m_weaponDna;
	}
}
