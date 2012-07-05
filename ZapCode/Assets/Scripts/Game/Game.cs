using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public Level m_pLevel = null;

	// Use this for initialization
	void Start () 
    {
        if( m_pLevel != null )
            m_pLevel.Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float dt = Time.deltaTime;
        bool gameOver = false;

        if (m_pLevel != null)
        {
            gameOver = m_pLevel.UpdateLevel(dt);
        }

        if (gameOver == true)
        {
            //  Transition
        }

	}
}
