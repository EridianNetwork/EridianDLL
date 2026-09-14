using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200075B RID: 1883
public class WeaponCraftView : BaseView
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x060031D9 RID: 12761 RVA: 0x000207E3 File Offset: 0x0001E9E3
	// (set) Token: 0x060031DA RID: 12762 RVA: 0x000207EB File Offset: 0x0001E9EB
	public ParticleManager ParticleManager_0
	{
		get
		{
			return this.m_particleManager;
		}
		set
		{
			this.m_particleManager = value;
		}
	}

	// Token: 0x060031DB RID: 12763 RVA: 0x000E2338 File Offset: 0x000E0538
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.method_3();
		this._currencyListener = new WeaponCraftView.currencyUpdateListener();
		this._currencyListener.RootView = this;
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this._currencyListener);
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			this._iMyCurrency = MonoSingleton<Session>.Instance.GetLocalPlayer().m_bondCurrency;
		}
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x060031DC RID: 12764 RVA: 0x000207F4 File Offset: 0x0001E9F4
	protected GameObject GameObject_0
	{
		get
		{
			if (this.m_parentModel == null)
			{
				this.m_parentModel = this.m_particleManager.method_0("UI", "PTL").gameObject;
			}
			return this.m_parentModel;
		}
	}

	// Token: 0x060031DD RID: 12765 RVA: 0x000E23B0 File Offset: 0x000E05B0
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._craftUIDataDic.Clear();
		this._craftUIDataDic = null;
		this._craftUIConfigList.Clear();
		this._craftUIConfigList = null;
		this._currencyListener = null;
		if (this.m_particleManager != null)
		{
			this.m_particleManager.method_1();
			global::UnityEngine.Object.DestroyObject(this.m_particleManager.gameObject);
			this.m_particleManager = null;
		}
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x060031DE RID: 12766 RVA: 0x0002082A File Offset: 0x0001EA2A
	public virtual void vmethod_5(int int_0)
	{
		this._iMyCurrency = int_0;
	}

	// Token: 0x17000266 RID: 614
	// (get) Token: 0x060031DF RID: 12767 RVA: 0x00020833 File Offset: 0x0001EA33
	public new bool Boolean_0
	{
		get
		{
			return this._bIsCrafting;
		}
	}

	// Token: 0x060031E0 RID: 12768 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6(bool bool_0)
	{
	}

	// Token: 0x060031E1 RID: 12769 RVA: 0x0002083B File Offset: 0x0001EA3B
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this.m_particleManager != null)
		{
			this.m_particleManager.method_2();
		}
	}

	// Token: 0x060031E2 RID: 12770 RVA: 0x000E2430 File Offset: 0x000E0630
	protected void method_3()
	{
		this._craftUIDataDic = new Dictionary<int, UICraftData>();
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/UI_WeaponCraft");
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(UI_WeaponCraftConfigContainer));
		UI_WeaponCraftConfigContainer ui_WeaponCraftConfigContainer = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as UI_WeaponCraftConfigContainer;
		Resources.UnloadAsset(textAsset);
		this._craftUIConfigList = new List<UI_WeaponCraftConfig>(ui_WeaponCraftConfigContainer.UI_WeaponCraftConfigList);
		this._craftUIConfigList.Sort(new Comparison<UI_WeaponCraftConfig>(this.method_4));
	}

	// Token: 0x060031E3 RID: 12771 RVA: 0x0002085E File Offset: 0x0001EA5E
	protected int method_4(UI_WeaponCraftConfig ui_WeaponCraftConfig_0, UI_WeaponCraftConfig ui_WeaponCraftConfig_1)
	{
		return ui_WeaponCraftConfig_0.Stage - ui_WeaponCraftConfig_1.Stage;
	}

	// Token: 0x060031E4 RID: 12772 RVA: 0x000E24B0 File Offset: 0x000E06B0
	public UICraftData method_5(int int_0)
	{
		UICraftData uicraftData = null;
		this._craftUIDataDic.TryGetValue(int_0, out uicraftData);
		return uicraftData;
	}

	// Token: 0x060031E5 RID: 12773 RVA: 0x0000311D File Offset: 0x0000131D
	protected bool method_6(UICraftData uicraftData_0)
	{
		return false;
	}

	// Token: 0x0400226E RID: 8814
	protected Dictionary<int, UICraftData> _craftUIDataDic = new Dictionary<int, UICraftData>();

	// Token: 0x0400226F RID: 8815
	protected List<UI_WeaponCraftConfig> _craftUIConfigList = new List<UI_WeaponCraftConfig>();

	// Token: 0x04002270 RID: 8816
	protected WeaponCraftView.currencyUpdateListener _currencyListener;

	// Token: 0x04002271 RID: 8817
	protected int _iOnCraftWeaponID;

	// Token: 0x04002272 RID: 8818
	protected bool _bIsCrafting;

	// Token: 0x04002273 RID: 8819
	protected int _iMyCurrency = -1;

	// Token: 0x04002274 RID: 8820
	protected List<int> m_pistolIDs = new List<int>();

	// Token: 0x04002275 RID: 8821
	protected List<int> m_shotgunIDs = new List<int>();

	// Token: 0x04002276 RID: 8822
	protected List<int> m_SMGIDs = new List<int>();

	// Token: 0x04002277 RID: 8823
	protected List<int> m_sniperIDs = new List<int>();

	// Token: 0x04002278 RID: 8824
	protected ParticleManager m_particleManager;

	// Token: 0x04002279 RID: 8825
	private GameObject m_parentModel;

	// Token: 0x0200075C RID: 1884
	protected class currencyUpdateListener : ICharacterServiceNotificationListerner
	{
		// Token: 0x060031E7 RID: 12775 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		// Token: 0x060031E8 RID: 12776 RVA: 0x0002086D File Offset: 0x0001EA6D
		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (this.RootView == null)
			{
				return;
			}
			this.RootView.vmethod_5(currency.BondCurrency);
		}

		// Token: 0x060031E9 RID: 12777 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}

		// Token: 0x060031EB RID: 12779 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnGetCharacterSettings(string strSettings)
		{
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetCharacterSettings(int iResult)
		{
		}

		// Token: 0x0400227A RID: 8826
		public WeaponCraftView RootView;
	}
}
