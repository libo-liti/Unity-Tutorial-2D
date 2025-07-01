using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float _timer;
    private float _idleTime, _patrolTime;
    private float _traceDist = 5f;
    private float _attckDist = 2f;

    private bool _isAttack;
    private void Start()
    {
        Init(10f, 3f, 2f);
        // StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attckTime)
    {
        base.Init(hp, speed, attckTime);
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

            _patrolTime = Random.Range(1f, 5f);

            ChangeState(MonsterState.Patrol);
        }

        if (targetDist <= _traceDist && isTrace)
        {
            _timer = 0;
            animator.SetBool("isRun", true);
            ChangeState(MonsterState.Trace);
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

        if (targetDist <= _traceDist && isTrace)
        {
            _timer = 0f;
            ChangeState(MonsterState.Trace);
        }
    }

    protected override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += targetDir.x * speed * Time.deltaTime * Vector3.right;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        
        if (targetDist > _traceDist)
        {
            animator.SetBool("isRun", false);
            ChangeState(MonsterState.Idle);
        }

        if (targetDist < _attckDist)
        {
            ChangeState(MonsterState.Attack);
        }
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
        yield return new WaitForSeconds(1f);

        // yield return new WaitForSeconds(attckTime - 1f);
        _isAttack = false;
        ChangeState(MonsterState.Idle);
        animator.SetBool("isRun", false);
    }
}
