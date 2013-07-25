/*KELOMPOK 8
 * IF 9
 * 
 *  Deni Ariyanto / 10109372
 *  Rahmat Mulyana / 10109402
 *  Muhammad Rizky / 10109405
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Drawing;

namespace Planet05
{
    class Kamera
    {
        #region Camera constants

        const double div1 = Math.PI / 180;
        const double div2 = 180 / Math.PI;

        #endregion


        //inisialisasi kamera init camara
        #region Private atributes

        static float rotationSpeed = 0.25f;
        static double i, j, k;
        static float yaw, pitch;
        static float eyex, eyey, eyez;
        static float centerx, centery, centerz;
       

        #endregion

        public static float Pitch
        {
            get { return Kamera.pitch; }
            set { Kamera.pitch = value; }
        }

        public static float Yaw
        {
            get { return Kamera.yaw; }
            set { Kamera.yaw = value; }
        }

        public void InitCamara()
        {
            eyex = 0f;
            eyey = 8f;
            eyez = 70f;
            centerx = 0;
            centery = 2;
            centerz = 0;
            Look();
        }



        public void Look()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(eyex, eyey, eyez, centerx, centery, centerz, 0, 1, 0);
        }

        static public float angleradian(double pAngle)
        {
            return (float)(pAngle * div1);
        }

        static public float radianangle(double pAngle)
        {
            return (float)(pAngle * div2);
        }


                public void UpdateDirVector()
        {
            k = Math.Cos(angleradian((double)yaw)); //sumbu z
            i = -Math.Sin(angleradian((double)yaw)); // sumbu x
            j = Math.Sin(angleradian((double)pitch)); // sumbyu y      

            centerz = eyez - (float)k; // perhitungan kamera
            centerx = eyex - (float)i;
            centery = eyey - (float)j;
        }

        public static void CenterMouse()
        {
            Import.SetCursorPos(FormMain.FormPos.X + 512, FormMain.FormPos.Y + 384);
        }
        public void Update(int pressedButton)
        {
            #region Aim camera

            Pointer position = new Pointer();
            Import.GetCursorPos(ref position);

            int difX = FormMain.FormPos.X + 512 - position.x;
            int difY = FormMain.FormPos.Y + 384 - position.y;

            if (position.y < 384)
            {
                pitch -= rotationSpeed * difY;
            }
            else
                if (position.y > 384)
                {
                    pitch += rotationSpeed * -difY;
                }
            if (position.x < 512)
            {
                yaw += rotationSpeed * -difX;
            }
            else
                if (position.x > 512)
                {
                    yaw -= rotationSpeed * difX;
                }
            UpdateDirVector();
            CenterMouse();
            #endregion
            Look();
        }
    }
}
