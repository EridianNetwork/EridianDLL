using System;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020008BF RID: 2239
public class uniWeaponPreviewView : WeaponPreviewView
{
	// Token: 0x06003DC5 RID: 15813 RVA: 0x0012699C File Offset: 0x00124B9C
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Weapon_review.swf", "MainPanel", new FuncLoad(this.method_7));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Tips.swf", "Panel_Tips_Card", new FuncLoad(this.method_5));
	}

	// Token: 0x06003DC6 RID: 15814 RVA: 0x00126A0C File Offset: 0x00124C0C
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.m_WeaponCard = null;
		this.m_PreviewPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Weapon_review.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Tips.swf");
	}

	// Token: 0x06003DC7 RID: 15815 RVA: 0x00029B66 File Offset: 0x00027D66
	private void method_5(MovieClip movieClip_0)
	{
		this.m_WeaponCard = new ItemCardPanel();
		this.m_WeaponCard.method_0(new MovieClip());
		this.m_WeaponCard.vmethod_2(movieClip_0);
		this.method_6();
	}

	// Token: 0x06003DC8 RID: 15816 RVA: 0x00126A60 File Offset: 0x00124C60
	private void method_6()
	{
		if (this.m_PreviewPanel != null && this.m_WeaponCard != null)
		{
			(this.m_PreviewPanel.DisplayObjectContainer_0 as MovieClip).stopAll();
			this.m_PreviewPanel.method_7(this.m_WeaponCard.DisplayObjectContainer_0);
			this.m_WeaponCard.DisplayObjectContainer_0.x = 0f;
			return;
		}
	}

	// Token: 0x06003DC9 RID: 15817 RVA: 0x00126AC0 File Offset: 0x00124CC0
	private void method_7(MovieClip movieClip_0)
	{
		this.m_PreviewPanel = new uniWeaponPreviewView.WeaponPreviewPanel();
		this.m_PreviewPanel.method_0(movieClip_0);
		this.m_PreviewPanel.addEventListener("Closing", new EventDispatcher.EventCallback(this.method_9));
		this._bWeaponResLoaded = true;
		this._bActive = true;
		this.method_6();
	}

	// Token: 0x06003DCA RID: 15818 RVA: 0x00029B96 File Offset: 0x00027D96
	public override bool vmethod_4()
	{
		if (this.m_PreviewPanel != null && this.m_PreviewPanel.Boolean_0)
		{
			this.vmethod_5();
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003DCB RID: 15819 RVA: 0x00126B18 File Offset: 0x00124D18
	public override void vmethod_5()
	{
		base.vmethod_5();
		if (this.m_PreviewPanel != null)
		{
			this.m_PreviewPanel.Boolean_0 = false;
		}
		if (this.m_ShowingModel != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.vmethod_7));
			global::UnityEngine.Object.DestroyObject(this.m_ShowingModel);
			this.m_ShowingModel = null;
		}
		if (this.m_WeaponCard != null)
		{
			this.m_WeaponCard.vmethod_3(null, null);
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_PreviewPanel);
	}

	// Token: 0x06003DCC RID: 15820 RVA: 0x00126BAC File Offset: 0x00124DAC
	public void method_8(ref GameObject gameObject_0, WeaponDNA weaponDNA_0)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(gameObject_0);
		skinnedMeshRenderer.material.SetTexture("_Cube", MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap);
		EntityWeapon.smethod_2(gameObject_0, EntityWeapon.smethod_1(weaponDNA_0.m_attribute));
		Vector3 center = skinnedMeshRenderer.bounds.center;
		float[] array = MonoSingleton<GraphicsMgr>.Instance.method_22().method_0();
		float[] array2 = MonoSingleton<GraphicsMgr>.Instance.method_22().method_1();
		float num = 1f;
		if (gameObject_0.name.ToLower().Contains("snr") && array.Length > 0 && array2.Length > 0)
		{
			num = array[0];
			this.mWpnRotSpeed = array2[0];
		}
		else if (gameObject_0.name.ToLower().Contains("smg") && array.Length > 1 && array2.Length > 1)
		{
			num = array[1];
			this.mWpnRotSpeed = array2[1];
		}
		else if (gameObject_0.name.ToLower().Contains("shn") && array.Length > 2 && array2.Length > 2)
		{
			num = array[2];
			this.mWpnRotSpeed = array2[2];
		}
		else if (gameObject_0.name.ToLower().Contains("rep") && array.Length > 3 && array2.Length > 3)
		{
			num = array[3];
			this.mWpnRotSpeed = array2[3];
		}
		else if (gameObject_0.name.ToLower().Contains("cor") && array.Length > 4 && array2.Length > 4)
		{
			num = array[4];
			this.mWpnRotSpeed = array2[4];
		}
		Vector3 vector = new Vector3(0f, 0f, num + 1f);
		MaterialHelper.smethod_2(gameObject_0);
		MonoSingleton<GraphicsMgr>.Instance.method_22().method_16(gameObject_0, vector, new Vector3(0f, 0f, 0f), true);
		this.m_ShowingModel = gameObject_0;
		this.m_ShowingModel.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
		vector = this.m_ShowingModel.transform.localPosition;
		vector += new Vector3(center.z, 0f, 0f);
		this.m_ShowingModel.transform.localPosition = vector;
		this.m_PreviewPanel.vmethod_2(MonoSingleton<GraphicsMgr>.Instance.method_22().method_13(), new Rect(0f, 0f, 1f, 1f));
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.vmethod_7), false);
	}

	// Token: 0x06003DCD RID: 15821 RVA: 0x00126E34 File Offset: 0x00125034
	public override void vmethod_6(WeaponDNA weaponDNA_0, bool bool_0 = true)
	{
		if (weaponDNA_0 == null)
		{
			return;
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_32(this.m_PreviewPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
		base.vmethod_6(weaponDNA_0, bool_0);
		if (this.m_PreviewPanel != null)
		{
			this.m_PreviewPanel.Boolean_0 = true;
			MonoSingleton<WeaponFactory>.Instance.method_1(weaponDNA_0, new WeaponFactory.WeaponCreatedCallBack(this.method_8));
			this.m_PreviewPanel.method_6(bool_0);
		}
		if (this.m_WeaponCard != null)
		{
			this.m_WeaponCard.vmethod_3(ItemDNA.smethod_2(weaponDNA_0), null);
		}
	}

	// Token: 0x06003DCE RID: 15822 RVA: 0x00029BBB File Offset: 0x00027DBB
	protected void method_9(CEvent cevent_0)
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		this.vmethod_5();
	}

	// Token: 0x04002B9A RID: 11162
	protected ItemCardPanel m_WeaponCard;

	// Token: 0x04002B9B RID: 11163
	protected uniWeaponPreviewView.WeaponPreviewPanel m_PreviewPanel;

	// Token: 0x04002B9C RID: 11164
	protected bool _bWeaponResLoaded;

	// Token: 0x020008C0 RID: 2240
	public class WeaponPreviewPanel : GClass51
	{
		// Token: 0x06003DD0 RID: 15824 RVA: 0x00029BDC File Offset: 0x00027DDC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			base.DisplayObjectContainer_0.visible = false;
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06003DD2 RID: 15826 RVA: 0x00023ADE File Offset: 0x00021CDE
		// (set) Token: 0x06003DD1 RID: 15825 RVA: 0x00027219 File Offset: 0x00025419
		public virtual bool Boolean_0
		{
			get
			{
				return base.DisplayObjectContainer_0.visible;
			}
			set
			{
				base.DisplayObjectContainer_0.visible = value;
			}
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x00029BF0 File Offset: 0x00027DF0
		public virtual void vmethod_2(Texture texture_0, Rect rect_0)
		{
			if (this.mcPortrait != null)
			{
				this.mcPortrait.vmethod_9(texture_0, rect_0);
			}
		}

		// Token: 0x06003DD4 RID: 15828 RVA: 0x00126ED4 File Offset: 0x001250D4
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcCancelBtn":
				this.mcCancelBtn = new GClass25();
				this.mcCancelBtn.method_0(movieClip);
				this.mcCancelBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
				flag = true;
				break;
			case "mcPortrait":
				this.mcPortrait = new GClass43();
				this.mcPortrait.method_0(movieClip);
				flag = true;
				break;
			case "mcBG":
				this.mcBG = movieClip;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x06003DD5 RID: 15829 RVA: 0x00029C07 File Offset: 0x00027E07
		protected void method_5(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent("Closing"));
		}

		// Token: 0x06003DD6 RID: 15830 RVA: 0x00029C1A File Offset: 0x00027E1A
		public void method_6(bool bool_0)
		{
			this.mcBG.visible = bool_0;
			this.mcCancelBtn.Boolean_1 = bool_0;
		}

		// Token: 0x06003DD7 RID: 15831 RVA: 0x00126FB0 File Offset: 0x001251B0
		public void method_7(DisplayObject displayObject_0)
		{
			int childIndex = base.DisplayObjectContainer_0.getChildIndex(this.mcPortrait.DisplayObjectContainer_0);
			base.DisplayObjectContainer_0.addChildAt(displayObject_0, childIndex);
		}

		// Token: 0x04002B9D RID: 11165
		protected GClass25 mcCancelBtn;

		// Token: 0x04002B9E RID: 11166
		protected MovieClip mcBG;

		// Token: 0x04002B9F RID: 11167
		protected GClass43 mcPortrait;
	}
}
