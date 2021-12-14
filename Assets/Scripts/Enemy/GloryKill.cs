using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{
    public string EnemyName;

    public Animator gloryKills;

    private bool shouldGloryKill = false;

    void Start()
    {
        gloryKills = GameObject.Find("GloryKills").GetComponent<Animator>();
    }

    void Update()
    {
        if(shouldGloryKill && Input.GetKey("e"))
        {
            gloryKills.SetTrigger("KillTurret");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldGloryKill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldGloryKill = false;
        }
    }
}
