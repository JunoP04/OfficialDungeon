using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class CountDownScript : MonoBehaviour
    {

        public float timeStart = 1200;
        public Text textBox;
        float timeLeft = 1200.0f;
        private bool gameEnded = false;
        public GameManager mnger;


        void Start()
        {
            textBox.text = timeStart.ToString();
            GameManager mnger = FindObjectOfType<GameManager>();
        }

        void FixedUpdate()
        {
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeLeft).ToString();
            if (timeLeft > 0)
            {
                gameEnded = false;
            }
            if (timeLeft > 0 && gameEnded == false)
            {
                timeLeft -= UnityEngine.Time.deltaTime;
                {

                }
            }
            else//Endgmae funtion when time runs out
            {
                Debug.Log(gameEnded);
                gameEnded = true;
            }
        }
    }
