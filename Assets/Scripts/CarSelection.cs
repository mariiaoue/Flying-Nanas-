using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarSelection : MonoBehaviour
{

    public Button previosButton;
    public Button nextButton;
  
    private int currentCar;
    private int SelecttCar;
 


    private void Awake()
    {
          
         SelecttCar = PlayerPrefs.GetInt("SelectedCar");

        if(SelecttCar != null)
        {
          SelectCar(SelecttCar);
          PlayerPrefs.SetInt("currentCar",SelecttCar);
        }else{
          SelectCar(0);
          PlayerPrefs.SetInt("currentCar",0);
        }
        
    }

   

    public void ChangeCar(int _change)
    {
      FindObjectOfType<AudioManager>().Play("ButtonClick");
       currentCar = PlayerPrefs.GetInt("currentCar");
       currentCar += _change;
       SelectCar(currentCar);
       PlayerPrefs.SetInt("currentCar",currentCar);
       PlayerPrefs.SetInt("SelectedCar",currentCar);
      
      
    }

 
    private void SelectCar(int _index)
    {
        previosButton.gameObject.SetActive(_index != 0);
        nextButton.gameObject.SetActive(_index != transform.childCount-1);
        
        
       for (int i = 0; i < transform.childCount; i++)
       {
        transform.GetChild(i).gameObject.SetActive(i == _index);
       }
    }


}
