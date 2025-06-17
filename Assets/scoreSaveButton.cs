using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSaveButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField nameInputField;
    private GameObject player;
    private Status playerstatus;
    private float score = 0f;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        playerstatus = player.GetComponent<Status>();
        score = playerstatus.score;
    }

    public void SaveScore(string name, int score)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogWarning("Name input field is empty.");
            return;
        }

        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    public void OnClick()
    {
        SaveScore(nameInputField.text, (int)score);
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
