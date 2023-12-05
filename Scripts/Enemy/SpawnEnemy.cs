using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy prefab;
    [SerializeField] private Transform points;
    [SerializeField] private int numEnemy;

    private Enemy _enemy;
    private bool _isVisible;
    private int _numPlayer;

    private void OnEnable()
    {
        EventManager.onDay += Destroy;
        EventManager.onNight += Spawn;
        EventManager.onVisible += OnVisible;
    }
    
    private void OnDisable()
    {
        EventManager.onDay -= Destroy;
        EventManager.onNight -= Spawn;
        EventManager.onVisible -= OnVisible;
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(prefab, transform.position, Quaternion.identity);
        enemy.SetPoints(points);
        enemy.numEnemy = numEnemy;
        if (_isVisible)
        {
            enemy.ActivatorOutline(_numPlayer);
            _isVisible = false;
        }

        _enemy = enemy;
    }

    private void OnVisible(int numPlayer)
    {
        print("321312");
        _numPlayer = numPlayer;
        _isVisible = true;
    }

    private void Destroy()
    {
        if (_enemy != null)
        {
            Destroy(_enemy.gameObject);
        }
    }
}
