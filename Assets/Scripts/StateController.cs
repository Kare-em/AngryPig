using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private EnemyMoveController move;
    [SerializeField] protected SpriteController sprite;

    public int State { get; private set; }//0-clear,1-dirty,2-triggered
    // Start is called before the first frame update
    private void Start()
    {
        State = -1;
        ChangeState(0);
    }
    public void ChangeState(int newState)
    {
        if (State == newState)
            return;
        State = newState;
        move.OnStateChanged();
        sprite.OnStateChanged();

    }

}
