using System;
using UnityEngine;

// Token: 0x0200064B RID: 1611
internal class BuildingKitTestScene : MonoBehaviour
{
	// Token: 0x060028C1 RID: 10433 RVA: 0x000C0F84 File Offset: 0x000BF184
	private void OnGUI()
	{
		GUI.enabled = true;
		GUILayout.BeginArea(new Rect(100f, 100f, 500f, 500f));
		GUILayout.Box("Please enble #USING_BUILDINGKIT_TEST_SCENE", new GUILayoutOption[] { GUILayout.Width(500f) });
		GUILayout.Box("in BuildingKitTestScene.cs if you want to use", new GUILayoutOption[] { GUILayout.Width(500f) });
		GUILayout.Box("BuildingKit Test Scene.", new GUILayoutOption[] { GUILayout.Width(500f) });
		GUILayout.EndArea();
	}
}
