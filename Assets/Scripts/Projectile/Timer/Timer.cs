using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Image loading;

    public float seconds = 0;
    public float timerRemaining = 0;
    public bool isStart = false;

    float totalTimer = 0;

    TMP_Text timerTxt;

    void Start()
    {
        timerTxt = GetComponent<TMP_Text>();    
    }

    void Update()
    {
        TimerUpdating();    
    }

    public void TimerUpdating()
    {
        if (isStart)
        {
            if(seconds > 0)
            {
                seconds -= Time.deltaTime;
                FillLoading();
            }
            if(seconds <= 0)
            {
                isStart = false;
                ResetLoader();
            }
        }
        timerTxt.text = string.Format("{0:00}", seconds);
    }

    public void FillLoading()
    {
        timerRemaining -= Time.deltaTime;
        float fill = timerRemaining / totalTimer;
        loading.fillAmount = fill;
    }
    public void CalculateTimeRemaining()
    {
        if(seconds > 0)
        {
            timerRemaining += seconds;
        }
        totalTimer = timerRemaining;
    }
    public void StartTimer(float value)
    {
        seconds = value;

        CalculateTimeRemaining();
        isStart = true;
        ResetLoader();
    }
    public float ResetLoader()
    {
        return loading.fillAmount = 1;
    }
}
