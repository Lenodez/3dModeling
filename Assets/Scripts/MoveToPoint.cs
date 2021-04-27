using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Threading;

public class MoveToPoint : MonoBehaviour
{

    public float speed = 1f;
    public GameObject player;//здесь ми указываем персонажа как игровой Object;
    NetworkSend send = new NetworkSend();
    ReceiverUDP receiver = new ReceiverUDP();
    Thread receiveThread;
    IPAddress IP = IPAddress.Parse("127.0.0.1");
    void Start()
    {
        player = (GameObject)this.gameObject; //тут присваиваем персонажа к игровому Object или как-то так.
        receiver.Localport = 3333;
        send.Sendport = 9999;
        send.Remoteport = 10000;
        send.IP = IP;
        init();
    }

    private void init()
    {
        receiveThread = new Thread(
            new ThreadStart(receiver.StartReceive));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
            send.Send("D");
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
            send.Send("A");
        }                                              //всё легко и просто, как борщ(всё как Вы и просили)
    }
}