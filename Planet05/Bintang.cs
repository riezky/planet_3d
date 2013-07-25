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



namespace Planet05
{
    class Bintang
    {
        //Mengambil inisial dari posisi.pos
        List<Pos> stars = new List<Pos>();

        public void BuatBintang(int amount)
        {
            Random r = new Random();
            int count = 0;

            while (count != amount)
            {
                // set titik bintang secara random
                Pos p = default(Pos);
                p.x = (r.Next(110)) * (float)Math.Pow(-1, r.Next());
                p.z = (r.Next(110)) * (float)Math.Pow(-1, r.Next());
                p.y = (r.Next(110)) * (float)Math.Pow(-1, r.Next());
                if (Math.Pow(Math.Pow(p.x, 2) + Math.Pow(p.y, 2) + Math.Pow(p.z, 2), 1 / 3f) > 15)
                {
                    stars.Add(p);
                    count++;
                }
            }
        }

        public void Draw()
        {
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3f(1, 1, 1);//Warna Bintang
            Gl.glPointSize(3);


            foreach (var item in stars)
            {
                Gl.glVertex3f(item.x, item.y, item.z);

            }
            Gl.glEnd();
        }

    }
}
