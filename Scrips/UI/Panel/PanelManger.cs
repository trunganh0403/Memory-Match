using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManger : GameMonoBehaviour
{

    private static PanelManger instance;
    public static PanelManger Instance { get => instance; }

    [SerializeField] protected List<Transform> panels;


    protected override void Awake()
    {
        if (PanelManger.instance != null) Debug.LogError("Only 1 PanelManger allow to exist");
        PanelManger.instance = this;
    }

    //protected override void Start()
    //{
    //    base.Start();
    //    IsAnyPanelActive();
    //}

    private void Update()
    {
        IsAnyPanelActive();
    }
    public bool IsAnyPanelActive()
    {
        foreach (var panel in panels)
        {
            if (panel.gameObject.activeSelf == true)
            {
                //Debug.Log("true");
                return true;
            }
        }
        //Debug.Log("flse");
        return false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPanels();
    }

    protected virtual void LoadListPanels()
    {
        if (this.panels.Count > 0) return;

        foreach (Transform panel in transform)
        {
            this.panels.Add(panel);
        }
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }
}
