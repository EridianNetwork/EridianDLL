using System;
using System.Diagnostics;
using Core;
using Photon;
using UnityEngine;

// Token: 0x02000A94 RID: 2708
public class DebugInfoSync : global::Photon.MonoBehaviour
{
	// Token: 0x06004943 RID: 18755 RVA: 0x0002FE85 File Offset: 0x0002E085
	private void Awake()
	{
		DebugUtils.s_debugInfoSync = this;
	}

	// Token: 0x06004944 RID: 18756 RVA: 0x001309B0 File Offset: 0x0012EBB0
	[Conditional("ASSERTS")]
	public void method_0(LogCategory logCategory_0, string string_0, string string_1)
	{
		if (this.m_enabled)
		{
			object[] array = new object[]
			{
				(int)logCategory_0,
				string_0,
				string_1
			};
			base.photonView.method_4("RPC_SendAssertInfo", PhotonTargets.Others, array);
		}
	}

	// Token: 0x06004945 RID: 18757 RVA: 0x001309F0 File Offset: 0x0012EBF0
	[Conditional("ASSERTS")]
	public void method_1(int int_0)
	{
		if (this.m_enabled)
		{
			object[] array = new object[] { int_0 };
			base.photonView.method_4("RPC_IgnoreThisOne", PhotonTargets.MasterClient, array);
		}
	}

	// Token: 0x06004946 RID: 18758 RVA: 0x0002FE8D File Offset: 0x0002E08D
	[RPC]
	[Conditional("ASSERTS")]
	private void RPC_IgnoreThisOne(int hashcode, PhotonMessageInfo info)
	{
		DebugUtils.smethod_13(hashcode);
	}

	// Token: 0x06004947 RID: 18759 RVA: 0x0000311B File Offset: 0x0000131B
	[RPC]
	[Conditional("ASSERTS")]
	private void RPC_SendAssertInfo(int type, string msg, string stackTrace, PhotonMessageInfo info)
	{
	}

	// Token: 0x06004948 RID: 18760 RVA: 0x00130A28 File Offset: 0x0012EC28
	[Conditional("ASSERTS")]
	public void RPC_SetHostDebugInfoTransferingEnabled(bool enabled)
	{
		object[] array = new object[] { enabled };
		base.photonView.method_4("RPC_SetHostDebugInfoTransferingEnabled", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06004949 RID: 18761 RVA: 0x0002FE95 File Offset: 0x0002E095
	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_SetHostDebugInfoTransferingEnabled(bool enabled, PhotonMessageInfo info)
	{
		this.m_enabled = enabled;
	}

	// Token: 0x0600494A RID: 18762 RVA: 0x00130A58 File Offset: 0x0012EC58
	[Conditional("ASSERTS")]
	public void RPC_DumpHostMemoryInfo()
	{
		object[] array = new object[0];
		base.photonView.method_4("RPC_DumpHostMemoryInfo", PhotonTargets.MasterClient, array);
	}

	// Token: 0x0600494B RID: 18763 RVA: 0x0002FE9E File Offset: 0x0002E09E
	[Conditional("ASSERTS")]
	[RPC]
	private void RPC_DumpHostMemoryInfo(PhotonMessageInfo info)
	{
		ResourceInfoDumper.smethod_0(string.Empty, "ResourceInfo.txt");
	}

	// Token: 0x0600494C RID: 18764 RVA: 0x00130A80 File Offset: 0x0012EC80
	[Conditional("ASSERTS")]
	public void method_2(float float_0, int int_0)
	{
		if (this.m_enabled)
		{
			object[] array = new object[] { float_0, int_0 };
			base.photonView.method_4("RPC_SendHostDebugInfoFPSMem", PhotonTargets.Others, array);
		}
	}

	// Token: 0x0600494D RID: 18765 RVA: 0x0002FEAF File Offset: 0x0002E0AF
	[RPC]
	[Conditional("ASSERTS")]
	private void RPC_SendHostDebugInfoFPSMem(float fps, int mem)
	{
		this.m_hostfps = fps;
		this.m_hostmem = mem;
	}

	// Token: 0x040035AF RID: 13743
	public bool m_enabled;

	// Token: 0x040035B0 RID: 13744
	public float m_hostfps;

	// Token: 0x040035B1 RID: 13745
	public int m_hostmem;
}
