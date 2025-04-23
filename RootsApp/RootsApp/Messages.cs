namespace RootsApp
{
    
    public class Messages
    {

        public enum ROOT_ERRORS { NONE, SAME_SIGN, DIVISION_BY_ZERO, RUNAWAY, CYCLE };
        public static void DivisionByZeroError(RootObj r)
        {
            
            r.root = double.NaN;
            r.error = (int)ROOT_ERRORS.DIVISION_BY_ZERO;
            
        }

        public static void SameSign(RootObj r)
        {

            r.root = double.NaN;
            r.error = (int)ROOT_ERRORS.SAME_SIGN;

        }

        public static void RunawayError(RootObj r)
        {
            
            r.root = double.NaN;
            r.error = (int)ROOT_ERRORS.RUNAWAY;
            
        }

        public static void CycleError(RootObj r)
        {
           
            r.root = double.NaN;
            r.error = (int)ROOT_ERRORS.CYCLE;
            
        }
    }
}
