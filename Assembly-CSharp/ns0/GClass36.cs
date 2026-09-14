using System;
using pumpkin.display;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x0200079F RID: 1951
	public class GClass36 : GClass26
	{
		// Token: 0x060033EC RID: 13292 RVA: 0x000EDFA8 File Offset: 0x000EC1A8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("mc_title");
			this.movieClip_2 = movieClip.getChildByName<MovieClip>("mc_detail1");
			this.movieClip_3 = movieClip.getChildByName<MovieClip>("mc_detail2");
			this.movieClip_2.visible = false;
			this.textField_1 = this.movieClip_1.getChildByName<TextField>("tf_title");
			this.textField_2 = this.movieClip_3.getChildByName<TextField>("tf_prefix2");
			this.textField_3 = this.movieClip_3.getChildByName<TextField>("tf_data2");
			this.textField_4 = this.movieClip_2.getChildByName<TextField>("tf_prefix1");
			this.textField_5 = this.movieClip_2.getChildByName<TextField>("tf_data1");
			this.textField_4.text = string.Empty;
			this.textField_5.text = string.Empty;
		}

		// Token: 0x060033ED RID: 13293 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_14(int int_1)
		{
		}

		// Token: 0x060033EE RID: 13294 RVA: 0x000EE0A0 File Offset: 0x000EC2A0
		public void method_19(string string_6, string string_7, bool bool_8 = false, bool bool_9 = false)
		{
			if (bool_9)
			{
				this.movieClip_1.visible = true;
				this.movieClip_3.visible = false;
				this.movieClip_2.visible = false;
				this.textField_1.text = string_6;
				this.textField_2.text = string.Empty;
				this.textField_3.text = string.Empty;
			}
			else
			{
				this.movieClip_1.visible = false;
				this.movieClip_3.visible = true;
				this.movieClip_2.visible = false;
				this.textField_1.text = string.Empty;
				this.textField_2.text = string_6;
				if (bool_8)
				{
					this.textField_3.textFormat.color = Color.gray;
					this.textField_3.text = "--";
				}
				else
				{
					this.textField_3.textFormat.color = Color.white;
					this.textField_3.text = string_7;
				}
			}
		}

		// Token: 0x04002402 RID: 9218
		private MovieClip movieClip_1;

		// Token: 0x04002403 RID: 9219
		private MovieClip movieClip_2;

		// Token: 0x04002404 RID: 9220
		private MovieClip movieClip_3;

		// Token: 0x04002405 RID: 9221
		private TextField textField_1;

		// Token: 0x04002406 RID: 9222
		private TextField textField_2;

		// Token: 0x04002407 RID: 9223
		private TextField textField_3;

		// Token: 0x04002408 RID: 9224
		private TextField textField_4;

		// Token: 0x04002409 RID: 9225
		private TextField textField_5;
	}
}
