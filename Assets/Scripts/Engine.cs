using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private static ILogger logger = Debug.unityLogger;

    public Player player;
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (this.terrain.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity)) {
                player.MoveTo(hit.point);
            }
        }
    }
}
