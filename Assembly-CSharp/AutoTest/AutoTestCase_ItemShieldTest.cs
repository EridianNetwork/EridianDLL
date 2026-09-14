using System;
using ns0;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x02000631 RID: 1585
	internal class AutoTestCase_ItemShieldTest : AutoTestCase_ItemTest
	{
		// Token: 0x0600283E RID: 10302 RVA: 0x0001A984 File Offset: 0x00018B84
		protected override void OpenAutoTestCase()
		{
			base.OpenAutoTestCase();
		}

		// Token: 0x0600283F RID: 10303 RVA: 0x000BD750 File Offset: 0x000BB950
	protected override void UpdateAutoTestCase()
	{
		base.UpdateAutoTestCase();
		if (ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2() && base.m_timeElapsed > 5f && !m_isEquiped)
		{
			for (int i = 0; i < ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_31(); i++)
			{
				ItemDNA itemDNA = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(i);
				if (itemDNA != null && itemDNA.method_3(ItemType.Shield))
				{
					ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_19((byte)i);
					break;
				}
			}
			m_isEquiped = true;
		}
		if (m_isEquiped && base.m_timeElapsed > 10f && m_equipPlayer.vmethod_39() != null)
		{
			Close(pass: true, string.Empty);
		}
	}
	}
}
