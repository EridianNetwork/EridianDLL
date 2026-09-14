using System;
using System.Collections;

// Token: 0x0200033F RID: 831
public class QuestProgress
{
	// Token: 0x060014F8 RID: 5368 RVA: 0x00003197 File Offset: 0x00001397
	public QuestProgress()
	{
	}

	// Token: 0x060014F9 RID: 5369 RVA: 0x0000F722 File Offset: 0x0000D922
	public QuestProgress(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x060014FA RID: 5370 RVA: 0x00078B54 File Offset: 0x00076D54
	public void method_0(Hashtable hashtable_0)
	{
		this.mQuestId = (int)hashtable_0[0];
		this.mStatus = (QuestState)((int)hashtable_0[1]);
		this.mCurrentTask = (int)hashtable_0[2];
		this.mTaskProgress = (int)hashtable_0[3];
	}

	// Token: 0x04000E7D RID: 3709
	public int mQuestId;

	// Token: 0x04000E7E RID: 3710
	public QuestState mStatus;

	// Token: 0x04000E7F RID: 3711
	public int mCurrentTask;

	// Token: 0x04000E80 RID: 3712
	public int mTaskProgress;
}
