
namespace DO_AN_CUOI_KY
{
    public class BSTNode
    {
        public Citizen Data;
        public BSTNode Left;
        public BSTNode Right;
        public int Height;

        public BSTNode(Citizen citizen)
        {
            Data = citizen;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}