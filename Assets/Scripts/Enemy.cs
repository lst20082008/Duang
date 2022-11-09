using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int attack;
    public GameObject enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        enemyHP.GetComponent<Slider>().value -= damage;
        if (hp <= 0) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Win();
        }
    }

    public void AttackPlayer()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PlayerTakeDamage(attack);
    }
}
