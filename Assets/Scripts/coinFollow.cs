using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinFollow : MonoBehaviour
{
    public Transform Target;
    public float minModifier;
    public float maxModifier;

    private Vector3 velocity = Vector3.zero;
    private bool isFollowing = false;
    public void StartFollowing()
    {
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
    }
}
