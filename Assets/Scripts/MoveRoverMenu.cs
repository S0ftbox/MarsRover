using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoverMenu : MonoBehaviour
{
    public GameObject finishPos;
    public GameObject fl, fr, rl, rr;
    public GameObject driveAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fl.GetComponent<Animation>().Play("LeftFWD");
            fr.GetComponent<Animation>().Play("RightFWD");
            rl.GetComponent<Animation>().Play("LeftFWD");
            rr.GetComponent<Animation>().Play("RightFWD");
            driveAudio.GetComponent<AudioSource>().Play();
            StartCoroutine(RoverMove());
        }
    }

    public IEnumerator RoverMove()
    {
        Vector3 targetPos = finishPos.transform.position;
        while ((transform.position.x != targetPos.x) && (transform.position.z != targetPos.z))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.75f * Time.deltaTime);
            yield return null;
        }
        fl.GetComponent<Animation>().Stop();
        fr.GetComponent<Animation>().Stop();
        rl.GetComponent<Animation>().Stop();
        rr.GetComponent<Animation>().Stop();
        driveAudio.GetComponent<AudioSource>().Stop();
    }
}
