using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldItems : MonoBehaviour {

    private ArrayList keyNumbers;
    private List<Image> itemBar;
    private Color transparent = Color.clear;
    private Color visible = Color.white;
    private Sprite keyImage;

	// Use this for initialization
	void Start () {
        keyNumbers = new ArrayList();
        itemBar = new List<Image>();
        itemBar.Add(GameObject.Find("Item 1").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 2").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 3").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 4").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 5").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 6").GetComponent<Image>());
        itemBar.Add(GameObject.Find("Item 7").GetComponent<Image>());
        /*keyImage = Resources.Load<Sprite>("Key_Icon");
        foreach(Image img in itemBar)
        {
            img.sprite = keyImage;
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addKey(int number)
    {
        keyNumbers.Add(number);
        showKey();
    }
    
    public bool useKey(int number)
    {
        if (keyNumbers.Contains(number))
        {
            keyNumbers.Remove(number);
            removeKey();
            return true;
        }else
        {
            return false;
        }
    }

    private void showKey()
    {
        int count = keyNumbers.Count;
        itemBar[count - 1].color = visible;
    }

    private void removeKey()
    {
        int count = keyNumbers.Count;
        itemBar[count].color = transparent;
    }
}
