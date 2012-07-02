using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    #region Variables

    private float m_fHealth;
    private float m_fSpeed;

    private EnemyType m_pEnemyType;
    private EnemyStats m_pEnemyStats;

    #endregion

    #region Properties   
    
    public float Health
    {
        get { return m_fHealth; }
        set { m_fHealth = value; }
    }

    public float Speed
    {
        get { return m_fSpeed; }
        set { m_fSpeed = value; }
    }

    #endregion

    /// <summary>
    /// Contains the stats the enemy has when it is spawned.  Doesnt change!  The pointer might, but the values within are read only.
    /// </summary>
    private EnemyStats m_pStats;
    private EnemyType m_pType;

    public void Initialize(EnemyType type, EnemyStats stats)
    {
        gameObject.name = type.m_sName;
        m_pEnemyType = Instantiate(type) as EnemyType;
        m_pEnemyType.Initialize(this);

        m_pEnemyStats = Instantiate(stats) as EnemyStats;
        m_pEnemyStats.transform.parent = this.transform;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void UpdateEnemy( float dt ) 
    {
	    
	}

    public static Enemy CreateEnemy(EnemyType type, EnemyStats stats, Vector3 pos)
    {
        GameObject go = new GameObject();
        go.AddComponent<Enemy>();
        go.transform.position = pos;
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Initialize(type, stats);

        return enemy;
    }
}
