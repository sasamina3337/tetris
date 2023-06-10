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
            { //なにもない
                { //上
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //左
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,0,0,0}
                },
            },
            { //Iミノ
                { //上
                    {0,0,0,0},
                    {1,1,1,1},
                    {0,0,0,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,1,0},
                    {0,0,1,0},
                    {0,0,1,0},
                    {0,0,1,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {1,1,1,1},
                    {0,0,0,0}
                },
                { //左
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,0,0}
                },
            },
            { //Oミノ
                { //上
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //下
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                },
                { //左
                    {0,0,0,0},
                    {2,2,0,0},
                    {2,2,0,0},
                    {0,0,0,0}
                }
            },
            { //Sミノ
                { //上
                    {0,0,0,0},
                    {0,3,3,0},
                    {3,3,0,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,3,0,0},
                    {0,3,3,0},
                    {0,0,3,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {0,3,3,0},
                    {3,3,0,0}
                },
                { //左
                    {0,0,0,0},
                    {3,0,0,0},
                    {3,3,0,0},
                    {0,3,0,0}
                },
            },
            { //Zミノ
                { //上
                    {0,0,0,0},
                    {4,4,0,0},
                    {0,4,4,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,0,4,0},
                    {0,4,4,0},
                    {0,4,0,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {4,4,0,0},
                    {0,4,4,0}
                },
                { //左
                    {0,0,0,0},
                    {0,4,0,0},
                    {4,4,0,0},
                    {4,0,0,0}
                },
            },
            { //Jミノ
                { //上
                    {0,0,0,0},
                    {5,0,0,0},
                    {5,5,5,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,5,5,0},
                    {0,5,0,0},
                    {0,5,0,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {5,5,5,0},
                    {0,0,5,0}
                },
                { //左
                    {0,0,0,0},
                    {0,0,5,0},
                    {0,0,5,0},
                    {0,5,5,0}
                },
            },
            { //Lミノ
                { //上
                    {0,0,0,0},
                    {0,0,6,0},
                    {6,6,6,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,6,0,0},
                    {0,6,0,0},
                    {0,6,6,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {6,6,6,0},
                    {6,0,0,0}
                },
                { //左
                    {0,0,0,0},
                    {6,6,0,0},
                    {0,6,0,0},
                    {0,6,0,0}
                },
            },
            { //Tミノ
                { //上
                    {0,0,0,0},
                    {0,7,0,0},
                    {7,7,7,0},
                    {0,0,0,0}
                },
                { //右
                    {0,0,0,0},
                    {0,7,0,0},
                    {0,7,7,0},
                    {0,7,0,0}
                },
                { //下
                    {0,0,0,0},
                    {0,0,0,0},
                    {7,7,7,0},
                    {0,7,0,0}
                },
                { //左
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

        //初期設定
        public void initialSet()
        {
            //ランダムにミノの種類を選択
            Random random = new Random();
            randomMino = random.Next(1, 8);

            //初期のミノの位置
            minoRow = 0;
            minoCol = 5;
            minoRotation = 0;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            inMinoBoard(false);
            //書き出し
            Drow(board);
            //時間ごとに落ちる処理
            if (minoEnable(board, 1, 0))
            {
                minoRow++;
            }
            else
            {
                minoConflict();
                Drow(board);
                minoErase();
                //初期ボードに保存
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

        //キーボードが押されときの処理
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (!keyList.Contains(e.KeyCode))
            {
                keyTimer.Start();
                keyList.Add(e.KeyCode);
            }
        }

        //キーボードが持ち上がっときの処理
        private void keyUp(object sender, KeyEventArgs e)
        {
            if (keyList.Contains(e.KeyCode))
            {
                keyTimer.Stop();
                keyList.Remove(e.KeyCode);
            }
        }

        //キーボードのの処理のタイマー
        private void pressKey(object sender, EventArgs e)
        {
            //keyの処理
            if (keyList.Count > 0)
            {
                Keys pressKey = keyList[0];
                if (keyList.Contains(pressKey))
                {
                    switch (pressKey)
                    {
                        //エンター
                        case Keys.Enter:
                            shiftBoard(memoryBoard, firstBoard);
                            Drow(memoryBoard);
                            initialSet();
                            label.Text = "←:Left →:Right ↑:Rotation Enter:Reset";
                            break;
                        //右
                        case Keys.Right:
                            if (judge()) break;
                            if (minoEnable(board, 0, 1)) minoCol++;
                            inMinoBoard(false);
                            Drow(board);
                            break;
                        //左
                        case Keys.Left:
                            if (judge()) break;
                            if (minoEnable(board, 0, -1)) minoCol--;
                            inMinoBoard(false);
                            Drow(board);
                            break;
                        //上
                        case Keys.Up:
                            if (judge()) break;
                            timer.Stop();
                            minoRotation = (minoRotation + 1) % 4;
                            inMinoBoard(true);
                            Drow(board);
                            timer.Start();
                            break;
                        //下
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

        //minoをboardに書き込む処理
        public void inMinoBoard(Boolean rotation)
        {
            int[,] oneMino = new int[4, 4];

            //初期化
            shiftBoard(board, memoryBoard);


            //まわりの0を消すために選択したminoを取り出す
            for (int i = 0; i < mino.GetLength(2); i++)
            {
                for (int j = 0; j < mino.GetLength(3); j++)
                {
                    oneMino[i, j] = mino[randomMino, minoRotation, i, j];
                }
            }

            minoTransform(oneMino);

            //取り出した
            for (int i = 0; i < selectMino.GetLength(0); i++)
            {
                for (int j = 0; j < selectMino.GetLength(1); j++)
                {
                    //代入するミノの0以外の場合のみ
                    if (selectMino[i, j] != 0)
                    {
                        if (rotation)
                        {
                            //回転の時の処理
                            //回転した時にboard内が0ではない場合
                            if (i + minoRow < board.GetLength(0) && j + minoCol < board.GetLength(1))
                            {
                                if (board[i + minoRow, j + minoCol] != 0)
                                {
                                    //Iミノの時の処理
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
                                    //それ以外のミノの時の処理
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

        //Iミノ以外を3×3の行列にする
        public void minoTransform(int[,] oneMino)
        {
            int newRow, newCol;
            newRow = oneMino.GetLength(0);
            newCol = oneMino.GetLength(1);

            //Iミノ以外は行列の幅を減らす
            if (randomMino != 1)
            {
                newRow--;
                newCol--;
            }
            selectMino = new int[newRow, newCol];

            //変換する処理
            for (int i = (oneMino.GetLength(0) - newRow); i < oneMino.GetLength(0); i++)
            {
                for (int j = 0; j < newCol; j++)
                {
                    selectMino[i - (oneMino.GetLength(0) - newRow), j] = oneMino[i, j];
                }
            }
        }

        //4方向の当たり判定
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

        //下に落ちたときに固まる処理
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

        //boardの入れ替え
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

        //一列消す
        public void minoErase()
        {
            //全ての列でカウント
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                int eraseCount = 0;
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] == 8)
                    {
                        eraseCount++;
                        //一列そろった時
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
            //描画
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