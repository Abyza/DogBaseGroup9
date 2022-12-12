using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using TMPro;

public class dogs : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public GameObject childOfList;
    public GameObject parentOfList;

    Action<string> _createItemsCallback;
    Action<Sprite> _getDogImage;
    Action<string> _showOwner;

    public TMP_InputField[] inputfields;
    public TMP_InputField[] ownerInputField;

    public GameObject dogImage;
    public TextMeshProUGUI ownerInfo;

    void Start()
    {
        _createItemsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
        };

        _getDogImage = (jsonArrayString) =>
        {
            StartCoroutine(GetDogImage(jsonArrayString));
        };

        _showOwner = (jsonArrayString) =>
        {
            StartCoroutine(GetOwner(jsonArrayString));
        };

    }

    

    public void createItems()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("item");
        foreach(GameObject target in targets)
        {
            GameObject.Destroy(target);
        }
        StartCoroutine(main.Instance.web.GetPetList(_createItemsCallback));
    }

    public void showDog()
    {
        StartCoroutine(main.Instance.web.GetDogImage(inputfields[7].text, _getDogImage));
    }
    public void addOwner()
    {
        StartCoroutine(main.Instance.web.AddOwner(ownerInputField[0].text, ownerInputField[1].text));
    }

    public void showOwner()
    {

        StartCoroutine(main.Instance.web.GetOwner(ownerInputField[2].text, _showOwner));
    }

    public void showUnowned()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject target in targets)
        {
            GameObject.Destroy(target);
        }
        StartCoroutine(main.Instance.web.ShowUnowned(_createItemsCallback));
    }

    public void addDog()
    {
        StartCoroutine(main.Instance.web.AddDog(inputfields[0].text, inputfields[1].text, inputfields[2].text
            , inputfields[3].text, inputfields[4].text, inputfields[5].text, inputfields[6].text));
        StartCoroutine(refreshDisplay());
    }

    public void updateDog()
    {
        StartCoroutine(main.Instance.web.UpdateDog(inputfields[0].text, inputfields[1].text, inputfields[2].text
            , inputfields[3].text, inputfields[4].text, inputfields[5].text, inputfields[6].text, inputfields[7].text));
        StartCoroutine(refreshDisplay());
    }

    public void deleteDog()
    {

        StartCoroutine(main.Instance.web.DeleteDog(inputfields[7].text));
        StartCoroutine(refreshDisplay());
    }

    IEnumerator refreshDisplay()
    {

        yield return new WaitForSeconds(1);
        createItems();
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for(int i =0; i<jsonArray.Count; i++)
        {
            Debug.Log(jsonArray[i].AsObject["pet_name"]);
            GameObject entry = Instantiate(childOfList,parentOfList.transform.position, Quaternion.identity, parentOfList.transform);

            GameObject[] testlist =  new GameObject[8];
            TextMeshProUGUI[] texttextList = new TextMeshProUGUI[8];

            for (int j = 0; j <8; j++)
            {
                GameObject text = entry.transform.GetChild(1+j).gameObject;
                testlist[j] = text;
                texttextList[j] = testlist[j].GetComponent<TextMeshProUGUI>();
            }

        
            string pet_name = jsonArray[i].AsObject["pet_name"];
            string is_owned = "No";
            string owner_id = jsonArray[i].AsObject["owner_id"];
            string registered_date = jsonArray[i].AsObject["registered_date"];
            string pet_age = jsonArray[i].AsObject["pet_age"];
            string pet_weight = jsonArray[i].AsObject["pet_weight"];
            string is_vaccinated = "No";
            string pet_id = jsonArray[i].AsObject["pet_id"];
            if (jsonArray[i].AsObject["is_owned"] == "1")
            {
                is_owned = "Yes";
            }
            if(jsonArray[i].AsObject["is_vaccinated_for_rabies"] == "1")
            {
                is_vaccinated = "Yes";
            }
            texttextList[0].text = pet_name;
            texttextList[1].text = is_owned;
            texttextList[2].text = owner_id;
            texttextList[3].text = registered_date;
            texttextList[4].text = pet_age;
            texttextList[5].text = pet_weight;
            texttextList[6].text = is_vaccinated;
            texttextList[7].text = pet_id;

        }

        yield return null;
    }


    IEnumerator GetDogImage(Sprite jsonArrayString)
    {
        dogImage.GetComponent<Image>().sprite = jsonArrayString;

      

        yield return null;
    }


    IEnumerator GetOwner(string jsonArrayString)
    {

        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

      
        string name = (jsonArray[0].AsObject["owner_name"]);
        string address = (jsonArray[0].AsObject["owner_address"]);

        ownerInfo.GetComponent<TextMeshProUGUI>().text = "Name: "+name+"\nAddress: "+address;

        yield return null;
    }

}
