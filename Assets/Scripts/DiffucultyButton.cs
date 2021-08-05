using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucultyButton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);//butonlardan  birine onclick yaptýðým zaman SetDiffuclty metodunu çaðýrýyor.

        
    }

    void SetDifficulty()
	{
        gameManager.StartGame(difficulty);
        
	}
}
