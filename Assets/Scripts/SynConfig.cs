using UnityEngine;
using System.Collections;
using UnityEditor;

public class SynConfig:AssetPostprocessor{

	static void OnPostprocessAllAssets(string[] importedAssets,string[] deletedAssets,string[] movedAssets,string[] movedAllAssetsPaths){
		foreach(string s in importedAssets)
		{
			if (s.Equals("Assets/SynConfig.cs"))
			{
				AddTag("obstacle");
				AddTag("enemy");
				AddTag("healthPickup");
				AddTag("bombPickup");
				AddTag("ground");


				AddLayer("Ground");
				AddLayer("Enemy");
				AddLayer("Bomb");
				AddLayer("Player");
				AddLayer("Pickup");
				return ;
			}
		}   
	}

	static void AddTag(string tag){
		if (!isHasTag (tag)) {
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();
			if(it.NextVisible(true)){
				if(it.name == "tags"){
					for (int i = 0; i < it.arraySize; i++) {
						SerializedProperty tagProperty = it.GetArrayElementAtIndex(i);
						if(string.IsNullOrEmpty(tagProperty.stringValue)){
							tagProperty.stringValue = tag;
							tagManager.ApplyModifiedProperties();
							return;
						}
					}
				}
			}
		}
	}
	static void AddLayer(string layer){
		if (!isHasLayer (layer)) {
			SerializedObject layerManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = layerManager.GetIterator ();
			if(it.NextVisible(true)){
				if(it.name.StartsWith("User Layer") && it.type == "string"){
					if(string.IsNullOrEmpty(it.stringValue)){
						it.stringValue = layer;
						layerManager.ApplyModifiedProperties();
						return;
					}
				}
			}
		}
	}
	static bool isHasTag(string tag){
		for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++) {
			if(UnityEditorInternal.InternalEditorUtility.tags[i].Contains(tag))
				return true;
		}
		return false;
	}
	static bool isHasLayer(string layer){
		for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.layers.Length; i++) {
			if(UnityEditorInternal.InternalEditorUtility.layers[i].Contains(layer))
				return true;
		}
		return false;
	}
}
