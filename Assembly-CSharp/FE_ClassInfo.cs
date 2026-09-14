using System;
using UnityEngine;
using XsdSettings;

// Token: 0x0200069E RID: 1694
public class FE_ClassInfo
{
	// Token: 0x06002BF4 RID: 11252 RVA: 0x000CF1AC File Offset: 0x000CD3AC
	public FE_ClassInfo(AvatarType avatarType_0)
	{
		this.classType = avatarType_0;
		this.strDisplayName = (this.strIntro = string.Empty);
		this.bFirstTimeShow = true;
		this.classModel = null;
	}

	// Token: 0x04001EDF RID: 7903
	public AvatarType classType;

	// Token: 0x04001EE0 RID: 7904
	public string strDisplayName;

	// Token: 0x04001EE1 RID: 7905
	public string strIntro;

	// Token: 0x04001EE2 RID: 7906
	public bool bFirstTimeShow;

	// Token: 0x04001EE3 RID: 7907
	public GameObject classModel;

	// Token: 0x04001EE4 RID: 7908
	public BuildingKitRender buildingKitRender;
}
