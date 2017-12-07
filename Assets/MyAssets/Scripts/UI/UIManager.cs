using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }
    public Dictionary<PageType, DefaultPanel> PageDict = new Dictionary<PageType, DefaultPanel>();
    public PageType startPage;

    public DefaultPanel AdjustView;

    #region Monobehaviour Methods
    void Awake()
    {
        Instance = this;
        PageDict = GetComponentsInChildren<DefaultPanel>(true).ToDictionary(k => k.PanelType, v => v);

        PageDict.Add(PageType.AdjustView, AdjustView);
    }

    void Start()
    {
        PageDict.Where(p => p.Key == startPage).Select(p => p.Value).ToList().ForEach(p => p.gameObject.SetActive(true));
    }

    void OnEnable()
    {

    }
    #endregion

    public void Navigate(PageType type)
    {
        StartCoroutine(_Navigate(type));
    }

    IEnumerator _Navigate(PageType type)
    {
        var activePages = PageDict.Values.Where(p => p.gameObject.activeInHierarchy).ToList();
        if (activePages.Count != 0)
        {
            if (activePages.Count > 1)
            {
                for (int i = 1; i < activePages.Count; i++)
                    StartCoroutine(activePages[i].HideUI());
            }
            yield return activePages[0].HideUI();
            activePages.ForEach(p => p.gameObject.SetActive(false));
        }

        PageDict[type].gameObject.SetActive(true);

        yield return PageDict[type].ShowUI();
        yield break;
    }
}