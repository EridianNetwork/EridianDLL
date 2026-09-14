using System;
using UnityEngine;

// Token: 0x02000557 RID: 1367
public class DestoryableObjSetting : MonoBehaviour
{
	// Token: 0x040017C0 RID: 6080
	public string m_name = "DestoryableObj";

	// Token: 0x040017C1 RID: 6081
	public bool m_bHideUI;

	// Token: 0x040017C2 RID: 6082
	public bool m_receiveMeleeAttackDamage = true;

	// Token: 0x040017C3 RID: 6083
	public bool m_receiveAreaDamage = true;

	// Token: 0x040017C4 RID: 6084
	public bool m_receiveShootDamage = true;

	// Token: 0x040017C5 RID: 6085
	public bool m_bReceiveNpcDamage;

	// Token: 0x040017C6 RID: 6086
	public int m_initHP = 100;
}
