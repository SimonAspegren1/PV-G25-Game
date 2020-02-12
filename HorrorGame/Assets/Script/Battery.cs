using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] int AmountToIncrease;
    rotate TheFlashLIght;
    // Start is called before the first frame update
    void Start()
    {
        TheFlashLIght = GameObject.FindGameObjectWithTag("FlashLight").GetComponent<rotate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        TheFlashLIght.battery += AmountToIncrease;
    }
}
