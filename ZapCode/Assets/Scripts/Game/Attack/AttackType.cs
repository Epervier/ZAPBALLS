using UnityEngine;
using System.Collections;

public class AttackType : MonoBehaviour {

    protected float m_fLifetime = 1.0f;
    protected float m_fDamage = 1.0f;
    protected float m_fFireRate = 1.0f;

    protected Attack m_pParent = null;

    protected BetterList<EnemyType> enemiesHit;

    public virtual void Initialize(Attack parent)
    {
        m_pParent = parent;

        m_fLifetime = parent.m_pAttackStats.m_fLifetime;
        m_fFireRate = parent.m_pAttackStats.m_fFireRate;
        m_fDamage = parent.m_pAttackStats.m_fDamage;

        enemiesHit = new BetterList<EnemyType>();
    }

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	public virtual void UpdateType (float dt) 
    {
	
	}

    protected void OnTriggerEnter(Collider other)
    {
        EnemyType type =  other.GetComponent<EnemyType>();
        if (type != null)
        {
            HitEnemy(type);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        EnemyType type = other.GetComponent<EnemyType>();
        if (type != null)
        {
            enemiesHit.Remove(type);
        }
    }

    public virtual void HitEnemy(EnemyType type)
    {
        enemiesHit.Remove(type);
        enemiesHit.Add(type);
        
    }


}
