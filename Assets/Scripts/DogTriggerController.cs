using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTriggerController : MonoBehaviour
{
    [SerializeField] private StateController stateController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            stateController.ChangeState(2);
        }
    }
}
