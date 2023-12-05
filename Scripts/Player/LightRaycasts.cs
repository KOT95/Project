using UnityEngine;

public class LightRaycasts : MonoBehaviour
{
    [Header("Raycast_Settings")]
    [SerializeField] private int rays = 8;
    [SerializeField] private int distance = 33;
    [SerializeField] private float angle = 40;
    [SerializeField] private Vector3 offset;
    [SerializeField] private UIController uiController;
    [SerializeField] private Player player;

    private Enemy EnemyTemp
    {
        get
        {
            return _enemyTemp;
        }
        set
        {
            _enemyTemp = value;
            
            if(value != null)
                uiController.ActivatorButton(true, this);
            else
                uiController.ActivatorButton(false, this);
        }
    }

    private Enemy _enemyTemp; 

    private bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform.TryGetComponent(out Enemy enemy))
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
                EnemyTemp = enemy;
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    private bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    private void Update()
    {
        if (RayToScan())
        {
            if (_enemyTemp.IsAttack || _enemyTemp.IsDead)
                EnemyTemp = null;
        }
        else
            EnemyTemp = null;
    }

    public void DeadEnemy()
    {
        if (EnemyTemp != null && EnemyTemp.numEnemy <= player.NumPlayer)
        {
            player.NumPlayer += EnemyTemp.numEnemy;
            EnemyTemp.Dead();
        }
        else if(EnemyTemp.numEnemy > player.NumPlayer)
            EnemyTemp.Attack(player.transform);
    }
}
