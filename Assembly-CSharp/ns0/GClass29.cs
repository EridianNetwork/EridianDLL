using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

namespace ns0
{
	// Token: 0x02000794 RID: 1940
	public class GClass29 : GClass26
	{
		// Token: 0x0600337D RID: 13181 RVA: 0x000EBEF0 File Offset: 0x000EA0F0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mc_FriendItem");
			this.movieClip_1 = childByName.getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = childByName.getChildByName<TextField>("tflv");
			this.textField_2 = childByName.getChildByName<TextField>("tfname");
			this.textField_3 = childByName.getChildByName<TextField>("tfposition");
			this.gclass25_0 = new GClass25();
			this.gclass25_1 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("mc_accept"));
			this.gclass25_1.method_0(movieClip.getChildByName<MovieClip>("mc_reject"));
			this.gclass25_0.Boolean_1 = false;
			this.gclass25_1.Boolean_1 = false;
			this.gclass25_0.Boolean_6 = false;
			this.gclass25_1.Boolean_6 = false;
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
			this.movieClip_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_20));
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x00021903 File Offset: 0x0001FB03
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.gclass25_0.Boolean_1 = false;
			this.gclass25_1.Boolean_1 = false;
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x00021923 File Offset: 0x0001FB23
		protected void method_19(CEvent cevent_0)
		{
			this.gclass25_0.Boolean_1 = false;
			this.gclass25_1.Boolean_1 = false;
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x000EC01C File Offset: 0x000EA21C
		protected void method_20(CEvent cevent_0)
		{
			MouseEvent mouseEvent = (MouseEvent)cevent_0;
			if (mouseEvent != null && mouseEvent.buttonId == 0)
			{
				return;
			}
			if (this.int_0 == -1)
			{
				return;
			}
			if (this.int_0 == MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId)
			{
				return;
			}
			if (GroupManager.smethod_0().method_17(this.int_0) && FriendManager.smethod_0().method_26(this.int_0))
			{
				return;
			}
			MenuItemDef[] array = new MenuItemDef[2];
			array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Invitation"));
			array[0].itemData = this.int_0;
			if (GroupManager.smethod_0().method_18() && (!GroupManager.smethod_0().method_19() || GroupManager.smethod_0().method_17(this.int_0)))
			{
				array[0].itemFunc = null;
			}
			else if (this.presence_0 != null)
			{
				if (this.presence_0.mIsOnline)
				{
					array[0].itemFunc = new MenuItemProcessFunc(this.method_21);
				}
				else
				{
					array[0].itemFunc = null;
				}
			}
			else
			{
				array[0].itemFunc = null;
			}
			array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("Friend_Invitation"));
			array[1].itemData = this.int_0;
			if (!FriendManager.smethod_0().method_26(this.int_0))
			{
				if (this.presence_0 != null)
				{
					if (FriendManager.smethod_0().method_13() && this.presence_0.mIsOnline)
					{
						array[1].itemFunc = new MenuItemProcessFunc(this.method_22);
					}
					else
					{
						array[1].itemFunc = null;
					}
				}
				else
				{
					array[1].itemFunc = null;
				}
			}
			else
			{
				array[1].itemFunc = null;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
		}

		// Token: 0x06003381 RID: 13185 RVA: 0x000EC200 File Offset: 0x000EA400
		public override void vmethod_14(int int_1)
		{
			this.presence_0 = FriendManager.smethod_0().method_23(int_1);
			if (this.presence_0 != null)
			{
				this.int_0 = this.presence_0.mCharacterId;
				UnityTextField unityTextField = (UnityTextField)this.textField_1;
				UnityTextField unityTextField2 = (UnityTextField)this.textField_2;
				UnityTextField unityTextField3 = (UnityTextField)this.textField_3;
				if (this.presence_0.mIsOnline)
				{
					unityTextField2.Color_0 = Color.white;
					unityTextField.Color_0 = Color.yellow;
					unityTextField3.Color_0 = Color.white;
					if (this.presence_0.mCurrentPlaylist != -1)
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString("Instance_" + this.presence_0.mCurrentPlaylist));
					}
					else
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString("Instance_28"));
					}
				}
				else
				{
					unityTextField2.Color_0 = Color.gray;
					unityTextField.Color_0 = Color.gray;
					unityTextField3.Color_0 = Color.gray;
					this.textField_3.text = Utility.smethod_13(this.presence_0.mLastOnline);
				}
				this.textField_1.text = Utility.smethod_5("Lv.", Utility.smethod_8(this.presence_0.mCharacterLevel));
				this.textField_2.text = this.presence_0.mCharacterName;
				AvatarType mAvatarType = this.presence_0.mAvatarType;
				this.movieClip_1.gotoAndStop(mAvatarType.ToString());
			}
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x0002193D File Offset: 0x0001FB3D
		protected void method_21(object object_1)
		{
			GroupManager.smethod_0().method_0((int)object_1);
			GroupManager.smethod_0().method_14(object_1);
		}

		// Token: 0x06003383 RID: 13187 RVA: 0x0002195A File Offset: 0x0001FB5A
		protected void method_22(object object_1)
		{
			FriendManager.smethod_0().method_1((int)object_1);
			FriendManager.smethod_0().method_14(object_1);
		}

		// Token: 0x040023A6 RID: 9126
		protected MovieClip movieClip_1;

		// Token: 0x040023A7 RID: 9127
		protected TextField textField_1;

		// Token: 0x040023A8 RID: 9128
		protected TextField textField_2;

		// Token: 0x040023A9 RID: 9129
		protected TextField textField_3;

		// Token: 0x040023AA RID: 9130
		protected GClass25 gclass25_0;

		// Token: 0x040023AB RID: 9131
		protected GClass25 gclass25_1;

		// Token: 0x040023AC RID: 9132
		protected Presence presence_0;
	}
}
