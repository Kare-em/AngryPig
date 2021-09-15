using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bomb;
    [SerializeField] private Text bombTimer;
    [SerializeField] private Text bombReload;
    [SerializeField] private float bombReloadTime;
    private bool ready;
    private float reloadRealTime;
    private void Start()
    {
        ready = true;
    }
    private IEnumerator ShowReload()
    {
        while (!ready)
        {
            yield return new WaitForSeconds(0.1f);
            reloadRealTime -= 0.1f;
            bombReload.text = ((int)reloadRealTime).ToString();
        }
        bombReload.text = "Ready";
    }
    private IEnumerator Reload()
    {
        StartCoroutine(ShowReload());
        reloadRealTime = bombReloadTime;
        yield return new WaitForSeconds(bombReloadTime);
        ready = true;
        
    }
    public void SetBomb()
    {
        if (ready)
        {
            ready = false;
            StartCoroutine(Reload());
            Instantiate(bomb, player.position, Quaternion.identity);
        }

    }

}
