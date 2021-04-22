using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{

    public float speed = 1f;
    public GameObject player;//здесь ми указываем персонажа как игровой Object;

    void Start()
    {
        player = (GameObject)this.gameObject; //тут присваиваем персонажа к игровому Object или как-то так.
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;//персонаж плавно двигается на W,S,D,A;
        }                                              //всё легко и просто, как борщ(всё как Вы и просили)
    }
}