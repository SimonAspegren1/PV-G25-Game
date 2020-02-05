using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : ItemClass
{
    [SerializeField] Text NoteText;
    [SerializeField] Button ExitButton;
    [SerializeField] GameObject ScrollArea;
    [SerializeField] string Name;
    [SerializeField] string Description = "Note to read from";
    [SerializeField] GameObject Theprefab;
    // Start is called before the first frame update
    void Start()
    {
        ItemName = Name;
        ItemDescription = Description;
        prefab = Theprefab;
        ExitButton.onClick.AddListener(ExitNote);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void UseItem()
    {
        ScrollArea.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        NoteText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(NoteText.gameObject.GetComponent<RectTransform>().sizeDelta.x
            ,NoteText.preferredHeight);
    }

    void ExitNote()
    {
        ScrollArea.SetActive(false);
        ExitButton.gameObject.SetActive(false);
    }
}


