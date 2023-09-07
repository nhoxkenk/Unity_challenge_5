using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class DrawOnScreen : MonoBehaviour
{
    GameManager gameManager;
    Camera cam;
    Vector3 mousePos;
    TrailRenderer trailRenderer;
    BoxCollider col;

    bool swiping = false;

    private void Awake()
    {
        cam = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trailRenderer.enabled = false;
        col.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        trailRenderer.enabled = swiping;
        col.enabled = swiping;
    }

    private void Update()
    {
        if(gameManager.isGameActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }else if (Input.GetMouseButtonUp(0))
            {
                swiping= false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
