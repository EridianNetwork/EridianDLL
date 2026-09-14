using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x02000AA4 RID: 2724
public class Utils : MonoBehaviour
{
	// Token: 0x060049CE RID: 18894 RVA: 0x00132554 File Offset: 0x00130754
	public static Entity smethod_0(GameObject gameObject_0)
	{
		if (gameObject_0 != null)
		{
			Transform transform = gameObject_0.transform;
			while (transform)
			{
				Entity component = transform.GetComponent<Entity>();
				if (component != null)
				{
					return component;
				}
				transform = transform.parent;
			}
		}
		return null;
	}

	// Token: 0x060049CF RID: 18895 RVA: 0x00132598 File Offset: 0x00130798
	public static T[] smethod_1<T>()
	{
		new List<T>();
		return Resources.FindObjectsOfTypeAll(typeof(T)) as T[];
	}

	// Token: 0x060049D0 RID: 18896 RVA: 0x001325C8 File Offset: 0x001307C8
	public static void smethod_2(Entity entity_0)
	{
		Vector3 position = entity_0.transform.position;
		float entityHeight = entity_0.m_entityHeight;
		RaycastHit raycastHit;
		if (Physics.Raycast(position, -Vector3.up, out raycastHit, entityHeight * 4f))
		{
			position.y = raycastHit.point.y + entityHeight * 0.5f;
			entity_0.transform.position = position;
		}
	}

	// Token: 0x060049D1 RID: 18897 RVA: 0x00132630 File Offset: 0x00130830
	public static bool smethod_3(object object_0, object object_1)
	{
		if (object_0 == null || object_1 == null)
		{
			return object_0 == null && object_1 == null;
		}
		if (!object_0.Equals(object_1))
		{
			if (object_0 is Vector3)
			{
				Vector3 vector = (Vector3)object_0;
				Vector3 vector2 = (Vector3)object_1;
				if (vector.AlmostEquals(vector2, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is Vector2)
			{
				Vector2 vector3 = (Vector2)object_0;
				Vector2 vector4 = (Vector2)object_1;
				if (vector3.AlmostEquals(vector4, PhotonNetwork.precisionForVectorSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is Quaternion)
			{
				Quaternion quaternion = (Quaternion)object_0;
				Quaternion quaternion2 = (Quaternion)object_1;
				if (quaternion.AlmostEquals(quaternion2, PhotonNetwork.precisionForQuaternionSynchronization))
				{
					return true;
				}
			}
			else if (object_0 is float)
			{
				float num = (float)object_0;
				float num2 = (float)object_1;
				if (num.AlmostEquals(num2, PhotonNetwork.precisionForFloatSynchronization))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	// Token: 0x060049D2 RID: 18898 RVA: 0x00132704 File Offset: 0x00130904
	public static void smethod_4(Transform transform_0, int int_0, bool bool_0 = false)
	{
		Stack<Transform> stack = new Stack<Transform>();
		stack.Push(transform_0);
		while (stack.Count != 0)
		{
			Transform transform = stack.Pop();
			transform.gameObject.layer = int_0;
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				if (!bool_0 || !(gameObject.name.ToLower() == "displayobj"))
				{
					stack.Push(gameObject.transform);
				}
			}
		}
	}

	// Token: 0x060049D3 RID: 18899 RVA: 0x00132780 File Offset: 0x00130980
	public static void smethod_5(Transform transform_0, string string_0, string string_1)
	{
		int num = LayerMask.NameToLayer(string_0);
		int num2 = LayerMask.NameToLayer(string_1);
		Stack<Transform> stack = new Stack<Transform>();
		stack.Push(transform_0);
		while (stack.Count != 0)
		{
			Transform transform = stack.Pop();
			if (transform.gameObject.layer == num)
			{
				transform.gameObject.layer = num2;
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				stack.Push(gameObject.transform);
			}
		}
	}

	// Token: 0x060049D4 RID: 18900 RVA: 0x00132804 File Offset: 0x00130A04
	public static int smethod_6(object object_0)
	{
		int num = 0;
		if (object_0 is Hashtable)
		{
			num += Utils.smethod_8((Hashtable)object_0);
		}
		else if (object_0 is IDictionary)
		{
			num += Utils.smethod_9((IDictionary)object_0);
		}
		else if (object_0 is Array)
		{
			num += Utils.smethod_7((Array)object_0);
		}
		else if (object_0 is IEnumerable)
		{
			num += Utils.smethod_10((IEnumerable)object_0);
		}
		else
		{
			num += BolCustomType.smethod_0(object_0);
		}
		return num;
	}

	// Token: 0x060049D5 RID: 18901 RVA: 0x00132880 File Offset: 0x00130A80
	public static int smethod_7(Array array_0)
	{
		int num = 4;
		for (int i = 0; i < array_0.Length; i++)
		{
			num += Utils.smethod_6(array_0.GetValue(i));
		}
		return num;
	}

	// Token: 0x060049D6 RID: 18902 RVA: 0x001328B0 File Offset: 0x00130AB0
	public static int smethod_8(Hashtable hashtable_0)
	{
		int num = 3;
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			num += Utils.smethod_6(enumerator.Key);
			num += Utils.smethod_6(enumerator.Value);
		}
		return num;
	}

	// Token: 0x060049D7 RID: 18903 RVA: 0x001328F0 File Offset: 0x00130AF0
	public static int smethod_9(IDictionary idictionary_0)
	{
		int num = 3;
		foreach (object obj in idictionary_0.Keys)
		{
			num += Utils.smethod_6(obj);
		}
		foreach (object obj2 in idictionary_0.Values)
		{
			num += Utils.smethod_6(obj2);
		}
		return num;
	}

	// Token: 0x060049D8 RID: 18904 RVA: 0x00132948 File Offset: 0x00130B48
	public static int smethod_10(IEnumerable ienumerable_0)
	{
		int num = 4;
		foreach (object obj in ienumerable_0)
		{
			num += Utils.smethod_6(obj);
		}
		return num;
	}

	// Token: 0x060049D9 RID: 18905 RVA: 0x00132978 File Offset: 0x00130B78
	public static int smethod_11(DictionaryEntry dictionaryEntry_0)
	{
		int num = 0 + Utils.smethod_6(dictionaryEntry_0.Key);
		return num + Utils.smethod_6(dictionaryEntry_0.Value);
	}

	// Token: 0x060049DA RID: 18906 RVA: 0x001329A8 File Offset: 0x00130BA8
	public static float smethod_12(float float_0, float float_1, float float_2)
	{
		float num;
		if (Mathf.Abs(float_0 - float_1) < 0.001f)
		{
			num = float_1;
		}
		else
		{
			num = Mathf.Lerp(float_0, float_1, float_2);
		}
		return num;
	}

	// Token: 0x060049DB RID: 18907 RVA: 0x001329D4 File Offset: 0x00130BD4
	public static Vector3 smethod_13(Vector3 vector3_0, Vector3 vector3_1, float float_0)
	{
		Vector3 vector;
		if (Vector3.Distance(vector3_0, vector3_1) < 0.001f)
		{
			vector = vector3_1;
		}
		else
		{
			vector = Vector3.Lerp(vector3_0, vector3_1, float_0);
		}
		return vector;
	}

	// Token: 0x060049DC RID: 18908 RVA: 0x00132A00 File Offset: 0x00130C00
	public static void smethod_14(ref Camera camera_0, ref Camera camera_1)
	{
		camera_1.fieldOfView = camera_0.fieldOfView;
		camera_1.nearClipPlane = camera_0.nearClipPlane;
		camera_1.farClipPlane = camera_0.farClipPlane;
		camera_1.renderingPath = camera_0.renderingPath;
		camera_1.hdr = camera_0.hdr;
		camera_1.orthographicSize = camera_0.orthographicSize;
		camera_1.orthographic = camera_0.orthographic;
		camera_1.transparencySortMode = camera_0.transparencySortMode;
		camera_1.depth = camera_0.depth;
		camera_1.aspect = camera_0.aspect;
		camera_1.cullingMask = camera_0.cullingMask;
		camera_1.eventMask = camera_0.eventMask;
		camera_1.backgroundColor = camera_0.backgroundColor;
		camera_1.rect = camera_0.rect;
		camera_1.pixelRect = camera_0.pixelRect;
		camera_1.targetTexture = camera_0.targetTexture;
		camera_1.worldToCameraMatrix = camera_0.worldToCameraMatrix;
		camera_1.projectionMatrix = camera_0.projectionMatrix;
		camera_1.clearFlags = camera_0.clearFlags;
		camera_1.useOcclusionCulling = camera_0.useOcclusionCulling;
		camera_1.layerCullDistances = camera_0.layerCullDistances;
		camera_1.layerCullSpherical = camera_0.layerCullSpherical;
		camera_1.depthTextureMode = camera_0.depthTextureMode;
		camera_1.transform.position = camera_0.transform.position;
		camera_1.transform.rotation = camera_0.transform.rotation;
	}

	// Token: 0x060049DD RID: 18909 RVA: 0x00132B80 File Offset: 0x00130D80
	public static float smethod_15(Ray ray_0, Vector3 vector3_0)
	{
		Vector3 vector = vector3_0 - ray_0.origin;
		float num = Vector3.Dot(vector, ray_0.direction.normalized);
		Vector3 vector2 = ray_0.origin;
		if (num > 0f)
		{
			vector2 += ray_0.direction.normalized * num;
		}
		return Vector3.Distance(vector2, vector3_0);
	}

	// Token: 0x060049DE RID: 18910 RVA: 0x00132BE8 File Offset: 0x00130DE8
	public static string smethod_16(GameObject gameObject_0)
	{
		string text = "null";
		if (null != gameObject_0)
		{
			text = gameObject_0.name;
			while (null != gameObject_0.transform.parent)
			{
				gameObject_0 = gameObject_0.transform.parent.gameObject;
				text = gameObject_0.name + "/" + text;
			}
		}
		return text;
	}

	// Token: 0x060049DF RID: 18911 RVA: 0x00132C48 File Offset: 0x00130E48
	private static string smethod_17(string string_0)
	{
		string text = null;
		if (string_0 != null && string_0.EndsWith("(Clone)"))
		{
			text = string_0.Substring(0, string_0.Length - "(Clone)".Length);
		}
		return text;
	}

	// Token: 0x060049E0 RID: 18912 RVA: 0x00132C84 File Offset: 0x00130E84
	public static string smethod_18(string string_0)
	{
		string text = Utils.smethod_17(string_0);
		return text ?? string_0;
	}

	// Token: 0x060049E1 RID: 18913 RVA: 0x00132CA0 File Offset: 0x00130EA0
	public static bool smethod_19(global::UnityEngine.Object object_0)
	{
		string text = Utils.smethod_18(object_0.name);
		bool flag;
		if (flag = null != text)
		{
			object_0.name = text;
		}
		return flag;
	}

	// Token: 0x060049E2 RID: 18914 RVA: 0x00132CCC File Offset: 0x00130ECC
	public static void smethod_20(GameObject gameObject_0, GameObject gameObject_1)
	{
		Transform transform = gameObject_0.transform;
		transform.parent = gameObject_1.transform;
		transform.localPosition = Vector3.zero;
		transform.localScale = Vector3.one;
		transform.localRotation = Quaternion.identity;
	}

	// Token: 0x060049E3 RID: 18915 RVA: 0x00132D10 File Offset: 0x00130F10
	public static string smethod_21(AmmoType ammoType_0)
	{
		switch (ammoType_0)
		{
		case AmmoType.SMG:
			return "SMG";
		case AmmoType.SniperRifle:
			return "SniperRifle";
		case AmmoType.Grenade:
			return "Grenade";
		case AmmoType.ShotGun:
			return "ShotGun";
		case AmmoType.Pistol:
			return "Pistol";
		case AmmoType.AssaultRifle:
			return "AssaultRifle";
		default:
			return string.Empty;
		}
	}

	// Token: 0x060049E4 RID: 18916 RVA: 0x00132D68 File Offset: 0x00130F68
	public static string smethod_22(AffectType affectType_0)
	{
		switch (affectType_0)
		{
		case AffectType.PrevAdd:
			return "PrevAdd";
		case AffectType.PostAdd:
			return "PostAdd";
		case AffectType.Scale:
			return "Scale";
		default:
			return string.Empty;
		}
	}

	// Token: 0x060049E5 RID: 18917 RVA: 0x00132DA0 File Offset: 0x00130FA0
	public static string smethod_23(AnimationStateFSM animationStateFSM_0)
	{
		switch (animationStateFSM_0 + 1)
		{
		case AnimationStateFSM.Idle:
			return "Invalid";
		case AnimationStateFSM.Move:
			return "Idle";
		case AnimationStateFSM.MoveWithFacing:
			return "Move";
		case AnimationStateFSM.HoverPatrol:
			return "MoveWithFacing";
		case AnimationStateFSM.FlyMeleeAttack:
			return "HoverPatrol";
		case AnimationStateFSM.FlyGather:
			return "FlyMeleeAttack";
		case AnimationStateFSM.Die:
			return "FlyGather";
		case AnimationStateFSM.Dead:
			return "Die";
		case AnimationStateFSM.MeleeAttack:
			return "Dead";
		case AnimationStateFSM.JumpAttack:
			return "MeleeAttack";
		case AnimationStateFSM.JumpAttackCrash:
			return "JumpAttack";
		case AnimationStateFSM.Warcry:
			return "JumpAttackCrash";
		case AnimationStateFSM.Charge:
			return "Warcry";
		case AnimationStateFSM.ChargeHit:
			return "Charge";
		case AnimationStateFSM.Spawn:
			return "ChargeHit";
		case AnimationStateFSM.AdvanceSpawn:
			return "Spawn";
		case AnimationStateFSM.Stun:
			return "AdvanceSpawn";
		case AnimationStateFSM.JumpOnSpot:
			return "Stun";
		case AnimationStateFSM.Fire:
			return "JumpOnSpot";
		case AnimationStateFSM.FireFullBody:
			return "Fire";
		case AnimationStateFSM.DeployAidStation:
			return "FireFullBody";
		case AnimationStateFSM.Reload:
			return "DeployAidStation";
		case AnimationStateFSM.CoverFire:
			return "Reload";
		case AnimationStateFSM.CoverIdleBeforeFire:
			return "CoverFire";
		case AnimationStateFSM.CoverIdle:
			return "CoverIdleBeforeFire";
		case AnimationStateFSM.CoverLookAround:
			return "CoverIdle";
		case AnimationStateFSM.CoverPeakIn:
			return "CoverLookAround";
		case AnimationStateFSM.CoverPeakOut:
			return "CoverPeakIn";
		case AnimationStateFSM.CoverReload:
			return "CoverPeakOut";
		case AnimationStateFSM.Hurt:
			return "CoverReload";
		case AnimationStateFSM.LightHurt:
			return "Hurt";
		case AnimationStateFSM.SuicideBomb:
			return "LightHurt";
		case AnimationStateFSM.RadiusAttack:
			return "SuicideBomb";
		case AnimationStateFSM.Burrow:
			return "RadiusAttack";
		case AnimationStateFSM.Alert:
			return "Burrow";
		case AnimationStateFSM.Roll:
			return "Alert";
		case AnimationStateFSM.SideStep:
			return "Roll";
		case AnimationStateFSM.Spit:
			return "SideStep";
		case AnimationStateFSM.Spacing:
			return "Spit";
		case AnimationStateFSM.Critical:
			return "Spacing";
		case AnimationStateFSM.SlideMove:
			return "Critical";
		case AnimationStateFSM.ThrowWeapon:
			return "SlideMove";
		case AnimationStateFSM.ShowWeapon:
			return "ThrowWeapon";
		case AnimationStateFSM.IceEarthquakeAttack:
			return "ShowWeapon";
		case AnimationStateFSM.IceMeteorAttack:
			return "IceEarthquakeAttack";
		case AnimationStateFSM.SummonExtraNPC:
			return "IceMeteorAttack";
		case AnimationStateFSM.Warning:
			return "SummonExtraNPC";
		case AnimationStateFSM.CombatSpawn:
			return "Warning";
		case AnimationStateFSM.RailgunAttack:
			return "CombatSpawn";
		case AnimationStateFSM.MortarAttack:
			return "RailgunAttack";
		case AnimationStateFSM.TurnTo:
			return "MortarAttack";
		case AnimationStateFSM.TurnOnSpot:
			return "TurnTo";
		case AnimationStateFSM.LaserSweep:
			return "TurnOnSpot";
		case AnimationStateFSM.Empty:
			return "LaserSweep";
		case AnimationStateFSM.PlayerIdle:
			return "Empty";
		case AnimationStateFSM.PlayerMove:
			return "PlayerIdle";
		case AnimationStateFSM.PlayerCrouchIdle:
			return "PlayerMove";
		case AnimationStateFSM.PlayerCrouchMove:
			return "PlayerCrouchIdle";
		case AnimationStateFSM.PlayerFire:
			return "PlayerCrouchMove";
		case AnimationStateFSM.PlayerReload:
			return "PlayerFire";
		case AnimationStateFSM.PlayerSwitchDown:
			return "PlayerReload";
		case AnimationStateFSM.PlayerSwitchUp:
			return "PlayerSwitchDown";
		case AnimationStateFSM.PlayerAim:
			return "PlayerSwitchUp";
		case AnimationStateFSM.PlayerJump:
			return "PlayerAim";
		case AnimationStateFSM.PlayerPickupWeapon:
			return "PlayerJump";
		case AnimationStateFSM.PlayerMelee:
			return "PlayerPickupWeapon";
		case AnimationStateFSM.PlayerMeleeSkill:
			return "PlayerMelee";
		case AnimationStateFSM.PlayerThrowGrenade:
			return "PlayerMeleeSkill";
		case AnimationStateFSM.PlayerFireBird:
			return "PlayerThrowGrenade";
		case AnimationStateFSM.PlayerCallback:
			return "PlayerFireBird";
		case AnimationStateFSM.PlayerDie:
			return "PlayerCallback";
		case AnimationStateFSM.PlayerBerserkCharge:
			return "PlayerDie";
		case AnimationStateFSM.PlayerBerserkDash:
			return "PlayerBerserkCharge";
		case AnimationStateFSM.PlayerBerserkPunch:
			return "PlayerBerserkDash";
		case AnimationStateFSM.PlayerThrowTurret:
			return "PlayerBerserkPunch";
		case AnimationStateFSM.PlayerRetrieveTurret:
			return "PlayerThrowTurret";
		case AnimationStateFSM.LavaStrike:
			return "PlayerRetrieveTurret";
		case AnimationStateFSM.PlayerReleaseDroid:
			return "LavaStrike";
		case AnimationStateFSM.PlayerRetrieveDroid:
			return "PlayerReleaseDroid";
		case AnimationStateFSM.WebTrap:
			return "PlayerRetrieveDroid";
		case AnimationStateFSM.TutorialLesson:
			return "WebTrap";
		case AnimationStateFSM.TutorialAction:
			return "TutorialLesson";
		case AnimationStateFSM.CircleMove:
			return "TutorialAction";
		case AnimationStateFSM.PlayerJumpStart:
			return "CircleMove";
		case AnimationStateFSM.PlayerJumpIdle:
			return "PlayerJumpStart";
		case AnimationStateFSM.PlayerJumpLand:
			return "PlayerJumpIdle";
		case AnimationStateFSM.AttachBomb:
			return "PlayerJumpLand";
		case AnimationStateFSM.DropBomb:
			return "AttachBomb";
		case (AnimationStateFSM)88:
			return "DropBomb";
		default:
			return string.Empty;
		}
	}

	// Token: 0x060049E6 RID: 18918 RVA: 0x00133138 File Offset: 0x00131338
	public static bool smethod_24(Camera camera_0, Vector3 vector3_0)
	{
		Vector3 vector = camera_0.WorldToScreenPoint(vector3_0);
		return vector.x >= 0f && vector.x <= (float)Screen.width && vector.y >= 0f && vector.y <= (float)Screen.height && vector.z >= 0f;
	}

	// Token: 0x060049E7 RID: 18919 RVA: 0x00133198 File Offset: 0x00131398
	public static bool smethod_25(Entity entity_0)
	{
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		return entityPlayer != null && entityPlayer.vmethod_25().IsMyActor();
	}

	// Token: 0x040035F9 RID: 13817
	private const string CLONE_MARKER = "(Clone)";

	// Token: 0x02000AA5 RID: 2725
	public class Timer
	{
		// Token: 0x060049E9 RID: 18921 RVA: 0x001331C4 File Offset: 0x001313C4
		public override string ToString()
		{
			return this.method_1().ToString();
		}

		// Token: 0x060049EA RID: 18922 RVA: 0x000304C3 File Offset: 0x0002E6C3
		public float method_0()
		{
			return this.m_duration;
		}

		// Token: 0x060049EB RID: 18923 RVA: 0x001331E0 File Offset: 0x001313E0
		public float method_1()
		{
			if (this.m_isRunning)
			{
				float time = Time.time;
				float num = this.m_duration - (time - this.m_startTime);
				return Mathf.Max(num, 0f);
			}
			return 0f;
		}

		// Token: 0x060049EC RID: 18924 RVA: 0x000304CB File Offset: 0x0002E6CB
		public float method_2()
		{
			if (this.m_isRunning)
			{
				return Mathf.Clamp((Time.time - this.m_startTime) / this.m_duration, 0f, 1f);
			}
			return 0f;
		}

		// Token: 0x060049ED RID: 18925 RVA: 0x000304FD File Offset: 0x0002E6FD
		public void Start(float duration)
		{
			this.m_duration = duration;
			this.m_startTime = Time.time;
			this.m_isRunning = true;
		}

		// Token: 0x060049EE RID: 18926 RVA: 0x00030518 File Offset: 0x0002E718
		public void method_3()
		{
			this.m_startTime = Time.time;
			this.m_isRunning = true;
		}

		// Token: 0x060049EF RID: 18927 RVA: 0x0003052C File Offset: 0x0002E72C
		public void method_4()
		{
			if (this.m_isRunning)
			{
				this.m_pauseTime = Time.time;
				this.m_isRunning = false;
			}
		}

		// Token: 0x060049F0 RID: 18928 RVA: 0x0013321C File Offset: 0x0013141C
		public void method_5()
		{
			if (!this.m_isRunning)
			{
				float num = this.m_duration - (this.m_pauseTime - this.m_startTime);
				this.Start(num);
			}
		}

		// Token: 0x060049F1 RID: 18929 RVA: 0x00030548 File Offset: 0x0002E748
		public bool method_6()
		{
			return this.m_isRunning;
		}

		// Token: 0x060049F2 RID: 18930 RVA: 0x00133250 File Offset: 0x00131450
		public bool method_7()
		{
			if (this.m_isRunning)
			{
				float time = Time.time;
				bool flag;
				if (flag = time - this.m_startTime > this.m_duration)
				{
					this.method_4();
				}
				return flag;
			}
			return false;
		}

		// Token: 0x060049F3 RID: 18931 RVA: 0x00133288 File Offset: 0x00131488
		public void method_8(float float_0)
		{
			if (this.m_isRunning)
			{
				float num = Mathf.Clamp(this.method_2() + float_0, 0f, 1f);
				this.m_startTime = Time.time - num * this.m_duration;
			}
		}

		// Token: 0x060049F4 RID: 18932 RVA: 0x00030550 File Offset: 0x0002E750
		public void method_9(float float_0)
		{
			if (this.method_6())
			{
				this.m_startTime = Time.time - float_0 * this.m_duration;
			}
		}

		// Token: 0x060049F5 RID: 18933 RVA: 0x0003056E File Offset: 0x0002E76E
		public void method_10(float float_0)
		{
			if (this.m_isRunning)
			{
				this.m_duration += float_0;
			}
		}

		// Token: 0x040035FA RID: 13818
		private bool m_isRunning;

		// Token: 0x040035FB RID: 13819
		private float m_startTime;

		// Token: 0x040035FC RID: 13820
		private float m_duration;

		// Token: 0x040035FD RID: 13821
		private float m_pauseTime;
	}

	// Token: 0x02000AA6 RID: 2726
	public class NetworkTimer
	{
		// Token: 0x060049F7 RID: 18935 RVA: 0x00030586 File Offset: 0x0002E786
		public void method_0(bool bool_0, double double_0, double double_1, double double_2)
		{
			this.m_isRunning = bool_0;
			this.m_startTime = double_0;
			this.m_duration = double_1;
			this.m_pauseTime = double_2;
		}

		// Token: 0x060049F8 RID: 18936 RVA: 0x000305A5 File Offset: 0x0002E7A5
		public double method_1()
		{
			return this.m_startTime;
		}

		// Token: 0x060049F9 RID: 18937 RVA: 0x000305AD File Offset: 0x0002E7AD
		public double method_2()
		{
			return this.m_duration;
		}

		// Token: 0x060049FA RID: 18938 RVA: 0x000305B5 File Offset: 0x0002E7B5
		public double method_3()
		{
			return this.m_pauseTime;
		}

		// Token: 0x060049FB RID: 18939 RVA: 0x001332CC File Offset: 0x001314CC
		public double method_4()
		{
			if (this.m_isRunning)
			{
				double num = NetworkManager.smethod_6();
				double num2 = this.m_duration - (num - this.m_startTime);
				return (num2 <= 0.0) ? 0.0 : num2;
			}
			return this.m_duration - (this.m_pauseTime - this.m_startTime);
		}

		// Token: 0x060049FC RID: 18940 RVA: 0x000305BD File Offset: 0x0002E7BD
		public void Start(double duration)
		{
			this.m_duration = duration;
			this.m_startTime = NetworkManager.smethod_6();
			this.m_isRunning = true;
		}

		// Token: 0x060049FD RID: 18941 RVA: 0x000305D8 File Offset: 0x0002E7D8
		public void method_5()
		{
			this.m_startTime = NetworkManager.smethod_6();
			this.m_isRunning = true;
		}

		// Token: 0x060049FE RID: 18942 RVA: 0x000305EC File Offset: 0x0002E7EC
		public void method_6()
		{
			if (this.m_isRunning)
			{
				this.m_pauseTime = NetworkManager.smethod_6();
				this.m_isRunning = false;
			}
		}

		// Token: 0x060049FF RID: 18943 RVA: 0x00133324 File Offset: 0x00131524
		public void method_7()
		{
			if (!this.m_isRunning)
			{
				double num = this.m_duration - (this.m_pauseTime - this.m_startTime);
				this.Start(num);
			}
		}

		// Token: 0x06004A00 RID: 18944 RVA: 0x00030608 File Offset: 0x0002E808
		public bool method_8()
		{
			return this.m_isRunning;
		}

		// Token: 0x06004A01 RID: 18945 RVA: 0x00133358 File Offset: 0x00131558
		public bool method_9()
		{
			if (this.m_isRunning)
			{
				double num = NetworkManager.smethod_6();
				bool flag;
				if (flag = num - this.m_startTime > this.m_duration)
				{
					this.method_6();
				}
				return flag;
			}
			return false;
		}

		// Token: 0x06004A02 RID: 18946 RVA: 0x00030610 File Offset: 0x0002E810
		public void method_10(double double_0)
		{
			this.m_duration += double_0;
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x00030620 File Offset: 0x0002E820
		public void method_11(double double_0)
		{
			this.m_duration -= double_0;
			this.m_duration = (double)Mathf.Max((float)this.m_duration, 0f);
		}

		// Token: 0x040035FE RID: 13822
		private bool m_isRunning;

		// Token: 0x040035FF RID: 13823
		private double m_startTime;

		// Token: 0x04003600 RID: 13824
		private double m_duration;

		// Token: 0x04003601 RID: 13825
		private double m_pauseTime;
	}

	// Token: 0x02000AA7 RID: 2727
	public struct Pouch
	{
		// Token: 0x06004A04 RID: 18948 RVA: 0x00030648 File Offset: 0x0002E848
		public void method_0(int int_0)
		{
			this.m_maxValue = int_0;
			this.m_currentValue = this.m_maxValue;
			this.m_baseMaxValue = int_0;
		}

		// Token: 0x06004A05 RID: 18949 RVA: 0x00030664 File Offset: 0x0002E864
		public void method_1(int int_0, int int_1)
		{
			this.m_maxValue = int_1;
			this.m_currentValue = int_0;
			this.m_baseMaxValue = int_1;
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x0003067B File Offset: 0x0002E87B
		public void method_2()
		{
			if (this.m_currentValue != this.m_maxValue)
			{
				this.m_currentValue = this.m_maxValue;
			}
		}

		// Token: 0x06004A07 RID: 18951 RVA: 0x00030697 File Offset: 0x0002E897
		public void method_3(int int_0)
		{
			this.m_currentValue = Mathf.Min(this.m_maxValue, this.m_currentValue + int_0);
		}

		// Token: 0x06004A08 RID: 18952 RVA: 0x000306B2 File Offset: 0x0002E8B2
		public int method_4()
		{
			return this.m_maxValue;
		}

		// Token: 0x06004A09 RID: 18953 RVA: 0x000306BA File Offset: 0x0002E8BA
		public int method_5()
		{
			return this.m_currentValue;
		}

		// Token: 0x06004A0A RID: 18954 RVA: 0x000306C2 File Offset: 0x0002E8C2
		public int method_6()
		{
			return this.m_baseMaxValue;
		}

		// Token: 0x06004A0B RID: 18955 RVA: 0x000306CA File Offset: 0x0002E8CA
		public void method_7(int int_0)
		{
			if (this.m_maxValue != int_0)
			{
				this.m_maxValue = int_0;
			}
		}

		// Token: 0x06004A0C RID: 18956 RVA: 0x000306DC File Offset: 0x0002E8DC
		public void method_8(int int_0)
		{
			int_0 = Mathf.Min(int_0, this.m_maxValue);
			int_0 = Mathf.Max(int_0, 0);
			if (this.m_currentValue != int_0)
			{
				this.m_currentValue = int_0;
			}
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x00030709 File Offset: 0x0002E909
		public void method_9(int int_0)
		{
			this.m_baseMaxValue = int_0;
		}

		// Token: 0x04003602 RID: 13826
		private int m_maxValue;

		// Token: 0x04003603 RID: 13827
		private int m_currentValue;

		// Token: 0x04003604 RID: 13828
		private int m_baseMaxValue;
	}

	// Token: 0x02000AA8 RID: 2728
	public class PouchNetwork
	{
		// Token: 0x06004A0F RID: 18959 RVA: 0x00030721 File Offset: 0x0002E921
		public void method_0(int int_0)
		{
			this.m_authorityPouch.method_0(int_0);
			this.m_localPouch.method_0(int_0);
		}

		// Token: 0x06004A10 RID: 18960 RVA: 0x0003073B File Offset: 0x0002E93B
		public void method_1(int int_0, int int_1)
		{
			this.m_authorityPouch.method_1(int_0, int_1);
			this.m_localPouch.method_1(int_0, int_1);
		}

		// Token: 0x06004A11 RID: 18961 RVA: 0x00030757 File Offset: 0x0002E957
		public void method_2()
		{
			if (this.authority)
			{
				this.m_authorityPouch.method_2();
			}
			else
			{
				this.m_localPouch.method_2();
			}
		}

		// Token: 0x06004A12 RID: 18962 RVA: 0x00030779 File Offset: 0x0002E979
		public void method_3(int int_0)
		{
			if (this.authority)
			{
				this.m_authorityPouch.method_3(int_0);
			}
			else
			{
				this.m_localPouch.method_3(int_0);
			}
		}

		// Token: 0x06004A13 RID: 18963 RVA: 0x0003079D File Offset: 0x0002E99D
		public int method_4()
		{
			if (this.authority)
			{
				return this.m_authorityPouch.method_4();
			}
			return this.m_localPouch.method_4();
		}

		// Token: 0x06004A14 RID: 18964 RVA: 0x000307BE File Offset: 0x0002E9BE
		public int method_5()
		{
			if (this.authority)
			{
				return this.m_authorityPouch.method_5();
			}
			return this.m_localPouch.method_5();
		}

		// Token: 0x06004A15 RID: 18965 RVA: 0x000307DF File Offset: 0x0002E9DF
		public int method_6()
		{
			if (this.authority)
			{
				return this.m_authorityPouch.method_6();
			}
			return this.m_localPouch.method_6();
		}

		// Token: 0x06004A16 RID: 18966 RVA: 0x00030800 File Offset: 0x0002EA00
		public void method_7(int int_0)
		{
			if (this.authority)
			{
				this.m_authorityPouch.method_7(int_0);
			}
			else
			{
				this.m_localPouch.method_7(int_0);
			}
		}

		// Token: 0x06004A17 RID: 18967 RVA: 0x00030824 File Offset: 0x0002EA24
		public void method_8(int int_0)
		{
			if (this.authority)
			{
				this.m_authorityPouch.method_8(int_0);
			}
			else
			{
				this.m_localPouch.method_8(int_0);
			}
		}

		// Token: 0x06004A18 RID: 18968 RVA: 0x00030848 File Offset: 0x0002EA48
		public void method_9(int int_0)
		{
			if (this.authority)
			{
				this.m_authorityPouch.method_9(int_0);
			}
			else
			{
				this.m_localPouch.method_9(int_0);
			}
		}

		// Token: 0x06004A19 RID: 18969 RVA: 0x0003086C File Offset: 0x0002EA6C
		public void method_10()
		{
			this.authority = true;
		}

		// Token: 0x06004A1A RID: 18970 RVA: 0x00030875 File Offset: 0x0002EA75
		public void method_11()
		{
			this.authority = false;
			this.m_localPouch = this.m_authorityPouch;
		}

		// Token: 0x04003605 RID: 13829
		private bool authority = true;

		// Token: 0x04003606 RID: 13830
		private Utils.Pouch m_authorityPouch;

		// Token: 0x04003607 RID: 13831
		private Utils.Pouch m_localPouch;
	}

	// Token: 0x02000AA9 RID: 2729
	public struct CacheFloatToInt
	{
		// Token: 0x06004A1B RID: 18971 RVA: 0x00133390 File Offset: 0x00131590
		public int method_0(float float_0)
		{
			this.m_sum += float_0;
			int num = Mathf.FloorToInt(this.m_sum);
			if (num > 0)
			{
				this.m_sum -= (float)num;
			}
			return num;
		}

		// Token: 0x04003608 RID: 13832
		private float m_sum;
	}

	// Token: 0x02000AAA RID: 2730
	public class CacheSeconds
	{
		// Token: 0x06004A1C RID: 18972 RVA: 0x0003088A File Offset: 0x0002EA8A
		public CacheSeconds(float float_0)
		{
			this.m_duration = float_0;
		}

		// Token: 0x06004A1D RID: 18973 RVA: 0x001333CC File Offset: 0x001315CC
		public int method_0(float float_0)
		{
			int num = 0;
			this.m_sum += float_0;
			if (Time.time - this.m_startTime >= this.m_duration)
			{
				this.m_startTime = Time.time;
				num = Mathf.FloorToInt(this.m_sum);
				if (num > 0)
				{
					this.m_sum -= (float)num;
				}
			}
			return num;
		}

		// Token: 0x04003609 RID: 13833
		private float m_sum;

		// Token: 0x0400360A RID: 13834
		private float m_duration;

		// Token: 0x0400360B RID: 13835
		private float m_startTime;
	}

	// Token: 0x02000AAB RID: 2731
	public class StaticRandom
	{
		// Token: 0x06004A20 RID: 18976 RVA: 0x000308B5 File Offset: 0x0002EAB5
		public static float smethod_0(int int_0)
		{
			return Utils.StaticRandom.randomList[int_0 % Utils.StaticRandom.randomList.Length];
		}

		// Token: 0x0400360C RID: 13836
		private static float[] randomList = new float[]
		{
			0.139f, 0.598f, 0.485f, 0.682f, 0.814f, 0.191f, 0.935f, 0.287f, 0.45f, 0.097f,
			0.683f, 0.976f, 0.805f, 0.957f, 0.764f, 0.214f, 0.202f, 0.608f, 0.261f, 0.929f,
			0.745f, 0.05f, 0.133f, 0.369f, 0.535f, 0.49f, 0.991f, 0.13f, 0.366f, 0.501f,
			0.315f, 0.005f, 0.852f, 0.913f, 0.974f, 0.061f, 0.045f, 0.64f, 0.718f, 0.432f,
			0.785f, 0.69f, 0.902f, 0.779f, 0.604f, 0.308f, 0.092f, 0.786f, 0.942f, 0.191f,
			0.975f, 0.408f, 0.079f, 0.019f, 0.726f, 0.088f, 0.465f, 0.116f, 0.147f, 0.324f,
			0.199f, 0.806f, 0.921f, 0.949f, 0.783f, 0.679f, 0.124f, 0.891f, 0.983f, 0.704f,
			0.169f, 0.562f, 0.889f, 0.829f, 0.144f, 0.056f, 0.148f, 0.354f, 0.766f, 0.228f,
			0.398f, 0.206f, 0.188f, 0.175f, 0.526f, 0.907f, 0.925f, 0.833f, 0.187f, 0.886f,
			0.596f, 0.929f, 0.493f, 0.395f, 0.233f, 0.979f, 0.769f, 0.953f, 0.996f, 0.925f,
			0.184f, 0.2f, 0.802f, 0.239f, 0.022f, 0.413f, 0.519f, 0.25f, 0.875f, 0.67f,
			0.94f, 0.11f, 0.35f, 0.919f, 0.926f, 0.993f, 0.618f, 0.746f, 0.423f, 0.876f,
			0.753f, 0.291f, 0.704f, 0.098f, 0.107f, 0.24f, 0.069f, 0.495f, 0.596f, 0.165f,
			0.287f, 0.196f, 0.358f, 0.84f, 0.044f, 0.198f, 0.403f, 0.949f, 0.152f, 0.114f,
			0.388f, 0.675f, 0.957f, 0.517f, 0.946f, 0.486f, 0.579f, 0.574f, 0.469f, 0.24f,
			0.361f, 0.023f, 0.53f, 0.12f, 0.172f, 0.893f, 0.496f, 0.705f, 0.131f, 0.782f,
			0.344f, 0.024f, 0.654f, 0.711f, 0.383f, 0.744f, 0.752f, 0.51f, 0.876f, 0.728f,
			0.59f, 0.669f, 0.594f, 0.309f, 0.488f, 0.078f, 0.334f, 0.187f, 0.152f, 0.621f,
			0.661f, 0.495f, 0.026f, 0.357f, 0.804f, 0.264f, 0.666f, 0.238f, 0.668f, 0.151f,
			0.702f, 0.698f, 0.818f, 0.37f, 0.77f, 0.364f, 0.021f, 0.246f, 0.134f, 0.202f,
			0.734f, 0.069f, 0.698f, 0.741f, 0.649f, 0.692f, 0.429f, 0.22f, 0.632f, 0.094f,
			0.559f, 0.309f, 0.553f, 0.51f, 0.121f, 0.848f, 0.998f, 0.297f, 0.907f, 0.119f,
			0.078f, 0.514f, 0.842f, 0.725f, 0.026f, 0.892f, 0.852f, 0.224f, 0.539f, 0.124f,
			0.057f, 0.087f, 0.053f, 0.95f, 0.887f, 0.593f, 0.797f, 0.284f, 0.707f, 0.112f,
			0.835f, 0.446f, 0.606f, 0.574f, 0.592f, 0.393f, 0.146f, 0.308f, 0.249f, 0.922f,
			0.366f, 0.724f, 0.339f, 0.014f, 0.124f, 0.22f, 0.227f, 0.973f, 0.716f, 0.758f,
			0.84f, 0.206f, 0.681f, 0.508f, 0.037f, 0.471f, 0.255f, 0.603f, 0.623f, 0.528f,
			0.051f, 0.714f, 0.59f, 0.796f, 0.285f, 0.632f, 0.908f, 0.267f, 0.133f, 0.633f,
			0.746f, 0.544f, 0.975f, 0.617f, 0.758f, 0.333f, 0.748f, 0.039f, 0.826f, 0.667f,
			0.366f, 0.824f, 0.569f, 0.949f, 0.271f, 0.629f, 0.765f, 0.097f, 0.538f, 0.121f,
			0.138f, 0.543f, 0.685f, 0.721f, 0.871f, 0.652f, 0.133f, 0.544f, 0.73f, 0.492f,
			0.312f, 0.96f, 0.84f, 0.083f, 0.012f, 0.297f, 0.231f, 0.064f, 0.75f, 0.703f,
			0.723f, 0.216f, 0.776f, 0.955f, 0.163f, 0.227f, 0.145f, 0.641f, 0.524f, 0.656f,
			0.867f, 0.811f, 0.729f, 0.012f, 0.495f, 0.203f, 0.859f, 0.254f, 0.747f, 0.106f,
			0.2f, 0.205f, 0.31f, 0.334f, 0.356f, 0.406f, 0.984f, 0.486f, 0.937f, 0.975f,
			0.398f, 0.701f, 0.347f, 0.835f, 0.398f, 0.921f, 0.767f, 0.73f, 0.558f, 0.644f,
			0.507f, 0.493f, 0.02f, 0.074f, 0.625f, 0.5f, 0.23f, 0.828f, 0.588f, 0.809f,
			0.438f, 0.977f, 0.317f, 0.644f, 0.503f, 0.518f, 0.906f, 0.442f, 0.6f, 0.757f,
			0.243f, 0.659f, 0.703f, 0.549f, 0.257f, 0.166f, 0.464f, 0.895f, 0.614f, 0.574f,
			0.436f, 0.129f, 0.696f, 0.103f, 0.599f, 0.707f, 0.185f, 0.236f, 0.71f, 0.856f,
			0.175f, 0.155f, 0.897f, 0.128f, 0.537f, 0.421f, 0.384f, 0.703f, 0.332f, 0.879f,
			0.015f, 0.325f, 0.13f, 0.801f, 0.4f, 0.848f, 0.789f, 0.47f, 0.817f, 0.459f,
			0.036f, 0.336f, 0.214f, 0.014f, 0.373f, 0.309f, 0.281f, 0.214f, 0.045f, 0.796f,
			0.333f, 0.671f, 0.732f, 0.744f, 0.582f, 0.088f, 0.762f, 0.575f, 0.012f, 0.836f,
			0.782f, 0.762f, 0.563f, 0.735f, 0.559f, 0.11f, 0.999f, 0.895f, 0.703f, 0.751f,
			0.918f, 0.715f, 0.419f, 0.251f, 0.82f, 0.84f, 0.941f, 0.883f, 0.755f, 0.228f,
			0.14f, 0.17f, 0.657f, 0.536f, 0.546f, 0.344f, 0.594f, 0.386f, 0.219f, 0.312f,
			0.086f, 0.214f, 0.458f, 0.981f, 0.676f, 0.274f, 0.772f, 0.479f, 0.456f, 0.263f,
			0.31f, 0.387f, 0.511f, 0.294f, 0.877f, 0.618f, 0.252f, 0.481f, 0.924f, 0.742f,
			0.147f, 0.879f, 0.82f, 0.784f, 0.697f, 0.612f, 0.104f, 0.027f, 0.189f, 0.215f,
			0.517f, 0.613f, 0.675f, 0.391f, 0.666f, 0.704f, 0.257f, 0.438f, 0.575f, 0.546f,
			0.067f, 0.462f, 0.427f, 0.492f, 0.918f, 0.753f, 0.659f, 0.364f, 0.658f, 0.928f,
			0.092f, 0.113f, 0.461f, 0.478f, 0.165f, 0.207f, 0.394f, 0.674f, 0.284f, 0.064f,
			0.17f, 0.745f, 0.291f, 0.241f, 0.747f, 0.696f, 0.711f, 0.12f, 0.628f, 0.173f,
			0.362f, 0.813f, 0.906f, 0.379f, 0.674f, 0.685f, 0.452f, 0.328f, 0.866f, 0.944f,
			0.953f, 0.741f, 0.369f, 0.261f, 0.122f, 0.404f, 0.152f, 0.198f, 0.225f, 0.459f,
			0.31f, 0.583f, 0.154f, 0.511f, 0.376f, 0.322f, 0.171f, 0.186f, 0.745f, 0.222f,
			0.042f, 0.539f, 0.735f, 0.485f, 0.566f, 0.279f, 0.207f, 0.082f, 0.803f, 0.48f,
			0.755f, 0.066f, 0.808f, 0.34f, 0.111f, 0.429f, 0.376f, 0.029f, 0.119f, 0.343f,
			0.544f, 0.514f, 0.895f, 0.169f, 0.863f, 0.779f, 0.659f, 0.395f, 0.002f, 0.352f,
			0.514f, 0.265f, 0.583f, 0.644f, 0.902f, 0.414f, 0.005f, 0.884f, 0.695f, 0.843f,
			0.197f, 0.07f, 0.394f, 0.746f, 0.704f, 0.244f, 0.775f, 0.814f, 0.399f, 0.948f,
			0.946f, 0.142f, 0.068f, 0.403f, 0.678f, 0.528f, 0.644f, 0.566f, 0.622f, 0.787f,
			0.62f, 0.812f, 0.08f, 0.451f, 0.966f, 0.49f, 0.483f, 0.164f, 0.439f, 0.698f,
			0.423f, 0.493f, 0.334f, 0.275f, 0.146f, 0.474f, 0.119f, 0.149f, 0.465f, 0.619f,
			0.004f, 0.845f, 0.996f, 0.055f, 0.406f, 0.372f, 0.197f, 0.181f, 0.967f, 0.374f,
			0.77f, 0.439f, 0.261f, 0.908f, 0.223f, 0.385f, 0.99f, 0.943f, 0.78f, 0.214f,
			0.762f, 0.611f, 0.375f, 0.702f, 0.524f, 0.453f, 0.808f, 0.792f, 0.257f, 0.203f,
			0.409f, 0.495f, 0.101f, 0.004f, 0.783f, 0.776f, 0.816f, 0.025f, 0.045f, 0.594f,
			0.292f, 0.302f, 0.197f, 0.065f, 0.928f, 0.984f, 0.231f, 0.426f, 0.053f, 0.761f,
			0.485f, 0.176f, 0.37f, 0.251f, 0.857f, 0.393f, 0.469f, 0.294f, 0.531f, 0.953f,
			0.564f, 0.405f, 0.924f, 0.763f, 0.965f, 0.275f, 0.338f, 0.258f, 0.126f, 0.447f,
			0.569f, 0.964f, 0.898f, 0.186f, 0.922f, 0.46f, 0.415f, 0.31f, 0.774f, 0.54f,
			0.222f, 0.382f, 0.739f, 0.496f, 0.719f, 0.233f, 0.125f, 0.85f, 0.147f, 0.39f,
			0.306f, 0.522f, 0.495f, 0.092f, 0.029f, 0.887f, 0.378f, 0.434f, 0.1f, 0.653f,
			0.647f, 0.973f, 0.3f, 0.606f, 0.192f, 0.52f, 0.278f, 0.184f, 0.329f, 0.397f,
			0.978f, 0.159f, 0.52f, 0.991f, 0.731f, 0.182f, 0.666f, 0.428f, 0.044f, 0.732f,
			0.15f, 0.487f, 0.111f, 0.735f, 0.141f, 0.047f, 0.469f, 0.806f, 0.157f, 0.035f,
			0.081f, 0.981f, 0.21f, 0.121f, 0.893f, 0.248f, 0.082f, 0.134f, 0.305f, 0.198f,
			0.954f, 0.941f, 0.521f, 0.75f, 0.412f, 0.147f, 0.002f, 0.504f, 0.361f, 0.847f,
			0.221f, 0.951f, 0.389f, 0.368f, 0.503f, 0.16f, 0.862f, 0.564f, 0.465f, 0.144f,
			0.051f, 0.473f, 0.027f, 0.294f, 0.316f, 0.997f, 0.949f, 0.4f, 0.098f, 0.483f,
			0.1f, 0.532f, 0.123f, 0.846f, 0.778f, 0.209f, 0.966f, 0.362f, 0.323f, 0.993f,
			0.046f, 0.965f, 0.445f, 0.31f, 0.813f, 0.131f, 0.592f, 0.842f, 0.618f, 0.733f,
			0.386f, 0.518f, 0.669f, 0.16f, 0.147f, 0.481f, 0.915f, 0.227f, 0.434f, 0.415f,
			0.199f, 0.602f, 0.406f, 0.877f, 0.747f, 0.689f, 0.828f, 0.543f, 0.59f, 0.295f,
			0.194f, 0.501f, 0.241f, 0.472f, 0.099f, 0.086f, 0.027f, 0.717f, 0.481f, 0.185f,
			0.405f, 0.106f, 0.782f, 0.365f, 0.097f, 0.582f, 0.863f, 0.963f, 0.699f, 0.297f,
			0.294f, 0.739f, 0.927f, 0.908f, 0.794f, 0.444f, 0.56f, 0.568f, 0.563f, 0.124f,
			0.303f, 0.049f, 0.253f, 0.323f, 0.539f, 0.885f, 0.276f, 0.197f, 0.061f, 0.062f,
			0.454f, 0.198f, 0.746f, 0.249f, 0.011f, 0.093f, 0.82f, 0.041f, 0.78f, 0.165f,
			0.826f, 0.865f, 0.845f, 0.293f, 0.001f, 0.455f, 0.573f, 0.334f, 0.678f, 0.655f,
			0.526f, 0.459f, 0.154f, 0.357f, 0.882f, 0.356f, 0.853f, 0.458f, 0.826f, 0.212f,
			0.306f, 0.667f, 0.902f, 0.637f, 0.843f, 0.096f, 0.992f, 0.678f, 0.897f, 0.702f,
			0.623f, 0.519f, 0.788f, 0.398f, 0.298f, 0.438f, 0.204f, 0.96f, 0.323f, 0.084f,
			0.312f, 0.943f, 0.519f, 0.406f, 0.536f, 0.995f, 0.044f, 0.389f, 0.368f, 0.655f,
			0.239f, 0.362f, 0.215f, 0.568f, 0.859f, 0.159f, 0.963f, 0.208f, 0.45f, 0.905f,
			0.463f, 0.895f, 0.437f, 0.976f, 0.032f, 0.007f, 0.672f, 0.755f, 0.059f, 0.444f,
			0.152f, 0.894f, 0.136f, 0.742f, 0.9f, 0.363f, 0.148f, 0.495f, 0.101f, 0.848f,
			0.052f, 0.603f, 0.31f, 0.242f, 0.463f, 0.262f, 0.304f, 0.22f, 0.539f, 0.139f
		};
	}
}
