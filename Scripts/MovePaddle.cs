using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    [SerializeField]
    private  float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        float transform_y = (Input.GetAxis("Mouse Y") * speed * Time.deltaTime);
        float transform_x = (Input.GetAxis("Mouse X") * speed * Time.deltaTime);
        transform.Translate(transform_x, 0, transform_y);
    }
}
