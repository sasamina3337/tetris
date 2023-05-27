using Microsoft.VisualBasic.ApplicationServices;

namespace tetris
{
    public partial class Form1 : Form
    {
        public int[,] board = new int[10, 20];

        public int[,] minoI = new int[2.3] { { 1, 1, 1} { } }
        public int[,] minoT = new int[2, 3] { { 0, 3, 0 }, { 3, 3, 3 } };

        public enum minoColor
        {
            none = 0,
            i = 1,
            o = 2,
            s = 3,
            z = 4,
            j = 5,
            l = 6,
            t = 7,
        }

        public Dictionary<minoColor, Color> stoneImg = new Dictionary<minoColor, Color>()
        {
            {minoColor.none, Color.DarkGray},
            {minoColor.i, Color.Cyan},
            {minoColor.o, Color.Yellow},
            {minoColor.s, Color.Green},
            {minoColor.z, Color.Red},
            {minoColor.j, Color.Blue},
            {minoColor.l, Color.Orange},
            {minoColor.t, Color.Purple}
        };

        public Form1()
        {
            InitializeComponent();
        }


    }
}