using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineController : MonoBehaviour
{
    //all different 10x , two the same 20x, all the same 100x
    [SerializeField] GameObject[] _row1;
    [SerializeField] GameObject[] _row2;
    [SerializeField] GameObject[] _row3;
    [SerializeField] GameObject _lastPanel;
    [SerializeField] ParticleSystem _successParticle;
    [SerializeField] GameObject _slotArrow;


    public PlayerController _player;
    public int _bonusIndex;
    public Text _bonusIndexText;
    public Text _coinText;


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
            _slotArrow.gameObject.SetActive(false);
            _slotEnd = true;
            
        }
    }


    private void StartSlotSequence()
    {
        ActiveFalse(_row1);
        ActiveFalse(_row2);
        ActiveFalse(_row3);

        _row1[_randomIndex].gameObject.SetActive(true);
        _row2[_randomIndex2].gameObject.SetActive(true);
        _row3[_randomIndex3].gameObject.SetActive(true);
     
    }


    private void ActiveFalse(GameObject[] row)
    {
        foreach (var planet in row)
        {
            planet.gameObject.SetActive(false);
        }
    }


    private IEnumerator StartSlot()
    {
        for (int i = 0; i < 15; i++)
        {
            _randomIndex = Random.Range(0, 3);
            _randomIndex2 = Random.Range(0, 3);
            _randomIndex3 = Random.Range(0, 3);
            if(i==14)
            {
                if (_randomIndex == _randomIndex2 && _randomIndex2 == _randomIndex3)
                {
                    _bonusIndex = 100;
                }
                else if (_randomIndex == _randomIndex2 || _randomIndex2 == _randomIndex3 || _randomIndex==_randomIndex3)
                {
                    _bonusIndex = 20;
                }
                else
                {
                    _bonusIndex = 10;
                }
                _successParticle.Play();
                _bonusIndexText.text = _bonusIndex.ToString() + "X";
                _coinText.text = ((GameManager.Instance._marsScore + GameManager.Instance._saturnScore + GameManager.Instance._worldScore) * _bonusIndex).ToString();
                _lastPanel.gameObject.SetActive(true);
                GameManager.Instance.IncreaseGameScore(_bonusIndex);
            }
            
            StartSlotSequence();
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return null;
    }


    

}
