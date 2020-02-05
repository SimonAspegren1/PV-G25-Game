using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] GameObject Panel;
    [SerializeField] Button Exitbtn;
    [SerializeField] ImageZoom IZ;
    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
        Exitbtn.onClick.AddListener(ExitPicture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        Panel.SetActive(true);
    }

    void ExitPicture()
    {
        IZ.currentZoom = 1;
        IZ.content.position = IZ.StartPos;
        Panel.SetActive(false);
    }
}
