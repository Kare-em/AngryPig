using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MoveController
{
    [SerializeField] private Transform player;
    [SerializeField] private float chillTime;
    [SerializeField] private float UnfreezeTime;
    [SerializeField] private float widthScene;
    [SerializeField] private float heightScene;
    [SerializeField] private float findTargetTime;
    [SerializeField] private StateController stateController;
    private Vector3 target;

    public void OnStateChanged()
    {
        int state = stateController.State;
        currentSpeed = speed[state];
        
        switch (stateController.State)
        {
            case 0:
                StartCoroutine(Walk());
                break;
            case 1:
                StartCoroutine(Freeze());
                break;
            case 2:
                StartCoroutine(Rage());
                break;
            default:
                stateController.ChangeState(0);
                break;
        }
    }
    private IEnumerator Walk()
    {
        while (true)
        {
            target = GenerateTarget();
            yield return new WaitForSeconds(findTargetTime);
        }
    }
    private IEnumerator Freeze()
    {
        StopCoroutine(Walk());
        yield return new WaitForSeconds(UnfreezeTime);
        stateController.ChangeState(2);
    }

    private IEnumerator Rage()
    {
        yield return new WaitForSeconds(chillTime);
        StopRage();
    }
    private void StopRage()
    {
        stateController.ChangeState(0);
    }
    
    private Vector2 GenerateTarget()
    {
        return new Vector2(Random.Range(-widthScene / 2, widthScene / 2), Random.Range(-heightScene / 2, heightScene / 2));
    }
    
    private void Update()
    {
        if(stateController.State==2)
            MoveToTarget(player.position);
        else
            MoveToTarget(target);
    }
    
}
