using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    AttackStats m_pAttackStats = null;
    AttackType m_pAttackType = null;

    public void Initialize(AttackType type, AttackStats stats)
    {
        m_pAttackType = Instantiate(type) as AttackType;
        m_pAttackType.transform.parent = this.transform;

        m_pAttackStats = Instantiate(stats) as AttackStats;
        m_pAttackStats.transform.parent = this.transform;
    }

	// Use this for initialization
	void Start () {
        //m_pAttackStats = GetComponentInChildren<AttackStats>();
        //m_pAttackType = GetComponentInChildren<AttackType>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static Attack CreateAttack(AttackType type, AttackStats stats, Vector3 pos)
    {
        GameObject go = new GameObject();
        go.AddComponent<Attack>();
        go.transform.position = pos;
        Attack attack = go.GetComponent<Attack>();
        attack.Initialize(type, stats);

        return attack;
    }
}
