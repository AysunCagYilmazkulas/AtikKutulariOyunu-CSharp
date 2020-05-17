/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**		  BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**			    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**			   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1.Proje/Tasarim
**				ÖĞRENCİ ADI............: AYSUN ÇAĞ YILMAZKULAŞ
**				ÖĞRENCİ NUMARASI.......: G191210373
**              DERSİN ALINDIĞI GRUP...: B
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Dergi : IAtik
    {
        public int Hacim { get => 200; }
        public Image Image { get => Properties.Resources.dergi; }
    }
}
