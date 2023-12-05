using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class EnemyMove : Enemy
{
    [SerializeField] private Transform points;
    [SerializeField] private float minRemainingDistance = 0.5f;
    [SerializeField] private float minPlayerDistance = 0.5f;
    [SerializeField] private float speed;
    [SerializeField] private float time;
    
    private int _destinationPoint = 0;
    private NavMeshAgent _navComponent;
    private Animator _anim;
    private float _time;
    private Transform _player;

    private void Start()
    {
        _navComponent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _navComponent.autoBraking = false;
        _navComponent.speed = speed;

        GoToNextPoint();
    }
    
    public void GoToNextPoint()
    {
        IsAttack = false;
        _navComponent.destination = points.GetChild(_destinationPoint).position;
        _destinationPoint = Random.Range(0, points.childCount);
    }

    private void Update()
    {
        if(IsDead)
            return;
        
        _anim.SetFloat("Velocity", _navComponent.velocity.magnitude);

        if (!IsAttack)
        {
            if(!_navComponent.pathPending && _navComponent.remainingDistance < minRemainingDistance)
                GoToNextPoint();
        }
        else
        {
            if (_time < time)
            {
                _time += Time.deltaTime;
                _navComponent.destination = _player.position;
                if (!_navComponent.pathPending && _navComponent.remainingDistance < minPlayerDistance)
                {
                    _player.GetComponent<Player>().Dead();
                    Dead();
                }
            }
            else
                GoToNextPoint();
        }
    }

    public override void Attack(Transform player)
    {
        _time = 0;
        _player = player;
        IsAttack = true;
    }

    public override void SetPoints(Transform pointsT)
    {
        points = pointsT;
    }
}
