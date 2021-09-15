using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] protected float[] speed;
    [SerializeField] protected SpriteController spriteControl;
    [SerializeField] protected Transform respawn;

    protected float currentSpeed;
    public void MoveToTarget(Vector3 target)
    {
        var direction = target - transform.position;
        Move(direction);
    }
    public void Move(Vector3 direction)
    {
        if (direction.magnitude > 0.1f)
        {
            spriteControl.CheckSpriteDirection(direction);
            transform.Translate((Vector2)direction.normalized * currentSpeed * Time.deltaTime);
        }
    }
    private void Awake()
    {
        Respawn();
        currentSpeed = speed[0];
    }
    public void Respawn()
    {
        transform.position = respawn.position;
    }
}
