using System.Collections;
using UnityEngine;

public abstract class  Monster : MonoBehaviour
{
    private SpawnManager _spawnManager;
    
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField] private Animator animator;

    private string _hitAnimationKey = "Hit";
    private string _deathAnimationKey = "Death";
    
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected float hp = 3f;
    
    
    private int _dir = 1;
    private bool _isMove = true;
    private bool _isHit = false;

    protected abstract void Init();
    private void Awake()
    {
        _spawnManager = FindFirstObjectByType<SpawnManager>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Init();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 마우스로 공격
    /// </summary>
    private void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }

    private void Move()
    {
        if (!_isMove)
            return;
        
        transform.position += Time.deltaTime * _dir * moveSpeed * Vector3.right;

        if (transform.position.x >= 8f)
        {
            _dir *= -1;
            sprite.flipX = true;
        }
        else if (transform.position.x <= -8f)
        {
            _dir *= -1;
            sprite.flipX = false;
        }
    }

    private IEnumerator Hit(float damage)
    {
        if (_isHit)
            yield break;
        
        _isMove = false;
        _isHit = true;
        animator.SetTrigger(_hitAnimationKey);
        hp -= damage;
    
        if (hp <= 0)
        {
            animator.SetTrigger(_deathAnimationKey);
            _spawnManager.DropCoin(transform.position);
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(0.7f);
        _isMove = true;
        _isHit = false;
    }
}
