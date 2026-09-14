using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.geom;
using UnityEngine;

// Token: 0x020008AB RID: 2219
public class uniTeamMateHpView : TeamMateHpView
{
	// Token: 0x06003CED RID: 15597 RVA: 0x00120B6C File Offset: 0x0011ED6C
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._hpPanel = new GClass51();
		this._mcContainer = new MovieClip();
		DisplayObject mcContainer = this._mcContainer;
		float num = 0f;
		this._mcContainer.y = num;
		mcContainer.x = num;
		this._mcContainer.width = 1280f;
		this._mcContainer.height = 720f;
		this._hpPanel.method_0(this._mcContainer);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_34(this._hpPanel);
		this.vmethod_5();
	}

	// Token: 0x06003CEE RID: 15598 RVA: 0x00120C08 File Offset: 0x0011EE08
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._hpPanel);
		this._hpPanel = null;
		this._htHpItems.Clear();
		MaskManager.smethod_0().method_2();
		this.vmethod_6();
	}

	// Token: 0x06003CEF RID: 15599 RVA: 0x00120C58 File Offset: 0x0011EE58
	public override void vmethod_7()
	{
		if (!_isShowTeammateHp)
		{
			if (_hpPanel != null)
			{
				_hpPanel.DisplayObjectContainer_0.visible = false;
			}
			return;
		}
		base.vmethod_7();
		int count = listTeammateId.Count;
		if (_htHpItems.Keys.Count > count)
		{
			method_6();
		}
		Camera camera_ = ns0.MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ == null)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			int int_ = listTeammateId[i];
			PlayerInfoSync playerInfoSync = ns0.MonoSingleton<Session>.Instance.method_36(int_);
			if (playerInfoSync == null)
			{
				break;
			}
			EntityPlayer entityPlayer = playerInfoSync.GetEntity() as EntityPlayer;
			HpItem hpItem = method_3(int_);
			if (entityPlayer == null)
			{
				hpItem?.method_6(bool_0: false);
				continue;
			}
			if (hpItem == null)
			{
				break;
			}
			if (!(entityPlayer != null))
			{
				continue;
			}
			Vector3 position = entityPlayer.method_114().transform.position;
			Vector3 position2 = camera_.WorldToViewportPoint(position + _yOffsetPos);
			bool flag = position2.z > 0f && position2.x > 0f && position2.x < 1f && position2.y > 0f && position2.y < 1f;
			hpItem.method_6(flag);
			if (!flag)
			{
				continue;
			}
			Vector3 vector = camera_.ViewportToScreenPoint(position2);
			Vector2 vector2_ = default(Vector2);
			vector2_.x = Mathf.CeilToInt(vector.x / GClass20.GClass20_0.Single_0);
			vector2_.y = Mathf.CeilToInt(((float)Screen.height - vector.y) / GClass20.GClass20_0.Single_0);
			float num = Vector3.Distance(camera_.transform.position, entityPlayer.transform.position);
			hpItem.method_9(Mathf.Clamp01(1f - num * 0.1f) + 0.5f);
			hpItem.method_5(vector2_);
			EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.vmethod_19();
			hpItem.method_11(equipmentInventoryEntity.vmethod_6(), equipmentInventoryEntity.vmethod_7());
			hpItem.method_10(equipmentInventoryEntity.vmethod_4(), equipmentInventoryEntity.vmethod_0());
			bool flag2 = false;
			Ray ray = new Ray(camera_.transform.position, entityPlayer.transform.position - camera_.transform.position);
			RaycastHit[] array = Physics.RaycastAll(ray, num, 1 << LayerMask.NameToLayer("Default"));
			for (int j = 0; j < array.Length; j++)
			{
				RaycastHit raycastHit = array[j];
				if (!(raycastHit.transform == _localPlayer.GetEntity().transform) && !(raycastHit.transform == entityPlayer.transform) && !(raycastHit.distance >= num))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				hpItem.method_8();
			}
			else
			{
				hpItem.method_8(1f);
			}
		}
	}
	// Token: 0x06003CF0 RID: 15600 RVA: 0x00120F7C File Offset: 0x0011F17C
	private uniTeamMateHpView.HpItem method_3(int int_0)
	{
		uniTeamMateHpView.HpItem hpItem = this._htHpItems[int_0] as uniTeamMateHpView.HpItem;
		if (hpItem == null)
		{
			hpItem = this.method_4(int_0);
		}
		return hpItem;
	}

	// Token: 0x06003CF1 RID: 15601 RVA: 0x00120FAC File Offset: 0x0011F1AC
	private uniTeamMateHpView.HpItem method_4(int int_0)
	{
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("SightBead.swf", "Panel_Hp");
		uniTeamMateHpView.HpItem hpItem = new uniTeamMateHpView.HpItem();
		hpItem.method_0(badAssMovieClip);
		this._mcContainer.addChild(hpItem.DisplayObjectContainer_0);
		this._htHpItems[int_0] = hpItem;
		return hpItem;
	}

	// Token: 0x06003CF2 RID: 15602 RVA: 0x00120FFC File Offset: 0x0011F1FC
	private void method_5(int int_0)
	{
		uniTeamMateHpView.HpItem hpItem = this._htHpItems[int_0] as uniTeamMateHpView.HpItem;
		this._mcContainer.removeChild(hpItem.DisplayObjectContainer_0);
		this._htHpItems.Remove(int_0);
	}

	// Token: 0x06003CF3 RID: 15603 RVA: 0x00121044 File Offset: 0x0011F244
	private void method_6()
	{
		if (this._htHpItems.Count <= 0)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (object obj in this._htHpItems)
		{
			int num = (int)((DictionaryEntry)obj).Key;
			if (!this.listTeammateId.Contains(num))
			{
				list.Add(num);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			this.method_5(list[i]);
		}
	}

	// Token: 0x04002AEF RID: 10991
	private GClass51 _hpPanel;

	// Token: 0x04002AF0 RID: 10992
	private MovieClip _mcContainer;

	// Token: 0x04002AF1 RID: 10993
	private Hashtable _htHpItems = new Hashtable();

	// Token: 0x04002AF2 RID: 10994
	private bool _isShowTeammateHp = true;

	// Token: 0x04002AF3 RID: 10995
	private Vector3 _yOffsetPos = new Vector3(0f, 0.4f, 0f);

	// Token: 0x020008AC RID: 2220
	private class HpItem : GClass51
	{
		// Token: 0x06003CF5 RID: 15605 RVA: 0x001210F8 File Offset: 0x0011F2F8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			}
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: uniTeamMateHpView::HpItem:onInit() 'mcSelf' is null! HpItem won't work!!!");
				return;
			}
			this.mcSelf.stop();
			this.mcInfo = this.mcSelf.getChildByName<MovieClip>("mcInfo");
			this.mcShieldBar = this.mcInfo.getChildByName<MovieClip>("mcShield");
			this.mcShieldBar.stop();
			this.mcHealthBar = this.mcInfo.getChildByName<MovieClip>("mcHealth");
			this.mcHealthBar.stop();
			this.mcHealthColorBar = this.mcHealthBar.getChildByName<MovieClip>("mc_hpbar");
			if (this.mcHealthBar != null)
			{
				this.mcHealthColorBar.gotoAndStop("GREEN");
				Rectangle bounds = this.mcHealthBar.getBounds(this.mcHealthColorBar);
				this.mcHealthBar.clipRect = bounds.rect;
			}
			MovieClip childByName = this.mcShieldBar.getChildByName<MovieClip>("mcProgressMask");
			if (childByName != null)
			{
				Rectangle bounds2 = this.mcShieldBar.getBounds(childByName);
				this.mcShieldBar.clipRect = bounds2.rect;
			}
			this.txtPlayer = this.mcSelf.getChildByName<UnityTextField>("playername");
			this.txtPlayer.visible = false;
		}

		// Token: 0x06003CF6 RID: 15606 RVA: 0x000291CA File Offset: 0x000273CA
		public void method_5(Vector2 vector2_0)
		{
			this.mcSelf.x = vector2_0.x;
			this.mcSelf.y = vector2_0.y;
		}

		// Token: 0x06003CF7 RID: 15607 RVA: 0x00027219 File Offset: 0x00025419
		public void method_6(bool bool_0)
		{
			base.DisplayObjectContainer_0.visible = bool_0;
		}

		// Token: 0x06003CF8 RID: 15608 RVA: 0x000291F0 File Offset: 0x000273F0
		public void method_7(string string_1)
		{
			this.txtPlayer.y = 0f;
			this.txtPlayer.visible = false;
			this.txtPlayer.text = string_1;
		}

		// Token: 0x06003CF9 RID: 15609 RVA: 0x0002921A File Offset: 0x0002741A
		public void method_8(float float_0 = 0.5f)
		{
			base.DisplayObjectContainer_0.alpha = float_0;
		}

		// Token: 0x06003CFA RID: 15610 RVA: 0x00029228 File Offset: 0x00027428
		public void method_9(float float_0 = 0.8f)
		{
			this.mcInfo.scaleX = float_0;
		}

		// Token: 0x06003CFB RID: 15611 RVA: 0x00121254 File Offset: 0x0011F454
		public void method_10(int int_0, int int_1)
		{
			if (this.mcHealthBar == null)
			{
				return;
			}
			if (int_0 == 0)
			{
				if (this.mcHealthBar.getCurrentFrame() <= 100)
				{
					this.mcHealthBar.gotoAndPlay(101);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				this.mcHealthBar.gotoAndStop(101 - num);
			}
		}

		// Token: 0x06003CFC RID: 15612 RVA: 0x001212BC File Offset: 0x0011F4BC
		public void method_11(int int_0, int int_1, bool bool_0 = true)
		{
			if (this.mcShieldBar == null)
			{
				return;
			}
			if (!bool_0)
			{
				this.mcShieldBar.visible = false;
				return;
			}
			this.mcShieldBar.visible = true;
			if (int_0 == 0)
			{
				if (int_1 == 0)
				{
					this.mcShieldBar.gotoAndStop(this.mcShieldBar.totalFrames);
				}
				else if (this.mcShieldBar.getCurrentFrame() <= 100)
				{
					this.mcShieldBar.gotoAndPlay(110);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				this.mcShieldBar.gotoAndStop(101 - num);
			}
		}

		// Token: 0x04002AF4 RID: 10996
		protected MovieClip mcSelf;

		// Token: 0x04002AF5 RID: 10997
		protected MovieClip mcRoot;

		// Token: 0x04002AF6 RID: 10998
		protected MovieClip mcInfo;

		// Token: 0x04002AF7 RID: 10999
		protected MovieClip mcShieldBar;

		// Token: 0x04002AF8 RID: 11000
		protected MovieClip mcHealthBar;

		// Token: 0x04002AF9 RID: 11001
		protected MovieClip mcHealthColorBar;

		// Token: 0x04002AFA RID: 11002
		protected UnityTextField txtPlayer;

		// Token: 0x04002AFB RID: 11003
		protected bool _bMaskSetted;
	}
}
