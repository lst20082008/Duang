using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float finalSpeed;
    public Player player;
    public Enemy enemy;

    public void Win()
    {
        Debug.Log("WIN");
    }

    public void Defeat()
    {
        Debug.Log("Defeat");
    }

    public void SetFinalSpeed(float speed)
    {
        finalSpeed = speed;
    }

    public void EnemyTakeDamage(int damage)
    {
        enemy.TakeDamage(damage);
    }

    public void PlayerTakeDamage(int damage)
    {
        player.TakeDamage(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
