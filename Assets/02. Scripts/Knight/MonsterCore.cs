using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { Idle, Patrol, Trace, Attack}
    public MonsterState monsterState = MonsterState.Idle;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;

    public Transform target;
    protected float targetDist;
    
    public float hp;
    public float speed;
    protected float moveDir;
    public float attckTime;

    protected bool isTrace;

    protected virtual void Init(float hp, float speed, float attckTime)
    {
        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        this.hp = hp;
        this.speed = speed;
        this.attckTime = attckTime;
    }
    
    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);
     
        var monsterDir = Vector3.right * moveDir;
        var playerDir = (target.position - transform.position).normalized;

        isTrace = Vector3.Dot(monsterDir, playerDir) > 0;

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
    }
}
