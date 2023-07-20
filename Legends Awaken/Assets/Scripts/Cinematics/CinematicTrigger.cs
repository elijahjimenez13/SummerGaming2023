using System.Collections;
using System.Collections.Generic;
using RPG.Saving;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour, ISaveable
    {
        bool wasPlayed = false;

        private void OnTriggerEnter(Collider other) {
            if(!wasPlayed && other.gameObject.tag == "Player")
            {
                GetComponent<PlayableDirector>().Play();
                wasPlayed = true;
            }
        }

        public object CaptureState()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Cinematic"] = wasPlayed;
            return data;        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state;
            wasPlayed = (bool)data["Cinematic"];
            Debug.Log("Restored " + wasPlayed);        }
    }
}
