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
using System.Runtime.InteropServices;
namespace Planet05
{

        public struct Pointer
        {
            public int x;
            public int y;
        }

        public static class Import
        {
            // interop servis sebelum masuk ke Form Main
            [DllImport("GDI32.dll")]
            public static extern void SwapBuffers(uint hdc);
            [DllImport("user32.dll")]
            public static extern void SetCursorPos(int x, int y);
            [DllImport("user32.dll")]
            public static extern void GetCursorPos(ref Pointer point);
        }
    }

