using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerCheckScript : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public bool bIsOnGround = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        Debug.Log(LayerMask.GetMask("Ground"));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      if(collision.gameObject.GetComponent<GroundScript>() != null)
        {
            bIsOnGround = true;
        }
      else
        {
            bIsOnGround = false;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<GroundScript>() != null)
    //    {
    //        bIsOnGround = true;
    //    }
    //    else
    //    {
    //        bIsOnGround = false;
    //    }
    //}
}
