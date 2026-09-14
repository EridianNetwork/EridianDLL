using System;
using pumpkin.display;
using pumpkin.swf;
using UnityEngine;

namespace ns0
{
	// Token: 0x0200079B RID: 1947
	public class GClass43 : GClass24
	{
		// Token: 0x060033A4 RID: 13220 RVA: 0x00021A6A File Offset: 0x0001FC6A
		public GClass43()
		{
			this.sprite_0 = new pumpkin.display.Sprite();
			this.material_0 = new Material(TextureManager.baseBitmapShader);
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060033A5 RID: 13221 RVA: 0x00021A98 File Offset: 0x0001FC98
		public virtual Texture Texture_0
		{
			get
			{
				return this.texture_0;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060033A6 RID: 13222 RVA: 0x00021AA0 File Offset: 0x0001FCA0
		public virtual pumpkin.display.Sprite Sprite_0
		{
			get
			{
				return this.sprite_0;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060033A7 RID: 13223 RVA: 0x00021AA8 File Offset: 0x0001FCA8
		// (set) Token: 0x060033A8 RID: 13224 RVA: 0x00021AB0 File Offset: 0x0001FCB0
		public virtual float Single_0
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		// Token: 0x1700028A RID: 650
		// (set) Token: 0x060033A9 RID: 13225 RVA: 0x00021AB9 File Offset: 0x0001FCB9
		public override bool Boolean_1
		{
			set
			{
				if (!this.bool_3 && value)
				{
					this.vmethod_11();
				}
				base.Boolean_1 = value;
			}
		}

		// Token: 0x060033AA RID: 13226 RVA: 0x00021AD3 File Offset: 0x0001FCD3
		public virtual void vmethod_8(Texture texture_1)
		{
			this.vmethod_9(texture_1, new Rect(0f, 0f, 1f, 1f));
		}

		// Token: 0x060033AB RID: 13227 RVA: 0x00021AF5 File Offset: 0x0001FCF5
		public virtual void vmethod_9(Texture texture_1, Rect rect_2)
		{
			this.vmethod_12();
			this.vmethod_10(texture_1, rect_2, this.rect_1);
		}

		// Token: 0x060033AC RID: 13228 RVA: 0x00021B0B File Offset: 0x0001FD0B
		public virtual void vmethod_10(Texture texture_1, Rect rect_2, Rect rect_3)
		{
			this.texture_0 = texture_1;
			this.rect_0 = rect_2;
			this.rect_1 = rect_3;
			this.vmethod_11();
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x00021B28 File Offset: 0x0001FD28
		public void method_10(pumpkin.display.Sprite sprite_1)
		{
			if (sprite_1 != null)
			{
				sprite_1.graphics.clear();
				if (this.texture_0 != null)
				{
					sprite_1.graphics.drawRectUV(this.material_0, this.rect_0, this.rect_1);
				}
			}
		}

		// Token: 0x060033AE RID: 13230 RVA: 0x000ED4F0 File Offset: 0x000EB6F0
		protected virtual void vmethod_11()
		{
			this.sprite_0.graphics.clear();
			if (this.texture_0 != null)
			{
				this.material_0.mainTexture = this.texture_0;
				this.sprite_0.graphics.drawRectUV(this.material_0, this.rect_0, this.rect_1);
			}
		}

		// Token: 0x060033AF RID: 13231 RVA: 0x000ED550 File Offset: 0x000EB750
		protected override void vmethod_4()
		{
			base.vmethod_4();
			this.vmethod_12();
			for (int i = 0; i < this.displayObjectContainer_0.numChildren; i++)
			{
				this.displayObjectContainer_0.getChildAt(i).visible = false;
			}
			this.displayObjectContainer_0.addChildAt(this.sprite_0, 1);
		}

		// Token: 0x060033B0 RID: 13232 RVA: 0x000ED5A4 File Offset: 0x000EB7A4
		protected virtual void vmethod_12()
		{
			float num = (1f - this.float_0) / 2f;
			this.rect_1.x = Mathf.Round(this.movieClip_0.srcWidth * num);
			this.rect_1.y = Mathf.Round(this.movieClip_0.srcHeight * num);
			this.rect_1.width = Mathf.Round(this.movieClip_0.srcWidth * this.float_0);
			this.rect_1.height = Mathf.Round(this.movieClip_0.srcHeight * this.float_0);
		}

		// Token: 0x060033B1 RID: 13233 RVA: 0x00021B64 File Offset: 0x0001FD64
		protected override void vmethod_5()
		{
			this.vmethod_11();
		}

		// Token: 0x040023D9 RID: 9177
		protected Texture texture_0;

		// Token: 0x040023DA RID: 9178
		protected Material material_0;

		// Token: 0x040023DB RID: 9179
		protected Rect rect_0;

		// Token: 0x040023DC RID: 9180
		protected Rect rect_1;

		// Token: 0x040023DD RID: 9181
		protected pumpkin.display.Sprite sprite_0;

		// Token: 0x040023DE RID: 9182
		protected float float_0 = 1f;
	}
}
