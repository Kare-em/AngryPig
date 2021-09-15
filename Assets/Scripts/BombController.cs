using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float timeCountdown;
    [SerializeField] private float deltaScale;
    
    [SerializeField] private int addScore;
    [SerializeField] private ScoreCounter score;

    private bool explosion;
    private void Start()
    {
        explosion = false;
        StartCoroutine(Countdown());
        score = FindObjectOfType<ScoreCounter>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StateController stateController = other.gameObject.GetComponentInChildren<StateController>();
            stateController.ChangeState(1);
            score.ChangeScore(addScore);
        }   
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeCountdown);
        
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<CircleCollider2D>().enabled = false;
        explosion = true;
        Destroy(gameObject,0.1f);
        
    }
    private void Update()
    {
        if(explosion)
            transform.localScale*= 1+deltaScale*Time.deltaTime;
    }
}
