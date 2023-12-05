using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private int startNumPlayer;
    
    public int NumPlayer { get; set; }
    
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerMove.SetFields();
        NumPlayer = startNumPlayer;
    }

    private void Update()
    {
        _playerMove.Move();
    }

    public void Dead()
    {
        print("Dead");
        NumPlayer /= 2;
    }
}
