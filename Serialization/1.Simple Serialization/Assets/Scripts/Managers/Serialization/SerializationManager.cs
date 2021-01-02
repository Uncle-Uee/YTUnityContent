using YourProjectName.General;
using UnityEngine;
using YourProjectName.General.Globals;

namespace YourProjectName.Managers
{
    [DefaultExecutionOrder(-1)]
    public class SerializationManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Variables")]
        public Variables Variables;

        [Header("Dynamic Data")]
        public DynamicData DynamicData = new DynamicData();

        #endregion

        #region PROPERTIES

        public static SerializationManager Instance { get; private set; }

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            Instance = this;

            // Events.OnSave += SerializeDynamicData;
            // Events.OnLoad += DeserializeDynamicData;
            
            Variables.RegisterSerializationEvents();
        }

        private void OnEnable()
        {
            Events.OnLoad?.Invoke();
        }

        private void OnDisable()
        {
            Events.OnSave?.Invoke();
        }

        #endregion

        #region METHODS

        public void SerializeDynamicData()
        {
            print("Saving Dynamic Data.");
            DynamicData.Serialize();
        }

        public void DeserializeDynamicData()
        {
            print("Loading Dynamic Data.");
            DynamicData.Deserialize();
        }

        #endregion
    }
}