using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlaceTower : MonoBehaviour

{

    public Camera Cam;
    public GameObject Tower;
    public int ResourceCount;
    [SerializeField] private TMP_Text ResourceCounter;
    // Start is called before the first frame update
    void Start()
    {
        ResourceCount = 10;
        ResourceCounter.text = ResourceCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.value;

            Ray ray = Cam.ScreenPointToRay(mousePosition);

            bool Hit = Physics.Raycast(ray, out RaycastHit HitInfo);

            if (Hit)
            {
                string ObjectHit = HitInfo.collider.name.ToString();


                if (Hit && ObjectHit == "Plane" && ResourceCount >= 3)
                {
                    Vector3 rayPos = HitInfo.point;
                    rayPos.y = rayPos.y + 1.0f;

                    Instantiate(Tower, rayPos, Quaternion.identity);
                    ResourceCount = ResourceCount - 3;
                    ResourceCounter.text = ResourceCount.ToString();
                }
            }

            else
            {
                Debug.Log("Nothing Hit");
            }
          
        }
    }

    public void AddResources()
    {
        ResourceCount = ResourceCount + 1;
        ResourceCounter.text = ResourceCount.ToString();
    }
}
