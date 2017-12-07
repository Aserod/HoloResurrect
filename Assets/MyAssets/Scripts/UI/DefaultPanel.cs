using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DefaultPanel : MonoBehaviour
{
    public float animationTime = .3f;
    public float stepFrac = .1f;
    public float offsetX = 50f;
    public PageType PanelType;

    protected List<Transform> _children = new List<Transform>();
    protected Dictionary<Transform, int> _childrenDict = new Dictionary<Transform, int>();
    protected Dictionary<Transform, ChildTrack> _childrenTrack = new Dictionary<Transform, ChildTrack>();
    protected Dictionary<Transform, CanvasGroup> _canvasGroup = new Dictionary<Transform, CanvasGroup>();
    protected List<CanvasGroup> _canvasGroupList = new List<CanvasGroup>();

    #region MonoBehaviour Methods
    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {

    }

    protected virtual void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            _children.Add(child);
            _childrenDict.Add(child, i);
        }
        _childrenTrack = _children.ToDictionary(k => k, v => (new ChildTrack(v.localPosition, offsetX)));
        _canvasGroup = _children.ToDictionary(k => k, v => v.GetComponent<CanvasGroup>());
        _canvasGroupList = _canvasGroup.Values.ToList();
    }

    protected virtual void Start()
    {
        
    }
    #endregion

    #region UI Methods
    public virtual IEnumerator ShowUI()
    {
        _canvasGroupList.ForEach(p => p.interactable = false);

        var startTime = Time.time;
        var currentTime = Time.time;
        var perc = 0f;
        var lastChildNum = _childrenDict[_children.Last()];

        while (true)
        {
            perc = (Time.time - startTime) / animationTime;
            if ((perc - stepFrac * lastChildNum) >= 1)
            {
                break;
            }
            else
            {
                _children.ForEach(p =>
                {
                    var frac = Mathf.Max(0, perc - stepFrac * _childrenDict[p]);
                    _canvasGroup[p].alpha = frac * 1.2f;
                    p.localPosition = _childrenTrack[p].LerpPosition(frac);
                });
                yield return null;
            }
        }
        _canvasGroupList.ForEach(p => p.interactable = true);
        yield break;
    }

    public virtual IEnumerator HideUI()
    {
        _canvasGroupList.ForEach(p => p.interactable = false);
        var startTime = Time.time;
        var currentTime = Time.time;
        var perc = 0f;
        var lastChildNum = _childrenDict[_children.Last()];

        while (true)
        {
            perc = (Time.time - startTime) / animationTime;

            if ((perc - stepFrac * lastChildNum) >= 1)
            {
                break;
            }
            else
            {
                _children.ForEach(p =>
                {
                    var frac = 1 - Mathf.Max(0, perc - stepFrac * _childrenDict[p]);
                    _canvasGroup[p].alpha = frac * 1.2f;
                    p.localPosition = _childrenTrack[p].LerpPosition(frac);
                });
                yield return null;
            }
        }
        yield break;
    }
    #endregion
}