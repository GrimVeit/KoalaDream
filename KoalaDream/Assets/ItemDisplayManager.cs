using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayManager : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private int displayCount = 3;

    [SerializeField] private List<Transform> displaySlots = new List<Transform>();

    [Header("")]
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [Header("")]
    [SerializeField] private List<GameObject> itemsPrefabs = new List<GameObject>();

    public List<GameObject> allItems;
    private int startIndex = 0;
    private readonly List<GameObject> displayedObjects = new List<GameObject>();

    private void Awake()
    {
        allItems = new List<GameObject>(itemsPrefabs);

        UpdateDisplay();
        UpdateButtons();
    }

    private void UpdateDisplay()
    {
        foreach (GameObject t in displayedObjects)
        {
            Destroy(t);
        }

        displayedObjects.Clear();

        for (int i = 0; i < displayCount; i++)
        {
            int itemIndex = startIndex + i;

            if(itemIndex >= allItems.Count || i >= displaySlots.Count)
                continue;

            GameObject item = Instantiate(allItems[itemIndex], displaySlots[i]);
            item.transform.localPosition = Vector3.zero;

            displayedObjects.Add(item);
        }
    }

    private void UpdateButtons()
    {
        buttonLeft.gameObject.SetActive(startIndex > 0);
        buttonRight.gameObject.SetActive((startIndex + displayCount) < allItems.Count);
    }

    public void LeftButton()
    {
        if(startIndex > 0)
        {
            startIndex--;
            UpdateDisplay();
            UpdateButtons();
        }
    }

    public void RightButton()
    {
        Debug.Log("jfv");

        if((startIndex + displayCount) < allItems.Count)
        {
            startIndex++;
            UpdateDisplay();
            UpdateButtons();
        }
    }

    public void Remove(int index)
    {
        if(index < 0 || index >= allItems.Count) return;

        allItems.RemoveAt(index);

        if(index < startIndex && startIndex > 0)
        {
            startIndex--;
        }

        if(startIndex + displayCount > allItems.Count)
        {
            startIndex = Mathf.Max(0, allItems.Count - displayCount);
        }

        UpdateDisplay();
        UpdateButtons();
    }
}
