using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    public float finalSpeed;
    public GameObject enemyHP;
    public GameObject playerHP;
    public bool flipHand;
    public GameObject target_left;
    public GameObject target_right;
    public int enemyAttack;
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
            if (Input.mousePosition.x < Screen.width / 2)
            {
                flipHand = false;
                target_left.transform.parent.parent.gameObject.SetActive(true);
                target_right.transform.parent.parent.gameObject.SetActive(false);
            }
            else {
                flipHand = true;
                target_left.transform.parent.parent.gameObject.SetActive(false);
                target_right.transform.parent.parent.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }
        if (isDown) {
            if (!flipHand)
            {
                target_left.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else {
                target_right.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            
        }
        if (isDown && notCross)
        {
            float delta = Vector2.Distance(lastMousePos, new Vector2(Input.mousePosition.x, Input.mousePosition.y)) / Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
            float speed = delta / Time.deltaTime;
            lastMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (!flipHand)
            {
                if (Input.mousePosition.x >= Screen.width / 2)
                {
                    notCross = false;
                    finalSpeed = speed;
                    enemyHP.GetComponent<Slider>().value -= finalSpeed;
                }
            }
            else {
                if (Input.mousePosition.x <= Screen.width / 2)
                {
                    notCross = false;
                    finalSpeed = speed;
                    enemyHP.GetComponent<Slider>().value -= finalSpeed;
                }
            }
            
        }
    }

    public void HitPlayer()
    {
        Debug.Log("hit");
        playerHP.GetComponent<Slider>().value -= enemyAttack;
    }
}
