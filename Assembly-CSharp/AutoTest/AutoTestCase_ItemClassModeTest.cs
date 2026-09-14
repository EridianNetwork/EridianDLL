using System;
using ns0;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x02000632 RID: 1586
	internal class AutoTestCase_ItemClassModeTest : AutoTestCase_ItemTest
	{
		// Token: 0x06002841 RID: 10305 RVA: 0x0001A984 File Offset: 0x00018B84
		protected override void OpenAutoTestCase()
		{
			base.OpenAutoTestCase();
		}

		// Token: 0x06002842 RID: 10306 RVA: 0x000BD7F4 File Offset: 0x000BB9F4
	protected override void UpdateAutoTestCase()
	{
		base.UpdateAutoTestCase();
		if (ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2() && base.m_timeElapsed > 5f && !m_isEquiped)
		{
			for (int i = 0; i < ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_31(); i++)
			{
				ItemDNA itemDNA = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(i);
				if (itemDNA != null && itemDNA.method_3(ItemType.ClassMode))
				{
					ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_20((byte)i);
					break;
				}
			}
			m_isEquiped = true;
		}
		if (m_isEquiped && base.m_timeElapsed > 10f && m_equipPlayer.method_13() != null)
		{
			Close(pass: true, string.Empty);
		}
	}
	}
}
