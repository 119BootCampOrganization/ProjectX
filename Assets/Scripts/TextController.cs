using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class TextController : MonoBehaviour
{
    #region Singleton
    public static TextController Instance { get; private set; }
	private void Awake()
	{

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}
    #endregion

    public GameObject storyText;
	public GameObject heroStoryText;

	public float delay = 0.1f;
	private float mainSceneDelay = 2f;

	private string currentText = "";
	private string storyIntro= "Everyone dreams.  But every dream is different.  Every dream is a product of the dreamer's imagination. It powers the dreamworld while the dreamworld also supporting it. Dreamworld consists of multiple dreams. One might even call it a patchwork dream.  Here, in this patchwork of dreams, we are going to delve into five dreamers worlds connected by the dream world.  ";
	private string ilkayIntro = "Sometimes dreams help us overcome our problems. By opening new doors in our minds, they cause a newfound clarity.We find ilkay at that threshold, he is just about to pass.But first, he must defeat his inner demons.";
	private string samIntro = "Sam is someone trying to understand the world around him. He loves thinking about the concept of time and immortality.He always wanted to experience the temporal difference between the Earth and the space, which led him to become an astronaut.Now, his next mission is to gather the space stones which might unlock the secrets to immortality. But he must hurry, otherwise, it will be too late for his loved ones on Earth.";
	private string morikoIntro = "Moriko always preferred the company of animals over humans.She made up her mind, that from now on, she will live amongst the animals.But in order to succeed, she must defeat the shadow creatures on her way while also avoiding the poisonous thorns.";
	private string foresterIntro = "What can a simple forester do? He is no hero. He can't save anyone. He can only convert one life to another. One life, to a tree.But when someone needs help, you can't just back away.The old man asked for his help, and the Forester promised to do what he can.";
	private string gIntro = "Not every dream causes a newfound clarity or a new power. Sometimes, dreams are adventures we must complete. They are a chance for us to become someone else, just for a short while. In his adventure, G must reach the end without touching the red walls of lava.";


	private string finishJourney =
		"As life goes on, so does the dream. We wake up and dreams eventually disappear. Until we dream again. So long.";
	

	public Button[] Heroes;


	void Start()
	{
        if (SceneManager.GetActiveScene().buildIndex==0 )
        {
			StartCoroutine(FadeStoryIntro());
			SoundManager.Instance.playSound("dream");
		}
		
	}

	IEnumerator FadeStoryIntro()
	{
		for (int i = 0; i < storyIntro.Length; i++)
		{
			currentText = storyIntro.Substring(0, i);
			storyText.GetComponent<Text>().text = currentText;
			FreeCurrentText();
			yield return new WaitForSecondsRealtime(delay);
		}

		yield return new WaitForSecondsRealtime(mainSceneDelay);
		LoadMainMenu();

	}

    private void LoadMainMenu()
    {
		SceneManager.LoadScene(1);
	}

    private void FreeCurrentText()
    {
		currentText = "";
	}

	private void HideHeroes()
    {
		for(int i = 0; i < Heroes.Length; i++)
        {
            Heroes[i].gameObject.SetActive(false);
        }
    }

	public void IlkayHero() {
		HideHeroes();
		StartCoroutine(ShowHeroIntro(ilkayIntro,2));
	}

	public void SamHero()
	{
		HideHeroes();
		StartCoroutine(ShowHeroIntro(samIntro,3));
	}
	public void MorikoHero()
	{
		HideHeroes();
		StartCoroutine(ShowHeroIntro(morikoIntro,4));
	}
	public void ForesterHero()
	{
		HideHeroes();
		StartCoroutine(ShowHeroIntro(foresterIntro,5));
	}
	public void GHero()
	{
		HideHeroes();
		StartCoroutine(ShowHeroIntro(gIntro,6));
	}
	IEnumerator ShowHeroIntro(string s, int j)
	{
		for (int i = 0; i < s.Length; i++)
		{
			currentText = s.Substring(0, i);
			heroStoryText.GetComponent<Text>().text = currentText;
			FreeCurrentText();
			yield return new WaitForSecondsRealtime(delay);
		}
		yield return new WaitForSecondsRealtime(3f);

		SoundManager.Instance.muteAll();
		
		switch (j)
        {
			case 2:
				SceneManager.LoadScene(2);
				break;
			case 3:
				SceneManager.LoadScene(3);
				break;
			case 4:
				SceneManager.LoadScene(4);
				break;
			case 5:
				SceneManager.LoadScene(5);
				break;
			case 6:
				SceneManager.LoadScene(6);
				break;
			case 7:
				Application.Quit();
				break;
		}
	}


	public void FinishJourney()
	{
		HideHeroes();
		StartCoroutine(ShowHeroIntro(finishJourney,7));
	}
	
	
	
	
	
}
