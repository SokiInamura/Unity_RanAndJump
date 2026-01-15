using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject player;    //プレイヤーを格納するための変数
    public GameObject text;    　//テキストを格納するための変数
    public bool isGoal = false;    //Goalしたかどうか判定する
    private GameObject timeObject;
    TimeManager timeManager;

    void Update()
    {
        //Goalした後で画面をクリックされたとき
        if (isGoal && Input.GetMouseButton(0))
        {
            Restart();
        }
    }

    //当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        timeObject = GameObject.Find("TimeManager");
        timeManager = timeObject.GetComponent<TimeManager>();

        //当たってきたオブジェクトの名前がプレイヤーの名前と同じとき
        if (other.name == player.name && timeManager.isGameOver == false)
        {
            //テキストの内容を変更する
            text.GetComponent<Text>().text = "ゴール！";
            text.SetActive(true);            //テキストをオンにして非表示→表示にする

            Scene loadScene = SceneManager.GetActiveScene();        // 現在のScene名を取得する

            switch (loadScene.name)
            {
                case "01_Nakazawa":
                    SceneManager.LoadScene("02_Inamura");        // Sceneの読み直し
                    text.SetActive(false);

                    break;

                case "02_Inamura":
                    SceneManager.LoadScene("03_Sudou");        // Sceneの読み直し
                    text.SetActive(false);

                    break;

                case "03_Sudou":
                    SceneManager.LoadScene("04_Inoue");        // Sceneの読み直し
                    text.SetActive(false);

                    break;

                case "04_Inoue":
                    SceneManager.LoadScene("05_Onodera");        // Sceneの読み直し
                    text.SetActive(false);

                    break;

                case "05_Onodera":
                    SceneManager.LoadScene("06_Uemura");        // Sceneの読み直し
                    text.SetActive(false);

                    break;

                case "06_Uemura":
                    isGoal = true;            //Goal判定をTrueにする

                    break;
            }
        }
    }

    //シーンを再読み込みする
    private void Restart()
    {
        SceneManager.LoadScene("01_Nakazawa");        // Sceneの読み直し
    }
}