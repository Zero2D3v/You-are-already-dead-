using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    public EndingManager endingManager;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        //get containers and template
        entryContainer = transform.Find("High Score Entry Container");
        entryTemplate = entryContainer.Find("High Score Entry Template");
        //disable template
        entryTemplate.gameObject.SetActive(false);
        //load any store highscores from previously written json file
        LoadHighscores();
        //convenient to call in testing so here to comment/uncomment as necessary
        //ResetHighscoreTable();
    }

    private void Start()
    {
        //if new highscore add entry and tell me, otherwise add entry and tell me normal score
        if (endingManager.newHighscore)
        {
            Debug.Log("newHighscore " + endingManager.newHighScoreValue);
            AddHighscoreEntry(endingManager.newHighScoreValue, "AAA");
        }
        else if (!endingManager.newHighscore)
        {
            Debug.Log("score " + endingManager.newHighScoreValue);
            AddHighscoreEntry(endingManager.newHighScoreValue, "AAA");
        }
    }
    //load scores from json or if first time then create new list
    private void LoadHighscores()
    {
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores;

        if (string.IsNullOrEmpty(jsonString))
        {
            // If no highscores found, create new instance
            highscores = new Highscores();
        }
        else
        {
            // Deserialize the existing highscores
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    //generate list and order them and rank them with the constraints of 23 height
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 23f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }
    //add entry if either less than 10 entries or score higher then 10th value and replace and reorder accordingly
    public void AddHighscoreEntry(int score, string name)
    {
        // Create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores;

        if (string.IsNullOrEmpty(jsonString))
        {
            // If no highscores found, create new instance
            highscores = new Highscores();
        }
        else
        {
            // Deserialize the existing highscores
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        bool scoreAdded = false;

        // Check if the score is higher than the lowest value on the table
        if (highscores.highscoreEntryList.Count < 10 || score > highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1].score)
        {
            // Add new entry to highscores
            highscores.highscoreEntryList.Add(highscoreEntry);

            // Sort the highscores by score
            highscores.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

            // Keep only the top 10 highscores
            if (highscores.highscoreEntryList.Count > 10)
            {
                highscores.highscoreEntryList.RemoveRange(10, highscores.highscoreEntryList.Count - 10);
            }

            scoreAdded = true;
        }

        // Save updated highscores if a score was added
        if (scoreAdded)
        {
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highScoreTable", json);
            PlayerPrefs.Save();
        }

        // Update the UI with the new highscore entries only if a score was added
        if (scoreAdded)
        {
            ClearHighscoreEntryTransforms();

            foreach (HighscoreEntry entry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(entry, entryContainer, highscoreEntryTransformList);
            }
        }
    }

    private void ClearHighscoreEntryTransforms()
    {
        foreach (Transform entryTransform in highscoreEntryTransformList)
        {
            Destroy(entryTransform.gameObject);
        }
        highscoreEntryTransformList.Clear();
    }

    public void ResetHighscoreTable()
    {
        // Clear the saved highscores
        PlayerPrefs.DeleteKey("highScoreTable");
        PlayerPrefs.Save();

        // Clear the UI entries
        ClearHighscoreEntryTransforms();
    }

    [System.Serializable]
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
