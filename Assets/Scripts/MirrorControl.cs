using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : MonoBehaviour
{
    float _rotationSpeed = 30f;
    bool _isSelected;

    public bool _isBlue;
    public bool _isGreen;
    public bool _isYellow;
    public bool _isRed;
    // Update is called once per frame
    void Update()
    {
        SelectionCheck();
    }

    private void SelectionCheck()
    {
        if (_isSelected)
        {
            // Rotate object when 'A' key is pressed
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
            }

            // Rotate object when 'D' key is pressed
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.down, _rotationSpeed * Time.deltaTime);
            }
        }
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with any GameObject
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked GameObject is the one attached to this script
                if (hit.collider.gameObject == gameObject)
                {
                    // The attached GameObject is clicked
                    Debug.Log("Clicked on this GameObject!");
                    _isSelected = true;
                }
                else if (hit.collider.gameObject.tag == "Mirror")
                {
                    _isSelected = false;
                }
            }
        }
    }
}
