using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;
        TextMeshProUGUI textMeshPro; // Declare a reference to the TextMeshProUGUI component

        private void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
            textMeshPro = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component on the same GameObject
        }

        private void Update()
        {
            textMeshPro.text = String.Format("{0:0}", baseStats.GetLevel());
        }
    }
}