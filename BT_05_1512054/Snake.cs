using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
//1512054-TranMinhCuong
namespace BT_05_1512054
{
    /// <summary>
    /// Con rắn
    /// </summary>
    public class Snake
    {
        #region Properties
        /// <summary>
        /// Mảng các ô thân con rắn
        /// </summary>
        public Rectangle[] Body;
        /// <summary>
        /// Tọa độ bắt đầu và chiều rộng, chiều cao của của các ô của con rắn
        /// </summary>
        private int x = 10, y = 10, width = 10, height = 10;
        #endregion

        #region Constructors
        /// <summary>
        /// Khởi tạo con rắn
        /// </summary>
        public Snake()
        {
            this.Body = new Rectangle[1];
            this.Body[0] = new Rectangle(this.x, this.y, this.width, this.height);
        }
        #endregion

        #region Events

        #endregion

        #region Methods
        /// <summary>
        /// Vẽ lại con rắn nguyên cái mảng của nó
        /// </summary>
        public void Draw()
        {
            for (int i = this.Body.Length - 1; i > 0; i--)
            {
                this.Body[i] = this.Body[i - 1];
            }
        }
        /// <summary>
        /// Vẽ lại con rắn lên form
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangles(Brushes.Green, Body);
            graphics.FillRectangle(Brushes.Red, Body[0]);
        }
        /// <summary>
        /// Con rắn di chuyển
        /// </summary>
        /// <param name="derection"></param>
        public void Move(int derection)
        {
            Draw();
            switch (derection)  //0-Phai, 1-Xuong, 2-Trai, 3-Len
            {
                case 0:
                    this.Body[0].X += 10;
                    break;
                case 1:
                    this.Body[0].Y += 10;
                    break;
                case 2:
                    this.Body[0].X -= 10;
                    break;
                case 3:
                    this.Body[0].Y -= 10;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Con rắn lớn lên
        /// </summary>
        public void Grow()
        {
            List<Rectangle> rectangles = Body.ToList();
            rectangles.Add(new Rectangle(this.Body[this.Body.Length - 1].X, this.Body[this.Body.Length - 1].Y, this.width, this.height));
            this.Body = rectangles.ToArray();
        }
        #endregion
    }
}
