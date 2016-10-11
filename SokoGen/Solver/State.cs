using System.Collections.Generic;

namespace SokoSolver
{
    class State
    {
        public List<Coordinate> boxes;
        public Coordinate player;

        public State(List<Coordinate> boxes, Coordinate player)
        {
            this.boxes = new List<Coordinate>(boxes);
            this.player = player;
        }

        public override int GetHashCode()
        {
            int result = 17;
            foreach (Coordinate b in boxes)
            {
                result = 37 * result + b.GetHashCode();
            }
            result = 37 * result + player.GetHashCode();
            return result;
        }

        public override bool Equals(object obj)
        {
            if(obj == null) { return false; }
            if(obj == this) { return true; }
            if(this.GetType() != obj.GetType()) { return false; }

            State s = (State)obj;
            if (this.GetHashCode() == s.GetHashCode()) return true;
            if ((this.boxes == s.boxes) && this.player == s.player) return true;

            return false;
        }
    }
}
