using EasyFileTransfer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyFileTransfer
{
    public class FileTransfer
    {
        #region Constants
        
        const int _portSend = 2346;
        #endregion

        #region fields
        Thread _listenThread;
        public Label InfoLabel;
        int _flag = 0;
        string _receivedPath;
        public delegate void ReceiveDelegate();
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        #endregion

        public FileTransfer()
        {
            
        }

        #region Send File
        public void Send(string FilePath)
        {
            string _fName = Path.GetFileName(FilePath);
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] fileName = Encoding.UTF8.GetBytes(_fName); //file name
            byte[] fileData = File.ReadAllBytes(FilePath); //file
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); //lenght of file name

            byte[] m_clientData = new byte[4 + fileName.Length + fileData.Length];

            fileNameLen.CopyTo(m_clientData, 0);
            fileName.CopyTo(m_clientData, 4);
            fileData.CopyTo(m_clientData, 4 + fileName.Length);

            clientSock.Connect(Helper.GetCurrentEmployeeIpAddress() , _portSend); //target machine's ip address and the port number
            clientSock.Send(m_clientData);
            clientSock.Close();
        }
        #endregion

        public void Stop()
        {
            _listenThread.Abort();
        }
    }

    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;

        public const int BufferSize = 1024 * 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
    }
}
