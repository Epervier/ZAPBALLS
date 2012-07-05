using UnityEngine;
using System.Collections;

public class BallLightning : AttackType {

    private float m_fSize = 1.5f;

    private bool m_bIsGrowing = true;
    private bool m_bIsInited = false;

    public override void Initialize(Attack parent)
    {
        base.Initialize(parent);

        m_fSize = 1.5f;
        this.transform.localScale = new Vector3(m_fSize, m_fSize, m_fSize);
    }


	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public override void UpdateType(float dt)
    {
        base.UpdateType(dt);

        if (m_bIsInited == false)
        {
            if (Input.GetMouseButtonUp(0) == true)
            {
                m_bIsGrowing = false;
            }

            if (m_bIsGrowing == true)
            {
                m_fSize += m_pParent.m_pAttackStats.m_fGrowthRate * dt;
                this.transform.localScale = new Vector3(m_fSize, m_fSize, m_fSize);
                if (m_fSize >= m_pParent.m_pAttackStats.m_fMaxSize)
                {
                    m_bIsGrowing = false;
                }
            }

            if ( m_bIsGrowing == false )
            {
                m_fLifetime += m_fSize / m_pParent.m_pAttackStats.m_fGrowthRate;
                m_bIsInited = true;
            }
        }
        
        if (m_bIsInited == true)
        {
            if (m_fLifetime > 0)
            {
                m_fLifetime -= dt;
            }
            else
            {
                m_pParent.AttackFinished();
            }
        }

        foreach (EnemyType type in enemiesHit)
        {
            if( type != null )
                type.EnemyHit(m_fDamage * dt);
        }
    }

    public override void HitEnemy(EnemyType type)
    {
        base.HitEnemy(type);
    }

}
