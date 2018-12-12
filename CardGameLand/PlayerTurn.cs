using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CardGameLand
{
    class PlayerTurn
    {
        LinkedListNode<String> currentNode;
        LinkedList<String> playerList;

        public PlayerTurn()
        {
            playerList = new LinkedList<String>();

        }

        public void AddPlayer(String playerNickName)
        {
            playerList.AddLast(playerNickName);
            if (currentNode == null)
            {
                currentNode = playerList.First;
            }
        }

        public void RemovePlayer(String playerNickName)
        {
            playerList.Remove(playerNickName);
        }

        public String GetCurrentPlayerTurn()
        {
            String playerNickName = currentNode.Value;
            return playerNickName;
        }

        public void NextPlayerTurn()
        {
            if (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            else
            {
                currentNode = playerList.First;
            }
        }

        public void PreviousTurn()
        {
            if (currentNode.Previous != null)
            {
                currentNode = currentNode.Previous;
            }
            else
            {
                currentNode = playerList.Last;
            }
        }

        public String ChangeTurnCard(int cardnum)
        {
            if (cardnum == 10)
            {
                NextPlayerTurn();
                NextPlayerTurn();
            }
            else if (cardnum == 11)
            {
                
            }
            else if (cardnum == 12)
            {
                PreviousTurn();
            }
            return GetCurrentPlayerTurn();
        }
    }
}
