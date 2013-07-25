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
    class Matahari
    {
            
        int list;
        float rotasi;

        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
            Gl.glDisable(Gl.GL_LIGHTING);
            Glu.gluSphere(quadratic, 3, 32, 32);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public void Paint()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("Matahari.jpg"));
            Gl.glPushMatrix();
            rotasi += 0.05f;
            Gl.glRotatef(rotasi, 0, 1, 0);
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
