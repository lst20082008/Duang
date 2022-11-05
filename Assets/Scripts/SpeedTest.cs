using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    public GameObject text;
    public float finalSpeed;
    public GameObject hp;
    private bool isDown;
    private bool notCross;
    private Vector2 lastMousePos;
    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
        notCross = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
            notCross = true;
            lastMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log("down");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
            Debug.Log("up");
        }
        if (isDown && notCross)
        {
            float delta = Vector2.Distance(lastMousePos, new Vector2(Input.mousePosition.x, Input.mousePosition.y)) / Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
            float speed = delta / Time.deltaTime;
            text.GetComponent<Text>().text = speed.ToString();
            lastMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (Input.mousePosition.x >= Screen.width / 2) {
                notCross = false;
                finalSpeed = speed;
                hp.GetComponent<Slider>().value -= finalSpeed;
            }
        }
    }

}
