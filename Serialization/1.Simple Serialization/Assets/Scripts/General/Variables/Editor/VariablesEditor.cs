#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace YourProjectName.General
{
    [CustomEditor(typeof(Variables))]
    public class VariablesEditor : Editor
    {
        #region VARIABLES

        private Variables _target;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as Variables;
        }

        public override void OnInspectorGUI()
        {
            AssignSelf();
            Persistance();
            base.OnInspectorGUI();
        }

        #endregion

        #region METHODS

        private void AssignSelf()
        {
            if (GUILayout.Button("Assign"))
            {
                List<GameObject> rootObjects = new List<GameObject>();
                int sceneCount = EditorSceneManager.sceneCount;

                for (int i = 0; i < sceneCount; i++)
                {
                    EditorSceneManager.GetSceneAt(i).GetRootGameObjects(rootObjects);
                    foreach (GameObject rootObject in rootObjects)
                    {
                        foreach (MonoBehaviour behaviour in rootObject.GetComponentsInChildren<MonoBehaviour>(true))
                        {
                            foreach (System.Reflection.FieldInfo variable in behaviour.GetType().GetFields())
                            {
                                if (variable.FieldType.IsInstanceOfType(_target))
                                {
                                    variable.SetValue(behaviour, _target);
                                }
                            }
                        }
                    }
                }

                EditorSceneManager.MarkAllScenesDirty();
                EditorUtility.SetDirty(this);
            }
        }

        private void Persistance()
        {
            using (EditorGUILayout.HorizontalScope hScope = new EditorGUILayout.HorizontalScope())
            {
                Serialize();
                Deserialize();
            }
        }

        private void Serialize()
        {
            if (GUILayout.Button("Save"))
            {
                string json = _target.ToJson();
                string path = EditorUtility.SaveFilePanel("Save", "", _target.name, "json");
                if (path != "") File.WriteAllText(path, json);
                AssetDatabase.Refresh();
            }
        }

        private void Deserialize()
        {
            if (GUILayout.Button("Load"))
            {
                string path = EditorUtility.OpenFilePanel("Load", "", "json");
                if (path == "") return;
                string json = File.ReadAllText(path);
                _target.FromJsonOverwrite(json);
                EditorUtility.SetDirty(_target);
            }
        }

        #endregion
    }
}
#endif