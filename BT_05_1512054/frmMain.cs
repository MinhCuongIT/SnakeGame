using System;
using System.Drawing;
using System.Windows.Forms;
//1512054-TranMinhCuong
namespace BT_05_1512054
{
    /// <summary>
    /// Màn hình chơi game
    /// </summary>
    public partial class frmMain : Form
    {
        #region Properties
        /// <summary>
        /// Điều hướng con rắn: 0-Phải, 1-Xuống, 2-Trái, 3-Lên
        /// </summary>
        private int direction = 0;
        /// <summary>
        /// Điểm số
        /// </summary>
        private int score = 0;
        /// <summary>
        /// Timer chơi trò chơi
        /// </summary>
        private Timer timer = new Timer();
        /// <summary>
        /// Biến tạo con mồi ngẫu nhiên
        /// </summary>
        private Random rand = new Random();
        /// <summary>
        /// Biến lưu trữ đối tượng đồ họa
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// Đối tượng con rắn
        /// </summary>
        private Snake snake;
        /// <summary>
        /// Đối tượng thức ăn
        /// </summary>
        private Food food;
        /// <summary>
        /// Đối tượng bức tường
        /// </summary>
        private Wall Wall;
        #endregion

        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo đối tượng bức tường
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            this.snake = new Snake();
            this.food = new Food(rand);
            this.Wall = new Wall(300, 200);
            this.timer.Interval = 100;
            this.timer.Tick += Update;
        }
        #endregion

        #region Events
        /// <summary>
        /// Xử lý khi người dùng nhấn phím và điều hướng con rắn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (this.lblMenu.Visible)
                    {
                        this.lblMenu.Visible = false;
                        this.timer.Start();
                    }
                    break;
                case Keys.Space:
                    if (!this.lblMenu.Visible)
                    {
                        this.timer.Enabled = (this.timer.Enabled) ? false : true;
                    }
                    break;
                case Keys.Right:
                    if (this.direction != 2)
                    {
                        this.direction = 0;
                    }
                    break;
                case Keys.Down:
                    if (this.direction != 3)
                    {
                        this.direction = 1;
                    }
                    break;
                case Keys.Left:
                    if (this.direction != 0)
                    {
                        this.direction = 2;
                    }
                    break;
                case Keys.Up:
                    if (this.direction != 1)
                    {
                        this.direction = 3;
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Vẽ lên form các đối tượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            this.graphics = this.CreateGraphics();
            this.snake.Draw(this.graphics);
            this.food.Draw(this.graphics);
            this.Wall.Draw(this.graphics);
        }
        /// <summary>
        /// Cập nhật lại các trạng thái
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            this.Text = string.Format("Snake score: {0}", this.score);
            this.snake.Move(this.direction);
            //Kiem tra dung do
            for (int i = 1; i < this.snake.Body.Length; i++)
            {
                //Con ran tu can than minh  
                if (this.snake.Body[0].IntersectsWith(this.snake.Body[i]))
                {

                    Restart();
                }
            }
            //Dung tuong
            if (this.snake.Body[0].X < 10 || this.snake.Body[0].X > 290 - 10)
            {
                Restart();
            }
            if (this.snake.Body[0].Y < 10 || this.snake.Body[0].Y > 190 - 10)
            {
                Restart();
            }
            //An duoc con moi
            if (this.snake.Body[0].IntersectsWith(this.food.Piece))
            {
                this.score++;
                this.snake.Grow();
                this.food.Generate(rand);
            }
            this.Invalidate();
        }
        #endregion

        #region Method
        /// <summary>
        /// Chơi lại trò chơi
        /// </summary>
        private void Restart()
        {
            this.timer.Stop();
            this.graphics.Clear(SystemColors.Control);
            this.snake = new Snake();
            this.food = new Food(rand);
            this.direction = 0;
            this.score = 0;
            lblMenu.Visible = true;
        }
        #endregion
    }
}
