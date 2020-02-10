using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDarkness : MonoBehaviour
{
    [SerializeField] public FieldOfView flashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = flashLight.raycasthit;
         
    }
}
