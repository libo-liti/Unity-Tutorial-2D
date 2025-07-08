using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageble
{
    public enum MonsterState { Idle, Patrol, Trace, Attack}
    public MonsterState monsterState = MonsterState.Idle;

    public ItemManager itemManager;
    
    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    public Image hpBar;

    public Transform target;
    protected float targetDist;
    
    public float hp;
    public float speed;
    protected float moveDir;
    public float attckTime;
    public float atkDamage;

    private float _curHp;
    protected bool isTrace;
    private bool _isDead;

    protected virtual void Init(float hp, float speed, float attckTime, float atkDamage)
    {
        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        itemManager = FindFirstObjectByType<ItemManager>();
        
        this.hp = hp;
        this.speed = speed;
        this.attckTime = attckTime;
        this.atkDamage = atkDamage;

        _curHp = hp;
        hpBar.fillAmount = _curHp / hp;
    }
    
    private void Update()
    {
        if (_isDead)
            return;
        switch (monsterState)
        {
            case MonsterState.Idle :
                Idle();
                break;
            case MonsterState.Patrol :
                Patrol();
                break;
            case MonsterState.Trace :
                Trace();
                break;
            case MonsterState.Attack :
                Attack();
                break;
        }
    }

    public void ChangeState(MonsterState state)
    {
        if (monsterState != state)
            monsterState = state;
    }

    protected abstract void Idle();
    protected abstract void Patrol();
    protected abstract void Trace();
    protected abstract void Attack();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if (other.GetComponent<IDamageble>() != null)
        {
            other.GetComponent<IDamageble>().TakeDamage(atkDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        _curHp -= damage;
        hpBar.fillAmount = _curHp / hp;
        if (_curHp <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        _isDead = true;
        animator.SetTrigger("Death");
        monsterRb.gravityScale = 0f;
        monsterColl.enabled = false;
        itemManager.DropItem(transform.position);

        int itemCount = Random.Range(0, 3);
        if (itemCount > 0)
        {
            for (int i = 0; i < itemCount; i++)
            {
                itemManager.DropItem(transform.position);
            }
        }
    }
}
