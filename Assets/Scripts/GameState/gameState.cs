using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
	public bool interactive;
	public BeamStretch beamStretch;
	public BeamController beamController;
	public Player player;
	public bool isLit;

	// Use this for initialization
	void Start ()
	{
		beamStretch = GameObject.Find("Player").GetComponent<BeamStretch>();
		
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//beamStretch.enabled = interactive;
		//beamController.enabled = interactive;
		player.enabled = interactive;
		//GameObject.Find("MimLight").GetComponent<Collider2D>().enabled = interactive;

        if (Input.GetKeyDown(KeyCode.R)) {
            Invoke("Restart", 1);
        }

		if (interactive == false)
		{
			player.GetComponent<Rigidbody2D>().constraints =
				RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX |
				RigidbodyConstraints2D.FreezeRotation;
		}
	}

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
