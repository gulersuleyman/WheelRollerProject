using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int _score = 1;
    Vector3 _wheelSize;

    [SerializeField] PlanetEnum type;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            if(type == PlanetEnum.mars)
            {
                GameManager.Instance.IncreaseScore(_score, 0, 0);
                WheelSizeAction(player);
            }
            else if(type == PlanetEnum.world)
            {
                GameManager.Instance.IncreaseScore(0, _score, 0);
                WheelSizeAction(player);
            }
            else
            {
                GameManager.Instance.IncreaseScore(0, 0, _score);
                WheelSizeAction(player);
            }
        }
    }

    private void WheelSizeAction(PlayerController player)
    {
        _wheelSize = player._wheel.transform.localScale;
        _wheelSize.z += 13f;
        player._wheel.transform.localScale = _wheelSize;
        Destroy(this.gameObject);
    }
}
