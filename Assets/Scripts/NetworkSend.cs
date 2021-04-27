using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class NetworkSend : MonoBehaviour
{
    int sendport;
    int remoteport;
    IPAddress remoteIPAddress;
    private UdpClient sender;
    public int Sendport
    {
        set { sendport = value; }
    }
    public int Remoteport
    {
        set { remoteport = value; }
    }

    public IPAddress IP
    {
        set { remoteIPAddress = value; }
    }


    public void Send(string datagram)
    {
        sender = new UdpClient(sendport);
        IPEndPoint endPoint = new IPEndPoint(remoteIPAddress, remoteport);
        try
        {
            // Преобразуем данные в массив байтов
            byte[] bytes = Encoding.UTF8.GetBytes(datagram);

            // Отправляем данные
            sender.Send(bytes, bytes.Length, endPoint);

        }

        finally
        {
            // Закрыть соединение
            sender.Close();
        }
    }
}
