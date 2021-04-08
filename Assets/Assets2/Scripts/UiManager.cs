using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UiManager : MonoBehaviour
{
    //Refactor en anglais
    [SerializeField] private GameObject[] personnagesPrincipaux;
    private GameObject _currentCharacter;

    [SerializeField] private Text _nomTitre;
    [SerializeField] private Text _desc;

    private int index;
    void Start()
    {
        //CurrentCharacter = Instantiate(personnagesPrincipaux[0]);
        CurrentCharacter = personnagesPrincipaux[0];
        CurrentCharacter.SetActive(true);
        _nomTitre.text = DescriptionBD.TitresDescriptions[index][0];
        _desc.text = DescriptionBD.TitresDescriptions[index][1];;
    }

    public void ChangerPersonnage(int incrementeur)
    {
        CurrentCharacter.SetActive(false);
        //if(!(CurrentCharacter is null))Destroy(CurrentCharacter);
        if (index + incrementeur < 0)
            index = 5;
        else if (index + incrementeur > 5)
        {
            index = 0;
        }
        else
        {
            index += incrementeur;
        }
        _nomTitre.text = DescriptionBD.TitresDescriptions[index][0];
        _desc.text = DescriptionBD.TitresDescriptions[index][1];
        CurrentCharacter = personnagesPrincipaux[index].gameObject;
        CurrentCharacter.SetActive(true);
    }
    
    public GameObject CurrentCharacter
    {
        get => _currentCharacter;
        set => _currentCharacter = value;
    }
}
