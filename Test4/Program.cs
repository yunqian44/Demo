using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    /// <summary>
    /// 方向包围盒对象
    /// </summary>
    public class OBB
    {
        /// <summary>
        /// 中心点坐标
        /// </summary>
        private float[] centerPoint;

        /// <summary>
        /// 物体自身宽度
        /// </summary>
        private float halfWidth;

        /// <summary>
        /// 物体自身高度
        /// </summary>
        private float halfHeight;

        /// <summary>
        /// X轴方向的单位矢量
        /// </summary>
        private float[] axisX;

        /// <summary>
        /// Y轴方向的单位矢量
        /// </summary>
        private float[] axisY;

        //旋转角度 0-360  
        private float rotation;

        /// <summary>
        /// 
        /// </summary>
        private float scaleX;

        /// <summary>
        /// 
        /// </summary>
        private float scaleY;


        private float offsetAxisPointDistance;

        /// <summary>
        /// 方向包围盒
        /// </summary>
        /// <param name="bornCenterX">X轴中心点</param>
        /// <param name="bornCenterY">Y周中心点</param>
        /// <param name="halfWidth">宽度</param>
        /// <param name="halfHeight">高度</param>
        public OBB(float bornCenterX, float bornCenterY, float halfWidth, float halfHeight)
        {

            this.halfWidth = halfWidth;
            this.halfHeight = halfHeight;

            this.scaleX = 1.0f;
            this.scaleY = 1.0f;

            this.centerPoint = new float[] {
                        bornCenterX,
                        bornCenterY
        };

            this.axisX = new float[2];
            this.axisY = new float[2];

            float[] offsetAxisPoint = new float[] {
                bornCenterX - Director.getHalfScreenWidth(),
                bornCenterY - Director.getHalfScreenHeight()
        };

            this.offsetAxisPointDistance = (float)Math.Sqrt(MathHelper.dot(offsetAxisPoint, offsetAxisPoint));

            this.offsetAxisPointDistance = (float)Math.Sqrt(MathHelper.dot(offsetAxisPoint, offsetAxisPoint));

            this.setRotation(0.0f);
        }

        public OBB(float halfWidth, float halfHeight)
        {
            this(Director.getHalfScreenWidth(), Director.getHalfScreenHeight(), halfWidth, halfHeight);
        }

        public float getProjectionRadius(float[] axis)
        {

            // axis, axisX and axisY are unit vector  

            // projected axisX to axis  
            float projectionAxisX = this.dot(axis, this.axisX);
            // projected axisY to axis  
            float projectionAxisY = this.dot(axis, this.axisY);


            return this.halfWidth * this.scaleX * projectionAxisX + this.halfHeight * this.scaleY * projectionAxisY;
        }

    }



    public static class MathHelper
    {
        /// <summary>
        /// 单位向量上的投影长度
        /// </summary>
        /// <param name="axisA">向量点</param>
        /// <param name="axisB">单位向量</param>
        /// <returns></returns>
        public static float dot(float[] axisA, float[] axisB)
        {
            return Math.Abs(axisA[0] * axisB[0] + axisA[1] * axisB[1]);
        }
    }
}
