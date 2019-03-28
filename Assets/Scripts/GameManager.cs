using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Text coinUI;
	public Text scoreUI;


	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		
	}

	void Update()
	{
		RefreshCoinUInum ();
		RefreshScoreUInum ();
	}
	/// <summary>
	/// 游戏结束
	/// </summary>
	public void GameOver()
	{
		Invoke ("Restart", 1);
	}

	/// <summary>
	/// 重新开始
	/// </summary>
	public void Restart()
	{
		SceneManager.LoadScene ("Game");
	}

	/// <summary>
	/// 增加金币(作弊用)
	/// </summary>
	public void AddCoin(int num)
	{
		int currentCoin = 0;
		if (PlayerPrefs.HasKey ("RewordCoin")) {
			currentCoin = PlayerPrefs.GetInt ("RewordCoin");
			PlayerPrefs.SetInt ("RewordCoin", currentCoin + num);
			RefreshCoinUInum ();
		}
	}

	/// <summary>
	/// 获得游戏中收集的金币
	/// </summary>
	public int GetRewordCoin()
	{
		if (PlayerPrefs.HasKey ("RewordCoin")) {
			return PlayerPrefs.GetInt ("RewordCoin");
		}
		return 0;
	}

	/// <summary>
	/// 设置金币
	/// </summary>
	public void SetCoin(int num)
	{
		
	}

	/// <summary>
	/// 获得分数
	/// </summary>
	/// <returns>The score.</returns>
	public int GetScore()
	{
		if (PlayerPrefs.HasKey ("GamingScore")) {
            return Mathf.Abs(PlayerPrefs.GetInt("GamingScore"));
		}
		return 0;
	}

	/// <summary>
	/// 设置分数
	/// </summary>
	/// <param name="num">Number.</param>
	public void SetScore(int num)
	{
		
	}

	/// <summary>
	/// 刷新金币的UI显示
	/// </summary>
	public void RefreshCoinUInum()
	{
		coinUI.text = GetRewordCoin ().ToString ();
	}

	/// <summary>
	/// 刷新分数的UI显示
	/// </summary>
	public void RefreshScoreUInum()
	{
		scoreUI.text = GetScore ().ToString ();
	}
}
