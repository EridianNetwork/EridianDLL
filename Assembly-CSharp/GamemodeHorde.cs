using System;

// Token: 0x020003FF RID: 1023
public class GamemodeHorde : Gamemode
{
	// Token: 0x060019D2 RID: 6610 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_2()
	{
		return true;
	}

	// Token: 0x060019D3 RID: 6611 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_1()
	{
		return true;
	}

	// Token: 0x04001146 RID: 4422
	public EnnemyWave[] m_waves = new EnnemyWave[0];
}
