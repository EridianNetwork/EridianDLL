using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000A8D RID: 2701
public class DebugInfoManager : MonoSingleton<DebugInfoManager>
{
	// Token: 0x0600490F RID: 18703 RVA: 0x0002FB7D File Offset: 0x0002DD7D
	public DebugInfoManager()
	{
		PhotonNetwork.onlinePeer.method_5(61, new OperationResponseCallback(this.OnRecordClientDebugInfoCallback));
		this.method_0();
	}

	// Token: 0x17000775 RID: 1909
	// (get) Token: 0x06004910 RID: 18704 RVA: 0x0002FBA4 File Offset: 0x0002DDA4
	// (set) Token: 0x06004911 RID: 18705 RVA: 0x0002FBAC File Offset: 0x0002DDAC
	public string String_0
	{
		get
		{
			return this.m_Version;
		}
		set
		{
			this.m_Version = value;
		}
	}

	// Token: 0x06004912 RID: 18706 RVA: 0x0002FBB5 File Offset: 0x0002DDB5
	private void method_0()
	{
		this.m_AddCount = 0U;
		this.m_DebugInfoSet = new Dictionary<int, DebugInfo>();
		this.m_lastFlush = Time.time;
	}

	// Token: 0x06004913 RID: 18707 RVA: 0x001302E0 File Offset: 0x0012E4E0
	public void method_1(DebugInfo debugInfo_0)
	{
		int hashcode = debugInfo_0.hashcode;
		if (this.m_DebugInfoSet.ContainsKey(hashcode))
		{
			this.m_DebugInfoSet[hashcode].count++;
		}
		else
		{
			this.m_DebugInfoSet.Add(hashcode, debugInfo_0);
		}
		this.m_AddCount += 1U;
	}

	// Token: 0x06004914 RID: 18708 RVA: 0x0002FBD4 File Offset: 0x0002DDD4
	private void OnDestroy()
	{
		this.method_3();
	}

	// Token: 0x06004915 RID: 18709 RVA: 0x0002FBDC File Offset: 0x0002DDDC
	public void method_2(bool bool_0)
	{
		DebugUtils.Log(LogCategory.Default, "DebugInfo submitted: " + bool_0);
	}

	// Token: 0x06004916 RID: 18710 RVA: 0x0002FBF4 File Offset: 0x0002DDF4
	private void Update()
	{
		if (Time.time - this.m_lastFlush > 30f)
		{
			this.method_3();
		}
	}

	// Token: 0x06004917 RID: 18711 RVA: 0x0002FC0F File Offset: 0x0002DE0F
	public void method_3()
	{
		if (this.m_DebugInfoSet.Count > 0)
		{
			this.method_4(new DebugInfoManager.SubmitClientDebugInfoCallback(this.method_2), this.String_0, this.m_DebugInfoSet);
			this.method_0();
		}
	}

	// Token: 0x06004918 RID: 18712 RVA: 0x00130338 File Offset: 0x0012E538
	private void method_4(DebugInfoManager.SubmitClientDebugInfoCallback submitClientDebugInfoCallback_0, string string_0, Dictionary<int, DebugInfo> dictionary_0)
	{
		this.mOnSubmitClientDebugInfo = submitClientDebugInfoCallback_0;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		foreach (DebugInfo debugInfo in dictionary_0.Values)
		{
			dictionary[num++] = new Hashtable
			{
				{ 0, debugInfo.hashcode },
				{ 1, debugInfo.count },
				{ 2, debugInfo.isFromHost },
				{ 3, debugInfo.isWarning },
				{ 4, debugInfo.type },
				{ 5, debugInfo.callstack },
				{ 6, debugInfo.message },
				{ 7, debugInfo.gameModeName },
				{ 8, debugInfo.instanceName },
				{ 9, debugInfo.mapName },
				{ 10, debugInfo.isWebPlayer },
				{
					11,
					(byte)debugInfo.difficulty
				},
				{ 12, debugInfo.currentStep }
			};
		}
		PhotonNetwork.onlinePeer.method_3(61, new object[] { string_0, dictionary });
	}

	// Token: 0x06004919 RID: 18713 RVA: 0x0002FC43 File Offset: 0x0002DE43
	private void OnRecordClientDebugInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSubmitClientDebugInfo != null)
		{
			if (operationResponse == 0)
			{
				this.mOnSubmitClientDebugInfo(true);
			}
			else
			{
				this.mOnSubmitClientDebugInfo(false);
			}
			this.mOnSubmitClientDebugInfo = null;
		}
	}

	// Token: 0x0400359F RID: 13727
	private Dictionary<int, DebugInfo> m_DebugInfoSet;

	// Token: 0x040035A0 RID: 13728
	private string m_Version;

	// Token: 0x040035A1 RID: 13729
	private uint m_AddCount;

	// Token: 0x040035A2 RID: 13730
	private float m_lastFlush;

	// Token: 0x040035A3 RID: 13731
	private DebugInfoManager.SubmitClientDebugInfoCallback mOnSubmitClientDebugInfo;

	// Token: 0x02000A8E RID: 2702
	// (Invoke) Token: 0x0600491B RID: 18715
	public delegate void SubmitClientDebugInfoCallback(bool success);
}
