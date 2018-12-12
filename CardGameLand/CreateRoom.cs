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
using System.Net;
using System.Net.Sockets;

namespace CardGameLand
{
    public partial class CreateRoom : Form
    {
        CardGameLand MainForm;
        RoomInfo roomInformation;

        public CreateRoom(RoomInfo roomInformation)
        {
            InitializeComponent();
            this.roomInformation = roomInformation;
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            MainForm = (CardGameLand)Owner;
        }

        //게임선택
        private void GamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeMaxpersons(comboBoxGameID.SelectedIndex);

        }

        //게임선택시에 인원수 설정
        private void makeMaxpersons(int gamenumber)
        {
            int min = 0;
            int max = 0;

            String strnum = "";
            if (gamenumber == 0)
            {
                min = 2;
                max = 6;
            }

            comboBoxPersons.Items.Clear();
            for (int i = min; i <= max; i++)
            {
                strnum = (i).ToString();
                comboBoxPersons.Items.Add(strnum);
            }
        }

        //비공개
        private void radioButtonprivate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.Enabled = true;
        }
        //공개
        private void radioButtonpublic_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.Enabled = false;
        }

        //방만들기 버튼
        private void buttoncreate_Click(object sender, EventArgs e)
        {
            roomInformation.Title = textBoxTitle.Text;
            roomInformation.Password = textBoxPassword.Text;
            roomInformation.GameID = comboBoxGameID.SelectedIndex;
            roomInformation.MaxPersonCount = Convert.ToInt32(comboBoxPersons.SelectedItem as String);

            if (textBoxTitle.Text == "")
            {
                MessageBox.Show("양식 모두 입력해주세요.");
                return;
            }
            if (radioButtonprivate.Checked && textBoxPassword.Text == "")
            {
                MessageBox.Show("양식 모두 입력해주세요.");
                return;
            }
            if (comboBoxGameID.SelectedIndex < 0)
            {
                MessageBox.Show("양식 모두 입력해주세요.");
                return;
            }
            if (comboBoxPersons.SelectedIndex < 0)
            {
                MessageBox.Show("양식 모두 입력해주세요.");
                return;
            }
            if (MainForm.tcpListener == null)
            {
                MainForm.tcpListener = new TcpListener(4545);
                MainForm.threadListener = new Thread(new ThreadStart(MainForm.tcpListener.Start));
                MainForm.threadListener.IsBackground = true;
                MainForm.threadListener.Start();
            }
            
            this.Close();
            this.Dispose();
            MainForm.OpenGame(true);

        }

        private void CreateRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            CardGameLand form = (CardGameLand)Owner;
            form.createroom = null;
        }

    }
}
