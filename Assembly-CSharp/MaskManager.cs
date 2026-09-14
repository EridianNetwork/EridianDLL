using System;
using System.Collections.Generic;
using pumpkin.display;

// Token: 0x02000781 RID: 1921
public class MaskManager
{
	// Token: 0x060032F7 RID: 13047 RVA: 0x000212C8 File Offset: 0x0001F4C8
	public MaskManager()
	{
		this.map = new Dictionary<MovieClip, MovieClip[]>();
	}

	// Token: 0x060032F8 RID: 13048 RVA: 0x000212DB File Offset: 0x0001F4DB
	public void method_0(MovieClip movieClip_0, MovieClip[] movieClip_1)
	{
		if (movieClip_0 == null)
		{
			return;
		}
		if (!this.map.ContainsKey(movieClip_0))
		{
			this.map.Add(movieClip_0, movieClip_1);
		}
		else
		{
			this.map[movieClip_0] = movieClip_1;
		}
	}

	// Token: 0x060032F9 RID: 13049 RVA: 0x0002130B File Offset: 0x0001F50B
	public void method_1(MovieClip movieClip_0)
	{
		if (movieClip_0 != null)
		{
			this.map.Remove(movieClip_0);
		}
	}

	// Token: 0x060032FA RID: 13050 RVA: 0x0002131D File Offset: 0x0001F51D
	public static MaskManager smethod_0()
	{
		if (MaskManager._MaskInstance == null)
		{
			MaskManager._MaskInstance = new MaskManager();
		}
		return MaskManager._MaskInstance;
	}

	// Token: 0x060032FB RID: 13051 RVA: 0x00021335 File Offset: 0x0001F535
	public void method_2()
	{
		this.map.Clear();
	}

	// Token: 0x060032FC RID: 13052 RVA: 0x00021342 File Offset: 0x0001F542
	public void Update(MovieClip masker, MovieClip clip)
	{
		if (masker == null)
		{
			return;
		}
		if (clip == null)
		{
			return;
		}
		clip.clipRect = masker.getBounds(clip).rect;
	}

	// Token: 0x060032FD RID: 13053 RVA: 0x000EA484 File Offset: 0x000E8684
	public void Update(MovieClip masker)
	{
		if (this.map.Count == 0)
		{
			return;
		}
		if (masker == null)
		{
			return;
		}
		MovieClip[] array = this.map[masker];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				array[i].clipRect = masker.getBounds(array[i]).rect;
			}
		}
	}

	// Token: 0x060032FE RID: 13054 RVA: 0x000EA4DC File Offset: 0x000E86DC
	public void Update()
	{
		if (this.map.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<MovieClip, MovieClip[]> keyValuePair in this.map)
		{
			if (keyValuePair.Key != null)
			{
				this.Update(keyValuePair.Key);
			}
		}
	}

	// Token: 0x04002360 RID: 9056
	private Dictionary<MovieClip, MovieClip[]> map;

	// Token: 0x04002361 RID: 9057
	protected static MaskManager _MaskInstance;
}
