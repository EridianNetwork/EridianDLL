using System;
using UnityEngine;

// Token: 0x02000531 RID: 1329
public class RVControl : MonoBehaviour
{
	// Token: 0x0600222A RID: 8746 RVA: 0x000A2A70 File Offset: 0x000A0C70
	private void Start()
	{
		this.m_enableDoor = false;
		if (this.m_EnableDoor != null)
		{
			this.m_EnableDoor.gameObject.SetActive(false);
		}
		if (this.m_DisableDoor != null)
		{
			this.m_DisableDoor.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600222B RID: 8747 RVA: 0x000A2AC4 File Offset: 0x000A0CC4
	public void method_0(bool bool_0)
	{
		if (bool_0 == this.m_enableDoor)
		{
			return;
		}
		this.m_enableDoor = bool_0;
		if (this.m_EnableDoor != null && this.m_DisableDoor != null)
		{
			this.m_EnableDoor.gameObject.SetActive(bool_0);
			this.m_DisableDoor.gameObject.SetActive(!bool_0);
		}
	}

	// Token: 0x040016CB RID: 5835
	public GameObject m_EnableDoor;

	// Token: 0x040016CC RID: 5836
	public GameObject m_DisableDoor;

	// Token: 0x040016CD RID: 5837
	private bool m_enableDoor;
}
