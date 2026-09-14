using System;
using System.Collections;

// Token: 0x020002C8 RID: 712
public class Announcement
{
	// Token: 0x06000F49 RID: 3913 RVA: 0x00003197 File Offset: 0x00001397
	public Announcement()
	{
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x0000D40D File Offset: 0x0000B60D
	public Announcement(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0000D41C File Offset: 0x0000B61C
	// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0000D424 File Offset: 0x0000B624
	public string Content { get; set; }

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0000D42D File Offset: 0x0000B62D
	// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0000D435 File Offset: 0x0000B635
	public AnnouncementType Type { get; set; }

	// Token: 0x06000F4F RID: 3919 RVA: 0x0000D43E File Offset: 0x0000B63E
	public void method_0(Hashtable hashtable_0)
	{
		this.Content = (string)hashtable_0[0];
		this.Type = (AnnouncementType)((int)hashtable_0[1]);
	}
}
