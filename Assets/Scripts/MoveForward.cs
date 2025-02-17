using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    // ** Mueve el gameObject hacia adelante
    public float speed= 40.0f;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        // Se usa up porque en este caso se requiere para mover el objeto hacia adelante
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
