using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 vPos = this.transform.position;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = Physics2D.OverlapBox(vPos, box.size, 0,nLayer);

        if(collider)
        {
            Player monster = this.GetComponent<Player>();
            Player player = collider.gameObject.GetComponent<Player>();

            SuperMode superMode = player.GetComponent<SuperMode>();
            if (superMode && !superMode.isUse)
            {
                monster.Attack(player);
                superMode.Active();
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player monter = this.GetComponent<Player>();
            Player player = collision.gameObject.GetComponent<Player>();

            monter.Attack(player);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }

   
}
