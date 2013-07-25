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
using ShadowEngine;

namespace Planet05
{
    class Planet
    {
        AllPlanet tipe;
        Pos p;
        float angelrotasi;
        float angelOrbit;
        float orbit;
        static Random r = new Random();
        float radio;
        int list;
        string texture;

        public Planet(float radio, AllPlanet tipe, Pos position, string texture)
        {
            this.radio = radio;
            this.tipe = tipe;
            p = position;
            angelOrbit = r.Next(360);
            orbit = (float)r.NextDouble() * 0.3f;
            this.texture = texture;

        }
        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric(); //Buat Objek
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1); // buat list
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(270, 1, 0, 0);
            Glu.gluSphere(quadratic, radio, 32, 32); //daerah planet
            Gl.glPopMatrix();
            Gl.glEndList();

        }
        public void DrawOrbit()
        {

            //Membuat orbit untuk perputaran planet
            Gl.glBegin(Gl.GL_LINE_STRIP);

            for (int i = 0; i < 361; i++)
            {
                Gl.glVertex3f(p.x * (float)Math.Sin(i * Math.PI / 180), 0, p.x * (float)Math.Cos(i * Math.PI / 180));
            }
            Gl.glEnd();
        }
        public void Paint()
        {
            if (FormMain.ShowOrbit)
            {
                DrawOrbit();
            }

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(texture));
            Gl.glPushMatrix();
            angelOrbit += orbit;
            angelrotasi += 0.6f;
            Gl.glRotatef(angelOrbit, 0, 1, 0);
            Gl.glTranslatef(-p.x, -p.y, -p.z);

            Gl.glRotatef(angelrotasi, 0, 1, 0);
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
