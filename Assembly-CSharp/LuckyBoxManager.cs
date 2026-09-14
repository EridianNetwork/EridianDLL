using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x0200067F RID: 1663
public class LuckyBoxManager
{
	// Token: 0x06002AE3 RID: 10979 RVA: 0x0001C654 File Offset: 0x0001A854
	private LuckyBoxManager()
	{
		this.m_RewardItems = new List<ItemDNA>();
		this.m_RewardItems.Clear();
		this.m_DiamondItems = new List<ItemDNA>();
		this.m_DiamondItems.Clear();
	}

	// Token: 0x06002AE4 RID: 10980 RVA: 0x0001C688 File Offset: 0x0001A888
	public static LuckyBoxManager smethod_0()
	{
		if (LuckyBoxManager._LuckyBoxInstance == null)
		{
			LuckyBoxManager._LuckyBoxInstance = new LuckyBoxManager();
		}
		return LuckyBoxManager._LuckyBoxInstance;
	}

	// Token: 0x06002AE5 RID: 10981 RVA: 0x0001C6A0 File Offset: 0x0001A8A0
	public void method_0()
	{
		this.m_bLuckyBoxOpened = false;
		this.m_bLockedLuckyBoxOpened = false;
		this.m_nOpenIndex = 0;
		this.m_nLockedOpenIndex = 0;
		this.m_RewardItems.Clear();
		this.m_DiamondItems.Clear();
	}

	// Token: 0x06002AE6 RID: 10982 RVA: 0x000C869C File Offset: 0x000C689C
	public void method_1(int int_0, bool bool_0)
	{
		if (bool_0)
		{
			if (this.m_bLockedLuckyBoxOpened)
			{
				return;
			}
			if (!ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().Dictionary_1.ContainsKey(LuckyBoxRank.Diamond))
			{
				return;
			}
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().Dictionary_1[LuckyBoxRank.Diamond].Count <= 0)
			{
				return;
			}
			this.m_bLockedLuckyBoxOpened = true;
			this.m_nLockedOpenIndex = int_0;
		}
		else
		{
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_3() == AntiAddiction.Level.NoRewards)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().vmethod_7();
				if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>().Boolean_0)
				{
					(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>() as uniHUDWrapupView).method_4();
				}
				if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().Boolean_0)
				{
					(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>() as uniHUDPvPInfoView).method_13();
				}
				return;
			}
			if (this.m_bLuckyBoxOpened)
			{
				return;
			}
			this.m_bLuckyBoxOpened = true;
			this.m_nOpenIndex = int_0;
		}
		DebugUtils.Log(LogCategory.GUI, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + " open lucky box " + bool_0.ToString());
		MonoSingleton<AppManager>.Instance.method_0().imethod_0("UI_Mission_Reward");
		OnAccessSingleton<ILuckyBoxService, LuckyBoxService, LuckyBoxServiceOffline>.Prop_0.imethod_0(new OnLuckyBoxOpened(this.OnLuckyBoxOpened), int_0, bool_0);
	}

	// Token: 0x06002AE7 RID: 10983 RVA: 0x000C87E4 File Offset: 0x000C69E4
	public void method_2()
	{
		Random random = new Random();
		int num = random.Next(1, 4);
		this.method_1(num, false);
	}

	// Token: 0x06002AE8 RID: 10984 RVA: 0x000C8808 File Offset: 0x000C6A08
	public void OnLuckyBoxOpened(bool locked, int index, ItemDNA rewardedItem, ItemDNA dummyItem1, ItemDNA dummyItem2)
	{
		if (!locked)
		{
			this.m_RewardItems.Clear();
			this.m_bLuckyBoxOpened = true;
		}
		else
		{
			this.m_DiamondItems.Clear();
			this.m_bLockedLuckyBoxOpened = true;
		}
		if (rewardedItem == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "rewardedItem is null");
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
			{
				ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(),
				" get rewardedItem ",
				rewardedItem.m_type.ToString(),
				" itemID:",
				rewardedItem.m_itemId.ToString(),
				" Locked:",
				locked.ToString()
			}));
			if (!locked)
			{
				this.m_RewardItems.Add(rewardedItem);
			}
			else
			{
				this.m_DiamondItems.Add(rewardedItem);
			}
		}
		if (dummyItem1 == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "dummyItem1 is null");
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
			{
				ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(),
				" get dummyItem1 ",
				dummyItem1.m_type.ToString(),
				" itemID:",
				dummyItem1.m_itemId.ToString(),
				" Locked:",
				locked.ToString()
			}));
			if (!locked)
			{
				this.m_RewardItems.Add(dummyItem1);
			}
			else
			{
				this.m_DiamondItems.Add(dummyItem1);
			}
		}
		if (dummyItem2 == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "dummyItem2 is null");
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
			{
				ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(),
				" get dummyItem2 ",
				dummyItem2.m_type.ToString(),
				" itemID:",
				dummyItem2.m_itemId.ToString(),
				" Locked:",
				locked.ToString()
			}));
			if (!locked)
			{
				this.m_RewardItems.Add(dummyItem2);
			}
			else
			{
				this.m_DiamondItems.Add(dummyItem2);
			}
		}
		TreasureBoxBehaviour.smethod_0();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().vmethod_6(locked);
	}

	// Token: 0x06002AE9 RID: 10985 RVA: 0x0001C6D4 File Offset: 0x0001A8D4
	public int method_3(bool bool_0 = false)
	{
		if (!bool_0)
		{
			return this.m_nOpenIndex;
		}
		return this.m_nLockedOpenIndex;
	}

	// Token: 0x06002AEA RID: 10986 RVA: 0x0001C6E6 File Offset: 0x0001A8E6
	public int method_4(bool bool_0 = false)
	{
		if (!bool_0)
		{
			return this.m_RewardItems.Count;
		}
		return this.m_DiamondItems.Count;
	}

	// Token: 0x06002AEB RID: 10987 RVA: 0x0001C702 File Offset: 0x0001A902
	public ItemDNA method_5(bool bool_0 = false)
	{
		if (!bool_0)
		{
			if (this.m_RewardItems.Count == 0)
			{
				return null;
			}
			return this.m_RewardItems[0];
		}
		else
		{
			if (this.m_DiamondItems.Count == 0)
			{
				return null;
			}
			return this.m_DiamondItems[0];
		}
	}

	// Token: 0x06002AEC RID: 10988 RVA: 0x000C8A20 File Offset: 0x000C6C20
	public ItemDNA method_6(int int_0, bool bool_0 = false)
	{
		if (!bool_0)
		{
			if (int_0 >= 0 && int_0 <= this.m_RewardItems.Count - 1)
			{
				return this.m_RewardItems[int_0];
			}
			return null;
		}
		else
		{
			if (int_0 >= 0 && int_0 <= this.m_DiamondItems.Count - 1)
			{
				return this.m_DiamondItems[int_0];
			}
			return null;
		}
	}

	// Token: 0x06002AED RID: 10989 RVA: 0x000C8A20 File Offset: 0x000C6C20
	public ItemDNA method_7(int int_0, bool bool_0 = false)
	{
		if (!bool_0)
		{
			if (int_0 >= 0 && int_0 <= this.m_RewardItems.Count - 1)
			{
				return this.m_RewardItems[int_0];
			}
			return null;
		}
		else
		{
			if (int_0 >= 0 && int_0 <= this.m_DiamondItems.Count - 1)
			{
				return this.m_DiamondItems[int_0];
			}
			return null;
		}
	}

	// Token: 0x04001E1B RID: 7707
	protected static LuckyBoxManager _LuckyBoxInstance;

	// Token: 0x04001E1C RID: 7708
	public bool m_bLuckyBoxOpened;

	// Token: 0x04001E1D RID: 7709
	public bool m_bLockedLuckyBoxOpened;

	// Token: 0x04001E1E RID: 7710
	private int m_nOpenIndex;

	// Token: 0x04001E1F RID: 7711
	private int m_nLockedOpenIndex;

	// Token: 0x04001E20 RID: 7712
	private List<ItemDNA> m_RewardItems;

	// Token: 0x04001E21 RID: 7713
	private List<ItemDNA> m_DiamondItems;
}
