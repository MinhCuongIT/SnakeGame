using System;
using System.Drawing;
//1512054-TranMinhCuong
namespace BT_05_1512054
{
    /// <summary>
    /// Mồi
    /// </summary>
    public class Food
    {
        #region properties
        /// <summary>
        /// Ô thể hiện mồi
        /// </summary>
        public Rectangle Piece;
        /// <summary>
        /// Tọa độ và chiều rộng chiều cao của mồi
        /// </summary>
        private int x, y, width = 10, height = 10;
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo mồi
        /// </summary>
        /// <param name="random"></param>
        public Food(Random random)
        {
            Generate(random);
            this.Piece = new Rectangle(this.x, this.y, this.width, this.height);
        }
        #endregion

        #region Events

        #endregion

        #region Methods
        /// <summary>
        /// Vẽ mồi lên form
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            this.Piece.X = this.x;
            this.Piece.Y = this.y;
            graphics.FillRectangle(Brushes.Brown, this.Piece);
        }
        /// <summary>
        /// Genertate mồi mới
        /// </summary>
        /// <param name="random"></param>
        public void Generate(Random random)
        {
            this.x = random.Next(1, 30) * 10;
            this.y = random.Next(1, 20) * 10;
        }
        #endregion
    }
}
