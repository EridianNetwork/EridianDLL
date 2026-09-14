using System;
using Core;
using XsdSettings;

// Token: 0x02000A8C RID: 2700
public class DebugInfo
{
	// Token: 0x0600490E RID: 18702 RVA: 0x0002FB52 File Offset: 0x0002DD52
	public DebugInfo()
	{
		this.hashcode = 0;
		this.count = 1;
		this.isFromHost = false;
		this.isWarning = false;
		this.type = LogCategory.Default;
	}

	// Token: 0x04003592 RID: 13714
	public int hashcode;

	// Token: 0x04003593 RID: 13715
	public int count;

	// Token: 0x04003594 RID: 13716
	public bool isFromHost;

	// Token: 0x04003595 RID: 13717
	public bool isWebPlayer;

	// Token: 0x04003596 RID: 13718
	public bool isWarning;

	// Token: 0x04003597 RID: 13719
	public LogCategory type;

	// Token: 0x04003598 RID: 13720
	public string callstack;

	// Token: 0x04003599 RID: 13721
	public string message;

	// Token: 0x0400359A RID: 13722
	public string gameModeName;

	// Token: 0x0400359B RID: 13723
	public string instanceName;

	// Token: 0x0400359C RID: 13724
	public string mapName;

	// Token: 0x0400359D RID: 13725
	public ELevelDifficulty difficulty;

	// Token: 0x0400359E RID: 13726
	public string currentStep;
}
