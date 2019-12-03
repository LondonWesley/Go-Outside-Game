using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverQuoting : MonoBehaviour
{
    public Text motivation = null;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 6);
        string[] tArray = {
        "Don't give up! You have people waiting for you and a home to return to. Don't abandon them...",
        "Is that all the strength you have? Get up, Ranger! You can do better.",
        "What an embrassing way to die... Go redeem yourself, Ranger!",
        "Feel that? That's a wound to your pride. You can either keep that wound or fight back!",
        "Ranger, you earned this job. Show those things why this park is yours!",
        "Please... don't give those things the satisfication of victory. Don't let them beat your humanity!",
        "Come on! You can do this! And please... don't ever think for one second that you are alone."
        };
        motivation.text = tArray[rand];
    }
}
