using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("bullet"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
