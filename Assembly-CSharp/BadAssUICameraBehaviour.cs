using System;
using pumpkin.displayInternal;
using pumpkin.events;
using UnityEngine;

// Token: 0x0200076C RID: 1900
public class BadAssUICameraBehaviour : MovieClipOverlayCameraBehaviour
{
	// Token: 0x06003244 RID: 12868 RVA: 0x00020C4E File Offset: 0x0001EE4E
	public BadAssUICameraBehaviour()
	{
		this.m_EnableAutoSize = false;
		this.syncStageScalePerFrame = false;
	}

	// Token: 0x06003245 RID: 12869 RVA: 0x00020C64 File Offset: 0x0001EE64
	public new void Awake()
	{
		base.Awake();
		this.m_EnableAutoSize = false;
		this.syncStageScalePerFrame = false;
	}

	// Token: 0x06003246 RID: 12870 RVA: 0x000E3F10 File Offset: 0x000E2110
	public new void OnPostRender()
	{
		if (this._bForceSync)
		{
			this.stage.scaleX = this.stageScale.x + 0.0001f;
			this.stage.scaleY = this.stageScale.y + 0.0001f;
			this._bForceSync = false;
		}
		this.stage.hasClipRect = false;
		base.OnPostRender();
		if (this.syncStageScalePerFrame)
		{
			this.syncStageScalePerFrame = false;
		}
	}

	// Token: 0x06003247 RID: 12871 RVA: 0x000E3F88 File Offset: 0x000E2188
	protected void method_0()
	{
		if (this.stage == null)
		{
			return;
		}
		if (this.m_EnableAutoSize && this.m_LastOrth != base.camera.orthographicSize)
		{
			this.m_LastOrth = base.camera.orthographicSize;
			this.calcDrawOffsets();
		}
		if (base.camera.rect != this.m_lastCamRect)
		{
			this.calcDrawOffsets();
			this.m_lastCamRect = base.camera.rect;
		}
		if ((this.m_EnableAutoSize && (float)Screen.width != this.m_LastScreenWidth) || (float)Screen.height != this.m_LastScreenHeight)
		{
			this.m_LastScreenWidth = (float)Screen.width;
			this.m_LastScreenHeight = (float)Screen.height;
			this.calcDrawOffsets();
			this.stage.screenWidth = (float)Screen.width;
			this.stage.screenHeight = (float)Screen.height;
			this.stage.dispatchEvent(new CEvent(CEvent.RESIZE));
		}
		if (this.syncStageScalePerFrame && (this.stage.scaleX != this.stageScale.x || this.stage.scaleY != this.stageScale.y))
		{
			this.stage.scaleX = this.stageScale.x;
			this.stage.scaleY = this.stageScale.y;
		}
		if (this.drawNow && this.gfxGenerator != null && !this.m_Is3D)
		{
			this.gfxGenerator.renderStage(this.stage);
			this.gfxGenerator.drawMeshNow(base.transform.localToWorldMatrix, this.drawOffset, this.drawScale);
		}
	}

	// Token: 0x06003248 RID: 12872 RVA: 0x00020C7A File Offset: 0x0001EE7A
	public void method_1(Vector2 vector2_0, bool bool_0 = false)
	{
		this.stageScale = vector2_0;
		this.syncStageScalePerFrame = true;
		this._bForceSync = bool_0;
	}

	// Token: 0x06003249 RID: 12873 RVA: 0x000E412C File Offset: 0x000E232C
	protected override IGraphicsGenerator instanceGfxGenerator()
	{
		IGraphicsGenerator graphicsGenerator;
		if (this.useFastRenderer)
		{
			graphicsGenerator = new FastGraphicsDrawMeshGenerator();
		}
		else
		{
			graphicsGenerator = new BadAssGraphicsDrawMeshGenerator();
		}
		this.calcDrawOffsets();
		return graphicsGenerator;
	}

	// Token: 0x040022BF RID: 8895
	private bool _bForceSync;
}
