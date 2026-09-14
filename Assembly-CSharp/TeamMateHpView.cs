using System;
using System.Collections.Generic;
using System.Linq;
using ns0;

// Token: 0x02000758 RID: 1880
public class TeamMateHpView : BaseView
{
	// Token: 0x060031C0 RID: 12736 RVA: 0x0002060D File Offset: 0x0001E80D
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
	}

	// Token: 0x060031C1 RID: 12737 RVA: 0x00020625 File Offset: 0x0001E825
	public virtual void vmethod_5()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.vmethod_7), true);
	}

	// Token: 0x060031C2 RID: 12738 RVA: 0x00020644 File Offset: 0x0001E844
	public virtual void vmethod_6()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.vmethod_7));
	}

	// Token: 0x060031C3 RID: 12739 RVA: 0x000E1FA4 File Offset: 0x000E01A4
	public virtual void vmethod_7()
	{
		if (this._localPlayer == null)
		{
			this._localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			return;
		}
		this.listTeammateId.Clear();
		int i = 0;
		int count = GroupManager.smethod_0().m_GroupInfoMap.Count;
		while (i < count)
		{
			Presence value = GroupManager.smethod_0().m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Value;
			if (value != null)
			{
				if (this._localPlayer.m_characterId != value.mCharacterId)
				{
					this.listTeammateId.Add(value.mCharacterId);
				}
			}
			i++;
		}
	}

	// Token: 0x04002266 RID: 8806
	protected PlayerInfoSync _localPlayer;

	// Token: 0x04002267 RID: 8807
	protected List<int> listTeammateId = new List<int>();
}
