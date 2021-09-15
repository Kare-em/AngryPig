using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCheck : MonoBehaviour
{
    [SerializeField] private LivesController lives;
    [SerializeField] private MoveController move;
    private void OnHit()
    {
        lives.ChangeLives(-1);
        move.Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<StateController>();
            if (enemy.State == 2)
            {
                enemy.ChangeState(0);
                OnHit();
            }
        }
        if (collision.tag == "HitCollider")
            OnHit();
        
    }
}
