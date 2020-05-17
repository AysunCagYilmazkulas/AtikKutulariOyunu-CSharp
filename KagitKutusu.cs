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

namespace WindowsFormsApp1
{
    class KagitKutusu : IAtikKutusu
    {
        private int _bosaltmaPuani = 1000; private int _kapasite = 1200; private int _doluHacim; private int _dolulukOrani;
        int IAtikKutusu.BosaltmaPuani { get { return _bosaltmaPuani; } }

        int IDolabilen.Kapasite
        {
            get { return _kapasite; }
            set { _kapasite = value; }
        }

        int IDolabilen.DoluHacim { get { return _doluHacim; } set { _doluHacim = value; } }

        int IDolabilen.DolulukOrani { get { return _doluHacim / _kapasite; } }

        bool IAtikKutusu.Bosalt()
        {
            if (_doluHacim >= _kapasite*75 / 100)
            {
                return true;
            }
            else
                return false;
        }

        bool IAtikKutusu.Ekle(IAtik atik)
        {
            if (_kapasite - _doluHacim >= atik.Hacim)
            {
                return true;
            }
            else
                return false;
        }
    }
}
