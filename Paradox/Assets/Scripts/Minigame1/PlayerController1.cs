using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    MapController map;
    public static string text; 

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (MapController.count < 5 && PlayerController1.text != " GAME OVER !! ")
            text = "Level : " + (MapController.count + 1);
        else if (MapController.count < 5 && PlayerController1.text == " GAME OVER !! ")
        {
            PlayerController1.text = "Level : " + (MapController.count + 1);
            transform.position = MapController.originalPosition;
        }
        else if(MapController.count == 5)
        {
            MapController.count = 0;
            minigameText.minigames++;
            SceneManager.UnloadSceneAsync("Level1");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MapController.count = 0;
            SceneManager.UnloadSceneAsync("Level1");
        }
        float horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horiz * moveSpeed, rb.velocity.y, 0f);
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, vert * moveSpeed, 0f);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "End")
        {
            text = " ";
            MapController.count++;
            if (MapController.count < 5)
            {
                GameObject go = GameObject.Find("InstanceContainer");
                Destroy(go.gameObject);
                map = GameObject.Find("MapController").GetComponent<MapController>();
                map.Init();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20),text);
    }
}
