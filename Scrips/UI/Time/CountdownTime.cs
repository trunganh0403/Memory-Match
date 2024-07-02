using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CountdownTime : GameMonoBehaviour
{
    private static CountdownTime instance;
    public static CountdownTime Instance { get => instance; }

    [SerializeField] protected float totalTime = 100; // Tổng thời gian countdown
    [SerializeField] protected float remainingTime;
    [SerializeField] private bool isCountdownFinished = false;
    [SerializeField] protected Text countdownText;
    [SerializeField] protected Image fillImage; // Hình ảnh để giảm Fill Amount

    public bool IsCountdownFinished { get => isCountdownFinished; set => isCountdownFinished=value; }


    protected override void Awake()
    {
        if (CountdownTime.instance != null) Debug.LogError("Only 1 CountdownTime allow to exist");
        CountdownTime.instance = this;
    }

    protected override void Start()
    {
        this.RestTime();
    }

    void Update()
    {
        UpdateRemainingTime();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFillImage();
        this.LoadCountdownText();
    }

    protected virtual void LoadFillImage()
    {
        if (fillImage != null) return;
        fillImage = transform.GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFillImage", gameObject);
    }

    protected virtual void LoadCountdownText()
    {
        if (countdownText != null) return;
        countdownText = transform.parent.Find("CountdownText").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadCountdownText", gameObject);
    }

    protected virtual void UpdateRemainingTime()
    {
        if (IsCountdownFinished) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            OnCountdownEnd();
           // IsCountdownFinished = true; // Đánh dấu countdown đã kết thúc
        }

        UpdateUI();

    }

    protected virtual void OnCountdownEnd()
    {
        DialogLossPn.Instance.Open();
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Cập nhật Fill Amount của Image
        fillImage.fillAmount = remainingTime / totalTime;
    }

    public virtual void RestTime()
    {
        remainingTime = totalTime;
        IsCountdownFinished = false;
    }    
}
