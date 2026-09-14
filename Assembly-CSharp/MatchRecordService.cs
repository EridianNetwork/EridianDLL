using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003B8 RID: 952
public class MatchRecordService : OnAccessSingleton<IMatchRecordService, MatchRecordService, MatchRecordServiceOffline>, IMatchRecordService
{
	// Token: 0x06001816 RID: 6166 RVA: 0x00011E21 File Offset: 0x00010021
	public MatchRecordService()
	{
		PhotonNetwork.onlinePeer.method_5(148, new OperationResponseCallback(this.OnRequestMatchRecordCallback));
	}

	// Token: 0x06001817 RID: 6167 RVA: 0x00011E45 File Offset: 0x00010045
	public void imethod_0(GetMatchRecordCallback getMatchRecordCallback_0, int int_0)
	{
		this.mOnGotMatchRecord = getMatchRecordCallback_0;
		PhotonNetwork.onlinePeer.method_3(148, new object[] { int_0 });
	}

	// Token: 0x06001818 RID: 6168 RVA: 0x000808A4 File Offset: 0x0007EAA4
	private void OnRequestMatchRecordCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMatchRecord != null)
		{
			if (operationResponse == 0)
			{
				MatchRecord matchRecord = new MatchRecord((Hashtable)parameters[0]);
				this.mOnGotMatchRecord(matchRecord);
			}
			this.mOnGotMatchRecord = null;
		}
	}

	// Token: 0x04001059 RID: 4185
	private GetMatchRecordCallback mOnGotMatchRecord;
}
