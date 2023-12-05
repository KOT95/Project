using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public bool IsAttack { get; set; }
    public bool IsDead { get; private set; }
    public int numEnemy { get; set; }

    private Outline _outline;

    public void Dead()
    {
        if (!IsDead)
        {
            IsDead = true;
            transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => { Destroy(gameObject); }).SetEase(Ease.InBack);
        }
    }

    public virtual void Attack(Transform player)
    {
    }
    
    public virtual void SetPoints(Transform pointsT)
    {
    }

    public void ActivatorOutline(int numPlayer)
    {
        _outline = GetComponent<Outline>();
        
        if(numPlayer >= numEnemy)
            _outline.OutlineColor = Color.green;
        else
            _outline.OutlineColor = Color.red;
            
        _outline.Activate();
    }
}
