﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

    public Transform loadingSlider;
    public Transform gameName;
    public Transform gamePlay;

    public int curProgress;
    public int maxProgress;

    private Vector3 gameNamePosition;
    private Vector3 gamePlayPosition;

    private int stage;
    private AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start() {
        gameNamePosition = gameName.position;
        gameName.position = new Vector3(gameNamePosition.x, gameNamePosition.y + 1500, gameNamePosition.z);

        gamePlayPosition = gamePlay.position;
        gamePlay.position = new Vector3(gamePlayPosition.x, gamePlayPosition.y - 1500, gamePlayPosition.z);

        curProgress = 0;
        maxProgress = 0;
        stage = 0;

        StartCoroutine(LoadAsync());
    }

    // Update is called once per frame
    void Update() {
        switch (stage) {
            case 0:
                LoadingUpdate();
                break;
            case 1:
                LoadedUpdate();
                break;
            default:
                break;
        }
    }

    public void OnGamePlayClick() {
        asyncOperation.allowSceneActivation = true;
    }

    private void LoadingUpdate() {
        if (asyncOperation != null) {
            var progress = Mathf.FloorToInt(asyncOperation.progress * 100);
            maxProgress = progress < 90 ? progress : 100;
        }

        if (curProgress < maxProgress) {
            curProgress += 1;
        }

        loadingSlider.GetComponent<Slider>().value = curProgress * 0.01f;

        if (curProgress == maxProgress) {
            TriggerLoaded();
            stage = 1;
        }
    }

    private void LoadedUpdate() {

    }

    private void TriggerLoaded() {
        loadingSlider.gameObject.SetActive(false);
        gameName.DOMoveY(gameNamePosition.y, 2).SetEase(Ease.InOutBack);
        gamePlay.DOMoveY(gamePlayPosition.y, 2).SetEase(Ease.InOutBack);

        var gameNameString = StringProvider.Instance.GetString("gameName");
        var gameNamePath = string.Format("images/{0}", gameNameString);
        gameName.GetComponent<Image>().sprite = Resources.Load<Sprite>(gameNamePath);

        var playString = StringProvider.Instance.GetString("play");
        gamePlay.GetComponentInChildren<Text>().text = playString;
    }

    private IEnumerator LoadAsync() {
        yield return LoadInfo();
        yield return LoadUI();
    }

    private IEnumerator LoadInfo() {
        StringProvider.Instance.LoadAll();
        maxProgress = 50;
        yield return null;
    }

    private IEnumerator LoadUI() {
        asyncOperation = SceneManager.LoadSceneAsync("play");
        asyncOperation.allowSceneActivation = false;
        yield return null;
    }
}
