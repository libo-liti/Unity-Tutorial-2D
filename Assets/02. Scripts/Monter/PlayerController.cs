using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _hitBox;
    private Animator _animator;
    
    [SerializeField] private float _moveSpeed = 3f;
    private float _h, _v;

    private bool _isAttack = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
        Move();
    }

    private void Move()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (_h == 0 && _v == 0)
        {
            _animator.SetBool("Run", false);
        }
        else
        {
            int scaleX = _h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            
            _animator.SetBool("Run", true);

            var dir = new Vector3(_h, _v, 0).normalized;
            transform.position += _moveSpeed * Time.deltaTime * dir;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        _isAttack = true;
        _hitBox.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        _hitBox.SetActive(false);
        _isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(3f));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get();
            Debug.Log("Working");
        }
    }
}
