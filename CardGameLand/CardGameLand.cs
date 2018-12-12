using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace CardGameLand
{
    public partial class CardGameLand : Form
    {
        public CreateRoom createroom;
        public Form Game;

        public TcpListener tcpListener;
        public TcpClient tcpClient;

        public NetworkStream ns;
        public BinaryWriter bw;
        public BinaryReader br;
        RoomInfo roomInformation;
        public Thread threadListener;

        public CardGameLand()
        {
            InitializeComponent();
        }

        private void CardGameLand_Load(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            for (int i = 0; i < host.AddressList.Length; i++)
            {

                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    labelmyIP.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        //게임 참가
        private void buttonjoin_Click(object sender, EventArgs e)
        {
            if (textBoxNickName.Text != "")
            {
                tcpClient = new TcpClient(textBoxjoinIP.Text, 4545);
                if (tcpClient.Connected)
                {
                    if(roomInformation == null)
                    {
                        roomInformation = new RoomInfo();
                    }
                    ns = tcpClient.GetStream();
                    bw = new BinaryWriter(ns);
                    br = new BinaryReader(ns);

                    bw.Write(textBoxNickName.Text);

                    while (true)
                    {
                        int command = br.ReadInt32();
                        if (command == Command.ReMakeNickName)
                        {
                            textBoxNickName.Text = Prompt.ShowDialog("닉네임을 다시 설정해주세요.", "닉네임 입력");
                            bw.Write(textBoxNickName.Text);
                        }
                        else
                        {
                            break;
                        }

                    }

                    //서버로 부터 받아오는 게임방 정보
                    roomInformation.Title = br.ReadString();
                    roomInformation.GameID = br.ReadInt32();
                    roomInformation.MaxPersonCount = br.ReadInt32();
                    OpenGame(false);
                }
                else
                {
                   // MessageBox.Show("서버접속 실패");
                }
            }
            else
            {
                MessageBox.Show("닉네임을 입력해주세요.");
            }
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            if (textBoxNickName.Text != "")
            {
                if (createroom == null)
                {
                    if(roomInformation == null)
                    {
                        roomInformation = new RoomInfo();
                    }
                    createroom = new CreateRoom(roomInformation);
                    createroom.Owner = this;
                    createroom.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("닉네임을 입력해주세요.");
            }
        }

        private void CardGameLand_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
            if(createroom != null)
            {
                createroom.Dispose();
            }
        }

        //게임열기
        public void OpenGame(bool Master)
        {
            if ( Game == null)
            {
                if (roomInformation.GameID == 0)
                {
                    Game = new OneCard(Master,textBoxNickName.Text, textBoxjoinIP.Text, roomInformation);
                    Game.Owner = this;
                    Game.ShowDialog();
                }
            }
        }
        
    }
}
