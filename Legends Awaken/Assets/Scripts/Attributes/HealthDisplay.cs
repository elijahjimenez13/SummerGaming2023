using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;
        TextMeshProUGUI textMeshPro; // Declare a reference to the TextMeshProUGUI component

        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            textMeshPro = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component on the same GameObject
        }

        private void Update()
        {
            textMeshPro.text = String.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints()); // Update the text using TextMeshPro component
        }
    }
}