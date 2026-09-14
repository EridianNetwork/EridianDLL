using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002A7 RID: 679
public class MenuManager : MonoBehaviour
{
	// Token: 0x06000EA2 RID: 3746 RVA: 0x00073F68 File Offset: 0x00072168
	private void Awake()
	{
		this.m_pages = new Dictionary<MenuManager.MenuPage, string>
		{
			{
				MenuManager.MenuPage.HostInstance,
				"HostMenu"
			},
			{
				MenuManager.MenuPage.SkillTree,
				"SkillTreeMenu"
			}
		};
	}

	// Token: 0x06000EA3 RID: 3747 RVA: 0x0000CD42 File Offset: 0x0000AF42
	public void method_0(MenuManager.MenuPage menuPage_0)
	{
		this.method_1();
		if (menuPage_0 != MenuManager.MenuPage.None)
		{
			base.gameObject.AddComponent(this.m_pages[menuPage_0]);
		}
	}

	// Token: 0x06000EA4 RID: 3748 RVA: 0x00073F9C File Offset: 0x0007219C
	private void method_1()
	{
		HostMenu component = base.GetComponent<HostMenu>();
		if (component != null)
		{
			global::UnityEngine.Object.Destroy(base.GetComponent<HostMenu>());
		}
		SkillTreeMenu component2 = base.GetComponent<SkillTreeMenu>();
		if (component2 != null)
		{
			component2.method_0();
			global::UnityEngine.Object.Destroy(base.GetComponent<SkillTreeMenu>());
		}
	}

	// Token: 0x04000D22 RID: 3362
	private Dictionary<MenuManager.MenuPage, string> m_pages;

	// Token: 0x020002A8 RID: 680
	public enum MenuPage
	{
		// Token: 0x04000D24 RID: 3364
		None,
		// Token: 0x04000D25 RID: 3365
		HostInstance,
		// Token: 0x04000D26 RID: 3366
		CheatMenu,
		// Token: 0x04000D27 RID: 3367
		SkillTree
	}
}
