using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceSelectionManager : MonoBehaviour
{
    public static FaceSelectionManager Instance { get; private set; }
    [SerializeField] private SingleFaceSectionUI singleFaceSectionUI;
    [SerializeField] private Transform container;
    [SerializeField] private Transform descText;

    private FaceController selectedFaceController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetChosenFace();
    }

    public void SetChosenFace()
    {
        List<GameObject> faceControllerList = GameManager.Instance.GetFaceControllers();
        selectedFaceController = faceControllerList[Random.Range(0, faceControllerList.Count)].GetComponent<FaceController>();
        selectedFaceController.Select();

        Dictionary<string, Sprite> faceDict = selectedFaceController.GetFaceDict();
        List<GameObject> faceSelectionList = new();

        foreach (var item in faceDict)
        {
            GameObject faceSelection = Instantiate(singleFaceSectionUI.gameObject, container);
            faceSelectionList.Add(faceSelection);
            faceSelection.GetComponent<SingleFaceSectionUI>().UpdateUI(item.Value, item.Key);
        }

        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, faceSelectionList.Count);
            faceSelectionList[randomNumber].SetActive(false);
            faceSelectionList.Remove(faceSelectionList[randomNumber]);
        }
    }

    public void ClearFaceComponentUI()
    {
        foreach (Transform item in container)
        {
            if (item == descText) continue;
            Destroy(item.gameObject);
        }


    }

}
