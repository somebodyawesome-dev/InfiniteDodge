using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<AudioManager>().play("MainMenuMusic");
    }
}
