#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace YourProjectName.Player
{
    [CustomEditor(typeof(PlayerShield))]
    [CanEditMultipleObjects]
    public class PlayerShieldEditor : Editor
    {
        #region VARIABLES

        private PlayerShield _target;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _target = target as PlayerShield;
        }

        public override void OnInspectorGUI()
        {
            ShieldButtons();
            base.OnInspectorGUI();
        }

        #endregion

        #region METHODS

        private void ShieldButtons()
        {
            using (EditorGUILayout.HorizontalScope hScope = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Reset"))
                {
                    _target.ResetShield();
                }

                if (GUILayout.Button("Get Shield"))
                {
                    _target.GetShield(5f);
                }

                if (GUILayout.Button("Lose Shield"))
                {
                    _target.LoseShield(5f);
                }
            }
        }

        #endregion
    }
}
#endif