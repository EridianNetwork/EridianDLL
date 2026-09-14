using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003DA RID: 986
public class RankService : OnAccessSingleton<IRankService, RankService, RankServiceOffline>, IRankService
{
	// Token: 0x060018CE RID: 6350 RVA: 0x0001290E File Offset: 0x00010B0E
	public RankService()
	{
		PhotonNetwork.onlinePeer.method_5(57, new OperationResponseCallback(this.OnGetRanking));
	}

	// Token: 0x060018CF RID: 6351 RVA: 0x0001292F File Offset: 0x00010B2F
	public void imethod_0(GetRankingCallback getRankingCallback_0, int int_0, int int_1, int int_2)
	{
		this.mOnGotRanking = getRankingCallback_0;
		PhotonNetwork.onlinePeer.method_3(57, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x060018D0 RID: 6352 RVA: 0x00082C7C File Offset: 0x00080E7C
	private void OnGetRanking(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotRanking != null)
		{
			if (operationResponse == 0 && parameters.Count > 0)
			{
				List<Rank> list = new List<Rank>();
				byte b = 0;
				while ((int)b < parameters.Count)
				{
					list.Add(new Rank((Hashtable)parameters[b]));
					b += 1;
				}
				this.mOnGotRanking(list);
			}
			else
			{
				this.mOnGotRanking(null);
			}
			this.mOnGotRanking = null;
		}
	}

	// Token: 0x040010E5 RID: 4325
	private GetRankingCallback mOnGotRanking;
}
