#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace YourProjectName.Player
{
    [CustomEditor(typeof(PlayerHealth))]
    [CanEditMultipleObjects]
    public class PlayerHealthEditor : Editor
    {
        #region VARIABLES

        private PlayerHealth _target;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as PlayerHealth;
        }

        public override void OnInspectorGUI()
        {
            HealthButtons();
            base.OnInspectorGUI();
        }

        #endregion

        #region METHODS

        private void HealthButtons()
        {
            using (EditorGUILayout.HorizontalScope hScope = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Reset"))
                {
                    _target.ResetHealth();
                }

                if (GUILayout.Button("Get Health"))
                {
                    _target.GetHealth(5f);
                }

                if (GUILayout.Button("Lose Health"))
                {
                    _target.LoseHealth(5f);
                }
            }
        }

        #endregion
    }
}
#endif