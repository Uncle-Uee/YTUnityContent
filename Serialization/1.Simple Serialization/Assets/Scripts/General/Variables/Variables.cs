using System;
using System.IO;
using UnityEngine;
using YourProjectName.General.Globals;

namespace YourProjectName.General
{

    [Serializable]
    public class EnemyData
    {
        [Header("Health")]
        public float Health = 50f;
    }
    
    [CreateAssetMenu(menuName = "YourProjectName/General/Variables")]
    public class Variables : ScriptableObject, ISaveable
    {
        #region VARIABLES

        [Header("Player Health")]
        public float Health = 100f;

        [Header("Player Shield")]
        public float Shield = 50f;

        [Header("Enemy")]
        public EnemyData EnemyData;

        [Header("Machine Gun")]
        public float MachineGunDamage = 2f;

        [Header("Currency")]
        public int Currency = 0;

        [Header("Score")]
        public int Score = 0;
        public int HighScore = 0;

        #endregion

        #region PROPERTIES

        #endregion

        #region SCORE METHODS

        public void AllocateHighScore()
        {
            if (Score > HighScore) HighScore = Score;
        }

        #endregion

        #region SERIALIZATION METHODS

        public string ToJson() => JsonUtility.ToJson(this, true);

        public void FromJsonOverwrite(string json) => JsonUtility.FromJsonOverwrite(json, this);

        public void Serialize()
        {
            File.WriteAllText(Constants.SaveGame_PD, ToJson());
        }

        public void Deserialize()
        {
            FromJsonOverwrite(File.ReadAllText(Constants.SaveGame_PD));
        }

        public void RegisterSerializationEvents()
        {
            Events.OnSave += Serialize;
            Events.OnLoad += Deserialize;
        }

        #endregion
    }
}