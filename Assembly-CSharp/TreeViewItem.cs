using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000B71 RID: 2929
[Serializable]
public class TreeViewItem
{
	// Token: 0x06004F73 RID: 20339 RVA: 0x00033DC7 File Offset: 0x00031FC7
	public TreeViewItem(TreeViewControl treeViewControl_0, TreeViewItem treeViewItem_0)
	{
		this.ParentControl = treeViewControl_0;
		this.Parent = treeViewItem_0;
		if (null == treeViewControl_0)
		{
			return;
		}
	}

	// Token: 0x06004F74 RID: 20340 RVA: 0x00150F10 File Offset: 0x0014F110
	public virtual TreeViewItem vmethod_0(string string_0)
	{
		TreeViewItem treeViewItem = new TreeViewItem(this.ParentControl, this)
		{
			Header = string_0
		};
		this.Items.Add(treeViewItem);
		return treeViewItem;
	}

	// Token: 0x06004F75 RID: 20341 RVA: 0x00150F40 File Offset: 0x0014F140
	public virtual TreeViewItem vmethod_1(string string_0, bool bool_0)
	{
		TreeViewItem treeViewItem = new TreeViewItem(this.ParentControl, this)
		{
			Header = string_0,
			IsExpanded = bool_0
		};
		this.Items.Add(treeViewItem);
		return treeViewItem;
	}

	// Token: 0x06004F76 RID: 20342 RVA: 0x00150F78 File Offset: 0x0014F178
	public TreeViewItem method_0(string string_0, bool bool_0, bool bool_1)
	{
		TreeViewItem treeViewItem = new TreeViewItem(this.ParentControl, this)
		{
			Header = string_0,
			IsExpanded = bool_0,
			IsCheckBox = true,
			IsChecked = bool_1
		};
		this.Items.Add(treeViewItem);
		return treeViewItem;
	}

	// Token: 0x06004F77 RID: 20343 RVA: 0x00033E04 File Offset: 0x00032004
	public bool method_1()
	{
		return this.Items != null && this.Items.Count != 0;
	}

	// Token: 0x06004F78 RID: 20344 RVA: 0x00033E1E File Offset: 0x0003201E
	public string method_2()
	{
		return (this.Parent == null) ? this.Header : (this.Parent.method_2() + "/" + this.Header);
	}

	// Token: 0x06004F79 RID: 20345 RVA: 0x00033E4B File Offset: 0x0003204B
	public bool method_3(TreeViewItem treeViewItem_0)
	{
		return this.Parent != null && (this.Parent.Equals(treeViewItem_0) || this.Parent.method_3(treeViewItem_0));
	}

	// Token: 0x06004F7A RID: 20346 RVA: 0x00150FC0 File Offset: 0x0014F1C0
	protected float method_4(Rect rect_0, Vector3 vector3_0)
	{
		if (rect_0.Contains(vector3_0))
		{
			return 0f;
		}
		float num = (rect_0.yMin + rect_0.yMax) * 0.5f;
		float y = vector3_0.y;
		return Mathf.Abs(num - y) / 50f;
	}

	// Token: 0x06004F7B RID: 20347 RVA: 0x0015100C File Offset: 0x0014F20C
	public virtual void vmethod_2(int int_0, TreeViewItem.SiblingOrder siblingOrder_0)
	{
		DebugUtils.Log(LogCategory.Default, "hey man, go to your inherit class");
		if (null == this.ParentControl)
		{
			return;
		}
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		for (int i = 0; i < int_0; i++)
		{
			this.ParentControl.method_2(TreeViewItem.TextureIcons.GUIDE);
		}
		if (!this.method_1())
		{
			bool flag;
			switch (siblingOrder_0)
			{
			case TreeViewItem.SiblingOrder.FIRST_CHILD:
				flag = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_NO_CHILD);
				break;
			case TreeViewItem.SiblingOrder.MIDDLE_CHILD:
				flag = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_NO_CHILD);
				break;
			case TreeViewItem.SiblingOrder.LAST_CHILD:
				flag = this.ParentControl.method_2(TreeViewItem.TextureIcons.LAST_SIBLING_NO_CHILD);
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				this.IsExpanded = !this.IsExpanded;
			}
		}
		else if (this.IsExpanded)
		{
			bool flag2;
			switch (siblingOrder_0)
			{
			case TreeViewItem.SiblingOrder.FIRST_CHILD:
				flag2 = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_EXPANDED);
				break;
			case TreeViewItem.SiblingOrder.MIDDLE_CHILD:
				flag2 = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_EXPANDED);
				break;
			case TreeViewItem.SiblingOrder.LAST_CHILD:
				flag2 = this.ParentControl.method_2(TreeViewItem.TextureIcons.LAST_SIBLING_EXPANDED);
				break;
			default:
				flag2 = false;
				break;
			}
			if (flag2)
			{
				this.IsExpanded = !this.IsExpanded;
			}
		}
		else
		{
			bool flag3;
			switch (siblingOrder_0)
			{
			case TreeViewItem.SiblingOrder.FIRST_CHILD:
				flag3 = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_COLLAPSED);
				break;
			case TreeViewItem.SiblingOrder.MIDDLE_CHILD:
				flag3 = this.ParentControl.method_2(TreeViewItem.TextureIcons.MIDDLE_SIBLING_COLLAPSED);
				break;
			case TreeViewItem.SiblingOrder.LAST_CHILD:
				flag3 = this.ParentControl.method_2(TreeViewItem.TextureIcons.LAST_SIBLING_COLLAPSED);
				break;
			default:
				flag3 = false;
				break;
			}
			if (flag3)
			{
				this.IsExpanded = !this.IsExpanded;
			}
		}
		if (!string.IsNullOrEmpty(this.Header))
		{
			bool flag4;
			if (this.ParentControl.SelectedItem == this && !this.ParentControl.m_forceDefaultSkin)
			{
				GUI.skin = this.ParentControl.m_skinSelected;
				flag4 = true;
			}
			else
			{
				flag4 = false;
			}
			if (this.IsCheckBox)
			{
				if (this.IsChecked && this.ParentControl.method_2(TreeViewItem.TextureIcons.NORMAL_CHECKED))
				{
					this.IsChecked = false;
					if (this.ParentControl.SelectedItem != this)
					{
						this.ParentControl.SelectedItem = this;
						this.IsSelected = true;
						if (this.Selected != null)
						{
							this.Selected(this, new TreeViewItem.SelectedEventArgs());
						}
					}
					if (this.Unchecked != null)
					{
						this.Unchecked(this, new TreeViewItem.UncheckedEventArgs());
					}
				}
				else if (!this.IsChecked && this.ParentControl.method_2(TreeViewItem.TextureIcons.NORMAL_UNCHECKED))
				{
					this.IsChecked = true;
					if (this.ParentControl.SelectedItem != this)
					{
						this.ParentControl.SelectedItem = this;
						this.IsSelected = true;
						if (this.Selected != null)
						{
							this.Selected(this, new TreeViewItem.SelectedEventArgs());
						}
					}
					if (this.Checked != null)
					{
						this.Checked(this, new TreeViewItem.CheckedEventArgs());
					}
				}
				this.ParentControl.method_2(TreeViewItem.TextureIcons.BLANK);
			}
			if (this.ParentControl.IsHoverEnabled)
			{
				GUISkin skin = GUI.skin;
				if (flag4)
				{
					GUI.skin = this.ParentControl.m_skinSelected;
				}
				else if (this.IsHover)
				{
					GUI.skin = this.ParentControl.m_skinHover;
				}
				else
				{
					GUI.skin = this.ParentControl.m_skinUnselected;
				}
				if (this.ParentControl.IsHoverAnimationEnabled)
				{
					GUI.skin.button.fontSize = (int)Mathf.Lerp(20f, 12f, this.m_hoverTime);
				}
				GUI.SetNextControlName("toggleButton");
				if (GUILayout.Button(this.Header, new GUILayoutOption[0]))
				{
					GUI.FocusControl("toggleButton");
					if (this.ParentControl.SelectedItem != this)
					{
						this.ParentControl.SelectedItem = this;
						this.IsSelected = true;
						if (this.Selected != null)
						{
							this.Selected(this, new TreeViewItem.SelectedEventArgs());
						}
					}
					if (this.Click != null)
					{
						this.Click(this, new TreeViewItem.ClickEventArgs());
					}
				}
				GUI.skin = skin;
			}
			else
			{
				GUI.SetNextControlName("toggleButton");
				if (GUILayout.Button(this.Header, new GUILayoutOption[0]))
				{
					GUI.FocusControl("toggleButton");
					if (this.ParentControl.SelectedItem != this)
					{
						this.ParentControl.SelectedItem = this;
						this.IsSelected = true;
						if (this.Selected != null)
						{
							this.Selected(this, new TreeViewItem.SelectedEventArgs());
						}
					}
					if (this.Click != null)
					{
						this.Click(this, new TreeViewItem.ClickEventArgs());
					}
				}
			}
			if (flag4 && !this.ParentControl.m_forceDefaultSkin)
			{
				GUI.skin = this.ParentControl.m_skinUnselected;
			}
		}
		GUILayout.EndHorizontal();
		if (this.ParentControl.IsHoverEnabled && Event.current != null && Event.current.type == EventType.Repaint)
		{
			Vector2 mousePosition = Event.current.mousePosition;
			if (this.ParentControl.method_4(mousePosition))
			{
				Rect lastRect = GUILayoutUtility.GetLastRect();
				if (lastRect.Contains(mousePosition))
				{
					this.IsHover = true;
					this.ParentControl.HoverItem = this;
				}
				else
				{
					this.IsHover = false;
				}
				if (this.ParentControl.IsHoverEnabled && this.ParentControl.IsHoverAnimationEnabled)
				{
					this.m_hoverTime = this.method_4(lastRect, Event.current.mousePosition);
				}
			}
		}
		if (this.method_1() && this.IsExpanded)
		{
			for (int j = 0; j < this.Items.Count; j++)
			{
				TreeViewItem treeViewItem = this.Items[j];
				treeViewItem.Parent = this;
				if (j + 1 == this.Items.Count)
				{
					treeViewItem.vmethod_2(int_0 + 1, TreeViewItem.SiblingOrder.LAST_CHILD);
				}
				else if (j == 0)
				{
					treeViewItem.vmethod_2(int_0 + 1, TreeViewItem.SiblingOrder.FIRST_CHILD);
				}
				else
				{
					treeViewItem.vmethod_2(int_0 + 1, TreeViewItem.SiblingOrder.MIDDLE_CHILD);
				}
			}
		}
		if (this.IsSelected && this.ParentControl.SelectedItem != this && this.Unselected != null)
		{
			this.Unselected(this, new TreeViewItem.UnselectedEventArgs());
		}
		this.IsSelected = this.ParentControl.SelectedItem == this;
	}

	// Token: 0x04003B89 RID: 15241
	public string Header = string.Empty;

	// Token: 0x04003B8A RID: 15242
	public bool IsExpanded = true;

	// Token: 0x04003B8B RID: 15243
	public bool IsCheckBox;

	// Token: 0x04003B8C RID: 15244
	public bool IsChecked;

	// Token: 0x04003B8D RID: 15245
	public bool IsHover;

	// Token: 0x04003B8E RID: 15246
	public bool IsSelected;

	// Token: 0x04003B8F RID: 15247
	public List<TreeViewItem> Items = new List<TreeViewItem>();

	// Token: 0x04003B90 RID: 15248
	public TreeViewControl ParentControl;

	// Token: 0x04003B91 RID: 15249
	public TreeViewItem Parent;

	// Token: 0x04003B92 RID: 15250
	public object DataContext;

	// Token: 0x04003B93 RID: 15251
	public EventHandler Click;

	// Token: 0x04003B94 RID: 15252
	public EventHandler Checked;

	// Token: 0x04003B95 RID: 15253
	public EventHandler Unchecked;

	// Token: 0x04003B96 RID: 15254
	public EventHandler Selected;

	// Token: 0x04003B97 RID: 15255
	public EventHandler Unselected;

	// Token: 0x04003B98 RID: 15256
	protected float m_hoverTime;

	// Token: 0x02000B72 RID: 2930
	public class ClickEventArgs : EventArgs
	{
	}

	// Token: 0x02000B73 RID: 2931
	public class CheckedEventArgs : EventArgs
	{
	}

	// Token: 0x02000B74 RID: 2932
	public class UncheckedEventArgs : EventArgs
	{
	}

	// Token: 0x02000B75 RID: 2933
	public class SelectedEventArgs : EventArgs
	{
	}

	// Token: 0x02000B76 RID: 2934
	public class UnselectedEventArgs : EventArgs
	{
	}

	// Token: 0x02000B77 RID: 2935
	public enum SiblingOrder
	{
		// Token: 0x04003B9A RID: 15258
		FIRST_CHILD,
		// Token: 0x04003B9B RID: 15259
		MIDDLE_CHILD,
		// Token: 0x04003B9C RID: 15260
		LAST_CHILD
	}

	// Token: 0x02000B78 RID: 2936
	public enum TextureIcons
	{
		// Token: 0x04003B9E RID: 15262
		BLANK,
		// Token: 0x04003B9F RID: 15263
		GUIDE,
		// Token: 0x04003BA0 RID: 15264
		LAST_SIBLING_COLLAPSED,
		// Token: 0x04003BA1 RID: 15265
		LAST_SIBLING_EXPANDED,
		// Token: 0x04003BA2 RID: 15266
		LAST_SIBLING_NO_CHILD,
		// Token: 0x04003BA3 RID: 15267
		MIDDLE_SIBLING_COLLAPSED,
		// Token: 0x04003BA4 RID: 15268
		MIDDLE_SIBLING_EXPANDED,
		// Token: 0x04003BA5 RID: 15269
		MIDDLE_SIBLING_NO_CHILD,
		// Token: 0x04003BA6 RID: 15270
		NORMAL_CHECKED,
		// Token: 0x04003BA7 RID: 15271
		NORMAL_UNCHECKED
	}
}
