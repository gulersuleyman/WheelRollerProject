using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    //hepsi farkli ise 10x , iki benzer var ise 20x, hepsi ayni ise 100x
    [SerializeField] GameObject[] _row1;
    [SerializeField] GameObject[] _row2;
    [SerializeField] GameObject[] _row3;


    public PlayerController _player;
    public int _bonusIndex;

    int _activePlanetIndex=0;
    int _randomIndex;
    int _randomIndex2;
    int _randomIndex3;
    bool _slotEnd = false;
    

    InputController _input;

    private void Awake()
    {
        _input = new InputController();

        for (int i = 0; i < 3; i++)
        {
            _row1[i].gameObject.SetActive(false);
            _row2[i].gameObject.SetActive(false);
            _row3[i].gameObject.SetActive(false);

        }
        _row1[_activePlanetIndex].gameObject.SetActive(true);
        _row2[_activePlanetIndex + 1].gameObject.SetActive(true);
        _row3[_activePlanetIndex + 2].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!_player._slotSceneActive) return;



        if(_input.FirstMouseClick && !_slotEnd)
        {

            StartCoroutine(StartSlot());

            _slotEnd = true;
            
        }
    }


    private IEnumerator StartSlotSequence()
    {
        ActiveFalse(_row1);
        ActiveFalse(_row2);
        ActiveFalse(_row3);

        _row1[_randomIndex].gameObject.SetActive(true);
        _row2[_randomIndex2].gameObject.SetActive(true);
        _row3[_randomIndex3].gameObject.SetActive(true);
        yield return null;
    }


    private IEnumerator StartSlot()
    {
        for (int i = 0; i < 15; i++)
        {
            _randomIndex = Random.Range(0, 3);
            _randomIndex2 = Random.Range(0, 3);
            _randomIndex3 = Random.Range(0, 3); 
            StartCoroutine(StartSlotSequence());

            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }


    private void ActiveFalse(GameObject[] row)
    {
        foreach (var planet in row)
        {
            planet.gameObject.SetActive(false);
        }
    }

}
