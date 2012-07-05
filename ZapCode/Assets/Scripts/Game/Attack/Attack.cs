using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public AttackStats m_pAttackStats = null;
    public AttackType m_pAttackType = null;

    public void Initialize(AttackType type, AttackStats stats)
    {
        m_pAttackStats = Instantiate(stats) as AttackStats;
        m_pAttackStats.transform.parent = this.transform;
        m_pAttackStats.gameObject.layer = this.gameObject.layer;

        m_pAttackType = Instantiate(type) as AttackType;
        m_pAttackType.transform.parent = this.transform;
        m_pAttackType.gameObject.layer = this.gameObject.layer;
        m_pAttackType.Initialize(this);

    }

	// Use this for initialization
	void Start () {
        //m_pAttackStats = GetComponentInChildren<AttackStats>();
        //m_pAttackType = GetComponentInChildren<AttackType>();
	}
	
	// Update is called once per frame
	public void UpdateAttack (float dt) {
        m_pAttackType.UpdateType(dt);
	}

    public static Attack CreateAttack(AttackType type, AttackStats stats, Vector3 pos, GameObject parent)
    {
        GameObject go = new GameObject();
        go.AddComponent<Attack>();
        go.transform.parent = parent.transform;
        go.layer = parent.layer;
        go.name = "Attack";

        Attack attack = go.GetComponent<Attack>();
        attack.Initialize(type, stats);

        go.transform.position = pos;

        return attack;
    }

    public void AttackFinished()
    {
        gameObject.SetActiveRecursively(false);
    }
}
