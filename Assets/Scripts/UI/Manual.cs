using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    [SerializeField] private GameObject _manualTogglePanel, _previousPageButton, _nextPageButton;
    [SerializeField] private List<GameObject> _manualPages = new List<GameObject>();

    private int _pageSelected = 0;

    public void TogglePanel(bool toggle) => _manualTogglePanel.SetActive(toggle);

    void Start()
    {
        TogglePanel(true);
        LoadPage();
    }

    public void PreviousPage()
    {
        _pageSelected = (_pageSelected - 1) % _manualPages.Count;
        LoadPage();
    }

    public void NextPage()
    {
        _pageSelected = (_pageSelected + 1) % _manualPages.Count;
        LoadPage();
    }

    private void LoadPage()
    {
        for (int i = 0; i < _manualPages.Count; i++)
        {
            _manualPages[i].SetActive(i == _pageSelected);
        }

        RefreshPageButtons();
    }

    private void RefreshPageButtons()
    {
        _previousPageButton.SetActive(_pageSelected > 0);
        _nextPageButton.SetActive(_pageSelected < _manualPages.Count - 1);
    }
}
