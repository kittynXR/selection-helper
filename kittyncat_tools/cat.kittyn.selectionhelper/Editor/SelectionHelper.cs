using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Catte.SelectionHelper
{
    public class SelectionHelper
    {

        public static System.Type myCurrentType = System.Type.GetType(SessionState.GetString("SelectionHelperSelectType", ""));


        [MenuItem("CONTEXT/Component/[SH] Choose Type", false, 900)]
        static void selectType(MenuCommand selected)
        {
            myCurrentType = selected.context.GetType();
            SessionState.SetString("SelectionHelperSelectType", myCurrentType.AssemblyQualifiedName);
        }

        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/Selection Helper/Select Immediate Children", false, 3100)]
        static void selectImmediate(MenuCommand selected)
        {
            Transform[] obj = Selection.GetFiltered<Transform>(SelectionMode.Editable);
            if (obj.Length == 0)
            {
                Debug.Log("[SH] No GameObject was selected");
                return;
            }
            List<GameObject> newSelection = new List<GameObject>();
            for (int i = 0; i < obj.Length; i++)
            {
                for (int j = 0; j < obj[i].childCount; j++)
                {
                    newSelection.Add(obj[i].GetChild(j).gameObject);
                }
            }
            Selection.objects = Selection.objects.Concat(newSelection).ToArray();
        }

        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/Selection Helper/By Type/Filter", false, 3110)]
        static void selectSelectedType()
        {
            Selection.objects = Selection.GetFiltered(myCurrentType, SelectionMode.Editable);
            List<GameObject> newSelection = new List<GameObject>();
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                newSelection.Add(((Component)Selection.objects[i]).gameObject);
            }
            Selection.objects = newSelection.ToArray();
        }

        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/Selection Helper/By Type/Children", false, 3111)]
        static void selectChildrenType(MenuCommand selected)
        {
            selectByType(selected, true);
        }

        [MenuItem("Tools/⚙️🎨 kittyn.cat 🐟/Selection Helper/By Type/Parents", false, 3112)]
        static void selectParentsType(MenuCommand selected)
        {
            selectByType(selected, false);
        }

        static void selectByType(MenuCommand selected, bool child)
        {
            if (myCurrentType == null)
            {
                Debug.Log("[SH] No Component Type Chosen");
                return;
            }
            if (!selected.context)
            {
                Debug.Log("[SH] No GameObject was selected");
                return;
            }
            GameObject[] objs;
            if (child)
                objs = ((GameObject)selected.context).GetComponentsInChildren(myCurrentType, true).Select(c => c.gameObject).ToArray();
            else
                objs = ((GameObject)selected.context).GetComponentsInParent(myCurrentType, true).Select(c => c.gameObject).ToArray();

            Selection.objects = objs;

        }
    }
}