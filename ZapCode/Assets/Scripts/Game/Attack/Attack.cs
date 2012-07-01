using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    AttackStats m_pAttackStats = null;
    AttackType m_pAttackType = null;

    public void Initialize(AttackType type, AttackStats stats)
    {
        m_pAttackType = type;
        m_pAttackStats = stats;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
