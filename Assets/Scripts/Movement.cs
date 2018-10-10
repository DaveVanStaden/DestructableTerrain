using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public int speed = 1;
    public int rotationSpeed = 1;
    float translation;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement();
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void PlayerMovement()
    {
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= (speed) * Time.deltaTime;
        rotation *= Time.deltaTime;
        lookhere.y = Mathf.Clamp(lookhere.y, -40, 40);
        transform.Translate(0, 0, translation);
        transform.Rotate(lookhere);
    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.Translate(0, 0, (translation - 1));
    }
}
