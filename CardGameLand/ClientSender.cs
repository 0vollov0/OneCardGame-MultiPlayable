using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace CardGameLand
{
    class ClientSender
    {
        BinaryWriter bw;
        string nickname;

        public ClientSender(BinaryWriter bw,string nickname)
        {
            this.bw = bw;
            this.nickname = nickname;
        }

        public void process()
        {
            bw.Write(nickname);
            while (bw != null)
            {
                
            }
        }
    }
}
