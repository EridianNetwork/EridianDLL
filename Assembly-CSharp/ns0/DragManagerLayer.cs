using System;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007B8 RID: 1976
	public class DragManagerLayer : EventDispatcher
	{
		// Token: 0x060034F7 RID: 13559 RVA: 0x00022C8E File Offset: 0x00020E8E
		private DragManagerLayer()
		{
			this.displayObjectContainer_0 = GClass20.GClass20_0.Stage_0;
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x060034F8 RID: 13560 RVA: 0x00022CA6 File Offset: 0x00020EA6
		public static DragManagerLayer Instance
		{
			get
			{
				if (DragManagerLayer.dragLayerManager == null)
				{
					DragManagerLayer.dragLayerManager = new DragManagerLayer();
				}
				return DragManagerLayer.dragLayerManager;
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x060034F9 RID: 13561 RVA: 0x00022CBE File Offset: 0x00020EBE
		public bool Boolean_0
		{
			get
			{
				return this.bool_1;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x060034FA RID: 13562 RVA: 0x00022CC6 File Offset: 0x00020EC6
		public object Object_0
		{
			get
			{
				return this.object_2;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060034FB RID: 13563 RVA: 0x00022CCE File Offset: 0x00020ECE
		public MovieClip MovieClip_0
		{
			get
			{
				return this.movieClip_0;
			}
		}

		// Token: 0x060034FC RID: 13564 RVA: 0x000F0E5C File Offset: 0x000EF05C
		public MovieClip method_0(MovieClip movieClip_2, object object_3, object object_4, object object_5, DisplayObject displayObject_0, bool bool_2)
		{
			if (movieClip_2 == null)
			{
				return null;
			}
			this.bool_0 = true;
			MovieClip movieClip = null;
			if (object_3 is MovieClip)
			{
				MovieClip movieClip2 = object_3 as MovieClip;
				movieClip = movieClip2.newInstance();
				movieClip.mouseEnabled = false;
				if (movieClip2.isPlaying)
				{
					movieClip.gotoAndPlay(movieClip2.currentFrame);
				}
				else
				{
					movieClip.gotoAndStop(movieClip2.currentFrame);
				}
			}
			else if (object_3 is GClass43)
			{
				pumpkin.display.Sprite sprite = new pumpkin.display.Sprite();
				(object_3 as GClass43).method_10(sprite);
				movieClip = new MovieClip();
				movieClip.stopAll();
				movieClip.addChild(sprite);
				movieClip.mouseEnabled = false;
			}
			else if (object_3 == null)
			{
				movieClip = null;
			}
			this.movieClip_0 = movieClip;
			GClass20.GClass20_0.method_4(this.movieClip_0, "DragManagerLayer");
			this.int_0 = ((!bool_2) ? 0 : (-Mathf.FloorToInt(displayObject_0.width / 2f)));
			this.int_1 = ((!bool_2) ? 0 : (-Mathf.FloorToInt(displayObject_0.height / 2f)));
			if (displayObject_0 != null && displayObject_0 != movieClip && movieClip != null)
			{
				Vector2 vector = new Vector2(GClass20.GClass20_0.Stage_0.mouseX, GClass20.GClass20_0.Stage_0.mouseY);
				movieClip.x = vector.x + (float)this.int_0;
				movieClip.y = vector.y + (float)this.int_1;
			}
			this.method_2(object_4, object_5);
			if (movieClip_2 != null)
			{
				this.movieClip_1 = movieClip_2;
				this.movieClip_1.visible = movieClip_2.visible;
			}
			this.method_10();
			this.displayObjectContainer_0.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_5));
			this.displayObjectContainer_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_9));
			return this.movieClip_0;
		}

		// Token: 0x060034FD RID: 13565 RVA: 0x00022CD6 File Offset: 0x00020ED6
		public void method_1()
		{
			this.method_7(false);
		}

		// Token: 0x060034FE RID: 13566 RVA: 0x00022CDF File Offset: 0x00020EDF
		public void method_2(object object_3, object object_4)
		{
			this.bool_1 = true;
			this.object_2 = object_3;
			this.object_1 = object_4;
			this.object_0 = null;
			base.dispatchEvent(new GClass55("dragBegin", object_3, true, false));
		}

		// Token: 0x060034FF RID: 13567 RVA: 0x00022D11 File Offset: 0x00020F11
		public void method_3()
		{
			this.method_7(true);
		}

		// Token: 0x06003500 RID: 13568 RVA: 0x00022D1A File Offset: 0x00020F1A
		public void method_4()
		{
			if (this.Boolean_0)
			{
				this.method_6();
			}
		}

		// Token: 0x06003501 RID: 13569 RVA: 0x00022D2A File Offset: 0x00020F2A
		private void method_5(CEvent cevent_0)
		{
			this.method_6();
		}

		// Token: 0x06003502 RID: 13570 RVA: 0x000F1020 File Offset: 0x000EF220
		private void method_6()
		{
			if (this.movieClip_0 != null)
			{
				this.movieClip_0.x = this.movieClip_0.parent.mouseX + (float)this.int_0;
				this.movieClip_0.y = this.movieClip_0.parent.mouseY + (float)this.int_1;
			}
		}

		// Token: 0x06003503 RID: 13571 RVA: 0x00022D32 File Offset: 0x00020F32
		private void method_7(bool bool_2)
		{
			if (!this.bool_1)
			{
				return;
			}
			base.dispatchEvent(new GClass55("dragEnd", new GStruct0(bool_2, this.object_2, this.object_0, null), true, false));
			this.method_8();
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x000F107C File Offset: 0x000EF27C
		private void method_8()
		{
			this.object_0 = null;
			if (this.bool_0 && this.movieClip_0 != null)
			{
				this.movieClip_0.parent.removeChild(this.movieClip_0);
			}
			this.movieClip_0 = null;
			this.object_2 = null;
			this.displayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_5));
			this.displayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_9));
			this.displayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_11));
			this.int_1 = 0;
			this.int_0 = 0;
			this.bool_1 = false;
		}

		// Token: 0x06003505 RID: 13573 RVA: 0x00022D6E File Offset: 0x00020F6E
		private void method_9(CEvent cevent_0)
		{
			this.method_10();
		}

		// Token: 0x06003506 RID: 13574 RVA: 0x000F1130 File Offset: 0x000EF330
		public void method_10()
		{
			if (this.object_0 == null)
			{
				this.displayObjectContainer_0.removeEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_11));
			}
			else
			{
				this.displayObjectContainer_0.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_11));
			}
		}

		// Token: 0x06003507 RID: 13575 RVA: 0x00022D76 File Offset: 0x00020F76
		private void method_11(CEvent cevent_0)
		{
			this.method_1();
		}

		// Token: 0x06003508 RID: 13576 RVA: 0x00022D7E File Offset: 0x00020F7E
		public void method_12()
		{
			this.displayObjectContainer_0 = GClass20.GClass20_0.Stage_0;
			GClass20.GClass20_0.method_5("DragManagerLayer");
		}

		// Token: 0x040024A5 RID: 9381
		private const string string_0 = "DragManagerLayer";

		// Token: 0x040024A6 RID: 9382
		private static DragManagerLayer dragLayerManager;

		// Token: 0x040024A7 RID: 9383
		public bool bool_0;

		// Token: 0x040024A8 RID: 9384
		public int int_0;

		// Token: 0x040024A9 RID: 9385
		public int int_1;

		// Token: 0x040024AA RID: 9386
		public object object_0;

		// Token: 0x040024AB RID: 9387
		public object object_1;

		// Token: 0x040024AC RID: 9388
		private bool bool_1;

		// Token: 0x040024AD RID: 9389
		private object object_2;

		// Token: 0x040024AE RID: 9390
		private MovieClip movieClip_0;

		// Token: 0x040024AF RID: 9391
		private DisplayObjectContainer displayObjectContainer_0;

		// Token: 0x040024B0 RID: 9392
		private MovieClip movieClip_1;
	}
}
