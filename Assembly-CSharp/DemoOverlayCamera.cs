using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.logging;
using pumpkin.text;
using pumpkin.tweener;
using UnityEngine;

// Token: 0x02000B97 RID: 2967
public class DemoOverlayCamera : MovieClipOverlayCameraBehaviour
{
	// Token: 0x06005017 RID: 20503 RVA: 0x0015524C File Offset: 0x0015344C
	private void Start()
	{
		MovieClip movieClip = new MovieClip("uniSWF/Examples/common/swf/common_uniswf_overlay.swf:DemoOverlay");
		this.stage.addChild(movieClip);
		TextField childByName = movieClip.getChildByName<TextField>("txt");
		if (childByName != null)
		{
			childByName.text = this.title;
		}
		MovieClip childByName2 = movieClip.getChildByName<MovieClip>("logo");
		childByName2.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_0));
		Logger.instance.addEventListener(LogEvent.LOGEVENT, new EventDispatcher.EventCallback(this.method_1));
		this.debug_txt = movieClip.getChildByName<TextField>("debug_txt");
		if (!this.displayAtTop)
		{
			movieClip.y = (float)Screen.height - movieClip.height;
		}
		if (this.fadeAfter > 0f)
		{
			Tweener.addTween(movieClip, Tweener.Hash(new object[] { "delay", this.fadeAfter, "time", 3, "alpha", 0 }));
		}
	}

	// Token: 0x06005018 RID: 20504 RVA: 0x000341C8 File Offset: 0x000323C8
	private void method_0(CEvent cevent_0)
	{
		if (Application.absoluteURL.IndexOf("uniswf.com") == -1)
		{
			Application.OpenURL("http://uniswf.com");
		}
	}

	// Token: 0x06005019 RID: 20505 RVA: 0x00155350 File Offset: 0x00153550
	private void method_1(CEvent cevent_0)
	{
		LogEvent logEvent = cevent_0 as LogEvent;
		this.debug_txt.alpha = 1f;
		this.debug_txt.text = logEvent.logStr;
		Tweener.addTween(this.debug_txt, Tweener.Hash(new object[] { "time", 1, "alpha", 0, "delay", 3 }));
	}

	// Token: 0x04003CF7 RID: 15607
	public bool displayAtTop = true;

	// Token: 0x04003CF8 RID: 15608
	public float fadeAfter;

	// Token: 0x04003CF9 RID: 15609
	public string title = string.Empty;

	// Token: 0x04003CFA RID: 15610
	protected TextField debug_txt;
}
