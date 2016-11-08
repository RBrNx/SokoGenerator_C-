using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanSolver
{
    public class Hashtable
    {
        public Move[] data = new Move[Global.HASHSIZE];
        public int count;

        public void initializeHash()
        {
            count = 0;
            data.Initialize();
        }

        public void cleanHash()
        {
            for(int i = 0; i < Global.HASHSIZE; i++)
            {
                if (data[i] != null)
                {
                    Allocator.freeMove(data[i]);
                }
            }
        }

        public bool addToHashtable(Move move)
        {
            uint pos = (uint)move.magic;
            while(data[pos % Global.HASHSIZE] != null)
            {
                if(Move.compareMoves(move, data[pos % Global.HASHSIZE]))
                {
                    return false;
                }
                else
                {
                    pos++;
                }
            }
            data[pos % Global.HASHSIZE] = move;
            count++;
            return true;
        }
    }

    
}
