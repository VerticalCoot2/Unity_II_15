using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyingControls : MonoBehaviour
{
    [Header ("\nPlayer")]
    [SerializeField] Transform playerTransform;
    [SerializeField]float baseSpeed;
    [SerializeField] float speed;

    [Header("\ncheckPoints")]
    [SerializeField] int checkpointCounter = 0;
    [SerializeField] List<Transform> chckList = new List<Transform>();

    [Header ("\nAnimation")]
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        speed = baseSpeed + GvrVRHelpers.GetHeadRotation().x * 10;

        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + GvrVRHelpers.GetHeadForward(),
            speed * Time.deltaTime
        );
    }

    void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        baseSpeed = 0;
        anim.SetTrigger("f_Out");
        yield return new WaitForSecondsRealtime(1);
        playerTransform.position = chckList[checkpointCounter].position;
        anim.SetTrigger("f_In");
        baseSpeed = 5;
        Debug.Log("lefutott");
        
    }
}
