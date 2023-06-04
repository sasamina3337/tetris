using Microsoft.VisualBasic.ApplicationServices;

namespace tetris
{
    public partial class Form1 : Form
    {
        public int minoRow, minoCol, minoRotation, randomMino;
        public int[,] firstBoard = new int[22, 12]
            {
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 }
            };
        public int[,] board = new int[22, 12];
        public int[,] selectMino;


        public int[,,,] mino = new int[8, 4, 4, 4]
        {
            { //�Ȃɂ��Ȃ�
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
            },
            { //I�~�m
                { //��
                    {0,0,0,0},
                    {1,1,1,1},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,1,0},
                    {0,0,1,0},
                    {0,0,1,0},
                    {0,0,1,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {1,1,1,1},
                    {0,0,0,0}
                },
                { //��
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0}
                },
            },
            { //O�~�m
                { //��
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //��
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //��
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                }
            },
            { //S�~�m
                { //��
                    {0,0,0,0},
                    {0,3,3,0},
                    {3,3,0,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,3,0,0},
                    {0,3,3,0},
                    {0,0,3,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,3,3,0},
                    {3,3,0,0}
                },
                { //��
                    {0,0,0,0},
                    {3,0,0,0},
                    {3,3,0,0},
                    {0,3,0,0}
                },
            },
            { //Z�~�m
                { //��
                    {0,0,0,0},
                    {4,4,0,0},
                    {0,4,4,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,0,4,0},
                    {0,4,4,0},
                    {0,4,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {4,4,0,0},
                    {0,4,4,0}
                },
                { //��
                    {0,0,0,0},
                    {0,4,0,0},
                    {4,4,0,0},
                    {4,0,0,0}
                },
            },
            { //J�~�m
                { //��
                    {0,0,0,0},
                    {5,0,0,0},
                    {5,5,5,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,5,5,0},
                    {0,5,0,0},
                    {0,5,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {5,5,5,0},
                    {0,0,5,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,5,0},
                    {5,5,5,0}
                },
            },
            { //L�~�m
                { //��
                    {0,0,0,0},
                    {0,0,6,0},
                    {6,6,6,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,6,0,0},
                    {0,6,0,0},
                    {0,6,6,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {6,6,6,0},
                    {6,0,0,0}
                },
                { //��
                    {0,0,0,0},
                    {6,6,0,0},
                    {0,6,0,0},
                    {0,6,0,0}
                },
            },
            { //T�~�m
                { //��
                    {0,0,0,0},
                    {0,7,0,0},
                    {7,7,7,0},
                    {0,0,0,0}
                },
                { //�E
                    {0,0,0,0},
                    {0,7,0,0},
                    {0,7,7,0},
                    {0,7,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,0,0,0},
                    {7,7,7,0},
                    {0,7,0,0}
                },
                { //��
                    {0,0,0,0},
                    {0,7,0,0},
                    {7,7,0,0},
                    {0,7,0,0}
                },
            },
        };

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
            boarder = 8
        }

        public Dictionary<minoColor, Color> minoBackColor = new Dictionary<minoColor, Color>()
        {
            {minoColor.none, Color.DarkGray},
            {minoColor.i, Color.Cyan},
            {minoColor.o, Color.Yellow},
            {minoColor.s, Color.Green},
            {minoColor.z, Color.Red},
            {minoColor.j, Color.Blue},
            {minoColor.l, Color.Orange},
            {minoColor.t, Color.Purple},
            {minoColor.boarder, Color.Black}
        };

        public Form1()
        {
            InitializeComponent();
            initialSet();
        }

        //�����ݒ�
        public void initialSet()
        {
            //�����_���Ƀ~�m�̎�ނ�I��
            Random random = new Random();
            randomMino = random.Next(1, 8);

            //�����̃~�m�̈ʒu
            minoRow = 0;
            minoCol = 5;
            minoRotation = 0;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            inMinoBoard();
            //�����o��
            Drow(board);
            //���Ԃ��Ƃɗ����鏈��
            if (minoEnable(board, 1, 0))
            {
                minoRow++;
            }
            else
            {
                minoConflict();
                Drow(board);
                //�����{�[�h�ɕۑ�
                shiftBoard(firstBoard, board);
                timer.Stop();
                initialSet();
            }

        }

        public void Drow(int[,] n)
        {
            Control[] c;
            PictureBox pic;
            string boxName;
            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 1; j < board.GetLength(1); j++)
                {
                    boxName = Convert.ToString(i * board.GetLength(1) + j);
                    c = this.Controls.Find("pictureBox" + boxName, true);
                    pic = (PictureBox)c[0];
                    pic.BackColor = minoBackColor[(minoColor)n[i, j]];
                }
            }
        }

        //�L�[�{�[�h�̏���
        private void keyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {

                if(minoEnable(board, 0, 1)) minoCol++;
                inMinoBoard();
                Drow(board);
            }
            if(e.KeyCode == Keys.Left)
            {
                if(minoEnable(board, 0, -1)) minoCol--;
                inMinoBoard();
                Drow(board);
            }
            if(e.KeyCode == Keys.Up)
            {
                minoRotation = (minoRotation + 1) % 4;
                inMinoBoard();
                Drow(board);
            }

            if(e.KeyCode == Keys.Down)
            {
                while (minoEnable(board, 1, 0))
                {
                    minoRow++;
                    inMinoBoard();
                }
                minoConflict();
                Drow(board);
                shiftBoard(firstBoard, board);
                timer.Stop();
                initialSet();
            }
        }

        //mino��board�ɏ������ޏ���
        public void inMinoBoard()
        {
            int[,] oneMino = new int[4,4];

            //������
            shiftBoard(board, firstBoard);
            

            //�܂���0���������߂ɑI������mino�����o��
            for (int i = 0; i < mino.GetLength(2); i++)
            {
                for (int j = 0; j < mino.GetLength(3); j++)
                {
                    oneMino[i, j] = mino[randomMino, minoRotation, i, j];
                }
            }

            minoTransform(oneMino);

            //���o����
            for (int i = 0; i < selectMino.GetLength(0); i++)
            {
                for (int j = 0; j < selectMino.GetLength(1); j++)
                {
                    if (selectMino[i, j] != 0) board[i + minoRow, j + minoCol] = selectMino[i, j];
                }
            }
        }

        //�w�肳�ꂽmino�̎����0������
        public void minoTransform(int[,] oneMino)
        {

            // ��[���̍s�Ɨ�͈̔͂�������
            int minRow = int.MaxValue;
            int maxRow = int.MinValue;
            int minCol = int.MaxValue;
            int maxCol = int.MinValue;

            for (int i = 0; i < oneMino.GetLength(0); i++)
            {
                for (int j = 0; j < oneMino.GetLength(1); j++)
                {
                    if (oneMino[i, j] != 0)
                    {
                        minRow = Math.Min(minRow, i);
                        maxRow = Math.Max(maxRow, i);
                        minCol = Math.Min(minCol, j);
                        maxCol = Math.Max(maxCol, j);
                    }
                }
            }

            // ��[���͈͓̔��̗v�f��V�����z��ɃR�s�[����
            selectMino = new int[maxRow - minRow + 1, maxCol - minCol + 1];

            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minCol; j <= maxCol; j++)
                {
                    selectMino[i - minRow, j - minCol] = oneMino[i, j];
                }
            }
        }

        //4�����̓����蔻��
        public Boolean minoEnable(int[,] beforeBoard, int arowMino,int acolMino)
        {
            List<int[]> canSlide = new List<int[]>();
            for(int i = 0; i < beforeBoard.GetLength(0); i++)
            {
                for(int j = 0; j < beforeBoard.GetLength(1); j++)
                {
                    if (beforeBoard[i,j] != 0 && beforeBoard[i, j] != 8)
                    {
                        int[] addlist = { i, j };
                        canSlide.Add(addlist);
                    }
                }
            }

            for (int i = 0; i < canSlide.Count; i++)
            {
                int selectRow = canSlide[i][0];
                int selectCol = canSlide[i][1];
                if ((beforeBoard[(selectRow + arowMino), (selectCol + acolMino)]) == 8)
                {
                    return false;
                }
            }

            return true ;
        }

        //���ɗ������Ƃ��Ɍł܂鏈��
        public void minoConflict()
        {
            List<int[]> canSlide = new List<int[]>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0 && board[i, j] != 8)
                    {
                        int[] addlist = { i, j };
                        canSlide.Add(addlist);
                    }
                }
            }

            for (int i = 0; i < canSlide.Count; i++)
            {
                int selectRow = canSlide[i][0];
                int selectCol = canSlide[i][1];
                board[selectRow, selectCol] = 8;
            }
        }

        //board�̓���ւ�
        public void shiftBoard(int[,] n, int[,] m)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    n[i, j] = m[i, j];
                }
            }
        }
    }
}