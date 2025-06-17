using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryList;

    // Start is called before the first frame update
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        // highscoreEntryList = new List<HighscoreEntry>()
        // {
        //     new HighscoreEntry { score = 1200, name = "AAA" },
        //     new HighscoreEntry { score = 5200, name = "BBB" },
        //     new HighscoreEntry { score = 6150, name = "CCC" },
        //     new HighscoreEntry { score = 2300, name = "DDD" },
        //     new HighscoreEntry { score = 7250, name = "EEE" }
        //  };

        //AddHighscoreEntry(10000, "CMK");

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscoreEntryList = highscores.highscoreEntryList;
        highscoreEntryList = highscoreEntryList.Take(8).ToList(); 

        
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    // Swap the entries
                    HighscoreEntry temp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = temp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }


        // Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
        // string json = JsonUtility.ToJson(highscores);
        // PlayerPrefs.SetString("highscoreTable", json);
        // PlayerPrefs.Save();
        // Debug.Log(PlayerPrefs.GetString("highscoreTable"));
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 25f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0f, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
            default: rankString = rank + "th"; break;
        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        transformList.Add(entryTransform);
    }


    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
