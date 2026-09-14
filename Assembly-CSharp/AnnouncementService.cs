using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200034C RID: 844
internal class AnnouncementService : OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>, IAnnouncementService
{
	// Token: 0x06001567 RID: 5479 RVA: 0x0000FA5A File Offset: 0x0000DC5A
	public AnnouncementService()
	{
		PhotonNetwork.onlinePeer.method_7(160, new EventCallback(this.OnAnnouncementsEvent));
		this.mOnAnnouncements = new List<OnAnnouncements>();
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x00079C48 File Offset: 0x00077E48
	public void OnAnnouncementsEvent(Dictionary<byte, object> parameters)
	{
		List<Announcement> list = new List<Announcement>();
		Hashtable hashtable = (Hashtable)parameters[0];
		foreach (DictionaryEntry item in hashtable)
		{
			list.Add(new Announcement((Hashtable)item.Value));
		}
		Announcement[] annnouncementsData = list.ToArray();
		mOnAnnouncements.ForEach(delegate(OnAnnouncements onAnnouncements_0)
		{
			onAnnouncements_0(annnouncementsData);
		});
	}
	// Token: 0x06001569 RID: 5481 RVA: 0x0000FA88 File Offset: 0x0000DC88
	public void imethod_0(OnAnnouncements onAnnouncements_0)
	{
		this.mOnAnnouncements.Add(onAnnouncements_0);
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x0000FA96 File Offset: 0x0000DC96
	public void imethod_1(OnAnnouncements onAnnouncements_0)
	{
		this.mOnAnnouncements.Remove(onAnnouncements_0);
	}

	// Token: 0x04000E95 RID: 3733
	private List<OnAnnouncements> mOnAnnouncements;
}
