using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Windows.Forms;
using static tetris.Form1;

namespace tetris
{
    public partial class Form1 : Form
    {
        public int minoRow, minoCol, minoRotation, randomMino, minoRotRow, minoRotCol;
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
        public int[,] memoryBoard = new int[22, 12];
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
                    {0,0,5,0},
                    {0,0,5,0},
                    {0,5,5,0}
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

        public int[,,] srsMino = new int[4, 5, 2]
        {
            {
                { 0, 0 },
                { 0,-2 },
                {-1,-2 },
                {-2, 0 },
                {-2,-1 }
            },
            {
                { 0, 0 },
                { 0,-1 },
                {-1,-1 },
                { 2, 0 },
                { 2,-1 }
            },
            {
                { 0, 0 },
                { 0,-1 },
                {-1, 1 },
                { 2, 0 },
                { 2, 1 }
            },
            {
                { 0, 0 },
                { 0,-1 },
                {-1, 1 },
                { 2, 0 },
                { 2, 1 }
            }
        };

        public int[,,] srsIMino = new int[4, 5, 2]
        {
            {
                { 0, 0 },
                { 0,-2 },
                { 0, 1 },
                { 2, 1 },
                {-1,-2 }
            },
            {
                { 0, 0 },
                { 0,-1 },
                { 0, 2 },
                {-2,-1 },
                { 1, 2 }
            },
            {
                { 0, 0 },
                { 0, 2 },
                { 0,-1 },
                {-1, 3 },
                { 2,-1 }
            },
            {
                { 0, 0 },
                { 0,-2 },
                { 0, 1 },
                { 2, 1 },
                {-1,-2 }
            }
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

        public Boolean minoRotEnable;

        private static List<Keys> keyList = new List<Keys>();

        public Form1()
        {
            InitializeComponent();
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
            inMinoBoard(false);
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
                minoErase();
                //�����{�[�h�ɕۑ�
                shiftBoard(memoryBoard, board);
                if (judge())
                {
                    timer.Stop();
                    label.Text = "Press The Enter";
                    MessageBox.Show("Game Over");

                    return;
                }
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

        //�L�[�{�[�h��������Ƃ��̏���
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (!keyList.Contains(e.KeyCode))
            {
                keyTimer.Start();
                keyList.Add(e.KeyCode);
            }
        }

        //�L�[�{�[�h�������オ���Ƃ��̏���
        private void keyUp(object sender, KeyEventArgs e)
        {
            if (keyList.Contains(e.KeyCode))
            {
                keyTimer.Stop();
                keyList.Remove(e.KeyCode);
            }
        }

        //�L�[�{�[�h�̂̏����̃^�C�}�[
        private void pressKey(object sender, EventArgs e)
        {
            //key�̏���
            if (keyList.Count > 0)
            {
                Keys pressKey = keyList[0];
                if (keyList.Contains(pressKey))
                {
                    switch (pressKey)
                    {
                        //�G���^�[
                        case Keys.Enter:
                            shiftBoard(memoryBoard, firstBoard);
                            Drow(memoryBoard);
                            initialSet();
                            label.Text = "��:Left ��:Right ��:Rotation Enter:Reset";
                            break;
                        //�E
                        case Keys.Right:
                            if (judge()) break;
                            if (minoEnable(board, 0, 1)) minoCol++;
                            inMinoBoard(false);
                            Drow(board);
                            break;
                        //��
                        case Keys.Left:
                            if (judge()) break;
                            if (minoEnable(board, 0, -1)) minoCol--;
                            inMinoBoard(false);
                            Drow(board);
                            break;
                        //��
                        case Keys.Up:
                            if (judge()) break;
                            timer.Stop();
                            minoRotation = (minoRotation + 1) % 4;
                            inMinoBoard(true);
                            Drow(board);
                            timer.Start();
                            break;
                        //��
                        case Keys.Down:
                            if (judge()) break;
                            while (minoEnable(board, 1, 0))
                            {
                                minoRow++;
                                inMinoBoard(false);
                            }
                            minoConflict();
                            Drow(board);

                            minoErase();
                            shiftBoard(memoryBoard, board);
                            if (judge())
                            {
                                timer.Stop();
                                label.Text = "Press The Enter";
                                MessageBox.Show("Game Over");
                                return;
                            }
                            timer.Stop();
                            initialSet();
                            break;
                    }
                    keyList.Remove(pressKey);
                }
            }
        }

        //mino��board�ɏ������ޏ���
        public void inMinoBoard(Boolean rotation)
        {
            int[,] oneMino = new int[4, 4];

            //������
            shiftBoard(board, memoryBoard);


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
                    //�������~�m��0�ȊO�̏ꍇ�̂�
                    if (selectMino[i, j] != 0)
                    {
                        if (rotation)
                        {
                            //��]�̎��̏���
                            //��]��������board����0�ł͂Ȃ��ꍇ
                            if (i + minoRow < board.GetLength(0) && j + minoCol < board.GetLength(1))
                            {
                                if (board[i + minoRow, j + minoCol] != 0)
                                {
                                    //I�~�m�̎��̏���
                                    if (randomMino == 1)
                                    {
                                        minoRotEnable = false;
                                        for (int k = 0; k < srsIMino.GetLength(1); k++)
                                        {
                                            minoRotRow = minoRow;
                                            minoRotCol = minoCol;
                                            minoRotRow = minoRotRow + srsIMino[minoRotation, k, 0];
                                            minoRotCol = minoRotCol + srsIMino[minoRotation, k, 1];
                                            if (i + minoRotRow > 0 && i + minoRotRow < board.GetLength(0) && minoRotCol + j > 0 && minoRotCol + j < board.GetLength(1))
                                            {
                                                if (board[i + minoRotRow, j + minoRotCol] == 0)
                                                {
                                                    minoRotEnable = true;
                                                    break;
                                                }
                                            }

                                        }

                                        if (minoRotEnable)
                                        {
                                            minoRow = minoRotRow;
                                            minoCol = minoRotCol;
                                            break;
                                        }
                                        else
                                        {
                                            minoRotation = (minoRotation + 3) % 4;
                                            break;
                                        }
                                    }
                                    //����ȊO�̃~�m�̎��̏���
                                    else
                                    {
                                        minoRotEnable = false;
                                        for (int k = 0; k < srsMino.GetLength(1); k++)
                                        {
                                            minoRotRow = minoRow;
                                            minoRotCol = minoCol;
                                            minoRotRow = minoRotRow + srsMino[minoRotation, k, 0];
                                            minoRotCol = minoRotCol + srsMino[minoRotation, k, 1];
                                            if (i + minoRotRow > 0 && i + minoRotRow < board.GetLength(0) && minoRotCol + j > 0 && minoRotCol + j < board.GetLength(1))
                                            {
                                                if (board[i + minoRotRow, j + minoRotCol] == 0)
                                                {
                                                    minoRotEnable = true;
                                                    break;
                                                }
                                            }

                                        }

                                        if (minoRotEnable)
                                        {
                                            minoRow = minoRotRow;
                                            minoCol = minoRotCol;
                                            break;
                                        }
                                        else
                                        {
                                            minoRotation = (minoRotation + 3) % 4;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    board[i + minoRow, j + minoCol] = selectMino[i, j];
                    }
                }
            }
        }

        //I�~�m�ȊO��3�~3�̍s��ɂ���
        public void minoTransform(int[,] oneMino)
        {
            int newRow, newCol;
            newRow = oneMino.GetLength(0);
            newCol = oneMino.GetLength(1);

            //I�~�m�ȊO�͍s��̕������炷
            if (randomMino != 1)
            {
                newRow--;
                newCol--;
            }
            selectMino = new int[newRow, newCol];

            //�ϊ����鏈��
            for (int i = (oneMino.GetLength(0) - newRow); i < oneMino.GetLength(0); i++)
            {
                for (int j = 0; j < newCol; j++)
                {
                    selectMino[i - (oneMino.GetLength(0) - newRow), j] = oneMino[i, j];
                }
            }
        }

        //4�����̓����蔻��
        public Boolean minoEnable(int[,] beforeBoard, int arowMino, int acolMino)
        {
            List<int[]> canSlide = new List<int[]>();
            for (int i = 0; i < beforeBoard.GetLength(0); i++)
            {
                for (int j = 0; j < beforeBoard.GetLength(1); j++)
                {
                    if (beforeBoard[i, j] != 0 && beforeBoard[i, j] != 8)
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

            return true;
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

        //������
        public void minoErase()
        {
            //�S�Ă̗�ŃJ�E���g
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                int eraseCount = 0;
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] == 8)
                    {
                        eraseCount++;
                        //��񂻂������
                        if (eraseCount >= 10)
                        {
                            for (int k = 1; k < board.GetLength(1) - 1; k++)
                            {
                                board[i, k] = 0;
                                for (int l = i; l > 0; l--)
                                {
                                    board[l, k] = board[(l - 1), k];
                                }

                            }
                        }
                    }
                }
            }
            //�`��
            Drow(board);
        }

        public Boolean judge()
        {
            for (int i = 1; i < board.GetLength(1) - 1; i++)
            {
                if (board[0, i] == 8)
                {
                    return true;
                }
            }
            return false;
        }
    }
}