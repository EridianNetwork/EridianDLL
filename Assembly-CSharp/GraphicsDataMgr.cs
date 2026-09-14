using System;
using UnityEngine;

// Token: 0x020005A7 RID: 1447
public class GraphicsDataMgr
{
	// Token: 0x060024C0 RID: 9408 RVA: 0x000AFE0C File Offset: 0x000AE00C
	public static void smethod_0()
	{
		WeaponElementalData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<WeaponElementalData>();
		if (component)
		{
			GraphicsDataMgr.NoneElementalEmissiveColor = component.NoneElementalEmissiveColor;
			GraphicsDataMgr.FireElementalEmissiveColor = component.FireElementalEmissiveColor;
			GraphicsDataMgr.ShockElementalEmissiveColor = component.ShockElementalEmissiveColor;
			GraphicsDataMgr.CorrosiveElementalEmissiveColor = component.CorrosiveElementalEmissiveColor;
		}
	}

	// Token: 0x040019E8 RID: 6632
	public static Texture2D CharacterDeathEffectData_FadingTexture = null;

	// Token: 0x040019E9 RID: 6633
	public static float CharacterDeathEffectData_FadingTime = 0f;

	// Token: 0x040019EA RID: 6634
	public static SecondWindDownEffect PostProcess_SecondWindDownEffect = null;

	// Token: 0x040019EB RID: 6635
	public static Color NoneElementalEmissiveColor = new Color(0.11372549f, 0.11372549f, 0.11372549f, 0.24313726f);

	// Token: 0x040019EC RID: 6636
	public static Color FireElementalEmissiveColor = new Color(0.4862745f, 0.16862746f, 0.023529412f, 0.5882353f);

	// Token: 0x040019ED RID: 6637
	public static Color ShockElementalEmissiveColor = new Color(0f, 0.23921569f, 0.74509805f, 0.47058824f);

	// Token: 0x040019EE RID: 6638
	public static Color CorrosiveElementalEmissiveColor = new Color(0.078431375f, 0.39607844f, 0.011764706f, 0.5882353f);
}
