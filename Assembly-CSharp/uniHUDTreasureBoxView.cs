using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

using System.Runtime.CompilerServices;
// Token: 0x02000840 RID: 2112
public class uniHUDTreasureBoxView : HUDTreasureBoxView
{
	// Token: 0x0600392F RID: 14639 RVA: 0x00026130 File Offset: 0x00024330
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("K-box.swf", "K_box", new FuncLoad(this.method_4));
	}

	// Token: 0x06003930 RID: 14640 RVA: 0x0010A018 File Offset: 0x00108218
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._treasureBoxPanel);
		this._treasureBoxPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("K-box.swf");
	}

	// Token: 0x06003931 RID: 14641 RVA: 0x0010A068 File Offset: 0x00108268
	private void method_4(MovieClip movieClip_0)
	{
		this._treasureBoxPanel = new uniHUDTreasureBoxView.TreasureBoxPanel();
		this._treasureBoxPanel.method_0(movieClip_0);
		DebugUtils.Log(LogCategory.GUI, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + "Add Lucky box to top!!!" + DateTime.Today.ToString());
	}

	// Token: 0x06003932 RID: 14642 RVA: 0x0010A0B4 File Offset: 0x001082B4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._treasureBoxPanel != null)
		{
			if (bool_0)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._treasureBoxPanel);
			}
			this._treasureBoxPanel.Boolean_0 = bool_0;
		}
		else if (bool_0)
		{
			DebugUtils.Log(LogCategory.GUI, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + " Lucky box view is null!!!" + DateTime.Today.ToString());
		}
	}

	// Token: 0x06003933 RID: 14643 RVA: 0x00026162 File Offset: 0x00024362
	public override void vmethod_5(Texture texture_0)
	{
		base.vmethod_5(texture_0);
		if (this._treasureBoxPanel != null)
		{
			this._treasureBoxPanel.method_7(texture_0);
		}
	}

	// Token: 0x06003934 RID: 14644 RVA: 0x0010A128 File Offset: 0x00108328
	public override void vmethod_6(bool bool_0 = false)
	{
		base.vmethod_6(bool_0);
		if (this._treasureBoxPanel != null)
		{
			this._treasureBoxPanel.method_10(bool_0);
			(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>() as uniHUDWrapupView).method_4();
			(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>() as uniHUDPvPInfoView).method_13();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.DefaultCursor);
		}
	}

	// Token: 0x06003935 RID: 14645 RVA: 0x0002617F File Offset: 0x0002437F
	public override void vmethod_7()
	{
		base.vmethod_7();
		if (this._treasureBoxPanel != null)
		{
			this._treasureBoxPanel.method_9();
		}
	}

	// Token: 0x06003936 RID: 14646 RVA: 0x0002619A File Offset: 0x0002439A
	public void method_5(bool bool_0 = false)
	{
		if (this._treasureBoxPanel != null)
		{
			this._treasureBoxPanel.method_8(bool_0);
		}
	}

	// Token: 0x040027FA RID: 10234
	private uniHUDTreasureBoxView.TreasureBoxPanel _treasureBoxPanel;

	// Token: 0x02000841 RID: 2113
	private class TreasureBox : GClass24
	{
		// Token: 0x06003937 RID: 14647 RVA: 0x000261B0 File Offset: 0x000243B0
		public TreasureBox(bool bool_4)
		{
			this.m_bIsLocked = bool_4;
			this.m_imageLoader = new GClass43();
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x0010A194 File Offset: 0x00108394
		public void method_10(MovieClip movieClip_1, MovieClip movieClip_2)
		{
			if (movieClip_2 != null)
			{
				base.method_0(movieClip_2);
				this.mc_Slot = movieClip_2;
				this.mc_Slot.visible = false;
				this.m_imageLoader.method_0(this.mc_Slot.getChildByName<MovieClip>("icons"));
			}
			if (movieClip_1 != null)
			{
				this.mc_Box = movieClip_1;
				this.mc_BoxStyle = this.mc_Box.getChildByName<MovieClip>("mc_boxStyle");
			}
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x0010A1FC File Offset: 0x001083FC
		public void method_11()
		{
			this.mc_Box.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this.mc_Box.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_13));
			this.mc_Box.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_14));
			this.m_tfNumber = this.mc_Slot.getChildByName<TextField>("textNumber");
			this.m_tfNumber.text = string.Empty;
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x0010A288 File Offset: 0x00108488
		protected void method_12(CEvent cevent_0)
		{
			MouseEvent mouseEvent = (MouseEvent)cevent_0;
			if (mouseEvent != null && mouseEvent.buttonId == 1)
			{
				return;
			}
			int num = int.Parse(this.mc_Box.name.Substring(this.mc_Box.name.Length - 1, 1));
			LuckyBoxManager.smethod_0().method_1(num, this.m_bIsLocked);
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x000261D5 File Offset: 0x000243D5
		protected void method_13(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.HandOpen);
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x000261E7 File Offset: 0x000243E7
		protected void method_14(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.DefaultCursor);
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x0010A2E4 File Offset: 0x001084E4
		public void method_15(string string_0)
		{
			if (this.mc_BoxStyle != null)
			{
				if (!this.m_bIsLocked)
				{
					this.mc_BoxStyle.gotoAndStop(string_0);
				}
				else if (string_0 == "weapon_load_pic")
				{
					this.mc_BoxStyle.gotoAndStop(string_0);
				}
				else
				{
					this.mc_BoxStyle.gotoAndStop("diamond");
				}
			}
		}

		// Token: 0x0600393E RID: 14654 RVA: 0x0010A33C File Offset: 0x0010853C
		public void method_16(ItemDNA itemDNA_0)
		{
			if (itemDNA_0 != null)
			{
				this.m_itemDNA = itemDNA_0;
				this.mc_Box.addFrameScript("flashoutEnd", new EventDispatcher.EventCallback(this.method_17));
				this.mc_Box.gotoAndPlay("flashout");
				this.mc_Box.removeEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
				this.mc_Box.removeEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_13));
				this.mc_Box.removeEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_14));
			}
		}

		// Token: 0x0600393F RID: 14655 RVA: 0x0010A3DC File Offset: 0x001085DC
		protected void method_17(CEvent cevent_0)
		{
			this.mc_Box.removeFrameScript("flashoutEnd", new EventDispatcher.EventCallback(this.method_17));
			this.mc_Box.visible = false;
			this.mc_Slot.visible = true;
			if (this.m_itemDNA.m_type == ItemType.Material)
			{
				MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(this.m_itemDNA);
				movieClip.alpha = this.m_fAlpha;
				movieClip.name = "icon";
				MovieClip childByName = this.mc_Slot.getChildByName<MovieClip>("icons");
				childByName.stopAll();
				childByName.addChild(movieClip);
			}
			else if (this.m_itemDNA.m_type == ItemType.Money)
			{
				MovieClip movieClip2 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_22();
				movieClip2.alpha = this.m_fAlpha;
				movieClip2.name = "icon";
				MovieClip childByName2 = this.mc_Slot.getChildByName<MovieClip>("icons");
				childByName2.stopAll();
				childByName2.addChild(movieClip2);
				this.m_tfNumber.text = this.m_itemDNA.m_value.ToString();
			}
			else
			{
				Texture2D texture2D = MonoSingleton<DNAPortrait>.Instance.method_3(this.m_itemDNA, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
				this.m_imageLoader.vmethod_8(texture2D);
			}
			if (this.m_itemDNA.m_type != ItemType.Money)
			{
				base.GInterface1_0 = new ItemTips(this.m_itemDNA);
			}
			int num = int.Parse(this.mc_Box.name.Substring(this.mc_Box.name.Length - 1, 1));
			if (num == LuckyBoxManager.smethod_0().method_3(this.m_bIsLocked))
			{
				this.mc_Slot.addFrameScript("selected", new EventDispatcher.EventCallback(this.method_19));
				this.mc_Slot.gotoAndStop("selected");
				(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>() as uniHUDTreasureBoxView).method_5(this.m_bIsLocked);
			}
			else
			{
				this.mc_Slot.addFrameScript("unpicked", new EventDispatcher.EventCallback(this.method_20));
				this.mc_Slot.gotoAndStop("unpicked");
			}
		}

		// Token: 0x06003940 RID: 14656 RVA: 0x000261F9 File Offset: 0x000243F9
		private void method_18()
		{
			this.m_tfNumber = this.mc_Slot.getChildByName<TextField>("textNumber");
			this.m_tfNumber.text = string.Empty;
		}

		// Token: 0x06003941 RID: 14657 RVA: 0x00026221 File Offset: 0x00024421
		protected void method_19(CEvent cevent_0)
		{
			this.mc_Slot.removeFrameScript("selected", new EventDispatcher.EventCallback(this.method_19));
			this.method_18();
		}

		// Token: 0x06003942 RID: 14658 RVA: 0x00026246 File Offset: 0x00024446
		protected void method_20(CEvent cevent_0)
		{
			this.mc_Slot.removeFrameScript("unpicked", new EventDispatcher.EventCallback(this.method_20));
			this.method_18();
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x0010A600 File Offset: 0x00108800
		protected void method_21(CEvent cevent_0)
		{
			this.mc_Box.removeFrameScript("weapon_load_pic", new EventDispatcher.EventCallback(this.method_21));
			this.m_tfNumber.text = Utility.smethod_5("x", this.m_itemDNA.m_value.ToString());
			MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(this.m_itemDNA);
			movieClip.alpha = this.m_fAlpha;
			movieClip.name = "icon";
			MovieClip childByName = this.mc_Box.getChildByName<MovieClip>("icons");
			childByName.stopAll();
			childByName.addChild(movieClip);
		}

		// Token: 0x040027FB RID: 10235
		public MovieClip mc_Box;

		// Token: 0x040027FC RID: 10236
		public MovieClip mc_Slot;

		// Token: 0x040027FD RID: 10237
		public MovieClip mc_BoxStyle;

		// Token: 0x040027FE RID: 10238
		public GClass43 m_imageLoader;

		// Token: 0x040027FF RID: 10239
		public ItemDNA m_itemDNA;

		// Token: 0x04002800 RID: 10240
		private bool m_bIsLocked;

		// Token: 0x04002801 RID: 10241
		protected TextField m_tfNumber;

		// Token: 0x04002802 RID: 10242
		private float m_fAlpha = 1f;
	}

	// Token: 0x02000842 RID: 2114
	private class TreasureBoxPanel : GClass51
	{
		public MovieClip mc_root;

		private GClass25 mc_CloseBtn;

		private MovieClip mc_Box1;

		private MovieClip mc_Box2;

		private MovieClip mc_Box3;

		private TextField tf_Keys;

		private List<TreasureBox> m_BoxList;

		protected GClass43 LuckyBoxLoader;

		protected GameObject LuckyBoxObj;

		[CompilerGenerated]
		private static Dictionary<string, int> f__switch_map1F;

		public virtual bool Boolean_0
		{
			get
			{
				if (mc_root != null)
				{
					return mc_root.visible;
				}
				return false;
			}
			set
			{
				if (mc_root == null)
				{
					return;
				}
				if (value)
				{
					for (int i = 0; i < m_BoxList.Count; i++)
					{
						m_BoxList[i].method_11();
					}
					method_5();
					mc_root.visible = true;
					mc_root.gotoAndPlay("fadein");
					tf_Keys.text = ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().method_3()
						.ToString();
				}
				else
				{
					mc_root.gotoAndPlay("fadeout");
				}
			}
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			mc_root = displayObjectContainer_0 as MovieClip;
			if (mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: TreasureBoxPanel onInit() 'mc_root' is null! TreasureBoxPanel won't work!!!");
				return;
			}
			m_BoxList = new List<TreasureBox>();
			m_BoxList.Clear();
			mc_root.stopAll();
			mc_root.visible = false;
			mc_CloseBtn = new GClass25();
			mc_CloseBtn.method_0(mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_closeButton"));
			mc_CloseBtn.Boolean_6 = false;
			tf_Keys = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<TextField>("textAccount");
			mc_Box1 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box1");
			mc_Box2 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box2");
			mc_Box3 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box3");
			TreasureBox treasureBox = new TreasureBox(bool_4: false);
			treasureBox.method_10(mc_Box1, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot1"));
			TreasureBox treasureBox2 = new TreasureBox(bool_4: false);
			treasureBox2.method_10(mc_Box2, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot2"));
			TreasureBox treasureBox3 = new TreasureBox(bool_4: false);
			treasureBox3.method_10(mc_Box3, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot3"));
			MovieClip childByName = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box4");
			MovieClip childByName2 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box5");
			MovieClip childByName3 = mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_box6");
			TreasureBox treasureBox4 = new TreasureBox(bool_4: true);
			treasureBox4.method_10(childByName, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot4"));
			TreasureBox treasureBox5 = new TreasureBox(bool_4: true);
			treasureBox5.method_10(childByName2, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot5"));
			TreasureBox treasureBox6 = new TreasureBox(bool_4: true);
			treasureBox6.method_10(childByName3, mc_root.getChildByName<MovieClip>("mc_Total").getChildByName<MovieClip>("mc_slot6"));
			m_BoxList.Add(treasureBox);
			m_BoxList.Add(treasureBox2);
			m_BoxList.Add(treasureBox3);
			m_BoxList.Add(treasureBox4);
			m_BoxList.Add(treasureBox5);
			m_BoxList.Add(treasureBox6);
			method_5();
			LuckyBoxObj = Resources.Load("Graphics/LuckyBox_UI") as GameObject;
			if (LuckyBoxObj == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "Prefab LuckyBox_UI is NULL!!!");
				return;
			}
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(LuckyBoxObj);
			gameObject.transform.position = new Vector3(-1500f, -1500f, -1500f);
		}

		private void method_5()
		{
			string text = "iron";
			switch (ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>().m_instanceGrade)
			{
			case InstanceGrade.S:
				text = "platinum";
				break;
			case InstanceGrade.A:
				text = "gold";
				break;
			case InstanceGrade.B:
				text = "silver";
				break;
			case InstanceGrade.C:
				text = "bronze";
				break;
			case InstanceGrade.D:
				text = "iron";
				break;
			}
			for (int i = 0; i < m_BoxList.Count; i++)
			{
				m_BoxList[i].method_15(text);
			}
		}

		protected void method_6(CEvent cevent_0)
		{
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = false;
		}

		public void method_7(Texture texture_0)
		{
			LuckyBoxLoader.vmethod_8(texture_0);
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
			{
				if (f__switch_map1F == null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcAvatar", 0);
					f__switch_map1F = dictionary;
				}
				if (f__switch_map1F.TryGetValue(name, out var value) && value == 0)
				{
					movieClip.stopAll();
					LuckyBoxLoader = new GClass43();
					LuckyBoxLoader.method_0(movieClip);
					result = true;
				}
			}
			return result;
		}

		public void method_8(bool bool_0 = false)
		{
			int num = LuckyBoxManager.smethod_0().method_3(bool_0);
			int num2 = 1;
			if (!bool_0)
			{
				for (int i = 0; i < 3; i++)
				{
					if (i != num - 1)
					{
						m_BoxList[i].method_16(LuckyBoxManager.smethod_0().method_6(num2, bool_0));
						num2++;
					}
				}
				return;
			}
			for (int j = 3; j < 6; j++)
			{
				if (j != num - 1)
				{
					m_BoxList[j].method_16(LuckyBoxManager.smethod_0().method_6(num2, bool_0));
					num2++;
				}
			}
		}

		public void method_9()
		{
			if (!mc_CloseBtn.Boolean_6)
			{
				mc_CloseBtn.Boolean_6 = true;
				mc_CloseBtn.addEventListener(MouseEvent.CLICK, method_6);
			}
		}

		public void method_10(bool bool_0 = false)
		{
			int num = LuckyBoxManager.smethod_0().method_3(bool_0);
			if (num != 0)
			{
				if (bool_0)
				{
					tf_Keys.text = Utility.smethod_8(ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().method_3() - 1);
				}
				m_BoxList[num - 1].method_16(LuckyBoxManager.smethod_0().method_5(bool_0));
			}
			else
			{
				tf_Keys.text = Utility.smethod_8(ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().method_3());
			}
			if (!mc_CloseBtn.Boolean_6)
			{
				mc_CloseBtn.Boolean_6 = true;
				mc_CloseBtn.addEventListener(MouseEvent.CLICK, method_6);
			}
		}
	}
}
