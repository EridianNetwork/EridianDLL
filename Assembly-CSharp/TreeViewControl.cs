using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000B6F RID: 2927
public class TreeViewControl : MonoBehaviour
{
	// Token: 0x17000804 RID: 2052
	// (get) Token: 0x06004F65 RID: 20325 RVA: 0x00150A08 File Offset: 0x0014EC08
	public TreeViewItem TreeViewItem_0
	{
		get
		{
			if (this.m_roomItem == null)
			{
				this.m_roomItem = new TreeViewItem(this, null)
				{
					Header = "Root item"
				};
			}
			return this.m_roomItem;
		}
	}

	// Token: 0x17000805 RID: 2053
	// (get) Token: 0x06004F66 RID: 20326 RVA: 0x00033D57 File Offset: 0x00031F57
	// (set) Token: 0x06004F67 RID: 20327 RVA: 0x00033D64 File Offset: 0x00031F64
	public string String_0
	{
		get
		{
			return this.TreeViewItem_0.Header;
		}
		set
		{
			this.TreeViewItem_0.Header = value;
		}
	}

	// Token: 0x17000806 RID: 2054
	// (get) Token: 0x06004F68 RID: 20328 RVA: 0x00033D72 File Offset: 0x00031F72
	// (set) Token: 0x06004F69 RID: 20329 RVA: 0x00033D7F File Offset: 0x00031F7F
	public object Object_0
	{
		get
		{
			return this.TreeViewItem_0.DataContext;
		}
		set
		{
			this.TreeViewItem_0.DataContext = value;
		}
	}

	// Token: 0x17000807 RID: 2055
	// (get) Token: 0x06004F6A RID: 20330 RVA: 0x00033D8D File Offset: 0x00031F8D
	// (set) Token: 0x06004F6B RID: 20331 RVA: 0x00033D9A File Offset: 0x00031F9A
	public List<TreeViewItem> List_0
	{
		get
		{
			return this.TreeViewItem_0.Items;
		}
		set
		{
			this.TreeViewItem_0.Items = value;
		}
	}

	// Token: 0x06004F6C RID: 20332 RVA: 0x00150A40 File Offset: 0x0014EC40
	private GUIStyle method_0(Texture2D texture2D_0)
	{
		return new GUIStyle
		{
			normal = 
			{
				background = texture2D_0
			}
		};
	}

	// Token: 0x06004F6D RID: 20333 RVA: 0x00150A60 File Offset: 0x0014EC60
	private bool method_1(Texture2D texture2D_0)
	{
		GUIStyle guistyle = this.method_0(texture2D_0);
		return GUILayout.Button(string.Empty, guistyle, new GUILayoutOption[]
		{
			GUILayout.Width((float)texture2D_0.width),
			GUILayout.MaxHeight((float)texture2D_0.height)
		});
	}

	// Token: 0x06004F6E RID: 20334 RVA: 0x00150AA4 File Offset: 0x0014ECA4
	public bool method_2(TreeViewItem.TextureIcons textureIcons_0)
	{
		switch (textureIcons_0)
		{
		case TreeViewItem.TextureIcons.BLANK:
			if (!(null == this.m_textureGuide) && !this.m_forceButtonText)
			{
				GUILayout.Label(string.Empty, this.method_0(this.m_textureBlank), new GUILayoutOption[]
				{
					GUILayout.MaxWidth(4f),
					GUILayout.MaxHeight((float)this.m_textureGuide.height)
				});
			}
			else
			{
				GUILayout.Label(string.Empty, new GUILayoutOption[] { GUILayout.MaxWidth(4f) });
			}
			return false;
		case TreeViewItem.TextureIcons.GUIDE:
			if (!(null == this.m_textureGuide) && !this.m_forceButtonText)
			{
				GUILayout.Label(string.Empty, this.method_0(this.m_textureGuide), new GUILayoutOption[]
				{
					GUILayout.MaxWidth((float)this.m_textureGuide.width),
					GUILayout.MaxHeight((float)this.m_textureGuide.height)
				});
			}
			else
			{
				GUILayout.Label("|", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
			}
			return false;
		case TreeViewItem.TextureIcons.LAST_SIBLING_COLLAPSED:
			if (!(null == this.m_textureLastSiblingCollapsed) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureLastSiblingCollapsed);
			}
			return GUILayout.Button("<", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.LAST_SIBLING_EXPANDED:
			if (!(null == this.m_textureLastSiblingExpanded) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureLastSiblingExpanded);
			}
			return GUILayout.Button(">", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.LAST_SIBLING_NO_CHILD:
			if (!(null == this.m_textureLastSiblingNoChild) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureLastSiblingNoChild);
			}
			return GUILayout.Button("-", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_COLLAPSED:
			if (!(null == this.m_textureMiddleSiblingCollapsed) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureMiddleSiblingCollapsed);
			}
			return GUILayout.Button("<", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_EXPANDED:
			if (!(null == this.m_textureMiddleSiblingExpanded) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureMiddleSiblingExpanded);
			}
			return GUILayout.Button(">", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_NO_CHILD:
			if (!(null == this.m_textureMiddleSiblingNoChild) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureMiddleSiblingNoChild);
			}
			return GUILayout.Button("-", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.NORMAL_CHECKED:
			if (!(null == this.m_textureNormalChecked) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureNormalChecked);
			}
			return GUILayout.Button("x", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		case TreeViewItem.TextureIcons.NORMAL_UNCHECKED:
			if (!(null == this.m_textureNormalUnchecked) && !this.m_forceButtonText)
			{
				return this.method_1(this.m_textureNormalUnchecked);
			}
			return GUILayout.Button("o", new GUILayoutOption[] { GUILayout.MaxWidth(16f) });
		default:
			return false;
		}
	}

	// Token: 0x06004F6F RID: 20335 RVA: 0x00150DDC File Offset: 0x0014EFDC
	public void method_3(TreeViewControl.DisplayTypes displayTypes_0)
	{
		if (!this.m_forceDefaultSkin)
		{
			GUI.skin = this.m_skinUnselected;
		}
		if (displayTypes_0 != TreeViewControl.DisplayTypes.USE_SCROLL_VIEW)
		{
			if (displayTypes_0 == TreeViewControl.DisplayTypes.USE_SCROLL_AREA)
			{
				GUILayout.BeginArea(new Rect((float)this.X, (float)this.Y, (float)this.Width, (float)this.Height));
				this.m_scrollView = GUILayout.BeginScrollView(this.m_scrollView, new GUILayoutOption[]
				{
					GUILayout.MaxWidth((float)this.Width),
					GUILayout.MaxHeight((float)this.Height)
				});
			}
		}
		else
		{
			this.m_scrollView = GUILayout.BeginScrollView(this.m_scrollView, new GUILayoutOption[]
			{
				GUILayout.MaxWidth((float)this.Width),
				GUILayout.MaxHeight((float)this.Height)
			});
		}
		this.TreeViewItem_0.vmethod_2(0, TreeViewItem.SiblingOrder.FIRST_CHILD);
		if (displayTypes_0 != TreeViewControl.DisplayTypes.USE_SCROLL_VIEW)
		{
			if (displayTypes_0 == TreeViewControl.DisplayTypes.USE_SCROLL_AREA)
			{
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
		}
		else
		{
			GUILayout.EndScrollView();
		}
		GUI.skin = null;
	}

	// Token: 0x06004F70 RID: 20336 RVA: 0x00150ED0 File Offset: 0x0014F0D0
	public bool method_4(Vector2 vector2_0)
	{
		Rect rect = new Rect(this.m_scrollView.x, this.m_scrollView.y, (float)this.Width, (float)this.Height);
		return rect.Contains(vector2_0);
	}

	// Token: 0x06004F71 RID: 20337 RVA: 0x00033DA8 File Offset: 0x00031FA8
	private void Start()
	{
		this.SelectedItem = null;
	}

	// Token: 0x06004F72 RID: 20338 RVA: 0x00033DB1 File Offset: 0x00031FB1
	private void OnGUI()
	{
		if (!this.DisplayOnGame)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Default, "treeview ongui!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
	}

	// Token: 0x04003B67 RID: 15207
	public int X;

	// Token: 0x04003B68 RID: 15208
	public int Y;

	// Token: 0x04003B69 RID: 15209
	public int Width = 400;

	// Token: 0x04003B6A RID: 15210
	public int Height = 400;

	// Token: 0x04003B6B RID: 15211
	public bool IsExpanded = true;

	// Token: 0x04003B6C RID: 15212
	public bool IsHoverEnabled = true;

	// Token: 0x04003B6D RID: 15213
	public bool IsHoverAnimationEnabled;

	// Token: 0x04003B6E RID: 15214
	public bool DisplayOnGame;

	// Token: 0x04003B6F RID: 15215
	public bool DisplayOnScene = true;

	// Token: 0x04003B70 RID: 15216
	public bool DisplayInInspector;

	// Token: 0x04003B71 RID: 15217
	public TreeViewItem m_roomItem;

	// Token: 0x04003B72 RID: 15218
	public GUISkin m_skinHover;

	// Token: 0x04003B73 RID: 15219
	public GUISkin m_skinUnselected;

	// Token: 0x04003B74 RID: 15220
	public GUISkin m_skinSelected;

	// Token: 0x04003B75 RID: 15221
	public Texture2D m_textureBlank;

	// Token: 0x04003B76 RID: 15222
	public Texture2D m_textureGuide;

	// Token: 0x04003B77 RID: 15223
	public Texture2D m_textureLastSiblingCollapsed;

	// Token: 0x04003B78 RID: 15224
	public Texture2D m_textureLastSiblingExpanded;

	// Token: 0x04003B79 RID: 15225
	public Texture2D m_textureLastSiblingNoChild;

	// Token: 0x04003B7A RID: 15226
	public Texture2D m_textureMiddleSiblingCollapsed;

	// Token: 0x04003B7B RID: 15227
	public Texture2D m_textureMiddleSiblingExpanded;

	// Token: 0x04003B7C RID: 15228
	public Texture2D m_textureMiddleSiblingNoChild;

	// Token: 0x04003B7D RID: 15229
	public Texture2D m_textureNormalChecked;

	// Token: 0x04003B7E RID: 15230
	public Texture2D m_textureNormalUnchecked;

	// Token: 0x04003B7F RID: 15231
	public Texture2D m_textureSelectedBackground;

	// Token: 0x04003B80 RID: 15232
	public bool m_forceButtonText;

	// Token: 0x04003B81 RID: 15233
	public bool m_forceDefaultSkin;

	// Token: 0x04003B82 RID: 15234
	public TreeViewItem HoverItem;

	// Token: 0x04003B83 RID: 15235
	public TreeViewItem SelectedItem;

	// Token: 0x04003B84 RID: 15236
	private Vector2 m_scrollView = Vector2.zero;

	// Token: 0x02000B70 RID: 2928
	public enum DisplayTypes
	{
		// Token: 0x04003B86 RID: 15238
		NONE,
		// Token: 0x04003B87 RID: 15239
		USE_SCROLL_VIEW,
		// Token: 0x04003B88 RID: 15240
		USE_SCROLL_AREA
	}
}
