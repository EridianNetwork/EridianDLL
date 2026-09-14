using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	// Token: 0x02000AEB RID: 2795
	[Serializable]
	public class MB2_MeshCombiner
	{
		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06004BA5 RID: 19365 RVA: 0x0000311D File Offset: 0x0000131D
		public static bool EVAL_VERSION
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06004BA6 RID: 19366 RVA: 0x00031591 File Offset: 0x0002F791
		// (set) Token: 0x06004BA7 RID: 19367 RVA: 0x00031599 File Offset: 0x0002F799
		public string name
		{
			get
			{
				return this.__name;
			}
			set
			{
				this.__name = value;
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06004BA8 RID: 19368 RVA: 0x000315A2 File Offset: 0x0002F7A2
		// (set) Token: 0x06004BA9 RID: 19369 RVA: 0x000315AA File Offset: 0x0002F7AA
		public MB2_TextureBakeResults textureBakeResults
		{
			get
			{
				return this.__textureBakeResults;
			}
			set
			{
				if (this.objectsInCombinedMesh.Count > 0 && this.__textureBakeResults != value && this.__textureBakeResults != null)
				{
					global::UnityEngine.Debug.LogWarning("If material bake result is changed then objects currently in combined mesh may be invalid.");
				}
				this.__textureBakeResults = value;
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06004BAA RID: 19370 RVA: 0x000315E7 File Offset: 0x0002F7E7
		// (set) Token: 0x06004BAB RID: 19371 RVA: 0x000315EF File Offset: 0x0002F7EF
		public Renderer targetRenderer
		{
			get
			{
				return this.__targetRenderer;
			}
			set
			{
				this.__targetRenderer = value;
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06004BAC RID: 19372 RVA: 0x000315F8 File Offset: 0x0002F7F8
		// (set) Token: 0x06004BAD RID: 19373 RVA: 0x00031600 File Offset: 0x0002F800
		public MB_RenderType renderType
		{
			get
			{
				return this.__renderType;
			}
			set
			{
				if (value == MB_RenderType.skinnedMeshRenderer && this.__renderType == MB_RenderType.meshRenderer && this.boneWeights.Length != this.verts.Length)
				{
					global::UnityEngine.Debug.LogError("Can't set the render type to SkinnedMeshRenderer without clearing the mesh first. Try deleteing the CombinedMesh scene object.");
				}
				this.__renderType = value;
			}
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06004BAE RID: 19374 RVA: 0x00031631 File Offset: 0x0002F831
		// (set) Token: 0x06004BAF RID: 19375 RVA: 0x00031639 File Offset: 0x0002F839
		public MB2_OutputOptions outputOption
		{
			get
			{
				return this.__outputOption;
			}
			set
			{
				this.__outputOption = value;
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06004BB0 RID: 19376 RVA: 0x00031642 File Offset: 0x0002F842
		// (set) Token: 0x06004BB1 RID: 19377 RVA: 0x0003164A File Offset: 0x0002F84A
		public MB2_LightmapOptions lightmapOption
		{
			get
			{
				return this.__lightmapOption;
			}
			set
			{
				if (this.objectsInCombinedMesh.Count > 0 && this.__lightmapOption != value)
				{
					global::UnityEngine.Debug.LogWarning("Can't change lightmap option once objects are in the combined mesh.");
				}
				this.__lightmapOption = value;
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x06004BB2 RID: 19378 RVA: 0x00031674 File Offset: 0x0002F874
		// (set) Token: 0x06004BB3 RID: 19379 RVA: 0x0003167C File Offset: 0x0002F87C
		public bool doNorm
		{
			get
			{
				return this.__doNorm;
			}
			set
			{
				this.__doNorm = value;
			}
		}

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06004BB4 RID: 19380 RVA: 0x00031685 File Offset: 0x0002F885
		// (set) Token: 0x06004BB5 RID: 19381 RVA: 0x0003168D File Offset: 0x0002F88D
		public bool doTan
		{
			get
			{
				return this.__doTan;
			}
			set
			{
				this.__doTan = value;
			}
		}

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06004BB6 RID: 19382 RVA: 0x00031696 File Offset: 0x0002F896
		// (set) Token: 0x06004BB7 RID: 19383 RVA: 0x0003169E File Offset: 0x0002F89E
		public bool doCol
		{
			get
			{
				return this.__doCol;
			}
			set
			{
				this.__doCol = value;
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06004BB8 RID: 19384 RVA: 0x000316A7 File Offset: 0x0002F8A7
		// (set) Token: 0x06004BB9 RID: 19385 RVA: 0x000316AF File Offset: 0x0002F8AF
		public bool doUV
		{
			get
			{
				return this.__doUV;
			}
			set
			{
				this.__doUV = value;
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06004BBA RID: 19386 RVA: 0x000316B8 File Offset: 0x0002F8B8
		// (set) Token: 0x06004BBB RID: 19387 RVA: 0x000316C0 File Offset: 0x0002F8C0
		public bool doUV1
		{
			get
			{
				return this.__doUV1;
			}
			set
			{
				this.__doUV1 = value;
			}
		}

		// Token: 0x06004BBC RID: 19388 RVA: 0x000316C9 File Offset: 0x0002F8C9
		private MB2_MeshCombiner.MB_DynamicGameObject instance2Combined_MapGet(GameObject key)
		{
			return this._instance2combined_map[key];
		}

		// Token: 0x06004BBD RID: 19389 RVA: 0x000316D7 File Offset: 0x0002F8D7
		private void instance2Combined_MapAdd(GameObject key, MB2_MeshCombiner.MB_DynamicGameObject dgo)
		{
			this._instance2combined_map.Add(key, dgo);
		}

		// Token: 0x06004BBE RID: 19390 RVA: 0x000316E6 File Offset: 0x0002F8E6
		private void instance2Combined_MapRemove(GameObject key)
		{
			this._instance2combined_map.Remove(key);
		}

		// Token: 0x06004BBF RID: 19391 RVA: 0x000316F5 File Offset: 0x0002F8F5
		private bool instance2Combined_MapTryGetValue(GameObject key, out MB2_MeshCombiner.MB_DynamicGameObject dgo)
		{
			return this._instance2combined_map.TryGetValue(key, out dgo);
		}

		// Token: 0x06004BC0 RID: 19392 RVA: 0x00031704 File Offset: 0x0002F904
		private int instance2Combined_MapCount()
		{
			return this._instance2combined_map.Count;
		}

		// Token: 0x06004BC1 RID: 19393 RVA: 0x00031711 File Offset: 0x0002F911
		private void instance2Combined_MapClear()
		{
			this._instance2combined_map.Clear();
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x0003171E File Offset: 0x0002F91E
		private bool instance2Combined_MapContainsKey(GameObject key)
		{
			return this._instance2combined_map.ContainsKey(key);
		}

		// Token: 0x06004BC3 RID: 19395 RVA: 0x0003172C File Offset: 0x0002F92C
		public bool doUV2()
		{
			return this.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged || this.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping;
		}

		// Token: 0x06004BC4 RID: 19396 RVA: 0x00031743 File Offset: 0x0002F943
		public int GetNumObjectsInCombined()
		{
			return this.objectsInCombinedMesh.Count;
		}

		// Token: 0x06004BC5 RID: 19397 RVA: 0x0013A32C File Offset: 0x0013852C
		public List<GameObject> GetObjectsInCombined()
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(this.objectsInCombinedMesh);
			return list;
		}

		// Token: 0x06004BC6 RID: 19398 RVA: 0x00031750 File Offset: 0x0002F950
		public Mesh GetMesh()
		{
			if (this._mesh == null)
			{
				this._mesh = new Mesh();
			}
			return this._mesh;
		}

		// Token: 0x06004BC7 RID: 19399 RVA: 0x00031771 File Offset: 0x0002F971
		public Transform[] GetBones()
		{
			return this.bones;
		}

		// Token: 0x06004BC8 RID: 19400 RVA: 0x00031779 File Offset: 0x0002F979
		public int GetLightmapIndex()
		{
			if (this.lightmapOption != MB2_LightmapOptions.generate_new_UV2_layout && this.lightmapOption != MB2_LightmapOptions.preserve_current_lightmapping)
			{
				return -1;
			}
			return this.lightmapIndex;
		}

		// Token: 0x06004BC9 RID: 19401 RVA: 0x0013A34C File Offset: 0x0013854C
		public int GetNumVerticesFor(GameObject go)
		{
			MB2_MeshCombiner.MB_DynamicGameObject mb_DynamicGameObject = null;
			if (this.instance2Combined_MapTryGetValue(go, out mb_DynamicGameObject))
			{
				return mb_DynamicGameObject.numVerts;
			}
			return -1;
		}

		// Token: 0x06004BCA RID: 19402 RVA: 0x0013A370 File Offset: 0x00138570
		private void _initialize()
		{
			if (this.objectsInCombinedMesh.Count == 0)
			{
				this.lightmapIndex = -1;
			}
			if (this._mesh == null)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("_initialize Creating new Mesh");
				}
				this._mesh = new Mesh();
			}
			if (this.instance2Combined_MapCount() != this.objectsInCombinedMesh.Count)
			{
				this.instance2Combined_MapClear();
				for (int i = 0; i < this.objectsInCombinedMesh.Count; i++)
				{
					this.instance2Combined_MapAdd(this.objectsInCombinedMesh[i], this.mbDynamicObjectsInCombinedMesh[i]);
				}
				this.boneWeights = this._mesh.boneWeights;
				this.submeshTris = new int[this._mesh.subMeshCount][];
				for (int j = 0; j < this.submeshTris.Length; j++)
				{
					this.submeshTris[j] = this._mesh.GetTriangles(j);
				}
			}
		}

		// Token: 0x06004BCB RID: 19403 RVA: 0x0013A45C File Offset: 0x0013865C
		private bool _collectMaterialTriangles(Mesh m, MB2_MeshCombiner.MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			int num = m.subMeshCount;
			if (sharedMaterials.Length < num)
			{
				num = sharedMaterials.Length;
			}
			dgo._submeshTris = new List<int>[num];
			dgo.targetSubmeshIdxs = new int[num];
			for (int i = 0; i < num; i++)
			{
				dgo._submeshTris[i] = new List<int>();
				if (this.textureBakeResults.doMultiMaterial)
				{
					if (!sourceMats2submeshIdx_map.Contains(sharedMaterials[i]))
					{
						global::UnityEngine.Debug.LogError(string.Concat(new object[]
						{
							"Object ",
							dgo.go,
							" has a material that was not found in the result materials maping. ",
							sharedMaterials[i]
						}));
						return false;
					}
					dgo.targetSubmeshIdxs[i] = (int)sourceMats2submeshIdx_map[sharedMaterials[i]];
				}
				else
				{
					dgo.targetSubmeshIdxs[i] = 0;
				}
				List<int> list = dgo._submeshTris[i];
				int[] triangles = m.GetTriangles(i);
				for (int j = 0; j < triangles.Length; j++)
				{
					list.Add(triangles[j]);
				}
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"Collecting triangles for: ",
						dgo.go.name,
						" submesh:",
						i,
						" maps to submesh:",
						dgo.targetSubmeshIdxs[i],
						" added:",
						triangles.Length
					}));
				}
			}
			return true;
		}

		// Token: 0x06004BCC RID: 19404 RVA: 0x0013A5B8 File Offset: 0x001387B8
		private bool _collectOutOfBoundsUVRects2(Mesh m, MB2_MeshCombiner.MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
		{
			if (this.textureBakeResults == null)
			{
				global::UnityEngine.Debug.LogError("Need to bake textures into combined material");
				return false;
			}
			int num = m.subMeshCount;
			if (sharedMaterials.Length < num)
			{
				num = sharedMaterials.Length;
			}
			dgo.obUVRects = new Rect[num];
			for (int i = 0; i < dgo.obUVRects.Length; i++)
			{
				dgo.obUVRects[i] = new Rect(0f, 0f, 1f, 1f);
			}
			for (int j = 0; j < num; j++)
			{
				Rect rect = default(Rect);
				MB_Utility.hasOutOfBoundsUVs(m, ref rect, j);
				dgo.obUVRects[j] = rect;
			}
			return true;
		}

		// Token: 0x06004BCD RID: 19405 RVA: 0x0013A66C File Offset: 0x0013886C
		private bool _validateTextureBakeResults()
		{
			if (this.textureBakeResults == null)
			{
				global::UnityEngine.Debug.LogError("Material Bake Results is null. Can't combine meshes.");
				return false;
			}
			if (this.textureBakeResults.materials != null && this.textureBakeResults.materials.Length != 0)
			{
				if (this.textureBakeResults.doMultiMaterial)
				{
					if (this.textureBakeResults.resultMaterials == null || this.textureBakeResults.resultMaterials.Length == 0)
					{
						global::UnityEngine.Debug.LogError("Material Bake Results has no result materials. Try baking materials. Can't combine meshes.");
						return false;
					}
				}
				else if (this.textureBakeResults.resultMaterial == null)
				{
					global::UnityEngine.Debug.LogError("Material Bake Results has no result material. Try baking materials. Can't combine meshes.");
					return false;
				}
				return true;
			}
			global::UnityEngine.Debug.LogError("Material Bake Results has no materials in material to uvRect map. Try baking materials. Can't combine meshes.");
			return false;
		}

		// Token: 0x06004BCE RID: 19406 RVA: 0x0013A710 File Offset: 0x00138910
		private bool _validateMeshFlags()
		{
			if (this.objectsInCombinedMesh.Count > 0 && ((!this._doNorm && this.doNorm) || (!this._doTan && this.doTan) || (!this._doCol && this.doCol) || (!this._doUV && this.doUV) || (!this._doUV1 && this.doUV1)))
			{
				global::UnityEngine.Debug.LogError("The channels have changed. There are already objects in the combined mesh that were added with a different set of channels.");
				return false;
			}
			this._doNorm = this.doNorm;
			this._doTan = this.doTan;
			this._doCol = this.doCol;
			this._doUV = this.doUV;
			this._doUV1 = this.doUV1;
			return true;
		}

		// Token: 0x06004BCF RID: 19407 RVA: 0x00031794 File Offset: 0x0002F994
		private bool getIsGameObjectActive(GameObject g)
		{
			return g.activeInHierarchy;
		}

		// Token: 0x06004BD0 RID: 19408 RVA: 0x0013A7C4 File Offset: 0x001389C4
		private bool _showHide(GameObject[] goToShow, GameObject[] goToHide)
		{
			if (goToShow == null)
			{
				goToShow = this.empty;
			}
			if (goToHide == null)
			{
				goToHide = this.empty;
			}
			for (int i = 0; i < goToHide.Length; i++)
			{
				if (!this.instance2Combined_MapContainsKey(goToHide[i]))
				{
					global::UnityEngine.Debug.LogWarning("Trying to hide an object " + goToHide[i] + " that is not in combined mesh");
					return false;
				}
			}
			for (int j = 0; j < goToShow.Length; j++)
			{
				if (!this.instance2Combined_MapContainsKey(goToShow[j]))
				{
					global::UnityEngine.Debug.LogWarning("Trying to show an object " + goToShow[j] + " that is not in combined mesh");
					return false;
				}
			}
			for (int k = 0; k < goToHide.Length; k++)
			{
				this._instance2combined_map[goToHide[k]].show = false;
			}
			for (int l = 0; l < goToShow.Length; l++)
			{
				this._instance2combined_map[goToShow[l]].show = true;
			}
			if (goToShow.Length > 0)
			{
				this.containsHiddenObjects = true;
			}
			return true;
		}

		// Token: 0x06004BD1 RID: 19409 RVA: 0x0013A8A4 File Offset: 0x00138AA4
	private bool _addToCombined(GameObject[] goToAdd, GameObject[] goToDelete, bool disableRendererInSource)
	{
		if (!_validateTextureBakeResults())
		{
			return false;
		}
		if (!_validateMeshFlags())
		{
			return false;
		}
		if (outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace && renderType == MB_RenderType.skinnedMeshRenderer && (targetRenderer == null || !(__targetRenderer is SkinnedMeshRenderer)))
		{
			UnityEngine.Debug.LogError("Target renderer must be set and must be a SkinnedMeshRenderer");
			return false;
		}
		GameObject[] _goToAdd;
		if (goToAdd == null)
		{
			_goToAdd = empty;
		}
		else
		{
			_goToAdd = (GameObject[])goToAdd.Clone();
		}
		GameObject[] array = ((goToDelete != null) ? ((GameObject[])goToDelete.Clone()) : empty);
		if (_mesh == null)
		{
			DestroyMesh();
		}
		Dictionary<Material, Rect> dictionary = textureBakeResults.method_0();
		_initialize();
		int num = 1;
		if (textureBakeResults.doMultiMaterial)
		{
			num = textureBakeResults.resultMaterials.Length;
		}
		if (VERBOSE)
		{
			UnityEngine.Debug.Log("_addToCombined objs adding:" + _goToAdd.Length + " objs deleting:" + array.Length + " fixOutOfBounds:" + textureBakeResults.fixOutOfBoundsUVs + " doMultiMaterial:" + textureBakeResults.doMultiMaterial + " disableRenderersInSource:" + disableRendererInSource);
		}
		OrderedDictionary orderedDictionary = null;
		if (textureBakeResults.doMultiMaterial)
		{
			orderedDictionary = new OrderedDictionary();
			for (int j = 0; j < num; j++)
			{
				MB_MultiMaterial mB_MultiMaterial = textureBakeResults.resultMaterials[j];
				for (int k = 0; k < mB_MultiMaterial.sourceMaterials.Count; k++)
				{
					if (!(mB_MultiMaterial.sourceMaterials[k] == null))
					{
						if (!orderedDictionary.Contains(mB_MultiMaterial.sourceMaterials[k]))
						{
							orderedDictionary.Add(mB_MultiMaterial.sourceMaterials[k], j);
						}
						continue;
					}
					UnityEngine.Debug.LogError("Found null material in source materials for combined mesh materials " + j);
					return false;
				}
			}
		}
		if (submeshTris.Length != num)
		{
			submeshTris = new int[num][];
			for (int l = 0; l < submeshTris.Length; l++)
			{
				submeshTris[l] = new int[0];
			}
		}
		int num2 = 0;
		int num3 = 0;
		int[] array2 = new int[num];
		for (int m = 0; m < array.Length; m++)
		{
			if (instance2Combined_MapTryGetValue(array[m], out var dgo))
			{
				num2 += dgo.numVerts;
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					num3 += dgo.numBones;
				}
				for (int n = 0; n < dgo.submeshNumTris.Length; n++)
				{
					array2[n] += dgo.submeshNumTris[n];
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("Trying to delete an object that is not in combined mesh");
			}
		}
		List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
		int num4 = 0;
		int num5 = 0;
		int[] array3 = new int[num];
		int i = 0;
		Vector2 vector3 = default(Vector2);
		while (true)
		{
			if (i < _goToAdd.Length)
			{
				if (instance2Combined_MapContainsKey(_goToAdd[i]) && !Array.Find(array, (GameObject o) => o == _goToAdd[i]))
				{
					UnityEngine.Debug.LogWarning("Object " + _goToAdd[i].name + " has already been added");
					_goToAdd[i] = null;
				}
				else
				{
					MB_DynamicGameObject mB_DynamicGameObject = new MB_DynamicGameObject();
					GameObject gameObject = _goToAdd[i];
					Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
					if (gOMaterials == null)
					{
						UnityEngine.Debug.LogError("Object " + gameObject.name + " does not have a Renderer");
						_goToAdd[i] = null;
						return false;
					}
					Mesh mesh = MB_Utility.GetMesh(gameObject);
					if (mesh == null)
					{
						UnityEngine.Debug.LogError("Object " + gameObject.name + " MeshFilter or SkinedMeshRenderer had no mesh");
						_goToAdd[i] = null;
						return false;
					}
					Rect[] array4 = new Rect[gOMaterials.Length];
					for (int num6 = 0; num6 < gOMaterials.Length; num6++)
					{
						if (!dictionary.TryGetValue(gOMaterials[num6], out array4[num6]))
						{
							UnityEngine.Debug.LogError(string.Concat("Object ", gameObject.name, " has an unknown material ", gOMaterials[num6], ". Try baking textures"));
							_goToAdd[i] = null;
						}
					}
					if (_goToAdd[i] != null)
					{
						mB_DynamicGameObject.go = _goToAdd[i];
						mB_DynamicGameObject.uvRects = array4;
						mB_DynamicGameObject.sharedMesh = mesh;
						mB_DynamicGameObject.numVerts = mesh.vertexCount;
						Renderer renderer = MB_Utility.GetRenderer(mB_DynamicGameObject.go);
						mB_DynamicGameObject.numBones = _getNumBones(renderer);
						if (lightmapIndex == -1)
						{
							lightmapIndex = renderer.lightmapIndex;
						}
						if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
						{
							if (lightmapIndex != renderer.lightmapIndex)
							{
								UnityEngine.Debug.LogWarning("Object " + gameObject.name + " has a different lightmap index. Lightmapping will not work.");
							}
							if (!getIsGameObjectActive(mB_DynamicGameObject.go))
							{
								UnityEngine.Debug.LogWarning("Object " + gameObject.name + " is inactive. Can only get lightmap index of active objects.");
							}
							if (renderer.lightmapIndex == -1)
							{
								UnityEngine.Debug.LogWarning("Object " + gameObject.name + " does not have an index to a lightmap.");
							}
						}
						mB_DynamicGameObject.lightmapIndex = renderer.lightmapIndex;
						mB_DynamicGameObject.lightmapTilingOffset = renderer.lightmapTilingOffset;
						if (!_collectMaterialTriangles(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary))
						{
							return false;
						}
						mB_DynamicGameObject.submeshNumTris = new int[num];
						mB_DynamicGameObject.submeshTriIdxs = new int[num];
						if (textureBakeResults.fixOutOfBoundsUVs && !_collectOutOfBoundsUVRects2(mesh, mB_DynamicGameObject, gOMaterials, orderedDictionary))
						{
							break;
						}
						list.Add(mB_DynamicGameObject);
						num4 += mB_DynamicGameObject.numVerts;
						if (renderType == MB_RenderType.skinnedMeshRenderer)
						{
							num5 += mB_DynamicGameObject.numBones;
						}
						for (int num7 = 0; num7 < mB_DynamicGameObject._submeshTris.Length; num7++)
						{
							array3[mB_DynamicGameObject.targetSubmeshIdxs[num7]] += mB_DynamicGameObject._submeshTris[num7].Count;
						}
					}
				}
				i++;
				continue;
			}
			for (int num8 = 0; num8 < _goToAdd.Length; num8++)
			{
				if (_goToAdd[num8] != null && disableRendererInSource)
				{
					MB_Utility.DisableRendererInSource(_goToAdd[num8]);
				}
			}
			int num9 = verts.Length + num4 - num2;
			int num10 = bindPoses.Length + num5 - num3;
			int[] array5 = new int[num];
			if (VERBOSE)
			{
				UnityEngine.Debug.Log("Verts adding:" + num4 + " deleting:" + num2);
			}
			if (VERBOSE)
			{
				UnityEngine.Debug.Log("Submeshes:" + array5.Length);
			}
			for (int num11 = 0; num11 < array5.Length; num11++)
			{
				array5[num11] = submeshTris[num11].Length + array3[num11] - array2[num11];
				if (VERBOSE)
				{
					UnityEngine.Debug.Log("    submesh :" + num11 + " already contains:" + submeshTris[num11].Length + " trisAdded:" + array3[num11] + " trisDeleted:" + array2[num11]);
				}
			}
			if (num9 > 65534)
			{
				UnityEngine.Debug.LogError("Cannot add objects. Resulting mesh will have more than 64k vertices. Try using a Multi-MeshBaker component. This will split the combined mesh into several meshes. You don't have to re-configure the MB2_TextureBaker. Just remove the MB2_MeshBaker component and add a MB2_MultiMeshBaker component.");
				return false;
			}
			Vector3[] destinationArray = null;
			Vector4[] destinationArray2 = null;
			Vector2[] destinationArray3 = null;
			Vector2[] destinationArray4 = null;
			Vector2[] destinationArray5 = null;
			Color[] destinationArray6 = null;
			Vector3[] destinationArray7 = new Vector3[num9];
			if (_doNorm)
			{
				destinationArray = new Vector3[num9];
			}
			if (_doTan)
			{
				destinationArray2 = new Vector4[num9];
			}
			if (_doUV)
			{
				destinationArray3 = new Vector2[num9];
			}
			if (_doUV1)
			{
				destinationArray4 = new Vector2[num9];
			}
			if (lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged || lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				destinationArray5 = new Vector2[num9];
			}
			if (_doCol)
			{
				destinationArray6 = new Color[num9];
			}
			BoneWeight[] destinationArray8 = new BoneWeight[num9];
			Matrix4x4[] array6 = new Matrix4x4[num10];
			Transform[] destinationArray9 = new Transform[num10];
			int[][] array7 = null;
			array7 = new int[num][];
			for (int num12 = 0; num12 < array7.Length; num12++)
			{
				array7[num12] = new int[array5[num12]];
			}
			for (int num13 = 0; num13 < array.Length; num13++)
			{
				MB_DynamicGameObject dgo2 = null;
				if (instance2Combined_MapTryGetValue(array[num13], out dgo2))
				{
					dgo2._beingDeleted = true;
				}
			}
			mbDynamicObjectsInCombinedMesh.Sort();
			int num14 = 0;
			int num15 = 0;
			int[] array8 = new int[num];
			int num16 = 0;
			int num17 = 0;
			containsHiddenObjects = false;
			for (int num18 = 0; num18 < mbDynamicObjectsInCombinedMesh.Count; num18++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[num18];
				if (!mB_DynamicGameObject2._beingDeleted)
				{
					if (VERBOSE)
					{
						UnityEngine.Debug.Log("Copying obj in combined arrays idx:" + num18);
					}
					if (!mB_DynamicGameObject2.show)
					{
						containsHiddenObjects = true;
					}
					Array.Copy(verts, mB_DynamicGameObject2.vertIdx, destinationArray7, num14, mB_DynamicGameObject2.numVerts);
					if (_doNorm)
					{
						Array.Copy(normals, mB_DynamicGameObject2.vertIdx, destinationArray, num14, mB_DynamicGameObject2.numVerts);
					}
					if (_doTan)
					{
						Array.Copy(tangents, mB_DynamicGameObject2.vertIdx, destinationArray2, num14, mB_DynamicGameObject2.numVerts);
					}
					if (_doUV)
					{
						Array.Copy(uvs, mB_DynamicGameObject2.vertIdx, destinationArray3, num14, mB_DynamicGameObject2.numVerts);
					}
					if (_doUV1)
					{
						Array.Copy(uv1s, mB_DynamicGameObject2.vertIdx, destinationArray4, num14, mB_DynamicGameObject2.numVerts);
					}
					if (doUV2())
					{
						Array.Copy(uv2s, mB_DynamicGameObject2.vertIdx, destinationArray5, num14, mB_DynamicGameObject2.numVerts);
					}
					if (_doCol)
					{
						Array.Copy(colors, mB_DynamicGameObject2.vertIdx, destinationArray6, num14, mB_DynamicGameObject2.numVerts);
					}
					if (renderType == MB_RenderType.skinnedMeshRenderer)
					{
						for (int num19 = mB_DynamicGameObject2.vertIdx; num19 < mB_DynamicGameObject2.vertIdx + mB_DynamicGameObject2.numVerts; num19++)
						{
							boneWeights[num19].boneIndex0 = boneWeights[num19].boneIndex0 - num17;
							boneWeights[num19].boneIndex1 = boneWeights[num19].boneIndex1 - num17;
							boneWeights[num19].boneIndex2 = boneWeights[num19].boneIndex2 - num17;
							boneWeights[num19].boneIndex3 = boneWeights[num19].boneIndex3 - num17;
						}
						Array.Copy(boneWeights, mB_DynamicGameObject2.vertIdx, destinationArray8, num14, mB_DynamicGameObject2.numVerts);
					}
					Array.Copy(bindPoses, mB_DynamicGameObject2.bonesIdx, array6, num15, mB_DynamicGameObject2.numBones);
					Array.Copy(bones, mB_DynamicGameObject2.bonesIdx, destinationArray9, num15, mB_DynamicGameObject2.numBones);
					for (int num20 = 0; num20 < num; num20++)
					{
						int[] array9 = submeshTris[num20];
						int num21 = mB_DynamicGameObject2.submeshTriIdxs[num20];
						int num22 = mB_DynamicGameObject2.submeshNumTris[num20];
						if (VERBOSE)
						{
							UnityEngine.Debug.Log("    Adjusting submesh triangles submesh:" + num20 + " startIdx:" + num21 + " num:" + num22);
						}
						for (int num23 = num21; num23 < num21 + num22; num23++)
						{
							array9[num23] -= num16;
						}
						Array.Copy(array9, num21, array7[num20], array8[num20], num22);
					}
					mB_DynamicGameObject2.bonesIdx = num15;
					mB_DynamicGameObject2.vertIdx = num14;
					for (int num24 = 0; num24 < array8.Length; num24++)
					{
						mB_DynamicGameObject2.submeshTriIdxs[num24] = array8[num24];
						array8[num24] += mB_DynamicGameObject2.submeshNumTris[num24];
					}
					num15 += mB_DynamicGameObject2.numBones;
					num14 += mB_DynamicGameObject2.numVerts;
				}
				else
				{
					if (VERBOSE)
					{
						UnityEngine.Debug.Log("Not copying obj: " + num18);
					}
					num16 += mB_DynamicGameObject2.numVerts;
					num17 += mB_DynamicGameObject2.numBones;
				}
			}
			for (int num25 = mbDynamicObjectsInCombinedMesh.Count - 1; num25 >= 0; num25--)
			{
				if (mbDynamicObjectsInCombinedMesh[num25]._beingDeleted)
				{
					instance2Combined_MapRemove(mbDynamicObjectsInCombinedMesh[num25].go);
					objectsInCombinedMesh.RemoveAt(num25);
					mbDynamicObjectsInCombinedMesh.RemoveAt(num25);
				}
			}
			verts = destinationArray7;
			if (_doNorm)
			{
				normals = destinationArray;
			}
			if (_doTan)
			{
				tangents = destinationArray2;
			}
			if (_doUV)
			{
				uvs = destinationArray3;
			}
			if (_doUV1)
			{
				uv1s = destinationArray4;
			}
			if (doUV2())
			{
				uv2s = destinationArray5;
			}
			if (_doCol)
			{
				colors = destinationArray6;
			}
			if (renderType == MB_RenderType.skinnedMeshRenderer)
			{
				boneWeights = destinationArray8;
			}
			bindPoses = array6;
			bones = destinationArray9;
			submeshTris = array7;
			for (int num26 = 0; num26 < list.Count; num26++)
			{
				MB_DynamicGameObject mB_DynamicGameObject3 = list[num26];
				GameObject go = mB_DynamicGameObject3.go;
				int num27 = num14;
				int num28 = num15;
				Mesh sharedMesh = mB_DynamicGameObject3.sharedMesh;
				Matrix4x4 localToWorldMatrix = go.transform.localToWorldMatrix;
				Quaternion rotation = go.transform.rotation;
				destinationArray7 = sharedMesh.vertices;
				Vector3[] array10 = null;
				Vector4[] array11 = null;
				if (_doNorm)
				{
					array10 = _getMeshNormals(sharedMesh);
				}
				if (_doTan)
				{
					array11 = _getMeshTangents(sharedMesh);
				}
				if (renderType != MB_RenderType.skinnedMeshRenderer)
				{
					for (int num29 = 0; num29 < destinationArray7.Length; num29++)
					{
						ref Vector3 reference = ref destinationArray7[num29];
						reference = localToWorldMatrix.MultiplyPoint(destinationArray7[num29]);
						if (_doNorm)
						{
							ref Vector3 reference2 = ref array10[num29];
							reference2 = rotation * array10[num29];
						}
						if (_doTan)
						{
							float w = array11[num29].w;
							ref Vector4 reference3 = ref array11[num29];
							reference3 = rotation * array11[num29];
							array11[num29].w = w;
						}
					}
				}
				if (_doNorm)
				{
					array10.CopyTo(normals, num27);
				}
				if (_doTan)
				{
					array11.CopyTo(tangents, num27);
				}
				destinationArray7.CopyTo(verts, num27);
				int subMeshCount = sharedMesh.subMeshCount;
				if (mB_DynamicGameObject3.uvRects.Length < subMeshCount)
				{
					UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject3.go.name + " has more submeshes than materials");
					subMeshCount = mB_DynamicGameObject3.uvRects.Length;
				}
				else if (mB_DynamicGameObject3.uvRects.Length > subMeshCount)
				{
					UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject3.go.name + " has fewer submeshes than materials");
				}
				if (_doUV)
				{
					destinationArray3 = _getMeshUVs(sharedMesh);
					int[] array12 = new int[destinationArray3.Length];
					for (int num30 = 0; num30 < array12.Length; num30++)
					{
						array12[num30] = -1;
					}
					bool flag = false;
					Rect rect = default(Rect);
					for (int num31 = 0; num31 < mB_DynamicGameObject3._submeshTris.Length; num31++)
					{
						List<int> list2 = mB_DynamicGameObject3._submeshTris[num31];
						Rect rect2 = mB_DynamicGameObject3.uvRects[num31];
						if (textureBakeResults.fixOutOfBoundsUVs)
						{
							rect = mB_DynamicGameObject3.obUVRects[num31];
						}
						for (int num32 = 0; num32 < list2.Count; num32++)
						{
							int num33 = list2[num32];
							if (array12[num33] == -1)
							{
								array12[num33] = num31;
								if (textureBakeResults.fixOutOfBoundsUVs)
								{
									destinationArray3[num33].x = destinationArray3[num33].x / rect.width - rect.x / rect.width;
									destinationArray3[num33].y = destinationArray3[num33].y / rect.height - rect.y / rect.height;
								}
								destinationArray3[num33].x = rect2.x + destinationArray3[num33].x * rect2.width;
								destinationArray3[num33].y = rect2.y + destinationArray3[num33].y * rect2.height;
							}
							if (array12[num33] != num31)
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						UnityEngine.Debug.LogWarning(mB_DynamicGameObject3.go.name + "has submeshes which share verticies. Adjusted uvs may not map correctly in combined atlas.");
					}
					destinationArray3.CopyTo(uvs, num27);
				}
				if (doUV2())
				{
					destinationArray5 = _getMeshUV2s(sharedMesh);
					if (lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
					{
						Vector4 lightmapTilingOffset = mB_DynamicGameObject3.lightmapTilingOffset;
						Vector2 vector = new Vector2(lightmapTilingOffset.x, lightmapTilingOffset.y);
						Vector2 vector2 = new Vector2(lightmapTilingOffset.z, lightmapTilingOffset.w);
						for (int num34 = 0; num34 < destinationArray5.Length; num34++)
						{
							vector3.x = vector.x * destinationArray5[num34].x;
							vector3.y = vector.y * destinationArray5[num34].y;
							ref Vector2 reference4 = ref destinationArray5[num34];
							reference4 = vector2 + vector3;
						}
					}
					destinationArray5.CopyTo(uv2s, num27);
				}
				if (_doUV1)
				{
					destinationArray4 = _getMeshUV1s(sharedMesh);
					destinationArray4.CopyTo(uv1s, num27);
				}
				if (_doCol)
				{
					destinationArray6 = _getMeshColors(sharedMesh);
					destinationArray6.CopyTo(colors, num27);
				}
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					Renderer renderer2 = MB_Utility.GetRenderer(mB_DynamicGameObject3.go);
					destinationArray9 = _getBones(renderer2);
					destinationArray9.CopyTo(bones, num28);
					array6 = _getBindPoses(renderer2);
					array6.CopyTo(bindPoses, num28);
					destinationArray8 = _getBoneWeights(renderer2, mB_DynamicGameObject3.numVerts);
					for (int num35 = 0; num35 < destinationArray8.Length; num35++)
					{
						destinationArray8[num35].boneIndex0 = destinationArray8[num35].boneIndex0 + num28;
						destinationArray8[num35].boneIndex1 = destinationArray8[num35].boneIndex1 + num28;
						destinationArray8[num35].boneIndex2 = destinationArray8[num35].boneIndex2 + num28;
						destinationArray8[num35].boneIndex3 = destinationArray8[num35].boneIndex3 + num28;
					}
					destinationArray8.CopyTo(boneWeights, num27);
				}
				for (int num36 = 0; num36 < array8.Length; num36++)
				{
					mB_DynamicGameObject3.submeshTriIdxs[num36] = array8[num36];
				}
				for (int num37 = 0; num37 < mB_DynamicGameObject3._submeshTris.Length; num37++)
				{
					List<int> list3 = mB_DynamicGameObject3._submeshTris[num37];
					for (int num38 = 0; num38 < list3.Count; num38++)
					{
						list3[num38] += num27;
					}
					int num39 = mB_DynamicGameObject3.targetSubmeshIdxs[num37];
					list3.CopyTo(submeshTris[num39], array8[num39]);
					mB_DynamicGameObject3.submeshNumTris[num39] += list3.Count;
					array8[num39] += list3.Count;
				}
				mB_DynamicGameObject3.vertIdx = num14;
				mB_DynamicGameObject3.bonesIdx = num15;
				instance2Combined_MapAdd(go, mB_DynamicGameObject3);
				objectsInCombinedMesh.Add(go);
				mbDynamicObjectsInCombinedMesh.Add(mB_DynamicGameObject3);
				num14 += destinationArray7.Length;
				num15 += array6.Length;
				for (int num40 = 0; num40 < mB_DynamicGameObject3._submeshTris.Length; num40++)
				{
					mB_DynamicGameObject3._submeshTris[num40].Clear();
				}
				mB_DynamicGameObject3._submeshTris = null;
				if (VERBOSE)
				{
					UnityEngine.Debug.Log("Added to combined:" + mB_DynamicGameObject3.go.name + " verts:" + destinationArray7.Length);
				}
			}
			return true;
		}
		return false;
	}
		// Token: 0x06004BD2 RID: 19410 RVA: 0x0013BE24 File Offset: 0x0013A024
		private Color[] _getMeshColors(Mesh m)
		{
			Color[] array = m.colors;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no colors. Generating");
				}
				if (this._doCol)
				{
					global::UnityEngine.Debug.LogWarning("Mesh " + m + " didn't have colors. Generating an array of white colors");
				}
				array = new Color[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Color.white;
				}
			}
			return array;
		}

		// Token: 0x06004BD3 RID: 19411 RVA: 0x0013BEA4 File Offset: 0x0013A0A4
		private Vector3[] _getMeshNormals(Mesh m)
		{
			Vector3[] array = m.normals;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no normals. Generating");
				}
				global::UnityEngine.Debug.LogWarning("Mesh " + m + " didn't have normals. Generating normals.");
				Mesh mesh = (Mesh)global::UnityEngine.Object.Instantiate(m);
				mesh.RecalculateNormals();
				array = mesh.normals;
				MB_Utility.Destroy(mesh);
			}
			return array;
		}

		// Token: 0x06004BD4 RID: 19412 RVA: 0x0013BF10 File Offset: 0x0013A110
		private Vector4[] _getMeshTangents(Mesh m)
		{
			Vector4[] array = m.tangents;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no tangents. Generating");
				}
				global::UnityEngine.Debug.LogWarning("Mesh " + m + " didn't have tangents. Generating tangents.");
				Vector3[] vertices = m.vertices;
				Vector2[] array2 = this._getMeshUVs(m);
				Vector3[] array3 = this._getMeshNormals(m);
				array = new Vector4[m.vertexCount];
				for (int i = 0; i < m.subMeshCount; i++)
				{
					int[] triangles = m.GetTriangles(i);
					this._generateTangents(triangles, vertices, array2, array3, array);
				}
			}
			return array;
		}

		// Token: 0x06004BD5 RID: 19413 RVA: 0x0013BFAC File Offset: 0x0013A1AC
		private Vector2[] _getMeshUVs(Mesh m)
		{
			Vector2[] array = m.uv;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no uvs. Generating");
				}
				global::UnityEngine.Debug.LogWarning("Mesh " + m + " didn't have uvs. Generating uvs.");
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this._HALF_UV;
				}
			}
			return array;
		}

		// Token: 0x06004BD6 RID: 19414 RVA: 0x0013C024 File Offset: 0x0013A224
		private Vector2[] _getMeshUV1s(Mesh m)
		{
			Vector2[] array = m.uv1;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no uv1s. Generating");
				}
				global::UnityEngine.Debug.LogWarning("Mesh " + m + " didn't have uv1s. Generating uv1s.");
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this._HALF_UV;
				}
			}
			return array;
		}

		// Token: 0x06004BD7 RID: 19415 RVA: 0x0013C09C File Offset: 0x0013A29C
		private Vector2[] _getMeshUV2s(Mesh m)
		{
			Vector2[] array = m.uv2;
			if (array.Length == 0)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Mesh " + m + " has no uv2s. Generating");
				}
				global::UnityEngine.Debug.LogWarning(string.Concat(new object[] { "Mesh ", m, " didn't have uv2s. Lightmapping option was set to ", this.lightmapOption, " Generating uv2s." }));
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this._HALF_UV;
				}
			}
			return array;
		}

		// Token: 0x06004BD8 RID: 19416 RVA: 0x0013C13C File Offset: 0x0013A33C
		public void UpdateSkinnedMeshApproximateBounds()
		{
			if (this.outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
			{
				global::UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
				return;
			}
			if (this.bones.Length == 0)
			{
				global::UnityEngine.Debug.LogWarning("No bones in SkinnedMeshRenderer. Could not UpdateSkinnedMeshApproximateBounds.");
				return;
			}
			if (this.targetRenderer == null)
			{
				global::UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBounds.");
				return;
			}
			if (!this.__targetRenderer.GetType().Equals(typeof(SkinnedMeshRenderer)))
			{
				global::UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBounds.");
				return;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)this.targetRenderer;
			Vector3 position = this.bones[0].position;
			Vector3 position2 = this.bones[0].position;
			for (int i = 1; i < this.bones.Length; i++)
			{
				Vector3 position3 = this.bones[i].position;
				if (position3.x < position2.x)
				{
					position2.x = position3.x;
				}
				if (position3.y < position2.y)
				{
					position2.y = position3.y;
				}
				if (position3.z < position2.z)
				{
					position2.z = position3.z;
				}
				if (position3.x > position.x)
				{
					position.x = position3.x;
				}
				if (position3.y > position.y)
				{
					position.y = position3.y;
				}
				if (position3.z > position.z)
				{
					position.z = position3.z;
				}
			}
			Vector3 vector = (position + position2) / 2f;
			Vector3 vector2 = position - position2;
			Matrix4x4 worldToLocalMatrix = skinnedMeshRenderer.worldToLocalMatrix;
			Bounds bounds = new Bounds(worldToLocalMatrix * vector, worldToLocalMatrix * vector2);
			skinnedMeshRenderer.localBounds = bounds;
		}

		// Token: 0x06004BD9 RID: 19417 RVA: 0x0003179C File Offset: 0x0002F99C
		private int _getNumBones(Renderer r)
		{
			if (this.renderType != MB_RenderType.skinnedMeshRenderer)
			{
				return 0;
			}
			if (r is SkinnedMeshRenderer)
			{
				return ((SkinnedMeshRenderer)r).bones.Length;
			}
			if (r is MeshRenderer)
			{
				return 1;
			}
			global::UnityEngine.Debug.LogError("Could not _getNumBones. Object does not have a renderer");
			return 0;
		}

		// Token: 0x06004BDA RID: 19418 RVA: 0x0013C310 File Offset: 0x0013A510
		private Transform[] _getBones(Renderer r)
		{
			if (r is SkinnedMeshRenderer)
			{
				return ((SkinnedMeshRenderer)r).bones;
			}
			if (r is MeshRenderer)
			{
				return new Transform[] { r.transform };
			}
			global::UnityEngine.Debug.LogError("Could not getBones. Object does not have a renderer");
			return null;
		}

		// Token: 0x06004BDB RID: 19419 RVA: 0x0013C358 File Offset: 0x0013A558
		private Matrix4x4[] _getBindPoses(Renderer r)
		{
			if (r is SkinnedMeshRenderer)
			{
				return ((SkinnedMeshRenderer)r).sharedMesh.bindposes;
			}
			if (r is MeshRenderer)
			{
				Matrix4x4 identity = Matrix4x4.identity;
				return new Matrix4x4[] { identity };
			}
			global::UnityEngine.Debug.LogError("Could not _getBindPoses. Object does not have a renderer");
			return null;
		}

		// Token: 0x06004BDC RID: 19420 RVA: 0x0013C3B0 File Offset: 0x0013A5B0
		private BoneWeight[] _getBoneWeights(Renderer r, int numVerts)
		{
			if (r is SkinnedMeshRenderer)
			{
				return ((SkinnedMeshRenderer)r).sharedMesh.boneWeights;
			}
			if (r is MeshRenderer)
			{
				BoneWeight boneWeight = default(BoneWeight);
				boneWeight.boneIndex3 = 0;
				boneWeight.boneIndex2 = 0;
				boneWeight.boneIndex1 = 0;
				boneWeight.boneIndex0 = 0;
				boneWeight.weight0 = 1f;
				float num = 0f;
				boneWeight.weight3 = num;
				num = num;
				boneWeight.weight2 = num;
				boneWeight.weight1 = num;
				BoneWeight[] array = new BoneWeight[numVerts];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = boneWeight;
				}
				return array;
			}
			global::UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
			return null;
		}

		// Token: 0x06004BDD RID: 19421 RVA: 0x0013C464 File Offset: 0x0013A664
		public void Apply()
		{
			bool flag = false;
			if (this.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				flag = true;
			}
			this.Apply(true, true, this._doNorm, this._doTan, this._doUV, this._doCol, this._doUV1, this.doUV2(), flag);
		}

		// Token: 0x06004BDE RID: 19422 RVA: 0x0013C4AC File Offset: 0x0013A6AC
		public void ApplyShowHide()
		{
			if (this._mesh != null)
			{
				this._mesh.Clear(true);
				this._mesh.vertices = this.verts;
				int[][] submeshTrisWithShowHideApplied = this.GetSubmeshTrisWithShowHideApplied();
				if (this.textureBakeResults.doMultiMaterial)
				{
					this._mesh.subMeshCount = submeshTrisWithShowHideApplied.Length;
					for (int i = 0; i < submeshTrisWithShowHideApplied.Length; i++)
					{
						this._mesh.SetTriangles(submeshTrisWithShowHideApplied[i], i);
					}
				}
				else
				{
					this._mesh.triangles = submeshTrisWithShowHideApplied[0];
				}
			}
			else
			{
				global::UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling ApplyShowHide");
			}
		}

		// Token: 0x06004BDF RID: 19423 RVA: 0x0013C540 File Offset: 0x0013A740
		[Obsolete("ApplyAll is deprecated, please use Apply instead.")]
		public void ApplyAll()
		{
			this.Apply(true, true, this._doNorm, this._doTan, this._doUV, this._doCol, this._doUV1, this.doUV2(), true);
		}

		// Token: 0x06004BE0 RID: 19424 RVA: 0x0013C57C File Offset: 0x0013A77C
		public void Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool colors, bool uv1, bool uv2, bool bones = false)
		{
			if (this._mesh != null)
			{
				if (triangles || this._mesh.vertexCount != this.verts.Length)
				{
					if (triangles && !vertices && !normals && !tangents && !uvs && !colors && !uv1 && !uv2 && !bones)
					{
						this._mesh.Clear(true);
					}
					else
					{
						this._mesh.Clear(false);
					}
				}
				if (vertices)
				{
					this._mesh.vertices = this.verts;
				}
				if (triangles)
				{
					int[][] submeshTrisWithShowHideApplied = this.GetSubmeshTrisWithShowHideApplied();
					if (this.textureBakeResults.doMultiMaterial)
					{
						this._mesh.subMeshCount = submeshTrisWithShowHideApplied.Length;
						for (int i = 0; i < submeshTrisWithShowHideApplied.Length; i++)
						{
							this._mesh.SetTriangles(submeshTrisWithShowHideApplied[i], i);
						}
					}
					else
					{
						this._mesh.triangles = submeshTrisWithShowHideApplied[0];
					}
				}
				if (normals)
				{
					if (this._doNorm)
					{
						this._mesh.normals = this.normals;
					}
					else
					{
						global::UnityEngine.Debug.LogError("normal flag was set in Apply but MeshBaker didn't generate normals");
					}
				}
				if (tangents)
				{
					if (this._doTan)
					{
						this._mesh.tangents = this.tangents;
					}
					else
					{
						global::UnityEngine.Debug.LogError("tangent flag was set in Apply but MeshBaker didn't generate tangents");
					}
				}
				if (uvs)
				{
					if (this._doUV)
					{
						this._mesh.uv = this.uvs;
					}
					else
					{
						global::UnityEngine.Debug.LogError("uv flag was set in Apply but MeshBaker didn't generate uvs");
					}
				}
				if (colors)
				{
					if (this._doCol)
					{
						this._mesh.colors = this.colors;
					}
					else
					{
						global::UnityEngine.Debug.LogError("color flag was set in Apply but MeshBaker didn't generate colors");
					}
				}
				if (uv1)
				{
					if (this._doUV1)
					{
						this._mesh.uv1 = this.uv1s;
					}
					else
					{
						global::UnityEngine.Debug.LogError("uv1 flag was set in Apply but MeshBaker didn't generate uv1s");
					}
				}
				if (uv2)
				{
					if (this.doUV2())
					{
						this._mesh.uv2 = this.uv2s;
					}
					else
					{
						global::UnityEngine.Debug.LogError("uv2 flag was set in Apply but lightmapping option was set to " + this.lightmapOption);
					}
				}
				bool flag = false;
				if (this.renderType != MB_RenderType.skinnedMeshRenderer && this.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout && !flag)
				{
					global::UnityEngine.Debug.LogError("Failed to generate new UV2 layout. Only works in editor.");
				}
				if (this.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					if (this.verts.Length == 0)
					{
						this.targetRenderer.enabled = false;
					}
					else
					{
						this.targetRenderer.enabled = true;
					}
				}
				if (bones)
				{
					this._mesh.bindposes = this.bindPoses;
					this._mesh.boneWeights = this.boneWeights;
				}
				if (triangles || vertices)
				{
					this._mesh.RecalculateBounds();
				}
			}
			else
			{
				global::UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling Apply or ApplyAll");
			}
		}

		// Token: 0x06004BE1 RID: 19425 RVA: 0x0013C7EC File Offset: 0x0013A9EC
		public int[][] GetSubmeshTrisWithShowHideApplied()
		{
			if (this.containsHiddenObjects)
			{
				int[] array = new int[this.submeshTris.Length];
				int[][] array2 = new int[this.submeshTris.Length][];
				for (int i = 0; i < this.mbDynamicObjectsInCombinedMesh.Count; i++)
				{
					MB2_MeshCombiner.MB_DynamicGameObject mb_DynamicGameObject = this.mbDynamicObjectsInCombinedMesh[i];
					if (mb_DynamicGameObject.show)
					{
						for (int j = 0; j < mb_DynamicGameObject.submeshNumTris.Length; j++)
						{
							array[j] += mb_DynamicGameObject.submeshNumTris[j];
						}
					}
				}
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = new int[array[k]];
				}
				int[] array3 = new int[array2.Length];
				for (int l = 0; l < this.mbDynamicObjectsInCombinedMesh.Count; l++)
				{
					MB2_MeshCombiner.MB_DynamicGameObject mb_DynamicGameObject2 = this.mbDynamicObjectsInCombinedMesh[l];
					if (mb_DynamicGameObject2.show)
					{
						for (int m = 0; m < this.submeshTris.Length; m++)
						{
							int[] array4 = this.submeshTris[m];
							int num = mb_DynamicGameObject2.submeshTriIdxs[m];
							int num2 = num + mb_DynamicGameObject2.submeshNumTris[m];
							for (int n = num; n < num2; n++)
							{
								array2[m][array3[m]] = array4[n];
								array3[m]++;
							}
						}
					}
				}
				return array2;
			}
			return this.submeshTris;
		}

		// Token: 0x06004BE2 RID: 19426 RVA: 0x000317D4 File Offset: 0x0002F9D4
		public void UpdateGameObjects(GameObject[] gos, bool recalcBounds = true)
		{
			this._updateGameObjects(gos, recalcBounds);
		}

		// Token: 0x06004BE3 RID: 19427 RVA: 0x0013C94C File Offset: 0x0013AB4C
		private void _updateGameObjects(GameObject[] gos, bool recalcBounds)
		{
			this._initialize();
			for (int i = 0; i < gos.Length; i++)
			{
				this._updateGameObject(gos[i], false);
			}
			if (recalcBounds)
			{
				this._mesh.RecalculateBounds();
			}
		}

		// Token: 0x06004BE4 RID: 19428 RVA: 0x0013C988 File Offset: 0x0013AB88
		private void _updateGameObject(GameObject go, bool recalcBounds)
		{
			MB2_MeshCombiner.MB_DynamicGameObject mb_DynamicGameObject = null;
			if (!this.instance2Combined_MapTryGetValue(go, out mb_DynamicGameObject))
			{
				global::UnityEngine.Debug.LogError("Object " + go.name + " has not been added");
				return;
			}
			Mesh sharedMesh = mb_DynamicGameObject.sharedMesh;
			if (mb_DynamicGameObject.numVerts != sharedMesh.vertexCount)
			{
				global::UnityEngine.Debug.LogError("Object " + go.name + " source mesh has been modified since being added");
				return;
			}
			Matrix4x4 localToWorldMatrix = go.transform.localToWorldMatrix;
			Quaternion rotation = go.transform.rotation;
			Vector3[] vertices = sharedMesh.vertices;
			Vector3[] array = sharedMesh.normals;
			Vector4[] array2 = sharedMesh.tangents;
			for (int i = 0; i < vertices.Length; i++)
			{
				int num = mb_DynamicGameObject.vertIdx + i;
				this.verts[num] = localToWorldMatrix.MultiplyPoint3x4(vertices[i]);
				if (this._doNorm)
				{
					this.normals[num] = rotation * array[i];
				}
				if (this._doTan)
				{
					float w = array2[i].w;
					this.tangents[num] = rotation * array2[i];
					this.tangents[num].w = w;
				}
			}
		}

		// Token: 0x06004BE5 RID: 19429 RVA: 0x000317DE File Offset: 0x0002F9DE
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs)
		{
			return this.AddDeleteGameObjects(gos, deleteGOs, true, this.textureBakeResults.fixOutOfBoundsUVs);
		}

		// Token: 0x06004BE6 RID: 19430 RVA: 0x000317F4 File Offset: 0x0002F9F4
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
		{
			return this.AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource, this.textureBakeResults.fixOutOfBoundsUVs);
		}

		// Token: 0x06004BE7 RID: 19431 RVA: 0x0003180A File Offset: 0x0002FA0A
		public bool ShowHideGameObjects(GameObject[] toShow, GameObject[] toHide)
		{
			return this._showHide(toShow, toHide);
		}

		// Token: 0x06004BE8 RID: 19432 RVA: 0x0013CAF4 File Offset: 0x0013ACF4
		public Mesh AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource, bool fixOutOfBoundUVs)
		{
			if (gos != null)
			{
				for (int i = 0; i < gos.Length; i++)
				{
					if (gos[i] == null)
					{
						global::UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
						return null;
					}
					for (int j = i + 1; j < gos.Length; j++)
					{
						if (gos[i] == gos[j])
						{
							global::UnityEngine.Debug.LogError("GameObject " + gos[i] + "appears twice in list of game objects to add");
							return null;
						}
					}
				}
			}
			if (deleteGOs != null)
			{
				for (int k = 0; k < deleteGOs.Length; k++)
				{
					for (int l = k + 1; l < deleteGOs.Length; l++)
					{
						if (deleteGOs[k] == deleteGOs[l] && deleteGOs[k] != null)
						{
							global::UnityEngine.Debug.LogError("GameObject " + deleteGOs[k] + "appears twice in list of game objects to delete");
							return null;
						}
					}
				}
			}
			if (!this._addToCombined(gos, deleteGOs, disableRendererInSource))
			{
				global::UnityEngine.Debug.LogError("Failed to add/delete objects to combined mesh");
				return null;
			}
			if (this.targetRenderer != null && this.outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace)
			{
				if (this.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)this.targetRenderer;
					skinnedMeshRenderer.bones = this.bones;
					this.UpdateSkinnedMeshApproximateBounds();
				}
				this.targetRenderer.lightmapIndex = this.GetLightmapIndex();
			}
			return this._mesh;
		}

		// Token: 0x06004BE9 RID: 19433 RVA: 0x00031814 File Offset: 0x0002FA14
		public bool CombinedMeshContains(GameObject go)
		{
			return this.objectsInCombinedMesh.Contains(go);
		}

		// Token: 0x06004BEA RID: 19434 RVA: 0x0013CC34 File Offset: 0x0013AE34
		private void _clearArrays()
		{
			this.verts = new Vector3[0];
			this.normals = new Vector3[0];
			this.tangents = new Vector4[0];
			this.uvs = new Vector2[0];
			this.uv1s = new Vector2[0];
			this.uv2s = new Vector2[0];
			this.colors = new Color[0];
			this.bones = new Transform[0];
			this.bindPoses = new Matrix4x4[0];
			this.boneWeights = new BoneWeight[0];
			this.submeshTris = new int[0][];
			this.mbDynamicObjectsInCombinedMesh.Clear();
			this.objectsInCombinedMesh.Clear();
			this.instance2Combined_MapClear();
		}

		// Token: 0x06004BEB RID: 19435 RVA: 0x00031822 File Offset: 0x0002FA22
		public void ClearMesh()
		{
			if (this._mesh != null)
			{
				this._mesh.Clear(false);
			}
			else
			{
				this._mesh = new Mesh();
			}
			this._clearArrays();
		}

		// Token: 0x06004BEC RID: 19436 RVA: 0x00031851 File Offset: 0x0002FA51
		public void DestroyMesh()
		{
			if (this._mesh != null)
			{
				if (MB2_MeshCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Destroying Mesh");
				}
				MB_Utility.Destroy(this._mesh);
			}
			this._mesh = new Mesh();
			this._clearArrays();
		}

		// Token: 0x06004BED RID: 19437 RVA: 0x0013CCE4 File Offset: 0x0013AEE4
		private void _generateTangents(int[] triangles, Vector3[] verts, Vector2[] uvs, Vector3[] normals, Vector4[] outTangents)
		{
			int num = triangles.Length;
			int num2 = verts.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			for (int i = 0; i < num; i += 3)
			{
				int num3 = triangles[i];
				int num4 = triangles[i + 1];
				int num5 = triangles[i + 2];
				Vector3 vector = verts[num3];
				Vector3 vector2 = verts[num4];
				Vector3 vector3 = verts[num5];
				Vector2 vector4 = uvs[num3];
				Vector2 vector5 = uvs[num4];
				Vector2 vector6 = uvs[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = num12 * num15 - num13 * num14;
				if (num16 == 0f)
				{
					global::UnityEngine.Debug.LogError("Could not compute tangents. All UVs need to form a valid triangles in UV space. If any UV triangles are collapsed, tangents cannot be generated.");
					return;
				}
				float num17 = 1f / num16;
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
				array[num3] += vector7;
				array[num4] += vector7;
				array[num5] += vector7;
				array2[num3] += vector8;
				array2[num4] += vector8;
				array2[num5] += vector8;
			}
			for (int j = 0; j < num2; j++)
			{
				Vector3 vector9 = normals[j];
				Vector3 vector10 = array[j];
				Vector3 normalized = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
				outTangents[j] = new Vector4(normalized.x, normalized.y, normalized.z);
				outTangents[j].w = ((Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) >= 0f) ? 1f : (-1f));
			}
		}

		// Token: 0x06004BEE RID: 19438 RVA: 0x0003188E File Offset: 0x0002FA8E
		public void SaveMeshsToAssetDatabase(string folderPath, string newFileNameBase)
		{
			global::UnityEngine.Debug.LogError("Can only save meshes in the editor");
		}

		// Token: 0x06004BEF RID: 19439 RVA: 0x0003189A File Offset: 0x0002FA9A
		public void RebuildPrefab(GameObject prefabRoot)
		{
			global::UnityEngine.Debug.LogError("Can only rebuild prefabs in the editor");
		}

		// Token: 0x06004BF0 RID: 19440 RVA: 0x0013D020 File Offset: 0x0013B220
		public GameObject buildSceneMeshObject(GameObject root, Mesh m, bool createNewChild = false)
		{
			MeshFilter meshFilter = null;
			MeshRenderer meshRenderer = null;
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			Transform transform = null;
			if (!createNewChild)
			{
				foreach (object obj in root.transform)
				{
					Transform transform2 = (Transform)obj;
					if (transform2.name.EndsWith("-mesh"))
					{
						transform = transform2;
					}
				}
			}
			GameObject gameObject;
			if (transform == null)
			{
				gameObject = new GameObject(this.name + "-mesh");
			}
			else
			{
				gameObject = transform.gameObject;
			}
			if (this.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == null)
				{
					skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				}
			}
			else
			{
				meshFilter = gameObject.GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = gameObject.AddComponent<MeshFilter>();
				}
				meshRenderer = gameObject.GetComponent<MeshRenderer>();
				if (meshRenderer == null)
				{
					meshRenderer = gameObject.AddComponent<MeshRenderer>();
				}
			}
			if (this.textureBakeResults.doMultiMaterial)
			{
				Material[] array = new Material[this.textureBakeResults.resultMaterials.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.textureBakeResults.resultMaterials[i].combinedMaterial;
				}
				if (this.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					skinnedMeshRenderer.materials = array;
					skinnedMeshRenderer.bones = this.GetBones();
					skinnedMeshRenderer.updateWhenOffscreen = true;
				}
				else
				{
					meshRenderer.sharedMaterials = array;
				}
			}
			else if (this.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				skinnedMeshRenderer.material = this.textureBakeResults.resultMaterial;
				skinnedMeshRenderer.bones = this.GetBones();
			}
			else
			{
				meshRenderer.material = this.textureBakeResults.resultMaterial;
			}
			if (this.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				skinnedMeshRenderer.sharedMesh = m;
				skinnedMeshRenderer.lightmapIndex = this.GetLightmapIndex();
			}
			else
			{
				meshFilter.sharedMesh = m;
				meshRenderer.lightmapIndex = this.GetLightmapIndex();
			}
			if (this.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping || this.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
			{
				gameObject.isStatic = true;
			}
			List<GameObject> objectsInCombined = this.GetObjectsInCombined();
			if (objectsInCombined.Count > 0 && objectsInCombined[0] != null)
			{
				bool flag = true;
				bool flag2 = true;
				string tag = objectsInCombined[0].tag;
				int layer = objectsInCombined[0].layer;
				for (int j = 0; j < objectsInCombined.Count; j++)
				{
					if (objectsInCombined[j] != null)
					{
						if (!objectsInCombined[j].tag.Equals(tag))
						{
							flag = false;
						}
						if (objectsInCombined[j].layer != layer)
						{
							flag2 = false;
						}
					}
				}
				if (flag)
				{
					root.tag = tag;
					gameObject.tag = tag;
				}
				if (flag2)
				{
					root.layer = layer;
					gameObject.layer = layer;
				}
			}
			gameObject.transform.parent = root.transform;
			return gameObject;
		}

		// Token: 0x04003728 RID: 14120
		private static bool VERBOSE;

		// Token: 0x04003729 RID: 14121
		[SerializeField]
		private bool _doNorm = true;

		// Token: 0x0400372A RID: 14122
		[SerializeField]
		private bool _doTan = true;

		// Token: 0x0400372B RID: 14123
		[SerializeField]
		private bool _doCol = true;

		// Token: 0x0400372C RID: 14124
		[SerializeField]
		private bool _doUV = true;

		// Token: 0x0400372D RID: 14125
		[SerializeField]
		private bool _doUV1 = true;

		// Token: 0x0400372E RID: 14126
		[SerializeField]
		private int lightmapIndex = -1;

		// Token: 0x0400372F RID: 14127
		[SerializeField]
		private bool containsHiddenObjects;

		// Token: 0x04003730 RID: 14128
		[SerializeField]
		private List<GameObject> objectsInCombinedMesh = new List<GameObject>();

		// Token: 0x04003731 RID: 14129
		[SerializeField]
		private List<MB2_MeshCombiner.MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = new List<MB2_MeshCombiner.MB_DynamicGameObject>();

		// Token: 0x04003732 RID: 14130
		private Dictionary<GameObject, MB2_MeshCombiner.MB_DynamicGameObject> _instance2combined_map = new Dictionary<GameObject, MB2_MeshCombiner.MB_DynamicGameObject>();

		// Token: 0x04003733 RID: 14131
		[SerializeField]
		private Vector3[] verts = new Vector3[0];

		// Token: 0x04003734 RID: 14132
		[SerializeField]
		private Vector3[] normals = new Vector3[0];

		// Token: 0x04003735 RID: 14133
		[SerializeField]
		private Vector4[] tangents = new Vector4[0];

		// Token: 0x04003736 RID: 14134
		[SerializeField]
		private Vector2[] uvs = new Vector2[0];

		// Token: 0x04003737 RID: 14135
		[SerializeField]
		private Vector2[] uv1s = new Vector2[0];

		// Token: 0x04003738 RID: 14136
		[SerializeField]
		private Vector2[] uv2s = new Vector2[0];

		// Token: 0x04003739 RID: 14137
		[SerializeField]
		private Color[] colors = new Color[0];

		// Token: 0x0400373A RID: 14138
		[SerializeField]
		private Matrix4x4[] bindPoses = new Matrix4x4[0];

		// Token: 0x0400373B RID: 14139
		[SerializeField]
		private Transform[] bones = new Transform[0];

		// Token: 0x0400373C RID: 14140
		[SerializeField]
		private Mesh _mesh;

		// Token: 0x0400373D RID: 14141
		private int[][] submeshTris = new int[0][];

		// Token: 0x0400373E RID: 14142
		private BoneWeight[] boneWeights = new BoneWeight[0];

		// Token: 0x0400373F RID: 14143
		private GameObject[] empty = new GameObject[0];

		// Token: 0x04003740 RID: 14144
		[SerializeField]
		private string __name;

		// Token: 0x04003741 RID: 14145
		[SerializeField]
		private MB2_TextureBakeResults __textureBakeResults;

		// Token: 0x04003742 RID: 14146
		[SerializeField]
		private Renderer __targetRenderer;

		// Token: 0x04003743 RID: 14147
		[SerializeField]
		private MB_RenderType __renderType;

		// Token: 0x04003744 RID: 14148
		[SerializeField]
		private MB2_OutputOptions __outputOption;

		// Token: 0x04003745 RID: 14149
		[SerializeField]
		private MB2_LightmapOptions __lightmapOption;

		// Token: 0x04003746 RID: 14150
		[SerializeField]
		private bool __doNorm;

		// Token: 0x04003747 RID: 14151
		[SerializeField]
		private bool __doTan;

		// Token: 0x04003748 RID: 14152
		[SerializeField]
		private bool __doCol;

		// Token: 0x04003749 RID: 14153
		[SerializeField]
		private bool __doUV;

		// Token: 0x0400374A RID: 14154
		[SerializeField]
		private bool __doUV1;

		// Token: 0x0400374B RID: 14155
		private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

		// Token: 0x02000AEC RID: 2796
		[Serializable]
		private class MB_DynamicGameObject : IComparable<MB2_MeshCombiner.MB_DynamicGameObject>
		{
			// Token: 0x06004BF2 RID: 19442 RVA: 0x000318DB File Offset: 0x0002FADB
			public int CompareTo(MB2_MeshCombiner.MB_DynamicGameObject b)
			{
				return this.vertIdx - b.vertIdx;
			}

			// Token: 0x0400374C RID: 14156
			public GameObject go;

			// Token: 0x0400374D RID: 14157
			public int vertIdx;

			// Token: 0x0400374E RID: 14158
			public int numVerts;

			// Token: 0x0400374F RID: 14159
			public int bonesIdx;

			// Token: 0x04003750 RID: 14160
			public int numBones;

			// Token: 0x04003751 RID: 14161
			public int lightmapIndex = -1;

			// Token: 0x04003752 RID: 14162
			public Vector4 lightmapTilingOffset = new Vector4(1f, 1f, 0f, 0f);

			// Token: 0x04003753 RID: 14163
			public bool show = true;

			// Token: 0x04003754 RID: 14164
			public int[] submeshTriIdxs;

			// Token: 0x04003755 RID: 14165
			public int[] submeshNumTris;

			// Token: 0x04003756 RID: 14166
			public int[] targetSubmeshIdxs;

			// Token: 0x04003757 RID: 14167
			public Rect[] uvRects;

			// Token: 0x04003758 RID: 14168
			public Rect[] obUVRects;

			// Token: 0x04003759 RID: 14169
			public List<int>[] _submeshTris;

			// Token: 0x0400375A RID: 14170
			public Mesh sharedMesh;

			// Token: 0x0400375B RID: 14171
			public bool _beingDeleted;

			// Token: 0x0400375C RID: 14172
			public int _triangleIdxAdjustment;
		}
	}
}
