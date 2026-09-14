using System;
using ns0;

// Token: 0x02000437 RID: 1079
public class Arbitrator : MonoSingleton<Arbitrator>
{
	// Token: 0x06001A8B RID: 6795 RVA: 0x00013567 File Offset: 0x00011767
	public void method_0(Arbitrator.ArbitratorClient arbitratorClient_0, Arbitrator.ArbitrableData arbitrableData_0)
	{
		arbitratorClient_0.OnArbitrated(arbitrableData_0);
	}

	// Token: 0x02000438 RID: 1080
	public interface ArbitrableData
	{
	}

	// Token: 0x02000439 RID: 1081
	public interface ArbitratorClient
	{
		// Token: 0x06001A8C RID: 6796
		void OnArbitrated(Arbitrator.ArbitrableData data);
	}
}
