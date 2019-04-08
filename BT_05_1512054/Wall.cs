using System;
using System.Drawing;
//1512054-TranMinhCuong
namespace BT_05_1512054
{
    /// <summary>
    /// Bức tường
    /// </summary>
    class Wall
    {
        #region Properties
        /// <summary>
        /// Chiều dài và chiều rộng
        /// </summary>
        private int width, height;
        /// <summary>
        /// Mảng các điểm tạo thành bức tường hình chữ nhật
        /// </summary>
        private Point[] points;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm dựng bước tường
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Wall(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.points = new Point[4];
            this.points[0] = new Point(0, 0);
            this.points[1] = new Point(width, 0);
            this.points[2] = new Point(width, height);
            this.points[3] = new Point(0, height);

        }
        #endregion

        #region Events

        #endregion

        #region Methods
        /// <summary>
        /// Vẽ bức tường
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Gray, 10), points[0], points[1]);
            graphics.DrawLine(new Pen(Color.Gray, 10), points[1], points[2]);
            graphics.DrawLine(new Pen(Color.Gray, 10), points[2], points[3]);
            graphics.DrawLine(new Pen(Color.Gray, 10), points[0], points[3]);
        }
        #endregion
    }
}
