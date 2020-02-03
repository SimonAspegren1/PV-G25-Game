using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : ItemClass
{
    [SerializeField] Text NoteText;
    [SerializeField] Button ExitButton;
    [SerializeField] string Name;
    [SerializeField] string Description = "Note to read from";
    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
        //ExitButton.onClick.AddListener()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseItem()
    {
        NoteText.gameObject.SetActive(true);
    }

    void ExitNote()
    {

    }
}
