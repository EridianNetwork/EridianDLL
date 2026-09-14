using System;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class AnimationManager : MonoBehaviour
{
	// Token: 0x06000180 RID: 384 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual void vmethod_0(EntityWeapon entityWeapon_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPickUpWeapon(EntityWeapon weapon)
	{
	}

	// Token: 0x06000182 RID: 386 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnSwitchWeapon(EntityWeapon weapon)
	{
	}

	// Token: 0x06000183 RID: 387 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnAttack()
	{
	}

	// Token: 0x06000184 RID: 388 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnReload(float compensation)
	{
	}

	// Token: 0x06000185 RID: 389 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnMelee()
	{
	}

	// Token: 0x06000186 RID: 390 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnDamaged(DamageInfo damageInfo)
	{
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnThrow(float networkLatency, AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate spawnGrenadeDelegate)
	{
	}

	// Token: 0x06000188 RID: 392 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnTeleportMe(Vector3 teleportPos)
	{
	}

	// Token: 0x06000189 RID: 393 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnReceiveEvent(string eventData)
	{
	}
}
