using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    Vector3 rotatePog;
    public float battery;
    bool isOn;
    
    public Vector2 originalSize;

    private void Start()
    {
        battery = 100f;
        transform.localScale = originalSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }

        rotatePog = Vector3.zero;
        rotatePog.x = Input.GetAxisRaw("Horizontal");
        rotatePog.y = Input.GetAxisRaw("Vertical");
        if (rotatePog.x > 0f || rotatePog.y > 0f || rotatePog.x < 0f || rotatePog.y < 0f)
        {

            if (rotatePog.x > 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                90);
            }
            if (rotatePog.x < 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                -90);
            }
            if (rotatePog.y > 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                180);
            }
            else if (rotatePog.y < 0)
            {
                this.gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                0);
            }
        }

        if (battery > 0f && isOn)
        {
            gameObject.GetComponent<Renderer>().enabled = true;

            transform.localScale = new Vector2(originalSize.x * battery * 0.01f, originalSize.y * battery * 0.01f);

            battery -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        
    }
}
