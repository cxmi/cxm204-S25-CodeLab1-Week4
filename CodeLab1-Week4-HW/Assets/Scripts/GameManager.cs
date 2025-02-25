using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //reference the timer
    public Timer timer;
    
    private int score = 0;

    public int Score
    {
        get
        {  
            return score;
        }
        set
        { 
            score = value;
            //UpdateHighScores(score); // whenever i get a new score, compare to other scores and insert it
        }
    }

    [SerializeField] List<int> highScores;
    
    private const string fileName = "highScores.txt";
    private string filePath = "";
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // better than DontDestroyOnLoad(this) according to Matt
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
       timer = GetComponent<Timer>();
       filePath = Application.dataPath + "/Data/" + fileName;

       if (File.Exists(filePath))
       {
           string fileContents = File.ReadAllText(filePath); // read the file contents - the string we created from the for loop
           string[] lines = fileContents.Split('\n');

           foreach (var line in lines)
           {
               highScores.Add(int.Parse(line));
           }
           
           //fileContents = File.ReadLines(filePath); is another option
       }
       else // set high score to default values
       {
           for (int i = 0; i < 10; i++)
           {
               highScores.Add(10-i);
               //white space bug
           }
       }
       
    
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            int currentHS = highScores[i]; // getting each high school out of it

            if (score >= currentHS)
            {
                highScores.Insert(i, score);
                break; // break out of the loop
            }
        }

        if (highScores.Count > 10)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
        

        string fileContents = "";

        foreach (var scoreData in highScores)
        {
            fileContents += scoreData + "\n";
        }
        File.WriteAllText(filePath, fileContents);

    }
}
