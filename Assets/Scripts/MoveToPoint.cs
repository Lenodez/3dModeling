using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Threading;

public class MoveToPoint : MonoBehaviour
{
    Rigidbody rigidbody;
    float horizontal;
    public float speed = 1f;
    public GameObject player;//здесь ми указываем персонажа как игровой Object;
    NetworkSend send = new NetworkSend();
    ReceiverUDP receiver = new ReceiverUDP();
    Thread receiveThread;
    IPAddress IP = IPAddress.Parse("127.0.0.1");
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.D))
        {          
        send.Send("D");
        }
        if (Input.GetKey(KeyCode.A))
        {          
          send.Send("A");
        }                  
    }

    private void FixedUpdate()
    {
        Vector3 position = rigidbody.position;
        position.x = position.x + speed * horizontal * Time.deltaTime*(-1);
        rigidbody.MovePosition(position);
    }
}