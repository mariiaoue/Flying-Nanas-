using UnityEngine;

public class GemController : MonoBehaviour
{
    public GameObject blossom;
    public GameObject buttercup;
    public GameObject bubbles;
    

    void Start()
    {
      int gem = PlayerPrefs.GetInt("GemSelected");
      if(gem == 1 || gem == null)
      {
         RedGem();
      }
      if(gem == 2)
      {
        GreenGem();
      }
      if(gem == 3)
      {
        BlueGem();
      }
    }
    public void RedGem()
    {
        ActivateObject(blossom, buttercup, bubbles);
        PlayerPrefs.SetInt("GemSelected",1);
    }

    public void GreenGem()
    {
        ActivateObject(buttercup, blossom, bubbles);
        PlayerPrefs.SetInt("GemSelected",2);
    }

    public void BlueGem()
    {
        ActivateObject(bubbles, blossom, buttercup);
        PlayerPrefs.SetInt("GemSelected",3);
    }

    private void ActivateObject(GameObject toActivate, GameObject toDeactivate1, GameObject toDeactivate2)
    {
        if (toActivate != null) toActivate.SetActive(true);
        if (toDeactivate1 != null) toDeactivate1.SetActive(false);
        if (toDeactivate2 != null) toDeactivate2.SetActive(false);
    }
}
