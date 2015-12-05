using UnityEngine;
using System.Collections;
using UnityEditor;

public class export : Editor {

	[MenuItem("Tools/Export")]
	static void OnExport(){
		AssetDatabase.ExportPackage ("Assets","PP.unitypackage",ExportPackageOptions.Interactive|ExportPackageOptions.Recurse|ExportPackageOptions.IncludeDependencies|ExportPackageOptions.IncludeLibraryAssets);
	}
}
