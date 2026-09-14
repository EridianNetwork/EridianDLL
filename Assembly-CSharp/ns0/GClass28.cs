using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

namespace ns0
{
	// Token: 0x02000793 RID: 1939
	public class GClass28 : GClass26
	{
		// Token: 0x06003379 RID: 13177 RVA: 0x000EBCC0 File Offset: 0x000E9EC0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("online_status");
			this.movieClip_2 = this.movieClip_1.getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = this.movieClip_1.getChildByName<TextField>("tflv");
			this.textField_2 = this.movieClip_1.getChildByName<TextField>("tfname");
			this.textField_3 = this.movieClip_1.getChildByName<TextField>("tfposition");
			this.movieClip_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x0600337A RID: 13178 RVA: 0x000EBD74 File Offset: 0x000E9F74
		protected void method_19(CEvent cevent_0)
		{
			MouseEvent mouseEvent = (MouseEvent)cevent_0;
			if (mouseEvent != null && mouseEvent.buttonId == 1)
			{
				FriendManager.smethod_0().method_19(this.int_0);
			}
		}

		// Token: 0x0600337B RID: 13179 RVA: 0x000EBDA4 File Offset: 0x000E9FA4
		public override void vmethod_14(int int_1)
		{
			Presence presence = FriendManager.smethod_0().method_2(int_1);
			if (presence != null)
			{
				this.int_0 = presence.mCharacterId;
				UnityTextField unityTextField = (UnityTextField)this.textField_1;
				UnityTextField unityTextField2 = (UnityTextField)this.textField_2;
				UnityTextField unityTextField3 = (UnityTextField)this.textField_3;
				if (presence.mIsOnline)
				{
					unityTextField2.Color_0 = Color.white;
					unityTextField.Color_0 = Color.yellow;
					unityTextField3.Color_0 = Color.white;
					if (presence.mCurrentPlaylist != -1)
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString("Instance_" + presence.mCurrentPlaylist));
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
					this.textField_3.text = Utility.smethod_13(presence.mLastOnline);
				}
				this.textField_2.text = presence.mCharacterName;
				unityTextField.text = Utility.smethod_5("Lv:", Utility.smethod_8(presence.mCharacterLevel));
				AvatarType mAvatarType = presence.mAvatarType;
				this.movieClip_2.gotoAndStop(mAvatarType.ToString());
			}
		}

		// Token: 0x040023A1 RID: 9121
		protected MovieClip movieClip_1;

		// Token: 0x040023A2 RID: 9122
		protected MovieClip movieClip_2;

		// Token: 0x040023A3 RID: 9123
		protected TextField textField_1;

		// Token: 0x040023A4 RID: 9124
		protected TextField textField_2;

		// Token: 0x040023A5 RID: 9125
		protected TextField textField_3;
	}
}
