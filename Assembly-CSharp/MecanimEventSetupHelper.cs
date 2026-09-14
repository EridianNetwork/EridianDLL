using System;
using Core;
using UnityEngine;

// Token: 0x02000ADA RID: 2778
public class MecanimEventSetupHelper : MonoBehaviour
{
	// Token: 0x06004B5F RID: 19295 RVA: 0x00139484 File Offset: 0x00137684
	private void Awake()
	{
		this.dataSource = (Resources.Load("Animation_Events") as GameObject).GetComponent<MecanimEventData>();
		if (this.dataSource == null && (this.dataSources == null || this.dataSources.Length == 0))
		{
			DebugUtils.LogError(LogCategory.Tool, "Please setup data source of event system.");
			return;
		}
		DebugUtils.Log(LogCategory.Animation, "Loading animation event data");
		if (this.dataSource != null)
		{
			MecanimEventManager.smethod_0(this.dataSource);
		}
		else
		{
			MecanimEventManager.smethod_1(this.dataSources);
		}
	}

	// Token: 0x040036E1 RID: 14049
	public const string ANIMEVENTHOLDER_ASSET_NAME_CLIENT = "Animation_Events";

	// Token: 0x040036E2 RID: 14050
	public const string ANIMEVENTHOLDER_ASSET_NAME_HOST = "Animation_Events_Host";

	// Token: 0x040036E3 RID: 14051
	public MecanimEventData dataSource;

	// Token: 0x040036E4 RID: 14052
	public MecanimEventData[] dataSources;
}
