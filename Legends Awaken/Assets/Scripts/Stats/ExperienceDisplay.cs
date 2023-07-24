using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System;

namespace RPG.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;
        TextMeshProUGUI textMeshPro; // Declare a reference to the TextMeshProUGUI component

        private void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
            textMeshPro = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component on the same GameObject
        }

        private void Update()
        {
            if (experience != null)
            {
                textMeshPro.text = String.Format("{0:0}", experience.GetPoints());
            }
            else
            {
                // Handle the case when experience is null
                Debug.LogWarning("Experience component not found on the Player GameObject.");
            }
        }
    }
}