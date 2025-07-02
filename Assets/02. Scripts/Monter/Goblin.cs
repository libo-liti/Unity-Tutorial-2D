using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float _timer;
    private float _idleTime, _patrolTime;
    private float _traceDist = 5f;
    private float _attckDist = 1.5f;

    private bool _isAttack;
    private void Start()
    {
        Init(10f, 3f, 2f, 10f);
        StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attckTime, float atkDamage)
    {
        base.Init(hp, speed, attckTime, atkDamage);
    }

    private IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);
            
            if (monsterState == MonsterState.Idle || monsterState == MonsterState.Patrol)
            {
                var monsterDir = Vector3.right * moveDir;
                var playerDir = (target.position - transform.position).normalized;

                isTrace = Vector3.Dot(monsterDir, playerDir) > 0;
                if (targetDist <= _traceDist && isTrace)
                {
                    animator.SetBool("isRun", true);
                    ChangeState(MonsterState.Trace);
                }
            }
            else if (monsterState == MonsterState.Trace)
            {
                if (targetDist > _traceDist)
                {
                    _timer = 0f;
                    _idleTime = Random.Range(1f, 5f);
                    animator.SetBool("isRun", false);
                    
                    ChangeState(MonsterState.Idle);
                }
                
                if (targetDist < _attckDist)
                {
                    ChangeState(MonsterState.Attack);
                }
            }
        }
    }

    protected override void Idle()
    {
        _timer += Time.deltaTime;
        if (_timer >= _idleTime)
        {
            _timer = 0;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            animator.SetBool("isRun", true);
            hpBar.transform.localScale = new Vector3(moveDir, 1, 1);

            _patrolTime = Random.Range(1f, 5f);

            ChangeState(MonsterState.Patrol);
        }
    }

    protected override void Patrol()
    {
        _timer += Time.deltaTime;
        transform.position += moveDir * speed * Time.deltaTime * Vector3.right;
        if (_timer >= _patrolTime)
        {
            _timer = 0;
            animator.SetBool("isRun", false);

            _idleTime = Random.Range(1f, 5f);
            
            ChangeState(MonsterState.Idle);
        }
    }

    protected override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += targetDir.x * speed * Time.deltaTime * Vector3.right;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
    }

    protected override void Attack()
    {
        if (!_isAttack)
            StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _isAttack = true;
        animator.SetTrigger("isAttack");
        float currAnimationLen = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAnimationLen);
        
        animator.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attckTime - 1f);
        
        _isAttack = false;
        animator.SetBool("isRun", true);
        ChangeState(MonsterState.Trace);
    }
}
