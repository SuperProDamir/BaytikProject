using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPSmind : MonoBehaviour
{
    public Vector3 dir = Vector3.right;
    private float health = 50;
    [SerializeField] private RectTransform healthBar;
    private int maxHealth = 50;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 3);
        if ((transform.position.x > 5f)||(transform.position.x < -5f)) {
            dir = -dir;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("bullet"))
        {
            health = health - 10;
            healthBar.localScale = new Vector2(health / maxHealth, 1f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    }
