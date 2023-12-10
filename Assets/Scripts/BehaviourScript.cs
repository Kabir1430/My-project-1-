using UnityEngine;
using UnityEngine.AI;



public class BehaviourScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking

    // States
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent  = GetComponent<NavMeshAgent>();

    }

    private void OnGuardPositioning()
    {

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();


    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

       // if (Physics.Raycast());
    }

    private void ChasePlayer()
    {
       // agent.SetDestination
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) OnGuardPositioning();
        if (playerInSightRange) ChasePlayer();
    }
}
