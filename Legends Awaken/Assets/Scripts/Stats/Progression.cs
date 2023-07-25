using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable = null;

        public float GetStat(Stat stat, CharacterClass characterClass, int level)
        {
            BuildLookup();

            if (lookupTable.TryGetValue(characterClass, out Dictionary<Stat, float[]> statLookupTable))
            {
                if (statLookupTable.TryGetValue(stat, out float[] levels))
                {
                    if (levels.Length >= level)
                    {
                        return levels[level - 1];
                    }
                }
            }

            return 0;
        }

        public int GetLevels(Stat stat, CharacterClass characterClass)
        {
            BuildLookup();

            if (lookupTable.TryGetValue(characterClass, out Dictionary<Stat, float[]> statLookupTable))
            {
                if (statLookupTable.TryGetValue(stat, out float[] levels))
                {
                    return levels.Length;
                }
            }

            return 0;
        }

        private void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();

            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();

                foreach (ProgressionStat progressionStat in progressionClass.stats)
                {
                    statLookupTable[progressionStat.stat] = progressionStat.levels;
                }

                lookupTable[progressionClass.characterClass] = statLookupTable;
            }
        }

        [System.Serializable]
        class ProgressionCharacterClass
        {
            public CharacterClass characterClass;
            public ProgressionStat[] stats;
            // public float[] health;
        }
        
        [System.Serializable]
        class ProgressionStat
        {
            public Stat stat;
            public float[] levels;
        }
    }
}