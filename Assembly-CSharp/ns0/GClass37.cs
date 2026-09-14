using System;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007A1 RID: 1953
	public class GClass37 : GClass26
	{
		// Token: 0x060033F5 RID: 13301 RVA: 0x00021F14 File Offset: 0x00020114
		public GClass37()
		{
			this.dictionary_0.Clear();
		}

		// Token: 0x060033F6 RID: 13302 RVA: 0x000EE194 File Offset: 0x000EC394
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.unityTextField_0 = movieClip.getChildByName<UnityTextField>("tfrank");
			this.unityTextField_1 = movieClip.getChildByName<UnityTextField>("tflevel");
			this.unityTextField_2 = movieClip.getChildByName<UnityTextField>("tfname");
			this.unityTextField_3 = movieClip.getChildByName<UnityTextField>("tfGuildName");
			this.unityTextField_4 = movieClip.getChildByName<UnityTextField>("tfPoint");
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("mc_self");
			this.movieClip_1.visible = false;
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x060033F7 RID: 13303 RVA: 0x00021F4C File Offset: 0x0002014C
		protected void method_19(CEvent cevent_0)
		{
			this.vmethod_13();
		}

		// Token: 0x060033F8 RID: 13304 RVA: 0x00021F54 File Offset: 0x00020154
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.vmethod_13();
		}

		// Token: 0x060033F9 RID: 13305 RVA: 0x000EE250 File Offset: 0x000EC450
		protected override void vmethod_13()
		{
			if (this.int_0 == -1)
			{
				return;
			}
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() == this.string_6)
			{
				if (!this.movieClip_1.visible)
				{
					this.movieClip_1.visible = true;
				}
			}
			else if (this.movieClip_1.visible)
			{
				this.movieClip_1.visible = false;
			}
		}

		// Token: 0x060033FA RID: 13306 RVA: 0x000EE2B4 File Offset: 0x000EC4B4
		public override void vmethod_15(int int_1, bool bool_8)
		{
			Rank rank;
			if (bool_8)
			{
				rank = LobbyManager.smethod_0().method_48(int_1);
			}
			else
			{
				rank = LobbyManager.smethod_0().method_49(int_1);
			}
			if (rank != null)
			{
				this.int_0 = rank.characterId;
				this.string_6 = rank.characterName;
				if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() == rank.characterName)
				{
					if (!this.movieClip_1.visible)
					{
						this.movieClip_1.visible = true;
					}
				}
				else if (this.movieClip_1.visible)
				{
					this.movieClip_1.visible = false;
				}
				if (FriendManager.smethod_0().method_26(rank.characterId))
				{
					this.unityTextField_0.Color_0 = this.color_0;
					this.unityTextField_1.Color_0 = this.color_0;
					this.unityTextField_2.Color_0 = this.color_0;
					this.unityTextField_3.Color_0 = this.color_0;
					this.unityTextField_4.Color_0 = this.color_0;
				}
				else if (GuildManager.smethod_0().method_7() && GuildManager.smethod_0().method_1(rank.characterId))
				{
					this.unityTextField_0.Color_0 = Color.green;
					this.unityTextField_1.Color_0 = Color.green;
					this.unityTextField_2.Color_0 = Color.green;
					this.unityTextField_3.Color_0 = Color.green;
					this.unityTextField_4.Color_0 = Color.green;
				}
				else
				{
					this.unityTextField_0.Color_0 = Color.white;
					this.unityTextField_1.Color_0 = Color.white;
					this.unityTextField_2.Color_0 = Color.white;
					this.unityTextField_3.Color_0 = Color.white;
					this.unityTextField_4.Color_0 = Color.white;
				}
				this.unityTextField_0.text = rank.rank.ToString();
				this.unityTextField_1.text = rank.level.ToString();
				this.unityTextField_2.text = rank.characterName;
				this.unityTextField_4.text = rank.LadderValue.ToString();
				if (rank.guildId != 0)
				{
					this.unityTextField_3.text = rank.guildName;
				}
				else
				{
					this.unityTextField_3.text = string.Empty;
				}
			}
		}

		// Token: 0x0400240B RID: 9227
		protected UnityTextField unityTextField_0;

		// Token: 0x0400240C RID: 9228
		protected UnityTextField unityTextField_1;

		// Token: 0x0400240D RID: 9229
		protected UnityTextField unityTextField_2;

		// Token: 0x0400240E RID: 9230
		protected UnityTextField unityTextField_3;

		// Token: 0x0400240F RID: 9231
		protected UnityTextField unityTextField_4;

		// Token: 0x04002410 RID: 9232
		protected MovieClip movieClip_1;

		// Token: 0x04002411 RID: 9233
		protected string string_6 = string.Empty;

		// Token: 0x04002412 RID: 9234
		protected Color color_0 = new Color(0.032f, 0.58f, 1f);
	}
}
