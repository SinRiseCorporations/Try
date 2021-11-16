using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMapsConnect : MonoBehaviour
{
    [Header("Комната буз освещения")]
    [Space(10)]
    public GameObject roomWithOutLight;

    [Header("Комната с освещением")]
    public GameObject roomWithLight;


    void Start()
    {
        roomWithLight.SetActive(false);
        roomWithLight.transform.position = roomWithOutLight.transform.position;
    }

    
    void Update()
    {
        
    }
}
