using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int _score = 1;

    [SerializeField] PlanetEnum type;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if(type == PlanetEnum.mars)
            {
                GameManager.Instance.IncreaseScore(_score, 0, 0);
                Debug.Log(GameManager.Instance._marsScore);
                Destroy(this.gameObject);
            }
            else if(type == PlanetEnum.world)
            {
                GameManager.Instance.IncreaseScore(0, _score, 0);
                Debug.Log(GameManager.Instance._worldScore);
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.Instance.IncreaseScore(0, 0, _score);
                Debug.Log(GameManager.Instance._saturnScore);
                Destroy(this.gameObject);
            }
        }
    }
}
