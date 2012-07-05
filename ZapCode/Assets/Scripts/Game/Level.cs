using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    #region Public Variables
    public float    m_fLevelDuration;

    public Vector3  m_vBottomLeftCorner;
    public Vector3  m_vUpperRightCorner;

    public float m_fSpawnTime = 3.0f;

    #endregion

    #region Prefabs
    public AttackType m_pAttackType = null;
    public AttackStats m_pAttackStats = null;
   
    public EnemyType[]          m_pEnemyTypes = null;
    public EnemyStats[]         m_pEnemyStats = null;
    public LevelObjectType[]    m_pLevelObjectTypes = null;
    public LevelObjectStats[]   m_pLevelObjectStats = null;
    #endregion

    #region Private Variables

    //  The current actual objects in the game
    private BetterList<Attack>      m_pAttacks;
    private BetterList<Enemy>       m_pEnemies;
    private BetterList<LevelObject> m_pLevelObjects;
    private BoxCollider m_pCollider;

    //  A container within unity to hold all the attacks
    private GameObject m_gAttacks;
    private GameObject m_gEnemies;

    private float m_fAttackTimer = 0.0f;
    private float m_fSpawnTimer = 0.0f;

    #endregion
    public void Initialize()
    {
        m_gAttacks = new GameObject();
        m_gAttacks.name = "Attacks";
        m_gAttacks.transform.parent = this.transform;
        m_gAttacks.transform.position = new Vector3(0, 0, 0);
        m_gAttacks.layer = gameObject.layer;

        m_gEnemies = new GameObject();
        m_gEnemies.name = "Enemies";
        m_gEnemies.transform.parent = this.transform;
        m_gEnemies.transform.position = new Vector3(0, 0, 0);
        m_gEnemies.layer = gameObject.layer;

        m_pAttacks = new BetterList<Attack>();
        m_pEnemies = new BetterList<Enemy>();
        m_pLevelObjects = new BetterList<LevelObject>();

        Vector3 pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

        pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

        pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

        m_pCollider = this.GetComponent<BoxCollider>();
        m_pCollider.bounds.SetMinMax(m_vBottomLeftCorner, m_vUpperRightCorner);
        
    }
	
	// Update is called once per frame
	public bool UpdateLevel ( float dt )
    {
        if (m_fAttackTimer > 0.0f)
        {
            m_fAttackTimer -= dt;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Vector3 pos = Input.mousePosition;
                Attack attack = CreateAttack(UICamera.currentCamera.ScreenToWorldPoint(pos));
                m_fAttackTimer = attack.m_pAttackStats.m_fFireRate;
            }
        }

        m_fSpawnTimer -= dt;
        if ( m_fSpawnTimer <= 0.0 )
        {
            SpawnEnemy();
            m_fSpawnTimer = m_fSpawnTime;
        }

        
        foreach (Attack attack in m_pAttacks)
        {
            if (attack == null)
                continue;
            attack.UpdateAttack(dt);
        }

        foreach (Enemy enemy in m_pEnemies)
        {
            if (enemy == null)
                continue;
            enemy.UpdateEnemy(dt);
            enemy.CheckBounds(m_vBottomLeftCorner, m_vUpperRightCorner);
        }

        foreach (LevelObject lo in m_pLevelObjects)
        {
            if (lo == null)
                continue;
            lo.UpdateLevelObject(dt);
        }

        return false;       // Level is not over
	}

    private Enemy CreateEnemy(Vector3 pos)
    {
        Enemy enemy = Enemy.CreateEnemy(m_pEnemyTypes[Random.Range(0, m_pEnemyTypes.Length)], m_pEnemyStats[Random.Range(0, m_pEnemyStats.Length)], pos, m_gEnemies);
        m_pEnemies.Add(enemy);
        return enemy;
    }

    private Attack CreateAttack(Vector3 pos)
    {
        pos.z = 50;
        Attack attack = Attack.CreateAttack(m_pAttackType, m_pAttackStats, pos, m_gAttacks);
        m_pAttacks.Add(attack);
        return attack;
    }

    private void SpawnEnemy()
    {
        Enemy enemy = null;
        foreach (Enemy en in m_pEnemies)
        {
            if (en != null && en.IsDead)
            {
                enemy = en;
                break;
            }
        }
        Vector3 pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);

        if (enemy != null)
        {
            enemy.Initialize( m_pEnemyTypes[Random.Range(0, m_pEnemyTypes.Length)], m_pEnemyStats[Random.Range(0, m_pEnemyStats.Length)] );
            enemy.transform.position = pos;
        }
        else
        {
            CreateEnemy(pos);
        }

    }
}
