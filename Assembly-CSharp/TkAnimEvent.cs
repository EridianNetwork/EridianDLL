using System;
using UnityEngine;

// Token: 0x02000B59 RID: 2905
[Serializable]
public class TkAnimEvent
{
	// Token: 0x17000800 RID: 2048
	// (get) Token: 0x06004ED1 RID: 20177 RVA: 0x00033624 File Offset: 0x00031824
	public string labelName
	{
		get
		{
			return this.actionPath;
		}
	}

	// Token: 0x06004ED2 RID: 20178 RVA: 0x0014F328 File Offset: 0x0014D528
	public override bool Equals(object obj)
	{
		TkAnimEvent tkAnimEvent = (TkAnimEvent)obj;
		return tkAnimEvent != null && (this.actionPath == tkAnimEvent.actionPath && this.locatorName == tkAnimEvent.locatorName) && this.frame == tkAnimEvent.frame;
	}

	// Token: 0x06004ED3 RID: 20179 RVA: 0x0003362C File Offset: 0x0003182C
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	// Token: 0x04003B28 RID: 15144
	public int frame;

	// Token: 0x04003B29 RID: 15145
	public string actionPath = string.Empty;

	// Token: 0x04003B2A RID: 15146
	[NonSerialized]
	public bool playedInEditor;

	// Token: 0x04003B2B RID: 15147
	[TkObjectNameField(typeof(GameObject), true)]
	public string locatorName = string.Empty;
}
