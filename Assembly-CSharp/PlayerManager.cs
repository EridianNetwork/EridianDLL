using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020002AC RID: 684
public class PlayerManager : MonoSingleton<PlayerManager>
{
	// Token: 0x06000EB0 RID: 3760 RVA: 0x0000CE01 File Offset: 0x0000B001
	public void method_0(PlayerProperties playerProperties_0, bool bool_0)
	{
		if (bool_0)
		{
			this.m_localPlayerId = playerProperties_0.m_id;
		}
		this.m_players.Remove(playerProperties_0.m_id);
		this.m_players.Add(playerProperties_0.m_id, playerProperties_0);
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x00073FE8 File Offset: 0x000721E8
	public PlayerProperties method_1(int int_0)
	{
		PlayerProperties playerProperties = null;
		this.m_players.TryGetValue(int_0, out playerProperties);
		return playerProperties;
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x0000CE36 File Offset: 0x0000B036
	public PlayerProperties method_2()
	{
		return this.method_1(this.m_localPlayerId);
	}

	// Token: 0x04000D2F RID: 3375
	private Dictionary<int, PlayerProperties> m_players = new Dictionary<int, PlayerProperties>();

	// Token: 0x04000D30 RID: 3376
	private int m_localPlayerId;
}
