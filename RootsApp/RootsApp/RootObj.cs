

namespace RootsApp
{
    public class RootObj //: IRoot
    {
        public double root;
        public int error;

        public double Root { get => root; set => root = value; }
        public int Error { get => error; set => error = value; }
        

        public override string ToString()
        {
            if (error == (int)Messages.ROOT_ERRORS.NONE)
            {
                return root.ToString();
            }
            else
            {
                return "Root Not Found: Error " + error;
            }
        }

        public RootObj()
        {
            error = (int)Messages.ROOT_ERRORS.NONE;
        }

        public RootObj(double r)
        {
            root = r;
            error = (int)Messages.ROOT_ERRORS.NONE;
        }
    }
}
