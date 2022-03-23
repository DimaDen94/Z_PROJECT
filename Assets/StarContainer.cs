using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContainer : MonoBehaviour
{
    [SerializeField] private GameObject _leftStar;
    [SerializeField] private GameObject _midleStar;
    [SerializeField] private GameObject _rightStar;

    public void RenderStar(int starCount)
    {
        switch (starCount)
        {
            case 1:
                _leftStar.SetActive(false);
                _midleStar.SetActive(true);
                _rightStar.SetActive(false);
                break;
            case 2:
                _leftStar.SetActive(true);
                _midleStar.SetActive(true);
                _rightStar.SetActive(false);
                break;
            case 3:
                _leftStar.SetActive(true);
                _midleStar.SetActive(true);
                _rightStar.SetActive(true);
                break;
            default:
                _leftStar.SetActive(false);
                _midleStar.SetActive(false);
                _rightStar.SetActive(false);
                break;
        }
    }
}
