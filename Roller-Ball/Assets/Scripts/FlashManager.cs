using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashManager : MonoBehaviour
{

    public GameObject lightObject;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Dark", 1f);
    }

    void Dark()
    {
        lightObject.SetActive(false);
        Invoke("Flash", 3f);
    }

    void Flash()
    {
        lightObject.SetActive(true);
        Invoke("Dark", 0.5f);
    }
}
