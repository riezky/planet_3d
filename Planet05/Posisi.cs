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
using System.Linq;
using System.Text;

namespace Planet05
{
    enum AllPlanet
    {
        
        merkuri,
        venus,
        bumi,
        mars,
        jupiter,
        saturnus,
        uranus,
        neptunus,
        pluto
    }
    public struct Pos
    {
        public float x;
        public float y;
        public float z;

        public Pos(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    class Posisi
    {
        //inisialisasi
        Kamera camera = new Kamera();
        Matahari sol = new Matahari();
        List<Planet> planetas = new List<Planet>();
        Bintang kelip = new Bintang();

        public void CreateScene()
        {
            //Pembuatan posisi Planet
            planetas.Add(new Planet(0.5f, AllPlanet.merkuri, new Pos(5, 0, 0), "merkuri.jpg"));
            planetas.Add(new Planet(0.7f, AllPlanet.venus, new Pos(11, 0, 0), "venus.jpg"));
            planetas.Add(new Planet(1, AllPlanet.bumi, new Pos (15,0,0), "Bumi.jpg"));
            planetas.Add(new Planet(1, AllPlanet.mars, new Pos(22, 0, 0), "mars.jpg"));
            planetas.Add(new Planet(1.5f, AllPlanet.jupiter, new Pos(28, 0, 0), "jupiter.jpg"));
            planetas.Add(new Planet(1.2f, AllPlanet.saturnus, new Pos(35, 0, 0), "saturnus.bmp"));
            planetas.Add(new Planet(1.2f, AllPlanet.uranus, new Pos(41, 0, 0), "uranus.jpg"));
            planetas.Add(new Planet(1.2f, AllPlanet.neptunus, new Pos(51, 0, 0), "Neptunus.jpg"));
            planetas.Add(new Planet(1.2f, AllPlanet.pluto, new Pos(60, 0, 0), "Pluto.jpg"));

            //bintang (jumlah bintang)
            kelip.BuatBintang(500);

            //matahari
            sol.Create();

            //Pembuatan set planet
            foreach (var item in planetas)
            {
                item.Create();
            }
        }


        public Kamera Camara
        {
            get { return camera; }
        }

        public void DrawScene()
        {

            kelip.Draw();
            sol.Paint();
            foreach (var item in planetas)
            {
                item.Paint();
            }
            
        }
    }
}
