using System;
using UnityEngine;

// Token: 0x020006D9 RID: 1753
public class MapObjectMark : MonoBehaviour
{
	// Token: 0x06002E48 RID: 11848 RVA: 0x0001E918 File Offset: 0x0001CB18
	private void OnEnable()
	{
		if (this.ObjType != UIMapDataManager.MiniMapObjectType.None)
		{
			this.method_0();
		}
	}

	// Token: 0x06002E49 RID: 11849 RVA: 0x0001E928 File Offset: 0x0001CB28
	private void OnDisable()
	{
		this.method_1();
	}

	// Token: 0x06002E4A RID: 11850 RVA: 0x0001E930 File Offset: 0x0001CB30
	public void method_0()
	{
		UIMapDataManager.smethod_0().method_19(this);
	}

	// Token: 0x06002E4B RID: 11851 RVA: 0x0001E93D File Offset: 0x0001CB3D
	public void method_1()
	{
		UIMapDataManager.smethod_0().method_22(this);
	}

	// Token: 0x04002087 RID: 8327
	public bool bAlwaysOnMap;

	// Token: 0x04002088 RID: 8328
	[HideInInspector]
	public int iNPCID = -1;

	// Token: 0x04002089 RID: 8329
	[HideInInspector]
	public int iCharacterID = -1;

	// Token: 0x0400208A RID: 8330
	public int layerIndex;

	// Token: 0x0400208B RID: 8331
	[SerializeField]
	public UIMapDataManager.MiniMapObjectType ObjType;
}
