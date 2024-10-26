using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 8f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    PlayerHealth target;
    EnemyHealth health;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = FindObjectOfType<PlayerHealth>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        //calculate distace to target
        ProcessAggro();

        if(health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            health.enabled = false;
        }
    }

    private void ProcessAggro()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        
        /*if (distanceToTarget > chaseRange)
        {
            isProvoked = false;
            navMeshAgent.SetDestination(transform.position);
            GetComponent<Animator>().SetTrigger("idle");
        }*/
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("move");
        GetComponent<Animator>().SetBool("attack", false);
        navMeshAgent.SetDestination(target.transform.position);
    }

    void AttackTarget()
    {   
        FaceTarget();
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log("Attacking Target.");
    }

    private void FaceTarget()
    {
        //transform.LookAt(target.transform.position);
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    //draw range of target
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
