using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections;


namespace CardGameLand
{
    public partial class OneCard : Form
    {
        //클라이언트 최대 크기//
        int MAXWIDTH = 500;
        int MAXHEIGHT = 500;
        int distanceFromTop = 50;
        Dictionary<String, BinaryWriter> clients;

        bool Master;
        string NickName;
        string myIP;
        RoomInfo roomInformation;

        CardGameLand MainForm;

        TcpListener tcpListener;

        NetworkStream ns;

        BinaryWriter clientbw;
        BinaryReader clientbr;

        Thread clientReceiverThread;

        ServerReceiver serverReceiver;
        ClientReceiver clientReceiver;

        List<Thread> threadList;
        List<ServerReceiver> serverReceivers;
        Thread acceptThread;
        Thread timerThread;
        BufferedGraphicsContext context;
        BufferedGraphics graphics;

        Bitmap trumpCard;
        Bitmap[] playerImages;

        List<int> mycards;

        private int dumytop;

        Dictionary<String, PlayerInfo> players;
        string playerturn;
        string winplayer;
        ClientDeck deck;
        string onecardNickname;
        private bool _shouldStop;
        public OneCard(bool Master, string NickName, string myIP, RoomInfo roomInformation)
        {
            InitializeComponent();

            this.Master = Master;
            this.NickName = NickName;
            this.myIP = myIP;
            this.roomInformation = roomInformation;
            dumytop = 0;
            mycards = new List<int>();
            players = new Dictionary<String, PlayerInfo>();

            labelTitle.Text = roomInformation.Title;
            labelMaxPersonCount.Text = Convert.ToString(roomInformation.MaxPersonCount);
            threadList = new List<Thread>();
            serverReceivers = new List<ServerReceiver>();
            playerImages = new Bitmap[6];
            playerImages[0] = Properties.Resources.MAN1;
            playerImages[1] = Properties.Resources.MAN2;
            playerImages[2] = Properties.Resources.MAN3;
            playerImages[3] = Properties.Resources.MAN4;
            playerImages[4] = Properties.Resources.MAN5;
            playerImages[5] = Properties.Resources.MAN6;


            _shouldStop = false;
            deck = new ClientDeck();
            
        }

        private void OneCard_Load(object sender, EventArgs e)
        {
            context = BufferedGraphicsManager.Current; // 참조
            context.MaximumBuffer = new Size(MAXWIDTH, MAXHEIGHT); // 버퍼 크기 설정
            graphics = context.Allocate(CreateGraphics(), new Rectangle(0, distanceFromTop, MAXWIDTH, MAXHEIGHT)); // 버퍼 그래픽스 객체 생성 및 참조
            graphics.Graphics.Clear(Color.Gray); // 버퍼 지우기

            trumpCard = Properties.Resources.TrumpCard;

            MainForm = (CardGameLand)Owner;
            if (Master)
            {
                tcpListener = MainForm.tcpListener;
                clients = new Dictionary<string, BinaryWriter>();

                acceptThread = new Thread(new ThreadStart(AcceptClient));
                acceptThread.IsBackground = true;
                acceptThread.Start();

                MainForm.tcpClient = new TcpClient(myIP, 4545);

                if (MainForm.tcpClient.Connected)
                {
                    ns = MainForm.tcpClient.GetStream();
                    clientbw = new BinaryWriter(ns);
                    clientbr = new BinaryReader(ns);
                    clientbw.Write(NickName);
                    int dump0 = clientbr.ReadInt32();
                    string dump1 = clientbr.ReadString();
                    int dump2 = clientbr.ReadInt32();
                    int dump3 = clientbr.ReadInt32();
                }
                this.buttonStart.Enabled = true;
            }
            else
            {
                clientbw = MainForm.bw;
                clientbr = MainForm.br;

            }
            clientReceiver = new ClientReceiver(clientbr, clientbw, textBoxChattingList, labelCurrentPersonCount, this, mycards, players,NickName);
            clientReceiverThread = new Thread(new ThreadStart(clientReceiver.process));
            clientReceiverThread.IsBackground = true;
            clientReceiverThread.Start();

            buttonOneCard.Location = new Point(-100, 0);
        }

        private void AcceptClient()
        {
            while (!_shouldStop)
            {
                if (tcpListener.Pending())
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    if (tcpClient.Connected)
                    {
                        serverReceiver = new ServerReceiver(tcpClient, clients, textBoxChattingList, roomInformation, this);
                        Thread serverReceiverThread = new Thread(new ThreadStart(serverReceiver.process));
                        serverReceiverThread.IsBackground = true;
                        serverReceiverThread.Start();
                        threadList.Add(serverReceiverThread);
                    }
                }
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (textBoxChatting.Text == "")
            {
                return;
            }
            clientbw.Write(Command.SendMessage);
            clientbw.Write(NickName + "::" + textBoxChatting.Text);
            textBoxChatting.Clear();
        }


        //종료
        private void OneCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clientReceiverThread != null)
            {
                clientReceiverThread.Abort();
                clientReceiverThread = null;
            }
            if (clientReceiver != null)
            {
                clientReceiver = null;
            }
            if (clientbr != null)
            {
                clientbr.Close();
                clientbr = null;
            }
            if (clientbw != null)
            {
                clientbw.Close();
                clientbw = null;
            }
            if (ns != null)
            {
                ns.Close();
                ns = null;
            }
            if (MainForm.tcpClient != null)
            {
                MainForm.tcpClient.Close();
                MainForm.tcpClient = null;
            }
            if (MainForm.Game != null)
            {
                MainForm.Game.Dispose();
                MainForm.Game = null;
            }
            if (MainForm.createroom != null)
            {
                MainForm.createroom.Dispose();
                MainForm.createroom = null;
            }
            _shouldStop = true;

            this.Close();
            this.Dispose();
        }

        private void OneCard_Paint(object sender, PaintEventArgs e)
        {
            graphics.Graphics.Clear(Color.Gray);
            graphics.Graphics.DrawImage(trumpCard, 229, 169 + distanceFromTop, 42, 62);
            for (int i = 0; i < players.Count-1; i++)
            {
                graphics.Graphics.DrawImage(playerImages[i], i * 100, distanceFromTop, 100, 120);
            }
            int index = 0;
            SolidBrush brush = new SolidBrush(Color.Blue);
            Font font = new Font("Arial", 14);
            foreach (KeyValuePair<String, PlayerInfo> player in players)
            {
                if (player.Key == NickName)
                {
                    continue;
                }
                graphics.Graphics.DrawString(player.Value.NickName, font, brush, index * 100, distanceFromTop + 120);
                for (int j = 0; j < player.Value.HowManyCard; j++)
                {
                    if (j < 6)
                    {
                        graphics.Graphics.DrawImage(trumpCard, (index * 100) + (j * 13), distanceFromTop + 80, 12, 17);
                    }
                    else
                    {
                        graphics.Graphics.DrawImage(trumpCard, (index * 100) + ((j - 6) * 13), distanceFromTop + 100, 12, 17);
                    }

                }
                index++;
            }

            for (int i = 0; i < mycards.Count; i++)
            {
                if (i < 6)
                {
                    graphics.Graphics.DrawImage(deck.DeckList[(int)mycards[i]], i * 75 + 10, distanceFromTop + 300, 75, 100);
                }
                else
                {
                    graphics.Graphics.DrawImage(deck.DeckList[(int)mycards[i]], (i - 6) * 75 + 10, distanceFromTop + 400, 75, 100);
                }
            }
            if (dumytop != 0)
            {
                graphics.Graphics.DrawImage(deck.DeckList[dumytop], 180, 169 + distanceFromTop, 42, 62);
            }
            if (winplayer != null)
            {
                font = new Font("Arial", 30);
                graphics.Graphics.DrawString(winplayer + "님의 승리", font, brush, 100, distanceFromTop + 200);
            }
            brush.Dispose();
            font.Dispose();
            graphics.Render(e.Graphics);            
        }

        

        public void repaintPlayerSetting()
        {
            int index = 0;
            SolidBrush brush = new SolidBrush(Color.Blue);
            Font font = new Font("Arial", 16);
            foreach (KeyValuePair<String, PlayerInfo> player in players)
            {
                graphics.Graphics.DrawString(player.Value.NickName, font, brush, index * 100, distanceFromTop + 140);
            }
            brush.Dispose();
            font.Dispose();
            Invalidate();
        }

        public void repaintMyCardList()
        {
            for (int i = 0; i < mycards.Count; i++)
            {
                graphics.Graphics.DrawImage(deck.DeckList[(int)mycards[i]], i * 75 + 10, distanceFromTop + 300, 75, 100);
            }
            Invalidate();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (players.Count < 0)
            {
                MessageBox.Show("인원이 적어 시작할 수 없습니다.");
                return;
            }
            clientbw.Write(Command.FistDraw);
            buttonStart.Enabled = false;
            acceptThread.Suspend();
        }

        public void setDumytop(int value)
        {
            dumytop = value;
        }

        public void addPlayerInfo(String nickname, int playernum, int howmanycard)
        {
            players.Add(nickname, new PlayerInfo(nickname, playernum, howmanycard));
        }

        private void OneCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (playerturn != null)
            {
                if (playerturn.Equals(NickName))
                {
                    if (e.Y >= distanceFromTop + 300 && e.Y <= distanceFromTop + 300 + 200)
                    {
                        if (e.X >= 10 && e.X <= 765)
                        {

                            int x = e.X;
                            x = x - 10;
                            int k = x % 75;

                            x = x / 75;

                            if (k > 0)
                            {
                                x = x + 1;
                            }
                            if (e.Y >= distanceFromTop + 400)
                            {
                                x = x + 6;
                            }
                            if (mycards.Count < x) return;
                            clientbw.Write(Command.PutCard);
                            clientbw.Write((int)mycards[x - 1]);
                            clientbw.Write(NickName);
                        }
                    }
                    else if (e.Y >= distanceFromTop + 169 && e.Y <= distanceFromTop + 169 + 62 && e.X >= 229 && e.X <= 229 + 42)
                    {
                        clientbw.Write(Command.Draw);
                        clientbw.Write(NickName);
                    }
                }
            }
        }

        public void setTurn(string playerturn)
        {
            this.playerturn = playerturn;
            labelPlayerTurn.Text = playerturn;
        }

        public string getTurn()
        {
            return playerturn;
        }

        public void Die()
        {
            clientbw.Write(Command.Die);
            clientbw.Write(mycards.Count);
            for (int i = 0; i < mycards.Count; i++)
            {
                clientbw.Write(mycards[i]);
            }
            mycards.Clear();
        }

        public void setWinPlayer(String NickName)
        {
            this.winplayer = NickName;
        }

        public void EnableOneCardButton(string nickname)
        {
            onecardNickname = nickname;
            Random random = new Random();
            buttonOneCard.Enabled = true;
            Point buttonLocation = new Point(random.Next(0,MAXWIDTH-buttonOneCard.Size.Width),random.Next(distanceFromTop,distanceFromTop+MAXHEIGHT-buttonOneCard.Size.Height));
            buttonOneCard.Location = buttonLocation;
        }

        public void DisableOneCardButton()
        {
            buttonOneCard.Location = new Point(-100,0);
            buttonOneCard.Enabled = false;
            onecardNickname = null;
        }

        public void CloseGameRoom()
        {
            acceptThread.Suspend();
        }

        public void OpenGameRoom()
        {
            acceptThread.Resume();
        }

        public bool GetStateAcceptThread()
        {
            if (acceptThread.ThreadState == (ThreadState.SuspendRequested | ThreadState.Background))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetStateStartButton()
        {
            if (buttonStart.Enabled == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonOneCard_Click(object sender, EventArgs e)
        {
            if (onecardNickname != null)
            {
                if (onecardNickname.Equals(NickName))
                {
                    clientbw.Write(Command.SucessOneCard);
                }
                else
                {
                    clientbw.Write(Command.BlockOneCard);
                    clientbw.Write(onecardNickname);
                }
            }
            
        }
    }
}
