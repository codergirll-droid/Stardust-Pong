using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketP1Sound;
    public AudioSource racketP2Sound;
    public AudioSource SideWallSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketPlayer1")
        {
            this.racketP1Sound.Play();
        }
        else if(collision.gameObject.name == "RacketPlayer2")
        {
            this.racketP2Sound.Play();
        }
        else if(collision.gameObject.name == "WallTop" || collision.gameObject.name == "WallBottom")
        {
            this.wallSound.Play();
        }
        else
        {
            this.SideWallSound.Play();
        }
    }

}
