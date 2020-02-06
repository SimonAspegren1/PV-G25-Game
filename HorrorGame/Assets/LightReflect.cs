using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflect : MonoBehaviour
{
    SpriteRenderer mySR;
    int SLId;
    public bool HasLightOnIt = false;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        SLId = mySR.sortingLayerID;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasLightOnIt)
        {
            mySR.sortingLayerID = SLId;
        }
        else
        {
            HasLightOnIt = false;
        }
    }
}
