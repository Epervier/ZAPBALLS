using UnityEngine;
using System.Collections;
/// <summary>
/// Modifies the stats of an attack.  
/// Can be a percentage or a straight up number, not all stats may be used depending on the attack type it is paired with.  
/// As much data as you want in other words.
/// </summary>
public class AttackStats : MonoBehaviour {

    public float m_fFireRate = 1.0f;
    public float m_fDamage = 1.0f;
    public float m_fLifetime = 1.0f;
    public float m_fGrowthRate = 1.0f;
    public float m_fMaxSize = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
