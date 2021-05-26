using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleAndInVisibleTest : MonoBehaviour
{

    private void OnBecameVisible()
    {
        Debug.Log("visible");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("invisible");
    }
}
