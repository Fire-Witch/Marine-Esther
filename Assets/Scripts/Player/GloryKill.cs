using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{
    public string EnemyName;

    public Animator gloryKills;
    public GameObject gun;

    private bool shouldGloryKill = false;

    private GameObject enemy; 

    void Start()
    {
        gloryKills = GameObject.Find("GloryKills").GetComponent<Animator>();
        gun = GameObject.Find("HUDGun");
    }

    void Update()
    {
       if (shouldGloryKill && Input.GetKey("e"))
        {
            gun.SetActive(false);
            gloryKills.SetTrigger("KillTurret");
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            shouldGloryKill = true;
            enemy = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            shouldGloryKill = false;
        }
    }

    public void RepopGun()
    {
        gun.SetActive(true);
    }
}
