using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextFOrTime : MonoBehaviour
{
    bool WriteText = false;
    bool CanWriteText = true;
    [SerializeField] float TimeToShowText;
    float CurrentTime;
    [SerializeField] Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanWriteText)
        {
            if (WriteText)
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CanWriteText)
        {
            WriteText = true;
        }
    }
}
