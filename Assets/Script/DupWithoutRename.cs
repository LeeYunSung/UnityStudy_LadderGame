using UnityEngine;
using UnityEditor;
 
public class DupWithoutRename
{
    [MenuItem("GameObject/Duplicate Without Renaming %#d")]

    public static void DuplicateWithoutRenaming() {
        foreach (Transform t in Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.ExcludePrefab | SelectionMode.Editable)){
            GameObject newObject = null;

            PrefabType pt = PrefabUtility.GetPrefabType(t.gameObject);
            if (pt == PrefabType.PrefabInstance || pt == PrefabType.ModelPrefabInstance){
                Object prefab = PrefabUtility.GetPrefabParent(t.gameObject);
                newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

                PropertyModification[] overrides = PrefabUtility.GetPropertyModifications(t.gameObject);
                PrefabUtility.SetPropertyModifications(newObject, overrides);
            }
            else{
                newObject = Object.Instantiate(t.gameObject);
                newObject.name = t.name;
            }
            newObject.transform.parent = t.parent;
            newObject.transform.position = t.position;
            newObject.transform.rotation = t.rotation;

            Undo.RegisterCreatedObjectUndo(newObject, "Duplicate Without Renaming");
        }
    }
    [MenuItem("GameObject/Duplicate Without Renaming %#d", true)]
    public static bool ValidateDuplicateWithoutRenaming(){
        return Selection.GetFiltered(typeof(GameObject), SelectionMode.TopLevel | SelectionMode.ExcludePrefab | SelectionMode.Editable).Length > 0;
    }
}