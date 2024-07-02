using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : GameMonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }

    [SerializeField] protected List<Transform> levels;
    [SerializeField] protected int currentLevel = 0;

    protected override void Awake()
    {
        if (LevelManager.instance != null) Debug.LogError("Only 1 LevelManager allow to exist");
        LevelManager.instance = this;
    }
    
    protected override void Start()
    {
        ShowLevel(currentLevel);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevels();

    }

    protected virtual void LoadLevels()
    {
        if (this.levels.Count > 0) return;

        foreach (Transform level in transform)
        {
            this.levels.Add(level);
        }
        Debug.LogWarning(transform.name + ": LoadLevels", gameObject);
    }

    public void ShowLevel(int levelIndex)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].gameObject.SetActive(i == levelIndex); // Chỉ hiển thị Panel của level được chọn
        }
        currentLevel = levelIndex;
    }

    public void NextLevel()
    {
        if (currentLevel < levels.Count - 1)
        {
            GameManager.Instance.IsScore = 0;
            ShowLevel(currentLevel + 1);
        }
        else
        {
            Debug.Log("Đã hết level!");
        }
    }

    public void PreviousLevel()
    {
        if (currentLevel > 0)
        {
            ShowLevel(currentLevel - 1);
        }
        else
        {
            Debug.Log("Đây là level đầu tiên!");
        }
    }
}
