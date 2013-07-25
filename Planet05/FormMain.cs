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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShadowEngine;
using ShadowEngine.OpenGL;
using Tao.OpenGl; 

namespace Planet05
{
    
    




    public partial class FormMain : Form
    {
        //Inisialisasi
        uint hdc;
        Posisi simpan = new Posisi();
        static Vector2 formPos;
        static bool showOrbit = true;
        int movemouse;

        public static Vector2 FormPos
        {
            get { return FormMain.formPos; }
            set { FormMain.formPos = value; }
        }

        public static bool ShowOrbit
        {
            get { return FormMain.showOrbit; }
            set { FormMain.showOrbit = value; }
        } 

        public FormMain()
        {
            InitializeComponent();
            hdc = (uint)panel.Handle;
            string error = "";
            //inisialisasi perintah view pada panel
            OpenGLControl.OpenGLInit(ref hdc, panel.Width,panel.Height, ref error);
            //sudut pandang kamera 

            if (error != "")
            {
                MessageBox.Show(error);
            }
            
            simpan.Camara.InitCamara();


            //mengaktifkan cahaya
            float[] materialDiffuse = { 0.8F, 0.8F, 0.8F, 1.0F };
            float[] materialSpecular = { 5.0F, 5.0F, 5.0F, 1.0F };
            float[] materialShininess = {100.0F };//kecerahan
            float[] ambientLightPosition = { 0F, 0.0F, 0F, 1F }; // posisi cahaya
            float[] lightAmbient = { 0.2F, 0.2F, 0.2F, 1.0f }; // Intensitas cahaya (RGB,A)

            
            Lighting.MaterialDiffuse = materialDiffuse;
            Lighting.MaterialShininess = materialShininess;
            Lighting.AmbientLightPosition = ambientLightPosition;
            Lighting.LightAmbient = lightAmbient;

            //load lighting
            Lighting.SetupLighting();


            //mengambil teksture
            ContentManager.SetTextureList("Tekstur\\");
            ContentManager.LoadTextures();
            simpan.CreateScene();
            Kamera.CenterMouse();
            // warna latarbelakang
            Gl.glClearColor(0, 0, 0, 1);//red green blue alpha 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            simpan.Camara.Update(movemouse);
            simpan.DrawScene();
            
            Import.SwapBuffers(hdc);

            Gl.glFlush();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            formPos = new Vector2(this.Left, this.Top);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.O)
            {
                if (showOrbit == true)
                    showOrbit = false;
                else
                    showOrbit = true;
            }

        }


        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            movemouse = 0;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
