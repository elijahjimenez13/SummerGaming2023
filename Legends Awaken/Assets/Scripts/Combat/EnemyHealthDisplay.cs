using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Attributes;
using TMPro; // Import the TextMeshPro namespace
using System;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;
        TextMeshProUGUI textMeshPro; // Declare a reference to the TextMeshProUGUI component

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
            textMeshPro = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component on the same GameObject
        }

        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                textMeshPro.text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();
            textMeshPro.text = String.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints()); // Update the text using TextMeshPro component
        }
    }
}