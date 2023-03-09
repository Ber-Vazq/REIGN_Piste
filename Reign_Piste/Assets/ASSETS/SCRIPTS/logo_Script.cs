using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo_Script : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos;

    // Start is called before the first frame update
    private void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time*freq)*amp +initPos.y,0);
    }
}
