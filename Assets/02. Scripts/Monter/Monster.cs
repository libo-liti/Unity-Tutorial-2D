using System;
using UnityEngine;

public abstract class  Monster : MonoBehaviour
{
    private SpriteRenderer sprite;
    
    [SerializeField]
    protected float moveSpeed = 3f;
    [SerializeField]
    protected float hp = 3f;
    
    private int dir = 1;

    public abstract void Init();
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        Hit(1);
    }

    private void Move()
    {
        transform.position += Time.deltaTime * dir * moveSpeed * Vector3.right;

        if (transform.position.x >= 8f)
        {
            dir *= -1;
            sprite.flipX = true;
        }
        else if (transform.position.x <= -8f)
        {
            dir *= -1;
            sprite.flipX = false;
        }
    }

    void Hit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
