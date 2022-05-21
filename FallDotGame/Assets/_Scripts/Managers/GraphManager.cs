using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GraphManager : Singleton<GraphManager> {

    [SerializeField] 
    private GameObject bar;
    [SerializeField] 
    private GameObject value;
    [SerializeField]
    private RectTransform graphContainer;

    public void LoadGraph() {
        List<int> scoreList = new List<int>() { 5, 98, 56, 45, 30, 22, 150, 120, 100, 160};

        Dictionary<int, int> scoreFreq = CalculateScoreFrequence(scoreList, 8);
        ShowGraph(new List<int>(scoreFreq.Values), 160, scoreList.Average(), scoreList.Max());
    }

    private Dictionary<int, int> CalculateScoreFrequence(List<int> scoreList, int nbPlage = 5) {
        int maxScore = Mathf.Max(scoreList.ToArray());
        float plageSize = maxScore / nbPlage;

        Dictionary<int, int> scoreFreq = new Dictionary<int, int>();
        for (int i=0; i<nbPlage; i++) {
            scoreFreq.Add(Mathf.RoundToInt(i), 0);
        }
        foreach (int score in scoreList) {
            int index = Mathf.FloorToInt(score / plageSize);
            scoreFreq.TryGetValue(index, out var currentCount);
            scoreFreq[index] = currentCount + 1;
        }

        return scoreFreq;
    }

    private void ShowGraph(List<int> valueList, int lastScore, double avgScore, int maxScore) {
        float graphHeight = graphContainer.rect.height;
        float graphWidth = graphContainer.rect.width;
        float yMaximum = Mathf.Max(valueList.ToArray()) * 1.3f;
        float xSize = graphWidth/(valueList.Count);
        float xScale = graphWidth/maxScore;

        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize/2 + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            CreateBar(new Vector2(xPosition, yPosition), xSize * 0.95f);
        }
        CreateValueBar(lastScore*xScale, "Last score");
        CreateValueBar((float)avgScore*xScale, "Your average");
    }

    private GameObject CreateBar(Vector2 anchoredPosition, float barWitdh) {
        GameObject gameObject = Instantiate(bar);
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, 0);
        rectTransform.sizeDelta = new Vector2(barWitdh, anchoredPosition.y);
        return gameObject;
    }

    private GameObject CreateValueBar(float position, string name) {
        GameObject gameObject = Instantiate(value);
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(position, 0);
        Text txt = gameObject.GetComponentInChildren<Text>();
        txt.text = name;
        return gameObject;
    }

}
