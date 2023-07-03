using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;
    private Vector3 offset = new Vector3(18, 10, 8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset target from player by adding the camera's position
        transform.position = target.transform.position + offset;   
    }
}
