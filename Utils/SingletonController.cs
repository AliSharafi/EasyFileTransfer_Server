using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace EasyFileTransfer
{
    [Serializable]
    class SingletonController : MarshalByRefObject
    {
        private static TcpChannel m_TCPChannel = null;
        private static Mutex m_Mutex = null;

        public delegate void ReceiveDelegate(string[] args);

        static private ReceiveDelegate m_Receive = null;
        static public ReceiveDelegate Receiver
        {
            get
            {
                return m_Receive;
            }
            set
            {
                m_Receive = value;
            }
        }

        public static bool IamFirst(ReceiveDelegate r,int port)
        {
            if (IamFirst(port))
            {
                Receiver += r;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IamFirst(int Port)
        {
            string m_UniqueIdentifier;
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName(false).CodeBase;
            m_UniqueIdentifier = assemblyName.Replace("\\", "_");

            m_Mutex = new Mutex(false, m_UniqueIdentifier);

            if (m_Mutex.WaitOne(1, true))
            {
                //We locked it! We are the first instance!!!    
                CreateInstanceChannel(Port);
                return true;
            }
            else
            {
                //Not the first instance!!!
                m_Mutex.Close();
                m_Mutex = null;
                return false;
            }
        }

        private static void CreateInstanceChannel(int Port)
        {
            m_TCPChannel = new TcpChannel(Port);
            ChannelServices.RegisterChannel(m_TCPChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                Type.GetType("EasyFileTransfer.SingletonController"),
                "SingletonController",
                WellKnownObjectMode.SingleCall);
        }

        public static void Cleanup()
        {
            if (m_Mutex != null)
            {
                m_Mutex.Close();
            }

            if (m_TCPChannel != null)
            {
                m_TCPChannel.StopListening(null);
            }

            m_Mutex = null;
            m_TCPChannel = null;
        }

        public static void Send(string[] s,int Port)
        {
            SingletonController ctrl;
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);
            try
            {
                ctrl = (SingletonController)Activator.GetObject(typeof(SingletonController), string.Format("tcp://localhost:{0}/SingletonController",Port.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                throw;
            }
            ctrl.Receive(s);
        }

        public void Receive(string[] s)
        {
            if (m_Receive != null)
            {
                m_Receive(s);
            }
        }
    }
}
