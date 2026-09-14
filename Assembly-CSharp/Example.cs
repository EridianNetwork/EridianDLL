using System;
using Core;
using UnityEngine;

// Token: 0x02000B6E RID: 2926
public class Example : MonoBehaviour
{
	// Token: 0x06004F5E RID: 20318 RVA: 0x00033C70 File Offset: 0x00031E70
	public void Start()
	{
		this.m_myTreeView = base.gameObject.GetComponent<TreeViewControl>();
		if (null == this.m_myTreeView)
		{
			DebugUtils.LogError(LogCategory.Default, "Use the tree view menu to add the control");
			return;
		}
		Example.smethod_3(this.m_myTreeView);
	}

	// Token: 0x06004F5F RID: 20319 RVA: 0x00033CA8 File Offset: 0x00031EA8
	public static void smethod_0(object sender, EventArgs e)
	{
		DebugUtils.Log(LogCategory.Default, string.Format("{0} detected: {1}", e.GetType().Name, (sender as TreeViewItem).Header));
	}

	// Token: 0x06004F60 RID: 20320 RVA: 0x00033CD0 File Offset: 0x00031ED0
	private static void smethod_1(out EventHandler eventHandler_0)
	{
		eventHandler_0 = new EventHandler(Example.smethod_0);
	}

	// Token: 0x06004F61 RID: 20321 RVA: 0x00033CE0 File Offset: 0x00031EE0
	private static void smethod_2(TreeViewItem treeViewItem_0)
	{
		Example.smethod_1(out treeViewItem_0.Click);
		Example.smethod_1(out treeViewItem_0.Checked);
		Example.smethod_1(out treeViewItem_0.Unchecked);
		Example.smethod_1(out treeViewItem_0.Selected);
		Example.smethod_1(out treeViewItem_0.Unselected);
	}

	// Token: 0x06004F62 RID: 20322 RVA: 0x001508BC File Offset: 0x0014EABC
	public static void smethod_3(TreeViewControl treeViewControl_0)
	{
		treeViewControl_0.Width = 600;
		treeViewControl_0.Height = 500;
		treeViewControl_0.String_0 = "Example.cs populated this treeview control";
		Example.smethod_2(treeViewControl_0.TreeViewItem_0);
		TreeViewItem treeViewItem = treeViewControl_0.TreeViewItem_0.vmethod_0("You can also add a tree view control");
		Example.smethod_2(treeViewItem);
		Example.smethod_2(treeViewItem.vmethod_0("to any existing game object by"));
		Example.smethod_2(treeViewItem.vmethod_0("selecting the game object and"));
		Example.smethod_2(treeViewItem.vmethod_0("using the menu item"));
		TreeViewItem treeViewItem2 = treeViewItem.vmethod_1("TreeView->Add Tree View to selected.", false);
		Example.smethod_2(treeViewItem2);
		Example.smethod_2(treeViewItem2.vmethod_0("You can also drag and drop the"));
		Example.smethod_2(treeViewItem2.vmethod_0("TreeViewControl script onto a"));
		Example.smethod_2(treeViewItem2.vmethod_0("game object."));
		Example.smethod_2(treeViewItem2.method_0("New checked and", false, true));
		Example.smethod_2(treeViewItem2.method_0("unchecked checkboxes", false, false));
	}

	// Token: 0x06004F63 RID: 20323 RVA: 0x001509A4 File Offset: 0x0014EBA4
	public void OnGUI()
	{
		if (null != this.m_myTreeView && this.m_myTreeView.SelectedItem != null && !string.IsNullOrEmpty(this.m_myTreeView.SelectedItem.Header))
		{
			GUILayout.Label(string.Format("Example selected: {0}", this.m_myTreeView.SelectedItem.Header), new GUILayoutOption[0]);
		}
	}

	// Token: 0x04003B66 RID: 15206
	public TreeViewControl m_myTreeView;
}
