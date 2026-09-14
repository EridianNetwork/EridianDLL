using System;
using ns0;
using UnityEngine;

// Token: 0x02000B45 RID: 2885
[AddComponentMenu("Effects/TKC/Decal Effect")]
public class DecalEffect : EffectBase
{
	// Token: 0x06004E97 RID: 20119 RVA: 0x000332C5 File Offset: 0x000314C5
	public void Awake()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		this.m_pool = new EffectPool(this.m_poolSize);
	}

	// Token: 0x06004E98 RID: 20120 RVA: 0x0014DFA8 File Offset: 0x0014C1A8
	public override void PlayEffect(EffectTrigger trigger)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (trigger.m_location == EffectLocationType.Raycast)
		{
			this.method_0(trigger.m_raycastHit.collider.gameObject, trigger.m_raycastHit.point, -trigger.m_raycastHit.normal);
		}
	}

	// Token: 0x06004E99 RID: 20121 RVA: 0x0014DFFC File Offset: 0x0014C1FC
	public void method_0(GameObject gameObject_0, Vector3 vector3_0, Vector3 vector3_1)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		this.method_1(new GameObject(this.m_myName)
		{
			transform = 
			{
				position = vector3_0,
				rotation = Quaternion.FromToRotation(Vector3.forward, vector3_1),
				localScale = this.m_decalSize
			}
		}, gameObject_0);
	}

	// Token: 0x06004E9A RID: 20122 RVA: 0x0014E060 File Offset: 0x0014C260
	public void method_1(GameObject gameObject_0, GameObject gameObject_1)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		EffectPoolController effectPoolController = gameObject_0.AddComponent<EffectPoolController>();
		effectPoolController.method_0(this.m_pool);
		Decal.dCount++;
		Decal decal = gameObject_0.AddComponent<Decal>();
		decal.affectedObject = gameObject_1;
		decal.decalMode = DecalMode.MESH_FILTER;
		decal.pushDistance = 0.02f;
		Material material = this.m_material;
		if (this.m_texture != null && this.m_texture.Length > 0)
		{
			int num = global::UnityEngine.Random.Range(0, this.m_texture.Length);
			material.mainTexture = this.m_texture[num];
		}
		decal.decalMaterial = material;
		decal.method_1();
		decal.transform.parent = gameObject_1.transform;
	}

	// Token: 0x04003AD2 RID: 15058
	public Material m_material;

	// Token: 0x04003AD3 RID: 15059
	public Vector3 m_decalSize = new Vector3(1f, 1f, 1f);

	// Token: 0x04003AD4 RID: 15060
	public Texture2D[] m_texture;

	// Token: 0x04003AD5 RID: 15061
	public int m_poolSize = 1;
}
