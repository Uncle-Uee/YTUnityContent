#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace YourProjectName.Managers
{
    [CustomEditor(typeof(SerializationManager))]
    public class SerializationManagerEditor : Editor
    {
        #region VARIABLES

        private SerializationManager _target;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as SerializationManager;
        }

        public override void OnInspectorGUI()
        {
            SerializationButtons();
            base.OnInspectorGUI();
        }

        #endregion

        #region METHODS

        private void SerializationButtons()
        {
            using (EditorGUILayout.HorizontalScope hScope = new EditorGUILayout.HorizontalScope())
            {
                SerializeDynamicData();
                DeserializeDynamicData();
            }
        }

        private void SerializeDynamicData()
        {
            if (GUILayout.Button("Serialize Dynamic Data"))
            {
                _target.SerializeDynamicData();
            }
        }

        private void DeserializeDynamicData()
        {
            if (GUILayout.Button("Deserialize Dynamic Data"))
            {
                _target.DeserializeDynamicData();
            }
        }

        #endregion
    }
}
#endif