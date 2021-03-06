using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private GameObject player;
    [SerializeField] private GameObject targetObject;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        RaycastHit[] hitList = Physics.RaycastAll(player.transform.position, Vector3.forward);
        foreach (RaycastHit hit in hitList)
        {
            if (hit.collider.tag == "WallViseur")
            {
                Vector3 screenPos = cam.WorldToScreenPoint(hit.point);
                targetObject.transform.position = screenPos;
            }
        }
        Debug.DrawRay(player.transform.position, Vector3.forward, Color.cyan);
    }
}
