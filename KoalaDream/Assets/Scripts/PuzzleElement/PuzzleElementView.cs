using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleElementView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<PuzzleElement> allItems = new();

    [SerializeField] private PuzzleElement currentPuzzleElement;

    [Header("Настройки")]
    [SerializeField] private int displayCount = 3;
    [SerializeField] private List<Transform> displaySlots = new List<Transform>();
    private int startIndex = 0;
    private readonly List<PuzzleElement> displayedObjects = new List<PuzzleElement>();

    [Header("")]
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    public void SetPuzzleElements(Puzzles puzzles)
    {
        allItems = new(puzzles.puzzleElements);

        UpdateDisplay();
        UpdateButtons();
    }

    public void Initialize()
    {
        buttonLeft.onClick.AddListener(LeftButton);
        buttonRight.onClick.AddListener(RightButton);
    }

    public void Dispose()
    {
        buttonLeft.onClick.RemoveListener(LeftButton);
        buttonRight.onClick.RemoveListener(RightButton);
    }

    public void GrabPuzzleElement(PuzzleElement puzzleElement)
    {
        UngrabCurrentPuzzleElement();

        currentPuzzleElement = puzzleElement;

        currentPuzzleElement.OnStartMove += OnStartMove;
        currentPuzzleElement.OnMove += OnMove;
        currentPuzzleElement.OnEndMove += OnEndMove;
    }

    public void UngrabCurrentPuzzleElement()
    {
        if (currentPuzzleElement != null)
        {
            currentPuzzleElement.OnStartMove -= OnStartMove;
            currentPuzzleElement.OnMove -= OnMove;
            currentPuzzleElement.OnEndMove -= OnEndMove;

            Teleport();
        }
    }

    public void Destroy()
    {
        Remove(currentPuzzleElement.ID);
    }

    public void Teleport()
    {
        currentPuzzleElement.Teleport();
    }

    public void StartMove()
    {
        currentPuzzleElement.StartMove();
    }

    public void EndMove()
    {
        currentPuzzleElement.EndMove();
    }

    public void Move(Vector2 vector)
    {
        currentPuzzleElement.Move(vector);
    }

    #region Input

    public void OnGrabPuzzleElement(PuzzleElement puzzleElement)
    {
        OnGrabPuzzleElement_Action?.Invoke(puzzleElement);
    }

    private void OnMove(Vector2 vector)
    {
        OnMove_Action?.Invoke(vector / canvas.scaleFactor);
    }

    private void OnStartMove()
    {
        OnStartMove_Action?.Invoke();
    }

    private void OnEndMove(int id, Transform transform)
    {
        OnEndMove_Action?.Invoke(id, transform);
    }

    public event Action<PuzzleElement> OnGrabPuzzleElement_Action;

    public event Action<Vector2> OnMove_Action;

    public event Action OnStartMove_Action;

    public event Action<int, Transform> OnEndMove_Action;

    #endregion




    //////////////////


    public void Remove(int idElement)
    {
        var indexInAllItems = allItems.IndexOf(allItems.FirstOrDefault(data => data.ID == idElement));

        if (indexInAllItems < 0 || indexInAllItems >= allItems.Count) return;

        allItems.RemoveAt(indexInAllItems);

        if (indexInAllItems < startIndex && startIndex > 0)
        {
            startIndex--;
        }

        if (startIndex + displayCount > allItems.Count)
        {
            startIndex = Mathf.Max(0, allItems.Count - displayCount);
        }

        UpdateDisplay();
        UpdateButtons();
    }



    private void UpdateDisplay()
    {
        foreach (PuzzleElement t in displayedObjects)
        {
            Destroy(t.gameObject);
            t.OnGrabbing -= OnGrabPuzzleElement;
            t.Dispose();
        }

        displayedObjects.Clear();

        for (int i = 0; i < displayCount; i++)
        {
            int itemIndex = startIndex + i;

            if (itemIndex >= allItems.Count || i >= displaySlots.Count)
                continue;

            PuzzleElement item = Instantiate(allItems[itemIndex], displaySlots[i]);
            item.transform.localPosition = Vector3.zero;

            item.OnGrabbing += OnGrabPuzzleElement;
            item.Initialize();

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
        if (startIndex > 0)
        {
            startIndex--;
            UpdateDisplay();
            UpdateButtons();
        }
    }

    public void RightButton()
    {
        Debug.Log("jfv");

        if ((startIndex + displayCount) < allItems.Count)
        {
            startIndex++;
            UpdateDisplay();
            UpdateButtons();
        }
    }

}
