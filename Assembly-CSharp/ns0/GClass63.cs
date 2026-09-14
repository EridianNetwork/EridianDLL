using System;
using pumpkin.display;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007CE RID: 1998
	public class GClass63 : GInterface2
	{
		// Token: 0x0600357C RID: 13692 RVA: 0x000F45A4 File Offset: 0x000F27A4
		public virtual bool imethod_0()
		{
			GClass20.GClass20_0.method_5("tips");
			MovieClip movieClip = new MovieClip("CommonLib.swf:HUDMask");
			DisplayObject displayObject = movieClip;
			float num = 512f;
			movieClip.scaleY = num;
			displayObject.scaleX = num;
			DisplayObject displayObject2 = movieClip;
			num = -256f;
			movieClip.y = num;
			displayObject2.x = num;
			movieClip.mouseEnabled = false;
			this.hudmaskPanel_0 = new UniUIManager.HUDMaskPanel();
			this.hudmaskPanel_0.method_0(movieClip);
			GClass20.GClass20_0.method_4(movieClip, "tips");
			return true;
		}

		// Token: 0x0600357D RID: 13693 RVA: 0x000F4628 File Offset: 0x000F2828
		public virtual DisplayObject imethod_1(GClass24 gclass24_0, GInterface1 ginterface1_0)
		{
			GClass62 gclass = ginterface1_0 as GClass62;
			if (gclass == null)
			{
				return null;
			}
			DisplayObject displayObject = gclass.vmethod_0();
			if (displayObject != null)
			{
				GClass20.GClass20_0.method_4(displayObject, "tips");
			}
			this.imethod_2(displayObject, gclass24_0, ginterface1_0);
			this.gclass62_0 = gclass;
			if (this.hudmaskPanel_0 != null)
			{
				this.hudmaskPanel_0.method_6(true);
			}
			return displayObject;
		}

		// Token: 0x0600357E RID: 13694 RVA: 0x000F4684 File Offset: 0x000F2884
		public virtual bool imethod_2(DisplayObject displayObject_0, GClass24 gclass24_0, GInterface1 ginterface1_0)
		{
			GClass62 gclass = ginterface1_0 as GClass62;
			if (gclass == null)
			{
				return false;
			}
			if (this.gclass62_0 != gclass)
			{
				this.gclass62_0 = gclass;
			}
			bool flag;
			if (gclass.genum2_0 == GEnum2.const_0)
			{
				flag = GClass63.smethod_0(displayObject_0, gclass24_0.DisplayObjectContainer_0);
			}
			else
			{
				flag = this.method_0(displayObject_0);
			}
			gclass.OnPositionAdjusted(gclass24_0, flag);
			return true;
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x0000311D File Offset: 0x0000131D
		public virtual bool imethod_3(DisplayObject[] displayObject_0)
		{
			return false;
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x000231D0 File Offset: 0x000213D0
		public virtual void imethod_4(DisplayObject displayObject_0)
		{
			if (this.gclass62_0 != null)
			{
				this.gclass62_0.OnClean();
			}
			if (displayObject_0 != null)
			{
				GClass20.GClass20_0.method_6(displayObject_0, "tips");
			}
			if (this.hudmaskPanel_0 != null)
			{
				this.hudmaskPanel_0.method_6(false);
			}
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x000F46D8 File Offset: 0x000F28D8
		private bool method_0(DisplayObject displayObject_0)
		{
			Vector2 vector = new Vector2(0f, 0f);
			DisplayObject displayObject = displayObject_0.getChildByName<MovieClip>("tipsFrame");
			if (displayObject == null)
			{
				displayObject = displayObject_0;
			}
			vector.x = displayObject_0.parent.mouseX;
			vector.y = displayObject_0.parent.mouseY;
			bool flag;
			if (!(flag = vector.x + displayObject.width < GClass20.GClass20_0.Single_1))
			{
				vector.x -= displayObject.width;
			}
			if (vector.x + displayObject.width > displayObject.stage.width)
			{
				vector.x = displayObject.stage.width - displayObject.width;
			}
			float num = vector.y + displayObject.height - GClass20.GClass20_0.Single_2;
			if (num > 0f)
			{
				vector.y -= num;
			}
			displayObject_0.x = vector.x;
			displayObject_0.y = vector.y;
			return flag;
		}

		// Token: 0x06003582 RID: 13698 RVA: 0x000F47E0 File Offset: 0x000F29E0
		public static bool smethod_0(DisplayObject displayObject_0, DisplayObject displayObject_1)
		{
			Vector2 vector = new Vector2(0f, 0f);
			vector = GClass20.GClass20_0.method_3(displayObject_1, vector);
			MovieClip movieClip = displayObject_0 as MovieClip;
			if (movieClip == null)
			{
				return true;
			}
			bool flag;
			if (flag = vector.x + displayObject_1.width + movieClip.width < GClass20.GClass20_0.Single_1)
			{
				vector.x += displayObject_1.width;
			}
			else
			{
				vector.x -= movieClip.width;
			}
			float num = vector.y + movieClip.height - GClass20.GClass20_0.Single_2;
			if (num > 0f)
			{
				vector.y -= num;
			}
			displayObject_0.x = vector.x;
			displayObject_0.y = vector.y;
			return flag;
		}

		// Token: 0x04002512 RID: 9490
		private const string string_0 = "tips";

		// Token: 0x04002513 RID: 9491
		protected GClass62 gclass62_0;

		// Token: 0x04002514 RID: 9492
		private UniUIManager.HUDMaskPanel hudmaskPanel_0;
	}
}
