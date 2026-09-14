using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x020007DB RID: 2011
internal class uniCharacterSelectView : CharacterSelectView
{
	// Token: 0x06003613 RID: 13843 RVA: 0x000F7E18 File Offset: 0x000F6018
	public override void vmethod_2()
	{
		this._panel = new GClass51();
		this.inProcessing = false;
		this._characterList = new List<uniCharacterSelectView.CharacterButton>();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("CharacterList.swf", "CharacterSelectPanel", new FuncLoad(this.method_3));
	}

	// Token: 0x06003614 RID: 13844 RVA: 0x000F7E6C File Offset: 0x000F606C
	private void method_3(MovieClip movieClip_0)
	{
		this._panel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		for (int i = 0; i < this.MAX_CHAR_COUNT; i++)
		{
			uniCharacterSelectView.CharacterButton characterButton = new uniCharacterSelectView.CharacterButton();
			characterButton.method_0(movieClip_0.getChildByName("item" + i) as MovieClip);
			characterButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.OnSwtichCharacter));
			this._characterList.Add(characterButton);
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panel);
		if (this._data != null)
		{
			this.method_4();
		}
	}

	// Token: 0x06003615 RID: 13845 RVA: 0x000F7F18 File Offset: 0x000F6118
	private void method_4()
	{
		if (this._characterList.Count > 0)
		{
			for (int i = 0; i < this.MAX_CHAR_COUNT; i++)
			{
				this._characterList[i].Boolean_3 = false;
				if (i < this._data.Count)
				{
					this._characterList[i].Boolean_6 = true;
					if (this._currentSelect == i)
					{
						this._characterList[i].Boolean_3 = true;
					}
					this._characterList[i].method_19();
					this._characterList[i].method_20(this._data[i].Name);
					this._characterList[i].method_21(this._data[i].Level);
					this._characterList[i].method_22(this._data[i].AvatarType.ToString());
					this._characterList[i].method_23(this._data[i].TimePlayed);
					this._characterList[i].addEventListener(GClass53.string_7, new EventDispatcher.EventCallback(this.OnDoubleClick));
				}
				else
				{
					this._characterList[i].Boolean_6 = false;
				}
			}
		}
		if (this.mcCreateBtn != null)
		{
			this.mcCreateBtn.Boolean_6 = this._data != null && this._data.Count < this.MAX_CHAR_COUNT;
		}
		if (this.mcDeleteBtn != null)
		{
			this.mcDeleteBtn.Boolean_6 = this._data.Count > 0;
		}
		if (this.mcEnterBtn != null)
		{
			this.mcEnterBtn.Boolean_6 = this._data.Count > 0;
		}
	}

	// Token: 0x06003616 RID: 13846 RVA: 0x000238A6 File Offset: 0x00021AA6
	private void OnDoubleClick(CEvent e)
	{
		if (this.inProcessing)
		{
			return;
		}
		if (this._logicBehaviour.inAnimation)
		{
			return;
		}
		this.vmethod_5(this._data[this._currentSelect].Id);
	}

	// Token: 0x06003617 RID: 13847 RVA: 0x000F80EC File Offset: 0x000F62EC
	public override void vmethod_10(List<Character> list_0)
	{
		base.vmethod_10(list_0);
		this._currentSelect = ((this._data.Count <= 0) ? (-1) : 0);
		this.method_4();
		if (this._currentSelect >= 0)
		{
			this.vmethod_9(this._data[this._currentSelect].Id);
		}
	}

	// Token: 0x06003618 RID: 13848 RVA: 0x000F8144 File Offset: 0x000F6344
	private void OnSwtichCharacter(CEvent e)
	{
		if (this.inProcessing)
		{
			return;
		}
		int num = this._characterList.IndexOf(e.currentTarget as uniCharacterSelectView.CharacterButton);
		if (num != -1 && num != this._currentSelect)
		{
			this._characterList[this._currentSelect].Boolean_3 = false;
			this.vmethod_11(num);
			this._characterList[this._currentSelect].Boolean_3 = true;
			this.vmethod_9(this._data[this._currentSelect].Id);
		}
	}

	// Token: 0x06003619 RID: 13849 RVA: 0x000238DB File Offset: 0x00021ADB
	private void OnEnterLobby(CEvent e)
	{
		this.vmethod_5(this._data[this._currentSelect].Id);
	}

	// Token: 0x0600361A RID: 13850 RVA: 0x000238F9 File Offset: 0x00021AF9
	private void method_5(CEvent cevent_0)
	{
		if (this._currentSelect < this._data.Count)
		{
			this.vmethod_6(this._currentSelect);
		}
	}

	// Token: 0x0600361B RID: 13851 RVA: 0x0002391A File Offset: 0x00021B1A
	public override void OnDeleteCharacter(bool success)
	{
		base.OnDeleteCharacter(success);
		if (success)
		{
			this.method_4();
		}
	}

	// Token: 0x0600361C RID: 13852 RVA: 0x0002392C File Offset: 0x00021B2C
	private void OnCreateCharacter(CEvent e)
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.ClassSelect, null);
	}

	// Token: 0x0600361D RID: 13853 RVA: 0x0002393F File Offset: 0x00021B3F
	public override void vmethod_7()
	{
		base.vmethod_7();
		this.inProcessing = true;
		this.mcDeleteBtn.Boolean_6 = false;
		this.mcCreateBtn.Boolean_6 = false;
		this.mcEnterBtn.Boolean_6 = false;
	}

	// Token: 0x0600361E RID: 13854 RVA: 0x000F81D0 File Offset: 0x000F63D0
	public override void vmethod_8()
	{
		base.vmethod_8();
		this.inProcessing = false;
		this.mcDeleteBtn.Boolean_6 = this._data.Count > 0;
		this.mcCreateBtn.Boolean_6 = this._data.Count < this.MAX_CHAR_COUNT;
		this.mcEnterBtn.Boolean_6 = this._data.Count > 0;
	}

	// Token: 0x0600361F RID: 13855 RVA: 0x000F823C File Offset: 0x000F643C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		this._panel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("CharacterList.swf");
	}

	// Token: 0x06003620 RID: 13856 RVA: 0x000F828C File Offset: 0x000F648C
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcSetBtn":
			this.mcSetBtn = new GClass25();
			this.mcSetBtn.method_0(movieClip);
			flag = true;
			this.mcSetBtn.Boolean_6 = false;
			this.mcSetBtn.Boolean_1 = false;
			break;
		case "mcDeleteBtn":
			this.mcDeleteBtn = new GClass25();
			this.mcDeleteBtn.method_0(movieClip);
			this.mcDeleteBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
			this.mcDeleteBtn.Boolean_6 = false;
			flag = true;
			break;
		case "mcCreateBtn":
			this.mcCreateBtn = new GClass25();
			this.mcCreateBtn.method_0(movieClip);
			this.mcCreateBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.OnCreateCharacter));
			flag = true;
			this.mcCreateBtn.Boolean_6 = true;
			break;
		case "mcEnterBtn":
			this.mcEnterBtn = new GClass25();
			this.mcEnterBtn.method_0(movieClip);
			this.mcEnterBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.OnEnterLobby));
			flag = true;
			break;
		}
		return flag;
	}

	// Token: 0x04002577 RID: 9591
	private GClass51 _panel;

	// Token: 0x04002578 RID: 9592
	private GClass25 mcSetBtn;

	// Token: 0x04002579 RID: 9593
	private GClass25 mcDeleteBtn;

	// Token: 0x0400257A RID: 9594
	private GClass25 mcCreateBtn;

	// Token: 0x0400257B RID: 9595
	private GClass25 mcEnterBtn;

	// Token: 0x0400257C RID: 9596
	private bool inProcessing;

	// Token: 0x0400257D RID: 9597
	private List<uniCharacterSelectView.CharacterButton> _characterList;

	// Token: 0x0400257E RID: 9598
	private int MAX_CHAR_COUNT = 5;

	// Token: 0x020007DC RID: 2012
	private class CharacterButton : GClass25
	{
		// Token: 0x06003622 RID: 13858 RVA: 0x000F8418 File Offset: 0x000F6618
		public void method_19()
		{
			MovieClip movieClip = this.movieClip_0.getChildByName("label") as MovieClip;
			(movieClip.getChildByName("tfClassLabel") as TextField).text = "Type:";
			(movieClip.getChildByName("tfTimeLabel") as TextField).text = " ";
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x000F8470 File Offset: 0x000F6670
		public void method_20(string string_6)
		{
			MovieClip movieClip = this.movieClip_0.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfName") as TextField;
			if (textField != null)
			{
				textField.text = string_6;
			}
		}

		// Token: 0x06003624 RID: 13860 RVA: 0x000F84B0 File Offset: 0x000F66B0
		public void method_21(int int_0)
		{
			MovieClip movieClip = this.movieClip_0.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfLevel") as TextField;
			if (textField != null)
			{
				textField.text = "Lv." + int_0;
			}
		}

		// Token: 0x06003625 RID: 13861 RVA: 0x000F8500 File Offset: 0x000F6700
		public void method_22(string string_6)
		{
			MovieClip movieClip = this.movieClip_0.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfClass") as TextField;
			if (textField != null)
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("CLASS_" + string_6));
			}
			MovieClip movieClip2 = this.movieClip_0.getChildByName("mcIcon") as MovieClip;
			movieClip2 = movieClip2.getChildByName("mcClassIcon") as MovieClip;
			movieClip2.gotoAndStop(string_6);
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x000F8580 File Offset: 0x000F6780
		public void method_23(int int_0)
		{
			MovieClip movieClip = this.movieClip_0.getChildByName("label") as MovieClip;
			TextField textField = movieClip.getChildByName("tfTime") as TextField;
			if (textField != null)
			{
				textField.text = Utility.smethod_12(int_0, 4, true);
			}
		}
	}
}
