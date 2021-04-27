using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ReceiverUDP : MonoBehaviour
{
    private UdpClient receivingUdpClient;
    int localport;
    string message = null;
    bool isalive = true;

    public int Localport
    {
        get { return localport; }
        set { localport = value; }
    }

    public string Message
    {
        get { return message; }

    }
    public bool isAlive
    {
        get { return isalive; }
        set { isalive = value; }
    }

    public void StartReceive()
    {

        // ������� UdpClient ��� ������ �������� ������
        receivingUdpClient = new UdpClient(localport);

        IPEndPoint RemoteIpEndPoint = null;
        isAlive = true;



        try
        {
            while (isAlive)
            {
                // �������� �����������
                byte[] receiveBytes = receivingUdpClient.Receive(
                   ref RemoteIpEndPoint);

                // ����������� � ���������� ������
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string dataget = returnData.ToString();

                message = dataget;


            }
        }
        catch (System.Exception ex)
        {

        }


    }

    public void Stopreceive()
    {
        isalive = false;
        receivingUdpClient.Close();
    }
}
