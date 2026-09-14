using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005C4 RID: 1476
public class LightsMgr
{
	// Token: 0x06002569 RID: 9577 RVA: 0x00019717 File Offset: 0x00017917
	public void method_0(GameObject gameObject_0, bool bool_0, LightsMgr.LightObjectType lightObjectType_0)
	{
		if (gameObject_0 == null)
		{
			return;
		}
		this.m_dictLights[lightObjectType_0] = gameObject_0;
		gameObject_0.SetActive(bool_0);
	}

	// Token: 0x0600256A RID: 9578 RVA: 0x00019737 File Offset: 0x00017937
	public void method_1(GameObject gameObject_0, LightsMgr.LightObjectType lightObjectType_0)
	{
		if (!(gameObject_0 == null) && this.m_dictLights.ContainsKey(lightObjectType_0) && !(this.m_dictLights[lightObjectType_0] != gameObject_0))
		{
			this.m_dictLights.Remove(lightObjectType_0);
			return;
		}
	}

	// Token: 0x0600256B RID: 9579 RVA: 0x00019772 File Offset: 0x00017972
	public void method_2(LightsMgr.LightObjectType lightObjectType_0, bool bool_0)
	{
		if (this.m_dictLights.ContainsKey(lightObjectType_0))
		{
			this.m_dictLights[lightObjectType_0].SetActive(bool_0);
		}
	}

	// Token: 0x04001ACA RID: 6858
	private Dictionary<LightsMgr.LightObjectType, GameObject> m_dictLights = new Dictionary<LightsMgr.LightObjectType, GameObject>();

	// Token: 0x020005C5 RID: 1477
	public enum LightObjectType
	{
		// Token: 0x04001ACC RID: 6860
		LT_Unknown = -1,
		// Token: 0x04001ACD RID: 6861
		LT_SnapLightsGroup,
		// Token: 0x04001ACE RID: 6862
		LT_UIPreviewLightsGroup,
		// Token: 0x04001ACF RID: 6863
		LT_SceneBakeOnlyGroup
	}
}
